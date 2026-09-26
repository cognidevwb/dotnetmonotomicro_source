using Acme.Shop.Data;
using Microsoft.EntityFrameworkCore;

namespace Acme.Shop.Catalog;

public class CatalogService(ShopDbContext db)
{
    public async Task<Product?> GetProduct(int id) =>
        await db.Products.FirstOrDefaultAsync(p => p.Id == id);

    public async Task<decimal> PriceOf(int productId) =>
        (await GetProduct(productId))?.Price ?? 0m;
}
