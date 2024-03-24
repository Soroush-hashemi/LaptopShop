using Application.ProductComment.Create;
using Application.ProductComment.Delete;
using Common.Application;

namespace PresentationFacade.ProductComment;
public interface IProductCommentFacade
{
    Task<OperationResult> Create(CreateCommentCommand command);
    Task<OperationResult> Delete(long commentId);
}