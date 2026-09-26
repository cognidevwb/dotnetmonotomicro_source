using Acme.Shop.Catalog;
using Acme.Shop.Customers;
using Acme.Shop.Data;
using Acme.Shop.Inventory;
using Acme.Shop.Payments;

namespace Acme.Shop.Orders;

// The cross-domain transaction: one SaveChanges spans Orders + Inventory + Payments,
// and reaches Catalog + Customers for reads. This is the CreateOrder saga seam.
public class OrderService(
    ShopDbContext db,
    CatalogService catalog,
    CustomerService customers,
    InventoryService inventory,
    PaymentService payments)
{
    public async Task<Order> PlaceOrder(int customerId, IEnumerable<(int productId, int qty)> items)
    {
        if (!await customers.IsActive(customerId))
            throw new InvalidOperationException("customer inactive");

        var order = new Order { CustomerId = customerId, Status = "pending" };
        decimal total = 0;
        foreach (var (productId, qty) in items)
        {
            if (!await inventory.Reserve(productId, qty))
                throw new InvalidOperationException("out of stock");
            var price = await catalog.PriceOf(productId);
            order.Lines.Add(new OrderLine { ProductId = productId, Quantity = qty, UnitPrice = price });
            total += price * qty;
        }
        order.Total = total;
        payments.Charge(order.Id, total);
        order.Status = "placed";
        db.Orders.Add(order);
        await db.SaveChangesAsync();          // one unit of work across 3 contexts
        return order;
    }
}
