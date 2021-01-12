using System;
using System.Collections.Generic;
using System.Text;

namespace Logistics
{
    public class Employee
    {
        //свойства на служителя и тяхната валидация 
        private string name;

        public string Name
        {
            get { return name; }
            private set
            {
                if (value.Length > 30)
                {
                    throw new ArgumentException("Name must be no more than 30 simbols");
                }
                name = value;
            }
        }

        private string position;

        public string Position
        {
            get { return position; }
            set 
            {
                if (value.Length > 35)
                {
                    throw new ArgumentException("Position's name must be no more than 35 simbols");
                }
                
                position = value;
            }
        }

        private decimal salary;

        public decimal Salary
        {
            get { return salary; }
            private set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Salary cannot be negative");
                }
                salary = value;
            }
        }

        private int expirience;
        public int Expirience
        {
            get { return expirience; }
            private set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Expirience must be positive number");
                }
                expirience = value;
            }
        }

        public Employee(string name, string position, decimal salary, int expirience)
        {
            Name = name;
            Position = position;
            Salary = salary;
            Expirience = expirience;
        }

        public override string ToString()
        {
            return $"{this.Name} - in position: {this.Position}, salary: {this.Salary}, expirience: {this.Expirience}";
        }
    }
}
  