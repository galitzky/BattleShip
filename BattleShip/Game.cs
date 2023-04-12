using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleShip
{
    public class Game
    {
        public Board? Board = null;

        public void StartGame(int x, int y)
        {
            Board board = new Board();
            board.InitBoard(x, y);

            board.CreateShip("Avrora", false, 2, 3, 3);
            board.CreateShip("Varyag", true, 1, 1, 2);
            board.CreateShip("Missouri", true, 5, 5, 4);
            board.CreateShip("Argo", true, 7, 7, 2);
            board.CreateShip("Bismarck", true, 7, 1, 4);
            board.CreateShip("Lenin", false, 5, 6, 4);
            board.CreateShip("Nin", true, 5, 10, 4);

            board.DrawBoardWithShips();

            User user = new User();
            int shootX = 2;
            int shootY = 3;

            Ship ship = user.Shoot(shootX, shootY, board);

            if(ship == null)
            {
                Console.WriteLine("You missed. {0}, {1}", shootX, shootY);
            }
            else
            {
                if(ship.IsWounded(shootX, shootY) == true)
                {
                    Console.WriteLine("Ship '{0}' was wounded", ship.Name);
                }
                if (ship.IsKilled(shootX, shootY) == true)
                {
                    Console.WriteLine("Ship '{0}' was killed", ship.Name);
                }
            }
        }
    }
}
