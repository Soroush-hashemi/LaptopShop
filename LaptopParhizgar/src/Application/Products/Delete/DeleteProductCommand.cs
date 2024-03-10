using Common.Application;

namespace Application.Products.Delete;
public class DeleteProductCommand : IBaseCommand
{
    public DeleteProductCommand(long productId)
    {
        ProductId = productId;
    }

    public long ProductId { get; set; }
}