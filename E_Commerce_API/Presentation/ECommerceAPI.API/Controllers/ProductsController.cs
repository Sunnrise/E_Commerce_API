using ECommerceAPI.Application.Abstractions;
using ECommerceAPI.Application.Repositories.Products;
using ECommerceAPI.Domain.Entities;
using ECommerceAPI.Persistence.Repositories.Products;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ECommerceAPI.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        readonly private IProductWriteRepository _productWriteRepository;
        readonly private IProductReadRepository _productReadRepository;

        public ProductsController(IProductReadRepository productReadRepository, IProductWriteRepository productWriteRepository)
        {
            _productReadRepository = productReadRepository;
            _productWriteRepository = productWriteRepository;
        }
        [HttpGet]
        public async Task Get()
        {
           // await _productWriteRepository.AddRangeAsync(new()

           //{
           //     new() {Id=Guid.NewGuid(), Name = "Product 1", Price = 10, CreatedAt=DateTime.UtcNow, Stock=10},
           //     new() {Id=Guid.NewGuid(), Name = "Product 2", Price = 100, CreatedAt=DateTime.UtcNow, Stock=20},
           //     new() {Id=Guid.NewGuid(), Name = "Product 3", Price = 1000, CreatedAt=DateTime.UtcNow, Stock=30}
           // });
           // await _productWriteRepository.SaveAsync();
          Product product= await _productReadRepository.GetByIdAsync("81cfe121-2f62-4d50-996e-3985b0f2168a",false);
            product.Name="AlperenGunes";
            await _productWriteRepository.SaveAsync();

        }
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(string id)
        {
            Product product = await _productReadRepository.GetByIdAsync(id);
            return Ok(product);
        }


    } 
}

