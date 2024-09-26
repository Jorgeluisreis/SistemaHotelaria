using System;
using System.Reflection.Metadata.Ecma335;
using SistemaHotelaria.Models;

namespace SistemaHotelaria.Models
{
    public class ListarSuites
    {
        public static void ExibirSuites()
        {
            Console.Clear();
            ConsoleUI.DisplayHeader(" Lista de Suítes Cadastradas ");

            if (CadastrarSuite.Suites.Count == 0)
            {
                ConsoleUI.Text(" Nenhuma suíte cadastrada. ");
            }
            for (int i = 0; i < CadastrarSuite.Suites.Count; i++)
            {
                Suite suite = CadastrarSuite.Suites[i];
                string status = suite.Ocupado ? "Sim" : "Não";
                string suiteDetails = $"Número: {suite.Id} - Tipo: {suite.Tipo} - Capacidade: {suite.Capacidade} - Valor Diária: R$ {suite.ValorDiaria:N2}, Ocupado: {status}";
                ConsoleUI.FormatAndWriteLine(suiteDetails);

                if (i < CadastrarSuite.Suites.Count - 1)
                {
                    ConsoleUI.DrawResponsiveLine();
                }
            }

            ConsoleUI.DisplayBorderedText("Pressione qualquer tecla para continuar...");
            Console.ReadKey();
            Menu.ExibirMenu();


        }
    }
}
