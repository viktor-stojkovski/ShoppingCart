namespace ShoppingCart.Core.Models;

public class UpdateCartItemQuantityModel
{
    public Guid UserId { get; set; }
    public Guid CartItemId { get; set; }
    public int Quantity { get; set; }
}
