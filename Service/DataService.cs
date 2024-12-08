using Model.Entitys;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;
using Model.RequestModel.Employee;
using Common;
namespace Service
{
    public class DataService
    {
        public List<Order> orders { get; set; }
        public List<OrderDetail> ordersDetail { get; set; }
        public List<Shiper> shiper { get; set; }
        public List<Eating> eating { get; set; }


        public DataService()
        {
            // Sample data for Eating
            eating = new List<Eating>
            {
                new Eating { Id = 1, Name = "Pizza", type = EatingType.normally, describe = "Cheese Pizza", Count = 10 },
                new Eating { Id = 2, Name = "Burger", type = EatingType.Healthy, describe = "Beef Burger", Count = 20 },
                new Eating { Id = 3, Name = "Ice Cream", type = EatingType.normally, describe = "Vanilla Ice Cream", Count = 30 }
            };

            // Sample data for Shiper
            shiper = new List<Shiper>
            {
                new Shiper { Id = 1, Name = "John Doe", addree = "123 Main St", email = "john.doe@example.com" },
                new Shiper { Id = 2, Name = "Jane Smith", addree = "456 Oak St", email = "jane.smith@example.com" }
            };

            // Sample data for Orders
            orders = new List<Order>
            {
                new Order
                {
                    Id = 1,
                    CustomId = 101,
                    DateTimeOrder = DateTime.Now,
                    PriceOrder = 40,
                    IsDessert = false,
                    StatusOrder = StatusOder.received,
                    Sum = 2,
                    Price = 80,
                    Note = "Fast delivery",
                    ShiperId = 1
                },
                new Order
                {
                    Id = 2,
                    CustomId = 102,
                    DateTimeOrder = DateTime.Now.AddMinutes(-10),
                    PriceOrder = 50,
                    IsDessert = true,
                    StatusOrder = StatusOder.complete,
                    Sum = 3,
                    Price = 150,
                    Note = "Special instructions",
                    ShiperId = 2
                }
            };

            // Sample data for OrderDetails
            ordersDetail = new List<OrderDetail>
            {
                new OrderDetail
                {
                    Id = 1,
                    OrderId = 1,
                    EatingId = 1, // Pizza
                    Count = 2,
                    Pirce = 40
                },
                new OrderDetail
                {
                    Id = 2,
                    OrderId = 2,
                    EatingId = 3, // Ice Cream (Dessert)
                    Count = 1,
                    Pirce = 50
                },
                new OrderDetail
                {
                    Id = 3,
                    OrderId = 2,
                    EatingId = 2, // Burger
                    Count = 2,
                    Pirce = 100
                }
            };
        }
        public GetAllOder GetAllOders()
        {
            // Create the result container
            var result = new GetAllOder
            {
                // Project the orders to a list of GetOrderReponse
                getOrderReponses = orders.Select(order => new GetOrderReponse
                {
                    Id = order.Id,
                    CustomId = order.CustomId,
                    DateTimeOrder = order.DateTimeOrder,
                    PriceOrder = order.PriceOrder,
                    IsDessert = order.IsDessert,
                    StatusOrder = order.StatusOrder,
                    Sum = order.Sum,
                    Price = order.Price,
                    Note = order.Note,
                    ShiperId = order.ShiperId ?? 0, // Handle nullable ShiperId (use 0 or a default value if null)

                    // Map the order details to the OrderDetailRepont format
                    OrderDetailRepont = ordersDetail
                        .Where(detail => detail.OrderId == order.Id)
                        .Select(detail => new OrderDetailRepont
                        {
                            OrderId = detail.OrderId,
                            NameEating = eating.FirstOrDefault(eat => eat.Id == detail.EatingId)?.Name ?? "Unknown", // Get eating name
                            type = eating.FirstOrDefault(type => type.Id == detail.EatingId)?.type ?? EatingType.normally,   // Get eating type
                            Count = detail.Count,
                            Pirce = detail.Pirce
                        }).ToList()

                }).ToList()
            };

            return result;
        }
    }

}
