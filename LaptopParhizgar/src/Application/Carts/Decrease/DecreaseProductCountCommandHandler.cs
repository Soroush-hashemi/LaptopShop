using Common.Application;
using Domain.Carts.Repository;
using Domain.Carts.Service;

namespace Application.Carts.Decrease;
public class DecreaseProductCountCommandHandler : IBaseCommandHandler<DecreaseProductCountCommand>
{
    private readonly ICartItemRepository _cartItemRepository;
    private readonly ICartItemDomainService _cartItemDomainService;
    public DecreaseProductCountCommandHandler(ICartItemRepository cartItemRepository, ICartItemDomainService cartItemDomainService)
    {
        _cartItemRepository = cartItemRepository;
        _cartItemDomainService = cartItemDomainService;
    }

    public async Task<OperationResult> Handle(DecreaseProductCountCommand request, CancellationToken cancellationToken)
    {
        var cartItem = await _cartItemRepository.GetTracking(request.CartItemId);
        if (cartItem == null)
            return OperationResult.Error();

        cartItem.Decrease(request.CartItemId, _cartItemDomainService);
        await _cartItemRepository.Save();
        return OperationResult.Success();
    }
}