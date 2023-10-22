namespace Domain.Entities;

public class ProductPriceHistory : AuditableEntity
{
    public Product Product { get; set; }
}