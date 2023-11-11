using Specification.Console.Entities;
using Specification.Core;

namespace Specification.Console.Specifications;

internal static class StatusSpecificationExtension
{
    public static bool Status(this OrderEntity order, int status)
    {
        var specification = new StatusSpecification(status);
        return specification.IsSatisfied(order);
    }

    public static IEnumerable<OrderEntity> Status(this IEnumerable<OrderEntity> orders, int status)
    {
        return orders.Where(x => x.Status(status));
    }

    public static IQueryable<OrderEntity> Status(this IQueryable<OrderEntity> orders, int status)
    {
        return orders.Query(new StatusSpecification(status));
    }

    public static ISpecification<OrderEntity> Status(this ISpecification<OrderEntity> specification, int status)
    {
        return specification.And(new StatusSpecification(status));
    }

    public static ISpecification<OrderEntity> Status(this ISpecification<OrderEntity> specification, params int[] statuses)
    {
        if (statuses.Length == 0) throw new ArgumentException("there is at least one status is required");

        var combinedSpecification = SpecificationBuilder.Create<OrderEntity>(order => order.Status(statuses.First()));

        statuses
            .Skip(1)
            .ToList()
            .ForEach(status =>
                combinedSpecification = combinedSpecification.Or(new StatusSpecification(status)));

        return specification.And(combinedSpecification);
    }
}