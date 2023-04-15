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
        public Board board1 = new();
        public Board board2 = new();

        // methods
        public void StartGame(int axisX, int axisY, Board board)
        {
            board.InitBoard(axisX, axisY);
            
            for (int i = 0; i < 2; i++)
            {
                string? name = "";
                bool isVertical = false;
                int x = 0;
                int y = 0;
                int cells = 0;

                Console.WriteLine("Please provide Ship name:");
                name = Console.ReadLine();

                Console.WriteLine("Please select the ship orientation, for horizontal press '1', for vertical press '2':");
                string? pos = Console.ReadLine();

                if(pos == "1")
                {
                    isVertical = true;
                }
                Console.WriteLine("Please provide start coordination X:");
                bool parsedX = int.TryParse(Console.ReadLine(), out x);
                Console.WriteLine("Please provide start coordination Y:");
                bool parsedY = int.TryParse(Console.ReadLine(), out y);
                Console.WriteLine("Please provide ships length:");
                bool parsedCells = int.TryParse(Console.ReadLine(), out cells);
                if(parsedX == false || parsedY == false || parsedCells == false)
                {
                    Console.WriteLine("Wrong X/Y/Cells parameters!");
                    continue;
                }
                if (cells > 4)
                {
                    Console.WriteLine("The ship is too long!");
                    continue;
                }
                board.CreateShip(name, isVertical, x, y, cells);
            }
            //board.CreateShip("Avrora", false, 2, 3, 3);
            //board.CreateShip("Varyag", true, 1, 1, 2);
            //board.CreateShip("Missouri", true, 5, 5, 4);
            //board.CreateShip("Argo", true, 7, 7, 2);
            //board.CreateShip("Bismarck", true, 7, 1, 4);
            //board.CreateShip("Lenin", false, 5, 6, 4);
            //board.CreateShip("Nin", true, 5, 10, 4);

            board.DrawBoardWithShips();
        }
        public void ExecuteGame()
        {
            User user1 = new User();
            User user2 = new User();

            bool isUser1Active = true;

            User? activeUser = null;

            while (true) 
            {
                Console.WriteLine("Enter coordinate X: ");

                bool isShootX = int.TryParse(Console.ReadLine(), out int shootX);

                Console.WriteLine("Enter coordinate Y: ");
                bool isShootY = int.TryParse(Console.ReadLine(), out int shootY);

                if (!isShootX || !isShootY)
                {
                    Console.WriteLine("Please enter  valid X and Y parameters");
                    continue;
                }

                if(isUser1Active == true)
                {
                    activeUser = user1;
                }
                else
                {
                    activeUser = user2;
                }

                Ship? ship = activeUser.Shoot(shootX, shootY, board1);

                if (isUser1Active == true)
                {
                    board1.Water.IsWaterWounded(shootX, shootY);
                }
                else
                {
                    board2.Water.IsWaterWounded(shootX, shootY);
                }

                if (ship == null)
                {
                    Console.WriteLine("You missed. Coordinates: {0}, {1}", shootX, shootY);
                    isUser1Active = !isUser1Active;
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
                }

                board1.DrawBoardWithShips();
                board2.DrawBoardWithShips();
            }
        }
    }

}
