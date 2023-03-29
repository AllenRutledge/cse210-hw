public class Pawn{
    public string _name;
    public char _symbol;
    public int _maxhp;
    public int _hp;
    public int _atk;
    public int _def;
    public bool _isRanged;
    public int _x {get; set;}
    public int _y {get; set;}
    public Room _room;

    public Pawn(Room room, string name, int maxhp, int hp, int atk, int def, bool isRanged, int x, int y){
        _room = room;
        _name = name;
        _symbol = 'X';
        _maxhp = maxhp;
        _hp = hp;
        _atk = atk;
        _def = def;
        _isRanged = isRanged;
        _x = x;
        _y = y;
        _room._roomArray[_x, _y] = _symbol;
    }
    public virtual void Movement(){
        ConsoleKeyInfo board = Console.ReadKey(true);  // Wait for key press
        switch (board.Key){
            // North
            case ConsoleKey.W:
            case ConsoleKey.UpArrow:
                Move(_x, _y - 1);
                break;
            // South
            case ConsoleKey.S:
            case ConsoleKey.DownArrow:
                Move(_x, _y + 1);
                break;
            // West
            case ConsoleKey.A:
            case ConsoleKey.LeftArrow:
                Move(_x - 1, _y);
                break;
            // East
            case ConsoleKey.D:
            case ConsoleKey.RightArrow:
                Move(_x + 1, _y);
                break;
            default:
                // Invalid key = nothing happens
                break;
        }

        // Collide with Pawn/Enemy
        char targetChar = _room._roomArray[_x, _y];
        if (targetChar == '@' || targetChar == '$' || targetChar == '%' || targetChar == '&'){
            int targetX = _isRanged ? _x + 1 : _x;
            int targetY = _isRanged ? _y : _y + 1;
            Pawn targetPawn = _room.GetPawnAt(targetX, targetY);
            if (targetPawn != null){
                Attack(targetPawn);
            }
        }
    }
    public void Move(int x, int y){
        if (_room._roomArray[x, y] == '.'){
            _room._roomArray[_x, _y] = '.';
            _x = x;
            _y = y;
            _room._roomArray[_x, _y] = '@';
        }
    }
    public virtual int Attack(Pawn target){
        Pawn targetPawn = _room.GetPawnAt(_x, _y);
        if (targetPawn != null){
            int damage = _atk - targetPawn._def;
            if (damage < 0){
                damage = 0;
            }
            targetPawn.TakeDamage(damage);
            Console.WriteLine($"{_name} attacks {target._name} for {damage} damage!");
            return damage;    
        }
        return 0;
    }
    public void TakeDamage(int damage){
        _hp -= damage;
        if (_hp <= 0){
            Console.WriteLine($"{_name} has been defeated!");
            _room.RemoveTarget(_x, _y);
        }
    }
}