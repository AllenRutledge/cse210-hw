using System;
using System.Collections.Generic;
public class Room{
    // Size
    public int _width { get; private set; }
    public int _height { get; private set; }
    public int _playX;
    public int _playY;
    // Portal position
    public int _portalX { get; private set; }
    public int _portalY { get; private set; }
    public List<Pawn> _pawns;
    Random rand = new Random();
    public Game _game;
    public string[] _roomLayout;
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
        DrawPortal(_roomLayout,p1);
        DrawRoom(_roomLayout);
        StartRoom();
    }
    public void StartRoom(){
        Player player = FindPlayer();
        if (player == null){
            throw new Exception("Player not found!");
        }
        while (true){
            // Check for player input
            player.Play();
        }
    }
    public Player DrawPlayer(string[] _roomLayout){
        Player p1 = new Player(_game, this, "Player", 10, 10, 2, 1, false, rand.Next(1,4), rand.Next(1,3));
        _roomLayout[p1._y] = _roomLayout[p1._y].Substring(0, p1._x) + p1._symbol + _roomLayout[p1._y].Substring(p1._x + 1);
        _playX = p1._x;
        _playY = p1._y;
        _pawns.Add(p1);
        return p1;
    }
    public List<Pawn> DrawEnemy(string[] _roomLayout){
        int _enemiesPlaced = 0;
        while (_enemiesPlaced < rand.Next(5,15)){
            int enemyX = rand.Next(1, _width - 1);
            int enemyY = rand.Next(1, _height - 1);
            if (_roomLayout[enemyY][enemyX] == '.'){
                // Put enemy here
                int enemyHP = rand.Next(1,5);
                char enemyType = rand.NextDouble() < 0.333 ? '&' : rand.NextDouble() < 0.5 ? '%' : 'B';
                _roomLayout[enemyY] = _roomLayout[enemyY].Substring(0, enemyX) + enemyType + _roomLayout[enemyY].Substring(enemyX + 1);
                Enemy e1 = new Enemy(_game, this, enemyType, "Enemy", 5, 5, rand.Next(1,4), rand.Next(0,1), false, enemyX, enemyY);
                _pawns.Add(e1);
                _enemiesPlaced++;
            }
        }
        return _pawns;
    }
    public void DrawPortal(string[] _roomLayout, Player player){
        // Portal is somewhere
        // Make sure there's only one
        // Spawns in the corner for some reason
        bool _portalPlaced = false;
        while (!_portalPlaced){
            int _pX = rand.Next(1, _width - 1);
            int _pY = rand.Next(1, _height - 1);
            if (_roomLayout[_pY][_pX] == '.'){
                // Put portal here, is ?
                Portal p1 = new Portal(_game, this, '?', "Portal", 4, 4, 0, 0, false, _pX, _pY);
                _pawns.Add(p1);
                // Tells computer: portal present
                _portalPlaced = true;
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
        foreach (Pawn pawn in _pawns) {
            if (pawn is Enemy enemy) {
                if (enemy._isAlive == true){
                    _roomLayout[enemy._y] = _roomLayout[enemy._y].Substring(0, enemy._x) + enemy._symbol + _roomLayout[enemy._y].Substring(enemy._x + 1);
                }else{
                    RemoveTarget(enemy._x, enemy._y);
                }
                if (_portalX != -1 && _portalY != -1) {
                    _roomLayout[_portalY] = _roomLayout[_portalY].Substring(0, _portalX) + '?' + _roomLayout[_portalY].Substring(_portalX + 1);
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
    public Player FindPlayer(){
        foreach (Pawn pawn in _pawns){
            if (pawn is Player){
                return (Player)pawn;
            }
        }
        return null;
    }
}