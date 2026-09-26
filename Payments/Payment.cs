namespace Acme.Shop.Payments;

public class Payment
{
    public int Id { get; set; }
    public int OrderId { get; set; }
    public decimal Amount { get; set; }
    public string Status { get; set; } = "pending";   // NOTE: string status — enum seam
}
