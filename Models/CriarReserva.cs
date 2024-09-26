using SistemaHotelaria.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SistemaHotelaria.Models
{
    public static class GerenciadorReservas
    {
        public static List<Reserva> Reservas = new List<Reserva>();
        public static void RealizarReserva()
        {
            bool ativo = true;
            while (ativo)
            {
                try
                {
                    var hospedesNaoHospedados = GerenciadorHospedes.Hospedes.Where(h => !h.Hospedado).ToList();
                    Console.Clear();
                    ConsoleUI.DisplayHeader("Realizar Reserva de Suíte");

                    var suitesDisponiveis = CadastrarSuite.Suites.Where(suite => !suite.Ocupado).ToList();
                    if (suitesDisponiveis.Count == 0)
                    {
                        ConsoleUI.Text("Não há suítes disponíveis para reserva.");
                        ConsoleUI.DisplayBorderedText("Pressione qualquer tecla para continuar...");
                        Console.ReadKey();
                        Menu.ExibirMenu();
                        return;
                    }

                    Suite suiteSelecionada = null;
                    while (suiteSelecionada == null)
                    {
                        Console.Clear();
                        ConsoleUI.DisplayHeader("Realizar Reserva de Suíte");
                        foreach (var suite in suitesDisponiveis)
                        {
                            string suiteDetails = $"Numero: {suite.Id} - {suite.Tipo} - Capacidade: {suite.Capacidade} - R$ {suite.ValorDiaria:N2} por dia";
                            ConsoleUI.FormatAndWriteLine(suiteDetails);
                        }
                        ConsoleUI.DrawResponsiveLine();
                        int suiteId;
                        bool isNumeric = int.TryParse(ConsoleUI.PromptWithLine("Digite o Numero da suíte que deseja reservar:"), out suiteId);
                        if (!isNumeric)
                        {
                            Console.Clear();
                            ConsoleUI.DrawResponsiveLine();
                            ConsoleUI.Text("Por favor, insira um número válido.");
                            ConsoleUI.DrawResponsiveLine();
                            Console.ReadKey();
                            continue;
                        }

                        suiteSelecionada = suitesDisponiveis.FirstOrDefault(s => s.Id == suiteId);
                        if (suiteSelecionada == null)
                        {
                            Console.Clear();
                            ConsoleUI.DrawResponsiveLine();
                            ConsoleUI.Text("Suíte não encontrada ou não está disponível. Tente novamente.");
                            ConsoleUI.DrawResponsiveLine();
                            Console.ReadKey();
                            continue;

                        }
                    }

                    if (GerenciadorHospedes.Hospedes.Count == 0)
                    {
                        Console.Clear();
                        ConsoleUI.DisplayHeader("Realizar Reserva de Suíte");
                        ConsoleUI.Text("Não há hóspedes cadastrados ou já estão hospedados.");
                        ConsoleUI.DisplayBorderedText("Pressione qualquer tecla para continuar...");
                        Console.ReadKey();
                        return;
                    }

                    if (hospedesNaoHospedados.Count == 0)
                    {
                        Console.Clear();
                        ConsoleUI.DisplayHeader("Criar Reserva");
                        ConsoleUI.Text("Não há hóspedes disponíveis para reserva.");
                        ConsoleUI.DisplayBorderedText("Pressione qualquer tecla para continuar...");
                        Console.ReadKey();
                        return;
                    }
                    Console.Clear();
                    ConsoleUI.DisplayHeader("Criar Reserva");
                    ConsoleUI.Text("Selecione o(s) hóspede(s) para a reserva:");
                    ConsoleUI.DrawResponsiveLine();
                    var hospedesSelecionados = new List<Pessoa>();
                    int maxHospedes = (int)suiteSelecionada.Capacidade + 1;

                    do
                    {
                        bool hospedeValido = false;
                        Pessoa hospedeSelecionado = null;

                        while (!hospedeValido)
                        {
                            Console.Clear();
                            ConsoleUI.DisplayHeader("Criar Reserva");
                            ConsoleUI.Text("Selecione o(s) hóspede(s) para a reserva:");
                            ConsoleUI.DrawResponsiveLine();
                            foreach (var hospedeDisponivel in hospedesNaoHospedados)
                            {
                                ConsoleUI.FormatAndWriteLine($"ID: {hospedeDisponivel.Id} - Nome: {hospedeDisponivel.Nome} {hospedeDisponivel.Sobrenome}");
                                ConsoleUI.DrawResponsiveLine();
                            }

                            int hospedeId;
                            bool isNumeric = int.TryParse(ConsoleUI.PromptWithLine("Digite o ID do hóspede que se hospedará:"), out hospedeId);
                            if (!isNumeric)
                            {
                                Console.Clear();
                                ConsoleUI.DrawResponsiveLine();
                                ConsoleUI.Text("Por favor, insira um número válido.");
                                ConsoleUI.DrawResponsiveLine();
                                Console.ReadKey();
                                continue;
                            }

                            hospedeSelecionado = hospedesNaoHospedados.FirstOrDefault(h => h.Id == hospedeId);
                            if (hospedeSelecionado != null && !hospedesSelecionados.Contains(hospedeSelecionado))
                            {
                                hospedesSelecionados.Add(hospedeSelecionado);
                                hospedeValido = true;
                                Console.Clear();
                                ConsoleUI.DisplayHeader("Criar Reserva");
                                ConsoleUI.FormatAndWriteLine($"{hospedeSelecionado.Nome} {hospedeSelecionado.Sobrenome} adicionado à reserva.");
                            }
                            else
                            {
                                Console.Clear();
                                ConsoleUI.DrawResponsiveLine();
                                ConsoleUI.Text("Hóspede não encontrado ou já hospedado. Tente novamente.");
                                ConsoleUI.DrawResponsiveLine();
                                Console.ReadKey();
                            }
                        }

                        if (hospedesSelecionados.Count >= maxHospedes) break;

                        ConsoleUI.DrawResponsiveLine();
                        int adicionarMais = int.TryParse(ConsoleUI.PromptWithLine("Deseja adicionar outro hóspede à reserva? 1 para sim, 2 para não:"), out int escolhaAdicionar) ? escolhaAdicionar : 0;
                        if (adicionarMais != 1)
                        {
                            break;
                        }

                    } while (hospedesSelecionados.Count < maxHospedes);



                    Console.Clear();
                    int diasReservados = int.Parse(ConsoleUI.PromptWithLineFull("Por quantos dias a suíte será reservada?"));

                    var reserva = new Reserva
                    { Id = suiteSelecionada.Id,
                        Hospedes = hospedesSelecionados,
                        suite = suiteSelecionada,
                        DiasReservados = diasReservados
                    };
                    Reservas.Add(reserva);

                    suiteSelecionada.Ocupado = true;

                    Console.Clear();
                    ConsoleUI.DisplayHeader("Reserva realizada com sucesso, aperte qualquer tecla para continuar!");
                    Console.ReadKey();
                    foreach (var hospede in hospedesSelecionados)
                    {
                        hospede.Hospedado = true;
                    }
                    break;
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
}
