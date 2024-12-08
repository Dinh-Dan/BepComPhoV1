using Model.Entitys;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.RequestModel.ImaganerService
{
    public class newMenuDay
    {

        public DateTime DateTime { get; set; }
        public string dessert { get; set; } // tráng miệng
        public List<DeltailMenuday> lstMainDishes { get; set; }

        public List<int> lstSideDishes { get; set; }

        public string Note { get; set; }
    }
}
