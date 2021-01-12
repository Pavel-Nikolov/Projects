using System;
using System.Collections.Generic;
using System.Linq;

namespace Logistics
{
    class Program
    {
        static void Main(string[] args)
        {
            int N;
            List<Employee> employees = new List<Employee>();
            Console.WriteLine("Enter Number of Employees");
            do
            {
                N = int.Parse(Console.ReadLine());
            } while (N < 5 || N > 30);

            for (int i = 0; i < N; i++)
            {
                employees.Add(GetEmployee());
            }

            Console.WriteLine(string.Join(Environment.NewLine, employees));
            Console.WriteLine(Environment.NewLine);

            List<Employee> rndEmployees = EmployeeManager.GetRandom(employees);
            EmployeeManager.WriteToFile(rndEmployees, "Employee_name.txt");

            List<Employee> highlyPaid = EmployeeManager.GetHighlyPaid(employees, 1500);
            Console.WriteLine(string.Join(Environment.NewLine, highlyPaid));
            EmployeeManager.WriteToFile(highlyPaid, "money.txt");
            Console.WriteLine(Environment.NewLine);

            List<Employee> sorted = EmployeeManager.GetSorted(employees);
            Console.WriteLine(string.Join(Environment.NewLine, sorted));
            EmployeeManager.WriteToFile(sorted, "sort_name.txt");
        }

        private static Employee GetEmployee()
        {
            try
            {
                Console.WriteLine("Enter info in this format: {names} {position} {salary} {expirience}");
                string[] input = Console.ReadLine().Split();
                if (input.Length < 4)
                {
                    throw new Exception("Write all information");
                }
                string name = string.Join(" ", input.Take(input.Length - 3));
                string position = input[input.Length - 3];
                decimal salary = decimal.Parse(input[input.Length - 2]);
                int expirience = int.Parse(input[input.Length - 1]);

                return EmployeeManager.GetEmployee(name, position, salary, expirience);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return GetEmployee();
            }
        }
    }
}
