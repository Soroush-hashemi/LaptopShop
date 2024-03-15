using Common.Query.Bases;
using Domain.Orders;

namespace Query.Order.DTOs;
public class OrderDetailsDto : BaseDto
{
    public long OrderId { get; set; }
    public long ProductId { get; set; }
    public string ProductName { get; set; }
    public long Price { get; set; }
    public int Count { get; set; }
    public string ProductSlug { get; set; }
    public OrderState OrderState { get; set; }
    public string NameOfRecipient { get; set; }
    public string Province { get; set; }
    public string City { get; set; }
    public string PostalCode { get; set; }
    public string AddressDetail { get; set; }
    public string PhoneNumberForAddress { get; set; }
}