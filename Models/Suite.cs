using System;

namespace SistemaHotelaria.Models
{
    public class Suite
    {
        public int Id { get; set; }
        public TipoSuite Tipo { get; set; }
        public Capacidade Capacidade { get; set; }
        public decimal ValorDiaria { get; set; }
        public bool Ocupado { get; set; } = false;
    }

    public enum TipoSuite
    {
        Simples,
        Premium,
        Master
    }

    public enum Capacidade
    {
        Solo,
        Casal,
        Grupo,
        Familia
    }
}
