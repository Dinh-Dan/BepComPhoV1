using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.RequestModel.Custom
{
    public class OrderDetaiRequest
    {
        public int EatingId { get; set; }  // ID món ăn
        public int Quantity { get; set; }  // Số lượng món ăn
        public int Pirce { get; set; }
    }

}
