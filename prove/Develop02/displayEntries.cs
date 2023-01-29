public class displayEntries{
    public List<string> entries = new List<string>(){};
    public string displayCombo(){
        string combinedEntries = "";
        foreach(var entry in entries){
            combinedEntries = ($"{combinedEntries}{entry}\n");
        }
        return combinedEntries;
    }
}