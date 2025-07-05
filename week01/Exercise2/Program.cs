using System;
//Thomas Barney
class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Enter a grade (0-100):");
        int Grade = int.Parse(Console.ReadLine());

        if (Grade >= 90)
        {
            Console.WriteLine("A");
        }
        else if (Grade >= 80)
        {
            Console.WriteLine("B");
        }
        else if (Grade >= 70)
        {
            Console.WriteLine("C");
        }
        else if (Grade >= 60)
        {
            Console.WriteLine("D");
        }
        else
        {
            Console.WriteLine("F");
        }
    }
}