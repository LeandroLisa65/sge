namespace Domain.Entities;

public class Role : EntityBase
{
    public Role()
    {
        Description = string.Empty;
        Permissions = new List<Permission>();
    }
    
    public string Description { get; set; }
    public virtual ICollection<Permission> Permissions { get; set; }
}