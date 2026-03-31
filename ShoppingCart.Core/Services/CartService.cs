using Microsoft.EntityFrameworkCore;
using ShoppingCart.Core.Dtos;
using ShoppingCart.Core.Interfaces;
using ShoppingCart.Core.Mappers;
using ShoppingCart.Core.Models;
using ShoppingCart.Data;
using ShoppingCart.Data.Entities;
using ShoppingCart.Data.Enums;
using ShoppingCart.Data.Repositories.Interfaces;

namespace ShoppingCart.Core.Services;

public class CartService(AppDbContext _dbContext, ICartRepository _cartRepository, IProductRepository _productRepository) : ICartService
{
    public async Task AddCartItemAsync(AddCartItemModel model, CancellationToken ct = default)
    {
        await using var transaction = await _dbContext.Database.BeginTransactionAsync(ct);

        try
        {
            var cart = await GetOrCreateActiveCartAsync(model.UserId, model.Currency, ct);
            var product = await _productRepository.GetByIdAsync(model.ProductId, ct);

            if (product == null)
            {
                throw new InvalidOperationException("Product not found.");
            }

            if (!product.IsActive)
            {
                throw new InvalidOperationException("Product is not active.");
            }

            var cartItem = cart.CartItems.FirstOrDefault(x => x.ProductId == model.ProductId);

            if (cartItem == null)
            {
                cartItem = new CartItem
                {
                    CartId = cart.Id,
                    ProductId = product.Id,
                    Quantity = model.Quantity,
                    PriceWhenAdded = product.Price
                };

                cart.CartItems.Add(cartItem);
            }
            else
            {
                cartItem.Quantity += model.Quantity;
            }

            if (cartItem.Quantity > product.StockQuantity)
            {
                throw new InvalidOperationException("Insufficient stock.");
            }

            cart.UpdatedOnUtc = DateTime.UtcNow;

            await _cartRepository.SaveChangesAsync(ct);
            await transaction.CommitAsync(ct);
        }
        catch
        {
            await transaction.RollbackAsync(ct);
            throw;
        }
    }

    private async Task<Cart> GetOrCreateActiveCartAsync(Guid userId, string currency, CancellationToken ct = default)
    {
        var cart = await _cartRepository.GetActiveCartByUserIdWithItemsAsync(userId, ct);

        if (cart != null)
        {
            return cart;
        }

        cart = new Cart
        {
            UserId = userId,
            Currency = currency,
            CreatedOnUtc = DateTime.UtcNow,
            UpdatedOnUtc = DateTime.UtcNow,
            Status = CartStatusEnum.Active
        };

        await _cartRepository.AddAsync(cart, ct);
        await _cartRepository.SaveChangesAsync(ct);

        return cart;
    }

    public async Task<CartDto> GetActiveCartAsync(Guid userId, CancellationToken ct = default)
    {
        var cart = await _cartRepository.GetActiveCartByUserIdWithItemsAsync(userId, ct);

        if (cart == null)
        {
            return CartMapper.EmptyCartDto(userId);
        }

        var productIds = cart.CartItems
            .Select(x => x.ProductId)
            .ToList();

        var products = await _productRepository.QueryNoTracking()
            .Where(p => productIds.Contains(p.Id))
            .ToListAsync(ct);

        var cartDto = cart.ToDtoModel(products);

        return cartDto;
    }

    public async Task UpdateCartItemQuantityAsync(UpdateCartItemQuantityModel model, CancellationToken ct = default)
    {
        var cart = await _cartRepository.GetActiveCartByUserIdWithItemsAsync(model.UserId, ct);

        if (cart == null)
        {
            throw new InvalidOperationException("Active cart not found.");
        }

        var cartItem = cart.CartItems.FirstOrDefault(x => x.Id == model.CartItemId);

        if (cartItem == null)
        {
            throw new InvalidOperationException("Cart item not found.");
        }

        if (model.Quantity == 0)
        {
            cart.CartItems.Remove(cartItem);
        }
        else
        {
            var product = await _productRepository.GetByIdAsync(cartItem.ProductId, ct);

            if (product == null || !product.IsActive)
            {
                cart.CartItems.Remove(cartItem);
                cart.UpdatedOnUtc = DateTime.UtcNow;
                await _cartRepository.SaveChangesAsync(ct);

                throw new InvalidOperationException("Product is no longer available and was removed from the cart.");
            }

            if (model.Quantity > product.StockQuantity)
            {
                throw new InvalidOperationException("Insufficient stock.");
            }

            cartItem.Quantity = model.Quantity;
        }

        cart.UpdatedOnUtc = DateTime.UtcNow;

        await _cartRepository.SaveChangesAsync(ct);
    }

    public async Task RemoveCartItemAsync(RemoveCartItemModel model, CancellationToken ct = default)
    {
        var cart = await _cartRepository.GetByIdWithItemsAsync(model.CartId, ct);

        if (cart == null)
        {
            throw new InvalidOperationException("Cart not found.");
        }

        var cartItem = cart.CartItems.FirstOrDefault(x => x.Id == model.CartItemId);

        if (cartItem == null)
        {
            throw new InvalidOperationException("Cart item not found.");
        }

        cart.CartItems.Remove(cartItem);

        if (cart.CartItems.Count == 0)
        {
            _cartRepository.Delete(cart);
        }
        else
        {
            cart.UpdatedOnUtc = DateTime.UtcNow;
        }

        await _cartRepository.SaveChangesAsync(ct);
    }

    public async Task CheckoutCartAsync(CheckoutCartModel model, CancellationToken ct = default)
    {
        var cart = await _cartRepository.GetByIdWithItemsAsync(model.CartId, ct);

        if (cart == null)
        {
            throw new InvalidOperationException("Cart not found.");
        }

        if (cart.UserId != model.UserId)
        {
            throw new InvalidOperationException("Invalid cart.");
        }

        if (cart.Status != CartStatusEnum.Active)
        {
            throw new InvalidOperationException("Cart is not active.");
        }

        if (cart.CartItems.Count == 0)
        {
            throw new InvalidOperationException("Cart is empty.");
        }

        var productIds = cart.CartItems
            .Select(x => x.ProductId)
            .ToList();

        var products = await _productRepository.Query()
            .Where(p => productIds.Contains(p.Id))
            .ToListAsync(ct);

        var productsDictionary = products.ToDictionary(x => x.Id);

        await using var transaction = await _dbContext.Database.BeginTransactionAsync(ct);

        try
        {
            foreach (var item in cart.CartItems)
            {
                if (!productsDictionary.TryGetValue(item.ProductId, out var product))
                {
                    throw new InvalidOperationException("Product not found during checkout.");
                }

                if (!product.IsActive)
                {
                    throw new InvalidOperationException($"Product '{product.Name}' is no longer available.");
                }

                if (item.Quantity > product.StockQuantity)
                {
                    throw new InvalidOperationException($"Insufficient stock for product '{product.Name}'.");
                }

                product.StockQuantity -= item.Quantity;
            }

            cart.Status = CartStatusEnum.CheckedOut;
            cart.UpdatedOnUtc = DateTime.UtcNow;

            await _cartRepository.SaveChangesAsync(ct);
            await transaction.CommitAsync(ct);
        }
        catch
        {
            await transaction.RollbackAsync(ct);
            throw;
        }
    }
}
