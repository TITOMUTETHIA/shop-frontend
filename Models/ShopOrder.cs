namespace ShopFrontend.Models;

public class ShopOrder
{
    public int Id { get; set; }
    public DateTime OrderDate { get; set; }

    public int CustomerId { get; set; }
    public Customer Customer { get; set; }

    public List<OrderItem> Items { get; set; } = new();
}
