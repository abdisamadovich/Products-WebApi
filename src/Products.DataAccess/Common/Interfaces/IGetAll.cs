using Products.DataAccess.Utils;

namespace Products.DataAccess.Common.Interfaces;

public interface IGetAll<TModel>
{
    public Task<IList<TModel>> GetAllAsync(PaginationParams @params);
}
