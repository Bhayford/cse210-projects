using System;

public class ListingActivity : MindfulnessActivity
{
    private static readonly string[] Prompts =
    {
        "Who are people that you appreciate?",
        "What are personal strengths of yours?",
        "Who are people that you have helped this week?",
        "When have you felt the Holy Ghost this month?",
        "Who are some of your personal heroes?"
    };

    public ListingActivity()
    {
        Name = "Listing";
        Description = "This activity will help you reflect on the good things in your life by having you list as many things as you can in a certain area.";
    }

    public override void PerformActivity()
    {
        Random random = new Random();
        string prompt = Prompts[random.Next(Prompts.Length)];
        Console.WriteLine(prompt);
        Pause(3);

        Console.WriteLine("Start listing items:");

        int time = 0;
        int itemCount = 0;
        while (time < Duration)
        {
            Console.Write("> ");
            Console.ReadLine();
            itemCount++;
            time += 5; // Assuming it takes about 5 seconds to think and type each item
        }

        Console.WriteLine($"You listed {itemCount} items.");
    }
}
