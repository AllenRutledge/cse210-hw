using System.IO; 
public class JournalFile{
    private DisplayEntries _writtenEntries;
    public JournalFile(DisplayEntries writtenEntries) {
        _writtenEntries = writtenEntries;
    }
    public void _saveFile(string fileName){
        
        using (StreamWriter outputFile = new StreamWriter($"{fileName}.txt")){
            string combo2 = _writtenEntries._displayCombo();
            outputFile.WriteLine(combo2);
        }
    }
    public void _loadFile(string fileName){
        string[] lines = System.IO.File.ReadAllLines($"{fileName}.txt");
        foreach (string line in lines){
            _writtenEntries._entries.Add(line);
        }
    }
}