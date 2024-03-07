using Common.Application;

namespace Application.Users.Delete;
public record DeleteUserCommand(long UserId) : IBaseCommand;