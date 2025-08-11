using System;
using System.Collections.Generic;
using System.IO;

class GoalManager
{
    private List<Goal> _goals = new List<Goal>();
    private int _score = 0;

    public void AddGoal(Goal goal) => _goals.Add(goal);

    public void RecordGoalEvent(int index)
    {
        if (index >= 0 && index < _goals.Count)
        {
            int pointsEarned = _goals[index].RecordEvent();
            _score += pointsEarned;
            Console.WriteLine($"You earned {pointsEarned} points!");
        }
    }

    public void DisplayGoals()
    {
        for (int i = 0; i < _goals.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {_goals[i].GetStatus()} {_goals[i].Name} ({_goals[i].Description})");
        }
        Console.WriteLine($"Score: {_score}");
    }

    public void Save(string filename)
    {
        using (StreamWriter writer = new StreamWriter(filename))
        {
            writer.WriteLine(_score);
            foreach (Goal g in _goals)
            {
                writer.WriteLine(SerializeGoal(g));
            }
        }
    }

    public void Load(string filename)
    {
        if (!File.Exists(filename)) return;

        string[] lines = File.ReadAllLines(filename);
        _score = int.Parse(lines[0]);
        _goals.Clear();

        for (int i = 1; i < lines.Length; i++)
        {
            _goals.Add(DeserializeGoal(lines[i]));
        }
    }

    private string SerializeGoal(Goal g)
    {
        if (g is SimpleGoal sg)
            return $"Simple|{sg.Name}|{sg.Description}|{sg.Points}|{sg.IsComplete()}";
        if (g is EternalGoal eg)
            return $"Eternal|{eg.Name}|{eg.Description}|{eg.Points}";
        if (g is ChecklistGoal cg)
            return $"Checklist|{cg.Name}|{cg.Description}|{cg.Points}";
        return "";
    }

    private Goal DeserializeGoal(string data)
    {
        var parts = data.Split('|');
        switch (parts[0])
        {
            case "Simple":
                var sg = new SimpleGoal(parts[1], parts[2], int.Parse(parts[3]));
                if (bool.Parse(parts[4])) sg.RecordEvent();
                return sg;
            case "Eternal":
                return new EternalGoal(parts[1], parts[2], int.Parse(parts[3]));
            case "Checklist":
                return new ChecklistGoal(parts[1], parts[2], int.Parse(parts[3]), 5, 500);
        }
        return null;
    }
}
