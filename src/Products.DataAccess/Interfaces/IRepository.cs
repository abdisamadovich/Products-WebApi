using Products.Domain.Entities.Products;

namespace Products.DataAccess.Interfaces;

public interface IRepository<TEntity>
{
    public Task<int> CreateAsync(TEntity entity);

    public Task<int> UpdateAsync(long id, TEntity entity);

    public Task<int> DeleteAsync(long id);

    public Task<Product> GetByIdAsync(long id);

    public Task<long> CountAsync();
}
