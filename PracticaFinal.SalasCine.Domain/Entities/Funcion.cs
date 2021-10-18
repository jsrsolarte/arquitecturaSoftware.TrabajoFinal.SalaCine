using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticaFinal.SalasCine.Domain.Entities
{
    public class Funcion: EntityBase<Guid>
    {
        public SalaDeCine SalaCine { get; set; }
        public Pelicula Pelicula { get; set; }
        public DateTime Fecha { get; set; }
    }
}
