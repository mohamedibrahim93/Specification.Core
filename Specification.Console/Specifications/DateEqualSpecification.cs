using Specification.Console.Entities;
using Specification.Core;

namespace Specification.Console.Specifications;

internal class DateEqualSpecification : Specification<OrderEntity>
{
    public DateEqualSpecification(DateTime dateTime)
        : base(order => order.CreationDate.Date == dateTime.Date)
    {
        AddInclude(order => order.OrderItems);
        AddOrderByDescending(order => order.CreationDate);
    }
}