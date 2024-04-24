using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        List<int> numbers = new List<int>();

        // Asking the user for numbers and appending them to the list
        Console.WriteLine("Enter a series of numbers (enter 0 to stop):");
        int input;
        do
        {
            Console.Write("Enter a number: ");
            input = int.Parse(Console.ReadLine());
            
            if (input != 0)
            {
                numbers.Add(input);
            }
        } while (input != 0);

        // Compute the sum of the numbers in the list
        int sum = numbers.Sum();

        // Compute the average of the numbers in the list
        double average = numbers.Count > 0 ? numbers.Average() : 0;

        // Find the maximum number in the list
        int max = numbers.Count > 0 ? numbers.Max() : 0;

        // Output the results
        Console.WriteLine($"Sum: {sum}");
        Console.WriteLine($"Average: {average}");
        Console.WriteLine($"Maximum: {max}");
    }
}
