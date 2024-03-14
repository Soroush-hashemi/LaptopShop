using Common.Query;
using Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using Query.Cart.DTOs;

namespace Query.Cart.GetMyCart;
public class GetMyCartItemByCartQueryHandler : IQueryHandler<GetMyCartItemByCartQuery, List<CartItemDto>>
{
    private readonly LaptopParhizgerContext _context;
    public GetMyCartItemByCartQueryHandler(LaptopParhizgerContext context)
    {
        _context = context;
    }

    public async Task<List<CartItemDto>> Handle(GetMyCartItemByCartQuery request, CancellationToken cancellationToken)
    {
        var cart = await _context.Carts.Where(c => c.UserId == request.cartDto.UserId && c.IsFinaly == false).FirstOrDefaultAsync();

        List<CartItemDto> CartItemDto = new List<CartItemDto>();

        if (cart != null)
        {
            var Cartitem = await _context.CartItem.Where(p => p.CartId == cart.Id).ToListAsync();
            foreach (var item in Cartitem)
            {
                var product = _context.Products.FirstOrDefault(p => p.Id == item.ProductId);
                if (product == null)
                {
                    return new List<CartItemDto>();
                }

                if (product.DiscountedPrice != null && product.DiscountedPrice > 0)
                {
                    item.Price = (int)product.DiscountedPrice;
                }

                CartItemDto.Add(new CartItemDto()
                {
                    Count = item.Count,
                    Price = item.Price,
                    Sum = item.Price * item.Count,
                    ProductName = product.Title,
                    Id = item.Id,
                    Color = product.Color,
                    ProductId = product.Id,
                    Images = product.ImageName,
                    CartId = cart.Id,
                    ProductSlug = product.Slug,
                });
            }
            return CartItemDto;
        }
        else
        {
            return new List<CartItemDto>();
        }
    }
}