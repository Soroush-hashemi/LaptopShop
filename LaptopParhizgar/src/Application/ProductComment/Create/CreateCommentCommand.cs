using Common.Application;

namespace Application.ProductComment.Create;
public record CreateCommentCommand(long userId, long productId, string text) : IBaseCommand;