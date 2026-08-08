using System.IO;

public class GoalManager
{
    private List<Goal> _goals;
    private List<string> _badges;
    private int _score;
    private int _eventsRecorded;

    public GoalManager()
    {
        _goals = new List<Goal>();
        _badges = new List<string>();
        _score = 0;
        _eventsRecorded = 0;
    }

    public void Start()
    {
        bool running = true;

        while (running)
        {
            Console.Clear();

            DisplayPlayerInfo();
            DisplayMenu();

            Console.Write("Select a choice from the menu: ");
            string choice = Console.ReadLine() ?? "";

            Console.WriteLine();

            switch (choice)
            {
                case "1":
                    CreateGoal();
                    break;

                case "2":
                    ListGoalDetails();
                    break;

                case "3":
                    SaveGoals();
                    break;

                case "4":
                    LoadGoals();
                    break;

                case "5":
                    RecordEvent();
                    break;

                case "6":
                    DisplayBadges();
                    break;

                case "7":
                    running = false;
                    Console.WriteLine(
                        "Keep working toward your eternal goals!"
                    );
                    break;

                default:
                    Console.WriteLine(
                        "Please enter a number from 1 to 7."
                    );
                    break;
            }

            if (running)
            {
                Console.WriteLine();
                Console.WriteLine(
                    "Press Enter to return to the menu."
                );

                Console.ReadLine();
            }
        }
    }

    public void DisplayPlayerInfo()
    {
        Console.WriteLine($"You have {_score} points.");
        Console.WriteLine($"Current level: {GetLevel()}");
        Console.WriteLine($"Badges earned: {_badges.Count}");
        Console.WriteLine();
    }

    public void DisplayMenu()
    {
        Console.WriteLine("Menu Options:");
        Console.WriteLine("  1. Create New Goal");
        Console.WriteLine("  2. List Goals");
        Console.WriteLine("  3. Save Goals");
        Console.WriteLine("  4. Load Goals");
        Console.WriteLine("  5. Record Event");
        Console.WriteLine("  6. View Badges");
        Console.WriteLine("  7. Quit");
        Console.WriteLine();
    }

    public void CreateGoal()
    {
        Console.WriteLine("The types of goals are:");
        Console.WriteLine("  1. Simple Goal");
        Console.WriteLine("  2. Eternal Goal");
        Console.WriteLine("  3. Checklist Goal");

        Console.Write(
            "Which type of goal would you like to create? "
        );

        string goalType = Console.ReadLine() ?? "";

        if (goalType != "1" &&
            goalType != "2" &&
            goalType != "3")
        {
            Console.WriteLine("That is not a valid goal type.");
            return;
        }

        Console.Write("What is the name of your goal? ");
        string name = Console.ReadLine() ?? "";

        Console.Write("What is a short description of it? ");
        string description = Console.ReadLine() ?? "";

        int points = ReadPositiveNumber(
            "What is the amount of points associated " +
            "with this goal? "
        );

        if (goalType == "1")
        {
            Goal goal = new SimpleGoal(
                name,
                description,
                points
            );

            _goals.Add(goal);
        }
        else if (goalType == "2")
        {
            Goal goal = new EternalGoal(
                name,
                description,
                points
            );

            _goals.Add(goal);
        }
        else
        {
            int target = ReadPositiveNumber(
                "How many times does this goal need " +
                "to be accomplished? "
            );

            int bonus = ReadPositiveNumber(
                "What is the bonus for accomplishing " +
                "it that many times? "
            );

            Goal goal = new ChecklistGoal(
                name,
                description,
                points,
                target,
                bonus
            );

            _goals.Add(goal);
        }

        Console.WriteLine("Your new goal has been created.");
    }

    public void ListGoalNames()
    {
        if (_goals.Count == 0)
        {
            Console.WriteLine("You do not have any goals yet.");
            return;
        }

        for (int i = 0; i < _goals.Count; i++)
        {
            Console.WriteLine(
                $"{i + 1}. {_goals[i].GetShortName()}"
            );
        }
    }

