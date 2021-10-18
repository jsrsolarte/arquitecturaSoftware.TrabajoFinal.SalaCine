using PracticaFinal.SalasCine.Domain.Entities;
using PracticaFinal.SalasCine.Domain.Exceptions;
using PracticaFinal.SalasCine.Domain.Ports;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticaFinal.SalasCine.Domain.Services
{
    [DomainService]
    public class ActorService : IActorService
    {
        private readonly IGenericRepository<Actor> _actorRepository;
        private readonly IFileRepository _fileRepository;

        public ActorService(IGenericRepository<Actor> actorRepository, IFileRepository fileRepository)
        {
            _actorRepository = actorRepository;
            _fileRepository = fileRepository;
        }

        public async Task<Actor> CreateActorAsync(Actor actor)
        {
            return await _actorRepository.AddAsync(actor);
        }

        public async Task UploadFotoToActor(Guid id, byte[] content, string extension, string contentType)
        {
            var actor = await _actorRepository.GetByIdAsync(id);
            if (actor == null) throw new AppNotExistEntityException($"Actor con id {id} no existe");
            using var memoryStream = new MemoryStream();
            actor.Foto = string.IsNullOrEmpty(actor.Foto)
                ? await _fileRepository.Save(content, extension, contentType)
                : await _fileRepository.Update(content, extension, actor.Foto, contentType);
            await _actorRepository.UpdateAsync(actor);
        }
    }
}
