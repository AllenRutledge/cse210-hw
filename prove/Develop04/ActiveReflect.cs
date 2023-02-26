public class ActiveReflect : Timer{
    public List<string> _questions = new List<string>(){
        "Think of a time when you stood up for someone else.",
        "Think of a time when you did something really difficult.",
        "Think of a time when you helped someone in need.",
        "Think of a time when you did something truly selfless."
    };
    public List<string> _reflectQuestions = new List<string>(){
        "Why was this experience meaningful to you?",
        "Have you ever done anything like this before?",
        "How did you get started?",
        "How did you feel when it was complete?",
        "What made this time different than other times when you were not as successful?",
        "What is your favorite thing about this experience?",
        "What could you learn from this experience that applies to other situations?",
        "What did you learn about yourself through this experience?",
        "How can you keep this experience in mind in the future?"
    };
    public string ReflectPrompt(){
        Random _randomNum = new Random();
        string _promptQuestion = (_questions[_randomNum.Next(3)]);
        string _reflectQuestion = (_reflectQuestions[_randomNum.Next(8)]);
        return ($"\n{_promptQuestion}\n{_reflectQuestion}");
    }

    public void Reflecting(int time){
        _reps = ((time/1000) / (_repTime*2));
        while(_reps > 0){
            Console.WriteLine(ReflectPrompt());
            ClockTick(_repTime*2000);
            _reps--;
        }
        SayDone();
    }
}
