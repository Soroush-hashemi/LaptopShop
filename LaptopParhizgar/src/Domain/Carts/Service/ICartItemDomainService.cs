using Common.Application;

namespace Domain.Carts.Service;
public interface ICartItemDomainService
{
    public Task<OperationResult> RemoveFromCart(long CartItemId);
}