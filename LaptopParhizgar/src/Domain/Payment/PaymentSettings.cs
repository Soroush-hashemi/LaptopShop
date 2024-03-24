using Common.Domain.Bases;

namespace Domain.Payment;
public class PaymentSettings : BaseEntity
{
    public bool PaymentStatus { get; private set; }

    private PaymentSettings()
    {
        
    }

    public void Enable()
    {
        PaymentStatus = true;
    }

    public void Disable()
    {
        PaymentStatus = false;
    }
}