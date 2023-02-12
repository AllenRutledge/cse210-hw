using System;
using System.IO;
using System.Collections.Generic;
public class GetScripture{
string _darn = "We couldn't find a scripture :(";
    public string GetFromFile(){
        Console.Clear();
        string[] _verses = System.IO.File.ReadAllLines("scriptFile.csv");
        try{
            _verses = System.IO.File.ReadAllLines("scriptFile.csv");
            }catch (FileNotFoundException) {
                Console.WriteLine("Can't find scriptFile.csv");
                return _darn;
            }catch (IOException){
                Console.WriteLine("Trouble with scriptFile.csv");
                return _darn;
        }
        Random rng = new Random();
        int _randomVerse = rng.Next(0, _verses.Length - 1);
        string _selectVerse = _verses[_randomVerse];
        List<string> _verse = new List<string>();
        int start = 0;
        bool inQuotes = false;
        for (int i = 0; i < _selectVerse.Length; i++) {
            if (_selectVerse[i] == '"'){
                inQuotes = !inQuotes;
            }else if (_selectVerse[i] == ',' && !inQuotes){
                _verse.Add(_selectVerse.Substring(start, i - start));
                start = i + 1;
            }
        }
        _verse.Add(_selectVerse.Substring(start));
        if (_verse.Count > 0){
            string _verseBook = _verse[0];
            string _verseCh = _verse[1];
            string _verseLine = _verse[2];
            string _verseTxt = _verse[3];
            if (_verseTxt.Contains("\"")){
                string _fullVerse = ($"{_verseBook} {_verseCh}:{_verseLine} {_verseTxt}");
                return _fullVerse;
            }else{
                string _fullVerse = ($"{_verseBook} {_verseCh}:{_verseLine} \"{_verseTxt}\"");
                return _fullVerse;
            }
        }
        return _darn;
    }
}