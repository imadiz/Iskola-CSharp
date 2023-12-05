using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Oroklodes
{
    class Program
    {
        public class Jarmu
        {
            public string Marka { get; set; }
            protected internal int EvJarat;
            protected internal void Duda()
            {
                Console.WriteLine("Jármű doot");
            }
        }
        public class Car : Jarmu
        {
            public string RendSzam { get; set; }
            public string Tipus { get; set; }
            public void writeMarka()
            {
                Console.WriteLine($"Autó márkája: {Marka}");
            }
        }

        static void Main(string[] args)
        {


            Console.WriteLine("Press enter to continue...");
            Console.ReadLine();
        }
        static void Brumm()
        {
            Car egy = new Car();
            egy.Marka = "Opel";
            egy.Tipus = "Astra";
            egy.RendSzam = "HIV-123";
            egy.EvJarat = 1994;

            egy.Duda();
            egy.writeMarka();

            Console.WriteLine($"A rendszám: {egy.RendSzam}");
        }
    }
}