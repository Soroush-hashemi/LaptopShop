using Common.Application;
using Common.Query;

namespace Query.Users.ChangePassword;
public record ChangePasswordQuery(string UserName, string PhoneNumber, string Password) : IQuery<OperationResult>;