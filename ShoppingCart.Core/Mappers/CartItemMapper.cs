using ShoppingCart.Core.Dtos;
using ShoppingCart.Data.Entities;

namespace ShoppingCart.Core.Mappers;

public static class CartItemMapper
{
    public static IList<CartItemDto> ToDtoModels(this IEnumerable<CartItem> cartItems, IReadOnlyList<Product> products)
    {
        var productsDictionary = products.ToDictionary(x => x.Id);

        return cartItems.Select(x =>
        {
            var product = productsDictionary[x.ProductId];
            return x.ToDtoModel(product.Name);
        }).ToList();
    }

    public static CartItemDto ToDtoModel(this CartItem cartItem, string productName)
    {
        return new CartItemDto
        {
            CartItemId = cartItem.Id,
            ProductId = cartItem.ProductId,
            ProductName = productName,
            Quantity = cartItem.Quantity,
            PriceWhenAdded = cartItem.PriceWhenAdded,
            TotalPrice = cartItem.PriceWhenAdded * cartItem.Quantity
        };
    }
}
