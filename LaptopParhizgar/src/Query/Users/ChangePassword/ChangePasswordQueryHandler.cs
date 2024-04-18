using Common.Application;
using Common.Application.SecurityUtil;
using Common.Query;
using Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace Query.Users.ChangePassword;
public class ChangePasswordQueryHandler : IQueryHandler<ChangePasswordQuery, OperationResult>
{
    private readonly LaptopParhizgerContext _context;
    public ChangePasswordQueryHandler(LaptopParhizgerContext context)
    {
        _context = context;
    }

    public async Task<OperationResult> Handle(ChangePasswordQuery request, CancellationToken cancellationToken)
    {
        if (request.UserName == null)
            return OperationResult.Error();
        if (request.PhoneNumber == null)
            return OperationResult.Error();

        if (request.Password == null)
            return OperationResult.Error("رمزعبور نمیتواند خالی باشد");

        var User = await _context.Users.Where(p => p.UserName == request.UserName).FirstOrDefaultAsync();
        if (User == null)
            return OperationResult.Error();

        var passwordHash = Sha256Hasher.Hash(request.Password);

        User.ChangePassword(passwordHash);

        _context.Users.Update(User);
        _context.SaveChanges();
        return OperationResult.Success();
    }
}