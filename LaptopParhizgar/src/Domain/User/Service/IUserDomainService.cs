using Common.Application;
using Common.Domain.ValueObjects;

namespace Domain.User.Service;
public interface IUserDomainService
{
    public OperationResult IsPhoneNumberExist(PhoneNumber phoneNumber);
}