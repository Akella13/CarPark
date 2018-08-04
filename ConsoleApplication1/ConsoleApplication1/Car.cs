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


        public void DisplayCar()
        {
            Console.WriteLine(this.carPark.parkName + "   " + this.carDriver + "   " + this.carBrand + "   " + this.carModel + "   " + this.carYear + "   " + this.carVin + "   " + this.carColor + "   " + this.carParts.partType);
        }

        public void DisplayParts()
        {
            Console.WriteLine(this.carModel + " driven by " + this.carDriver + " parts are:");
            Console.WriteLine("Type   Year   Serial N");
            foreach (Part part in carParts)
            {
                Console.WriteLine(part.partType + "   " + part.partExpDate + "   " + part.partNumber);
            }
            Console.ReadLine();
        }

        public Car AssignParts()
        {
            this.DisplayParts();
            Part part1 = new Part();
            part1.partType = "";
            part1.partExpDate = 1;
            part1.partNumber = 00000;

            List<Part> assignedParts = new List<Part>();
            assignedParts.Add(part1);
            this.carParts = assignedParts;
            return this;
        }
    }
}
