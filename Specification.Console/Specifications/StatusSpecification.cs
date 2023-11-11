using Specification.Console.Entities;
using Specification.Core;

namespace Specification.Console.Specifications;

internal class StatusSpecification : Specification<OrderEntity>
{
    public StatusSpecification(int status)
        : base(order => order.Status == status)
    {
    }
}