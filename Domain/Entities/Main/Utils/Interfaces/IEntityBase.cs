using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities;

public interface IEntityBase
{
    [Column(Order = 0), DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public long Id { get; set; }
}