using BattleShip;
using System;
public class Program
{
    public static void Main()
    {
        Console.WriteLine("Starting the game...");
        int maxX = 10;
        int maxY = 10;
        Game game = new Game();
        game.StartGame(maxX, maxY, game.board1);
        game.StartGame(maxX, maxY, game.board2);
        game.ExecuteGame();
    }
}