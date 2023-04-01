using System;
public class Room{
    // Size
    public int _width { get; private set; }
    public int _height { get; private set; }
    // Player position
    public int _playX { get; private set; }
    public int _playY { get; private set; }
    // Has locked door?
    public bool _doorsLocked { get; private set; }
    // Key position
    public int _keyX { get; private set; }
    public int _keyY { get; private set; }
    // Enemy position
    public int _enemyX { get; private set; }
    public int _enemyY { get; private set; }
    private List<Pawn> _pawns;
    private Player _player;
    Random rand = new Random();
    private string[] _roomLayout;
    public string[] RoomLayout {
        get { return _roomLayout; }
    }
    public char[,] _roomArray = new char[10,10];
    // Generate room
    public Room(int minW, int maxW, int minH, int maxH){
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
        DrawEnemies(_roomLayout);
        DrawKey(_roomLayout);
        DrawRoom(_roomLayout);
        p1.Play();
    }
    public Player DrawPlayer(string[] _roomLayout){
        // Player
        Player p1 = new Player(this, "Player", 10, 10, 2, 1, false, rand.Next(1,9), rand.Next(1,4));
        if (_player != null){
            _roomLayout[p1._y] = _roomLayout[p1._y].Substring(0, p1._x) + p1._symbol + _roomLayout[p1._y].Substring(p1._x + 1);
        }
        // Player at (_player.X, _player.Y)
        _roomLayout[p1._y] = _roomLayout[p1._y].Substring(0, p1._x) + p1._symbol + _roomLayout[p1._y].Substring(p1._x + 1);
        _playX = p1._x;
        _playY = p1._y;
        return p1;
    }
    public void DrawEnemies(string[] _roomLayout){
        // Enemies are somewhere
        int _enemiesPlaced = 0;
        while (_enemiesPlaced < 2){
            int enemyX = rand.Next(1, _width - 1);
            int enemyY = rand.Next(1, _height - 1);
            if (_roomLayout[enemyY][enemyX] == '.'){
                // Put enemy here. Is $, %, or &
                char enemyType = rand.NextDouble() < 0.333 ? '&' : rand.NextDouble() < 0.5 ? '%' : '$';
                _roomLayout[enemyY] = _roomLayout[enemyY].Substring(0, enemyX) + enemyType + _roomLayout[enemyY].Substring(enemyX + 1);
                _pawns.Add(new Enemy(this, "Enemy", 5, 5, 2, 1, false, enemyX, enemyY));
                _enemiesPlaced++;
            }
        }
    }
    public void DrawKey(string[] _roomLayout){
        _doorsLocked = true;
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
                }
                    if (GetPawnAt(_kX, _kY) != null){
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
    public Pawn FindClosestPawn(int x, int y){
        Pawn closestPawn = null;
        int minDist = int.MaxValue;
        for (int i = 0; i < _roomArray.GetLength(0); i++){
            for (int j = 0; j < _roomArray.GetLength(1); j++){
                Pawn pawn = GetPawnAt(i,j);
                if (pawn != null && pawn._isAlive){
                    int dist = Math.Abs(x - i) + Math.Abs(y - j);
                    if (dist < minDist){
                        minDist = dist;
                        closestPawn = pawn;
                    }
                }
            }
        }
        return closestPawn;
    }
}