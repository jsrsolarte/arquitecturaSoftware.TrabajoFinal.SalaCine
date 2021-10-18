using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticaFinal.SalasCine.Application.Commands.Peliculas
{
    public class AddActorToPelicula : IRequest
    {
        public Guid IdActor { get; set; }
        public Guid IdPelicula { get; set; }
    }
}
