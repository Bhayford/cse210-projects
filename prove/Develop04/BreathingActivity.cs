using System;

public class BreathingActivity : MindfulnessActivity
{
    public BreathingActivity()
    {
        Name = "Breathing";
        Description = "This activity will help you relax by walking you through breathing in and out slowly. Clear your mind and focus on your breathing.";
    }

    public override void PerformActivity()
    {
        int time = 0;
        while (time < Duration)
        {
            Console.WriteLine("Breathe in...");
            Pause(3);
            time += 3;

            Console.WriteLine("Breathe out...");
            Pause(3);
            time += 3;
        }
    }
}
