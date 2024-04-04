using System;
using SistemaHotelaria.Models;
using System.Linq;

namespace SistemaHotelaria.Models
{
    public static class ListarReservas
    {
        public static void ExibirReservas()
        {
            Console.Clear();
            ConsoleUI.DisplayHeader("Lista de Reservas Cadastradas");

            var reservas = GerenciadorReservas.Reservas;

            if (reservas.Count == 0)
            {
                ConsoleUI.Text("Nenhuma reserva cadastrada.");
                ConsoleUI.DisplayBorderedText("Pressione qualquer tecla para continuar...");
                Console.ReadKey();
                Menu.ExibirMenu();
                return;
            }

            foreach (var reserva in reservas)
            {
                string hospedesNomes = string.Join(", ", reserva.Hospedes.Select(h => $"{h.Nome} {h.Sobrenome}"));
                string suiteDetalhes = $"Número: {reserva.suite.Id}, Tipo: {reserva.suite.Tipo}, Capacidade: {reserva.suite.Capacidade}, Valor Diária: R$ {reserva.suite.ValorDiaria:N2},";
                string reservaDetalhes = $"Hóspede(s): {hospedesNomes}, Dia(s) Reservado(s): {reserva.DiasReservados}";
                ConsoleUI.DrawResponsiveLine();

                ConsoleUI.FormatAndWriteLine(suiteDetalhes);
                ConsoleUI.FormatAndWriteLine(reservaDetalhes);
            }

            ConsoleUI.DisplayBorderedText("Pressione qualquer tecla para continuar...");
            Console.ReadKey();
            Menu.ExibirMenu();
        }
    }
}
