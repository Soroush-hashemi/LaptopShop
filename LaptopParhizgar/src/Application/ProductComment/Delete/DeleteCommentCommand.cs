using Common.Application;

namespace Application.ProductComment.Delete;
public record DeleteCommentCommand(long CommentId, long UserId) : IBaseCommand;