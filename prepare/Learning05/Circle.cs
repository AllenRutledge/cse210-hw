public class Circle : Shape{
    private double _rad;
    public Circle(string color, double R) : base(color){
        _rad = R;
    }
    public override double GetArea(){
        return (_rad*_rad) * Math.PI;
    }
}