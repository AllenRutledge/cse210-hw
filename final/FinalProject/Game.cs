using System;

public class Game{
    private int playerX;
    private int playerY;
    private int roomWidth;
    private int roomHeight;
    private char[,] room;

    public Game(int width, int height){
        roomWidth = width;
        roomHeight = height;
        room = new char[roomWidth, roomHeight];
        playerX = roomWidth / 2;
        playerY = roomHeight / 2;
        InitializeRoom();
    }
    public void Run(){
        while (true){
            DrawRoom();
            ConsoleKeyInfo keyInfo = Console.ReadKey(true);
            if (keyInfo.Key == ConsoleKey.UpArrow && playerY > 0){
                MovePlayer(0, -1);
            }else if (keyInfo.Key == ConsoleKey.DownArrow && playerY < roomHeight - 1){
                MovePlayer(0, 1);
            }else if (keyInfo.Key == ConsoleKey.LeftArrow && playerX > 0){
                MovePlayer(-1, 0);
            }else if (keyInfo.Key == ConsoleKey.RightArrow && playerX < roomWidth - 1){
                MovePlayer(1, 0);
            }
            Console.Clear();
        }
    }
    private void InitializeRoom(){
        for (int y = 0; y < roomHeight; y++){
            for (int x = 0; x < roomWidth; x++){
                if (x == playerX && y == playerY){
                    room[x, y] = '@';
                }else{
                    room[x, y] = '.';
                }
            }
        }
    }
    private void DrawRoom(){
        for (int y = 0; y < roomHeight; y++){
            for (int x = 0; x < roomWidth; x++){
                Console.Write(room[x, y]);
            }
            Console.WriteLine();
        }
    }
    private void MovePlayer(int deltaX, int deltaY){
        room[playerX, playerY] = '.';
        playerX += deltaX;
        playerY += deltaY;
        room[playerX, playerY] = '@';
    }
}
