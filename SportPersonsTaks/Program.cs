using System;
using System.Collections.Generic;
using System.Linq;

namespace SportPersonsTaks
{
    class Program
    {
        static void Main(string[] args)
        {
            List<SportPerson> sportPersons = new List<SportPerson>();

            int N;
            do
            {
                Console.WriteLine("Enter number of SportPersons");
                N = int.Parse(Console.ReadLine());
            } while (N < 5 || N > 40);

            for (int i = 0; i < N; i++)
            {
                sportPersons.Add(GetSportPerson());
            }

            Console.WriteLine(string.Join(Environment.NewLine, sportPersons));
            PersonManager.WriteToFile(sportPersons, "sport_persons.txt");

            List<SportPerson> longstaying = GetPowerfull(sportPersons, 30);
            Console.WriteLine(string.Join(Environment.NewLine, longstaying));
            PersonManager.WriteToFile(longstaying, "days30.txt");

            List<SportPerson> sorted = GetSorted(sportPersons);
            PersonManager.WriteToFile(sorted, "sort_name.txt");
        }

        private static List<SportPerson> GetSorted(List<SportPerson> SportPersons)
        {
            return SportPersons.OrderBy(x => x.Name).ToList();
        }

        private static List<SportPerson> GetPowerfull(List<SportPerson> SportPersons, int power)
        {
            return SportPersons.Where(x => x.Days > power).ToList();
        }

        static SportPerson GetSportPerson()
        {
            try
            {
                Console.WriteLine("Enter name, eng, status and day");
                string name = Console.ReadLine();
                string egn = Console.ReadLine();
                string status = Console.ReadLine();
                int day = int.Parse(Console.ReadLine());

                return PersonManager.CreateSportPerson(name, egn, status, day);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Unexpected errow has occured: {ex.Message}");
                return GetSportPerson();
            }
        }
    }
}
