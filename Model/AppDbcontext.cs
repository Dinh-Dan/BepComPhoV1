using Microsoft.EntityFrameworkCore;
using Model.Entitys;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class AppDbcontext : DbContext
    {

        public DbSet<Customer> Customer { get; set; }
        public DbSet<Eating> eatings { get; set; }
        public DbSet<Menu> menus { get; set; }
        public DbSet<Messsager> messsagers { get; set; }
        public DbSet<Order> oders { get; set; }
        public DbSet<Shiper> shipers { get; set; }

        public DbSet<MenuDetail> menuDetails { get; set; }
        public DbSet<OrderDetail> orderDetails { get; set; }
        public AppDbcontext(DbContextOptions<AppDbcontext> options) : base(options)
        {

        }
    }
}
