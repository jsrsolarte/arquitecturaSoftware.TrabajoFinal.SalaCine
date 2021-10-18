using AutoMapper;
using MediatR;
using PracticaFinal.SalasCine.Application.Dtos;
using PracticaFinal.SalasCine.Domain.Entities;
using PracticaFinal.SalasCine.Domain.Ports;
using System.Threading;
using System.Threading.Tasks;

namespace PracticaFinal.SalasCine.Application.Commands.Actores
{
    public class CreateActorHandler : IRequestHandler<CreateActor, ActorDto>
    {
        private readonly IMapper _mapper;
        private readonly IActorService _actorService;

        public CreateActorHandler(IMapper mapper, IActorService actorService)
        {
            _mapper = mapper;
            _actorService = actorService;
        }


        public async Task<ActorDto> Handle(CreateActor request, CancellationToken cancellationToken)
        {
            var actor = _mapper.Map<Actor>(request);
            return _mapper.Map<ActorDto>(await _actorService.CreateActorAsync(actor));
        }
    }
}
