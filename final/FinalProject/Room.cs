using System;
public class Room{
    // Size
    public int _width { get; private set; }
    public int _height { get; private set; }
    public int _playX;
    public int _playY;
    // Key position
    public int _keyX { get; private set; }
    public int _keyY { get; private set; }
    // Enemy position
    public int _enemyX { get; private set; }
    public int _enemyY { get; private set; }
    private List<Pawn> _pawns;
    Random rand = new Random();
    public Game _game;
    private string[] _roomLayout;
    public string[] RoomLayout {
        get { return _roomLayout; }
    }
    public char[,] _roomArray = new char[10,10];
    // Generate room
    public Room(Game game, int minW, int maxW, int minH, int maxH){
        _game = game;
        // Generate width and height randomly, within bounds
        // Max + 1 for consistency
        _width = rand.Next(minW, maxW + 1);
        _height = rand.Next(minH, maxH + 1);
        // Pawns list
        _pawns = new List<Pawn>();
        // Make empty room
        _roomArray = new char[_width, _height];
        for (int x = 0; x < _width; x++){
            for (int y = 0; y < _height; y++){
                _roomArray[x, y] = '.';
            }
        }
    }
    public void MakeRoom(){
        _roomLayout = new string[_height];
        // Fill edges with wall (#) and floors (.)
        for (int y = 0; y < _height; y++) {
            string row = "";
            for (int x = 0; x < _width; x++){
                if (x == 0 || x == _width - 1 || y == 0 || y == _height - 1){
                    row += "#";
                } else {
                    row += ".";
                }
            }
            _roomLayout[y] = row;
        }
        Player p1 = DrawPlayer(_roomLayout);
        DrawEnemy(_roomLayout);
        DrawKey(_roomLayout,p1);
        DrawRoom(_roomLayout);
        StartRoom(p1);
    }
    public void StartRoom(Player p1){
        while (true){
            // Move enemies
            foreach (Pawn enemy in _pawns){
                enemy.Movement();
            }
            // Check for player input
            p1.Play();
            // Did you die?
            if (p1._isAlive == false){
                _game.GameOver();
            }
        }
        }
    public Player DrawPlayer(string[] _roomLayout){
        Player p1 = new Player(this, "Player", 10, 10, 2, 1, false, rand.Next(1,4), rand.Next(1,3));
        _roomLayout[p1._y] = _roomLayout[p1._y].Substring(0, p1._x) + p1._symbol + _roomLayout[p1._y].Substring(p1._x + 1);
        _playX = p1._x;
        _playY = p1._y;
        _pawns.Add(p1);
        return p1;
    }
    public List<Pawn> DrawEnemy(string[] _roomLayout){
        int _enemiesPlaced = 0;
        while (_enemiesPlaced < rand.Next(1,4)){
            int enemyX = rand.Next(1, _width - 1);
            int enemyY = rand.Next(1, _height - 1);
            if (_roomLayout[enemyY][enemyX] == '.'){
                // Put enemy here
                int enemyHP = rand.Next(1,5);
                char enemyType = rand.NextDouble() < 0.333 ? '&' : rand.NextDouble() < 0.5 ? '%' : 'B';
                _roomLayout[enemyY] = _roomLayout[enemyY].Substring(0, enemyX) + enemyType + _roomLayout[enemyY].Substring(enemyX + 1);
                Enemy e1 = new Enemy(this, enemyType, "Enemy", 5, 5, rand.Next(1,4), rand.Next(0,1), false, enemyX, enemyY);
                _pawns.Add(e1);
                _enemiesPlaced++;
            }
        }
        return _pawns;
    }
    public void DrawKey(string[] _roomLayout, Player player){
        // Key is somewhere
        // Make sure there's only one
        bool _keyPlaced = false;
        while (!_keyPlaced){
            int _kX = rand.Next(1, _width - 1);
            int _kY = rand.Next(1, _height - 1);
            if (_roomLayout[_kY][_kX] == '.'){
                // Don't overlap player or enemy
                if (_kX == _playX && _kY == _playY){
                    continue;
                }if (GetPawnAt(_kX, _kY) != null){
                    continue;
                }
                // Put key here, is ?
                _roomLayout[_kY] = _roomLayout[_kY].Substring(0, _kX) + "?" + _roomLayout[_kY].Substring(_kX + 1);
                _keyX = _kX;
                _keyY = _kY;
                // Tells computer: key present
                _keyPlaced = true;
            }
        }
    }
    public void DrawRoom(string[] _roomLayout) {
        Console.Clear();
        for (int y = 0; y < _roomLayout.Length; y++) {
            Console.WriteLine(_roomLayout[y]);
        }
    }
    public void UpdateLayout(string[] _roomLayout, int x, int y){
        foreach (var pawn in _pawns) {
            // Each Enemy must move
            if (pawn is Enemy enemy) {
                enemy.Movement();
            }
        }
        foreach (Pawn pawn in _pawns) {
            if (pawn is Enemy enemy) {
                if (enemy._isAlive == true){
                _roomLayout[enemy._y] = _roomLayout[enemy._y].Substring(0, enemy._x) + enemy._symbol + _roomLayout[enemy._y].Substring(enemy._x + 1);
            }
            if (_keyX != -1 && _keyY != -1) {
                _roomLayout[_keyY] = _roomLayout[_keyY].Substring(0, _keyX) + '?' + _roomLayout[_keyY].Substring(_keyX + 1);
            }
            }
            
        }
        _roomLayout[_playY] = _roomLayout[_playY].Remove(_playX, 1).Insert(_playX, ".");
        _playX = x;
        _playY = y;
        _roomLayout[_playY] = _roomLayout[_playY].Remove(_playX, 1).Insert(_playX, "@");
    }
    public void RemoveTarget(int x, int y){
        _roomArray[x, y] = '.';
    }
    public Pawn GetPawnAt(int x, int y){
        foreach (Pawn pawn in _pawns){
            if (pawn._x == x && pawn._y == y){
                return pawn;
            }
        }
        return null;
    }
    public bool IsInBounds(int x, int y){
        return x >= 0 && x < _width && y >= 0 && y < _height;
    }
    public Player FindPlayer(int x, int y){
        Player closestPlayer = null;
        int minDist = int.MaxValue;
        for (int i = 0; i < _roomArray.GetLength(0); i++){
            for (int j = 0; j < _roomArray.GetLength(1); j++){
                Pawn pawn = GetPawnAt(i,j);
                if (pawn != null && pawn is Player && pawn._isAlive){
                    int dist = Math.Abs(x - i) + Math.Abs(y - j);
                    if (dist < minDist){
                        minDist = dist;
                        closestPlayer = (Player)pawn;
                    }
                }
            }
        }
        return closestPlayer;
    }
}