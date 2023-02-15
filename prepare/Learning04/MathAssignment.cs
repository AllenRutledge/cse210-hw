public class MathAssignment : Assignment{
    private string _txtSection;
    private string _problems;
    public MathAssignment(string sName, string topic, string txtSection, string problems)
    : base(sName, topic){
        _txtSection = txtSection;
        _problems = problems;
    }
    public string GetHWList(){
        return ($"Section: {_txtSection} | Problems: {_problems}");
    }
}