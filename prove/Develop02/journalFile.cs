using System.IO; 
public class journalFile{
    private displayEntries _writtenEntries;
    public journalFile(displayEntries writtenEntries) {
        _writtenEntries = writtenEntries;
    }
    public void saveFile(string fileName){
        
        using (StreamWriter outputFile = new StreamWriter($"{fileName}.txt")){
            string combo2 = _writtenEntries.displayCombo();
            outputFile.WriteLine(combo2);
        }
    }
    public void loadFile(string fileName){
        string[] lines = System.IO.File.ReadAllLines($"{fileName}.txt");
        foreach (string line in lines){
            _writtenEntries.entries.Add(line);
        }
    }
}