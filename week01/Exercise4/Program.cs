using System;
using System.Collections.Generic;
using System.Linq;
// Thomas Barney
class Program
{
    static void Main(string[] args)
    {
        List<int> numbers = new List<int>();
        int number = -1;

        
        while (number != 0)
        {
            Console.Write("Enter a number (0 to quit): ");
            number = int.Parse(Console.ReadLine());
            if (number != 0)
            {
                numbers.Add(number);
            }
        }

        int sum = numbers.Sum();
        Console.WriteLine($"The sum is: {sum}");

        
        double average = numbers.Count > 0 ? numbers.Average() : 0;
        Console.WriteLine($"The average is: {average}");

        
        int max = numbers.Count > 0 ? numbers.Max() : 0;
        Console.WriteLine($"The largest number is: {max}");
    }
}