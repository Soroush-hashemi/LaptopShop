using Common.Application;
using Common.Application.SecurityUtil;
using Common.Domain.Exceptions;
using Domain.User;
using Domain.User.Repository;
using Domain.User.Service;

namespace Application.Users.Register;
public class RegisterUserCommandHandler : IBaseCommandHandler<RegisterUserCommand>
{
    private readonly IUserRepository _userRepository;
    private readonly IUserDomainService _userDomainService;
    public RegisterUserCommandHandler(IUserRepository userRepository, IUserDomainService userDomainService)
    {
        _userRepository = userRepository;
        _userDomainService = userDomainService;
    }

    public async Task<OperationResult> Handle(RegisterUserCommand request, CancellationToken cancellationToken)
    {
        try
        {
            var password = Sha256Hasher.Hash(request.Password);
            var user = new User(request.UserName, request.FullName, request.PhoneNumber, request.Email, password, _userDomainService);

            _userRepository.Add(user);
            await _userRepository.Save();
            return OperationResult.Success();
        }
        catch(NullOrEmptyException ex)
        {
            return OperationResult.Error(ex.Message);
        }
    }
}
