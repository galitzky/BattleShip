using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleShip
{
    public class Game
    {
        // data memberes
        Board board = new Board();

        // methods
        public void StartGame(int axisX, int axisY)
        {
            
            board.InitBoard(axisX, axisY);

            board.CreateShip("Avrora", false, 2, 3, 3);
            board.CreateShip("Varyag", true, 1, 1, 2);
            board.CreateShip("Missouri", true, 5, 5, 4);
            board.CreateShip("Argo", true, 7, 7, 2);
            board.CreateShip("Bismarck", true, 7, 1, 4);
            board.CreateShip("Lenin", false, 5, 6, 4);
            board.CreateShip("Nin", true, 5, 10, 4);

            board.DrawBoardWithShips();
        }
        public void ExecuteGame()
        {

            User user = new User();

            while (true) 
            {
                Console.WriteLine("Enter X and Y parameters: ");

                bool isShootX = int.TryParse(Console.ReadLine(), out int shootX);
                bool isShootY = int.TryParse(Console.ReadLine(), out int shootY);

                if (!isShootX || !isShootY)
                {
                    Console.WriteLine("Please enter  valid X and Y parameters");
                    continue;
                }

                Ship ship = user.Shoot(shootX, shootY, board);

                if (ship == null)
                {
                    Console.WriteLine("You missed. Coordinates: {0}, {1}", shootX, shootY);
                }
                else
                {
                    if (ship.IsWounded(shootX, shootY) == true)
                    {
                        Console.WriteLine("Ship '{0}' was wounded", ship.Name);
                    }
                    if (ship.IsKilled() == true)
                    {
                        Console.WriteLine("Ship '{0}' was killed", ship.Name);
                    }

                    board.DrawBoardWithShips();
                }
            }

        }
    }

}
