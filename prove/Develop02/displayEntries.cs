public class DisplayEntries{
    public List<string> _entries = new List<string>(){};
    public string _displayCombo(){
        string combinedEntries = "";
        foreach(var entry in _entries){
            combinedEntries = ($"{combinedEntries}{entry}\n");
        }
        return combinedEntries;
    }
}