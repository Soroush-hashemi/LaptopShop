using Common.Domain.Bases;
using Domain.Addresses;
using Domain.Carts;
using Domain.Category;
using Domain.Orders;
using Domain.Payment;
using Domain.Products;
using Domain.Sliders;
using Domain.Users;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistence;
public class LaptopParhizgerContext : DbContext
{
    public LaptopParhizgerContext(DbContextOptions<LaptopParhizgerContext> options) : base(options)
    {

    }

    public DbSet<Category> Categories { get; set; }
    public DbSet<Product> Products { get; set; }
    public DbSet<ProductComment> ProductComments { get; set; }
    public DbSet<User> Users { get; set; }
    public DbSet<Address> Addresses { get; set; }
    public DbSet<Cart> Carts { get; set; }
    public DbSet<CartItem> CartItem { get; set; }
    public DbSet<Order> Orders { get; set; }
    public DbSet<OrderDetail> OrderDetails { get; set; }
    public DbSet<Slider> Slider { get; set; }
    public DbSet<SliderPosters> SliderPosters { get; set; }
    public DbSet<RequestPay> RequestPay { get; set; }
    public DbSet<PaymentSettings> PaymentSettings { get; set; }

    private List<BaseEntity> GetModifiedEntities() =>
    ChangeTracker.Entries<BaseEntity>()
        .Where(x => x.State != EntityState.Detached)
        .Select(c => c.Entity)
        .Where(c => c.DomainEvents.Any()).ToList();

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
        base.OnConfiguring(optionsBuilder);
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(LaptopParhizgerContext).Assembly);
        base.OnModelCreating(modelBuilder);
    }
}