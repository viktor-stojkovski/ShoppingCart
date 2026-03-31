namespace ShoppingCart.Core.Dtos;

public class CartItemDto
{
    public Guid CartItemId { get; set; }
    public Guid ProductId { get; set; }
    public string ProductName { get; set; } = null!;
    public int Quantity { get; set; }
    public decimal PriceWhenAdded { get; set; }
    public decimal TotalPrice { get; set; }
}
