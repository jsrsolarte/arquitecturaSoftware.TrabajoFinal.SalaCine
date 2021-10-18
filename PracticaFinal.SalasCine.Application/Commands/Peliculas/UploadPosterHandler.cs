using MediatR;
using PracticaFinal.SalasCine.Domain.Ports;
using System.IO;
using System.Threading;
using System.Threading.Tasks;

namespace PracticaFinal.SalasCine.Application.Commands.Peliculas
{
    public class UploadPosterHandler : AsyncRequestHandler<UploadPoster>
    {
        private readonly IPeliculaService _peliculaService;

        public UploadPosterHandler(IPeliculaService peliculaService)
        {
            _peliculaService = peliculaService;
        }

        protected override async Task Handle(UploadPoster request, CancellationToken cancellationToken)
        {
            using var memoryStream = new MemoryStream();
            await request.Poster.CopyToAsync(memoryStream, cancellationToken);
            var contenido = memoryStream.ToArray();
            var extension = Path.GetExtension(request.Poster.FileName);

            await _peliculaService.UploadPosterToPelicula(request.IdPelicula, contenido, extension, request.Poster.ContentType);
        }
    }
}
