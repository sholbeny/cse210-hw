using System;
using System.Collections.Generic;

public class ReflectingActivity : Activity
{
    private List<string> _prompts;
    private List<string> _questions;
    private Random _random;

    public ReflectingActivity()
        : base(
            "Reflecting Activity",
            "This activity will help you reflect on times in your life "
            + "when you have shown strength and resilience. This will "
            + "help you recognize the power you have and how you can "
            + "use it in other aspects of your life."
        )
    {
        _random = new Random();

        _prompts = new List<string>
        {
            "Think of a time when you stood up for someone else.",
            "Think of a time when you did something really difficult.",
            "Think of a time when you helped someone in need.",
            "Think of a time when you did something truly selfless.",
            "Think of a time when you overcame a personal challenge.",
            "Think of a time when you showed courage."
        };

        _questions = new List<string>
        {
            "Why was this experience meaningful to you?",
            "Have you ever done anything like this before?",
            "How did you get started?",
            "How did you feel when it was complete?",
            "What made this time different from other times?",
            "What is your favorite thing about this experience?",
            "What could you learn from this experience?",
            "What did you learn about yourself?",
            "How can you keep this experience in mind in the future?"
        };
    }

    public void Run()
    {
        DisplayStartingMessage();

        Console.WriteLine(
            "Consider the following prompt:"
        );

        Console.WriteLine();

        DisplayPrompt();

        Console.WriteLine();

        Console.WriteLine(
            "When you have something in mind, press Enter to continue."
        );

        Console.ReadLine();

        Console.WriteLine(
            "Now consider each of the following questions."
        );

        Console.Write("You may begin in: ");
        ShowCountDown(5);

        Console.Clear();

        DisplayQuestions();

        DisplayEndingMessage();
    }

    public string GetRandomPrompt()
    {
        int index = _random.Next(_prompts.Count);

        return _prompts[index];
    }

    public string GetRandomQuestion(
        List<string> availableQuestions
    )
    {
        int index = _random.Next(availableQuestions.Count);

        string question = availableQuestions[index];

        availableQuestions.RemoveAt(index);

        return question;
    }

    public void DisplayPrompt()
    {
        string prompt = GetRandomPrompt();

        Console.WriteLine(
            "----------------------------------------"
        );

        Console.WriteLine($"— {prompt} —");

        Console.WriteLine(
            "----------------------------------------"
        );
    }

    public void DisplayQuestions()
    {
        List<string> availableQuestions =
            new List<string>(_questions);

        DateTime endTime =
            DateTime.Now.AddSeconds(GetDuration());

        while (DateTime.Now < endTime)
        {
            if (availableQuestions.Count == 0)
            {
                availableQuestions =
                    new List<string>(_questions);
            }

            string question =
                GetRandomQuestion(availableQuestions);

            Console.Write($"> {question} ");

            ShowSpinner(8);

            Console.WriteLine();
        }
    }
}