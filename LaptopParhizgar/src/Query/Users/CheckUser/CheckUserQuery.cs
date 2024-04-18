using Common.Application;
using Common.Query;

namespace Query.Users.CheckUser;
public record CheckUserQuery(string UserName, string PhoneNumber) : IQuery<OperationResult>;