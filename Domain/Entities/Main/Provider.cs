namespace Domain.Entities;

public class Provider : AuditableEntity
{
    public string Name { get; set; }
    public string? Description { get; set; }
}