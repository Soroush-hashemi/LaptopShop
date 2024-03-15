using Query.Posts.DTOs;

namespace Query.Payment.DTO;
public class RequestPayFilterDto : BasePagination
{
    public List<RequestPayDto> RequestPay { get; set; }
    public RequestPayFilterParams FilterParams { get; set; }
}

public class RequestPayFilterParams
{
    public int PageId { get; set; }
    public int Take { get; set; }
}
