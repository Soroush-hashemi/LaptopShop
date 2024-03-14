using Common.Query;
using Query.Cart.DTOs;

namespace Query.Cart.GetMyCart;
public record GetMyCartItemByCartQuery(CartDto cartDto) : IQuery<List<CartItemDto>>;