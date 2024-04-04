using System;
using SistemaHotelaria.Models;

namespace SistemaHotelaria.Models
{
    public class ListarHospedes
    {
        public static void ExibirHospedes()
        {
            Console.Clear();
            ConsoleUI.DisplayHeader(" Lista de Hóspedes Cadastrados ");

            if (GerenciadorHospedes.Hospedes.Count == 0)
            {
                Console.WriteLine(ConsoleUI.CenterTextInLine("Nenhum hóspede cadastrado."));
            }
            else
            {
                foreach (Pessoa hospede in GerenciadorHospedes.Hospedes)
                {
                    string hospedeDetails = $"ID: {hospede.Id} - Nome: {hospede.Nome} {hospede.Sobrenome} - Hospedado: {(hospede.Hospedado == true ? "Sim" : "Não")}";
                    Console.WriteLine(ConsoleUI.CenterTextInLine(hospedeDetails));
                    ConsoleUI.DrawResponsiveLine();

                }
            }

            Console.WriteLine(ConsoleUI.CenterTextInLine("Pressione qualquer tecla para continuar..."));
            ConsoleUI.DrawResponsiveLine();
            Console.ReadKey();
        }
    }
}
