namespace Domain.Entities;

public interface IAuditable
{
    DateTime CreatedDate { get; set; }
    string CreatedBy { get; set; }
    DateTime? LastChangeDate { get; set; }
    public string? LastChangeBy { get; set; }
    public bool IsActive { get; set; }
}