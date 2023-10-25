using Products.DataAccess.Common.Interfaces;
using Products.Domain.Entities.Products;

namespace Products.DataAccess.Interfaces.Products;

public interface IProductRepository : IRepository<Product>,IGetAll<Product>,ISearchable<Product>
{}
