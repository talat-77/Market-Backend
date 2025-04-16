using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketAPI.Application.Abstractions.Storage
{
    public interface IFileStorageService
    {
        Task<string> UploadFileAsync(IFormFile file);
        Task<bool> DeleteFileAsync(string fileName);
        Task<Stream> DownloadFileAsync(string fileName);
    }
}
