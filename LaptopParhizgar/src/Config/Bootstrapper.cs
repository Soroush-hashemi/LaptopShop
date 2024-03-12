using Application.Carts;
using Application.Categories;
using Application.Categories.Create;
using Application.Products;
using Application.Users;
using Common.Application.FileUtil;
using Domain.Carts.Service;
using Domain.Category.Service;
using Domain.Products.Service;
using Domain.Users.Service;
using Infrastructure;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace Config;
public static class Bootstrapper
{
    public static void ConfigBootstrapper(this IServiceCollection services, string connectionString)
    {
        InfrastructureBootstrapper.Init(services, connectionString);

        services.AddMediatR(typeof(Directories).Assembly);
        services.AddMediatR(typeof(CreateCategoryCommand).Assembly);
        services.AddMediatR(typeof(CreateCategoryCommandValidator).Assembly);
        services.AddMediatR(typeof(CreateCategoryCommandHandler).Assembly);

        services.AddTransient<IProductDomainService, ProductDomainService>();
        services.AddTransient<IUserDomainService, UserDomainService>();
        services.AddTransient<ICategoryDomainService, CategoryDomainService>();
        services.AddTransient<ICartItemDomainService, CartItemDomainService>();
    }
}