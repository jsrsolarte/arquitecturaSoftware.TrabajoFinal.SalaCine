using Azure.Storage.Blobs;
using Azure.Storage.Blobs.Models;
using Microsoft.Extensions.Configuration;
using PracticaFinal.SalasCine.Domain.Ports;
using System;
using System.IO;
using System.Threading.Tasks;

namespace PracticaFinal.SalasCine.Infrastructure.Adapters
{
    public class BlobStorageFileRepository : IFileRepository
    {

        private readonly BlobContainerClient _blobContainer;

        public BlobStorageFileRepository(IConfiguration configuration)
        {
            _blobContainer = new BlobContainerClient(configuration.GetValue<string>("AzureStorage:ConnectionString"), configuration.GetValue<string>("AzureStorage:ContainerName"));
        }

        public async Task<string> Save(byte[] content, string extension, string contentType)
        {
            await _blobContainer.CreateIfNotExistsAsync();
            _blobContainer.SetAccessPolicy(PublicAccessType.Blob);

            var archivoNombre = $"{Guid.NewGuid()}{extension}";
            var blob = _blobContainer.GetBlobClient(archivoNombre);

            var blobUploadOptions = new BlobUploadOptions();
            var blobHttpHeader = new BlobHttpHeaders();
            blobHttpHeader.ContentType = contentType;
            blobUploadOptions.HttpHeaders = blobHttpHeader;

            await blob.UploadAsync(new BinaryData(content), blobUploadOptions);
            return blob.Uri.ToString();
        }

        public async Task Delete(string ruta)
        {
            if (string.IsNullOrEmpty(ruta))
            {
                return;
            }
            await _blobContainer.CreateIfNotExistsAsync();
            var archivo = Path.GetFileName(ruta);
            var blob = _blobContainer.GetBlobClient(archivo);
            await blob.DeleteIfExistsAsync();
        }

        public async Task<string> Update(byte[] content, string extension, string path, string contentType)
        {
            await Delete(path);
            return await Save(content, extension, contentType);
        }
    }
}
