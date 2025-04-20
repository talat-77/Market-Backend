using MarketAPI.Application.Repositories.ProductRepository;
using MarketAPI.Application.ViewModels.Product_VM;
using MarketAPI.Persistence.Repositories.ProductRepository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace MarketAPI.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductReadRepository _productReadRepository;
        private readonly IProductWriteRepository _productWriteRepository;
        public ProductsController(IProductReadRepository productReadRepository, IProductWriteRepository productWriteRepository)
        {
            _productReadRepository = productReadRepository;
            _productWriteRepository = productWriteRepository;
        }

        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] int page = 0, [FromQuery] int size = 5)
        {

            var totalProductCount = await _productReadRepository.GetAll(false).CountAsync();


            var products = await _productReadRepository.GetAll(false)
                                      .Skip(page * size)
                                      .Take(size)
                                      .Select(p => new
                                      {
                                          p.Id,
                                          p.Name,
                                          p.Price,
                                          p.Stock,
                                          p.CreatedDate,
                                          p.UpdatedDate
                                      })
                                      .ToListAsync();

            return Ok(new
            {
                totalProductCount,
                products
            });
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            // string id'yi Guid'e dönüştür
            if (!Guid.TryParse(id, out Guid productId))
            {
                return BadRequest(new { Message = "Geçersiz ID formatı" });
            }

            // Ürünü ID'ye göre bul
            var deleted = await _productReadRepository.GetByIdAsync(productId.ToString(), false);

            if (deleted == null)
            {
                return NotFound(new { Message = "Ürün Bulunamadı" });
            }

            // Ürünü sil
            await _productWriteRepository.RemoveAsync(productId); // GUID olarak geçer

            return NoContent();
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(string id)
        {
            // Async işlem bekleniyor
            var product = await _productReadRepository.GetByIdAsync(id, false);
            if (product == null)
            {
                return NotFound();  // Ürün bulunamazsa 404 döner
            }
            return Ok(product);
        }

        [HttpPost]
        public async Task<IActionResult> Post(Create_Product_VM model)
        {
            if (string.IsNullOrEmpty(model.ImageUrl))
            {
                return BadRequest(new { Message = "Görsel URL'si gereklidir." });
            }
            await _productWriteRepository.AddAsync(new()
            {
                Name = model.Name,
                Price = model.Price,
                Stock = model.Stock ,
                ImageUrl = model.ImageUrl
            });
            await _productWriteRepository.SaveAsync();
            return Ok();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(string id, [FromBody] Update_Product_VM model)
        {
            var product = await _productReadRepository.GetByIdAsync(id);
            if (product == null)
            {
                return NotFound(new { Message = "Ürün bulunamadı." });
            }

            // ImageUrl zorunlu değilse, kontrolü kaldırıyoruz
            if (model.Name != null)
                product.Name = model.Name;
            if (model.Price != null)
                product.Price = model.Price;
            if (model.Stock != null)
                product.Stock = model.Stock;

            // ImageUrl boş ise, mevcut değeri koruyalım
            if (!string.IsNullOrEmpty(model.ImageUrl))
            {
                product.ImageUrl = model.ImageUrl;
            }

            await _productWriteRepository.SaveAsync();

            return Ok(new { Message = "Ürün başarıyla güncellendi." });
        }



    }
}
