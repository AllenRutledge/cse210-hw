public class Assignment{
    private string _sName;
    private string _topic;

    public Assignment(string sName, string topic){
        _sName = sName;
        _topic = topic;
    }
    public string GetName(){
        return _sName;
    }
    public string GetTopic(){
        return _topic;
    }
    public string GetSummary(){
        return ($"{_sName} - {_topic}");
    }
}