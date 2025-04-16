using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.IO;
using System.Threading.Tasks;
using MarketAPI.Application.Abstractions.Storage;
using MarketAPI.Infrastructure;
using MarketAPI.Persistence.Contexts;
using MarketAPI.Domain.Entities;  // ApplicationDbContext'e erişim için

namespace MarketAPI.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FileController : ControllerBase
    {
        private readonly IFileStorageService _fileStorageService;
        private readonly MarketAPIDbContext _context; // DbContext

        public FileController(IFileStorageService fileStorageService, MarketAPIDbContext context)
        {
            _fileStorageService = fileStorageService;
            _context = context;
        }

        [HttpPost("upload")]
        public async Task<IActionResult> UploadFile(IFormFile file)
        {
            if (file == null || file.Length == 0)
                return BadRequest("No file uploaded.");

            // Service'i kullanarak dosya yükleme işlemini yapıyoruz
            var fileUrl = await _fileStorageService.UploadFileAsync(file);

            // Dosya bilgilerini veritabanına kaydediyoruz
            var fileInfo = new FileInfoo
            {
                FileName = Path.GetFileName(file.FileName),
                FileUrl = fileUrl,
               
            };

            // Veritabanına kaydediyoruz
            _context.FileInfos.Add(fileInfo);
            await _context.SaveChangesAsync();

            return Ok(new { FileName = fileInfo.FileName, FileUrl = fileInfo.FileUrl });
        }
    }
}
