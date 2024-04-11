using Common.Application;
using Common.Query;
using Query.Users.DTOs;

namespace Query.Users.CheckUser;
public record CheckUserQuery(string UserName, string PhoneNumber) : IQuery<OperationResult>;