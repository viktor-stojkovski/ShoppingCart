using ShoppingCart.Data.Entities;

namespace ShoppingCart.Data;

public static class ProductSeedData
{
    public static List<Product> GetProducts()
    {
        return
        [
            new Product { Id = Guid.Parse("00000000-0000-0000-0000-000000000001"), Name = "Wireless Mouse Logitech M185", Description = "Compact wireless mouse with USB receiver", Price = 14.99m, Currency = "USD", StockQuantity = 150, IsActive = true },
            new Product { Id = Guid.Parse("00000000-0000-0000-0000-000000000002"), Name = "Mechanical Keyboard Redragon K552", Description = "RGB mechanical gaming keyboard", Price = 49.99m, Currency = "USD", StockQuantity = 80, IsActive = true },
            new Product { Id = Guid.Parse("00000000-0000-0000-0000-000000000003"), Name = "Dell 27-inch 4K Monitor", Description = "Ultra HD IPS display monitor", Price = 329.99m, Currency = "USD", StockQuantity = 25, IsActive = true },
            new Product { Id = Guid.Parse("00000000-0000-0000-0000-000000000004"), Name = "Sony WH-1000XM5 Headphones", Description = "Noise cancelling wireless headphones", Price = 399.99m, Currency = "USD", StockQuantity = 40, IsActive = true },
            new Product { Id = Guid.Parse("00000000-0000-0000-0000-000000000005"), Name = "Samsung 1TB SSD T7 Portable", Description = "High-speed external solid state drive", Price = 119.99m, Currency = "USD", StockQuantity = 60, IsActive = true },
            new Product { Id = Guid.Parse("00000000-0000-0000-0000-000000000006"), Name = "Apple Magic Trackpad", Description = "Wireless multi-touch trackpad", Price = 129.00m, Currency = "USD", StockQuantity = 30, IsActive = true },
            new Product { Id = Guid.Parse("00000000-0000-0000-0000-000000000007"), Name = "Anker USB-C Hub 7-in-1", Description = "Multiport adapter with HDMI and USB", Price = 39.99m, Currency = "USD", StockQuantity = 120, IsActive = true },
            new Product { Id = Guid.Parse("00000000-0000-0000-0000-000000000008"), Name = "Logitech C920 HD Webcam", Description = "Full HD webcam for streaming", Price = 79.99m, Currency = "USD", StockQuantity = 5, IsActive = true },
            new Product { Id = Guid.Parse("00000000-0000-0000-0000-000000000009"), Name = "HP LaserJet Pro Printer", Description = "Wireless monochrome laser printer", Price = 189.99m, Currency = "USD", StockQuantity = 20, IsActive = true },
            new Product { Id = Guid.Parse("00000000-0000-0000-0000-000000000010"), Name = "Apple AirPods Pro 2nd Gen", Description = "Wireless earbuds with noise cancellation", Price = 249.00m, Currency = "USD", StockQuantity = 90, IsActive = true },
            new Product { Id = Guid.Parse("00000000-0000-0000-0000-000000000011"), Name = "Amazon Echo Dot 5th Gen", Description = "Smart speaker with Alexa", Price = 50.00m, Currency = "USD", StockQuantity = 200, IsActive = true },
            new Product { Id = Guid.Parse("00000000-0000-0000-0000-000000000012"), Name = "Razer DeathAdder Gaming Mouse", Description = "Ergonomic wired gaming mouse", Price = 59.99m, Currency = "USD", StockQuantity = 110, IsActive = true },
            new Product { Id = Guid.Parse("00000000-0000-0000-0000-000000000013"), Name = "Samsung 32-inch Curved Monitor", Description = "Full HD curved gaming monitor", Price = 219.99m, Currency = "USD", StockQuantity = 35, IsActive = true },
            new Product { Id = Guid.Parse("00000000-0000-0000-0000-000000000014"), Name = "WD 2TB External HDD", Description = "Portable external hard drive USB 3.0", Price = 79.99m, Currency = "USD", StockQuantity = 85, IsActive = true },
            new Product { Id = Guid.Parse("00000000-0000-0000-0000-000000000015"), Name = "Corsair Vengeance 16GB RAM", Description = "DDR4 desktop memory kit", Price = 69.99m, Currency = "USD", StockQuantity = 95, IsActive = true },
            new Product { Id = Guid.Parse("00000000-0000-0000-0000-000000000016"), Name = "Intel Core i5 13400 Processor", Description = "Desktop CPU 10-core performance", Price = 239.99m, Currency = "USD", StockQuantity = 45, IsActive = true },
            new Product { Id = Guid.Parse("00000000-0000-0000-0000-000000000017"), Name = "NVIDIA RTX 4060 Graphics Card", Description = "High performance gaming GPU", Price = 400.00m, Currency = "USD", StockQuantity = 15, IsActive = true },
            new Product { Id = Guid.Parse("00000000-0000-0000-0000-000000000018"), Name = "TP-Link WiFi 6 Router", Description = "Dual-band high-speed router", Price = 129.99m, Currency = "USD", StockQuantity = 65, IsActive = true },
            new Product { Id = Guid.Parse("00000000-0000-0000-0000-000000000019"), Name = "Apple MacBook Air M2", Description = "13-inch laptop with M2 chip", Price = 1099.00m, Currency = "USD", StockQuantity = 20, IsActive = true },
            new Product { Id = Guid.Parse("00000000-0000-0000-0000-000000000020"), Name = "Lenovo ThinkPad X1 Carbon", Description = "Business ultrabook laptop", Price = 1399.00m, Currency = "USD", StockQuantity = 2, IsActive = true }
        ];
    }
}
