using System;
using System.Collections.Generic;
public class CoverWord{
    Random _randomThing = new Random();
    public string ReplaceText(string verse){
        Console.Clear();
        string[] _verseWords = verse.Split(' ');
        Random random = new Random();
        bool withinQuotes = false;
        for (int i = 0; i < _verseWords.Length; i++) {
            if (_verseWords[i].StartsWith("\"")){
                withinQuotes = !withinQuotes;
            }
            if (withinQuotes){
                if (random.Next(2) == 0){
                    _verseWords[i] = new string('_', _verseWords[i].Length);
                }
            }
        }
        return string.Join(" ", _verseWords);
    }
}
