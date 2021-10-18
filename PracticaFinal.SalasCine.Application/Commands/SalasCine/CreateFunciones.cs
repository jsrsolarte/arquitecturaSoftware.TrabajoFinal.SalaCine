using MediatR;
using System;
using System.Collections.Generic;

namespace PracticaFinal.SalasCine.Application.Commands.SalasCine
{
    public class CreateFunciones : IRequest
    {
        public Guid IdPelicula { get; set; }
        public Guid IdSalaCine { get; set; }
        public IEnumerable<CreateFuncion> Funciones { get; set; }
    }


    public class CreateFuncion
    {
        public DateTime Fecha { get; set; }
    }
}
