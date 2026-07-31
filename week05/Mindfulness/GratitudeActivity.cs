using System;
using System.Collections.Generic;

public class GratitudeActivity : Activity
{
    private List<string> _questions;
    private Random _random;

    public GratitudeActivity()
        : base(
            "Gratitude Activity",
            "This activity will help you focus on positive things "
            + "in your life by thinking about something you are "
            + "grateful for and why it is meaningful to you."
        )
    {
        _random = new Random();

        _questions = new List<string>
        {
            "What is something you are grateful for today?",
            "Why is this meaningful to you?",
            "How has this person or thing helped you?",
            "How could you show your appreciation?",
            "How does thinking about this make you feel?",
            "What is a happy memory connected to this?",
            "How might your life be different without it?",
            "What is one small thing that made your day better?",
            "Who is someone who has supported you recently?"
        };
    }

    public void Run()
    {
        DisplayStartingMessage();

        Console.WriteLine(
            "Think about something or someone you are grateful for."
        );

        Console.WriteLine();

        Console.Write("You may begin in: ");
        ShowCountDown(5);

        Console.WriteLine();
        Console.WriteLine();

        DisplayQuestions();

        DisplayEndingMessage();
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

            Console.WriteLine(question);
            Console.Write("> ");

            string response = Console.ReadLine();

            Console.WriteLine();

            if (DateTime.Now < endTime)
            {
                Console.Write("Take a moment to reflect ");

                ShowSpinner(2);

                Console.WriteLine();
                Console.WriteLine();
            }
        }
    }
}