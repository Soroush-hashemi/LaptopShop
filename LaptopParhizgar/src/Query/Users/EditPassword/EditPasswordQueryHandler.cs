using Common.Application;
using Common.Application.SecurityUtil;
using Common.Query;
using Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace Query.Users.EditPassword;
public class EditPasswordQueryHandler : IQueryHandler<EditPasswordQuery, OperationResult>
{
    private readonly LaptopParhizgerContext _context;
    public EditPasswordQueryHandler(LaptopParhizgerContext context)
    {
        _context = context;
    }

    public async Task<OperationResult> Handle(EditPasswordQuery request, CancellationToken cancellationToken)
    {
        if (request.UserName == null)
            return OperationResult.Error("نام کاربری نمیتواند خالی باشد");
        if (request.Password == null)
            return OperationResult.Error("رمزعبور نمیتواند خالی باشد");

        var User = await _context.Users.Where(p => p.UserName == request.UserName).FirstOrDefaultAsync();

        var passwordHash = Sha256Hasher.Hash(request.Password);

        User.SetPassword(passwordHash);

        _context.SaveChanges();
        return OperationResult.Success();
    }
}