using System;

class Program
{
    static void Main(string[] args)
    {

        //Require name of the user
        Console.Write("What is your first name? ");
        string first = Console.ReadLine();

        Console.Write("What is your last name? ");
        string last = Console.ReadLine();

        Console.Write($"Your name is {last}, {first} {last}");

    }
}