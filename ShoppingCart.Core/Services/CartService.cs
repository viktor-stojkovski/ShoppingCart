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
    public async Task<Cart> GetOrCreateActiveCartAsync(Guid userId, string currency, CancellationToken ct = default)
    {
        var cart = await _cartRepository.GetActiveCartByUserIdWithItemsAsync(userId, ct);

        if (cart != null)
        {
            return cart;
        }

        cart = new Cart
        {
            Id = Guid.NewGuid(),
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

    public async Task AddItemAsync(AddCartItemModel model, CancellationToken ct = default)
    {
        if (model.Quantity <= 0)
        {
            throw new InvalidOperationException("Quantity must be greater than zero.");
        }

        await using var transaction = await _dbContext.Database.BeginTransactionAsync(ct);

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
                Id = Guid.NewGuid(),
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

        var products = await _productRepository.Query()
            .Where(p => productIds.Contains(p.Id))
            .ToListAsync(ct);

        var cartDto  = cart.ToDtoModel(products);

        return cartDto;
    }
}
