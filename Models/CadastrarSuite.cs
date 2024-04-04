using SistemaHotelaria.Models;
using System;
using System.Collections.Generic;

public static class CadastrarSuite
{
    public static List<Suite> Suites = new List<Suite>();

    public static void Cadastrar()
    {
        bool ativo = true;
        while (ativo)
        {
            try
            {

                TipoSuite tipo = TipoSuite.Simples; // Ou qualquer valor padrão válido
                Capacidade capacidade = Capacidade.Solo; // Ou qualquer valor padrão válido

                // Pedir o tipo da suíte
                bool tipoValido = false;
                while (!tipoValido)
                {
                    Console.Clear();
                    ConsoleUI.DisplayHeader("Cadastro de Suítes");
                    ConsoleUI.Text("Tipo de Suíte");
                    ConsoleUI.DrawResponsiveLine();
                    Console.WriteLine(ConsoleUI.CenterTextInLine("0) Simples 1) Premium 2) Master"));
                    ConsoleUI.DrawResponsiveLine();
                    tipoValido = Enum.TryParse(Console.ReadLine(), out tipo) && Enum.IsDefined(typeof(TipoSuite), tipo);
                    if (!tipoValido)
                    {
                        Console.Clear();
                        ConsoleUI.DrawResponsiveLine();
                        ConsoleUI.Text("Opção inválida. Escolha um dos 3 tipos de suítes");
                        ConsoleUI.DrawResponsiveLine();
                        Console.ReadKey();
                        continue;
                    }
                }

                Console.Clear();
                ConsoleUI.DisplayHeader("Cadastro de Suítes");

                // Pedir a capacidade da suíte
                bool capacidadeValida = false;
                while (!capacidadeValida)
                {
                    ConsoleUI.Text("Capacidade da Suíte");
                    ConsoleUI.DrawResponsiveLine();
                    Console.WriteLine(ConsoleUI.CenterTextInLine("0) Solo 1) Casal 2) Grupo 3) Familia"));
                    ConsoleUI.DrawResponsiveLine();
                    capacidadeValida = Enum.TryParse(Console.ReadLine(), out capacidade) && Enum.IsDefined(typeof(Capacidade), capacidade);
                    if (!capacidadeValida)
                    {
                        Console.Clear();
                        ConsoleUI.DrawResponsiveLine();
                        ConsoleUI.Text("Opção inválida. Escolha um dos 4 tipos de capacidades.");
                        ConsoleUI.DrawResponsiveLine();
                        Console.ReadKey();
                        continue;
                    }
                }

                Console.Clear();
                ConsoleUI.DisplayHeader("Cadastro de Suítes");

                // Pedir o valor da diária
                ConsoleUI.Text("Valor da Diária (R$)");
                ConsoleUI.DrawResponsiveLine();
                decimal valorDiaria = decimal.Parse(Console.ReadLine());

                Suite novaSuite = new Suite
                {
                    Tipo = tipo,
                    Capacidade = capacidade,
                    ValorDiaria = valorDiaria,
                    Ocupado = false,
                    Id = Suites.Count + 1
                };

                Suites.Add(novaSuite);
                Console.Clear();
                ConsoleUI.DisplayHeader("Suíte cadastrada com sucesso!");
                Console.ReadKey();
                ativo = false;
            }
            catch (FormatException)
            {
                Console.Clear();
                ConsoleUI.DrawResponsiveLine();
                ConsoleUI.Text("Formato inválido, por favor, insira um número correspondente às opções.");
                ConsoleUI.DrawResponsiveLine();
                Console.ReadKey();
                continue;
            }
            catch (Exception ex)
            {
                Console.Clear();
                ConsoleUI.DrawResponsiveLine();
                ConsoleUI.Text($"Erro inesperado: {ex.Message}");
                ConsoleUI.DrawResponsiveLine();
                Console.ReadKey();
                continue;
            }
        }
    }
}
