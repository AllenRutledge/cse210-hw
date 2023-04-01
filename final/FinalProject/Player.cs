public class Player:Pawn{
    private readonly string[] _roomLayout;
    public Player(Room room, string name, int maxhp, int hp, int atk, int def, bool isRanged, int x, int y) : base(room, name, maxhp, hp, atk, def, isRanged, x, y){
        _symbol = '@';
        _room = room;
        _roomLayout = _room.RoomLayout;
    }
    private ConsoleKeyInfo GetUserInput(char _symbol) {
        return Console.ReadKey(true);
    }
    public override void Movement(){
        ConsoleKeyInfo board = Console.ReadKey(true);  // Wait for key press
        switch (board.Key){
            // North
            case ConsoleKey.W:
            case ConsoleKey.UpArrow:
                CheckCollisions();
                if (!Move(_x, _y - 1)){
                    break;
                }
                SendUpdate(_x,_y);
                break;
            // South
            case ConsoleKey.S:
            case ConsoleKey.DownArrow:
                CheckCollisions();
                if (!Move(_x, _y + 1)){
                    break;
                }
                SendUpdate(_x,_y);
                break;
            // West
            case ConsoleKey.A:
            case ConsoleKey.LeftArrow:
                CheckCollisions();
                if (!Move(_x - 1, _y)){
                    break;
                }
                SendUpdate(_x,_y);
                break;
            // East
            case ConsoleKey.D:
            case ConsoleKey.RightArrow:
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
    }
    public void Play(){
        while (true){
            Movement();
        }
    }
}