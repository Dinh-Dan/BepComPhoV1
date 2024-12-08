using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common;
namespace Model.Entitys
{
    public class Order
    {
        public int Id { get; set; }
        public int CustomId { get; set; }
        public virtual Customer Custom { get; set; }
        public DateTime DateTimeOrder { get; set; }
        public int PriceOrder { get; set; } // 35 40 45 50
        public bool IsDessert { get; set; } // có tráng miệng hoặc đầy đặn
        public StatusOder StatusOrder { get; set; }
        public int Sum { get; set; }
        public int Price { get; set; }
        public string Note { get; set; }
        public int? ShiperId { get; set; }
        public virtual Shiper Shiper { get; set; }

        // Liên kết với OrderDetails
        public virtual ICollection<OrderDetail> OrderDetails { get; set; }
    }
}
