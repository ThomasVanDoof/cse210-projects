public class BreathingActivity
{
    public void Start()
    {
        Console.WriteLine("Welcome to the Breathing Activity.");
        for (int i = 0; i < 3; i++)
        {
            Console.WriteLine("Get ready to breathe...");
            System.Threading.Thread.Sleep(2000);
            Console.WriteLine("Inhale deeply through your nose...");
            System.Threading.Thread.Sleep(4000);
            Console.WriteLine("Hold your breath...");
            System.Threading.Thread.Sleep(4000);
            Console.WriteLine("Exhale slowly through your mouth...");
            System.Threading.Thread.Sleep(4000);
            Console.WriteLine("Great job! Let's do it again.");
            System.Threading.Thread.Sleep(2000);
            Console.WriteLine($"Breathing cycle {i + 1} complete.");
        }
        
        Console.WriteLine("Activity complete. Thank you for participating.");
    }
}