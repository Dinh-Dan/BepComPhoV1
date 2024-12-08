
using Microsoft.EntityFrameworkCore;
using Model;
using Service;
using Service.IService;
using Service.Service;
using System;

namespace BepComPhoV1
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddDbContext<AppDbcontext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));


            builder.Services.AddCors(options =>
            {
                options.AddPolicy("AllowAll", builder =>
                {
                    builder.AllowAnyOrigin()  // Cho phép tất cả các domain
                           .AllowAnyMethod()  // Cho phép tất cả các phương thức HTTP
                           .AllowAnyHeader(); // Cho phép tất cả các header
                });
            });

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();



            builder.Services.AddScoped<IMaganerService, MaganerService>();
            builder.Services.AddScoped<ICustomService ,CustomService>();
            builder.Services.AddScoped<IEmloyeeService, EmployeeService>();

            builder.Services.AddSingleton<DataService>();

            builder.Services.AddMemoryCache();

            var app = builder.Build();
            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();

            app.UseCors("AllowAll");
            app.MapControllers();

            app.Run();
        }
    }
}
