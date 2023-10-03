namespace Domain.Entities;

public class Auditable : EntityBase, IAuditable
{
    public Auditable()
    {
        CreatedBy = string.Empty;
        CreatedDate = DateTime.Now;
    }
    public DateTime CreatedDate { get; set; }
    public string CreatedBy { get; set; }
    public DateTime? LastChangeDate { get; set; }
    public string? LastChangeBy { get; set; }
    public bool IsActive { get; set; }
}