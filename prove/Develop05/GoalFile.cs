using System.IO; 
public class GoalFile{
    private GoalList _writtenEntries;
    public GoalFile(GoalList writtenEntries) {
        _writtenEntries = writtenEntries;
    }
    public void SaveFile(){
        Console.Write("Input file name to be saved: ");
        string fileName = Console.ReadLine();
        using (StreamWriter outputFile = new StreamWriter($"{fileName}.txt")){
            string combo2 = _writtenEntries.DisplayGoals();
            outputFile.WriteLine(combo2);
        }
        Console.WriteLine($"{fileName}.txt saved!");
    }
    public void LoadFile(){
        Console.Write("Input file name to be loaded: ");
        string fileName = Console.ReadLine();
        string[] lines = System.IO.File.ReadAllLines($"{fileName}.txt");
        foreach (string line in lines){
            _writtenEntries._entries.Add(line);
        }
        Console.WriteLine($"{fileName}.txt loaded!");
    }
}