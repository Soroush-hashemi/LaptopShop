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
using PresentationFacade.Addresses;
using PresentationFacade.Cart;
using PresentationFacade.Cart.Service;
using PresentationFacade.Categories;
using PresentationFacade.Order;
using PresentationFacade.Order.Service;
using PresentationFacade.PaymentSetting;
using PresentationFacade.PaymentSetting.Service;
using PresentationFacade.ProductComment;
using PresentationFacade.ProductComment.Service;
using PresentationFacade.Products;
using PresentationFacade.Products.Serivce;
using PresentationFacade.RequestPayment.Service;
using PresentationFacade.SliderPosters;
using PresentationFacade.Sliders;
using PresentationFacade.Users;
using Query.Addresses.GetById;

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
        services.AddMediatR(typeof(GetAdderssByIdQuery).Assembly);
        services.AddMediatR(typeof(GetAdderssByIdQueryHandler).Assembly);

        services.AddTransient<IProductDomainService, ProductDomainService>();
        services.AddTransient<IUserDomainService, UserDomainService>();
        services.AddTransient<ICategoryDomainService, CategoryDomainService>();
        services.AddTransient<ICartItemDomainService, CartItemDomainService>();

        services.AddTransient<IAddressFacade, AddressFacade>();
        services.AddTransient<ICartFacade, CartFacade>();
        services.AddTransient<ICategoryFacade, CategoryFacade>();
        services.AddTransient<IOrderFacade, OrderFacade>();
        services.AddTransient<IProductCommentFacade, ProductCommentFacade>();
        services.AddTransient<IProductsFacade, ProductsFacade>();
        services.AddTransient<ISliderPostersFacade, SliderPostersFacade>();
        services.AddTransient<ISliderFacade, SliderFacade>();
        services.AddTransient<IUserFacade, UserFacade>();

        services.AddTransient<ICartService, CartService>();
        services.AddTransient<IOrderService, OrderService>();
        services.AddTransient<IRequestPaymentService, RequestPaymentService>();
        services.AddTransient<IPaymentSettingService, PaymentSettingService>();
        services.AddTransient<ICommentService, CommentService>();
        services.AddTransient<IProductSerivce, ProductSerivce>();
    }
}