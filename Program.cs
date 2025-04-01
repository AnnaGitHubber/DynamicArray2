using System;

namespace DynamicArray2
{
    class Program
    {
        public static void Main()
        {
            DynamicArray arr = new DynamicArray();

            arr.Add(3);
            arr.Add(-2);
            arr.Add(5);
            arr.Add(10);
            arr.Add(5);
            arr.Add(-1);
            arr.Add(5);
            arr.Print();

            arr.RemoveAt(1);
            arr.Print();

            Console.WriteLine($"Index of 5: {arr.IndexOf(5)}");
            Console.WriteLine($"Sum of positive elements: {arr.SumPositive()}");
            Console.WriteLine($"Product between max|x| and min|x|: {arr.ProductBetweenExtremes()}");

            var (value, length) = arr.LongestSequence();
            Console.WriteLine($"Longest sequence: Value {value}, Length {length}");
        }
    }
}