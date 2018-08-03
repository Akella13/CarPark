using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    class Program
    {
        public static List<Park> InitializeParkList()
        {
            //create new parks
            Park Detpark = new Park();
            Detpark.parkName = "DetPark";
            Detpark.parkCity = "Detroit";
            Detpark.parkAddress = "Avenue";

            Park Lonpark = new Park();
            Lonpark.parkName = "LonPark";
            Lonpark.parkCity = "London";
            Lonpark.parkAddress = "Soho";

            //collect parks to a list
            List<Park> ParkList = new List<Park>();
            ParkList.Add(Detpark);
            ParkList.Add(Lonpark);
            return ParkList;
        }
        public static List<Car> InitializeCarList(List<Park> arg)
        {
            //create new cars
            Car car1 = new Car();
            car1.carPark = arg[1];
            car1.carBrand = "Toyota";
            car1.carModel = "Prius";
            car1.carDriver = "John";
            car1.carColor = "yellow";
            car1.carYear = 2008;
            car1.carVin = "112233";
            car1.carParts = "parts";

            Car car2 = new Car();
            car2.carPark = arg[0];
            car2.carBrand = "Dodge";
            car2.carModel = "Charger";
            car2.carDriver = "Mike";
            car2.carColor = "brown";
            car2.carYear = 1967;
            car2.carVin = "223344";
            car2.carParts = "parts";

            Car car3 = new Car();
            car3.carPark = arg[0];
            car3.carBrand = "BMW";
            car3.carModel = "M3";
            car3.carDriver = "Alex";
            car3.carColor = "blue";
            car3.carYear = 2008;
            car3.carVin = "112233";
            car3.carParts = "parts";

            //collect cars to a list
            List<Car> CarList = new List<Car>();
            CarList.Add(car1);
            CarList.Add(car2);
            CarList.Add(car3);
            arg[0].parkCapacity++;

            return CarList;
        }

        static void DisplayParks(List<Park> arg)
        {
            Console.WriteLine("Here are all available car parks:\n");
            Console.WriteLine("Name   City   Address");
            foreach (Park item in arg)
            {
                item.DisplayPark();
            }
            Console.ReadLine();
        }
        static void DisplayAllCars(List<Car> arg)
        {
            Console.WriteLine("Here are all available cars:\n");
            Console.WriteLine("Park      Driver   Brand   Model   Year   VIN   Color   Parts");
            foreach (Car item in arg)
            {
                item.DisplayCar();
            }
            Console.ReadLine();
        }
        static void DisplayCars(List<Car> arg1, Park arg2)
        {
            Console.WriteLine("Here are  available cars in " + arg2.parkName + ":\n");
            Console.WriteLine("Park      Driver   Brand   Model   Year   VIN   Color   Parts");
            foreach (Car item in arg1)
            {
                if (item.carPark == arg2)
                {
                    item.DisplayCar();
                }
                
            }
            Console.ReadLine();
        }

        public static List<Car> AddCar(List<Car> arg1, Park arg2)
        {
            Car newCar = new Car();
            newCar.carPark = arg2;
            newCar.carBrand = "Aston Martin";
            newCar.carModel = "DB9";
            newCar.carDriver = "James";
            newCar.carColor = "silver";
            newCar.carYear = 2003;
            newCar.carVin = "445566";
            newCar.carParts = "parts";

            if (arg2.ParkIsValid())
            {
                arg1.Add(newCar);
                arg2.parkCapacity++;
                DisplayCars(arg1, arg2);
            }           
            return arg1;
        }
        public static List<Car> RemoveCar(List<Car> arg1, Car arg2)
        {
            var carToRemove = arg1.SingleOrDefault(car => car == arg2);
            if (carToRemove.carPark != arg2.carPark)
            {
                Console.WriteLine(arg2.carModel + " driven by " + arg2.carDriver + " does not exist in " + arg2.carPark.parkName);
            }
            else if (arg2.carPark.parkCapacity <= 1)
            {
                Console.WriteLine(arg2.carPark.parkName + " must have at least " + arg2.carPark.parkCapacity + " car(s), you cannot remove any more");
            }
            else if (carToRemove != null && arg2.carPark.ParkIsValid())
            {
                arg1.Remove(carToRemove);
                arg2.carPark.parkCapacity--;
                Console.WriteLine("You have removed a car driven by " + carToRemove.carDriver + "!");
            }
            
            DisplayCars(arg1, arg2.carPark);
            return arg1;
        }
        public static List<Car> TransferCar(List<Car> arg1, Park arg2, Car arg3)
        {
            var carToTransfer = arg1.SingleOrDefault(car => car == arg3);
            if (carToTransfer.carPark != arg3.carPark)
            {
                Console.WriteLine(arg3.carModel + " driven by " + arg3.carDriver + " does not exist in " + carToTransfer.carPark.parkName);
            }
            else if (carToTransfer.carPark.parkCapacity <= 1)
            {
                Console.WriteLine(carToTransfer.carPark.parkName + " must have at least " + carToTransfer.carPark.parkCapacity + " car(s), you cannot remove any more");
            }
            else if (carToTransfer.carPark == arg2)
            {
                Console.WriteLine(carToTransfer.carDriver + " is already staged at " + arg2.parkName + "!");
            }
            else if (carToTransfer != null)
            {
                carToTransfer.carPark = arg2;
            }

            DisplayAllCars(arg1);
            Console.WriteLine("carPark name = " + arg3.carPark.parkName + ", carCapacity = " + arg3.carPark.parkCapacity);
            Console.ReadLine();
            return arg1;
        }

        static void Main(string[] args)
        {
            List<Park> ParkList = InitializeParkList();
            List<Car> CarList = InitializeCarList(ParkList);

            DisplayParks(ParkList);
            DisplayAllCars(CarList);

            RemoveCar(CarList, CarList[1]);
            //RemoveCar(CarList, ParkList[0], CarList[1]);
            //RemoveCar(CarList, ParkList[0], CarList[1]);

        }
    }
}
