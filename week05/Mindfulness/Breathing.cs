using System;
using System.Threading;

public class BreathingActivity : Activity
{
    public BreathingActivity()
    {
        name = "Breathing";
        description = "This activity will help you relax by walking you through breathing in and out slowly. Clear your mind and focus on your breathing.";
    }

    protected override void RunActivity()
    {
        int timePassed = 0;
        while (timePassed < duration)
        {
            Console.WriteLine("Breathe in through your nose...");
            Countdown(4);
            Console.WriteLine("Hold your breath...");
            Countdown(4);
            Console.WriteLine("Breathe out through your mouth...");
            Countdown(4);
            timePassed += 12;
        }
    }
}
