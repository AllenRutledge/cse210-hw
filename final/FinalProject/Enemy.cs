    public class Enemy : Pawn{
    private Player _target;
    public Enemy(Room room, string name, int maxhp, int hp, int atk, int def, bool isRanged, int x, int y) 
        : base(room, name, maxhp, hp, atk, def, isRanged, x, y){
        _symbol = '&';
    }
    public override void Movement(){
        // If no target, find one
        if (_target == null){
            _target = _room.FindClosestPawn(this._x, this._y) as Player;
        }
        // If target found, move towards it
        if (_target != null){
            int dx = Math.Sign(_target._x - _x);
            int dy = Math.Sign(_target._y - _y);
            // Check if adjacent to player
            if ((dx == 0 && Math.Abs(_target._y - _y) == 1) || (dy == 0 && Math.Abs(_target._x - _x) == 1)){
                // Attack player
                Attack(_target);
            }else{
                // Move towards player
                int newX = _x + dx;
                int newY = _y + dy;
                if (_room.IsInBounds(newX, newY) && _room._roomArray[newX, newY] == '.'){
                    Move(newX, newY);
                }
            }
        }
    }
    public void TargetPlayer(Player player){
        _target = player;
    }
}
