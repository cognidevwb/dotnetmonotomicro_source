using Acme.Shop.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<ShopDbContext>(o => o.UseInMemoryDatabase("shop"));
builder.Services.AddScoped<Acme.Shop.Catalog.CatalogService>();
builder.Services.AddScoped<Acme.Shop.Customers.CustomerService>();
builder.Services.AddScoped<Acme.Shop.Inventory.InventoryService>();
builder.Services.AddScoped<Acme.Shop.Payments.PaymentService>();
builder.Services.AddScoped<Acme.Shop.Orders.OrderService>();
builder.Services.AddControllers();

var app = builder.Build();
app.MapControllers();
app.Run();
