using Common.Application;
using Domain.Products.Repository;

namespace Application.ProductComment.Delete;
public class DeleteCommentCommandHandler : IBaseCommandHandler<DeleteCommentCommand>
{
    private readonly IProductCommentRepository _repository;
    public DeleteCommentCommandHandler(IProductCommentRepository repository)
    {
        _repository = repository;
    }

    public async Task<OperationResult> Handle(DeleteCommentCommand request, CancellationToken cancellationToken)
    {
        var comment = await _repository.GetTracking(request.CommentId);
        if (comment == null)
            return OperationResult.Error();

        _repository.DeleteProductComment(comment);
        await _repository.Save();
        return OperationResult.Success();
    }
}