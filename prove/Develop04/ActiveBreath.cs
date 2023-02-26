public class ActiveBreath : Timer{
    public void BreatheRep(){
        while (_repTime != 0){
            Console.Write(_repTime);
            Thread.Sleep(1000);
            _repTime--;
        }
    }
    public void Breathing(int time){
        _reps = ((time/1000) / (_repTime*2));
        while (_reps > 0){
            Console.WriteLine("\nBreathe in...");
            BreatheRep();
            _repTime = 5;
            Console.WriteLine("\nBreathe out...");
            BreatheRep();
            _repTime = 5;
            _reps--;
        }
        SayDone();
    }
}