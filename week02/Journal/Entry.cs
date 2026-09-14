using System;

public class Entry
{
    // Member variables
    public string _date;
    public string _promptText;
    public string _entryText;

    // Displays one journal entry
    public void Display()
    {
        Console.WriteLine($"Date: {_date}");
        Console.WriteLine($"Prompt: {_promptText}");
        Console.WriteLine($"Response: {_entryText}");
        Console.WriteLine();
    }

    // Prepares the entry to be saved to a file
    public string GetFileLine()
    {
        return $"{_date}|{_promptText}|{_entryText}";
    }
}