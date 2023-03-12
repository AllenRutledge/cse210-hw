public class GoalList{
    public List<string> _entries = new List<string>(){};
    public string DisplayGoals(){
        string combinedEntries = "";
        foreach(var entry in _entries){
            combinedEntries = ($"{combinedEntries}{entry}\n");
        }
        return combinedEntries;
    }
}