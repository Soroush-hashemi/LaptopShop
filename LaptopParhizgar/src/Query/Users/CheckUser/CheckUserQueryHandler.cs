using Common.Application;
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
        try
        {
            if (request.UserName == null)
                return OperationResult.Error("نام کاربری نمیتواند خالی باشد");
            if (request.PhoneNumber == null)
                return OperationResult.Error("تلفن نمیتواند خالی باشد");

            var UserNameIsExist = await _context.Users.AnyAsync(p => p.UserName == request.UserName);
            if (UserNameIsExist == false)
                return OperationResult.Error("این کاربر وجود ندارد");

            var user = await _context.Users.FirstOrDefaultAsync(p => p.UserName == request.UserName);
            if (user == null)
                return OperationResult.Error("این کاربر وجود ندارد");

            var isPhoneNumberNotExist = await _context.Users.AnyAsync(p => user.PhoneNumber.Value == request.PhoneNumber);
            if (isPhoneNumberNotExist == false)
                return OperationResult.Error("این کاربر وجود ندارد");

            return OperationResult.Success();

        }
        catch (NullReferenceException ex)
        {
            return OperationResult.Error(ex.Message);
        }
    }
}