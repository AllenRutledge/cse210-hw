using System;

class Program
{
    static void Main(string[] args)
    {
        Random randomGenerator = new Random();
        int number = randomGenerator.Next(1, 101);
        bool guessed = false;
        int turns = 0;
        bool play_again = true;
        while (play_again == true)
        {
            while(guessed == false)
            {
                Console.Write("What is your guess? ");
                int guess = int.Parse(Console.ReadLine());
                turns += 1;
                if (guess > number)
                {
                    Console.WriteLine("Go lower.");
                }
                else if (guess < number)
                {
                    Console.WriteLine("Go higher.");
                }
                else
                {
                    Console.WriteLine("You did it!");
                    Console.WriteLine($"It took {turns} guesses!");
                    guessed = true;
                    Console.Write("Play again? y/n ");
                    string yes_no = Console.ReadLine();
                    if (yes_no.ToUpper() == "N")
                    {
                        play_again = false;
                    }
                }
            }
        }
    }
}