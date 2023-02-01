using System;

class Program
{
    static void Main(string[] args)
    {
        Fraction f1 = new Fraction();
        Console.WriteLine($"{f1.GetString()} = {f1.GetDouble()}\n");

        Fraction f2 = new Fraction(5);
        Console.WriteLine($"{f2.GetString()} = {f2.GetDouble()}\n");

        Fraction f3 = new Fraction(3, 4);
        Console.WriteLine($"{f3.GetString()} = {f3.GetDouble()}\n");

        Fraction f4 = new Fraction(1, 3);
        Console.WriteLine($"{f4.GetString()} = {f4.GetDouble()}");
    }
}