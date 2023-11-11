using Specification.Console.Entities;
using Specification.Core;

namespace Specification.Console.Specifications;

internal class TodaySpecification : Specification<OrderEntity>
{
    public TodaySpecification()
        : base(order => order.CreationDate.Date == DateTime.Today)
    {
        AddInclude(order => order.OrderItems);
        AddOrderByDescending(order => order.CreationDate);
    }
}