using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Products.Service.Dtos;
using Products.Service.Interfaces;

namespace Products.WebApi.Controllers
{
    [Route("api/products")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductService _productService;
        private readonly int maxPageSize = 30;

        public ProductsController(IProductService product)
        {
            this._productService = product;
        }

        [HttpPost]
        public async Task<IActionResult> CreateAsync([FromForm] ProductCreateDto dto)
        {
            return Ok(await  _productService.CreateAsync(dto)); 
        }
    }
}
