using Products.DataAccess.Common.Interfaces;
using Products.DataAccess.Utils;
using Products.Domain.Entities.Products;

namespace Products.DataAccess.Interfaces.Products;

public interface IProductRepository : IRepository<Product>,IGetAll<Product>
{
    public Task<IList<Product>> SearchAsync(string search, PaginationParams @params);
    public Task<IList<Product>> SortAsync(string sort, PaginationParams @params);
    public Task<IList<Product>> FiltrAsync(decimal? minPrice, decimal? maxPrice, DateTime? minTime,
        DateTime? maxTime, PaginationParams @params);
}
