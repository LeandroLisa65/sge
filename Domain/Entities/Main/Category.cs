namespace Domain.Entities;

public class Category : Auditable
{
    public Category()
    {
        Description = string.Empty;
    }
    public string Description { get; set; }
}