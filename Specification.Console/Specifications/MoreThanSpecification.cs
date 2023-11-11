using Specification.Console.Entities;
using Specification.Core;

namespace Specification.Console.Specifications;

internal class MoreThanSpecification : Specification<OrderEntity>
{
    public MoreThanSpecification(decimal amount)
        : base(order => order.TotalAmount >= amount)
    {
        AddInclude(order => order.OrderItems);
    }
}