namespace Domain.Entities;

public class Provider : Auditable
{
    public string Name { get; set; }
    public string? Description { get; set; }
}