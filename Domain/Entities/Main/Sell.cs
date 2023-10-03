using Domain.Entities.Utils;

namespace Domain.Entities;

public class Sell : Auditable
{
    public Sell()
    {
        SellDetails = new List<SellDetail>();
        State = SellStateEnum.SellStates.Started;
    }
    public virtual User User { get; set; }
    public virtual ICollection<SellDetail> SellDetails { get; set; }
    public SellStateEnum.SellStates State { get; set; }
    public virtual Client? Client { get; set; }
    public virtual Payment? Payment { get; set; }
    public virtual Store Store { get; set; }
}