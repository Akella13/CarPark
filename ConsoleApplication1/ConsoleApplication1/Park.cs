using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    public class Park
    {
        public string parkName = "";
        public string parkCity = "";
        public string parkAddress = "";
        public int parkCapacity = 1;

        public void DisplayPark()
        {
            Console.WriteLine(this.parkName + "   " + this.parkCity + "   " + this.parkAddress);
        }


    }
}
