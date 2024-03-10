﻿using Common.Application;
using Common.Domain.ValueObjects;

namespace Domain.Users.Service;
public interface IUserDomainService
{
    public OperationResult IsPhoneNumberExist(PhoneNumber phoneNumber);
}