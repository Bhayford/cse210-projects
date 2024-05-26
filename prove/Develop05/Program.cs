using System;
using System.Collections.Generic;
using System.IO;

// Base class for goals
public abstract class Goal
{
    public string Name { get; set; }
    protected bool IsComplete { get; set; }  // Changed to protected set
    public int Points { get; protected set; }

    public Goal(string name)
    {
        Name = name;
        IsComplete = false;
        Points = 0;
    }

    public virtual void RecordEvent()
    {
        IsComplete = true;  // Accessible due to protected setter
    }

    public virtual string GetStatus()
    {
        return IsComplete ? "[X]" : "[ ]";
    }

    public abstract void DisplayProgress();
}

// Simple goal that can be marked complete
public class SimpleGoal : Goal
{
    public SimpleGoal(string name, int points) : base(name)
    {
        Points = points;
    }

    public override void RecordEvent()
    {
        base.RecordEvent();
        IsComplete = true;  // Accessible due to protected setter
    }

    public override void DisplayProgress()
    {
        Console.WriteLine($"{Name} - {GetStatus()} - Points: {Points}");
    }
}

// Eternal goal that never ends
public class EternalGoal : Goal
{
    private int _timesCompleted;

    public EternalGoal(string name, int pointsPerCompletion) : base(name)
    {
        Points = pointsPerCompletion;
        _timesCompleted = 0;
    }

    public override void RecordEvent()
    {
        base.RecordEvent();
        IsComplete = true;  // Accessible due to protected setter
        _timesCompleted++;
    }

    public override void DisplayProgress()
    {
        Console.WriteLine($"{Name} - {GetStatus()} - Times Completed: {_timesCompleted} - Points: {Points}");
    }
}

// Checklist goal that must be completed a certain number of times
public class ChecklistGoal : Goal
{
    private int _totalRequired;
    private int _timesCompleted;
    private int _bonusPoints;

    public ChecklistGoal(string name, int pointsPerCompletion, int totalRequired, int bonusPoints) : base(name)
    {
        Points = pointsPerCompletion;
        _totalRequired = totalRequired;
        _timesCompleted = 0;
        _bonusPoints = bonusPoints;
    }

    public override void RecordEvent()
    {
        base.RecordEvent();
        IsComplete = true;  // Accessible due to protected setter
        _timesCompleted++;
        if (_timesCompleted == _totalRequired)
        {
            Points += _bonusPoints;
        }
    }

    public override void DisplayProgress()
    {
        Console.WriteLine($"{Name} - {GetStatus()} - Completed {_timesCompleted}/{_totalRequired} times - Points: {Points}");
    }
}

// Main program to demonstrate the usage
public class Program
{
    private static List<Goal> goals = new List<Goal>();

    public static void Main()
    {
        LoadGoalsFromFile("goals.txt");

        bool exit = false;
        while (!exit)
        {
            DisplayMenu();
            string choice = Console.ReadLine();
            Console.WriteLine();

            switch (choice)
            {
                case "1":
                    CreateNewGoal();
                    break;
                case "2":
                    RecordGoalEvent();
                    break;
                case "3":
                    DisplayGoalsProgress();
                    break;
                case "4":
                    DisplayUserScore();
                    break;
                case "5":
                    SaveGoalsToFile("goals.txt");
                    Console.WriteLine("Goals saved successfully.");
                    break;
                case "6":
                    exit = true;
                    SaveGoalsToFile("goals.txt");
                    Console.WriteLine("Exiting program. Goals saved.");
                    break;
                default:
                    Console.WriteLine("Invalid choice. Please try again.");
                    break;
            }

            Console.WriteLine();
        }
    }

    // Display main menu
    private static void DisplayMenu()
    {
        Console.WriteLine("Eternal Quest - Main Menu");
        Console.WriteLine("1. Create a new goal");
        Console.WriteLine("2. Record an event (accomplished goal)");
        Console.WriteLine("3. Display goals progress");
        Console.WriteLine("4. Display user's score");
        Console.WriteLine("5. Save goals to file");
        Console.WriteLine("6. Exit program");
        Console.Write("Enter your choice: ");
    }

