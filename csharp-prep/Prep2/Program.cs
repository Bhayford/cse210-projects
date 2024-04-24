using System;

class Program
{
    static void Main(string[] args)
    {
        Console.Write("What was your score? ");
        string answer = Console.ReadLine();
        int score = int.Parse(answer);

        string letter = "";

        if (score >= 90)
        {
            letter = "A";
        }
        else if (score >= 80)
        {
            letter = "B";
        }
        else if (score >= 70)
        {
            letter = "C";
        }
        if (score >= 60)
        {
            letter = "D";
        }
        else
        {
            letter = "F";
        }

        Console.WriteLine($"Your grade is {letter}");

        if (score >= 70)
        {
            Console.WriteLine("Congratulations you passed!");
        }

        else 
        {
            Console.WriteLine("Unfortunately you failed, but you can try harder next time");
        }


    }
}