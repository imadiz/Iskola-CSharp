using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _09_21
{
    internal class Program
    {
        class Person
        {
            public string Name { get; protected set; }
            public string Residence { get; set; }
            public int[] BirthDate = new int[3];//Day, Month, Year

            public int GetBirthDate(string nameofdate)
            {
                switch (nameofdate)
                {
                    case "Év":
                        return BirthDate[2];
                    case "Hónap":
                        return BirthDate[1];
                    case "Nap":
                        return BirthDate[0];
                    default:
                        return -1;
                }
            }

            public DateTime Age()
            {
                DateTime WholeBirthDate = new DateTime();
                TimeSpan AgeOfPerson;

                WholeBirthDate = new DateTime(BirthDate[2], BirthDate[1], BirthDate[0]);

                AgeOfPerson = DateTime.Now - WholeBirthDate;

                return new DateTime(AgeOfPerson.Ticks);
            }

            public Person(string name = "", string residence = "", int[] birthdate = null)
            {
                this.Name = name;
                this.Residence = residence;
                this.BirthDate = birthdate;
            }
        }
        class Employee : Person
        {
            public string Post { get; set; }
            public double Wage { get; set; }

            public void RaiseWage(double raise)
            {
                Wage *= 1 + raise / 100;
            }

            public Employee(string name = "", string residence = "", int[] birthdate = null, string post = "", int wage = 0) : base(name, residence, birthdate)
            {
                this.Name = name;
                this.Residence = residence;
                this.BirthDate = birthdate;
                this.Post = post;
                this.Wage = wage;
            }
        }
        static void Main(string[] args)
        {
            int[] dateofbirth = { 01, 04, 2005 };
            Employee emp1 = new Employee("Mohammed", "Desert", dateofbirth, "Allah's strongest soldier", 1);

            Console.WriteLine($"Info about first employee:\n" +
                              $"\tName | {emp1.Name}\n" +
                              $"\tResidence | {emp1.Residence}\n" +
                              $"\tAge | {emp1.Age():yy/MM/dd}\n" +
                              $"\tPost | {emp1.Post}\n" +
                              $"\tWage | {emp1.Wage}");

            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
        }
    }
}

}
