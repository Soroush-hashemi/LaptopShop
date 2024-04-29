using Common.Application.FileUtil.Interfaces;
using Common.Application.FileUtil.Services;
using Domain.Addresses.Repository;
using Domain.Carts.Repository;
using Domain.Category.Repository;
using Domain.Orders.Repository;
using Domain.Payment.Repository;
using Domain.Products.Repository;
using Domain.Sliders.Repository;
using Domain.Users.Repository;
using Infrastructure.Persistence;
using Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure;
public class InfrastructureBootstrapper
{
    public static void Init(IServiceCollection services, string connectionString)
    {
        services.AddScoped<ICategoryRepository, CategoryRepository>();
        services.AddScoped<IOrderRepository, OrderRepository>();
        services.AddScoped<IAddressRepository, AddressRepository>();
        services.AddScoped<ICartsRepository, CartsRepository>();
        services.AddScoped<ICartItemRepository, CartItemRepository>();
        services.AddScoped<IPaymentSettingsRepository, PaymentSettingsRepository>();
        services.AddScoped<IProductRepository, ProductRepository>();
        services.AddScoped<IProductCommentRepository, ProductCommentRepository>();
        services.AddScoped<IOrderDetailRepository, OrderDetailRepository>();
        services.AddScoped<ISliderPostersRepository, SliderPostersRepository>();
        services.AddScoped<ISliderRepository, SliderRepository>();
        services.AddScoped<IUserRepository, UserRepository>();
        services.AddScoped<IFileService, FileService>();

        services.AddDbContext<LaptopParhizgerContext>(options =>
        {
            options.UseSqlServer(connectionString,
                sqlServerOptions => sqlServerOptions.EnableRetryOnFailure());
        });
    }
}