using Acme.Shop.Data;

namespace Acme.Shop.Payments;

public class PaymentService(ShopDbContext db)
{
    public Payment Charge(int orderId, decimal amount)
    {
        var p = new Payment { OrderId = orderId, Amount = amount, Status = "charged" };
        db.Payments.Add(p);
        return p;
    }
}
