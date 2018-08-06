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
        public Park carPark;
        public List<Part> carParts;

        public Car()
        {
            this.carParts = new List<Part>();
        }


        public void DisplayCar()
        {
            Console.WriteLine(this.carPark.parkName + "   " + this.carDriver + "   " + this.carBrand + "   " + this.carModel + "   " + this.carYear + "   " + this.carVin + "   " + this.carColor + "   ");
            foreach (Part part in this.carParts)
            {
                Console.WriteLine("                                                        " + part.partType);
            }

        }

        public void DisplayParts()
        {
            Console.WriteLine(this.carModel + " driven by " + this.carDriver + " parts are:");
            Console.WriteLine("Type   Expiration   Serial N");
            foreach (Part part in carParts)
            {
                Console.WriteLine(part.partType + "   " + part.partExpDate + "   " + part.partNumber);
            }
            Console.ReadLine();
        }

        public Car AddPart(Part arg)
        {
            int partTypeRepeat = this.carParts.FindIndex(part => part.partType == arg.partType);
            if (partTypeRepeat != 0)
            {
                Console.WriteLine(arg.partType + " has been added to " + this.carModel + " driven by " + this.carDriver);
                this.carParts.Add(arg);
            }
            else
            {
                Console.WriteLine(this.carBrand + " " + this.carModel + " already contains " + arg.partType);
            }
            this.DisplayParts();
            return this;
        }

        public Car RemovePart(Part arg)
        {
            int partTypeRepeat = this.carParts.FindIndex(part => part.partType == arg.partType);
            if (partTypeRepeat == 0)
            {
                Console.WriteLine(this.carBrand + " " + this.carModel + " does not have " + arg.partType);
            }
            else
            {
                Console.WriteLine(arg.partType + " has been removed from " + this.carModel + " driven by " + this.carDriver);
                this.carParts.Remove(arg);
            }
            this.DisplayParts();
            return this;
        }
    }
}
