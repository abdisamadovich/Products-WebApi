using Products.DataAccess.Utils;

namespace Products.Service.Interfaces;

public interface IPaginator
{
    public void Paginate(long ItemsCount, PaginationParams @params);
}
