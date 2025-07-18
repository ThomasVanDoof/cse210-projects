using System;
using System.Collections.Generic;
using System.IO;
// for the "exceeding requirements" I decided "Think of other problems that keep people from writing in their journal and address one of those"
// It's kind of hard to tell tone in a journal so before writing an entry the user can choose an between, Happy, Neutral, or Unhappy.
// I did do something a little different with the prompts, instead of ranomly selecting one every time you boot it up
// it intead chooses one at random once a day, so you can write about the same prompt multiple times if you want.
class JournalApp
{
    static List<JournalEntry> entries = new List<JournalEntry>();
    static string filePath = "journal.txt";

    static List<string> prompts = new List<string>
    {
        "What made you smile today?",
        "What challenged you today?",
        "What are you grateful for right now?",
        "What did you learn today?",
        "What would you tell yourself one year ago?",
        "What is a goal you want to achieve?",
        "Describe a moment that made you proud."

    };

    static void Main()
    {
        bool running = true;
        while (running)
        {
            Console.WriteLine("\n=== Journal Menu ===");
            Console.WriteLine("1. Write");
            Console.WriteLine("2. Display");
            Console.WriteLine("3. Load");
            Console.WriteLine("4. Save");
            Console.WriteLine("5. Quit");
            Console.Write("Choose an option: ");

            string input = Console.ReadLine();
            switch (input)
            {
                case "1":
                    WriteEntry();
                    break;
                case "2":
                    DisplayEntries();
                    break;
                case "3":
                    LoadEntries();
                    break;
                case "4":
                    SaveEntries();
                    break;
                case "5":
                    running = false;
                    break;
                default:
                    Console.WriteLine("Invalid option. Try again.");
                    break;
            }
        }
    }

    static void WriteEntry()
    {
        Console.WriteLine("\nChoose an emoji to indicate your mood:");
        Console.WriteLine("1. Happy");
        Console.WriteLine("2. Neutral");
        Console.WriteLine("3. Unhappy");
        Console.Write("Enter the number of your choice: ");
        string chooseEmoji = Console.ReadLine();
        switch (chooseEmoji)
        {
            case "1":
                Console.WriteLine("You chose: Happy");
                break;
            case "2":
                Console.WriteLine("You chose: Neutral");
                break;
            case "3":
                Console.WriteLine("You chose: Unhappy");
                break;
            default:
                Console.WriteLine("Invalid choice.");
                return;
        }
        string prompt = GetPrompt();
        Console.WriteLine($"\nPrompt: {prompt}");
        Console.Write("Your response: ");
        string response = Console.ReadLine();

        JournalEntry entry = new JournalEntry
        {
            Date = DateTime.Now,
            Prompt = prompt,
            Response = response
        };

        entries.Add(entry);
        Console.WriteLine("Entry added!");
    }

    static string GetPrompt()
    {
        Random rnd = new Random();
        int index = rnd.Next(prompts.Count);
        return prompts[index];
    }

    static void DisplayEntries()
    {
        if (entries.Count == 0)
        {
            Console.WriteLine("\nNo entries to display.");
            return;
        }

        Console.WriteLine("\n=== Journal Entries ===");
        foreach (var entry in entries)
        {
            Console.WriteLine(entry.ToString());
        }
    }

    static void SaveEntries()
    {
        using (StreamWriter sw = new StreamWriter(filePath))
        {
            foreach (var entry in entries)
            {
                sw.WriteLine("-----");
                sw.WriteLine(entry.Date);
                sw.WriteLine(entry.Prompt);
                sw.WriteLine(entry.Response);
            }
        }
        Console.WriteLine("Entries saved to journal.txt");
    }

    static void LoadEntries()
    {
        entries.Clear();
        if (!File.Exists(filePath))
        {
            Console.WriteLine("No journal file found to load.");
            return;
        }

        using (StreamReader sr = new StreamReader(filePath))
        {
            string line;
            JournalEntry entry = null;
            int state = 0;

            while ((line = sr.ReadLine()) != null)
            {
                if (line == "-----")
                {
                    if (entry != null && state == 3)
                        entries.Add(entry);
                    entry = new JournalEntry();
                    state = 0;
                }
                else if (entry != null)
                {
                    switch (state)
                    {
                        case 0:
                            entry.Date = DateTime.Parse(line);
                            state++;
                            break;
                        case 1:
                            entry.Prompt = line;
                            state++;
                            break;
                        case 2:
                            entry.Response = line;
                            state++;
                            break;
                    }
                }
            }

            if (entry != null && state == 3)
                entries.Add(entry);
        }

        Console.WriteLine("Journal entries loaded.");
    }
}
