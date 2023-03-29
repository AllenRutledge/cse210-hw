public class Player:Pawn{
    public Player(Room room, string name, int maxhp, int hp, int atk, int def, bool isRanged, int x, int y) : base(room, name, maxhp, hp, atk, def, isRanged, x, y){
        _symbol = '@';
    }
    public void Play(){
        Movement();
    }
}