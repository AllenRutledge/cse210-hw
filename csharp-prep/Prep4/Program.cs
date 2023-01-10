using System;
using System.Collections.Generic;
class Program
{
    static void Main(string[] args)
    {
        // Setting it up before the input loop.
        List<int> numbers = new List<int>();
        int userNumber = -42;

        Console.WriteLine("Insert some numbers. (0 to quit)");
        while (userNumber != 0)
        {
            Console.Write("Input Number: ");
            userNumber = int.Parse(Console.ReadLine());
            if (userNumber != 0)
            {
                numbers.Add(userNumber);
            }
        }

        int sum = 0;
        foreach (int n in numbers)
        {
            sum += n;
        }

        //Turns the sum into a float for compatibility.
        float avg = ((float)sum) / numbers.Count;

        int max = numbers[0];
        foreach (int n in numbers)
        {
            if (n > max)
            {
                max = n;
            }
        }
        int min = numbers[0];
        foreach (int n in numbers)
        {
            if (n < min)
            {
                min = n;
            }
        }
        Console.WriteLine($"Sum: {sum}");
        Console.WriteLine($"Average: {avg}");
        Console.WriteLine($"Highest: {max}");
        Console.WriteLine($"Lowest: {min}");
    }
}