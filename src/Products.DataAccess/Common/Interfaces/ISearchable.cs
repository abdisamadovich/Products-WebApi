using Products.DataAccess.Utils;

namespace Products.DataAccess.Common.Interfaces;

public interface ISearchable<Product>
{
    public Task<Product> Searchable(string search,
        PaginationParams @params);
}
