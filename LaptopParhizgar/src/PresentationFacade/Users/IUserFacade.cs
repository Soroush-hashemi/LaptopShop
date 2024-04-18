using Application.Users.Edit;
using Application.Users.Register;
using Common.Application;
using Query.Users.DTOs;

namespace PresentationFacade.Users;
public interface IUserFacade
{
    Task<OperationResult> Delete(long Id);
    Task<OperationResult> Register(RegisterUserCommand command);
    Task<OperationResult> Edit(EditUserCommand command);

    Task<UserDto> GetById(long Id);
    Task<UserDto?> GetUserByUserName(string userName);
    Task<List<UserDto>> GetList();
    Task<OperationResult> CheckUser(string UserName, string PhoneNumber);
    Task<OperationResult> ChangePassword(string UserName, string phoneNumber, string Password);
}