    public void ListGoalDetails()
    {
        Console.WriteLine("The goals are:");
        Console.WriteLine();

        if (_goals.Count == 0)
        {
            Console.WriteLine("You do not have any goals yet.");
            return;
        }

        for (int i = 0; i < _goals.Count; i++)
        {
            Console.WriteLine(
                $"{i + 1}. {_goals[i].GetDetailsString()}"
            );
        }
    }

    public void RecordEvent()
    {
        if (_goals.Count == 0)
        {
            Console.WriteLine(
                "You need to create a goal first."
            );

            return;
        }

        Console.WriteLine("The goals are:");
        ListGoalNames();

        Console.WriteLine();
        Console.Write("Which goal did you accomplish? ");

        string input = Console.ReadLine() ?? "";

        if (!int.TryParse(input, out int goalNumber))
        {
            Console.WriteLine(
                "Please enter a valid goal number."
            );

            return;
        }

        int goalIndex = goalNumber - 1;

        if (goalIndex < 0 || goalIndex >= _goals.Count)
        {
            Console.WriteLine(
                "That goal number does not exist."
            );

            return;
        }

        int previousLevel = GetLevel();

        int pointsEarned =
            _goals[goalIndex].RecordEvent();

        _score += pointsEarned;

        if (pointsEarned > 0)
        {
            _eventsRecorded++;

            Console.WriteLine();
            Console.WriteLine(
                $"Congratulations! You earned " +
                $"{pointsEarned} points!"
            );

            Console.WriteLine(
                $"You now have {_score} points."
            );
        }

        int newLevel = GetLevel();

        if (newLevel > previousLevel)
        {
            Console.WriteLine();
            Console.WriteLine(
                "********************************"
            );

            Console.WriteLine(
                $"LEVEL UP! You reached Level {newLevel}!"
            );

            Console.WriteLine(
                "********************************"
            );
        }

        CheckForBadges();
    }

    public void DisplayBadges()
    {
        Console.WriteLine("Your Badges:");
        Console.WriteLine();

        if (_badges.Count == 0)
        {
            Console.WriteLine(
                "You have not earned any badges yet."
            );

            Console.WriteLine();
            Console.WriteLine("Available badges:");
            Console.WriteLine(
                "- First Step: Record your first goal"
            );

            Console.WriteLine(
                "- Point Collector: Earn 1,000 points"
            );

            Console.WriteLine(
                "- Goal Getter: Complete five goals"
            );

            Console.WriteLine(
                "- Checklist Champion: Complete a " +
                "checklist goal"
            );

            return;
        }

        foreach (string badge in _badges)
        {
            Console.WriteLine($"* {badge}");
        }
    }

    private void CheckForBadges()
    {
        if (_eventsRecorded >= 1)
        {
            AwardBadge("First Step");
        }

        if (_score >= 1000)
        {
            AwardBadge("Point Collector");
        }

        int completedGoals = 0;

        foreach (Goal goal in _goals)
        {
            if (goal.IsComplete())
            {
                completedGoals++;
            }
        }

        if (completedGoals >= 5)
        {
            AwardBadge("Goal Getter");
        }

        foreach (Goal goal in _goals)
        {
            if (goal is ChecklistGoal &&
                goal.IsComplete())
            {
                AwardBadge("Checklist Champion");
                break;
            }
        }
    }

    private void AwardBadge(string badge)
    {
        if (!_badges.Contains(badge))
        {
            _badges.Add(badge);

            Console.WriteLine();
            Console.WriteLine(
                "********************************"
            );

            Console.WriteLine("NEW BADGE EARNED!");
            Console.WriteLine($"Badge: {badge}");

            Console.WriteLine(
                "********************************"
            );
        }
    }

    public void SaveGoals()
    {
        Console.Write(
            "What is the filename for the goal file? "
        );

        string filename = Console.ReadLine() ?? "";

        if (string.IsNullOrWhiteSpace(filename))
        {
            Console.WriteLine(
                "The filename cannot be empty."
            );

            return;
        }

        try
        {
            using (StreamWriter outputFile =
                   new StreamWriter(filename))
            {
                outputFile.WriteLine(_score);
                outputFile.WriteLine(_eventsRecorded);

                outputFile.WriteLine(
                    string.Join("|", _badges)
                );

                foreach (Goal goal in _goals)
                {
                    outputFile.WriteLine(
                        goal.GetStringRepresentation()
                    );
                }
            }

            Console.WriteLine(
                "Your goals and badges have been saved."
            );
        }
        catch (Exception error)
        {
            Console.WriteLine(
                $"The file could not be saved: " +
                $"{error.Message}"
            );
        }
    }

