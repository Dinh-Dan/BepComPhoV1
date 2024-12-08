using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Entitys
{

    public class MenuDetail
    {
        public int Id { get; set; }

        // Liên kết với Menu
        public int MenuId { get; set; }
        public virtual Menu Menu { get; set; }

        // Liên kết với món ăn
        public int EatingId { get; set; }
        public virtual Eating Eating { get; set; }
         public int Quantity { get; set; }
    }
}
