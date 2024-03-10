using Common.Application;
using Domain.Carts;
using Domain.Carts.Repository;
using Domain.Products.Repository;

namespace Application.Carts.Add;
public class AddToCartCommandHandler : IBaseCommandHandler<AddToCartCommand>
{
    private readonly ICartsRepository _cartrepository;
    private readonly ICartItemRepository _cartItemRepository;
    private readonly IProductRepository _productRepository;
    public AddToCartCommandHandler(ICartsRepository cartrepository, ICartItemRepository cartItemRepository, IProductRepository productRepository)
    {
        _cartrepository = cartrepository;
        _productRepository = productRepository;
        _cartItemRepository = cartItemRepository;
    }

    public async Task<OperationResult> Handle(AddToCartCommand request, CancellationToken cancellationToken)
    {
        var cart = _cartrepository.GetByUserId(request.UserId);
        if (cart == null)
        {
            var newCart = new Domain.Carts.Cart(request.UserId, false);
            _cartrepository.Add(newCart);
            await _cartrepository.Save();
            cart = newCart;
        }

        var product = await _productRepository.GetTracking(request.ProductId);
        if (product == null)
            return OperationResult.Error();
        if (product.ProductNotExist == true)
            return OperationResult.Error();

        var cartitem = _cartItemRepository.FindByProductIdandCartId(request.ProductId, cart.Id);
        if (cartitem != null)
        {
            cartitem.Increase();
        }
        else
        {
            var newCartItem = new CartItem(cart.Id, product.Id, 1, product.Price);
            _cartItemRepository.Add(newCartItem);
            await _cartItemRepository.Save();
        }

        return OperationResult.Success();
    }
}