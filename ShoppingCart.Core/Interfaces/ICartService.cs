using ShoppingCart.Core.Dtos;
using ShoppingCart.Core.Models;
using ShoppingCart.Data.Entities;

namespace ShoppingCart.Core.Interfaces;

public interface ICartService
{
    Task<Cart> GetOrCreateActiveCartAsync(Guid userId, string currency, CancellationToken ct = default);
    Task AddCartItemAsync(AddCartItemModel model, CancellationToken ct = default);
    Task<CartDto> GetActiveCartAsync(Guid userId, CancellationToken ct = default);
    Task UpdateCartItemQuantityAsync(UpdateCartItemQuantityModel model, CancellationToken ct = default);
    Task RemoveCartItemAsync(RemoveCartItemModel model, CancellationToken ct = default);
    Task CheckoutCartAsync(CheckoutCartModel model, CancellationToken ct = default);
}
