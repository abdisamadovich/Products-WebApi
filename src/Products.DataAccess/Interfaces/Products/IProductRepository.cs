using Products.DataAccess.Common.Interfaces;
using Products.DataAccess.Utils;
using Products.Domain.Entities.Products;

namespace Products.DataAccess.Interfaces.Products;

public interface IProductRepository : IRepository<Product>,IGetAll<Product>,ISearchable<Product>
{
    public Task<IList<Product>> SearchAsync(string search, PaginationParams @params);
}
