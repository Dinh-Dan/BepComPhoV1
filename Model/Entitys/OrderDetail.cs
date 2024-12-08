using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Entitys
{
    public class OrderDetail
    {
        public int Id { get; set; }

        public int OrderId { get; set; }
        public virtual  Order  order{ get; set; }

        public int EatingId { get; set; }
        public virtual Eating Eating { get; set; }

        public int Count { get; set; }

        public int Pirce {  get; set; } 
    }
}
