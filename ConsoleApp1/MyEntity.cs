using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public class MyEntity
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public int Age { get; set; }

        public DateTime CreateDate { get; set; }
        public Role Role { get; set; }
    }

}
