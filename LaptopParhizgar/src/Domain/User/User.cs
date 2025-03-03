﻿using Common.Domain.Bases;
using Common.Domain.Exceptions;
using Common.Domain.Tools;
using Common.Domain.ValueObjects;
using Domain.Users.Service;

namespace Domain.Users;
public class User : BaseEntity
{
    public string UserName { get; private set; }
    public string FullName { get; private set; }
    public PhoneNumber PhoneNumber { get; private set; }
    public string Email { get; private set; }
    public string Password { get; private set; }
    public UserRole Roles { get; private set; }

    private User()
    {

    }

    public User(string userName, string fullName, PhoneNumber phoneNumber, string email,
    string password, IUserDomainService userDomainService)
    {
        Guard(phoneNumber, email, userName, userDomainService);
        UserName = userName;
        FullName = fullName;
        PhoneNumber = phoneNumber;
        Email = email;
        Password = password;
        Roles = UserRole.user;
    }

    public void Edit(string fullName)
    {
        FullName = fullName;
    }

    public void ChangePassword(string password)
    {
        Password = password;
    }

    public void Guard(PhoneNumber phoneNumber, string email, string userName, IUserDomainService userDomainService)
    {
        if (phoneNumber.Value.Length > 13)
            throw new NullOrEmptyException("تلفن نامعتبر است");

        if (phoneNumber.Value.Length < 9)
            throw new NullOrEmptyException("تلفن نامعتبر است");

        var IsPhoneNumberExist = userDomainService.IsPhoneNumberExist(phoneNumber);
        if (IsPhoneNumberExist.Status != Common.Application.OperationResultStatus.Success)
            throw new NullOrEmptyException(IsPhoneNumberExist.Message);

        var IsEmailExist = userDomainService.IsEmailExist(email);
        if (IsEmailExist.Status != Common.Application.OperationResultStatus.Success)
            throw new NullOrEmptyException(IsEmailExist.Message);

        var IsUserNameExist = userDomainService.IsUserNameExist(userName);
        if (IsUserNameExist.Status != Common.Application.OperationResultStatus.Success)
            throw new NullOrEmptyException(IsUserNameExist.Message);

        if (!string.IsNullOrWhiteSpace(email))
            if (email.IsValidEmail() == false)
                throw new NullOrEmptyException("ایمیل نامعتبر است");
    }
}

public enum UserRole
{
    admin,
    user
}