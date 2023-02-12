using System;
class Program{
    static void Main(string[] args){
        GetScripture script1 = new GetScripture();
        string entry1 = script1.GetFromFile();
        Console.WriteLine($"{entry1}\n\nPress enter to cover a few words.");
        Console.ReadLine();

        CoverWord cover1 = new CoverWord();
        string entry2 = cover1.ReplaceText(entry1);
        Console.WriteLine($"{entry2}\n");
    }
}