using Common.Application;
using Domain.Carts.Repository;

namespace Application.Carts.RemoveItemFromCart;
public class RemoveItemFromCartCommandHandler : IBaseCommandHandler<RemoveItemFromCartCommand>
{
    private readonly ICartItemRepository _repository;
    public RemoveItemFromCartCommandHandler(ICartItemRepository repository)
    {
        _repository = repository;
    }

    public async Task<OperationResult> Handle(RemoveItemFromCartCommand request, CancellationToken cancellationToken)
    {
        var cartItem = await _repository.GetTracking(request.CartItemId);
        if (cartItem == null)
            return OperationResult.Error();

        _repository.Remove(cartItem);
        await _repository.Save();
        return OperationResult.Success();
    }
}