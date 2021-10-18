using MediatR;
using Microsoft.AspNetCore.Mvc;
using PracticaFinal.SalasCine.Application.Commands.SalasCine;
using PracticaFinal.SalasCine.Application.Dtos;
using PracticaFinal.SalasCine.Application.Queries.SalasCine;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;

namespace PracticaFinal.SalasCine.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SalaCineController : ControllerBase
    {
        private readonly IMediator _mediator;

        public SalaCineController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("list")]
        public async Task<IEnumerable<SalaCineDto>> GetAllSalasCine()
        {
            return await _mediator.Send(new GetAllSalasCine());
        }

        [HttpGet("funciones")]
        public async Task<IEnumerable<FuncionDto>> GetFunciones([Required] Guid idSalaCine, [Required] Guid idPelicula)
        {
            return await _mediator.Send(new GetAllFunciones
            {
                IdPelicula = idPelicula,
                IdSalaCine = idSalaCine
            });
        }

        [HttpPost]
        public async Task<SalaCineDto> CreateSalaCine(CreateSalaCine createSalaCine)
        {
            return await _mediator.Send(createSalaCine);
        }

        [HttpPost("addpelicula")]
        public async Task AddPelicula(AddPeliculaToSalaCine peliculaToSalaCine)
        {
            await _mediator.Send(peliculaToSalaCine);
        }

        [HttpPost("addfunciones")]
        public async Task AddFunciones(CreateFunciones createFunciones)
        {
            await _mediator.Send(createFunciones);
        }
    }
}
