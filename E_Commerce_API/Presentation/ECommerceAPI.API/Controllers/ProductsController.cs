using ECommerceAPI.Application.Abstractions;
using ECommerceAPI.Application.Repositories.Customers;
using ECommerceAPI.Application.Repositories.Orders;
using ECommerceAPI.Application.Repositories.Products;
using ECommerceAPI.Domain.Entities;
using ECommerceAPI.Persistence.Repositories.Products;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Runtime.InteropServices;

namespace ECommerceAPI.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        readonly private IProductWriteRepository _productWriteRepository;
        readonly private IProductReadRepository _productReadRepository;
        readonly private IOrderWriteRepository _orderWriteRepository;
        readonly private IOrderReadRepository _orderReadRepository;
        readonly private ICustomerWriteRepository _customerWriteRepository;

        public ProductsController(
            IProductReadRepository productReadRepository,
            IProductWriteRepository productWriteRepository,
            IOrderWriteRepository orderWriteRepository,
            ICustomerWriteRepository customerWriteRepository,
            IOrderReadRepository orderReadRepository)
        {
            _productReadRepository = productReadRepository;
            _productWriteRepository = productWriteRepository;
            _orderWriteRepository = orderWriteRepository;
            _customerWriteRepository = customerWriteRepository;
            _orderReadRepository = orderReadRepository;
        }
        #region OrderWrite
        //[HttpGet]
        //public async Task Get()
        //{
        //    var customerId = Guid.NewGuid();
        //    await _customerWriteRepository.AddAsync(new() { Name = "Alperen", Id = customerId });
        //    await _orderWriteRepository.AddAsync(new() { Description = "order detail", Address = "Eskişehir", CustomerId = customerId });
        //    await _orderWriteRepository.AddAsync(new() { Description = "order detail2", Address = "Eskişehirr", CustomerId = customerId });
        //    await _orderWriteRepository.AddAsync(new() { Description = "order detail3", Address = "Eskişehirrr", CustomerId = customerId });
        //    await _orderWriteRepository.SaveAsync();
        //}
        #endregion

        #region Add Range Test
        //[HttpGet]
        //public async Task Get()
        //{
        //   // await _productWriteRepository.AddRangeAsync(new()

        //   //{
        //   //     new() {Id=Guid.NewGuid(), Name = "Product 1", Price = 10, CreatedAt=DateTime.UtcNow, Stock=10},
        //   //     new() {Id=Guid.NewGuid(), Name = "Product 2", Price = 100, CreatedAt=DateTime.UtcNow, Stock=20},
        //   //     new() {Id=Guid.NewGuid(), Name = "Product 3", Price = 1000, CreatedAt=DateTime.UtcNow, Stock=30}
        //   // });
        //   // await _productWriteRepository.SaveAsync();
        //  Product product= await _productReadRepository.GetByIdAsync("81cfe121-2f62-4d50-996e-3985b0f2168a",false);
        //    product.Name="AlperenGunes";
        //    await _productWriteRepository.SaveAsync();
        #endregion

        #region GetByID
        //[HttpGet("{id}")]
        //public async Task<IActionResult> Get(string id)
        //{
        //    Product product = await _productReadRepository.GetByIdAsync(id);
        //    return Ok(product);
        //}
        #endregion
        [HttpGet]
        public async Task Get()
        {
            Order order = await _orderReadRepository.GetByIdAsync("b7a7f904-17c2-42d2-a5db-6f7bf48cb39f");
            order.Address = "Antalya";
            await _orderWriteRepository.SaveAsync();
        }
    }
}

