using Acme.Shop.Data;
using Microsoft.EntityFrameworkCore;

namespace Acme.Shop.Inventory;

public class InventoryService(ShopDbContext db)
{
    public async Task<bool> Reserve(int productId, int qty)
    {
        var item = await db.StockItems.FirstOrDefaultAsync(s => s.ProductId == productId);
        if (item is null || item.Quantity < qty) return false;
        item.Quantity -= qty;               // NOTE: read-check-then-write — the oversell seam
        return true;
    }
}
