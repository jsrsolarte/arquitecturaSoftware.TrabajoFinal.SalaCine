using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PracticaFinal.SalasCine.Domain.Entities
{
    public class SalaDeCine : EntityBase<Guid>
    {
        [Required] public string Nombre { get; set; }
        public List<Pelicula> Peliculas { get; set; }
    }
}