using Common.Application;
using Common.Domain.Exceptions;
using Domain.Products.Repository;

namespace Application.ProductComment.Edit;
public class EditCommentCommandHandler : IBaseCommandHandler<EditCommentCommand>
{
    private readonly IProductCommentRepository _repository;
    public EditCommentCommandHandler(IProductCommentRepository repository)
    {
        _repository = repository;
    }

    public async Task<OperationResult> Handle(EditCommentCommand request, CancellationToken cancellationToken)
    {
        try
        {
            var comment = await _repository.GetTracking(request.CommentId);
            if (comment == null)
                return OperationResult.NotFound();

            comment.Edit(request.text);
            await _repository.Save();
            return OperationResult.Success();
        }
        catch (NullOrEmptyException ex)
        {
            return OperationResult.Error(ex.Message);
        }
    }
}