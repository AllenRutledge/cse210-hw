public class Pawn{
    public string _name;
    // Symbol = what pawn will look like
    public char _symbol;
    private int _maxhp;
    public int _hp;
    // Def reduces Atk damage
    public int _atk;
    public int _def;
    public bool _isAlive = true;
    public bool _isRanged;
    // Coordinates
    public int _x {get; set;}
    public int _y {get; set;}
    // Room to maintain ref
    public Room _room;
    public Game _game;
    public enum Direction {North,South,West,East,None}
    // Build instance of Pawn
    public Pawn(Game game, Room room, string name, int maxhp, int hp, int atk, int def, bool isRanged, int x, int y){
        _game = game;
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
    public virtual void Movement(){}
    public void CheckCollisions(){
        Player player = _room.FindPlayer();
        int targetX = _x;
        int targetY = _y;
        switch (player._lastMoveDirection){
        case (int)Direction.North:
            targetY--;
            break;
        case (int)Direction.South:
            targetY++;
            break;
        case (int)Direction.West:
            targetX--;
            break;
        case (int)Direction.East:
            targetX++;
            break;
        default:
            break;
    }
        
        char targetChar = _room._roomArray[_x, _y];
        if (targetChar == '@' || targetChar == '$' || targetChar == '%' || targetChar == '&'){
            Pawn targetPawn = _room.GetPawnAt(targetX, targetY);
            if (targetPawn != null){
                Attack(targetPawn);
            }
        }
    }
    // Move
    public bool Move(int x, int y){
        x = Math.Clamp(x, 1, _room._roomArray.GetLength(0) - 2);
        y = Math.Clamp(y, 1, _room._roomArray.GetLength(1) - 2);
        // Tile is empty?
        char destTile = _room._roomArray[x, y];
        if (destTile != '.' && destTile != '@'){
            // Collision detected, no move
            return false;
        }
        // Move pawn to destination
        _room._roomArray[_x, _y] = '.';
        _x = x;
        _y = y;
        _room._roomArray[_x, _y] = '@';
        return true;
    }
    // Attack target
    public int Attack(Pawn target){
        if (target == null){
        Console.WriteLine($"No target.");
        return 0;
        }
        // Damage subtracted by Def stat
        int damage = _atk - target._def;
        // Punches won't heal
        if (damage < 0){
            damage = 0;
        }
        Console.WriteLine($"{_name} attacks {target._name} for {damage} damage!");
        target.TakeDamage(damage);
        Thread.Sleep(200);
        return damage;
    }
    public virtual void TakeDamage(int damage){
        _hp -= damage;
        if (_hp <= 0){
            Console.WriteLine($"{_name} defeated!");
            if (_name == "Player"){
                _game.GameOver();
            }
            Thread.Sleep(1000);
            _isAlive = false;
            _room.RemoveTarget(_x, _y);
        }else{
            _isAlive = true;
        }
    }
}