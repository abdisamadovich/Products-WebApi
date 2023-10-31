using Dapper;
using Microsoft.Data.SqlClient;
using Products.DataAccess.Common.Interfaces;
using Products.DataAccess.Interfaces.Products;
using Products.DataAccess.Utils;
using Products.Domain.Entities.Products;

namespace Products.DataAccess.Repositories.Products;

public class ProductRepository : BaseRepository, IProductRepository
{
    public async Task<long> CountAsync()
    {
        try
        {
            await _connection.OpenAsync();
            string query = "SELECT COUNT(*) FROM products";
            var result = await _connection.QuerySingleAsync<long>(query);

            return result;
        }
        catch
        {
            return 0;
        }
        finally
        {
            await _connection.CloseAsync();
        }
    }

    public async Task<int> CreateAsync(Product entity)
    {
        try
        {
            await _connection.OpenAsync();

            string query = "INSERT INTO public.products(name, type, price, brand, created_at, updated_at) " +
                "VALUES (@Name, @Type, @Price, @Brand, @CreatedAt, @UpdatedAt);";

            var result = await _connection.ExecuteAsync(query, entity);

            return result;
        }
        catch
        {
            return 0;
        }
        finally
        {
            await _connection.CloseAsync();
        }
    }

    public async Task<int> DeleteAsync(long id)
    {
        try
        {
            await _connection.OpenAsync();
            string query = "DELETE FROM products WHERE id = @Id";
            var result = await _connection.ExecuteAsync(query, new { Id = id });

            return result;
        }
        catch
        {
            return 0;
        }
        finally
        {
            await _connection.CloseAsync();
        }
    }

    public async Task<IList<Product>> GetAllAsync(PaginationParams @params)
    {
        try
        {
            await _connection.OpenAsync();

            string query = $"SELECT * FROM products ORDER BY id DESC " +
                $"OFFSET {@params.GetSkipCount()} LIMIT {@params.PageSize}";

            var result = (await _connection.QueryAsync<Product>(query)).ToList();

            return result;
        }
        catch
        {
            return new List<Product>();
        }
        finally
        {
            await _connection.CloseAsync();
        }
    }

    public async Task<Product> GetByIdAsync(long id)
    {
        try
        {
            await _connection.OpenAsync();
            string query = "SELECT * FROM products WHERE id = @Id";
            var result = await _connection.QuerySingleAsync<Product>(query, new { Id = id });

            return result;
        }
        catch
        {
            return null;
        }
        finally
        {
            await _connection.CloseAsync();
        }
    }

    public async Task<IList<Product>> SearchAsync(string search, PaginationParams @params)
    {
        try
        {
            await _connection.OpenAsync();

            string query = $"SELECT * FROM public.products WHERE (name ILIKE '%{search}%' OR type" +
                $" ILIKE '%{search}%' OR brand ILIKE '%{search}%' OR price::text ILIKE '%{search}%') " +
                    $"ORDER BY id DESC OFFSET {@params.GetSkipCount()} LIMIT {@params.PageSize}";

            var products = await _connection.QueryAsync<Product>(query);

            return products.ToList();
        }
        catch
        {
            return new List<Product>();
        }
        finally
        {
            await _connection.CloseAsync();
        }
    }

    public async Task<IList<Product>> SortAsync(string sort, PaginationParams @params)
    {
        try
        {
            string query = $"SELECT p.* FROM products p ORDER BY {sort}";
            var products = await _connection.QueryAsync<Product>(query);

            return products.ToList();
        }
        catch
        {
            return new List<Product>();
        }
        finally
        {
            await _connection.CloseAsync();
        }
    }

    public async Task<int> UpdateAsync(long id, Product entity)
    {
        try
        {
            await _connection.OpenAsync();

            string query = $"UPDATE public.products SET name=@Name, type=@Type, price=@Price, brand=@Brand, " +
                $"created_at=@CreatedAt, updated_at=@UpdatedAt WHERE id=@Id;";

            var result = await _connection.ExecuteAsync(query, entity);

            return result;
        }
        catch
        {
            return 0;
        }
        finally
        {
            await _connection.CloseAsync();
        }
    }

    public async Task<IList<Product>> FiltrAsync(decimal? minPrice, decimal? maxPrice, DateTime? minTime, 
        DateTime? maxTime, PaginationParams @params)
    {
        try
        {
            string query = "SELECT p.* FROM products p WHERE 1=1";

            if (minPrice.HasValue)
            {
                query += $" AND p.price >= {minPrice}";
            }

            if (maxPrice.HasValue)
            {
                query += $" AND p.price <= {maxPrice}";
            }

            if (minTime.HasValue)
            {
                query += $" AND p.created_at >= '{minTime:yyyy-MM-dd}'";
            }

            if (maxTime.HasValue)
            {
                query += $" AND p.created_at <= '{maxTime:yyyy-MM-dd}'";
            }

            var products = await _connection.QueryAsync<Product>(query);

            return products.ToList();
        }
        catch
        {
            return new List<Product>();
        }
        finally
        {
            await _connection.CloseAsync();
        }
    }
}
