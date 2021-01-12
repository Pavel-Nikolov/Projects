using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Logistics
{
    static class EmployeeManager
    {
        public static Employee GetEmployee(string name, string position, decimal salary, int expirience)
        {
            if (name.Length > 30)
            {
                throw new ArgumentException("Name must be no more than 30 simbols");
            }
            if (position.Length > 35)
            {
                throw new ArgumentException("Position's name must be no more than 35 simbols");
            }
            if (salary < 0)
            {
                throw new ArgumentException("Salary cannot be negative");
            }
            if (expirience < 0)
            {
                throw new ArgumentException("Expirience must be positive number");
            }
            return new Employee(name, position, salary, expirience);
        }

        public static void WriteToFile(List<Employee> employees, string path)
        {
            using (StreamWriter writer = new StreamWriter(path))
            {
                foreach (var item in employees)
                {
                    writer.WriteLine(item);
                }
            }
        }
        public static List<Employee> GetRandom(List<Employee> employees)
        {
            Random random = new Random();
            return employees
                .Take(
                random.Next(employees.Count)
                )
                .ToList();
        }
        public static List<Employee> GetHighlyPaid(List<Employee> employees, int minSalary)
        {
            return employees.Where(x => x.Salary > minSalary).ToList();
        }
        public static List<Employee> GetSorted(List<Employee> employees)
        {
            return employees.OrderBy(x => x.Name).ToList();
        }
    }
}