    // Create a new goal
    private static void CreateNewGoal()
    {
        Console.Write("Enter goal name: ");
        string name = Console.ReadLine();

        Console.WriteLine("Select goal type:");
        Console.WriteLine("1. Simple Goal");
        Console.WriteLine("2. Eternal Goal");
        Console.WriteLine("3. Checklist Goal");
        Console.Write("Enter your choice: ");
        string typeChoice = Console.ReadLine();

        switch (typeChoice)
        {
            case "1":
                Console.Write("Enter points for completing this goal: ");
                int points = int.Parse(Console.ReadLine());
                goals.Add(new SimpleGoal(name, points));
                break;
            case "2":
                Console.Write("Enter points per completion: ");
                int pointsPerCompletion = int.Parse(Console.ReadLine());
                goals.Add(new EternalGoal(name, pointsPerCompletion));
                break;
            case "3":
                Console.Write("Enter points per completion: ");
                int pointsPerChecklistCompletion = int.Parse(Console.ReadLine());
                Console.Write("Enter total required completions: ");
                int totalRequired = int.Parse(Console.ReadLine());
                Console.Write("Enter bonus points for completing all: ");
                int bonusPoints = int.Parse(Console.ReadLine());
                goals.Add(new ChecklistGoal(name, pointsPerChecklistCompletion, totalRequired, bonusPoints));
                break;
            default:
                Console.WriteLine("Invalid choice. Goal creation canceled.");
                break;
        }

        Console.WriteLine($"Goal '{name}' created successfully.");
    }

    // Record an event (accomplished goal)
    private static void RecordGoalEvent()
    {
        if (goals.Count == 0)
        {
            Console.WriteLine("No goals created yet.");
            return;
        }

        Console.WriteLine("Select a goal to mark as completed:");
        for (int i = 0; i < goals.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {goals[i].Name}");
        }

        Console.Write("Enter your choice: ");
        int choice = int.Parse(Console.ReadLine()) - 1;

        if (choice < 0 || choice >= goals.Count)
        {
            Console.WriteLine("Invalid choice.");
            return;
        }

        goals[choice].RecordEvent();
        Console.WriteLine($"Event recorded for goal '{goals[choice].Name}'.");
    }

    // Display goals progress
    private static void DisplayGoalsProgress()
    {
        if (goals.Count == 0)
        {
            Console.WriteLine("No goals created yet.");
            return;
        }

        Console.WriteLine("Goals Progress:");
        foreach (var goal in goals)
        {
            goal.DisplayProgress();
        }
    }

    // Display user's score
    private static void DisplayUserScore()
    {
        int totalScore = 0;
        foreach (var goal in goals)
        {
            totalScore += goal.Points;
        }

        Console.WriteLine($"Total Score: {totalScore}");
    }

    // Save goals to a text file
    private static void SaveGoalsToFile(string filename)
    {
        using (StreamWriter writer = new StreamWriter(filename))
        {
            foreach (var goal in goals)
            {
                writer.WriteLine($"{goal.GetType().Name},{goal.Name},{goal.Points},{goal.IsComplete}");
            }
        }
        Console.WriteLine($"Goals saved to {filename}");
    }

    // Load goals from a text file
    private static void LoadGoalsFromFile(string filename)
    {
        goals.Clear();
        if (File.Exists(filename))
        {
            using (StreamReader reader = new StreamReader(filename))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    string[] parts = line.Split(',');
                    if (parts.Length == 4)
                    {
                        string type = parts[0];
                        string name = parts[1];
                        int points = int.Parse(parts[2]);
                        bool isComplete = bool.Parse(parts[3]);

                        switch (type)
                        {
                            case nameof(SimpleGoal):
                                goals.Add(new SimpleGoal(name, points) { IsComplete = isComplete });
                                break;
                            case nameof(EternalGoal):
                                goals.Add(new EternalGoal(name, points) { IsComplete = isComplete });
                                break;
                            case nameof(ChecklistGoal):
                                goals.Add(new ChecklistGoal(name, points, 0, 0) { IsComplete = isComplete });
                                break;
                            default:
                                Console.WriteLine($"Unknown goal type '{type}'. Skipping.");
                                break;
                        }
                    }
                    else
                    {
                        Console.WriteLine($"Invalid line format: '{line}'. Skipping.");
                    }
                }
            }
            Console.WriteLine($"Goals loaded from {filename}");
        }
        else
        {
            Console.WriteLine("No goals found. Starting with an empty list.");
        }
    }
}
