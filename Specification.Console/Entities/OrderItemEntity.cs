namespace Specification.Console.Entities;

internal class OrderItemEntity
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public decimal Price { get; set; }
    public int Quantity { get; set; }

    public override string ToString()
    {
        return $"ITEM:: Id: {Id}, Name: {Name}, Description: {Description}, Price: {Price:F}, Quantity: {Quantity}, TotalAmount: {Quantity}";
    }
}