using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities;

public class EntityBase : IEntityBase
{
    [Column(Order = 0), DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public long Id { get; set; }
}