using Specification.Console.Entities;
using Specification.Core;

namespace Specification.Console.Specifications;

internal class GetByIdSpecification : Specification<OrderEntity>
{
    public GetByIdSpecification(int id)
        : base(order => order.Id == id)
    {
        AddInclude(order => order.OrderItems);
    }
}