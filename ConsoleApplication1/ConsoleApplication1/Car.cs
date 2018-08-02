using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    class Car
    {
        public string driver;
        public string brand;
        public string model;
        public int year;
        public string vin;
        public string color;
        public string parts;

        public void DisplayCar()
        {
            Console.WriteLine(this.driver + "   " + this.brand + "   " + this.model + "   " + this.year + "   " + this.vin + "   " + this.color + "   " + this.parts);
        }
    }
}
