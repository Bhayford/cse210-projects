using System;
using System.Collections.Generic;
using System.IO;

public class Entry {
    public string Prompt { get; set; }
    public string Response { get; set; }
    public string Date { get; set; }

    public Entry(string prompt, string response, string date) {
        Prompt = prompt;
        Response = response;
        Date = date;
    }

    // Method to format the entry for display
    public override string ToString() {
        return $"Date: {Date}\nPrompt: {Prompt}\nResponse: {Response}\n";
    }
}

public class Journal {
    private List<Entry> entries;

    public Journal() {
        entries = new List<Entry>();
    }

    // Method to add a new entry to the journal
    public void AddEntry(string prompt, string response, string date) {
        Entry entry = new Entry(prompt, response, date);
        entries.Add(entry);
    }

    // Method to display all entries in the journal
    public void DisplayJournal() {
        if (entries.Count == 0) {
            Console.WriteLine("Journal is empty.");
            return;
        }
        foreach (Entry entry in entries) {
            Console.Write(entry);
        }
    }

    // Method to save the journal to a file
    public void SaveToFile(string filename) {
        using (StreamWriter writer = new StreamWriter(filename)) {
            foreach (Entry entry in entries) {
                writer.WriteLine($"{entry.Date}|{entry.Prompt}|{entry.Response}");
            }
        }
        Console.WriteLine("Journal saved successfully.");
    }

    // Method to load entries from a file
    public void LoadFromFile(string filename) {
        entries.Clear(); // Clear existing entries
        using (StreamReader reader = new StreamReader(filename)) {
            string line;
            while ((line = reader.ReadLine()) != null) {
                string[] parts = line.Split('|');
                if (parts.Length == 3) {
                    string date = parts[0];
                    string prompt = parts[1];
                    string response = parts[2];
                    AddEntry(prompt, response, date);
                }
            }
        }
        Console.WriteLine("Journal loaded successfully.");
    }
}

public class Program {
    static void Main(string[] args) {
        Journal journal = new Journal();

        while (true) {
            Console.WriteLine("1. Write a new entry");
            Console.WriteLine("2. Display the journal");
            Console.WriteLine("3. Save the journal to a file");
            Console.WriteLine("4. Load the journal from a file");
            Console.WriteLine("5. Exit");
            Console.Write("Enter your choice: ");

            int choice;
            if (!int.TryParse(Console.ReadLine(), out choice)) {
                Console.WriteLine("Invalid input. Please enter a number.");
                continue;
            }

            switch (choice) {
                case 1:
                    Console.WriteLine("Writing a new entry...");
                    // Get random prompt (you can define a list of prompts)
                    string[] prompts = { "Prompt 1", "Prompt 2", "Prompt 3", "Prompt 4", "Prompt 5" };
                    Random rnd = new Random();
                    string randomPrompt = prompts[rnd.Next(prompts.Length)];
                    Console.Write($"Prompt: {randomPrompt} ");
                    Console.Write("Enter your response: ");
                    string response = Console.ReadLine();
                    // Get current date
                    string date = DateTime.Now.ToString("yyyy-MM-dd");
                    journal.AddEntry(randomPrompt, response, date);
                    break;
                case 2:
                    Console.WriteLine("Displaying journal entries...");
                    journal.DisplayJournal();
                    break;
                case 3:
                    Console.Write("Enter filename to save: ");
                    string saveFilename = Console.ReadLine();
                    journal.SaveToFile(saveFilename);
                    break;
                case 4:
                    Console.Write("Enter filename to load: ");
                    string loadFilename = Console.ReadLine();
                    journal.LoadFromFile(loadFilename);
                    break;
                case 5:
                    Console.WriteLine("Exiting program...");
                    Environment.Exit(0);
                    break;
                default:
                    Console.WriteLine("Invalid choice. Please enter a number between 1 and 5.");
                    break;
            }
        }
    }
}
