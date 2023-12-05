using System;
using System.Collections.Generic;
using System.Linq;

namespace OOP_Példák
{
    internal class Program
    {
        class Tanulo
        {
            public string nev;
            public int szulido;
            public string szulhely = "Budapest";

            public void Udvozlet()
            {
                Console.WriteLine($"Helló {this.nev}");
            }

            public Tanulo(string nev, int szulido, string szulhely = null)
            {
                this.nev = nev;
                this.szulido = szulido;
                this.szulhely = szulhely;
            }
        }
        class Gyumolcs
        {
            public string nev;
            private int _ar;
            public int Ar
            {
                get => _ar;
                set => _ar = value;
            }

        }
        class Car
        {
            public string Rendszam { get; set; }
            public string Model { get; set; }
            public int Evjarat { get; set; }

            public DateTime CalculateAge()
            {
                return DateTime.Now.AddYears(Evjarat * -1);
            }

            public Car(string Rendszam, string Model, int Evjarat)
            {
                this.Rendszam = Rendszam;
                this.Model = Model;
                this.Evjarat = Evjarat;
            }
        }
        static void Main(string[] args)
        {
            Tanulo tan1 = new Tanulo(szulhely: "Bp", szulido: 2005, nev: "Gipsz Jakab");
            Gyumolcs Gyumi1 = new Gyumolcs()
            {
                nev = "Alma"
            };

            List<Tanulo> tanulok = new List<Tanulo>();

            Car Auto = new Car("ABC - 123", "Passat", 2005);

            Console.WriteLine($"Autó kora: {Auto.CalculateAge()}");

            Console.WriteLine($"Tanulói adatok\n\tNév:\t{tan1.nev}\n\tSzületési év:\t{tan1.szulido}\n\tSzületési hely:\t{tan1.szulhely}");

            Console.ReadKey();
        }
    }
}