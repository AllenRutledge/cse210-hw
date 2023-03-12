public class GoalNew{
    public int _goalType;
    public string _goalName;
    public string _goalDesc;
    private int _goalScore;
    private int _goalBonus;
    public int _goalTimes;
    public int _goalDone;
    private GoalList _writtenEntries;
    public GoalNew(GoalList writtenEntries) {
        _writtenEntries = writtenEntries;
    }
    public int PromptQ1(){
        Console.WriteLine("1. Simple");
        Console.WriteLine("2. Eternal");
        Console.WriteLine("3. Checklist");
        Console.WriteLine("Goal type: ");
        _goalType = int.Parse(Console.ReadLine());
        return _goalType;
    }
    
    public string PromptGoal(){
        string _combinedEntry = "";
        _goalType = PromptQ1();
        Console.WriteLine("Goal name: ");
        _goalName = Console.ReadLine();
        Console.WriteLine("Goal description: ");
        _goalDesc = Console.ReadLine();
        Console.WriteLine("Goal points: ");
        _goalScore = int.Parse(Console.ReadLine());
        if (_goalType == 2){
            _combinedEntry = ($"{_goalType}. {_goalName} ({_goalDesc})");
        }else if (_goalType == 3){
            Console.WriteLine("Times to accomplish goal for bonus: ");
            _goalTimes = int.Parse(Console.ReadLine());
            Console.WriteLine("Goal bonus: ");
            _goalBonus = int.Parse(Console.ReadLine());
            _combinedEntry = ($"{_goalType}. [{_goalDone}/{_goalTimes}] {_goalName} ({_goalDesc})");
        }else{
            _goalType = 1;
            _combinedEntry = ($"{_goalType}. [ {_goalDone} ] {_goalName} ({_goalDesc})");
        }
        _writtenEntries._entries.Add(_combinedEntry);
        return _combinedEntry;
    }
}