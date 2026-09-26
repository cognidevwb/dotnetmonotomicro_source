namespace Acme.Shop.Customers;

public class Customer
{
    public int Id { get; set; }
    public string Email { get; set; } = "";
    public bool Active { get; set; } = true;
}
