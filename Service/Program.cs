using Service.Service;
using Microsoft.Extensions.DependencyInjection;
using Service.IService;
using Microsoft.EntityFrameworkCore;
using Model;

namespace Service
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var services = new ServiceCollection();
            ConfigureServices(services);

            var serviceProvider = services.BuildServiceProvider();

            var customService = serviceProvider.GetService<ICustomService>();
            var employeeService = serviceProvider.GetService<IEmloyeeService>();



            var result = customService.GetMenuDay("2024/12/02").Result;
            var results = employeeService.GetAllOrder().Result;
            Console.WriteLine(results);
            Console.WriteLine("Debug completed. Press any key to exit...");
            Console.ReadKey();


        }




        private static void ConfigureServices(ServiceCollection services)
        {
            services.AddDbContext<AppDbcontext>(options =>
               options.UseSqlServer("Data Source=DESKTOP-G34I4C9;Initial Catalog=bepcomphotest;Integrated Security=True;Encrypt=False"));
            // Đăng ký các service
            services.AddTransient<ICustomService, CustomService>();
        }
    }
}
