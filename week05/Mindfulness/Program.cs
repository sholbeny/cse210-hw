using System;
using System.Threading;

class Program
{
    static void Main(string[] args)
    {
        /*
        Creativity and Exceeding Requirements:

        I added a fourth mindfulness activity called the Gratitude Activity.
        This activity helps the user focus on something positive in their life
        by answering gratitude-related questions.

        The program also keeps track of how many activities the user completes
        during the current session and displays the total on the menu.
        */

        bool running = true;
        int completedActivities = 0;

        while (running)
        {
            Console.Clear();

            Console.WriteLine("Menu Options:");
            Console.WriteLine("  1. Start breathing activity");
            Console.WriteLine("  2. Start reflecting activity");
            Console.WriteLine("  3. Start listing activity");
            Console.WriteLine("  4. Start gratitude activity");
            Console.WriteLine("  5. Quit");
            Console.WriteLine();

            Console.WriteLine(
                $"Activities completed this session: {completedActivities}"
            );

            Console.WriteLine();
            Console.Write("Select a choice from the menu: ");

            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    BreathingActivity breathingActivity =
                        new BreathingActivity();

                    breathingActivity.Run();
                    completedActivities++;
                    break;

                case "2":
                    ReflectingActivity reflectingActivity =
                        new ReflectingActivity();

                    reflectingActivity.Run();
                    completedActivities++;
                    break;

                case "3":
                    ListingActivity listingActivity =
                        new ListingActivity();

                    listingActivity.Run();
                    completedActivities++;
                    break;

                case "4":
                    GratitudeActivity gratitudeActivity =
                        new GratitudeActivity();

                    gratitudeActivity.Run();
                    completedActivities++;
                    break;

                case "5":
                    running = false;
                    break;

                default:
                    Console.WriteLine();
                    Console.WriteLine(
                        "Please enter a number from 1 to 5."
                    );

                    Thread.Sleep(2000);
                    break;
            }
        }

        Console.Clear();

        Console.WriteLine(
            "Thank you for using the Mindfulness Program."
        );

        Console.WriteLine(
            $"You completed {completedActivities} activities this session."
        );
    }
}