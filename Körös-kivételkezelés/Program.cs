using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Körös_kivételkezelés
{
    internal class Program
    {
        class Circle
        {
            public double Radius { get; set; }
            public uint Circumference { get; set; }
            public double Area { get; set; } 

            public double CalculateArea()
            {
                return Math.Pow(Radius, 2) * Math.PI;
            }
            
            public Circle(double radius)
            {
                try
                {
                    this.Radius = radius;
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Hiba történt a kör adatai megadása közben! (Megadott érték: {radius})\n\t{ex.Message}");
                }
            }
        }
        static double input = 0;
        static void Main(string[] args)
        {
            Circle kor = new Circle(RadiusInput());
            Console.WriteLine($"A kör területe: {kor.CalculateArea():0.00}");
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
        }
        static double RadiusInput()
        {
            Console.Write("Kérem a kör sugarát: ");
            try
            {
                input = Convert.ToDouble(Console.ReadLine());
                if (input < 0)
                    throw new Exception("A megadott érték kisebb mint 0!");
            }
            catch (FormatException ex)
            {
                Console.WriteLine("\tA bemeneti érték nem megfelelő, egy számot kell megadni!");
                RadiusInput();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"\t{ex.Message}");
                RadiusInput();
            }

            return input;
        }
    }
}