using BattleShip;
using System;
public class Program
{
    public static void Main()
    {
        int maxX = 10;
        int maxY = 10;
        Game game = new Game();
        game.StartGame(maxX, maxY);
    }
}