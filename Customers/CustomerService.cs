using Acme.Shop.Data;
using Microsoft.EntityFrameworkCore;

namespace Acme.Shop.Customers;

public class CustomerService(ShopDbContext db)
{
    public async Task<Customer?> Get(int id) =>
        await db.Customers.FirstOrDefaultAsync(c => c.Id == id);

    public async Task<bool> IsActive(int id) => (await Get(id))?.Active ?? false;
}
