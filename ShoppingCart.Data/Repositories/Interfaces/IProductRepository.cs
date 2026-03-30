using ShoppingCart.Data.Entities;

namespace ShoppingCart.Data.Repositories.Interfaces;

public interface IProductRepository
{
    IQueryable<Product> Query();
    Task<IReadOnlyList<Product>> GetAllAsync(CancellationToken ct = default);
    Task<Product?> GetByIdAsync(Guid productId, CancellationToken ct = default);
}
