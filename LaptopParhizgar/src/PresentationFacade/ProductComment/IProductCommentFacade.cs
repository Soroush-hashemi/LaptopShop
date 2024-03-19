using Application.ProductComment.Create;
using Application.ProductComment.Delete;
using Application.ProductComment.Edit;
using Common.Application;

namespace PresentationFacade.ProductComment;
public interface IProductCommentFacade
{
    Task<OperationResult> Create(CreateCommentCommand command);
    Task<OperationResult> Edit(EditCommentCommand command);
    Task<OperationResult> Delete(DeleteCommentCommand command);
}