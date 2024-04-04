using SistemaHotelaria;
using SistemaHotelaria.Models;
using System;
using System.Linq;

public static class GerenciadorHospedes
{
    public static List<Pessoa> Hospedes = new List<Pessoa>();

    public static Pessoa CadastrarHospede()
    {
        string nome, sobrenome;
        int respMenu;

        while (true)
        {
            Console.Clear();
            ConsoleUI.DisplayHeader(" Cadastro de Hóspedes ");
            nome = ConsoleUI.PromptWithLine("Digite o Nome:");
            // Verificação para garantir que o nome não está vazio e não contém números
            while (string.IsNullOrWhiteSpace(nome) || nome.Any(char.IsDigit))
            {
                Console.Clear();
                ConsoleUI.DisplayHeader("Erro");
                ConsoleUI.Text("Nome inválido, não deve conter números ou estar vazio.");
                ConsoleUI.DrawResponsiveLine();
                Console.ReadKey(); // Espera o usuário apertar uma tecla

                // Reexibe a solicitação do nome após o usuário apertar uma tecla
                Console.Clear();
                ConsoleUI.DisplayHeader(" Cadastro de Hóspedes ");
                nome = ConsoleUI.PromptWithLine("Digite o Nome:");
            }

            Console.Clear();
            ConsoleUI.DisplayHeader(" Cadastro de Hóspedes ");
            sobrenome = ConsoleUI.PromptWithLine("Digite o Sobrenome:");
            // Verificação similar para o sobrenome
            while (string.IsNullOrWhiteSpace(sobrenome) || sobrenome.Any(char.IsDigit))
            {
                Console.Clear();
                ConsoleUI.DisplayHeader("Erro");
                ConsoleUI.Text("Sobrenome inválido, não deve conter números ou estar vazio.");
                ConsoleUI.DrawResponsiveLine();
                Console.ReadKey(); // Espera o usuário apertar uma tecla


                // Reexibe a solicitação do sobrenome após o usuário apertar uma tecla
                Console.Clear();
                ConsoleUI.DisplayHeader(" Cadastro de Hóspedes ");
                sobrenome = ConsoleUI.PromptWithLine("Digite o Sobrenome:");
            }

            Console.Clear();
            ConsoleUI.DisplayHeader(" Confirmação de Cadastro ");
            Console.WriteLine(ConsoleUI.CenterTextInLine($"{nome} {sobrenome}"));
            ConsoleUI.DrawResponsiveLine();
            Console.WriteLine(ConsoleUI.CenterTextInLine("1) Sim   2) Não"));
            ConsoleUI.DrawResponsiveLine();

            if (int.TryParse(Console.ReadLine(), out respMenu) && respMenu == 1)
            {
                Pessoa novaPessoa = new Pessoa
                {
                    Id = Hospedes.Count + 1,
                    Nome = nome,
                    Sobrenome = sobrenome,
                    Hospedado = false
                };

                Hospedes.Add(novaPessoa);
                Console.Clear();
                ConsoleUI.DisplayHeader(" Usuário cadastrado com sucesso, aperte qualquer tecla para continuar! ");
                Console.ReadKey();
                return novaPessoa;
            }
            else if (respMenu == 2)
            {
                // Não é necessário alterar este bloco
                continue;
            }
            else
            {
                Console.Clear();
                ConsoleUI.DisplayHeader(" Erro ");
                ConsoleUI.Text("Entrada inválida, tente novamente apertando qualquer tecla!");
                ConsoleUI.DrawResponsiveLine();
                Console.ReadKey();
                continue;

            }
        }
    }
}
