using System;
//Thomas Barney
class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Enter a grade (0-100):");
        int Letter = int.Parse(Console.ReadLine());

        if (Letter >= 90)
        {
            Console.WriteLine("A");
        }
        else if (Letter >= 80)
        {
            Console.WriteLine("B");
        }
        else if (Letter >= 70)
        {
            Console.WriteLine("C");
        }
        else if (Letter >= 60)
        {
            Console.WriteLine("D");
        }
        else
        {
            Console.WriteLine("F");
        }
        if (Letter >= 70)
        {
            Console.WriteLine("Congratulations, you passed!");
        }
    }
}