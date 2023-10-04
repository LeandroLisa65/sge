namespace Domain.Entities;

public class Table : AuditableEntity
{
    public Table()
    {
        Description = string.Empty;
    }
    public string Description { get; set; }
    public virtual Sell Sell { get; set; }
}