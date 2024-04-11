using Common.Application;
using Common.Domain.Exceptions;
using Common.Domain.ValueObjects;
using Common.Query;
using Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace Query.Users.CheckUser;
public class CheckUserQueryHandler : IQueryHandler<CheckUserQuery, OperationResult>
{
    private readonly LaptopParhizgerContext _context;
    public CheckUserQueryHandler(LaptopParhizgerContext context)
    {
        _context = context;
    }
    public async Task<OperationResult> Handle(CheckUserQuery request, CancellationToken cancellationToken)
    {
        if (request.UserName == null)
        {
            return OperationResult.Error("نام کاربری نمیتواند خالی باشد");
        }
        if (request.PhoneNumber == null)
        {
            return OperationResult.Error("تلفن نمیتواند خالی باشد");

        }

        var UserNameIsExist = _context.Users.Any(p => p.UserName == request.UserName);
        if (UserNameIsExist == false)
            return OperationResult.Error("این کاربر وجود ندارد");

        var UserPhone = await _context.Users.FirstOrDefaultAsync(p => p.UserName == request.PhoneNumber);

        var isPhoneNumberNotExist = _context.Users.Any(p => UserPhone.PhoneNumber.Value == request.PhoneNumber);
        if (isPhoneNumberNotExist == false)
            return OperationResult.Error("این کاربر وجود ندارد");

        return OperationResult.Success();
    }
}