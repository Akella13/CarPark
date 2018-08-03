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

            int CarCount = CarList.Count;
            //for (int i = 0; i < CarCount; i++)
            //{
            //    CarList.Add(value);
            //}
            return CarList;
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

            arg1.Add(newCar);
            DisplayCars(arg1, arg2);
            return arg1;
        }

        public static List<Car> RemoveCar(List<Car> arg1, Park arg2)
        {
            var itemToRemove = arg1.SingleOrDefault(car => car.carDriver == "John");
            if (itemToRemove != null && itemToRemove.carPark == arg2)
            {
                arg1.Remove(itemToRemove);
            }
            Console.WriteLine("You have removed a car driven by " + itemToRemove.carDriver + "!");
            DisplayCars(arg1, arg2);
            return arg1;
        }

        static void Main(string[] args)
        {
            List<Park> ParkList = InitializeParkList();
            List<Car> CarList = InitializeCarList(ParkList);

            DisplayParks(ParkList);
            DisplayCars(CarList,ParkList[1]);
            Console.ReadLine();
            AddCar(CarList, ParkList[1]);
            RemoveCar(CarList, ParkList[1]);
            Console.ReadLine();

        }
    }
}
