using Acme.Shop.Catalog;
using Acme.Shop.Customers;
using Acme.Shop.Inventory;
using Acme.Shop.Orders;
using Acme.Shop.Payments;
using Microsoft.EntityFrameworkCore;

namespace Acme.Shop.Data;

public class ShopDbContext(DbContextOptions<ShopDbContext> options) : DbContext(options)
{
    public DbSet<Product> Products => Set<Product>();
    public DbSet<Category> Categories => Set<Category>();
    public DbSet<Customer> Customers => Set<Customer>();
    public DbSet<StockItem> StockItems => Set<StockItem>();
    public DbSet<Payment> Payments => Set<Payment>();
    public DbSet<Order> Orders => Set<Order>();
    public DbSet<OrderLine> OrderLines => Set<OrderLine>();
}
