using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PracticaFinal.SalasCine.Domain.Entities
{
    public class Actor : EntityBase<Guid>
    {
        [Required] public string Nombre { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public string Foto { get; set; }
        public ICollection<Pelicula> Peliculas { get; set; }
    }
}