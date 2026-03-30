using Microsoft.Extensions.DependencyInjection;
using ShoppingCart.Data.Repositories.Implementations;
using ShoppingCart.Data.Repositories.Interfaces;

namespace ShoppingCart.Data.Repositories;

public static class RepositoriesInitializer
{
    public static void Initialize(IServiceCollection services)
    {
        services.AddScoped<IProductRepository, ProductRepository>();
        services.AddScoped<ICartRepository, CartRepository>();
    }
}
