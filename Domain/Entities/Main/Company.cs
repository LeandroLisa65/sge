namespace Domain.Entities;

public class Company : AuditableEntity
{
    public Company()
    {
        Stores = new List<Store>();
    }
    public string? Name { get; set; }
    public virtual ICollection<Store> Stores { get; set; }
}