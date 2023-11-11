using Specification.Console.Entities;
using Specification.Core;

namespace Specification.Console.Specifications;

internal static class MoreThanSpecificationExtension
{
    public static bool MoreThan(this OrderEntity order, int amount)
    {
        var specification = new MoreThanSpecification(amount);
        return specification.IsSatisfied(order);
    }

    public static IEnumerable<OrderEntity> MoreThan(this IEnumerable<OrderEntity> orders, int amount)
    {
        return orders.Where(x => x.MoreThan(amount));
    }

    public static IQueryable<OrderEntity> MoreThan(this IQueryable<OrderEntity> orders, int amount)
    {
        return orders.Query(new MoreThanSpecification(amount));
    }

    public static ISpecification<OrderEntity> MoreThan(this ISpecification<OrderEntity> specification, int amount)
    {
        return specification.And(new MoreThanSpecification(amount));
    }
}