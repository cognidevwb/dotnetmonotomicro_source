using Microsoft.AspNetCore.Mvc;

namespace Acme.Shop.Orders;

[ApiController]
[Route("orders")]
public class OrdersController(OrderService orders) : ControllerBase
{
    public record PlaceOrderRequest(int CustomerId, List<LineDto> Lines);
    public record LineDto(int ProductId, int Quantity);

    [HttpPost]
    public async Task<IActionResult> Place([FromBody] PlaceOrderRequest req)
    {
        var order = await orders.PlaceOrder(req.CustomerId, req.Lines.Select(l => (l.ProductId, l.Quantity)));
        return Ok(order);
    }
}
