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
    // Key position, who is guarding it?
    public int _keyX { get; private set; }
    public int _keyY { get; private set; }
    public int _enemyX { get; private set; }
    public int _enemyY { get; private set; }
    private List<Pawn> _pawns;
    
    public char[,] _roomArray = new char[10,10];
    // Generate room
    public Room(int minW, int maxW, int minH, int maxH){
        Random rand = new Random();
        // Generate width and height randomly, within bounds
        // Max + 1 for consistency
        _width = rand.Next(minW, maxW + 1);
        _height = rand.Next(minH, maxH + 1);
        // Make empty room
        _roomArray = new char[_width, _height];
        for (int x = 0; x < _width; x++){
            for (int y = 0; y < _height; y++){
                _roomArray[x, y] = '.';
            }
        }
        // Fill edges with wall (#)
        for (int x = 0; x < _width; x++){
            // North, south
            _roomArray[x, 0] = '#';
            _roomArray[x, _height - 1] = '#';
        }for (int y = 0; y < _height; y++) {
            // West, east
            _roomArray[0, y] = '#';
            _roomArray[_width - 1, y] = '#';
        }
        // Make 2 doors, 1 away from other door
        int _doorX1 = rand.Next(1, _width - 1);
        int _doorY1 = 0;
        int _doorX2 = rand.Next(1, _width - 1);
        int _doorY2 = _height - 1;
        _roomArray[_doorX1, _doorY1] = '+';
        _roomArray[_doorX2, _doorY2] = '+';
        // Player is somewhere. Does it make sense to enter a door and be in the middle? No.
        // However, it's fun
        // Subtract 1 from w and h for consistency
        _playX = rand.Next(1, _width - 1);
        _playY = rand.Next(1, _height - 1);
        // Player is @
        _roomArray[_playX, _playY] = '@';
        // Enemies are somewhere
        int _enemiesPlaced = 0;
        while (_enemiesPlaced < 2){
            int _enemyX = rand.Next(1, _width - 1);
            int _enemyY = rand.Next(1, _height - 1);
            if (_roomArray[_enemyX, _enemyY] == '.'){
                // Put enemy here. Is $, %, or &
            _roomArray[_enemyX, _enemyY] = rand.NextDouble() < 0.333 ? '&' : rand.NextDouble() < 0.5 ? '%' : '$';
            _enemiesPlaced++;
            }
        }
         if (rand.NextDouble() < 0.3){
            _doorsLocked = true;
            // Key is somewhere
            // Make sure there's only one
            bool _keyPlaced = false;
            while (!_keyPlaced){
                int _kX = rand.Next(1, _width - 1);
                int _kY = rand.Next(1, _height - 1);
                if (_roomArray[_kX, _kY] == '.'){
                    // Don't overlap player. Enemy overlap is fine.
                    if (_roomArray[_kX, _kY] == '@'){
                        continue;
                    }
                    // Put key here, is !
                    _roomArray[_kX, _kY] = '!';
                    _keyX = _kX;
                    _keyY = _kY;
                    // Tells computer: key present
                    _keyPlaced = true;
                }
            }
        }
        _pawns = new List<Pawn>();
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
                if (_roomArray[i, j] == '@'){
                    int dist = Math.Abs(i - x) + Math.Abs(j - y);
                    if (dist < minDist){
                        closestPawn = GetPawnAt(i, j);
                        minDist = dist;
                    }
                }
            }
        }
        return closestPawn;
    }
    public void PlacePawns(List<Pawn> pawns){
    _pawns = pawns;
    _roomArray = new char[_width, _height];
    for (int i = 0; i < _width; i++){
        for (int j = 0; j < _height; j++){
            _roomArray[i, j] = '.';
        }
    }
    foreach (var pawn in _pawns){
        _roomArray[pawn._x, pawn._y] = pawn._symbol;
    }
}

}
