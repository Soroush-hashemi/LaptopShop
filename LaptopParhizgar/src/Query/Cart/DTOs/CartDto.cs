using Common.Query.Bases;

namespace Query.Cart.DTOs;
public class CartDto : BaseDto
{
    public long UserId { get; set; }
    public bool IsFinaly { get; set; }
    public List<CartItemDto> CartItem { get; set; }
}