using Common;
using Model.Entitys;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.RequestModel.Employee
{
   
  
    public class GetAllOder
    {
      public List<GetOrderReponse>? getOrderReponses { get; set; }
    }

    public class GetOrderReponse
    {
        public int Id { get; set; }
        public int CustomId { get; set; }
        public DateTime DateTimeOrder { get; set; }
        public int PriceOrder { get; set; }
        public bool IsDessert { get; set; }
        public StatusOder StatusOrder { get; set; }
        public int Sum { get; set; }
        public int Price { get; set; }
        public string Note { get; set; } = string.Empty; 
        public int ShiperId { get; set; }
        public List<OrderDetailRepont> OrderDetailRepont { get; set; } = new(); 
    }


    public class OrderDetailRepont
    {

        public int OrderId { get; set; }

        public string NameEating { get; set; }

        public EatingType type { get; set; }

        public int Count { get; set; }

        public int Pirce { get; set; }
    }

}
