using System;

class Program
{
    static void Main()
    {
        GoalManager manager = new GoalManager();

        bool running = true;
        while (running)
        {
            Console.WriteLine("\nMenu:");
            Console.WriteLine("1. Create New Goal");
            Console.WriteLine("2. Record Event");
            Console.WriteLine("3. Show Goals");
            Console.WriteLine("4. Save Goals");
            Console.WriteLine("5. Load Goals");
            Console.WriteLine("6. Quit");
            Console.Write("Choose: ");
            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    Console.WriteLine("Choose goal type: 1=Simple, 2=Eternal, 3=Checklist");
                    string type = Console.ReadLine();
                    Console.Write("Name: "); string name = Console.ReadLine();
                    Console.Write("Description: "); string desc = Console.ReadLine();
                    Console.Write("Points: "); int points = int.Parse(Console.ReadLine());

                    if (type == "1") manager.AddGoal(new SimpleGoal(name, desc, points));
                    else if (type == "2") manager.AddGoal(new EternalGoal(name, desc, points));
                    else if (type == "3")
                    {
                        Console.Write("Target count: "); int target = int.Parse(Console.ReadLine());
                        Console.Write("Bonus: "); int bonus = int.Parse(Console.ReadLine());
                        manager.AddGoal(new ChecklistGoal(name, desc, points, target, bonus));
                    }
                    break;

                case "2":
                    manager.DisplayGoals();
                    Console.Write("Enter goal number: ");
                    int idx = int.Parse(Console.ReadLine()) - 1;
                    manager.RecordGoalEvent(idx);
                    break;

                case "3":
                    manager.DisplayGoals();
                    break;

                case "4":
                    manager.Save("goals.txt");
                    Console.WriteLine("Saved!");
                    break;

                case "5":
                    manager.Load("goals.txt");
                    Console.WriteLine("Loaded!");
                    break;

                case "6":
                    running = false;
                    break;
            }
        }
    }
}
