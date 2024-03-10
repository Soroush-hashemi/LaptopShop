using Common.Application;

namespace Application.ProductComment.Edit;
public record EditCommentCommand(long CommentId, string text) : IBaseCommand;