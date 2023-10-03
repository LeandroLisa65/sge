namespace Domain.Entities;

public class User : Auditable
{
    public User()
    {
        Names = string.Empty;
        LastNames = string.Empty;
        Roles = new List<Role>();
    }
    
    public string? UserName { get; set; }
    public string? Password { get; set; }
    public string Names { get; set; }
    public string LastNames { get; set; }
    public virtual ICollection<Role> Roles { get; set; }
}