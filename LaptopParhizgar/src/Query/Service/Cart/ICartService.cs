namespace Query.Service.Cart;
public interface ICartService
{
    public Task<long> GetTotalPrice(long userId);
}