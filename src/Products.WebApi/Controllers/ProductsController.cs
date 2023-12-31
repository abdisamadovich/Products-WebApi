﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Products.DataAccess.Utils;
using Products.Service.Dtos;
using Products.Service.Interfaces;
using Products.Service.Services;

namespace Products.WebApi.Controllers
{
    [Route("api/products")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductService _service;
        private readonly int maxPageSize = 30;

        public ProductsController(IProductService service)
        {
            this._service = service;
        }

        [HttpPost]
        public async Task<IActionResult> CreateAsync([FromForm] ProductCreateDto dto)
        {
            return Ok(await  _service.CreateAsync(dto)); 
        }

        [HttpDelete("{productId}")]
        public async Task<IActionResult> DeleteAsync(long productId) => Ok(await _service.DeleteAsync(productId));

        [HttpGet]
        public async Task<IActionResult> GetAllAsync([FromQuery] int page = 1)
        {
            return Ok(await _service.GetAllAsync(new PaginationParams(page, maxPageSize)));
        }

        [HttpGet("{productId}")]
        public async Task<IActionResult> GetByIdAsync(long productId)
        {
            return Ok(await _service.GetByIdAsync(productId));
        }

        [HttpGet("search")]
        [AllowAnonymous]
        public async Task<IActionResult> SearchAsync([FromQuery] string search, [FromQuery] int page = 1)
            => Ok(await _service.SearchAsync(search, new PaginationParams(page, maxPageSize)));

        [HttpGet("sort")]
        public async Task<IActionResult> SortAsync([FromQuery] string sortProperty, [FromQuery] int page = 1)
            => Ok(await _service.SortAsync(sortProperty, new PaginationParams(page,maxPageSize)));

        [HttpGet("filter")]
        public async Task<IActionResult> FilterAsync(
            [FromQuery] decimal? minPrice,
            [FromQuery] decimal? maxPrice,
            [FromQuery] DateTime? minTime,
            [FromQuery] DateTime? maxTime,
            [FromQuery] int page = 1)
        {
            try
            {
                var paginationParams = new PaginationParams(page, maxPageSize);
                var products = await _service.FilterAsync(minPrice, maxPrice, minTime, maxTime, paginationParams);
                return Ok(products);
            }
            catch
            {
                return StatusCode(500, "Qayerdadir xato qilyapsiz");
            }
        }
    }
}
    