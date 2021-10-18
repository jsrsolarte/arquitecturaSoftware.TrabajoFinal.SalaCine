using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticaFinal.SalasCine.Application.Commands.SalasCine
{
    public class AddPeliculaToSalaCine: IRequest
    {
        public Guid IdSalaCine { get; set; }
        public Guid IdPelicula { get; set; }
    }
}
