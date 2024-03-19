using PresentationFacade.ProductComment.Service.DTO;

namespace PresentationFacade.ProductComment.Service;
public interface ICommentService
{
    List<ProductCommentDto> GetProductComments(long ProductId);
    List<ProductCommentDto> GetAllCommentsForAdmin();
}