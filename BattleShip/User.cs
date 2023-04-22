using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleShip
{
    public class User
    {
        // data memberes

        public string Name { get; set; }

        public Board ActiveBoard = new Board();
        public Board EnemyBoard = new Board();

        public Statistics Statistics = new Statistics();

        public User(string name)
        {
            Name = name;
        }

        public void InitBoards(int axisX, int axisY)
        {
            ActiveBoard.InitBoard(axisX, axisY);
            EnemyBoard.InitBoard(axisX, axisY);
        }

        public void CreateShips(int totalShips, bool debugMode)
        {
            if(debugMode == false)
            {
                for (int i = 0; i < totalShips; i++)
                {
                    string? name;
                    bool isVertical = false;
                    int x;
                    int y;
                    Console.WriteLine("{0} Please provide the Ship name:", Name);
                    name = Console.ReadLine();

                    Console.WriteLine("{0} Please select the ship orientation, for horizontal press '1', for vertical press '2':", Name);
                    string? pos = Console.ReadLine();

                    if (pos == "2")
                    {
                        isVertical = true;
                    }

                    Console.WriteLine("{0} Please provide start coordination X:", Name);
                    bool parsedX = int.TryParse(Console.ReadLine(), out x);
                    Console.WriteLine("{0} Please provide start coordination Y:", Name);
                    bool parsedY = int.TryParse(Console.ReadLine(), out y);
                    Console.WriteLine("{0} Please provide ships length:", Name);

                    bool parsedCells = int.TryParse(Console.ReadLine(), out int cells);

                    if (parsedX == false || parsedY == false || parsedCells == false)
                    {
                        Console.WriteLine("Wrong X/Y/Cells parameters!");
                        continue;
                    }
                    if (cells > 4)
                    {
                        Console.WriteLine("The ship is too long!");
                        continue;
                    }

                    ActiveBoard.CreateShip(name, isVertical, x, y, cells);
                }
            }
            else
            {
                ActiveBoard.CreateShip("Avrora", false, 2, 3, 3);
                ActiveBoard.CreateShip("Varyag", true, 1, 1, 2);
                ActiveBoard.CreateShip("Missouri", true, 5, 5, 4);
                ActiveBoard.CreateShip("Argo", true, 7, 7, 2);
                ActiveBoard.CreateShip("Bismarck", true, 7, 1, 4);
                ActiveBoard.CreateShip("Lenin", false, 5, 6, 4);
                ActiveBoard.CreateShip("Nin", true, 5, 10, 4);
            }
        }

        // methods
        public Ship? Shoot(int x, int y, User shootTarget, User shootInitiator)
        {
            shootInitiator.Statistics.TotalShots++;

            Ship? enemyShip = shootTarget.ActiveBoard.Ships.FirstOrDefault(ship => ship.Cells.FirstOrDefault(cell => cell.X == x && cell.Y == y) != null);

            if (enemyShip != null) // The ship was injured or killed
            {
                Cell? enemyCell = enemyShip?.Cells.FirstOrDefault(cell => cell.X == x && cell.Y == y);

                if (enemyCell != null)
                {
                    enemyCell.Status = CellStatus.ShipHit;
                }

                bool isShipKilled = enemyShip.IsKilled();

                if(isShipKilled == false)
                {
                    shootInitiator.Statistics.InjuredEnemyDecs++;
                    shootTarget.Statistics.InjuredMyDecs++;

                    Cell? initiatorWaterCell = shootInitiator.EnemyBoard.Water.FirstOrDefault(waterCell => waterCell.X == x && waterCell.Y == y);

                    if (initiatorWaterCell != null)
                    {
                        initiatorWaterCell.Status = CellStatus.ShipHit;
                    }
                }
                else // if ship was killed set all water cells as killed in the Shooter's Enemy board
                {
                    shootInitiator.Statistics.InjuredEnemyDecs++;
                    shootInitiator.Statistics.KilledEnemyShips++;

                    shootTarget.Statistics.InjuredMyDecs++;
                    shootTarget.Statistics.KilledMyShips++;

                    foreach (Cell cell in enemyShip.Cells)
                    {
                        Cell? initiatorWaterCell = shootInitiator.EnemyBoard.Water.FirstOrDefault(waterCell => waterCell?.X == cell.X && waterCell?.Y == cell.Y);

                        if (initiatorWaterCell != null)
                        {
                            initiatorWaterCell.Status = CellStatus.ShipKilled;
                        }
                    }
                }
            }
            else // The shot did not hit the ship
            {
                shootInitiator.Statistics.MissedShots++;

                Cell? targerWaterCell = shootTarget.ActiveBoard.Water.FirstOrDefault(waterCell => waterCell.X == x && waterCell.Y == y);

                if (targerWaterCell != null)
                {
                    targerWaterCell.Status = CellStatus.WaterHit;
                }

                Cell? initiatorWaterCell = shootInitiator.EnemyBoard.Water.FirstOrDefault(waterCell => waterCell.X == x && waterCell.Y == y);

                if (initiatorWaterCell != null)
                {
                    initiatorWaterCell.Status = CellStatus.WaterHit;
                }
            }

            return enemyShip;
        }
    }
}
