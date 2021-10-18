using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PracticaFinal.SalasCine.Domain.Entities
{
    public class Pelicula : EntityBase<Guid>
    {
        [Required] public string Titulo { get; set; }
        public bool EnCines => SalasCine != null && SalasCine.Count > 0;
        public DateTime FechaEstreno { get; set; }
        public ICollection<Actor> Actores { get; set; }
        public List<Genero> Generos { get; set; }
        public string Poster { get; set; }
        public List<SalaDeCine> SalasCine { get; set; }
    }
}