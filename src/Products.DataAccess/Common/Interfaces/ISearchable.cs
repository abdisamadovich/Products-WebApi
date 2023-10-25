using Products.DataAccess.Utils;

namespace Products.DataAccess.Common.Interfaces;

public interface ISearchable<TModel>
{
    public Task<(int ItemsCount, IList<TModel>)> Searchable(string search,
        PaginationParams @params);
}
