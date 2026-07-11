using System;

/*
Added elements: A word count feature and also a 
feature that can offer a category for an entry
Categories are: School, Family, Work, Church and Other
Hopefully it works!
*/

class Program
{
    static void Main(string[] args)
    {
        Journal journal = new Journal();
        PromptGenerator promptGenerator = new PromptGenerator();

        int userChoice = 0;

        Console.WriteLine("Welcome to the Journal Program!");

        while (userChoice != 5)
        {
            DisplayMenu();

            Console.Write("What would you like to do? ");
            string input = Console.ReadLine();

            bool isValidNumber = int.TryParse(input, out userChoice);

            if (!isValidNumber)
            {
                Console.WriteLine("Please enter a number from 1 to 5.");
                Console.WriteLine();
                continue;
            }

            if (userChoice == 1)
            {
                WriteNewEntry(journal, promptGenerator);
            }
            else if (userChoice == 2)
            {
                journal.DisplayAll();
            }
            else if (userChoice == 3)
            {
                Console.Write("What filename would you like to use? ");
                string filename = Console.ReadLine();

                journal.SaveToFile(filename);
            }
            else if (userChoice == 4)
            {
                Console.Write("What filename would you like to load? ");
                string filename = Console.ReadLine();

                journal.LoadFromFile(filename);
            }
            else if (userChoice == 5)
            {
                Console.WriteLine(
                    "Thank you for using the Journal Program!"
                );
            }
            else
            {
                Console.WriteLine("Please choose an option from 1 to 5.");
            }

            Console.WriteLine();
        }
    }

    static void DisplayMenu()
    {
        Console.WriteLine(
            "Please select one of the following choices:"
        );

        Console.WriteLine("1. Write");
        Console.WriteLine("2. Display");
        Console.WriteLine("3. Save");
        Console.WriteLine("4. Load");
        Console.WriteLine("5. Quit");
    }

    static void WriteNewEntry(
        Journal journal,
        PromptGenerator promptGenerator)
    {
        string prompt = promptGenerator.GetRandomPrompt();

        Console.WriteLine();
        Console.WriteLine(prompt);
        Console.Write("> ");

        string response = Console.ReadLine();

        if (string.IsNullOrWhiteSpace(response))
        {
            Console.WriteLine(
                "The entry was not saved because it was empty."
            );

            return;
        }

        string category = ChooseCategory();

        string date = DateTime.Now.ToShortDateString();

        Entry newEntry = new Entry(
            date,
            prompt,
            response,
            category
        );

        journal.AddEntry(newEntry);

        Console.WriteLine("Your journal entry was added.");
    }

    static string ChooseCategory()
    {
        Console.WriteLine();
        Console.WriteLine("Choose a category:");
        Console.WriteLine("1. School");
        Console.WriteLine("2. Family");
        Console.WriteLine("3. Work");
        Console.WriteLine("4. Church");
        Console.WriteLine("5. Other");

        Console.Write("Category: ");
        string categoryChoice = Console.ReadLine();

        if (categoryChoice == "1")
        {
            return "School";
        }
        else if (categoryChoice == "2")
        {
            return "Family";
        }
        else if (categoryChoice == "3")
        {
            return "Work";
        }
        else if (categoryChoice == "4")
        {
            return "Church";
        }
        else
        {
            return "Other";
        }
    }
}