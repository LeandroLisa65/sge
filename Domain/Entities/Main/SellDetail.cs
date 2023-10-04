namespace Domain.Entities;

public class SellDetail : AuditableEntity
{
    public virtual Sell Sell { get; set; }
    public virtual Product Product { get; set; }
}