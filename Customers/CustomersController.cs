using Microsoft.AspNetCore.Mvc;

namespace Acme.Shop.Customers;

[ApiController]
[Route("customers")]
public class CustomersController(CustomerService customers) : ControllerBase
{
    [HttpGet("{id:int}")]
    public async Task<IActionResult> Get(int id)
    {
        var c = await customers.Get(id);
        return c is null ? NotFound() : Ok(c);
    }
}
