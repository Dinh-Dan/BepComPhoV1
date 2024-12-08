using Model.Entitys;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.ResponseModel.CustomRepon
{
    public class GetMenuDay
    {

        public int Id { get; set; }
        public DateTime Date { get; set; }
        public string dessert { get; set; } 
        public string note { get; set; }

        public List<Eating> lstEating {  get; set; }
    }
}
