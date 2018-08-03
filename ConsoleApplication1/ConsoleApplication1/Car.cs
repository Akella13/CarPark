using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    class Car
    {
        public string carDriver;
        public string carBrand;
        public string carModel;
        public int carYear;
        public string carVin;
        public string carColor;
        public string carParts;
        public Park carPark;
        

        public void DisplayCar()
        {
            Console.WriteLine(this.carPark.parkName + "   " + this.carDriver + "   " + this.carBrand + "   " + this.carModel + "   " + this.carYear + "   " + this.carVin + "   " + this.carColor + "   " + this.carParts);
        }

        public bool CarHasParkCheck()
        {
            if(carPark.parkName == "" || carPark.parkCity == "" || carPark.parkAddress == "")
            {
                Console.WriteLine("You need to assign this " + this.carModel + " driven by " + this.carDriver + " to a park!");
                Console.ReadLine();
                return false;
            }
            else
            {
                return true;
            }
        }
    }
}
