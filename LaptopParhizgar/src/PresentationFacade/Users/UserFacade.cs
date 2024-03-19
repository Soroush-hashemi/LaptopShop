using Application.Users.Delete;
using Application.Users.Edit;
using Application.Users.Register;
using Common.Application;
using MediatR;
using Query.Users.DTOs;
using Query.Users.GetById;
using Query.Users.GetByPhoneNumber;
using Query.Users.GetList;

namespace PresentationFacade.Users;
public class UserFacade : IUserFacade
{
    private readonly IMediator _mediator;
    public UserFacade(IMediator mediator)
    {
        _mediator = mediator;
    }

    public Task<OperationResult> Register(RegisterUserCommand command)
    {
        return _mediator.Send(command);
    }

    public Task<OperationResult> Delete(long Id)
    {
        return _mediator.Send(new DeleteUserCommand(Id));
    }

    public Task<OperationResult> EditUser(EditUserCommand command)
    {
        return _mediator.Send(command);
    }

    public Task<UserDto> GetById(long Id)
    {
        return _mediator.Send(new GetUserByIdQuery(Id));
    }

    public Task<List<UserDto>> GetList()
    {
        return _mediator.Send(new GetUserListQuery());
    }

    public Task<UserDto> GetPhoneNumberById(string phoneNumber)
    {
        return _mediator.Send(new GetUserByPhoneNumberQuery(phoneNumber));
    }
}