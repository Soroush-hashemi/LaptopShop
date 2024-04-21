using Common.Query;
using Query.Cart.DTOs;

namespace Query.Cart.GetMyCart;
public record GetMyCartItemByCartQuery(long UserId) : IQuery<List<CartItemDto>>;