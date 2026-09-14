using System;

class Program
{
    static void Main(string[] args)
    {
        Journal journal = new Journal();

        bool isRunning = true;

        while (isRunning)
        {
            Console.WriteLine();
            Console.WriteLine("Welcome to the Journal Program!");
            Console.WriteLine("Please select one of the following choices:");
            Console.WriteLine("1. Write");
            Console.WriteLine("2. Display");
            Console.WriteLine("3. Save");
            Console.WriteLine("4. Load");
            Console.WriteLine("5. Display number of entries");
            Console.WriteLine("6. Quit");
            Console.Write("What would you like to do? ");

            string userChoice = Console.ReadLine();

            Console.WriteLine();

            if (userChoice == "1")
            {
                // Get a random writing prompt
                string prompt = journal.GetRandomPrompt();

                Console.WriteLine($"Prompt: {prompt}");
                Console.Write("Response: ");

                string response = Console.ReadLine();

                // Get today's date
                string date = DateTime.Now.ToShortDateString();

                // Create a new journal entry
                Entry journalEntry = new Entry();

                journalEntry._date = date;
                journalEntry._promptText = prompt;
                journalEntry._entryText = response;

                // Add the entry to the journal
                journal.AddEntry(journalEntry);

                Console.WriteLine();
                Console.WriteLine("Your entry has been saved.");
            }
            else if (userChoice == "2")
            {
                // Display all journal entries
                journal.DisplayAll();
            }
            else if (userChoice == "3")
            {
                // Ask the user for a filename
                Console.Write("Enter the filename to save: ");

                string fileName = Console.ReadLine();

                try
                {
                    journal.SaveToFile(fileName);
                }
                catch (Exception error)
                {
                    Console.WriteLine(
                        $"Unable to save the journal: {error.Message}"
                    );
                }
            }
            else if (userChoice == "4")
            {
                // Ask the user for a filename
                Console.Write("Enter the filename to load: ");

                string fileName = Console.ReadLine();

                try
                {
                    journal.LoadFromFile(fileName);
                }
                catch (Exception error)
                {
                    Console.WriteLine(
                        $"Unable to load the journal: {error.Message}"
                    );
                }
            }
            else if (userChoice == "5")
            {
                // EXTRA FEATURE:
                // Display the total number of entries in the journal.
                int entryCount = journal.GetEntryCount();

                Console.WriteLine(
                    $"You currently have {entryCount} journal entries."
                );
            }
            else if (userChoice == "6")
            {
                isRunning = false;

                Console.WriteLine(
                    "Thank you for using the Journal Program!"
                );
            }
            else
            {
                Console.WriteLine(
                    "Invalid choice. Please select a number from 1 to 6."
                );
            }
        }
    }
}