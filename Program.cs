using SistemaHotelaria.Models;
using System;

namespace SistemaHotelaria
{
    public class Menu
    {
        public static void ExibirMenu()
        {
            Console.Clear();
            Console.SetWindowSize(80, 30); // Defina um tamanho de início razoável
            Console.SetBufferSize(80, 30); // Impede o scroll vertical e horizontal
            ConsoleManager.DisableResize();
            int respMenu = 0;
            bool ativo = true;
            while (ativo)
            {
                try
                {
                    Console.Clear();
                    ConsoleUI.DisplayHeader(" Sistema de Hotelaria ");
                    Console.WriteLine(ConsoleUI.CenterTextInLine("1- Reservas"));
                    Console.WriteLine(ConsoleUI.CenterTextInLine("2- Cadastros"));
                    Console.WriteLine(ConsoleUI.CenterTextInLine("3- Listar Hospedes"));
                    Console.WriteLine(ConsoleUI.CenterTextInLine("4- Listar Suítes"));
                    Console.WriteLine(ConsoleUI.CenterTextInLine("5- Listar Reservas"));
                    Console.WriteLine(ConsoleUI.CenterTextInLine("6- Sair"));
                    ConsoleUI.DrawResponsiveLine();

                    respMenu = int.Parse(Console.ReadLine());

                    switch (respMenu)
                    {

                        case 1:
                            try
                            {
                                Console.Clear();
                                ConsoleUI.DisplayHeader(" Sistema de Hotelaria ");
                                Console.WriteLine(ConsoleUI.CenterTextInLine("1- Criar Reserva"));
                                Console.WriteLine(ConsoleUI.CenterTextInLine("2- Fechar Reserva"));
                                Console.WriteLine(ConsoleUI.CenterTextInLine("3- Voltar ao menu principal"));
                                ConsoleUI.DrawResponsiveLine();

                                respMenu = int.Parse(Console.ReadLine());

                                switch (respMenu)
                                {
                                    case 1:
                                        ativo = false;
                                        GerenciadorReservas.RealizarReserva();
                                        break;

                                    case 2:
                                        FecharReserva.EncerrarReserva();
                                        break;

                                    case 3:
                                        Menu.ExibirMenu();
                                        break;

                                    default:
                                        Console.Clear();
                                        ConsoleUI.DrawResponsiveLine();
                                        ConsoleUI.ShowErrorMessageWithLine("Opção inválida, tente novamente!");
                                        break;
                                }
                            }
                            catch (FormatException)
                            {
                                Console.Clear();
                                ConsoleUI.DrawResponsiveLine();
                                ConsoleUI.ShowErrorMessageWithLine("Caractere inválido, insira apenas números, aperte qualquer tecla para continuar!");
                            }
                            break;

                        case 2:
                            ExibirSubMenuCadastros();
                            break;

                        case 3:
                            ListarHospedes.ExibirHospedes();
                            break;

                        case 4:
                            ListarSuites.ExibirSuites();
                            break;
                        case 5:
                            ListarReservas.ExibirReservas();
                            break;
                        case 6:
                            Environment.Exit(0);
                            break;


                        // Outros casos...
                        default:
                            Console.Clear();
                            ConsoleUI.DrawResponsiveLine();
                            ConsoleUI.ShowErrorMessageWithLine("Opção inválida, tente novamente!");
                            break;
                    }
                }
                catch (FormatException)
                {
                    Console.Clear();
                    ConsoleUI.DrawResponsiveLine();
                    ConsoleUI.ShowErrorMessageWithLine("Caractere inválido, insira apenas números, aperte qualquer tecla para continuar!");
                }
            }
        }

        private static void ExibirSubMenuCadastros()
        {
            int respMenu;
            bool continuarSubMenu = true;

            while (continuarSubMenu)
            {
                Console.Clear();
                ConsoleUI.DisplayHeader(" Cadastros ");
                Console.WriteLine(ConsoleUI.CenterTextInLine("1- Cadastrar Hospede"));
                Console.WriteLine(ConsoleUI.CenterTextInLine("2- Cadastrar Suíte"));
                Console.WriteLine(ConsoleUI.CenterTextInLine("3- Voltar ao menu principal"));
                ConsoleUI.DrawResponsiveLine();

                respMenu = int.Parse(Console.ReadLine());

                switch (respMenu)
                {
                    case 1:
                        GerenciadorHospedes.CadastrarHospede();
                        break;
                    case 2:
                        CadastrarSuite.Cadastrar();
                        break;
                    case 3:
                        Menu.ExibirMenu();
                        break;
                    default:
                        Console.Clear();
                        ConsoleUI.DrawResponsiveLine();
                        ConsoleUI.ShowErrorMessageWithLine("Opção inválida, tente novamente apertando em qualquer tecla!");
                        break;
                }
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Menu.ExibirMenu();
        }
    }
}
