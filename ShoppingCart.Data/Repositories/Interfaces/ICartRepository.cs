using ShoppingCart.Data.Entities;

namespace ShoppingCart.Data.Repositories.Interfaces;

public interface ICartRepository
{
    Task<Cart?> GetByIdAsync(Guid cartId, CancellationToken ct = default);
    Task<Cart?> GetByIdWithItemsAsync(Guid cartId, CancellationToken ct = default);
    Task<Cart?> GetActiveCartByUserIdAsync(Guid userId, CancellationToken ct = default);
    Task AddAsync(Cart cart, CancellationToken ct = default);
    void Delete(Cart cart);
    Task SaveChangesAsync(CancellationToken ct = default);
}
