public class Rectangle : Shape{
    private double _sideL;
    private double _sideW;
    public Rectangle(string color, double L, double W) : base(color){
        _sideL = L;
        _sideW = W;
    }
    public override double GetArea(){
        return _sideL * _sideW;
    }
}