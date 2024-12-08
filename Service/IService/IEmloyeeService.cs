using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common;
using Model;
using Model.RequestModel.Employee;
namespace Service.IService
{
    public interface IEmloyeeService
    {
        Task<string> GetAllOrder();
        Task<Notification> UpdateStatusOrder(int IdOrder, StatusOder statusOder);

    }
}
