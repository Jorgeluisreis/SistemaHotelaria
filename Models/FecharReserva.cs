using System;
using System.Linq;
using System.Reflection.Metadata.Ecma335;

namespace SistemaHotelaria.Models
{
    public static class FecharReserva
    {
        public static void EncerrarReserva()
        {
            bool ativo = true;
            try
            {

                while (ativo)
                {
                    Console.Clear();
                    ConsoleUI.DisplayHeader("Fechar Reserva de Suíte");

                    var reservas = GerenciadorReservas.Reservas;

                    if (reservas.Count == 0)
                    {
                        ConsoleUI.Text("Nenhuma reserva cadastrada.");
                        ConsoleUI.DisplayBorderedText("Pressione qualquer tecla para continuar...");
                        Console.ReadKey();
                        return;
                    }

                    foreach (var reserva in reservas)
                    {
                        string hospedesNomes = string.Join(", ", reserva.Hospedes.Select(h => $"{h.Nome} {h.Sobrenome}"));
                        string suiteDetalhes = $"Numero: {reserva.Id}, Número da Suíte: {reserva.suite.Id}, Tipo: {reserva.suite.Tipo}, Capacidade: {reserva.suite.Capacidade}, Valor Diária: R$ {reserva.suite.ValorDiaria:N2}, Dias Reservados: {reserva.DiasReservados}";

                        ConsoleUI.FormatAndWriteLine(suiteDetalhes);
                        ConsoleUI.FormatAndWriteLine($"Hóspede(s): {hospedesNomes}");
                        ConsoleUI.DrawResponsiveLine();
                    }

                    ConsoleUI.DrawResponsiveLine();
                    int reservaId = int.Parse(ConsoleUI.PromptWithLine("Digite o ID da reserva que deseja fechar:"));
                    var reservaParaFechar = reservas.FirstOrDefault(r => r.Id == reservaId);

                    if (reservaParaFechar != null)
                    {
                        decimal valorTotal = reservaParaFechar.suite.ValorDiaria * reservaParaFechar.DiasReservados;
                        Console.Clear();
                        ConsoleUI.DrawResponsiveLine();
                        ConsoleUI.FormatAndWriteLine($"Valor total pago: R${valorTotal:N2}");

                        reservaParaFechar.suite.Ocupado = false;
                        foreach (var hospede in reservaParaFechar.Hospedes)
                        {
                            hospede.Hospedado = false;
                        }

                        reservas.Remove(reservaParaFechar);

                        ConsoleUI.DisplayBorderedText("Reserva fechada com sucesso. Pressione qualquer tecla para continuar...");
                        Console.ReadKey();
                        break;
                    }
                    else
                    {
                        Console.Clear();
                        ConsoleUI.DrawResponsiveLine();
                        ConsoleUI.Text("Reserva não encontrada, aperte qualquer tecla para continuar!");
                        ConsoleUI.DrawResponsiveLine();
                        Console.ReadKey();
                        continue;
                    }
                }
            }
            catch (FormatException)
            {
                Console.Clear();
                ConsoleUI.DrawResponsiveLine();
                ConsoleUI.Text("Formato inválido, por favor, insira um número correspondente às opções.");
                ConsoleUI.DrawResponsiveLine();
                Console.ReadKey();
                FecharReserva.EncerrarReserva();
            }
        }
    }
}
