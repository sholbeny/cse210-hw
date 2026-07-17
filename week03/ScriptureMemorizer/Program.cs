using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        /*
         * Creativity and exceeding requirements:
         *
         * I made the program contain a small library of five scriptures and had it 
         * randomly choose one whenever the program begins. It also selects words only
         * from those that are still visible, so it never wastes a turn by
         * selecting a word that has already been hidden.
         *
         * The program also keeps punctuation visible when hiding words.
         */

        List<Scripture> scriptureLibrary = new List<Scripture>();

        scriptureLibrary.Add(
            new Scripture(
                new Reference("John", 3, 16),
                "For God so loved the world, that he gave his only begotten Son, " +
                "that whosoever believeth in him should not perish, but have everlasting life."
            )
        );

        scriptureLibrary.Add(
            new Scripture(
                new Reference("Joshua", 1, 9),
                "Have not I commanded thee? Be strong and of a good courage; " +
                "be not afraid, neither be thou dismayed: for the Lord thy God " +
                "is with thee whithersoever thou goest."
            )
        );

        scriptureLibrary.Add(
            new Scripture(
                new Reference("Philippians", 4, 13),
                "I can do all things through Christ which strengtheneth me."
            )
        );

        scriptureLibrary.Add(
            new Scripture(
                new Reference("Isaiah", 41, 10),
                "Fear thou not; for I am with thee: be not dismayed; for I am thy God: " +
                "I will strengthen thee; yea, I will help thee; yea, I will uphold thee " +
                "with the right hand of my righteousness."
            )
        );

        scriptureLibrary.Add(
            new Scripture(
                new Reference("John", 14, 6),
                "Jesus saith unto him, I am the way, the truth, and the life: " +
                "no man cometh unto the Father, but by me."
            )
        );

        Random random = new Random();
        int randomIndex = random.Next(scriptureLibrary.Count);
        Scripture scripture = scriptureLibrary[randomIndex];

        bool quitRequested = false;

        while (!quitRequested)
        {
            Console.Clear();
            Console.WriteLine(scripture.GetDisplayText());
            Console.WriteLine();

            if (scripture.IsCompletelyHidden())
            {
                break;
            }

            Console.Write("Press Enter to hide words or type \"quit\": ");
            string userInput = Console.ReadLine() ?? "";

            if (userInput.ToLower() == "quit")
            {
                quitRequested = true;
            }
            else
            {
                scripture.HideRandomWords(3);
            }
        }

        if (!quitRequested)
        {
            Console.WriteLine();
            Console.WriteLine("All the words are hidden. Great job practicing!");
        }
    }
}