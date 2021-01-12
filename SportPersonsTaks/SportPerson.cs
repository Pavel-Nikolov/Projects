using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SportPersonsTaks
{
    class SportPerson
    {
        private string name;

        public string Name
        {
            get { return name; }
            private set 
            {
                if (value.Length > 30)
                {
                    throw new ArgumentException("Too long name");
                }
                name = value; 
            }
        }
        private string egn;

        public string EGN
        {
            get { return egn; }
            private set 
            {
                if (value.Length != 10)
                {
                    throw new ArgumentException("EGN must be 10 digits");
                }
                if (!value.All(x => char.IsDigit(x)))
                {
                    throw new ArgumentException("EGN must be composited from digits");
                }
                egn = value; 
            }
        }
        private string healthStatus;

        public string HealthStatus
        {
            get { return healthStatus; }
            private set 
            {
                if (value.Length > 35)
                {
                    throw new ArgumentException("Too long health status");
                }
                healthStatus = value; 
            }
        }

        private int days;

        public int Days
        {
            get { return days; }
            private set 
            {
                if (days < 0)
                {
                    throw new ArgumentException("Days must be positive");
                }
                days = value; 
            }
        }

        public SportPerson(string name, string eGN, string healthStatus, int days)
        {
            Name = name;
            EGN = eGN;
            HealthStatus = healthStatus;
            Days = days;
        }

        public override string ToString()
        {
            return $"{this.Name} - EGN: {this.EGN}, Status: {this.HealthStatus}, DaysStaying: {this.Days}";
        }
    }
}
