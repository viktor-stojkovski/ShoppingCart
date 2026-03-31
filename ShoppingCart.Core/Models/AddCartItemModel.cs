namespace ShoppingCart.Core.Models;

public class AddCartItemModel
{
    public Guid UserId { get; set; }
    public Guid ProductId { get; set; }
    public int Quantity { get; set; }
    public string Currency { get; set; } = null!;
}
