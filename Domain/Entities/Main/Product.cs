using System.Collections;
using System.Security.AccessControl;

namespace Domain.Entities;

public class Product : AuditableEntity
{
    public Product()
    {
        Description = string.Empty;
    }
    
    public string Description { get; set; }
    public virtual Category Category { get; set; }
    public virtual Cost Cost { get; set; }
    public virtual Price Price { get; set; }
    public virtual Provider Provider { get; set; }
}