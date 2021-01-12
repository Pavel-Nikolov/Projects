using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace CarTask
{
    static class CarManager
    {
        public static Car CreateCar(string model, int yearOfManufacture, int enginePower, decimal price)
        {
            if (model.Length > 30)
            {
                throw new ArgumentException("Model and brand must be no more than 30 simbols");
            }
            if (yearOfManufacture < 1880 || yearOfManufacture > DateTime.Now.Year)
            {
                throw new ArgumentException("Invalid year");
            }
            if (enginePower < 0)
            {
                throw new ArgumentException("Power must be positive number");
            }
            if (price < 0)
            {
                throw new ArgumentException("Price cannot be negative");
            }

            return new Car(model, yearOfManufacture, enginePower, price);
        }

        public static void WriteToFile(List<Car> cars, string path)
        {
            using (StreamWriter writer = new StreamWriter(path))
            {
                foreach (var car in cars)
                {
                    writer.WriteLine(car);
                }
            }
        }
    }
}
