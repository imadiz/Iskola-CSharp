using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EqualsTesting
{
    internal class Program
    {
        static int CompareCount = 0;
        static void Main(string[] args)
        {
            Compare<string>(new string[]{ "a", "b"});
            Compare<int>(new int[] {(byte)1, (sbyte)1});
            Console.Write("Press any key to continue...");
            Console.ReadKey();
        }
        static void Compare<T>(T[] first_second) where T : IEquatable<T>
        {
            T first = first_second[0];
            T second = first_second[1];
            Console.WriteLine($"Compare<{typeof(T)}> #{CompareCount} | {first.GetType()}: {first} & {second.GetType()}: {second}");
            CompareCount++;
            Console.WriteLine($"\tEquals: {first.Equals(second)}");
            Console.WriteLine($"\tReferenceEquals: {ReferenceEquals(first, second)}");
        }
    }
}
