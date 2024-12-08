using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Entitys
{
    public class Menu
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public string dessert { get; set; } // tráng miệng
        public string note { get; set; }
        public virtual ICollection<MenuDetail> MenuDetails { get; set; }

    }
}
