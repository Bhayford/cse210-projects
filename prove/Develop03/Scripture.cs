using System;
using System.Collections.Generic;

public class Scripture
{
    private Reference reference;
    private List<Word> words;

    public Scripture(string reference, string text)
    {
        this.reference = new Reference(reference);
        words = new List<Word>();

        // Split the text into words and initialize Word objects
        string[] wordArray = text.Split(' ');
        foreach (string wordText in wordArray)
        {
            words.Add(new Word(wordText));
        }
    }

    public void Display()
    {
        // Display the scripture reference and text
        Console.WriteLine(reference.GetFormattedReference());
        foreach (Word word in words)
        {
            Console.Write(word.GetDisplayText() + " ");
        }
        Console.WriteLine();
    }

    public void HideRandomWords()
    {
        Random random = new Random();
        int numWordsToHide = random.Next(1, words.Count);
        HashSet<int> hiddenIndices = new HashSet<int>();
        for (int i = 0; i < numWordsToHide; i++)
        {
            int index = random.Next(0, words.Count);
            hiddenIndices.Add(index);
            words[index].Hide();
        }

        // Clear console screen
        Console.Clear();

        // Display the scripture again
        Display();

        // Prompt user to press enter to continue
        Console.WriteLine("Press Enter to continue or type 'quit' to exit.");
        string input = Console.ReadLine();
        if (input.ToLower() == "quit")
        {
            Environment.Exit(0);
        }
        else
        {
            // Continue hiding words
            HideRandomWords();
        }
    }
}
