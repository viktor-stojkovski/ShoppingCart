namespace ShoppingCart.Core.Models;

public class RemoveCartItemModel
{
    public Guid CartId { get; set; }
    public Guid CartItemId { get; set; }
}
