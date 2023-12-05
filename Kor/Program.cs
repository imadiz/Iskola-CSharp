using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Color = System.Drawing.Color;

namespace Kor
{
    internal class Program
    {
        class Circle
        {
            internal Point Center;
            internal double Radius;

            internal void ModifyRadius(double amount)
            {
                Radius += amount;
                Console.WriteLine($"Megváltozott a kör sugara, új adatok:");
                GetArea();
                GetCircumference();
            }

            internal void GetArea()
            {
                Console.WriteLine($"A kör területe: {Math.Pow(Radius, 2) * Math.PI}");
            }

            internal void GetCircumference()
            {
                Console.WriteLine($"A kör kerülete: {2 * Radius * Math.PI}");
            }

            internal Circle(double radius, Point center = new Point())
            {
                this.Center = center;
                this.Radius = radius;
            }
        }

        class ColoredCircle : Circle
        {
            internal Color Background;
            internal ColoredCircle(double radius, Point center, Color BackGround) : base(radius: radius, center: center)
            {
                this.Center = center;
                this.Radius = radius;
                this.Background = BackGround;
            }
        }
        static void Main(string[] args)
        {
            Circle kor = new Circle(5, new Point(0, 0));

            kor.GetArea();
            kor.GetCircumference();

            Console.WriteLine($"Kör adatai: \n" +
                              $"\tKözéppont: {kor.Center}\n" +
                              $"\tSugár: {kor.Radius}\n");

            kor.ModifyRadius(156789);

            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
        }
    }
}