using MediatR;
using PracticaFinal.SalasCine.Domain.Ports;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace PracticaFinal.SalasCine.Application.Commands.SalasCine
{
    public class AddPeliculaToSalaCineHandler : AsyncRequestHandler<AddPeliculaToSalaCine>
    {
        private readonly ISalasCineService _salasCineService;

        public AddPeliculaToSalaCineHandler(ISalasCineService salasCineService)
        {
            _salasCineService = salasCineService;
        }

        protected override async Task Handle(AddPeliculaToSalaCine request, CancellationToken cancellationToken)
        {
            await _salasCineService.AddPelicula(request.IdSalaCine, request.IdPelicula);
        }
    }
}
