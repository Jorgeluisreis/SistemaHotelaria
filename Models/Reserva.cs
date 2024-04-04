using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaHotelaria.Models
{
    public class Reserva
    {
        public int Id { get; set; }
        public List<Pessoa> Hospedes { get; set; }
        public Suite suite { get; set; }
        public int DiasReservados { get; set; }
    }
}
