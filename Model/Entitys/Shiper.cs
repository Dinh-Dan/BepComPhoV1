using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Entitys
{
    public class Shiper
    {
        public int Id { get; set; }
        public string Name { get; set; }    
        public string addree { get; set; }
        public string email { get; set; }
     // public string PhoneNumber { get; set; }
        public virtual ICollection<Order> orders { get; set; }
    }
}
