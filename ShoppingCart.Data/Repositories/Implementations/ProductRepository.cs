using Microsoft.EntityFrameworkCore;
using ShoppingCart.Data.Entities;
using ShoppingCart.Data.Repositories.Interfaces;

namespace ShoppingCart.Data.Repositories.Implementations;

public class ProductRepository(AppDbContext _dbContext) : IProductRepository
{
    public IQueryable<Product> Query()
        => _dbContext.Products.AsNoTracking();

    public async Task<IReadOnlyList<Product>> GetAllAsync(CancellationToken ct = default)
    {
        return await Query()
            .ToListAsync(ct);
    }

    public async Task<Product?> GetByIdAsync(Guid productId, CancellationToken ct = default)
    {
        return await Query()
            .FirstOrDefaultAsync(x => x.Id == productId, ct);
    }
}
