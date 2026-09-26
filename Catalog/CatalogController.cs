using Microsoft.AspNetCore.Mvc;

namespace Acme.Shop.Catalog;

[ApiController]
[Route("catalog")]
public class CatalogController(CatalogService catalog) : ControllerBase
{
    [HttpGet("products/{id:int}")]
    public async Task<IActionResult> Get(int id)
    {
        var p = await catalog.GetProduct(id);
        return p is null ? NotFound() : Ok(p);
    }
}
