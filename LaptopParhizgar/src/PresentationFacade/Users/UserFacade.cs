using Application.Users.Delete;
using Application.Users.Edit;
using Application.Users.Register;
using Common.Application;
using MediatR;
using Query.Users.CheckUser;
using Query.Users.DTOs;
using Query.Users.ChangePassword;
using Query.Users.GetById;
using Query.Users.GetByUserName;
using Query.Users.GetList;

namespace PresentationFacade.Users;
public class UserFacade : IUserFacade
{
    private readonly IMediator _mediator;
    public UserFacade(IMediator mediator)
    {
        _mediator = mediator;
    }

    public async Task<OperationResult> Register(RegisterUserCommand command)
    {
        return await _mediator.Send(command);
    }

    public async Task<OperationResult> Delete(long Id)
    {
        return await _mediator.Send(new DeleteUserCommand(Id));
    }

    public async Task<OperationResult> Edit(EditUserCommand command)
    {
        return await _mediator.Send(command);
    }

    public async Task<UserDto> GetById(long Id)
    {
        return await _mediator.Send(new GetUserByIdQuery(Id));
    }

    public async Task<List<UserDto>> GetList()
    {
        return await _mediator.Send(new GetUserListQuery());
    }

    public async Task<UserDto?> GetUserByUserName(string userName)
    {
        return await _mediator.Send(new GetUserByUserNameQuery(userName));
    }

    public async Task<OperationResult> CheckUser(string UserName, string PhoneNumber)
    {
        return await _mediator.Send(new CheckUserQuery(UserName, PhoneNumber));
    }

    public async Task<OperationResult> ChangePassword(string UserName,string phoneNumber, string Password)
    {
        return await _mediator.Send(new ChangePasswordQuery(UserName, phoneNumber, Password));
    }
}