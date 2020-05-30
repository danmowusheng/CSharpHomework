﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace OrderWeb.Model
{
    public class Goods
    {
        [Key]
        public string ID { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
    }
}
