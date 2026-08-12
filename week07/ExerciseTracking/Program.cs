/*
Creativity and Exceeding Requirements:

I added a Random Workout Generator to the program.
The user can press ENTER to receive a randomly selected
exercise, workout time, and goal.

Each exercise has a different type of goal. Running gives
a distance goal, cycling gives a speed goal, and swimming
gives a lap goal.
*/

List<Activity> activities = new List<Activity>();

Running running = new Running(
    new DateTime(2026, 8, 12),
    30,
    3.0
);

Cycling cycling = new Cycling(
    new DateTime(2026, 8, 10),
    45,
    12.0
);

Swimming swimming = new Swimming(
    new DateTime(2026, 8, 8),
    30,
    40
);

activities.Add(running);
activities.Add(cycling);
activities.Add(swimming);


// Display exercise history

Console.WriteLine("===== Exercise History =====");
Console.WriteLine();

foreach (Activity activity in activities)
{
    Console.WriteLine(activity.GetSummary());
}


// Random Workout Generator

Console.WriteLine();
Console.WriteLine("===== Random Workout Generator =====");
Console.WriteLine();
Console.WriteLine("Press ENTER to get a random workout!");
Console.ReadLine();

Random random = new Random();

string[] exerciseTypes =
{
    "Running",
    "Cycling",
    "Swimming"
};

int[] workoutTimes =
{
    10,
    15,
    20,
    25,
    30,
    45,
    60
};

string randomExercise =
    exerciseTypes[random.Next(exerciseTypes.Length)];

int randomTime =
    workoutTimes[random.Next(workoutTimes.Length)];

Console.WriteLine();
Console.WriteLine("===== Your Random Workout =====");
Console.WriteLine();

Console.WriteLine($"Activity: {randomExercise}");
Console.WriteLine($"Time: {randomTime} minutes");


// Create a goal based on the random exercise

if (randomExercise == "Running")
{
    double[] distances =
    {
        1.0,
        1.5,
        2.0,
        2.5,
        3.0,
        4.0,
        5.0
    };

    double randomDistance =
        distances[random.Next(distances.Length)];

    Console.WriteLine($"Goal: Run {randomDistance} miles");
}
else if (randomExercise == "Cycling")
{
    int[] speeds =
    {
        8,
        10,
        12,
        14,
        16
    };

    int randomSpeed =
        speeds[random.Next(speeds.Length)];

    Console.WriteLine($"Goal: Try to maintain {randomSpeed} mph");
}
else if (randomExercise == "Swimming")
{
    int[] laps =
    {
        10,
        15,
        20,
        25,
        30,
        40
    };

    int randomLaps =
        laps[random.Next(laps.Length)];

    Console.WriteLine($"Goal: Swim {randomLaps} laps");
}

Console.WriteLine();
Console.WriteLine("Have a great workout!");