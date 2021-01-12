using System;
using System.Collections.Generic;
using System.Linq;

namespace CarTask
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Car> cars = new List<Car>();
            
            int N;
            do
            {
                Console.WriteLine("Enter number of cars");
                N = int.Parse(Console.ReadLine());
            } while (N < 6 || N > 50);

            for (int i = 0; i < N; i++)
            {
                cars.Add(GetCar());
            }

            Console.WriteLine(string.Join(Environment.NewLine, cars));
            CarManager.WriteToFile(cars, "cars.txt");

            List<Car> powerfull = GetPowerfull(cars, 184);
            Console.WriteLine(string.Join(Environment.NewLine, powerfull));
            CarManager.WriteToFile(powerfull, "power.txt");

            List<Car> sorted = GetSorted(cars);
            CarManager.WriteToFile(sorted, "sortedprice.txt");
        }

        private static List<Car> GetSorted(List<Car> cars)
        {
            return cars.OrderBy(x => x.Price).ToList();
        }

        private static List<Car> GetPowerfull(List<Car> cars, int power)
        {
            return cars.Where(x => x.EnginePower > power).ToList();
        }

        static Car GetCar()
        {
            try
            {
                Console.WriteLine("Enter model, year, power and price");
                string model = Console.ReadLine();
                int year = int.Parse(Console.ReadLine());
                int power = int.Parse(Console.ReadLine());
                decimal price = decimal.Parse(Console.ReadLine());

                return CarManager.CreateCar(model, year, power, price);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Unexpected errow has occured: {ex.Message}");
                return GetCar();
            }
        }
    }
}
