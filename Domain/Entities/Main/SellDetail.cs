namespace Domain.Entities;

public class SellDetail : Auditable
{
    public virtual Sell Sell { get; set; }
    public virtual Product Product { get; set; }
}