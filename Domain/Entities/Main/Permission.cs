namespace Domain.Entities;

public class Permission : EntityBase
{
    public Permission()
    {
        Description = string.Empty;
    }
    public string Description { get; set; }
}