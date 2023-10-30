using Products.DataAccess.Interfaces.Products;
using Products.DataAccess.Utils;
using Products.Domain.Entities.Products;
using Products.Domain.Exceptions.Products;
using Products.Service.Dtos;
using Products.Service.Interfaces;

namespace Products.Service.Services;

public class ProductService : IProductService
{
    private readonly IProductRepository _repository;
    private readonly IPaginator _paginator;

    public ProductService(IProductRepository productRepository, IPaginator paginator)
    {
        this._repository = productRepository;
        this._paginator = paginator;
    }

    public async Task<long> CountAsync()
    {
        return await _repository.CountAsync();
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

    public async Task<bool> DeleteAsync(long productId)
    {
        var product = await _repository.GetByIdAsync(productId);
        if (product == null) throw new ProductNotFoundException();
        var result = await _repository.DeleteAsync(productId);

        return result > 0;
    }

    public async Task<IList<Product>> GetAllAsync(PaginationParams @params)
    {
        var product = await _repository.GetAllAsync(@params);
        
        var count = await _repository.CountAsync();
        _paginator.Paginate(count, @params);
        
        return product;
    }

    public async Task<Product> GetByIdAsync(long productId)
    {
        return await _repository.GetByIdAsync(@productId);
    }

    public async Task<IList<Product>> SearchAsync(string search, PaginationParams @params)
    {
        var product = await _repository.SearchAsync(search, @params);
        if (product is null) throw new ProductNotFoundException();
        return product;
    }

    public Task<bool> UpdateAsync(long ProductId, ProductUpdateDto dto)
    {
        throw new NotImplementedException();
    }
}
