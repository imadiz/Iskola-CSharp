using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _20231130
{
    class Varos
    {
        public int Helyezes { get; set; }
        public string Varosnev { get; set; }
        public string Orszag { get; set; }
        public int Nepesseg { get; set; }

        public Varos(string sor)
        {
            string[] reszek = sor.Split(';');
            Helyezes = int.Parse(reszek[0]);
            Varosnev = reszek[1];
            Orszag = reszek[2];
            Nepesseg = int.Parse(reszek[3]);
        }
    }
    class Fajlkezeles
    {
        static void Main(string[] args)
        {
            Fajlbeolvasas();
            Console.Write("Press any key to continue...");
            Console.ReadKey();
        }
        static void Fajlbeolvasas()
        {
            List<Varos> lista = new List<Varos>();
            string elsosor = "";

            try
            {
                StreamReader sr = new StreamReader("../../varosok.txt");
                elsosor = sr.ReadLine();
                while (!sr.EndOfStream)
                {
                    Varos sor = new Varos(sr.ReadLine());
                    lista.Add(sor);
                }
                sr.Close();
            }

            catch (FileNotFoundException ex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(ex.Message);
                Console.WriteLine("Rosszul adtad meg az elérési utat!");
            }

            catch (FormatException ex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(ex.Message);
                Console.WriteLine("Valamelyik típuskonverzió nem jó");
            }

            catch (Exception ex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(ex.Message);
                Console.WriteLine("Valami hiba történt!");
            }

            Console.ResetColor();
            foreach (var item in lista)
            {
                Console.WriteLine($"{item.Varosnev} - {item.Orszag}");
            }

            try
            {
                var kinai = lista.Where(x => x.Orszag == "Kína");
                StreamWriter sw = new StreamWriter("../../kinaivarosok.txt");
                sw.WriteLine(elsosor);
                foreach (var it in kinai)
                {
                    sw.WriteLine($"{it.Helyezes};{it.Varosnev};{it.Orszag};{it.Nepesseg}");
                }
                sw.Flush();
                sw.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}