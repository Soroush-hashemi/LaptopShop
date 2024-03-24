using Common.Domain.Bases;
using Common.Domain.Exceptions;

namespace Domain.Products;
public class ProductComment : BaseEntity
{
    public long UserId { get; private set; }
    public long ProductId { get; private set; }
    public string Text { get; private set; }

    private ProductComment()
    {
        
    }

    public ProductComment(long userId, long productId, string text)
    {
        Guard(text);
        UserId = userId;
        ProductId = productId;
        Text = text;
    }

    public void Guard(string text)
    {
        NullOrEmptyException.CheckString(text, nameof(text));
    }
}