using System;

class Program
{
    static void Main(string[] args)
    {
        Console.Write("What percentage grade do you have? ");
        string answer = Console.ReadLine();
        int percent = int.Parse(answer);
        string letter = "";
        if (percent >= 90)
        {
            letter = "A";
        }
        else if (percent >= 80)
        {
            letter = "B";
        }
        else if (percent >= 70)
        {
            letter = "C";
        }
        else if (percent >= 60)
        {
            letter = "D";
        }
        else
        {
            letter = "F";
        }

        Console.WriteLine($"You recieved {percent}% ({letter}) as your grade.");

        if (percent >= 70)
        {
            Console.Write("Congratulations! You passed!");
        }
        else
        {
            Console.Write("Unfortunately, you didn't pass. Please try again.");
        }
    }
}