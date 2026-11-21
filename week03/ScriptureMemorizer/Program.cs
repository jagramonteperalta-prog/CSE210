using System;

class Program
{
    static void Main(string[] args)
    {
        int wordsToHide = 3;

        Console.WriteLine("Choose a difficulty:");
        Console.WriteLine("1. Easy");
        Console.WriteLine("2. Medium");
        Console.WriteLine("3. Hard");

        string difficulty = Console.ReadLine();

        if (difficulty == "1")
        {
            wordsToHide = 1;
        }
        else if (difficulty == "2")
        {
            wordsToHide = 3;
        }
        else if (difficulty == "3")
        {
            wordsToHide = 5;
        }

        Reference reference = new Reference("John", 3, 16);

        Scripture scripture = new Scripture(
            reference,
            "For God so loved the world that he gave his only begotten Son"
        );

        while (!scripture.IsCompletelyHidden())
        {
            Console.Clear();

            Console.WriteLine(scripture.GetDisplayText());

            Console.Write("Press Enter to continue or type 'quit' to finish");

            string input = Console.ReadLine();

            if (input == "quit")
            {
                return;
            }

            scripture.HideRandomWords(wordsToHide);
        }

        Console.Clear();
        Console.WriteLine(scripture.GetDisplayText());
    }
}