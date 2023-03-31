    public class Enemy : Pawn{
    private Random _random;
    private Player _target;
    public Enemy(Room room, string name, int maxhp, int hp, int atk, int def, bool isRanged, int x, int y) 
        : base(room, name, maxhp, hp, atk, def, isRanged, x, y){
        _random = new Random();
        _symbol = '&';
    }

    public override void Movement(){
    // If no target, find one
        if (_target == null){
            _target = _room.FindClosestPawn(this._x, this._y) as Player;
        }

        // If target found, move to it
        if (_target != null)
        {
            int dx = Math.Sign(_target._x - _x);
            int dy = Math.Sign(_target._y - _y);

            // New spot valid?
            int newX = _x + dx;
            int newY = _y + dy;

            if (_room.IsInBounds(newX, newY) && _room._roomArray[newX, newY] == '.')
            {
                Move(newX, newY);
            }else{
                // Do nothing
                return;
            }
        }
    }
    public void TargetPlayer(Player player){
        _target = player;
    }
}
