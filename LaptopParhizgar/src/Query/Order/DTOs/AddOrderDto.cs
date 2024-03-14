using Common.Query.Bases;

namespace Query.Order.DTOs;
public class AddOrderDto
{
    public long CartId { get; set; }
    public long RequestPayId { get; set; }
    public long UserId { get; set; }
    public long TotalPrice { get; set; }
    public long AddressId { get; set; }

}