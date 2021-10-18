using PracticaFinal.SalasCine.Domain.Entities;
using System;
using System.Threading.Tasks;

namespace PracticaFinal.SalasCine.Domain.Ports
{
    public interface IActorService
    {
        Task<Actor> CreateActorAsync(Actor actor);
        Task UploadFotoToActor(Guid id, byte[] content, string extension, string contentType);
    }
}
