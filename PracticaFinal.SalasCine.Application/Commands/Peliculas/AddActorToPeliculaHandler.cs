using MediatR;
using PracticaFinal.SalasCine.Domain.Ports;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace PracticaFinal.SalasCine.Application.Commands.Peliculas
{
    public class AddActorToPeliculaHandler : AsyncRequestHandler<AddActorToPelicula>
    {
        private readonly IPeliculaService _peliculaService;

        public AddActorToPeliculaHandler(IPeliculaService peliculaService)
        {
            _peliculaService = peliculaService;
        }

        protected override async Task Handle(AddActorToPelicula request, CancellationToken cancellationToken)
        {
            await _peliculaService.AddActor(request.IdPelicula, request.IdActor);
        }
    }
}
