namespace Acme.Shop.Orders;

public class Order
{
    public int Id { get; set; }
    public int CustomerId { get; set; }
    public string Status { get; set; } = "new";
    public decimal Total { get; set; }
    public List<OrderLine> Lines { get; set; } = new();
}
