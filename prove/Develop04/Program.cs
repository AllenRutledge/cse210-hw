using System;

class Program
{
    static void Main(string[] args){
        int menuNum = 0;
        Console.WriteLine("-=Welcome to the Meditation Program!=-");
            while (menuNum < 4){
                Console.WriteLine("Please Select 1-4");
                Console.WriteLine("==========================");
                Console.WriteLine("1. Breathing Activity");
                Console.WriteLine("2. Reflection Activity");
                Console.WriteLine("3. Listing Activity");
                Console.WriteLine("4. Exit Program");
                menuNum = int.Parse(Console.ReadLine());
            
                if (menuNum == 1){
                    ActiveBreath a1 = new ActiveBreath();
                    int _time = a1.GetTime();
                    a1.Breathing(_time);
                }else if(menuNum == 2){
                    ActiveReflect a2 = new ActiveReflect();
                    int _time = a2.GetTime();
                    a2.Reflecting(_time);
                }else if(menuNum == 3){
                    ActiveList a3 = new ActiveList();
                    int _time = a3.GetTime();
                    a3.Listing(_time);
                }
            }
    }
}