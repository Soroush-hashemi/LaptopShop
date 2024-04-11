using Common.Application;
using Common.Domain.ValueObjects;
using Domain.Users.Repository;
using Domain.Users.Service;

namespace Application.Users;
public class UserDomainService : IUserDomainService
{
    private readonly IUserRepository _repository;
    public UserDomainService(IUserRepository repository)
    {
        _repository = repository;
    }

    public OperationResult IsEmailExist(string Email)
    {
        var Exists = _repository.Exists(s => s.Email == Email);
        if (Exists == false)
            return OperationResult.Success();

        return OperationResult.Error("ایمیل تکراری است");
    }

    public OperationResult IsPhoneNumberExist(PhoneNumber phoneNumber)
    {
        var Exists = _repository.Exists(s => s.PhoneNumber.Value == phoneNumber.Value); //  اگر در سیستم وجود نداشت 0 رو برگشت میده
        if (Exists == false)
            return OperationResult.Success();

        return OperationResult.Error("تلفن تکراری است");
    }

    public OperationResult IsUserNameExist(string UserName)
    {
        var Exists = _repository.Exists(s => s.UserName == UserName);
        if (Exists == false)
            return OperationResult.Success();

        return OperationResult.Error("نام کاربری تکراری است");
    }
}