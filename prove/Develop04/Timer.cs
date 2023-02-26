public class Timer{
    public int _time;
    public int _repTime = 5;
    public float _reps;
    public int GetTime(){
        Console.WriteLine("How long, in seconds, would you like? ");
        int _promptTime = int.Parse(Console.ReadLine());
        int _time = (_promptTime * 1000);
        return _time;
    }
    public void SayDone(){
        Console.WriteLine("\n //////////////////\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\");
        Console.WriteLine("||  Exercise complete, great job!  ||");
        Console.WriteLine(" \\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\/////////////////");
        Thread.Sleep(1000);
    }
    public void ClockTick(int time){
        while(time > 0){
            Console.Write("+");
            Thread.Sleep(500);
            Console.Write("\b \b"); // Erase character
            Console.Write("-"); // Replace 
            time = time - 500;
        }
    }
}