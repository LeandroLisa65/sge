namespace Domain.Entities;

public class Price : AuditableEntity
{
    public decimal PriceValue { get; set; }
}