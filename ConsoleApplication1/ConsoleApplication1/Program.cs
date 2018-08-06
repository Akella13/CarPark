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

            //add parts to car1
            Part part001111 = new Part();
            part001111.partType = "engine oil";
            part001111.partExpDate = "7000 km";
            part001111.partNumber = 001111;
            car1.carParts.Add(part001111);
            Part part001112 = new Part();
            part001112.partType = "oil filter";
            part001112.partExpDate = "4600 km";
            part001112.partNumber = 001111;
            car1.carParts.Add(part001112);
            Part part001113 = new Part();
            part001113.partType = "front brake shoe";
            part001113.partExpDate = "1 year";
            part001113.partNumber = 001111;
            car1.carParts.Add(part001113);


            Car car2 = new Car();
            car2.carPark = arg[0];
            car2.carBrand = "Dodge";
            car2.carModel = "Charger";
            car2.carDriver = "Mike";
            car2.carColor = "brown";
            car2.carYear = 1967;
            car2.carVin = "223344";

            Car car3 = new Car();
            car3.carPark = arg[0];
            car3.carBrand = "BMW";
            car3.carModel = "M3";
            car3.carDriver = "Alex";
            car3.carColor = "blue";
            car3.carYear = 2008;
            car3.carVin = "112233";

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

        public static List<Car> SortByDriver(List<Car> arg1, bool desc)
        {
            if (desc == false)
            {
                arg1 = arg1.OrderBy(car => car.carDriver).ToList();
            }
            else
            {
                arg1 = arg1.OrderByDescending(car => car.carDriver).ToList();
            }
            Console.WriteLine("Sorted by driver");
            DisplayAllCars(arg1);
            return arg1;
        }
        public static List<Car> SortByColor(List<Car> arg1, bool desc)
        {
            if (desc == false)
            {
                arg1 = arg1.OrderBy(car => car.carColor).ToList();
            }
            else
            {
                arg1 = arg1.OrderByDescending(car => car.carColor).ToList();
            }
            Console.WriteLine("Sorted by color");
            DisplayAllCars(arg1);
            return arg1;
        }
        public static List<Car> SortByYear(List<Car> arg1, bool desc)
        {
            if (desc == false)
            {
                arg1 = arg1.OrderBy(car => car.carYear).ToList();
            }
            else
            {
                arg1 = arg1.OrderByDescending(car => car.carYear).ToList();
            }
            Console.WriteLine("Sorted by year");
            DisplayAllCars(arg1);
            return arg1;
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

            Part newPart1 = new Part();
            newPart1.partType = "engine oil";
            newPart1.partExpDate = "1 year";
            newPart1.partNumber = 001111;
            newCar.AddPart(newPart1);
            Part newPart2 = new Part();
            newPart2.partType = "oil filter";
            newPart2.partExpDate = "5000 km";
            newPart2.partNumber = 001111;
            newCar.AddPart(newPart2);
            Part newPart3 = new Part();
            newPart3.partType = "front brake shoe";
            newPart3.partExpDate = "1900 km";
            newPart3.partNumber = 001111;
            newCar.AddPart(newPart3);
            

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

        public static void TransferPart(List<Car> arg1, Car arg2, Car arg3, Part arg4)
        {
            if (arg4.partType.Contains("oil") || arg4.partType.Contains("fluid"))
            {
                Console.WriteLine("Cannot transfer liquid parts");
                Console.ReadLine();
            }
            else if (arg2.carBrand != arg3.carBrand)
            {
                Console.WriteLine("Cannot transfer part, they must be of the same car brand");
                Console.ReadLine();
            }
            else if (arg2.carModel != arg3.carModel)
            {
                Console.WriteLine("Cannot transfer part, they must be of the same model");
                Console.ReadLine();
            }
            else if (arg2.carModel == arg3.carModel && arg2.carBrand == arg3.carBrand)
            {
                arg2.RemovePart(arg4);
                arg3.AddPart(arg4);
                DisplayAllCars(arg1);
            }
        }

        static void Main(string[] args)
        {
            List<Park> ParkList = InitializeParkList();
            List<Car> CarList = InitializeCarList(ParkList);

            //DisplayParks(ParkList);
            DisplayAllCars(CarList);
            CarList[0].DisplayParts();
            Part newpart1 = new Part();
            newpart1.partType = "some";
            newpart1.partExpDate = "5600km";
            newpart1.partNumber = 001122;

            CarList[1].AddPart(newpart1);
            newpart1.PartContainingCar(CarList).DisplayParts();
            DisplayAllCars(CarList);
            CarList[1].Maintenance();
            CarList[1].DisplayParts();
        }
    }
}
