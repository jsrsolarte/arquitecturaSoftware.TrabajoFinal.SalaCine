using MediatR;
using PracticaFinal.SalasCine.Application.Dtos;
using System;
using System.Collections.Generic;

namespace PracticaFinal.SalasCine.Application.Queries.SalasCine
{
    public class GetAllFunciones : IRequest<IEnumerable<FuncionDto>>
    {
        public Guid IdPelicula { get; set; }
        public Guid IdSalaCine { get; set; }
    }
}
