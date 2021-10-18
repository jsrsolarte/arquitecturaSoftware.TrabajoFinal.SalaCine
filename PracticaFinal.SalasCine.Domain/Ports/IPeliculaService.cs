using PracticaFinal.SalasCine.Domain.Entities;
using System;
using System.Threading.Tasks;

namespace PracticaFinal.SalasCine.Domain.Ports
{
    public interface IPeliculaService
    {
        Task<Pelicula> CreatePeliculaAsync(Pelicula pelicula);

        Task UploadPosterToPelicula(Guid id, byte[] content, string extension, string contentType);

        Task AddActor(Guid idPelicula, Guid idActor);

        Task AddReview(Guid idPelicula, Review review);
    }
}