    public void LoadGoals()
    {
        Console.Write(
            "What is the filename for the goal file? "
        );

        string filename = Console.ReadLine() ?? "";

        if (!File.Exists(filename))
        {
            Console.WriteLine(
                "That file could not be found."
            );

            return;
        }

        try
        {
            string[] lines =
                File.ReadAllLines(filename);

            if (lines.Length < 3)
            {
                Console.WriteLine(
                    "The save file does not contain " +
                    "enough information."
                );

                return;
            }

            List<Goal> loadedGoals =
                new List<Goal>();

            List<string> loadedBadges =
                new List<string>();

            int loadedScore;
            int loadedEvents;

            if (!int.TryParse(
                    lines[0],
                    out loadedScore))
            {
                loadedScore = 0;
            }

            if (!int.TryParse(
                    lines[1],
                    out loadedEvents))
            {
                loadedEvents = 0;
            }

            if (!string.IsNullOrWhiteSpace(lines[2]))
            {
                string[] badges =
                    lines[2].Split('|');

                foreach (string badge in badges)
                {
                    if (!string.IsNullOrWhiteSpace(badge))
                    {
                        loadedBadges.Add(badge);
                    }
                }
            }

            for (int i = 3; i < lines.Length; i++)
            {
                string line = lines[i];

                string[] typeAndDetails =
                    line.Split(':', 2);

                if (typeAndDetails.Length != 2)
                {
                    continue;
                }

                string goalType =
                    typeAndDetails[0];

                string[] details =
                    typeAndDetails[1].Split('|');

                Goal? goal = CreateGoalFromFile(
                    goalType,
                    details
                );

                if (goal != null)
                {
                    loadedGoals.Add(goal);
                }
            }

            _score = loadedScore;
            _eventsRecorded = loadedEvents;
            _badges = loadedBadges;
            _goals = loadedGoals;

            Console.WriteLine(
                "Your goals and badges have been loaded."
            );
        }
        catch (Exception error)
        {
            Console.WriteLine(
                $"The file could not be loaded: " +
                $"{error.Message}"
            );
        }
    }

    private Goal? CreateGoalFromFile(
        string goalType,
        string[] details)
    {
        try
        {
            if (goalType == "SimpleGoal" &&
                details.Length >= 4)
            {
                string name = details[0];
                string description = details[1];
                int points = int.Parse(details[2]);

                bool isComplete =
                    bool.Parse(details[3]);

                return new SimpleGoal(
                    name,
                    description,
                    points,
                    isComplete
                );
            }

            if (goalType == "EternalGoal" &&
                details.Length >= 3)
            {
                string name = details[0];
                string description = details[1];
                int points = int.Parse(details[2]);

                return new EternalGoal(
                    name,
                    description,
                    points
                );
            }

            if (goalType == "ChecklistGoal" &&
                details.Length >= 6)
            {
                string name = details[0];
                string description = details[1];
                int points = int.Parse(details[2]);
                int target = int.Parse(details[3]);
                int bonus = int.Parse(details[4]);

                int amountCompleted =
                    int.Parse(details[5]);

                return new ChecklistGoal(
                    name,
                    description,
                    points,
                    target,
                    bonus,
                    amountCompleted
                );
            }
        }
        catch
        {
            Console.WriteLine(
                "One of the goals in the file " +
                "could not be loaded."
            );
        }

        return null;
    }

    private int ReadPositiveNumber(string prompt)
    {
        while (true)
        {
            Console.Write(prompt);

            string input =
                Console.ReadLine() ?? "";

            if (int.TryParse(input, out int number) &&
                number > 0)
            {
                return number;
            }

            Console.WriteLine(
                "Please enter a positive whole number."
            );
        }
    }

    private int GetLevel()
    {
        return (_score / 500) + 1;
    }
}