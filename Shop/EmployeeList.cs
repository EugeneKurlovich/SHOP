using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop
{
   public class EmployeeList
    {
        public static List<EmployeeList> emplList = new List<EmployeeList>();
        public int id { get; set; }
        public string name { get; set; }
        public string surname { get; set; }
        public string post { get; set; }
        public string login { get; set; }
        public string password { get; set; }
        public double salary { get; set; }
    }
}
