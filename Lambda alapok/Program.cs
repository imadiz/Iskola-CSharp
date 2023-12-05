using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Schema;

namespace Lambda_alapok
{
    internal class Program
    {
        class Dolgozo
        {
            public string nev { get; set; }
            public int szulido { get; set; }
            public string varos { get; set; }
            public string munkakor { get; set; }
        }
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
        static List<Dolgozo> dolgozok = new List<Dolgozo>();
        static void Main(string[] args)
        {
            TanarurMunkaja();

            List<int> Numbers = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
            List<int> EvenNumbers = new List<int>();

            foreach (int szam in Numbers)
            {
                if (szam % 2 == 0)
                    EvenNumbers.Add(szam);
            }

            EvenNumbers.Clear();

            EvenNumbers = Numbers.FindAll(x => x % 2 == 0);

            Console.WriteLine("Páros számok:");

            foreach (int item in EvenNumbers)
            {
                Console.WriteLine($"\t{item}");
            }

            List<string> dist = dolgozok.Select(x => x.varos).Distinct().ToList();
            Console.WriteLine("Különböző városok:");

            foreach (string varos in dist)
            {
                Console.WriteLine($"\t{varos}");
            }

            //7. Min, Max, Count, Sum, Avg



            Console.ReadKey();
        }
        static void TanarurMunkaja()
        {
            var d1 = new Dolgozo
            {
                nev = "Csaba",
                szulido = 2006,
                varos = "Budapest",
                munkakor = "fejlesztő"
            };
            var d2 = new Dolgozo
            {
                nev = "Ádám",
                szulido = 2005,
                varos = "Vác",
                munkakor = "fejlesztő"
            };
            var d3 = new Dolgozo
            {
                nev = "Jónás",
                szulido = 2000,
                varos = "Budapest",
                munkakor = "igazgató"
            };
            var d4 = new Dolgozo
            {
                nev = "Júlia",
                szulido = 2002,
                varos = "Eger",
                munkakor = "takarító"
            };
            dolgozok.Add(d1);
            dolgozok.Add(d2);
            dolgozok.Add(d3);
            dolgozok.Add(d4);

            foreach (var d in dolgozok)
            {
                if (d.varos == "Budapest")
                {
                    //  Console.WriteLine($"\tnév: {d.nev} város: {d.varos}");
                }
            }

            //1. listázzuk ki a dolgozókat (select * from dolgozok)
            var result = from d in dolgozok
                         select d;

            foreach (var item in result)
            {
                Console.WriteLine($"név: {item.nev} munkakör: {item.munkakor}");
            }

            //2. listázzuk ki a dolgozók nevét (select nev from dolgozok)
            var name = from d in dolgozok
                       select d.nev;

            foreach (var n in name)
            {
                Console.WriteLine($"név: {n}");
            }

            //3. listázzuk ki a dolgozók nevét és munkakörét
            var nev_munka = from d in dolgozok
                            select new
                            {
                                d.nev,
                                d.munkakor
                            };

            foreach (var item in nev_munka)
            {
                Console.WriteLine($"név: {item.nev} munkakör: {item.munkakor}");
            }

            //4. listázzuk ki a budapesti dolgozókat
            var bp = from d in dolgozok
                     where d.varos == "Budapest"
                     select d;

            Console.WriteLine("Budapestiek:");
            foreach (var item in bp)
            {
                Console.WriteLine($"név: {item.nev} város: {item.varos}");
            }

            //5. budapesti fejlesztők
            var bpfejlesztok = from d in dolgozok
                               where d.varos == "Budapest"
                               where d.munkakor == "fejlesztő"
                               select d;
            Console.WriteLine("Budapesti fejlesztők:");
            foreach (var item in bpfejlesztok)
            {
                Console.WriteLine($"név: {item.nev} város: {item.varos}");
            }

            //6. rendezés növekvő név szerint
            var rendezett = from d in dolgozok
                            orderby d.nev
                            select d;

            foreach (var item in rendezett)
            {
                Console.WriteLine($"név: {item.nev}");
            }

            //7. rendezés csökkenő név szerint
            var csokkeno = from d in dolgozok
                           orderby d.nev descending
                           select d;

            foreach (var item in csokkeno)
            {
                Console.WriteLine($"név: {item.nev}");
            }

            //8. csak egyedi értékek
            var egyedi = (from d in dolgozok
                          select d.varos).Distinct();
            //vagy egyedi.Distinct()
            foreach (var item in egyedi)
            {
                Console.WriteLine($"név: {item}");
            }

            //9. csoportosító függvények (count, sum, min, max, avg)
            var darab = (from d in dolgozok
                         select d).Count();
            Console.WriteLine($"Dolgozók száma: {darab}");

            var min = (from d in dolgozok
                       select d.szulido).Min();
            Console.WriteLine($"Legidősebb: {min}");

            var darabbp = (from d in dolgozok
                           where d.varos == "Budapest"
                           select d).Count();
            Console.WriteLine($"Budapestiek száma: {darabbp}");

            //10. group by
            var csoport = from d in dolgozok
                          group d by d.varos;
            Console.WriteLine("Group by varos");
            foreach (var item in csoport)
            {
                Console.WriteLine(item.Key + " " + item.Count());
            }

            //11. budapesti vagy fejlesztő
            var fejlesztok = from d in dolgozok
                             where d.varos == "Budapest"
                             || d.munkakor == "fejlesztő"
                             select d;
            Console.WriteLine("Budapesti vagy fejlesztő:");
            foreach (var item in fejlesztok)
            {
                Console.WriteLine($"név: {item.nev} város: {item.varos}");
            }
        }
    }
}