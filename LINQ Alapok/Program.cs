using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace LINQ_Alapok
{
    internal class Program
    {
        public class Worker
        {
            public string Name;
            public string Gender;
            public string Department;
            public int StartedWork;
            public int Wage;

            public Worker(string name, string gender, string department, int startedWork, int wage)
            {
                Name = name;
                Gender = gender;
                Department = department;
                Wage = wage;
                StartedWork = startedWork;
            }
        }

        static List<Worker> AllWorkers = new List<Worker>();

        static void Main(string[] args)
        {
            ReadFile();
            HeadCountDepartment();


            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
        }
        static void ReadFile()
        {
            foreach (string row in File.ReadAllLines("berek2020.txt").Skip(1))
            {
                string[] data = row.Trim().Split(';');
                AllWorkers.Add(new Worker(data[0], data[1], data[2], Convert.ToInt32(data[3]), Convert.ToInt32(data[4])));
            }
        }
        static void HeadCountDepartment()
        {
            IEnumerable<Worker> DistinctDepartments = AllWorkers;

            Console.WriteLine($"Különböző részlegek munkavállaló számai:");

            foreach (Worker item in DistinctDepartments)
            {
                Console.WriteLine($"\t{item.Department}: {AllWorkers.Count(x => x.Department.Equals(item.Department))}");
            }
        }
    }
}
