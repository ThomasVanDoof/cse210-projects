public class GratitudeActivity
{
    public void Start()
    {
        Console.WriteLine("Let's take a moment to reflect on things we're grateful for.");
        System.Threading.Thread.Sleep(1000);
        Console.WriteLine("Think of three things you appreciate in your life.");
        Console.WriteLine("Type your responses below:");
        for (int i = 0; i < 3; i++)
        {
            Console.Write($"Gratitude {i + 1}: ");
            string response = Console.ReadLine();
            Console.WriteLine($"You wrote: {response}");
        }
    }
}