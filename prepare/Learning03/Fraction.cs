using System;

public class Fraction{
    private int _high;
    private int _low;
    public Fraction(){
        _high = 1;
        _low = 1;
    }
    public Fraction(int wholeNum){
        _high = wholeNum;
        _low = 1;
    }
    public Fraction(int high, int low){
        _high = high;
        _low = low;
    }
    public string GetString(){
        string txt = ($"{_high}/{_low}");
        return txt;
    }
    public double GetDouble(){
        return (double)_high / (double)_low;
    }
}