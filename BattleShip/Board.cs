using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleShip
{
    public class Board
    {
        // data members
        public List<Ship> Ships = new List<Ship>();
        public List<Water> Water = new List<Water>();

        public int X;
        public int Y;

        // methods
        public void InitBoard(int x, int y)
        {
            X = x;
            Y = y;
        }

        public void DrawBoardWithShips(string title)
        {
            Console.Write("\n");
            Console.WriteLine(title);
            
            for (int i = 0; i <= X; i++)
            {
                Console.Write(i + "\t");

                for (int j = 1; j <= Y; j++)
                {
                    if (i > 0)
                    {
                        bool found = false;

                        //Ship? ship1 = Ships.FirstOrDefault(ship => ship.Cells.FirstOrDefault(cell => cell.X == i && cell.Y == j) != null);
                        //Cell? cell1 = ship1?.Cells.FirstOrDefault(cell => (cell.X == i && cell.Y == j) == true);

                        foreach (Ship ship in Ships)
                        {
                            foreach (Cell cell in ship.Cells)
                            {
                                if (cell.X == i && cell.Y == j)
                                {
                                    int index = ship.Cells.IndexOf(cell); 

                                    if(index >= 0)
                                    {
                                        if(cell.Status == CellStatus.ShipHit)
                                        {
                                            if(ship.Alive == false)
                                            {
                                                Console.Write("{0} {1}", "^", '\t');
                                            }
                                            else
                                            {
                                                Console.Write("{0} {1}", "@", '\t');
                                            }
                                        }
                                        else
                                        {
                                            if (index >= ship.Name?.Length)
                                            {
                                                Console.Write("{0} {1}", "*", '\t');
                                            }
                                            else
                                            {
                                                Console.Write("{0} {1}", ship.Name?[index], '\t');
                                            }
                                        }
                                    }

                                    found = true;
                                    break;
                                }
                            }
                        }

                        if(found == false)
                        {
                            Water? waterCell = Water.FirstOrDefault(obj => obj.Cell?.X == i && obj.Cell?.Y == j);

                            if(waterCell == null)
                            {
                                waterCell = new Water(i, j);
                                Water.Add(waterCell);
                            }

                            if(waterCell.Cell?.Status == CellStatus.WaterHit)
                            {
                                Console.Write("{0} {1}", "~", '\t');
                            }

                            else if (waterCell.Cell?.Status == CellStatus.ShipHit)
                            {
                                Console.Write("{0} {1}", "!", '\t');
                            }
                            else if (waterCell.Cell?.Status == CellStatus.ShipKilled)
                            {
                                Console.Write("{0} {1}", "--", '\t');
                            }
                            else
                            {
                                Console.Write("{0} {1}", ".", '\t');
                            }
                        }
                    }
                    else
                    {
                        Console.Write("{0} {1}", j, '\t');
                    }
                }
                Console.Write("\n");
            }
         }

        public void CreateShip(string? name, bool isVertical, int x, int y, int cells)
        {
            Ship ship = new Ship();
            ship.Name = name;
            for (int i = 0; i < cells; i++)
            {
                Cell cell = new Cell();
                if (i == 0)
                {
                    cell.X = x;
                    cell.Y = y;
                }
                else
                {
                    if (isVertical == true)
                    {
                        cell.X = x + i;
                        cell.Y = y;
                    }
                    else
                    {
                        cell.X = x;
                        cell.Y = y + i;
                    }
                }
                
                ship.Cells.Add(cell);
            }

            Ships.Add(ship);
        }
    }
}
