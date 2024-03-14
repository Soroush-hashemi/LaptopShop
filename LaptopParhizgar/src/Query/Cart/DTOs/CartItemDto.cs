using Common.Query.Bases;

namespace Query.Cart.DTOs;
public class CartItemDto : BaseDto
{
    public long CartItemId { get; set; }
    public long CartId { get; set; }
    public long ProductId { get; set; }
    public string ProductName { get; set; }
    public string Images { get; set; }
    public int Count { get; set; }
    public long Price { get; set; }
    public string Color { get; set; }
    public string ProductSlug { get; set; }
    public long Sum { get; set; }
}