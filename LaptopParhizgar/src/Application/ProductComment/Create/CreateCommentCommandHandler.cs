using Common.Application;
using Common.Domain.Exceptions;
using Domain.Products.Repository;

namespace Application.ProductComment.Create;
public class CreateCommentCommandHandler : IBaseCommandHandler<CreateCommentCommand>
{
    private readonly IProductCommentRepository _repository;
    public CreateCommentCommandHandler(IProductCommentRepository repository)
    {
        _repository = repository;
    }

    public async Task<OperationResult> Handle(CreateCommentCommand request, CancellationToken cancellationToken)
    {
        try
        {
            var comment = new Domain.Products.ProductComment(request.userId, request.productId, request.text);
            _repository.Add(comment);
            await _repository.Save();
            return OperationResult.Success();
        }
        catch (NullOrEmptyException ex)
        {
            return OperationResult.Error(ex.Message);
        }
    }
}