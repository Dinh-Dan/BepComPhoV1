using Common;
using Microsoft.EntityFrameworkCore;
using Model;
using Model.Entitys;
using Model.RequestModel.Employee;
using Service.IService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Service
{
    public class EmployeeService : IEmloyeeService
    {
        private readonly AppDbcontext _context;

        private readonly DataService _dataService;
        public EmployeeService(AppDbcontext context, DataService dataService)
        {
            _context = context;
            _dataService = dataService;
        }

        public async Task<string> GetAllOrder()
        {
            try
            {
                var LstOder = await _context.oders.ToListAsync();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}"); // Log chi tiết lỗi
                return $"Error: {ex.Message}";
            }

            return "e5";
        }





        public Task<Notification> UpdateStatusOrder(int IdOrder, StatusOder statusOder)
        {
            throw new NotImplementedException();
        }
    }
}
