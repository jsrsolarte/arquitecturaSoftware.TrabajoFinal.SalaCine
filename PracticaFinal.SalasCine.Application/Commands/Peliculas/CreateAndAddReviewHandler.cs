using AutoMapper;
using MediatR;
using PracticaFinal.SalasCine.Domain.Entities;
using PracticaFinal.SalasCine.Domain.Ports;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace PracticaFinal.SalasCine.Application.Commands.Peliculas
{
    public class CreateAndAddReviewHandler : AsyncRequestHandler<CreateAndAddReview>
    {
        private readonly IPeliculaService _peliculaService;
        private readonly IMapper _mapper;

        public CreateAndAddReviewHandler(IPeliculaService peliculaService, IMapper mapper)
        {
            _peliculaService = peliculaService;
            _mapper = mapper;
        }

        protected override async Task Handle(CreateAndAddReview request, CancellationToken cancellationToken)
        {
            await _peliculaService.AddReview(request.IdPelicula, _mapper.Map<Review>(request));
        }
    }
}
