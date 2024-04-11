using Common.Application;
using Common.Query;

namespace Query.Users.EditPassword;
public record EditPasswordQuery(string UserName, string Password) : IQuery<OperationResult>;