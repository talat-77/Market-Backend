using Azure.Storage.Blobs;
using MarketAPI.Application.Abstractions.Storage;
using MarketAPI.Domain.Entities;
using MarketAPI.Infrastructure.Services.FileStorage.InfraConfigurations;
using MarketAPI.Persistence.Contexts;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace MarketAPI.Infrastructure.Services.FileStorage
{

    public class AzureBlobStorageService : IFileStorageService
    {
        private readonly AzureBlobSettings _azureblobSettings;

        public AzureBlobStorageService(AzureBlobSettings azureblobSettings)
        {
            _azureblobSettings = azureblobSettings;
        }
        private readonly MarketAPIDbContext _context;

        private readonly BlobContainerClient _blobcontainerClient;

        public AzureBlobStorageService(BlobContainerClient blobcontainerClient)
        {
            _blobcontainerClient = blobcontainerClient;
        }

        public async Task<bool> DeleteFileAsync(string fileName)
        {
            var blobClient = _blobcontainerClient.GetBlobClient(fileName);

            var result = await blobClient.DeleteIfExistsAsync();

            return result.Value;
        }

        public async Task<Stream> DownloadFileAsync(string fileName)
        {
            var blobClient = _blobcontainerClient.GetBlobClient(fileName);

            if (await blobClient.ExistsAsync())
            {
                var download = await blobClient.DownloadAsync();
                return download.Value.Content;
            }

            return null;
        }

        public async Task<string> UploadFileAsync(IFormFile file)
        {
            var fileName = Guid.NewGuid().ToString() + Path.GetExtension(file.FileName);
            var blobClient = _blobcontainerClient.GetBlobClient(fileName);

            using (var stream = file.OpenReadStream())
            {
                await blobClient.UploadAsync(stream, new Azure.Storage.Blobs.Models.BlobHttpHeaders
                {
                    ContentType = file.ContentType
                });
            }

            return blobClient.Uri.ToString(); // URL'yi geri döndürüyoruz
        }
    }
}
