public class Pawn{
    public int _hp;
    public int _atk;
    public int _def;
    public bool _isRanged;
    public virtual void Movement(){

    }
    public virtual int Attack(){

        return _atk - _def;
    }

}