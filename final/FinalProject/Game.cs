using System;
public class Game{
    Random _rng = new Random();
    public void Start(){
        Console.Clear();
                Console.WriteLine("\n //////////////////\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\");
        Console.WriteLine("||||||-Welcome-To-The-Dungeon!-||||||");
        Console.WriteLine(" \\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\/////////////////");
        Thread.Sleep(2000);
        Run();
    }
    public void Run(){
        Room room = new Room(3,20,2,19);
        room.MakeRoom();
    }
}