using Specification.Console.Entities;

namespace Specification.Console;

internal static class Context
{
    private static readonly List<OrderEntity> StoreOrders = new()
    {
        new()
        {
            Id = 1,
            CreationDate = DateTime.Today,
            Status = 1,
            TotalAmount = 1000,
            UserName = "user 1",
            OrderItems = new List<OrderItemEntity>
            {
                new()
                {
                    Id = 1,
                    Price = 100,
                    Quantity = 2,
                    Name = "product 1",
                    Description = "desc 1"
                },
                new()
                {
                    Id = 2,
                    Price = 200,
                    Quantity = 1,
                    Name = "product 2",
                    Description = "desc 2"
                },
                new()
                {
                    Id = 3,
                    Price = 600,
                    Quantity = 1,
                    Name = "product 3",
                    Description = "desc 3"
                }
            }
        },
        new()
        {
            Id = 2,
            CreationDate = DateTime.Today,
            Status = 2,
            TotalAmount = 2000,
            UserName = "user 2",
            OrderItems = new List<OrderItemEntity>
            {
                new()
                {
                    Id = 1,
                    Price = 100,
                    Quantity = 10,
                    Name = "product 1",
                    Description = "desc 1"
                },
                new()
                {
                    Id = 2,
                    Price = 200,
                    Quantity = 5,
                    Name = "product 2",
                    Description = "desc 2"
                }
            }
        },
        new()
        {
            Id = 3,
            CreationDate = DateTime.Now.AddDays(-1),
            Status = 1,
            TotalAmount = 600,
            UserName = "user 1",
            OrderItems = new List<OrderItemEntity>
            {
                new()
                {
                    Id = 3,
                    Price = 600,
                    Quantity = 1,
                    Name = "product 1",
                    Description = "desc 1"
                }
            }
        },
        new()
        {
            Id = 4,
            CreationDate = DateTime.Now.AddDays(-2),
            Status = 4,
            TotalAmount = 200,
            UserName = "user 1",
            OrderItems = new List<OrderItemEntity>
            {
                new()
                {
                    Id = 2,
                    Price = 200,
                    Quantity = 1,
                    Name = "product 1",
                    Description = "desc 1"
                }
            }
        },
        new()
        {
            Id = 5,
            CreationDate = DateTime.Now,
            Status = 2,
            TotalAmount = 300,
            UserName = "user 1",
            OrderItems = new List<OrderItemEntity>
            {
                new()
                {
                    Id = 2,
                    Price = 300,
                    Quantity = 1,
                    Name = "product 1",
                    Description = "desc 1"
                }
            }
        },
        new()
        {
            Id = 6,
            CreationDate = DateTime.Now.AddDays(-3),
            Status = 1,
            TotalAmount = 200,
            UserName = "user 1",
            OrderItems = new List<OrderItemEntity>
            {
                new()
                {
                    Id = 2,
                    Price = 200,
                    Quantity = 1,
                    Name = "product 1",
                    Description = "desc 1"
                }
            }
        },
        new()
        {
            Id = 7,
            CreationDate = DateTime.Now,
            Status = 2,
            TotalAmount = 200,
            UserName = "user 1",
            OrderItems = new List<OrderItemEntity>
            {
                new()
                {
                    Id = 2,
                    Price = 200,
                    Quantity = 1,
                    Name = "product 1",
                    Description = "desc 1"
                }
            }
        },
        new()
        {
            Id = 8,
            CreationDate = DateTime.Now,
            Status = 3,
            TotalAmount = 700,
            UserName = "user 1",
            OrderItems = new List<OrderItemEntity>
            {
                new()
                {
                    Id = 2,
                    Price = 200,
                    Quantity = 1,
                    Name = "product 1",
                    Description = "desc 1"
                }
            }
        },
        new()
        {
            Id = 9,
            CreationDate = DateTime.Now,
            Status = 4,
            TotalAmount = 200,
            UserName = "user 1",
            OrderItems = new List<OrderItemEntity>
            {
                new()
                {
                    Id = 2,
                    Price = 200,
                    Quantity = 1,
                    Name = "product 1",
                    Description = "desc 1"
                }
            }
        },
    };

    public static IQueryable<OrderEntity> Orders => StoreOrders.AsQueryable();
}