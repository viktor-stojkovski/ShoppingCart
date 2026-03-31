using Microsoft.Extensions.DependencyInjection;
using ShoppingCart.Core.Interfaces;
using ShoppingCart.Core.Services;

namespace ShoppingCart.Core;

public static class CoreServicesInitializer
{
    public static void Initialize(IServiceCollection services)
    {
        services.AddScoped<ICartService, CartService>();
    }
}
