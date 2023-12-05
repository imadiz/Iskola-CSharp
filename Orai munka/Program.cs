using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ajandekozas
{
    internal class Program
    {
        static int[] ajandek = { 6, 5, 8, 7, 10, 3, 1, 2, 0, 4, 9 };
        static Dictionary<int, string> nevekkel = new Dictionary<int, string>()
        {
            { 0, "András" },
            { 1, "Béla" },
            { 2, "Cecília" },
            { 3, "Dóra" },
            { 4, "Elemér" },
            { 5, "Fanni" },
            { 6, "Glória" },
            { 7, "Hedvig" },
            { 8, "Ilona" },
            { 9, "József" },
            { 10, "Katalin" }
        };//Feladat 5

        static void Main(string[] args)
        {
            feladat1();
            feladat2();
            feladat3();
            feladat4();
            feladat6();

            Console.WriteLine(nevekkel.Where(x => x.Key == 1).First().Value);

            Console.WriteLine("Nyomj meg valamit a folytatáshoz");
            Console.ReadKey();//Állj meg, hogy látható legyen az eredmény
        }
        static void feladat1()
        {
            double befogo1;
            double befogo2;

            while (true)//Első befogó
            {
                try
                {
                    Console.Write("1.feladat: Kérem a háromszög egyik befogóját: ");
                    befogo1 = Convert.ToDouble(Console.ReadLine());
                    if (befogo1 > 0)
                        break;
                }
                catch (Exception)
                {
                    //Nem sikerült konvertálni, kérd be újra
                }
            }

            while (true)//Második befogó
            {
                try
                {
                    Console.Write("1.feladat: Kérem a háromszög másik befogóját: ");
                    befogo2 = Convert.ToDouble(Console.ReadLine());
                    if (befogo2 > 0)
                        break;
                }
                catch (Exception)
                {
                    //Nem sikerült konvertálni, kérd be újra
                }
            }

            Console.WriteLine($"1.feladat: A háromszög átfogója {Math.Sqrt(Math.Pow(befogo1, 2) + Math.Pow(befogo2, 2)):0.0}");
        }
        static void feladat2()
        {
            Console.WriteLine($"2.feladat: A 7. tanuló a {ajandek[7]}. tanulónak adott ajándékot.");
        }
        static void feladat3()
        {
            Console.WriteLine($"3.feladat: Aki az 5. tanulótól kapott ajándékot az a(z) {ajandek[ajandek[5]]}. tanulónak adott ajándékot.");
        }
        static void feladat4()
        {
            (ajandek[3], ajandek[4]) = (ajandek[4], ajandek[3]);
        }
        static void feladat6()
        {
            Console.Write($"6.feladat: Kérek egy számot: ");
            int id = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine($"6.feladat: {nevekkel[id]} -> {nevekkel[ajandek[id]]}");
        }

    }
}
