using System;
// Thomas Barney
class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Welcome to the program!");
        Console.WriteLine("Enter your name:");
        string name = Console.ReadLine();
        Console.WriteLine("Enter your favorite number:");
        int favoriteNumber = int.Parse(Console.ReadLine());

        int square = favoriteNumber * favoriteNumber;
        Console.WriteLine($"Hello {name}, your favorite number is {favoriteNumber}.");
        Console.WriteLine($"The square of your favorite number is {square}.");
    }
}