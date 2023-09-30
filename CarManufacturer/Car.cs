using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Channels;
using System.Threading.Tasks;

namespace CarManufacturer
{
    public class Car
    {
        private string make;
        private string model;
        private int year;
        private int horsePower;
        private double fuelQuantity;
        private double fuelConsumption;
        private int engineIndex;
        private int tiresIndex;
        private double totalPressure;


        public Car(string make, string model, int year, int horsePower, double fuelQuantity,
            double fuelConsumption, int engineIndex, int tiresIndex, double totalPressure)
        {
            Make = make;
            Model = model;
            Year = year;
            HorsePower = horsePower;
            FuelQuantity = fuelQuantity;
            FuelConsumption = fuelConsumption;
            EngineIndex = engineIndex;
            TiresIndex = tiresIndex;
            TotalPressure = totalPressure;
        }


        public string Make
        {
            get { return make;}
            set { make = value;}
        }
        public string Model
        {
            get { return model; }
            set { model = value; }
        }

        public int Year
        {
            get { return year; }
            set { year = value; }
        }

        public int HorsePower
        {
            get { return horsePower; }
            set { horsePower = value; }
        }
        public double FuelQuantity
        {
            get { return fuelQuantity; }
            set { fuelQuantity = value; }
        }
        public double FuelConsumption
        {
            get { return fuelConsumption; }
            set { fuelConsumption = value; }
        }
        public int EngineIndex
        {
            get { return engineIndex; }
            set { engineIndex = value; }
        }

        public int TiresIndex
        {
            get { return tiresIndex; }
            set { tiresIndex = value; }
        }
        
        public double TotalPressure
        {
            get { return totalPressure; }
            set { totalPressure = value; }
        }

        public double DriveTwentyKm(double fuelQuantity, double fuelConsumption)
        {
            fuelQuantity -= (FuelConsumption / 100) * 20;

            return fuelQuantity;
        }
    }

}

public class Engine
{
    private int horsePower;

    public int HorsePower
    {
        get { return horsePower; }
        set { horsePower = value; }
    }


    private double cubicCapacity;

    public double CubicCapacity
    {
        get { return cubicCapacity; }
        set { cubicCapacity = value; }
    }

    public Engine(int horsePower, double cubicCapacity)
    {
        HorsePower = horsePower;
        CubicCapacity = cubicCapacity;
    }

    public int GetHorsePower(string[] splitFirstInput)
    {
        int horsePower = int.Parse(splitFirstInput[0]);

        return horsePower;
    }

    public double GetCubicCapacity(string[] splitFirstInput)
    {
        double cubicCapacity = double.Parse(splitFirstInput[1]);

        return cubicCapacity;
    }
}

public class Tire
{
    private int year;

    public int Year
    {
        get { return year; }
        set { year = value; }
    }

    private double pressure;

    public double Pressure
    {
        get { return pressure; }
        set { pressure = value; }
    }

    public Tire(int year, double pressure)
    {
        Year = year;
        Pressure = pressure;
    }

    public List<double> GetYearInfo(string[] splitSecondInput)
    {
        List<double> yearsList = new List<double>();

        for (int i = 0; i < splitSecondInput.Length; i += 2)
        {
            yearsList.Add(int.Parse(splitSecondInput[i]));
        }

        return yearsList;
    }

    public List<double> GetPressureInfo(string[] splitSecondInput)
    {
        List<double> pressureList = new List<double>();

        for (int i = 1; i < splitSecondInput.Length; i += 2)
        {
            pressureList.Add(double.Parse(splitSecondInput[i]));
        }

        return pressureList;
    }

    public double GetSumPressure(List<List<double>> tirePressureList,
        int tires)
    {
        double sumPressure = tirePressureList[tires].Sum();

        return sumPressure;
    }
}
