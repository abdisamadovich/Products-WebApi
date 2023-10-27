using Products.DataAccess.Interfaces.Products;
using Products.DataAccess.Utils;
using Products.Domain.Entities.Products;
using Products.Service.Dtos;
using Products.Service.Interfaces;

namespace Products.Service.Services;

public class ProductService : IProductService
{
    private readonly IProductRepository _repository;

    public ProductService(IProductRepository productRepository)
    {
        this._repository = productRepository;
    }

    public Task<long> CountAsync()
    {
        throw new NotImplementedException();
    }

    public async Task<bool> CreateAsync(ProductCreateDto dto)
    {
        Product product = new Product();
        product.Name = dto.Name;
        product.Type = dto.Type;
        product.Price = dto.Price;
        product.Brand = dto.Brand;
        product.CreatedAt = product.UpdatedAt = TimeHelper.GetDateTime();
        var result = await _repository.CreateAsync(product);
        return result > 0;
    }

    public Task<bool> DeleteAsync(long productId)
    {
        throw new NotImplementedException();
    }

    public Task<IList<Product>> GetAllAsync(PaginationParams @params)
    {
        throw new NotImplementedException();
    }

    public Task<Product> GetByIdAsync(long productId)
    {
        throw new NotImplementedException();
    }

    public Task<bool> UpdateAsync(long ProductId, ProductUpdateDto dto)
    {
        throw new NotImplementedException();
    }
}
