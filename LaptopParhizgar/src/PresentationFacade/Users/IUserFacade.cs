using Application.Users.Edit;
using Application.Users.Register;
using Common.Application;
using Query.Users.DTOs;

namespace PresentationFacade.Users;
public interface IUserFacade
{
    Task<OperationResult> Delete(long Id);
    Task<OperationResult> Register(RegisterUserCommand command);
    Task<OperationResult> EditUser(EditUserCommand command);


    Task<UserDto> GetById(long Id);
    Task<UserDto> GetPhoneNumberById(string phoneNumber);
    Task<List<UserDto>> GetList();
}