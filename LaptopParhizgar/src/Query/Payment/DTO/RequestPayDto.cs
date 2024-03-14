using Common.Query.Bases;

namespace Query.Payment.DTO;
public class RequestPayDto : BaseDto
{
    public Guid guid { get; set; }
    public bool IsPay { get; set; }
    public int Amount { get; set; }
    public string Email { get; set; }
    public string PhoneNumber { get; set; }
    public long RequestPayId { get; set; }

}