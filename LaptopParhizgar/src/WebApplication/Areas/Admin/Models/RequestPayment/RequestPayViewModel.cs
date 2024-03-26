using Query.Sheard;
using WebApplication.Areas.Admin.Models.Shared;

namespace WebApplication.Areas.Admin.Models.RequestPayment;
public class RequestPayViewModel
{
    public long Id { get; set; }
    public DateTime CreationDate { get; set; }
    public Guid guid { get; set; }
    public int Amount { get; set; }
    public long UserId { get; set; }
    public string Username { get; set; }
    public string Fullname { get; set; }
    public string PhoneNumber { get; set; }
    public string Email { get; set; }
    public bool IsPay { get; set; }
}

public class RequestPayFilterViewModel : BasePaginationViewModel
{
    public List<RequestPayViewModel> RequestPay { get; set; }
    public RequestPayFilterParamsViewModel FilterParams { get; set; }
}

public class RequestPayFilterParamsViewModel
{
    public int PageId { get; set; }
    public int Take { get; set; }
}