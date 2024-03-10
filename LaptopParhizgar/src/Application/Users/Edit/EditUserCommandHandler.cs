using Common.Application;
using Common.Domain.Exceptions;
using Domain.Users.Repository;
using Domain.Users.Service;

namespace Application.Users.Edit;
public class EditUserCommandHandler : IBaseCommandHandler<EditUserCommand>
{
    private readonly IUserRepository _userRepository;
    private readonly IUserDomainService _domainService;
    public EditUserCommandHandler(IUserDomainService domainService, IUserRepository userRepository)
    {
        _domainService = domainService;
        _userRepository = userRepository;
    }

    public async Task<OperationResult> Handle(EditUserCommand request, CancellationToken cancellationToken)
    {
        try
        {
            var user = await _userRepository.GetTracking(request.UserId);
            if (user == null)
                return OperationResult.NotFound();

            user.Edit(request.UserName, request.FullName, request.PhoneNumber, request.Email, _domainService);

            await _userRepository.Save();
            return OperationResult.Success();
        }
        catch (NullOrEmptyException ex)
        {
            return OperationResult.Error(ex.Message);
        }
    }
}