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
        public Water water = new Water();
        public int X;
        public int Y;

        // methods
        public void InitBoard(int x, int y)
        {
            X = x;
            Y = y;
        }

        public void DrawBoardWithShips()
        {
            Console.Write("\n");
            Console.Write("Board with Ships");
            Console.Write("\n");

            for (int i = 0; i <= X; i++)
            {
                Console.Write(i + "\t");

                for (int j = 1; j <= Y; j++)
                {
                    if (i > 0)
                    {
                        bool found = false;

                        foreach (Ship ship in Ships)
                        {
                            foreach (Cell cell in ship.Cells)
                            {
                                if (cell.X == i && cell.Y == j)
                                {
                                    int index = ship.Cells.IndexOf(cell); 

                                    if(index >= 0)
                                    {
                                        if(cell.Alive == false)
                                        {
                                            Console.Write("{0} {1}", "@", '\t');
                                        }
                                        else
                                        {
                                            if (index >= ship.Name.Length)
                                            {
                                                Console.Write("{0} {1}", "*", '\t');
                                            }
                                            else
                                            {
                                                Console.Write("{0} {1}", ship.Name[index], '\t');
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
                            bool cellInWaterFound = false;

                            foreach (Cell cellInWater in water.Cells)
                            {
                                if(cellInWater.X == i && cellInWater.Y == j)
                                {
                                    cellInWaterFound = true;

                                    if (cellInWater.Alive == false)
                                    {
                                        Console.Write("~{0}", '\t');
                                    }
                                    else
                                    {
                                        Console.Write(".{0}", '\t');
                                    }
                                }
                            }
                            if(cellInWaterFound == false)
                            {
                                Cell cell = new Cell();
                                cell.X = i;
                                cell.Y = j;
                                water.Cells.Add(cell);
                                Console.Write(".{0}", '\t');
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

        public void CreateShip(string name, bool isVertical, int x, int y, int cells)
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
