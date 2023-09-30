using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarManufacturer
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            List<List<double>> listTiresYears = new List<List<double>>();
            List<List<double>> listTiresPressures = new List<List<double>>();
            List<int> listHorsePowers = new List<int>();
            List<double> listCubicCapacity = new List<double>();

            List<Car> listCars = new List<Car>();


            string firstInput = Console.ReadLine();

            Tire tires = new Tire(0,0);
            Engine engine = new Engine(0,0);

            while (firstInput != "No more tires")
            {
                string[] splitFirstInput = firstInput.Split();

                List<double> yearsList = tires.GetYearInfo(splitFirstInput);
                List<double> pressureList = tires.GetPressureInfo(splitFirstInput);

                listTiresYears.Add(yearsList);
                listTiresPressures.Add(pressureList);

                firstInput = Console.ReadLine();
            }

            string secondInput = Console.ReadLine();

            while (secondInput != "Engines done")
            {
                string[] splitSecondInput = secondInput.Split();

                listHorsePowers.Add(engine.GetHorsePower(splitSecondInput));
                listCubicCapacity.Add(engine.GetCubicCapacity(splitSecondInput));

                secondInput = Console.ReadLine();
            }

            string thirdInput = Console.ReadLine();

            while (thirdInput != "Show special")
            {
                string[] splitThirdInput = thirdInput.Split();

                string make = splitThirdInput[0];
                string model = splitThirdInput[1];
                int year = int.Parse(splitThirdInput[2]);
                double fuelQuantity = double.Parse(splitThirdInput[3]);
                double fuelConsumption = double.Parse(splitThirdInput[4]);
                int engineIndex = int.Parse(splitThirdInput[5]);
                int tiresIndex = int.Parse(splitThirdInput[6]);

                int horsePower = listHorsePowers[engineIndex];
                double pressure = tires.GetSumPressure(listTiresPressures, tiresIndex);

                Car car = new Car(make, model, year, horsePower, fuelQuantity, fuelConsumption,
                    engineIndex, tiresIndex, pressure);

                listCars.Add(car);


                thirdInput = Console.ReadLine();
            }

            foreach (var car in listCars)
            {
                if (car.Year >= 2017 && car.HorsePower > 330
                    && car.TotalPressure > 9 && car.TotalPressure < 10)
                {
                    car.FuelQuantity = car.DriveTwentyKm(car.FuelQuantity, car.FuelConsumption);

                    Console.WriteLine($"Make: {car.Make}");
                    Console.WriteLine($"Model: {car.Model}");
                    Console.WriteLine($"Year: {car.Year}");
                    Console.WriteLine($"HorsePowers: {car.HorsePower}");
                    Console.WriteLine($"FuelQuantity: {car.FuelQuantity}");
                }
            }
        }
    }
}

    



