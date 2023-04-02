public class Player:Pawn{
    private readonly string[] _roomLayout;
    public int _lastMoveDirection { get; set; }

    public Player(Game game, Room room, string name, int maxhp, int hp, int atk, int def, bool isRanged, int x, int y) : base(game, room, name, maxhp, hp, atk, def, isRanged, x, y){
        _symbol = '@';
        _roomLayout = _room.RoomLayout;
        _lastMoveDirection = (int)Direction.None;
    }
    public override void Movement(){
        ConsoleKeyInfo board = Console.ReadKey(true);  // Wait for key press
        switch (board.Key){
            // North
            case ConsoleKey.W:
            case ConsoleKey.UpArrow:
                _lastMoveDirection = (int)Direction.North;
                CheckCollisions();
                if (!Move(_x, _y - 1)){
                    break;
                }
                SendUpdate(_x,_y);
                break;
            // South
            case ConsoleKey.S:
            case ConsoleKey.DownArrow:
                _lastMoveDirection = (int)Direction.South;
                CheckCollisions();
                if (!Move(_x, _y + 1)){
                    break;
                }
                SendUpdate(_x,_y);
                break;
            // West
            case ConsoleKey.A:
            case ConsoleKey.LeftArrow:
                _lastMoveDirection = (int)Direction.West;
                CheckCollisions();
                if (!Move(_x - 1, _y)){
                    break;
                }
                SendUpdate(_x,_y);
                break;
            // East
            case ConsoleKey.D:
            case ConsoleKey.RightArrow:
                _lastMoveDirection = (int)Direction.East;
                CheckCollisions();
                if (!Move(_x + 1, _y)){
                    break;
                }
                SendUpdate(_x,_y);
                break;
            default:
                // Invalid key = nothing happens
                break;
        }
    }
    public void SendUpdate(int x, int y){
        _room.UpdateLayout(_roomLayout, x, y); // give changed data to Room class
        _room.DrawRoom(_roomLayout); // redraw room with new data
        _room._playX = _x;
        _room._playY = _y;
        
    }
    public void Play(){
        while (true){
            Movement();
        }
    }
}