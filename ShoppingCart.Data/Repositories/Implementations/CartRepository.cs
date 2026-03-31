using Microsoft.EntityFrameworkCore;
using ShoppingCart.Data.Entities;
using ShoppingCart.Data.Enums;
using ShoppingCart.Data.Repositories.Interfaces;

namespace ShoppingCart.Data.Repositories.Implementations;

public class CartRepository(AppDbContext _dbContext) : ICartRepository
{
    public async Task<Cart?> GetByIdAsync(Guid cartId, CancellationToken ct = default)
    {
        return await _dbContext.Carts
            .FirstOrDefaultAsync(x => x.Id == cartId, ct);
    }

    public async Task<Cart?> GetByIdWithItemsAsync(Guid cartId, CancellationToken ct = default)
    {
        return await _dbContext.Carts
            .Include(x => x.CartItems)
            .FirstOrDefaultAsync(x => x.Id == cartId, ct);
    }

    public async Task<Cart?> GetActiveCartByUserIdAsync(Guid userId, CancellationToken ct = default)
    {
        return await _dbContext.Carts
            .FirstOrDefaultAsync(x => x.UserId == userId && x.Status == CartStatusEnum.Active, ct);
    }

    public async Task<Cart?> GetActiveCartByUserIdWithItemsAsync(Guid userId, CancellationToken ct = default)
    {
        return await _dbContext.Carts
            .Include(x => x.CartItems)
            .FirstOrDefaultAsync(x => x.UserId == userId && x.Status == CartStatusEnum.Active, ct);
    }

    public async Task AddAsync(Cart cart, CancellationToken ct = default)
    {
        await _dbContext.Carts.AddAsync(cart, ct);
    }

    public void Delete(Cart cart)
    {
        _dbContext.Carts.Remove(cart);
    }

    public async Task SaveChangesAsync(CancellationToken ct = default)
    {
        await _dbContext.SaveChangesAsync(ct);
    }
}
