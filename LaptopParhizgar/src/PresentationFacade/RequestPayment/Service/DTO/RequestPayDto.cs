using Common.Query.Bases;

namespace PresentationFacade.RequestPayment.Service.DTO;
public class RequestPayDto : BaseDto
{
    public Guid guid { get; set; }
    public int Amount { get; set; }
    public long UserId { get; set; }
    public string Username { get; set; }
    public string Fullname { get; set; }
    public string PhoneNumber { get; set; }
    public string Email { get; set; }
    public bool IsPay { get; set; }
}