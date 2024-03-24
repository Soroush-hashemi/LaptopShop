using Application.ProductComment.Create;
using Application.ProductComment.Delete;
using Common.Application;
using MediatR;

namespace PresentationFacade.ProductComment;
public class ProductCommentFacade : IProductCommentFacade
{
    private readonly IMediator _mediator;
    public ProductCommentFacade(IMediator mediator)
    {
        _mediator = mediator;
    }

    public async Task<OperationResult> Create(CreateCommentCommand command)
    {
        return await _mediator.Send(command);
    }

    public async Task<OperationResult> Delete(long commentId)
    {
        return await _mediator.Send(new DeleteCommentCommand(commentId));
    }
}