using System;
class Program
{
    static void Main(string[] args)
    {
        int menuNum = 0;
        var writtenEntries = new DisplayEntries(){};
            while (menuNum != 5){
                Console.WriteLine("-=Welcome to the Journal!=-");
                Console.WriteLine("Please Select 1-5");
                Console.WriteLine("==========================");
                Console.WriteLine("1. New Journal Entry");
                Console.WriteLine("2. Display Written Entries");
                Console.WriteLine("3. Load Previous Entries");
                Console.WriteLine("4. Save Current Entries");
                Console.WriteLine("5. Exit Program");
                menuNum = int.Parse(Console.ReadLine());
            
                if (menuNum == 1){
                    WritePrompt prompt1 = new WritePrompt(writtenEntries);
                    string entry1 = prompt1._displayPrompt();
                    Console.WriteLine(entry1);
                    Console.WriteLine();
                }else if(menuNum == 2){
                    string combo1 = writtenEntries._displayCombo();
                    Console.WriteLine(combo1);
                }else if(menuNum == 3){
                    Console.Write("Input file name to be loaded: ");
                    string fileName = Console.ReadLine();
                    var myLoadFile = new JournalFile(writtenEntries);
                    myLoadFile._loadFile(fileName);
                    Console.WriteLine($"{fileName}.txt loaded!");
                }else if(menuNum == 4){
                    Console.Write("Input file name to be saved: ");
                    string fileName = Console.ReadLine();
                    var mySaveFile = new JournalFile(writtenEntries);
                    mySaveFile._saveFile(fileName);
                    Console.WriteLine($"{fileName}.txt saved!");
                }
            }
    }
}