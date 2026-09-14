using System;
using System.Collections.Generic;
using System.IO;

public class Journal
{
    // Stores all journal entries
    public List<Entry> _entries = new List<Entry>();

    // List of writing prompts
    private List<string> _prompts = new List<string>
    {
        "Who was the most interesting person I interacted with today?",
        "What was the best part of my day?",
        "How did I see the hand of the Lord in my life today?",
        "What was the strongest emotion I felt today?",
        "If I had one thing I could do over today, what would it be?",
        "What is one thing I learned today?",
        "What am I grateful for today?"
    };

    // Gets a random prompt
    public string GetRandomPrompt()
    {
        Random random = new Random();

        int promptIndex = random.Next(_prompts.Count);

        return _prompts[promptIndex];
    }

    // Adds an entry to the journal
    public void AddEntry(Entry entry)
    {
        _entries.Add(entry);
    }

    // Displays all journal entries
    public void DisplayAll()
    {
        if (_entries.Count == 0)
        {
            Console.WriteLine("There are no entries in the journal.");
            return;
        }

        foreach (Entry entry in _entries)
        {
            entry.Display();
        }
    }

    // Saves the journal to a file
    public void SaveToFile(string fileName)
    {
        using (StreamWriter outputFile = new StreamWriter(fileName))
        {
            foreach (Entry entry in _entries)
            {
                outputFile.WriteLine(entry.GetFileLine());
            }
        }

        Console.WriteLine("Journal saved successfully.");
    }

    // Loads the journal from a file
    public void LoadFromFile(string fileName)
    {
        _entries.Clear();

        string[] lines = File.ReadAllLines(fileName);

        foreach (string line in lines)
        {
            string[] parts = line.Split('|');

            if (parts.Length >= 3)
            {
                Entry entry = new Entry();

                entry._date = parts[0];
                entry._promptText = parts[1];
                entry._entryText = parts[2];

                _entries.Add(entry);
            }
        }

        Console.WriteLine("Journal loaded successfully.");
    }

    // EXTRA FEATURE:
    // Returns the number of entries in the journal.
    public int GetEntryCount()
    {
        return _entries.Count;
    }
}