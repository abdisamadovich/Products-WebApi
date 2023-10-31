using Products.DataAccess.Utils;
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
    public Task<IList<Product>> SearchAsync(string search, PaginationParams @params);
    public Task<IList<Product>> SortAsync(string sort, PaginationParams @params);
    Task<IList<Product>> FilterAsync(decimal? minPrice, decimal? maxPrice, DateTime? minTime, DateTime? maxTime, PaginationParams @params);

}
