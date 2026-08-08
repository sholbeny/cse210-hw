public class ChecklistGoal : Goal
{
    private int _amountCompleted;
    private int _target;
    private int _bonus;

    public ChecklistGoal(
        string shortName,
        string description,
        int points,
        int target,
        int bonus,
        int amountCompleted = 0)
        : base(shortName, description, points)
    {
        _target = target;
        _bonus = bonus;
        _amountCompleted = amountCompleted;
    }

    public override int RecordEvent()
    {
        if (IsComplete())
        {
            Console.WriteLine(
                "This checklist goal has already been completed."
            );

            return 0;
        }

        _amountCompleted++;

        int pointsEarned = GetPoints();

        if (_amountCompleted == _target)
        {
            pointsEarned += _bonus;

            Console.WriteLine();
            Console.WriteLine("Checklist goal completed!");
            Console.WriteLine(
                $"You earned a bonus of {_bonus} points!"
            );
        }

        return pointsEarned;
    }

    public override bool IsComplete()
    {
        return _amountCompleted >= _target;
    }

    public override string GetDetailsString()
    {
        string checkbox;

        if (IsComplete())
        {
            checkbox = "[X]";
        }
        else
        {
            checkbox = "[ ]";
        }

        return $"{checkbox} {GetShortName()} " +
               $"({GetDescription()}) -- Completed " +
               $"{_amountCompleted}/{_target} times";
    }

    public override string GetStringRepresentation()
    {
        return $"ChecklistGoal:{GetShortName()}|" +
               $"{GetDescription()}|{GetPoints()}|{_target}|" +
               $"{_bonus}|{_amountCompleted}";
    }
}