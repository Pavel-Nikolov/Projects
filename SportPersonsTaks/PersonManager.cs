using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace SportPersonsTaks
{
    static class PersonManager
    {
        public static SportPerson CreateSportPerson(string name, string egn, string status, int days)
        {
            if (name.Length > 30)
            {
                throw new ArgumentException("Too long name");
            }
            if (egn.Length != 10 || !egn.All(x => char.IsDigit(x)))
            {
                throw new ArgumentException("Invalid EGN format");
            }
            if (status.Length > 35)
            {
                throw new ArgumentException("Too long status");
            }
            if (days < 0)
            {
                throw new ArgumentException("Days cannot be negative");
            }

            return new SportPerson(name, egn, status, days);
        }

        public static void WriteToFile(List<SportPerson> SportPersons, string path)
        {
            using (StreamWriter writer = new StreamWriter(path))
            {
                foreach (var SportPerson in SportPersons)
                {
                    writer.WriteLine(SportPerson);
                }
            }
        }
    }
}
