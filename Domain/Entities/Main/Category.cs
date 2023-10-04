namespace Domain.Entities;

public class Category : AuditableEntity
{
    public Category()
    {
        Description = string.Empty;
    }
    public string Description { get; set; }
}