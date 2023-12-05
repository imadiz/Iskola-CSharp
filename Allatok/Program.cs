using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace Allatok
{
    internal class Program
    {
        public abstract class Animal
        {
            protected internal DateTime BirthDate;
            protected internal string Type;
            protected internal string Name;
            protected internal bool Wild;
            protected internal void WriteName()
            {
                Console.WriteLine($"{this.GetType().Name} példány neve: {Name}");
            }
            protected internal virtual void MakeSound()
            {
                Console.WriteLine("No animal given");
            }

            protected internal virtual string AllBaseProperties()
            {
                return $"{Name} fajtája: {Type}\n" +
                       $"\tVadállat?\t{Wild}\n" +
                       $"\tSzületett\t{BirthDate:yyyy/MM/dd}";
            }
        }
        public class Cat : Animal
        {
            internal Color FurColor;
            protected internal override void MakeSound()
            {
                Console.WriteLine("Meow");
            }

            protected internal Cat(string Name, string Type, bool Wild, Color FurColor)
            {
                this.Name = Name;
                this.Type = Type;
                this.Wild = Wild;
                this.FurColor = FurColor;
            }

        }

        public class Dog : Animal
        {
            internal Color FurColor;
            protected internal override void MakeSound()
            {
                Console.WriteLine("Woof");
            }

            protected internal Dog(string Name, string Type, bool Wild, Color FurColor)
            {
                this.Name = Name;
                this.Type = Type;
                this.Wild = Wild;
                this.FurColor = FurColor;
            }
        }

        static void Main(string[] args)
        {
            Cat Macska = new Cat("Skorbut", "Brit Rövidszőrű", false, Colors.Gray);
            Macska.MakeSound();
            Macska.WriteName();


            Dog Kutya = new Dog("Dömper", "Fehér", false, Colors.White);
            Kutya.MakeSound();
            Kutya.WriteName();



            Console.WriteLine("Press ENTER to continue...");
            Console.ReadKey();
        }
    }
}