namespace Domain.Entities;

public class ProductCostHistory : AuditableEntity
{
    public Product Product { get; set; }
}