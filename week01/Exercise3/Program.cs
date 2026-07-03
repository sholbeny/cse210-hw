using System;

class Program
{
    static void Main(string[] args)
    {
        //Parts 1 and 2:
        // Console.WriteLine("What is the Magic Number? ");
        // int magicNumber = int.Parse(Console.ReadLine());

        Random randomGenerator = new Random();
        int magicNumber = randomGenerator.Next(1,101);

        Console.Write("What is your guess? ");
        int guess = int.Parse(Console.ReadLine());
        
        
        while (guess != magicNumber)
        
        {
            if (guess < magicNumber)
            {
                Console.WriteLine("Higher");
                }
            else if (guess > magicNumber)
            {
                Console.WriteLine("Lower");
                }

        Console.Write("What is your guess? ");
        guess = int.Parse(Console.ReadLine());
        
        }
        Console.WriteLine("Congratulations! You got it correct!");
    }
}