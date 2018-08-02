using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    class Program
    {
        public static Array ParkList()
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

            //collect parks to an array
            Park[] ParkList = { Detpark, Lonpark };
            return ParkList;
        }

        static void DisplayParks(Array arg)
        {
            Console.WriteLine("Here are all available car parks:\n");
            Console.WriteLine("Name   City   Address");
            foreach (Park item in arg)
            {
                item.DisplayPark();
            }
            Console.ReadLine();
        }

        public static List<Car> InitializeCarList()
        {
            //create new cars
            Car car1 = new Car();
            car1.brand = "Toyota";
            car1.model = "Prius";
            car1.driver = "John";
            car1.color = "yellow";
            car1.year = 2008;
            car1.vin = "112233";
            car1.parts = "parts";

            Car car2 = new Car();
            car2.brand = "Dodge";
            car2.model = "Charger";
            car2.driver = "Mike";
            car2.color = "brown";
            car2.year = 1967;
            car2.vin = "223344";
            car2.parts = "parts";

            Car car3 = new Car();
            car3.brand = "BMW";
            car3.model = "M3";
            car3.driver = "Alex";
            car3.color = "blue";
            car3.year = 2008;
            car3.vin = "112233";
            car3.parts = "parts";

            //collect cars to an array
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

        static void DisplayCars(List<Car> arg)
        {
            Console.WriteLine("Here are all available cars:\n");
            Console.WriteLine("Driver   Brand   Model   Year   VIN   Color   Parts");
            foreach (Car item in arg)
            {
                item.DisplayCar();
            }
            Console.ReadLine();
        }

        public static List<Car> AddCar(List<Car> arg)
        {
            Car newCar = new Car();
            newCar.brand = "Aston Martin";
            newCar.model = "DB9";
            newCar.driver = "James";
            newCar.color = "silver";
            newCar.year = 2003;
            newCar.vin = "445566";
            newCar.parts = "parts";

            arg.Add(newCar);
            DisplayCars(arg);
            return arg;
        }

        public static List<Car> RemoveCar(List<Car> arg)
        {
            var itemToRemove = arg.SingleOrDefault(car => car.driver == "Mike");
            if (itemToRemove != null)
                arg.Remove(itemToRemove);
            DisplayCars(arg);
            return arg;
        }

        static void Main(string[] args)
        {
            List<Car> CarList = InitializeCarList();

            //DisplayParks(ParkList());
            DisplayCars(CarList);
            Console.ReadLine();
            AddCar(CarList);
            RemoveCar(CarList);
            Console.ReadLine();

        }
    }
}
