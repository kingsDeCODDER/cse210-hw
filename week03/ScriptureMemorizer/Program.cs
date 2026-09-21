using System;

class Program
{
    static void Main(string[] args)
    {
        Reference reference = new Reference(
            "Proverbs",
            3,
            5,
            6
        );

        string text =
            "Trust in the Lord with all your heart and lean not on your own understanding.";

        Scripture scripture = new Scripture(reference, text);

        while (!scripture.AllWordsHidden())
        {
            Console.Clear();

            Console.WriteLine(scripture.GetDisplayText());

            Console.WriteLine();
            Console.Write("Press Enter to hide words or type 'quit' to exit: ");

            string input = Console.ReadLine();

            if (input != null && input.ToLower() == "quit")
            {
                break;
            }

            scripture.HideRandomWords(3);
        }

        Console.Clear();

        Console.WriteLine(scripture.GetDisplayText());
    }
}