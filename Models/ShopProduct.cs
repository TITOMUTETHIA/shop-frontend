namespace ShopFrontend.Models;

public sealed record ShopProduct(
    int Id,
    string Name,
    string Category,
    decimal Price,
    string Symbol,
    string ColorClass,
    string Badge);
