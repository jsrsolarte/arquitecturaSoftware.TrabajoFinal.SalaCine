using PracticaFinal.SalasCine.Domain.Entities;
using PracticaFinal.SalasCine.Domain.Exceptions;
using PracticaFinal.SalasCine.Domain.Ports;
using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace PracticaFinal.SalasCine.Domain.Services
{
    [DomainService]
    public class PeliculaService : IPeliculaService
    {
        private readonly IGenericRepository<Pelicula> _peliculaRepository;
        private readonly IGenericRepository<Actor> _actorRepository;
        private readonly IGenericRepository<Review> _reviewRepository;
        private readonly IFileRepository _fileRepository;

        public PeliculaService(IGenericRepository<Pelicula> peliculaRepository, IFileRepository fileRepository, IGenericRepository<Actor> actorRepository, IGenericRepository<Review> reviewRepository)
        {
            _peliculaRepository = peliculaRepository;
            _fileRepository = fileRepository;
            _actorRepository = actorRepository;
            _reviewRepository = reviewRepository;
        }

        public async Task AddActor(Guid idPelicula, Guid idActor)
        {
            var actores = await _actorRepository.GetAsync(x => x.Id.Equals(idActor), isTracking: true, includeObjectProperties: x => x.Peliculas);
            var actor = actores.FirstOrDefault();
            if (actor == null) throw new AppNotExistEntityException($"Actor con id {idActor} no existe");

            var peliculas = await _peliculaRepository.GetAsync(x => x.Id.Equals(idPelicula), includeObjectProperties: x => x.Actores);
            var pelicula = peliculas.FirstOrDefault();
            if (pelicula == null) throw new AppNotExistEntityException($"Pelicula con id {idPelicula} no existe");

            pelicula.Actores.Add(actor);

            await _peliculaRepository.UpdateAsync(pelicula);

        }

        public async Task AddReview(Guid idPelicula, Review review)
        {
            var pelicula = await _peliculaRepository.GetByIdAsync(idPelicula);
            review.Pelicula = pelicula ?? throw new AppNotExistEntityException($"Pelicula con id {idPelicula} no existe");

            await _reviewRepository.AddAsync(review);
        }

        public async Task<Pelicula> CreatePeliculaAsync(Pelicula pelicula)
        {
            return await _peliculaRepository.AddAsync(pelicula);
        }

        public async Task UploadPosterToPelicula(Guid id, byte[] content, string extension, string contentType)
        {
            var pelicula = await _peliculaRepository.GetByIdAsync(id);
            if (pelicula == null) throw new AppNotExistEntityException($"Pelicula con id {id} no existe");
            using var memoryStream = new MemoryStream();
            pelicula.Poster = string.IsNullOrEmpty(pelicula.Poster)
                ? await _fileRepository.Save(content, extension, contentType)
                : await _fileRepository.Update(content, extension, pelicula.Poster, contentType);
            await _peliculaRepository.UpdateAsync(pelicula);
        }
    }
}