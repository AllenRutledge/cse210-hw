using System;
using System.Diagnostics;
public class ActiveList : Timer{
    public List<string> _questions = new List<string>(){
        "Who are people that you appreciate?",
        "What are personal strengths of yours?",
        "Who are people that you have helped this week?",
        "When have you felt the Holy Ghost this month?",
        "Who are some of your personal heroes?"
    };
    public string ListPrompt(){
        Random _randomNum = new Random();
        string _promptQuestion = (_questions[_randomNum.Next(4)]);
        return ($"\n{_promptQuestion}");
    }
    public void Listing(int time){
        Console.WriteLine(ListPrompt());
        Thread.Sleep(5000);
        int _itemTotal = 0;
        List<string> _items = new List<string>();
        Stopwatch _stopwatch = new Stopwatch();
        while (time > 0){
            _stopwatch.Start();
            Console.Write("> ");
            string _item = Console.ReadLine();
            _stopwatch.Stop();
            time -= (int)Math.Round(_stopwatch.Elapsed.TotalMilliseconds);
            if (string.IsNullOrEmpty(_item)){
                break;
            }
            _items.Add(_item);
            if (time <= 0){
            break;
        }
        Console.WriteLine($"Time remaining: {time / 1000} seconds");
        // Reset the stopwatch for the next loop iteration
        _stopwatch.Reset();
    }
    foreach (string i in _items){
        _itemTotal++;
    }
    Console.WriteLine($"Great job! You wrote {_itemTotal} items!");
    SayDone();
}

}