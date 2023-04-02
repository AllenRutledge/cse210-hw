public class Enemy : Pawn {
    
    public Enemy(Game game, Room room, char symbol, string name, int maxhp, int hp, int atk, int def, bool isRanged, int x, int y) : base(game, room, name, maxhp, hp, atk, def, isRanged, x, y) {
        _symbol = symbol;
        _room = room;
        }
    public override void TakeDamage(int damage){
        _hp -= damage;
        if (_hp <= 0){
            Console.WriteLine($"{_name} defeated!");
            _room._pawns.Remove(this);
            Thread.Sleep(1000);
            _isAlive = false;
            _room.RemoveTarget(_x, _y);
        } else {
            _isAlive = true;
            Player player = _room.FindPlayer();
            Attack(player);
        }
    }
}
