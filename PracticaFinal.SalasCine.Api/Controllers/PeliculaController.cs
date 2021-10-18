using MediatR;
using Microsoft.AspNetCore.Mvc;
using PracticaFinal.SalasCine.Application.Commands.Peliculas;
using PracticaFinal.SalasCine.Application.Dtos;
using PracticaFinal.SalasCine.Application.Queries.Peliculas;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PracticaFinal.SalasCine.Api.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    public class PeliculaController : ControllerBase
    {
        private readonly IMediator _mediator;

        public PeliculaController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("list")]
        public async Task<IEnumerable<PeliculaDto>> GetPeliculas()
        {
            return await _mediator.Send(new GetAllPeliculas());
        }

        [HttpPost]
        public async Task<PeliculaDto> CreatePelicula(CreatePelicula createPelicula)
        {
            return await _mediator.Send(createPelicula);
        }

        [HttpPost("uploadPoster")]
        [Consumes("multipart/form-data")]
        public async Task UploadPoster([FromForm] UploadPoster uploadPoster)
        {

            await _mediator.Send(uploadPoster);
        }

        [HttpGet("{id}")]
        public async Task<PeliculaDetalleDto> GetDetallePelicula(Guid id)
        {
            return await _mediator.Send(new GetDetallePelicula
            {
                Id = id
            });
        }

        [HttpPost("addActor")]
        public async Task AddActor(AddActorToPelicula addActorToPelicula)
        {
            await _mediator.Send(addActorToPelicula);
        }

        [HttpGet("{idPelicula}/reviews")]
        public async Task<IEnumerable<ReviewDto>> GetReviewsPelicula(Guid idPelicula)
        {
            return await _mediator.Send(new GetReviewsByPelicula
            {
                IdPelicula = idPelicula
            });
        }

        [HttpPost("review")]
        public async Task CreateReview(CreateAndAddReview createAndAddReview)
        {
            await _mediator.Send(createAndAddReview);
        }
    }
}
