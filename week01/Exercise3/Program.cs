using System;
//Thomas Barney
class Program
{
    static void Main(string[] args)
    {
        Random rnd = new Random();
        int randomNumber = rnd.Next(1, 101);
        int guess = 0;

        while (guess != randomNumber)
        {
            Console.Write("Guess the number (1-100): ");
            guess = int.Parse(Console.ReadLine());

            if (guess == randomNumber)
            {
                Console.WriteLine("Congratulations! You guessed the right number.");
            }
            else if (guess < randomNumber)
            {
                Console.WriteLine("Your guess is too low.");
            }
            else if (guess > randomNumber)
            {
                Console.WriteLine("Your guess is too high.");
            }
        }
    }
}