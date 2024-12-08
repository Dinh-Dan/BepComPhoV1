using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Entitys
{
    public class Customer

    {
        public int id { get; set; }

        public string CODE { get; set; }
        public string name { get; set; }
        public string numberPhone { get; set; }

        public string email { get; set; }

        public string address { get; set; }

        public string addMap  { get; set; }  // địa chỉ google map  1312321,23.1231232,23

        public DateTime timeLate { get; set; } // thời gian giao cơm muộn nhất
    }
}
