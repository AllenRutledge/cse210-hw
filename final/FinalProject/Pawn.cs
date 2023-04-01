public class Pawn{
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
    public virtual void Movement(){}
    public void CheckCollisions(){
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
            Thread.Sleep(1000);
            _isAlive = false;
            _room.RemoveTarget(_x, _y);
        }else{
            _isAlive = true;
        }
    }
}