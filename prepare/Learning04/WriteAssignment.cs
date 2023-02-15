public class WriteAssignment : Assignment{
    private string _title;
    public WriteAssignment(string sName, string topic, string title)
    : base(sName, topic){
        _title = title;
    }
    public string GetWriteInfo(){
        string sName = GetName();
        return ($"Project: {_title} by student {sName}");
    }
}