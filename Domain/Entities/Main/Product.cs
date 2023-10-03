using System.Collections;
using System.Security.AccessControl;

namespace Domain.Entities;

public class Product : Auditable
{
    public Product()
    {
        Description = string.Empty;
        Costs = new List<Cost>();
        Prices = new List<Price>();
    }
    
    public string Description { get; set; }
    public virtual Category Category { get; set; }
    public virtual ICollection<Cost> Costs { get; set; }
    public virtual ICollection<Price> Prices { get; set; }
    public virtual Provider Provider { get; set; }
}