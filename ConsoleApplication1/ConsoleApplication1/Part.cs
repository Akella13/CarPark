using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    class Part
    {
        public int partNumber = 0;
        public string partExpDate = "10000 km";
        public string partType = "";

        public Car PartContainingCar(List<Car> arg)
        {
            int carCount = 0;
            foreach (Car car in arg)
            {
                int partTypeRepeat = car.carParts.FindIndex(part => part == this);
                if (partTypeRepeat != 0)
                {
                    carCount++;
                }
            }
            if (carCount >= 1)
            {
                int index = 0;
                for (int i = 0; i < arg.Count; i++)
                {
                    int partTypeRepeat = arg[i].carParts.FindIndex(part => part == this);
                    if (partTypeRepeat == 0)
                    {
                        index = i;
                    }
                }
                return arg[index];
            }
            else
            {
                Console.WriteLine("Part is not in a car");
                return null;
            }
        }

        public void ExpCheck(List<Car> arg)
        {
            if (this.PartContainingCar(arg) == null)
            {
                this.partExpDate = "1 year";
            }
        }
    }
}
