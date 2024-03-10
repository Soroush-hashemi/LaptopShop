using Common.Application;
using Common.Domain.Exceptions;
using Domain.Carts.Repository;

namespace Application.Carts.Increase;
public class IncreaseProductCountCommandHandler : IBaseCommandHandler<IncreaseProductCountCommand>
{
    private readonly ICartItemRepository _repository;
    public IncreaseProductCountCommandHandler(ICartItemRepository repository)
    {
        _repository = repository;
    }

    public async Task<OperationResult> Handle(IncreaseProductCountCommand request, CancellationToken cancellationToken)
    {
        try
        {
            var cartItem = await _repository.GetTracking(request.CartItemId);
            if (cartItem == null)
                return OperationResult.Error();

            cartItem.Increase();
            await _repository.Save();
            return OperationResult.Success();
        }
        catch (ProductIsNotEnoughException ex)
        {
            return OperationResult.Error(ex.Message);
        }
    }
}