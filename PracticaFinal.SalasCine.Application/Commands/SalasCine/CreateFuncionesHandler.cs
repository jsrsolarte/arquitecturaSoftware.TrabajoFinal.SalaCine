using AutoMapper;
using MediatR;
using PracticaFinal.SalasCine.Domain.Entities;
using PracticaFinal.SalasCine.Domain.Ports;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace PracticaFinal.SalasCine.Application.Commands.SalasCine
{
    internal class CreateFuncionesHandler : AsyncRequestHandler<CreateFunciones>
    {
        private readonly ISalasCineService _salasCineService;
        private readonly IMapper _mapper;

        public CreateFuncionesHandler(ISalasCineService salasCineService, IMapper mapper)
        {
            _salasCineService = salasCineService;
            _mapper = mapper;
        }

        protected override async Task Handle(CreateFunciones request, CancellationToken cancellationToken)
        {
            var funciones = _mapper.Map<IEnumerable<Funcion>>(request.Funciones);
            await _salasCineService.AddFunciones(request.IdSalaCine, request.IdPelicula, funciones);

        }
    }
}
