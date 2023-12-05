using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hibakezelés
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Kérek egy páros számot:");
            EvenNumberInput(Console.ReadLine());
        }
        public static void EvenNumberInput(string input)
        {
            int evennum = 0;
            try
            {
                evennum = int.Parse(input);
            }
            catch (Exception) when (evennum % 2 == 0)
            {

            }
        }
        public static void WriteError(string message)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(message);
            Console.ResetColor();
        }
    }
}
