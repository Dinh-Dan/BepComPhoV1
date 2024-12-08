using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Entitys
{
    public class ImageEating
    {
        public int Id { get; set; }


        public virtual Eating Eating { get; set; }
        public string name { get; set; }

        public string link { get; set; }

    }
}
