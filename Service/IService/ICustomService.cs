using Common;
using Model.Entitys;
using Model.RequestModel.Custom;
using Model.RequestModel.ImaganerService;
using Model.ResponseModel.CustomRepon;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.IService
{
    public   interface ICustomService
    {
          Task<GetMenuDay> GetMenuDay(string date);
        Task<Notification> CreateCustomer (CreateCustomer newCustomer);
        Task<Notification> CreateOrderAsync(OrderRequet newOrder);
        Task<Notification> UpdateOrder(OrderRequet newOrder);
        Task<Order> GetOrderByCustomerIdAsync(int customerId);
    }
}
