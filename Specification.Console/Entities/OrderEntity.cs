namespace Specification.Console.Entities;

internal class OrderEntity
{
    public int Id { get; set; }
    public int Status { get; set; }
    public DateTime CreationDate { get; set; }
    public string UserName { get; set; } = string.Empty;
    public decimal TotalAmount { get; set; }
    public IReadOnlyCollection<OrderItemEntity> OrderItems { get; set; } = new List<OrderItemEntity>();

    public override string ToString()
    {
        return $"\nORDER:: Id: {Id}, Status: {Status}, Creation Date: {CreationDate:yyyy-MM-dd}, UserName: {UserName}, TotalAmount: {TotalAmount:F}" +
               $"\n\t{string.Join("\n\t", OrderItems.Select(item => item))}\n";
    }
}