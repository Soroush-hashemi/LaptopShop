using Common.Application;
using Common.Domain.Exceptions;
using Domain.Users.Repository;

namespace Application.Users.Delete;
public class DeleteUserCommandHandler : IBaseCommandHandler<DeleteUserCommand>
{
    private readonly IUserRepository _repository;
    public DeleteUserCommandHandler(IUserRepository userRepository)
    {
        _repository = userRepository;
    }

    public async Task<OperationResult> Handle(DeleteUserCommand request, CancellationToken cancellationToken)
    {
        try
        {
            var user = await _repository.GetTracking(request.UserId);
            if (user == null)
                return OperationResult.NotFound();

            _repository.DeleteUser(user);
            await _repository.Save();
            return OperationResult.Success();
        }
        catch (NullOrEmptyException ex)
        {
            return OperationResult.Error(ex.Message);
        }
    }
}