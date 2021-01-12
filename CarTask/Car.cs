using System;
using System.Collections.Generic;
using System.Text;

namespace CarTask
{
    class Car
    {
        //свойства на  колата и тяхната валидация 
        private string model;

        public string Model
        {
            get { return model; }
            private set 
            {
                if (value.Length > 30)
                {
                    throw new ArgumentException("Model and brand must be no more than 30 simbols");
                }
                model = value; 
            }
        }

        private int yearOfManufacture;

        public int YearOfManufacture
        {
            get { return yearOfManufacture; }
            private set 
            {
                if (value < 1880 || value > DateTime.Now.Year)
                {
                    throw new ArgumentException("Invalid year");
                }
                yearOfManufacture = value;
            }
        }
        private int enginePower;

        public int EnginePower
        {
            get { return enginePower; }
            private set 
            {
                if (value < 0)
                {
                    throw new ArgumentException("Power must be positive number");
                }
                enginePower = value; 
            }
        }
        private decimal price;

        public decimal Price
        {
            get { return price; }
            private set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Price cannot be negative");
                }
                price = value; 
            }
        }

        //ком
        public Car(string model, int yearOfManufacture, int enginePower, decimal price)
        {
            Model = model;
            YearOfManufacture = yearOfManufacture;
            EnginePower = enginePower;
            Price = price;
        }

        public override string ToString()
        {
            return $"{this.Model} - manufactured: {this.YearOfManufacture}, power: {this.EnginePower}, price: {this.Price}";
        }
    }
}
