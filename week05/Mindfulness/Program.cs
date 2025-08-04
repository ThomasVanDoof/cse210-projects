using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Activity 1: Breathing exercise");
        Console.WriteLine("Activity 2: Meditation");
        Console.WriteLine("Activity 3: Gratitude journaling");
        System.Threading.Thread.Sleep(2000);

        Console.WriteLine("First let's do a breathing exercise.");
        BreathingActivity breathingActivity = new BreathingActivity();
        breathingActivity.Start();
        System.Threading.Thread.Sleep(2000);

        Console.WriteLine("Now let's move on to meditation.");
        MeditationActivity meditationActivity = new MeditationActivity();
        meditationActivity.Start();
        System.Threading.Thread.Sleep(2000);

        Console.WriteLine("Now let's move on to gratitude journaling.");
        GratitudeActivity gratitudeActivity = new GratitudeActivity();
        gratitudeActivity.Start();
        System.Threading.Thread.Sleep(2000);
        Console.WriteLine("Thank you for participating in today's mindfulness activities!");
    }
}