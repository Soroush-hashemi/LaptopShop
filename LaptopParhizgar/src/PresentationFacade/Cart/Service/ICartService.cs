namespace PresentationFacade.Cart.Service;
public interface ICartService
{
    public Task<long> GetTotalPrice(long userId);
}