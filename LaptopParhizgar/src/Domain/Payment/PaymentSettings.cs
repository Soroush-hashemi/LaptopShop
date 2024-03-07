using Common.Domain.Bases;

namespace Domain.Payment;
public class PaymentSettings : BaseEntity
{
    public bool PaymentSetting { get; private set; }

    public void Enable()
    {
        PaymentSetting = true;
    }

    public void Disable()
    {
        PaymentSetting = false;
    }
}