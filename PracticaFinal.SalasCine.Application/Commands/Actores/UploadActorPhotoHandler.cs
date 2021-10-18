using MediatR;
using PracticaFinal.SalasCine.Domain.Ports;
using System.IO;
using System.Threading;
using System.Threading.Tasks;

namespace PracticaFinal.SalasCine.Application.Commands.Actores
{
    public class UploadActorPhotoHandler : AsyncRequestHandler<UploadActorPhoto>
    {
        private readonly IActorService _actorService;

        public UploadActorPhotoHandler(IActorService actorService)
        {
            _actorService = actorService;
        }

        protected override async Task Handle(UploadActorPhoto request, CancellationToken cancellationToken)
        {
            using var memoryStream = new MemoryStream();
            await request.Foto.CopyToAsync(memoryStream, cancellationToken);
            var contenido = memoryStream.ToArray();
            var extension = Path.GetExtension(request.Foto.FileName);
            await _actorService.UploadFotoToActor(request.IdActor, contenido, extension, request.Foto.ContentType);
        }
    }
}
