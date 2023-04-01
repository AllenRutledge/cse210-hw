    public class Enemy : Pawn{
    private int _targetX;
    private int _targetY;
    private Player _target;
    private readonly string[] _roomLayout;
    public Enemy(Room room, char symbol, string name, int maxhp, int hp, int atk, int def, bool isRanged, int x, int y) 
        : base(room, name, maxhp, hp, atk, def, isRanged, x, y){
        _symbol = symbol;
        _room = room;
        _roomLayout = _room.RoomLayout;
    }
    // public override void Movement(){
    //     // If no target, find one
    //     if (_targetX == 0 && _targetY == 0){
    //         Player closestPlayer = _room.FindPlayer(_x, _y);
    //         if (closestPlayer != null){
    //             _targetX = closestPlayer._x;
    //             _targetY = closestPlayer._y;
    //         }
    //     }
    //     // If target found, move towards it
    //     if (_targetX != 0 || _targetY != 0){
    //         int dx = Math.Sign(_targetX - _x);
    //         int dy = Math.Sign(_targetY - _y);
    //         // Check if adjacent to player
    //         if ((dx == 0 && Math.Abs(_targetY - _y) == 1) || (dy == 0 && Math.Abs(_targetX - _x) == 1)){
    //             // Attack player
    //             Player player = _room.FindPlayer(_targetX, _targetY);
    //             if (player != null){
    //                 Attack(player);
    //             }
    //             _targetX = 0;
    //             _targetY = 0;
    //         }else{
    //             // Move to player
    //             int newX = _x + dx;
    //             int newY = _y + dy;
    //             if (_room.IsInBounds(newX, newY) && _room._roomArray[newX, newY] == '.'){
    //                 Move(newX, newY);
    //             }
    //         }
    //     }
    // }
    // public override void Movement(){
    //     // If no target, find one
    //     if (_target == null){
    //         _target = _room.FindPlayer(this._x, this._y);
    //     }
    //     // If target found, move towards it
    //     if (_target != null){
    //         int dx = Math.Sign(_target._x - _x);
    //         int dy = Math.Sign(_target._y - _y);
    //         // Check if adjacent to player
    //         if ((dx == 0 && Math.Abs(_target._y - _y) == 1) || (dy == 0 && Math.Abs(_target._x - _x) == 1)){
    //             // Attack player
    //             Attack(_target);
    //         }else{
    //             // Move towards player
    //             int newX = _x + dx;
    //             int newY = _y + dy;
    //             if (_room.IsInBounds(newX, newY) && _room._roomArray[newX, newY] == '.'){
    //                 Move(newX, newY);
    //             }
    //         }
    //     }
    // }
    public void SendUpdate(int x, int y){
        _room.UpdateLayout(_roomLayout, x, y); // give changed data to Room class
        _room.DrawRoom(_roomLayout); // redraw room with new data
        _room._playX = _x;
        _room._playY = _y;
    }
    public void TargetPlayer(Player player){
        _target = player;
    }
}
