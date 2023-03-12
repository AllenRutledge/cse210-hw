using System;

class Program{
    static void Main(string[] args){
        DateTime today = DateTime.Today;
         int menuNum = 0;
        var writtenEntries = new GoalList(){};
            while (menuNum != 5){
                Console.WriteLine("Welcome to the Goal Tracker!");
                Console.WriteLine($"Today is {today.ToString("MM/dd/yyyy")}");
                Console.WriteLine("==========================");
                Console.WriteLine("1. New Goal");
                Console.WriteLine("2. List Goals");
                Console.WriteLine("3. Load Goals");
                Console.WriteLine("4. Save Goals");
                Console.WriteLine("5. Exit Program");
                menuNum = int.Parse(Console.ReadLine());
            
                if (menuNum == 1){
                    GoalNew a1 = new GoalNew(writtenEntries);
                    string e1 = a1.PromptGoal();
                    Console.WriteLine(e1);
                }else if(menuNum == 2){
                    string a2 = writtenEntries.DisplayGoals();
                    Console.WriteLine(a2);
                }else if(menuNum == 3){
                    var a3 = new GoalFile(writtenEntries);
                    a3.LoadFile();
                }else if(menuNum == 4){
                    var a4 = new GoalFile(writtenEntries);
                    a4.SaveFile();
                }else if(menuNum == 5){
                    
                }
            }
    }
}