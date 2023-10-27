﻿using Products.DataAccess.Utils;
using Products.Domain.Entities.Products;
using Products.Service.Dtos;

namespace Products.Service.Interfaces;

public interface IProductService
{
    public Task<bool> CreateAsync(ProductCreateDto dto);
    public Task<bool> UpdateAsync(long ProductId, ProductUpdateDto dto);
    public Task<IList<Product>> GetAllAsync(PaginationParams @params);
    public Task<bool> DeleteAsync(long productId);
    public Task<long> CountAsync();
    public Task<Product> GetByIdAsync(long productId);  
}