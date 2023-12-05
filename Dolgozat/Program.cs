using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dolgozat
{
    internal class Program
    {
        //Számla főosztály
        //egyenleg property
        //lekötött property
        //Folyószámla alosztály
        //Pénzfelvét
        //Pénzbetét
        //kamatszámítás

        abstract class Szamla
        {
            public double Egyenleg;
            public double Lekotott;
            public void PenzFelvet(double osszeg)
            {
                Console.WriteLine($"{this.GetType().Name} számla egyenlegéről ki lett véve {osszeg:N} Ft!");
                Egyenleg -= osszeg;
                Console.WriteLine($"\tÚj érték: {Egyenleg:N} Ft");
            }

            public void PenzBetet(double osszeg)
            {
                Console.WriteLine($"{this.GetType().Name} számla egyenlegére be lett rakva {osszeg:N} Ft!");
                Egyenleg += osszeg;
                Console.WriteLine($"\tÚj érték: {Egyenleg:N} Ft");
            }

            public void Kamat(double szazalek)
            {
                double kamat = 1 + szazalek / 100;
                Console.WriteLine($"{this.GetType().Name} számla lekötött egyenlege ({Lekotott:N} Ft) kamatozott {szazalek}%-al({Lekotott * kamat - Lekotott:N})!");
                Lekotott *= kamat;
                Console.WriteLine($"\tÚj összeg: {Lekotott:N} Ft");
            }

            public void Kiir()
            {
                Console.WriteLine($"A számla tartalma:\n" +
                                  $"\tEgyenleg: {Egyenleg:N} Ft\n" +
                                  $"\tLekötött: {Lekotott:N} Ft");
            }

            public Szamla(double egyenleg, double lekotott = 0)
            {
                Egyenleg = egyenleg;
                Lekotott = lekotott;
            }
        }
        class FolyoSzamla : Szamla
        {
            public FolyoSzamla(double egyenleg, double lekotott = 0) : base(egyenleg, lekotott)
            {
                this.Egyenleg = egyenleg;
                this.Lekotott = lekotott;
            }
        }
        static void Main(string[] args)
        {
            foreach (string item in args)
            {
                Console.WriteLine(item);
            }

            FolyoSzamla elsoszamla = new FolyoSzamla(10000, 90000);
            elsoszamla.Kiir();
            elsoszamla.PenzBetet(15000);
            elsoszamla.PenzFelvet(5000);
            elsoszamla.Kamat(50);
            elsoszamla.Kiir();


            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
        }
    }
}
