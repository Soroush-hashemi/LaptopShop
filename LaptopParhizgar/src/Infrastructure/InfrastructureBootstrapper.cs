using Common.Application.FileUtil.Interfaces;
using Common.Application.FileUtil.Services;
using Domain.Address.Repository;
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
        services.AddTransient<ICategoryRepository, CategoryRepository>();
        services.AddTransient<IOrderRepository, OrderRepository>();
        services.AddTransient<IAddressRepository, AddressRepository>();
        services.AddTransient<ICartsRepository, CartsRepository>();
        services.AddTransient<ICartItemRepository, CartItemRepository>();
        services.AddTransient<IPaymentSettingsRepository, PaymentSettingsRepository>();
        services.AddTransient<IProductRepository, ProductRepository>();
        services.AddTransient<IProductCommentRepository, ProductCommentRepository>();
        services.AddTransient<IOrderDetailRepository, OrderDetailRepository>();
        services.AddTransient<ISliderPostersRepository, SliderPostersRepository>();
        services.AddTransient<ISliderRepository, SliderRepository>();
        services.AddTransient<IUserRepository, UserRepository>();
        services.AddTransient<IFileService, FileService>();

        services.AddDbContext<LaptopParhizgerContext>(options =>
        {
            options.UseSqlServer((connectionString),
                sqlServerOptions => sqlServerOptions.EnableRetryOnFailure());
        });
    }
}