using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common;
namespace Model.Entitys
{
    public class Eating
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public EatingType type { get; set; }
        public string describe { get; set; }
        public int Count { get; set; }
    }
}
