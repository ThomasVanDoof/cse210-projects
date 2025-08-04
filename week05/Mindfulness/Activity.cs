using System;
using System.Threading;

public abstract class Activity
{
    protected int duration;
    protected string name;
    protected string description;

    public void StartActivity()
    {
        Console.Clear();
        Console.WriteLine($"--- {name} ---");
        Console.WriteLine(description);
        Console.Write("Enter the duration of the activity in seconds: ");
        duration = int.Parse(Console.ReadLine());

        Console.WriteLine("Prepare to begin...");
        Spinner(3);
        Console.Clear();

        RunActivity();

        Console.WriteLine("Well done!");
        Spinner(2);
        Console.WriteLine($"You completed the {name} activity for {duration} seconds.");
        Spinner(3);
    }

    protected abstract void RunActivity();

    protected void Spinner(int seconds)
    {
        string[] spinner = { "|", "/", "-", "\\" };
        DateTime end = DateTime.Now.AddSeconds(seconds);
        int i = 0;
        while (DateTime.Now < end)
        {
            Console.Write(spinner[i++ % spinner.Length]);
            Thread.Sleep(250);
            Console.Write("\b");
        }
    }

    protected void Countdown(int seconds)
    {
        for (int i = seconds; i > 0; i--)
        {
            Console.Write(i);
            Thread.Sleep(1000);
            Console.Write("\b \b");
        }
    }
}
