﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Entitys
{
    public class ImageCustom
    {
        public int id { get; set; }
        public virtual Customer Custom { get; set; }
        public string link { get; set; }

    }
}
