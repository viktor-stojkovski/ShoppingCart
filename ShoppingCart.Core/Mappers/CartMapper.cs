using ShoppingCart.Core.Constants;
using ShoppingCart.Core.Dtos;
using ShoppingCart.Data.Entities;

namespace ShoppingCart.Core.Mappers;

public static class CartMapper
{
    public static CartDto ToDtoModel(this Cart cart, IReadOnlyList<Product> products)
    {
        return new CartDto
        {
            Id = cart.Id,
            UserId = cart.UserId,
            Currency = cart.Currency,
            CreatedOnUtc = cart.CreatedOnUtc,
            UpdatedOnUtc = cart.UpdatedOnUtc,
            Status = cart.Status,
            CartItems = cart.CartItems.ToDtoModels(products),
            TotalAmount = cart.CartItems.Sum(x => x.PriceWhenAdded * x.Quantity)
        };
    }

    public static CartDto EmptyCartDto(Guid userID)
    {
        return new CartDto
        {
            Id = Guid.Empty,
            UserId = userID,
            Currency = CurrencyConstants.DefaultCurrency,
            Status = Data.Enums.CartStatusEnum.Active,
            CartItems = [],
            TotalAmount = 0m
        };
    }
}
