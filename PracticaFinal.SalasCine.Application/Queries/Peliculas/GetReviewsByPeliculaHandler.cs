using AutoMapper;
using MediatR;
using PracticaFinal.SalasCine.Application.Dtos;
using PracticaFinal.SalasCine.Domain.Entities;
using PracticaFinal.SalasCine.Domain.Ports;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace PracticaFinal.SalasCine.Application.Queries.Peliculas
{
    public class GetReviewsByPeliculaHandler : IRequestHandler<GetReviewsByPelicula, IEnumerable<ReviewDto>>
    {
        private readonly IGenericRepository<Review> _reviewRepository;
        private readonly IMapper _mapper;

        public GetReviewsByPeliculaHandler(IGenericRepository<Review> reviewRepository, IMapper mapper)
        {
            _reviewRepository = reviewRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<ReviewDto>> Handle(GetReviewsByPelicula request, CancellationToken cancellationToken)
        {
            return _mapper.Map<IEnumerable<ReviewDto>>(await _reviewRepository.GetAsync(x => x.Pelicula.Id.Equals(request.IdPelicula)));
        }
    }
}
