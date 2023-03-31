public class Pawn{
    // Encapsulation
    private string _name;
    public string Name {
        get { return _name; }
        set { _name = value; }}
    // Symbol = what pawn will look like
    public char _symbol;
    // Max HP varies between enemies
    public int _maxhp;
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

    // Build instance of Pawn
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
    // Move around
    public virtual void Movement(){
        ConsoleKeyInfo board = Console.ReadKey(true);  // Wait for key press
        switch (board.Key){
            // North
            case ConsoleKey.W:
            case ConsoleKey.UpArrow:
                if (Move(_x, _y - 1)){
                    CheckCollisions();
                }
                break;
            // South
            case ConsoleKey.S:
            case ConsoleKey.DownArrow:
                if (Move(_x, _y + 1)){
                    CheckCollisions();
                }
                break;
            // West
            case ConsoleKey.A:
            case ConsoleKey.LeftArrow:
                if (Move(_x - 1, _y)){
                    CheckCollisions();
                }
                break;
            // East
            case ConsoleKey.D:
            case ConsoleKey.RightArrow:
                if (Move(_x + 1, _y)){
                    CheckCollisions();
                }
                break;
            default:
                // Invalid key = nothing happens
                break;
        }
    }
    private void CheckCollisions(){
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
    // Move
    public bool Move(int x, int y){
        if (_room._roomArray[x, y] == '.'){
            _room._roomArray[_x, _y] = '.';
            _x = x;
            _y = y;
            _room._roomArray[_x, _y] = '@';
            return true;
        }else{
            return false;
        }
    }
    // Attack target
    public virtual int Attack(Pawn target){
        if (target == null) {
        Console.WriteLine($"No target present.");
        return 0;
        }
        // Damage subtracted by Def stat
        int damage = _atk - target._def;
        // Punches won't heal
        if (damage < 0){
            damage = 0;
        }
        target.TakeDamage(damage);
        Console.WriteLine($"{_name} attacks {target._name} for {damage} damage!");
        return damage;
    }
    public void TakeDamage(int damage){
        _hp -= damage;
        if (_hp <= 0){
            Console.WriteLine($"{_name} has been defeated!");
            _isAlive = false;
            _room.RemoveTarget(_x, _y);
        }else{
            _isAlive = true;
        }
    }
}