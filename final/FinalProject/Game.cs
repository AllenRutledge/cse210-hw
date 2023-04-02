using System;
public class Game{
    public void Start(){
        Console.WriteLine("Please ensure you have at least 25 lines ready in Console. Press Enter when ready.");
        Console.ReadLine();
        MakeTitle();
        Thread.Sleep(2000);
        Run();
    }
    public void Run(){
        Room room = new Room(this,10,20,7,19);
        room.MakeRoom();
    }
    private void MakeTitle(){
        Console.Clear();
        string signFrame = "[]M===M[]===================[]M===M[]";
        string signSpace = "||---------------------------------||";
        string signThigh = " \\|---|/                     \\|---|/ ";
        string signLeg =   "  |---|                       |---|  ";
        string signFoot =  " [_____]                     [_____] ";
        int line = 0;
        Console.WriteLine(signFrame);
        while (line != 2){
            Console.WriteLine(signSpace);
            line += 1;
        }
        line = 0;
        Console.WriteLine("||----W-E-L-C-O-M-E-----T-O--------||");
        Console.WriteLine(signSpace);
        Console.WriteLine("||---------D-U-N-G-E-O-N-----------||");
        while (line != 2){
            Console.WriteLine(signSpace);
            line += 1;
        }
        Console.WriteLine(signFrame);
        Console.WriteLine(signThigh);
        while (line != 14){
            Console.WriteLine(signLeg);
            line += 1;
        }
        Console.WriteLine(signFoot);
    }
    public void GameOver(){
        Console.WriteLine("The dungeon has claimed you!");
        Environment.Exit(0);
    }
}