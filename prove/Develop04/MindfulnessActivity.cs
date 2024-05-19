using System;
using System.Threading;

public abstract class MindfulnessActivity
{
    public string Name { get; set; }
    public string Description { get; set; }
    public int Duration { get; set; }

    public void StartActivity()
    {
        ShowStartingMessage();
        PerformActivity();
        ShowEndingMessage();
    }

    public void ShowStartingMessage()
    {
        Console.WriteLine($"Starting {Name} Activity");
        Console.WriteLine(Description);
        Console.Write("Enter duration in seconds: ");
        Duration = int.Parse(Console.ReadLine());
        Console.WriteLine("Prepare to begin...");
        Pause(3);
    }

    public void ShowEndingMessage()
    {
        Console.WriteLine("Good job!");
        Console.WriteLine($"You have completed the {Name} activity for {Duration} seconds.");
        Pause(3);
    }

    public void Pause(int seconds)
    {
        for (int i = 0; i < seconds; i++)
        {
            Console.Write(".");
            Thread.Sleep(1000);
        }
        Console.WriteLine();
    }

    public abstract void PerformActivity();
}
