using Query.ProductComment.DTO;

namespace Query.ProductComment.Service;
public interface ICommentService
{
    List<ProductCommentDto> GetProductComments(int ProductId);
    List<ProductCommentDto> GetAllCommentsForAdmin();
}