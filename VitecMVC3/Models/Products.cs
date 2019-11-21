using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VitecMVC3.Models
{
    public class Products
    {
        public int ID { get; set; }
        public string Title { get; set; }
        public string Picture { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
    }
}
