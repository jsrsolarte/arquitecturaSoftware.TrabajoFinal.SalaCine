using MediatR;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticaFinal.SalasCine.Application.Commands.Peliculas
{
    public class CreateAndAddReview : IRequest
    {
        [Required]
        public Guid IdPelicula { get; set; }
        [Required]
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        [Range(0, 5)]
        public int Calificacion { get; set; }
    }
}
