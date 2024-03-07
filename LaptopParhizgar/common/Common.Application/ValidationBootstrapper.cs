using Common.Application.Validation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace Common.Application;
public class ValidationBootstrapper
{
    public static void Init(IServiceCollection service)
    {
        service.AddTransient(typeof(IPipelineBehavior<,>), typeof(CommandValidationBehavior<,>));
    }
}