using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticaFinal.SalasCine.Domain.Entities
{
    public class Review: EntityBase<Guid>
    {
        public Pelicula Pelicula { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        [Range(0,5)]
        public int Calificacion { get; set; }
    }
}
