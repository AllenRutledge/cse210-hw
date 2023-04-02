public class Portal: Enemy{
    public Portal(Game game, Room room, char symbol, string name, int maxhp, int hp, int atk, int def, bool isRanged, int x, int y) : base(game, room, symbol, name, maxhp, hp, atk, def, isRanged, x, y){
        _room = room;
        }
    public override void TakeDamage(int damage){
        _hp -= damage;
        if (_hp <= 0){
            Console.WriteLine($"A bright blue light fills the room...");
            _room._pawns.Remove(this);
            _isAlive = false;
            _room.RemoveTarget(_x, _y);
            Thread.Sleep(1000);
            _game.Run();
        } else {
            Console.WriteLine($"It's cracking, keep attacking...");
            _isAlive = true;
        }
    }
    public void TeleportPlayer(){
        
    }
}