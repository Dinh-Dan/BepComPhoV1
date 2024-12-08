using Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.RequestModel.Custom
{
    public class OrderRequet
    {
        public int IDCustom { get; set; } 
        public DateTime DateTimeOrder { get; set; }  
        public int PriceOrder { get; set; } 
        public bool IsDessert { get; set; }  // Có tráng miệng hay không
        public string Note { get; set; }  // Ghi chú của khách hàng

        public List<OrderDetaiRequest> Detai { get; set; }
    }
}
