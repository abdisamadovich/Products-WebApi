namespace Products.Domain.Entities.Products;

public class Product : Auditable
{
    public string Name { get; set; } = string.Empty;
    public string Type { get; set; } = string.Empty;    
    public double Price { get; set; }
    public string Brand { get; set; } = string.Empty;
}
