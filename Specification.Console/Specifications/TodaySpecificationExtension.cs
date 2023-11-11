using Specification.Console.Entities;
using Specification.Core;

namespace Specification.Console.Specifications;

internal static class TodaySpecificationExtension
{
    public static bool Today(this OrderEntity order)
    {
        var specification = new TodaySpecification();
        return specification.IsSatisfied(order);
    }

    public static IEnumerable<OrderEntity> Today(this IEnumerable<OrderEntity> orders)
    {
        return orders.Where(x => x.Today());
    }

    public static IQueryable<OrderEntity> Today(this IQueryable<OrderEntity> orders)
    {
        return orders.Query(new TodaySpecification());
    }

    public static ISpecification<OrderEntity> Today(this ISpecification<OrderEntity> specification)
    {
        return specification.And(new TodaySpecification());
    }
}