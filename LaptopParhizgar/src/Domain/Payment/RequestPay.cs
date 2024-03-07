using Common.Domain.Bases;

namespace Domain.Payment;
public class RequestPay : BaseEntity
{
    public Guid Guid { get; private set; }
    public long UserId { get; private set; }
    public long OrderId { get; private set; }
    public int Amount { get; private set; }
    public bool IsPay { get; private set; }
    public string? Authority { get; private set; }
    public long RefId { get; private set; } = 0;
}