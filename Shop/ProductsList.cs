using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop
{
    public class ProductsList
    {
        public static List<ProductsList> prodList = new List<ProductsList>();
        public string name { get; set; }
        public double price { get; set; }
        public string description { get; set; }
    }
}
