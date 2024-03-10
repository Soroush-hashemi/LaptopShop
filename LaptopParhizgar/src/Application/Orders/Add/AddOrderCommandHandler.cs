using Common.Application;
using Domain.Carts;
using Domain.Orders;
using Domain.Orders.Repository;
using Domain.Payment;
using Domain.Products;

namespace Application.Orders.Add;
public class AddOrderCommandHandler : IBaseCommandHandler<AddOrderCommand>
{
    private readonly IOrderRepository _repository;
    private readonly IOrderDetailRepository _orderDetailRepository;
    public AddOrderCommandHandler(IOrderRepository repository, IOrderDetailRepository orderDetailRepository)
    {
        _repository = repository;
        _orderDetailRepository = orderDetailRepository;
    }

    public async Task<OperationResult> Handle(AddOrderCommand request, CancellationToken cancellationToken)
    {
        var requestPay = _repository.FindRequestPayById(request.RequestPayId);
        var cart = _repository.FindCartsById(request.CartId);

        var order = new Order(request.UserId, request.RequestPayId, request.AddressId);
        requestPay.IsPaid();
        cart.Finaly();

        _repository.Add(order);

        List<CartItem> CartItemList = new List<CartItem>();
        List<OrderDetail> OrderDetails = new List<OrderDetail>();

        if (cart != null)
        {
            var cartItem = _repository.FindCartItemListByCartId(cart.Id);
            foreach (var item in cartItem)
            {
                var product = GetProductById(item.ProductId);
                if (product == null)
                    return OperationResult.NotFound();

                if (product.DiscountedPrice != null && product.DiscountedPrice > 0)
                    item.Price = (int)product.DiscountedPrice;

                CartItemList.Add(new CartItem(item.CartId, product.Id, item.Count, item.Price));
            }

            foreach (var item in CartItemList)
            {
                var product = GetProductById(item.ProductId);
                if (product == null)
                    return OperationResult.NotFound();

                if (product.DiscountedPrice != null && product.DiscountedPrice > 0)
                    item.Price = (int)product.DiscountedPrice;

                var orderDetail = new OrderDetail(order.Id, item.ProductId, item.Price, item.Count);
                OrderDetails.Add(orderDetail);
            }
            await _orderDetailRepository.AddRange(OrderDetails);
            await _orderDetailRepository.Save();
            await _repository.Save();
        }
        else
        {
            return OperationResult.NotFound();
        }
        return OperationResult.Success();
    }

    public Product GetProductById(long productId)
    {
        return _repository.FindProductById(productId);
    }
}