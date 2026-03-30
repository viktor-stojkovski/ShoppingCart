using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ShoppingCart.Data.Migrations
{
    /// <inheritdoc />
    public partial class SeedProducts : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Currency", "Description", "IsActive", "Name", "Price", "StockQuantity" },
                values: new object[,]
                {
                    { new Guid("00000000-0000-0000-0000-000000000001"), "USD", "Compact wireless mouse with USB receiver", true, "Wireless Mouse Logitech M185", 14.99m, 150 },
                    { new Guid("00000000-0000-0000-0000-000000000002"), "USD", "RGB mechanical gaming keyboard", true, "Mechanical Keyboard Redragon K552", 49.99m, 80 },
                    { new Guid("00000000-0000-0000-0000-000000000003"), "USD", "Ultra HD IPS display monitor", true, "Dell 27-inch 4K Monitor", 329.99m, 25 },
                    { new Guid("00000000-0000-0000-0000-000000000004"), "USD", "Noise cancelling wireless headphones", true, "Sony WH-1000XM5 Headphones", 399.99m, 40 },
                    { new Guid("00000000-0000-0000-0000-000000000005"), "USD", "High-speed external solid state drive", true, "Samsung 1TB SSD T7 Portable", 119.99m, 60 },
                    { new Guid("00000000-0000-0000-0000-000000000006"), "USD", "Wireless multi-touch trackpad", true, "Apple Magic Trackpad", 129.00m, 30 },
                    { new Guid("00000000-0000-0000-0000-000000000007"), "USD", "Multiport adapter with HDMI and USB", true, "Anker USB-C Hub 7-in-1", 39.99m, 120 },
                    { new Guid("00000000-0000-0000-0000-000000000008"), "USD", "Full HD webcam for streaming", true, "Logitech C920 HD Webcam", 79.99m, 5 },
                    { new Guid("00000000-0000-0000-0000-000000000009"), "USD", "Wireless monochrome laser printer", true, "HP LaserJet Pro Printer", 189.99m, 20 },
                    { new Guid("00000000-0000-0000-0000-000000000010"), "USD", "Wireless earbuds with noise cancellation", true, "Apple AirPods Pro 2nd Gen", 249.00m, 90 },
                    { new Guid("00000000-0000-0000-0000-000000000011"), "USD", "Smart speaker with Alexa", true, "Amazon Echo Dot 5th Gen", 50.00m, 200 },
                    { new Guid("00000000-0000-0000-0000-000000000012"), "USD", "Ergonomic wired gaming mouse", true, "Razer DeathAdder Gaming Mouse", 59.99m, 110 },
                    { new Guid("00000000-0000-0000-0000-000000000013"), "USD", "Full HD curved gaming monitor", true, "Samsung 32-inch Curved Monitor", 219.99m, 35 },
                    { new Guid("00000000-0000-0000-0000-000000000014"), "USD", "Portable external hard drive USB 3.0", true, "WD 2TB External HDD", 79.99m, 85 },
                    { new Guid("00000000-0000-0000-0000-000000000015"), "USD", "DDR4 desktop memory kit", true, "Corsair Vengeance 16GB RAM", 69.99m, 95 },
                    { new Guid("00000000-0000-0000-0000-000000000016"), "USD", "Desktop CPU 10-core performance", true, "Intel Core i5 13400 Processor", 239.99m, 45 },
                    { new Guid("00000000-0000-0000-0000-000000000017"), "USD", "High performance gaming GPU", true, "NVIDIA RTX 4060 Graphics Card", 400.00m, 15 },
                    { new Guid("00000000-0000-0000-0000-000000000018"), "USD", "Dual-band high-speed router", true, "TP-Link WiFi 6 Router", 129.99m, 65 },
                    { new Guid("00000000-0000-0000-0000-000000000019"), "USD", "13-inch laptop with M2 chip", true, "Apple MacBook Air M2", 1099.00m, 20 },
                    { new Guid("00000000-0000-0000-0000-000000000020"), "USD", "Business ultrabook laptop", true, "Lenovo ThinkPad X1 Carbon", 1399.00m, 2 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000001"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000002"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000003"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000004"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000005"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000006"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000007"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000008"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000009"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000010"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000011"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000012"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000013"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000014"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000015"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000016"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000017"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000018"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000019"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000020"));
        }
    }
}
