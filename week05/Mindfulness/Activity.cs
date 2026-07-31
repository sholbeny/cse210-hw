using System;
using System.Collections.Generic;
using System.Threading;

public class Activity
{
    private string _name;
    private string _description;
    private int _duration;

    public Activity(string name, string description)
    {
        _name = name;
        _description = description;
        _duration = 0;
    }

    public void DisplayStartingMessage()
    {
        Console.Clear();

        Console.WriteLine($"Welcome to the {_name}.");
        Console.WriteLine();

        Console.WriteLine(_description);
        Console.WriteLine();

        bool validDuration = false;

        while (!validDuration)
        {
            Console.Write(
                "How long, in seconds, would you like for your session? "
            );

            string response = Console.ReadLine();

            if (
                int.TryParse(response, out int duration)
                && duration > 0
            )
            {
                _duration = duration;
                validDuration = true;
            }
            else
            {
                Console.WriteLine();
                Console.WriteLine(
                    "Please enter a whole number greater than zero."
                );

                Console.WriteLine();
            }
        }

        Console.Clear();

        Console.WriteLine("Get ready...");
        ShowSpinner(3);

        Console.WriteLine();
    }

    public void DisplayEndingMessage()
    {
        Console.WriteLine();
        Console.WriteLine("Well done!");

        ShowSpinner(3);

        Console.WriteLine();
        Console.WriteLine(
            $"You have completed another {_duration} seconds "
            + $"of the {_name}."
        );

        ShowSpinner(3);
    }

    public void ShowSpinner(int seconds)
    {
        List<string> spinnerCharacters = new List<string>
        {
            "|",
            "/",
            "-",
            "\\"
        };

        DateTime endTime = DateTime.Now.AddSeconds(seconds);

        int spinnerIndex = 0;

        while (DateTime.Now < endTime)
        {
            Console.Write(spinnerCharacters[spinnerIndex]);

            Thread.Sleep(250);

            Console.Write("\b \b");

            spinnerIndex++;

            if (spinnerIndex >= spinnerCharacters.Count)
            {
                spinnerIndex = 0;
            }
        }
    }

    public void ShowCountDown(int seconds)
    {
        for (int number = seconds; number > 0; number--)
        {
            Console.Write(number);

            Thread.Sleep(1000);

            for (
                int digit = 0;
                digit < number.ToString().Length;
                digit++
            )
            {
                Console.Write("\b \b");
            }
        }
    }

    public int GetDuration()
    {
        return _duration;
    }
}