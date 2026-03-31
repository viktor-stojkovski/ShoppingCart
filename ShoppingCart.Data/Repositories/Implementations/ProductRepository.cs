using Microsoft.EntityFrameworkCore;
using ShoppingCart.Data.Entities;
using ShoppingCart.Data.Repositories.Interfaces;

namespace ShoppingCart.Data.Repositories.Implementations;

public class ProductRepository(AppDbContext _dbContext) : IProductRepository
{
    public IQueryable<Product> QueryNoTracking()
        => _dbContext.Products.AsNoTracking();

    public IQueryable<Product> Query()
        => _dbContext.Products.AsQueryable();

    public async Task<IReadOnlyList<Product>> GetAllAsync(CancellationToken ct = default)
    {
        return await QueryNoTracking()
            .ToListAsync(ct);
    }

    public async Task<Product?> GetByIdAsync(Guid productId, CancellationToken ct = default)
    {
        return await QueryNoTracking()
            .FirstOrDefaultAsync(x => x.Id == productId, ct);
    }
}
