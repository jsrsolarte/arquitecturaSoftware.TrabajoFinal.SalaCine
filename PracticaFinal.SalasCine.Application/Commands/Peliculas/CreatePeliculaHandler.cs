using AutoMapper;
using MediatR;
using PracticaFinal.SalasCine.Application.Dtos;
using PracticaFinal.SalasCine.Domain.Entities;
using PracticaFinal.SalasCine.Domain.Ports;
using System.Threading;
using System.Threading.Tasks;

namespace PracticaFinal.SalasCine.Application.Commands.Peliculas
{
    public class CreatePeliculaHandler : IRequestHandler<CreatePelicula, PeliculaDto>
    {
        private readonly IPeliculaService _peliculaService;
        private readonly IMapper _mapper;

        public CreatePeliculaHandler(IPeliculaService peliculaService, IMapper mapper)
        {
            _peliculaService = peliculaService;
            _mapper = mapper;
        }

        public async Task<PeliculaDto> Handle(CreatePelicula request, CancellationToken cancellationToken)
        {
            var peliculaCreated = await _peliculaService.CreatePeliculaAsync(_mapper.Map<Pelicula>(request));
            return _mapper.Map<PeliculaDto>(peliculaCreated);
        }
    }
}
