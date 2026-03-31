using ShoppingCart.Core.Dtos;
using ShoppingCart.Core.Models;
using ShoppingCart.Data.Entities;

namespace ShoppingCart.Core.Interfaces;

public interface ICartService
{
    Task<Cart> GetOrCreateActiveCartAsync(Guid userId, string currency, CancellationToken ct = default);
    Task AddItemAsync(AddCartItemModel model, CancellationToken ct = default);
    Task<CartDto> GetActiveCartAsync(Guid userId, CancellationToken ct = default);
}
