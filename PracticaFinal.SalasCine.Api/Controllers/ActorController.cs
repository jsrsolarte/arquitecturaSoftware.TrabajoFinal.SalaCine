using MediatR;
using Microsoft.AspNetCore.Mvc;
using PracticaFinal.SalasCine.Application.Commands.Actores;
using PracticaFinal.SalasCine.Application.Dtos;
using PracticaFinal.SalasCine.Application.Queries.Actores;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PracticaFinal.SalasCine.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ActorController
    {

        private readonly IMediator _mediator;

        public ActorController(IMediator mediator)
        {
            _mediator = mediator;
        } 
        [HttpGet("list")]
        public async Task<IEnumerable<ActorDto>> GetAllActors()
        {
            return await _mediator.Send(new GetAllActores());
        }

        [HttpPost]
        public Task<ActorDto> CreateActor(CreateActor createActor)
        {
            return _mediator.Send(createActor);
        }

        [HttpPost("uploadFoto")]
        [Consumes("multipart/form-data")]
        public async Task UploadPoster([FromForm] UploadActorPhoto uploadActorPhoto)
        {

            await _mediator.Send(uploadActorPhoto);
        }
    }
}
