namespace WebApplication.Areas.Admin.Models.Order;
public class OrderViewModel
{
    public long Id { get; set; }
    public long OrderDetailsId { get; set; }
    public OrderStateViewModel OrderState { get; set; }
    public long RequestPayId { get; set; }
    public long UserId { get; set; }
    public long AddressId { get; set; }
    public string UserName { get; set; }
    public long Price { get; set; }
    public long TotalPrice { get; set; }
    public List<OrderDetailsViewModel> OrderDetails { get; set; }
    public DateTime CreationDate { get; set; }
}

public enum OrderStateViewModel
{
    Processing = 0,
    Canceled = 1,
    Delivered = 2
}