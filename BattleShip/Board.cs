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
        public List<Cell> Water = new List<Cell>();
        public List<Cell> BlockedCells = new List<Cell>();

        public int X;
        public int Y;

        public string Injured = "Injured";
        public string Sanked = "Sanked";
        public string Missed = "Missed";
        public string Waves = "~";

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
                if(i == 0)
                {
                    Console.Write("" + "\t");
                }
                else
                {
                    Console.Write(i + "\t");
                }

                for (int j = 1; j <= Y; j++)
                {
                    if (i > 0)
                    {
                        bool found = false;

                        Ship? ship = Ships.FirstOrDefault(ship => ship.Cells.FirstOrDefault(cell => cell.X == i && cell.Y == j) != null);
                        Cell? cell = ship?.Cells.FirstOrDefault(cell => (cell.X == i && cell.Y == j) == true);

                        if(ship != null)
                        {
                            if (cell != null)
                            {
                                int index = ship.Cells.IndexOf(cell);

                                if (index >= 0)
                                {
                                    if (cell.Status == CellStatus.ShipHit || cell.Status == CellStatus.ShipKilled)
                                    {
                                        if (ship.Alive == false)
                                        {
                                            Console.Write("{0} {1}", Sanked, '\t');
                                        }
                                        else
                                        {
                                            Console.Write("{0} {1}", Injured, '\t');
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
                            }
                        }
                       
                        if(found == false)
                        {
                            Cell? waterCell = Water.FirstOrDefault(obj => obj.X == i && obj.Y == j);

                            if(waterCell == null)
                            {
                                waterCell = new Cell(i,j);
                                Water.Add(waterCell);
                            }

                            if(waterCell.Status == CellStatus.WaterHit)
                            {
                                Console.Write("{0} {1}", Missed, '\t');
                            }

                            else if (waterCell.Status == CellStatus.ShipHit)
                            {
                                Console.Write("{0} {1}", Injured, '\t');
                            }
                            else if (waterCell.Status == CellStatus.ShipKilled)
                            {
                                Console.Write("{0} {1}", Sanked, '\t');
                            }
                            else
                            {
                                Console.Write("{0} {1}", Waves, '\t');
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

        public bool CreateShip(string? name, bool isVertical, int x, int y, int cells)
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
                Cell? forbdCell = BlockedCells.FirstOrDefault(obj => obj.X == cell.X && obj.Y == cell.Y);
                if (forbdCell != null)
                {
                    //we can't put our cell ship in that coordinate due  to another existing cell in BlockedCells
                    Console.WriteLine("We can't put {0}'s cell {1},{2}  due  to another ship existing there", name, cell.X, cell.Y);
                    //return false;
                }
                Cell centralCell = new Cell();
                centralCell.X = cell.X;
                centralCell.Y = cell.Y;
                BlockedCells.Add(centralCell);

                if (isVertical == true)
                {

                    Cell surroundBottomLeftCell = new Cell();
                    surroundBottomLeftCell.X = cell.X-1;
                    surroundBottomLeftCell.Y = cell.Y+1;
                    BlockedCells.Add(surroundBottomLeftCell);
                    Console.WriteLine("Added surround Bottom Left Cell {0},{1} to Blocked Cells", cell.X-1, cell.Y+1);

                    Cell surroundLeftCell = new Cell();
                    surroundLeftCell.X = cell.X - 1;
                    surroundLeftCell.Y = cell.Y;
                    BlockedCells.Add(surroundLeftCell);
                    Console.WriteLine("Added surround Left Cell {0},{1} to Blocked Cells", cell.X-1, cell.Y);

                    Cell surroundUpperLeftCell = new Cell();
                    surroundUpperLeftCell.X = cell.X - 1;
                    surroundUpperLeftCell.Y = cell.Y-1;
                    BlockedCells.Add(surroundUpperLeftCell);
                    Console.WriteLine("Added surround Upper Left Cell {0},{1} to Blocked Cells", cell.X-1, cell.Y-1);

                    Cell surroundUpperCell = new Cell();
                    surroundUpperCell.X = cell.X;
                    surroundUpperCell.Y = cell.Y - 1;
                    BlockedCells.Add(surroundUpperCell);
                    Console.WriteLine("Added surround Upper Cell {0},{1} to Blocked Cells", cell.X, cell.Y-1);

                    Cell surroundUpperRightCell = new Cell();
                    surroundUpperRightCell.X = cell.X + 1;
                    surroundUpperRightCell.Y = cell.Y - 1;
                    BlockedCells.Add(surroundUpperRightCell);
                    Console.WriteLine("Added surround Upper Right Cell {0},{1} to Blocked Cells", cell.X+1, cell.Y-1);

                    Cell surroundRightCell = new Cell();
                    surroundRightCell.X = cell.X + 1;
                    surroundRightCell.Y = cell.Y;
                    BlockedCells.Add(surroundRightCell);
                    Console.WriteLine("Added surround Right Cell {0},{1} to Blocked Cells", cell.X+1, cell.Y);

                    Cell surroundBottomRightCell = new Cell();
                    surroundBottomRightCell.X = cell.X + 1;
                    surroundBottomRightCell.Y = cell.Y + 1;
                    BlockedCells.Add(surroundBottomRightCell);
                    Console.WriteLine("Added surround Bottom Right Cell {0},{1} to Blocked Cells", cell.X+1, cell.Y+1);

                }
                else
                {
                    Cell surroundBottomLeftCell = new Cell();
                    surroundBottomLeftCell.X = cell.X - 1;
                    surroundBottomLeftCell.Y = cell.Y + 1;
                    BlockedCells.Add(surroundBottomLeftCell);
                    Console.WriteLine("Added surround Bottom Left Cell {0},{1} to Blocked Cells", cell.X-1, cell.Y+1);

                    Cell surroundLeftCell = new Cell();
                    surroundLeftCell.X = cell.X - 1;
                    surroundLeftCell.Y = cell.Y;
                    BlockedCells.Add(surroundLeftCell);
                    Console.WriteLine("Added surround Left Cell {0},{1} to Blocked Cells", cell.X-1, cell.Y);

                    Cell surroundUpperLeftCell = new Cell();
                    surroundUpperLeftCell.X = cell.X - 1;
                    surroundUpperLeftCell.Y = cell.Y - 1;
                    BlockedCells.Add(surroundUpperLeftCell);
                    Console.WriteLine("Added surround Upper Left Cell {0},{1} to Blocked Cells", cell.X-1, cell.Y-1);

                    Cell surroundUpperCell = new Cell();
                    surroundUpperCell.X = cell.X;
                    surroundUpperCell.Y = cell.Y - 1;
                    BlockedCells.Add(surroundUpperCell);
                    Console.WriteLine("Added surround Upper Cell {0},{1} to Blocked Cells", cell.X, cell.Y-1);

                    Cell surroundUpperRightCell = new Cell();
                    surroundUpperRightCell.X = cell.X + 1;
                    surroundUpperRightCell.Y = cell.Y - 1;
                    BlockedCells.Add(surroundUpperRightCell);
                    Console.WriteLine("Added surround Upper Right Cell {0},{1} to Blocked Cells", cell.X+1, cell.Y-1);

                    Cell surroundBottomRightCell = new Cell();
                    surroundBottomRightCell.X = cell.X + 1;
                    surroundBottomRightCell.Y = cell.Y + 1;
                    BlockedCells.Add(surroundBottomRightCell);
                    Console.WriteLine("Added surround Upper Right Cell {0},{1} to Blocked Cells", cell.X+1, cell.Y+1);

                    Cell surroundBottomCell = new Cell();
                    surroundBottomCell.X = cell.X;
                    surroundBottomCell.Y = cell.Y + 1;
                    BlockedCells.Add(surroundBottomCell);
                    Console.WriteLine("Added surround Bottom Cell {0},{1} to Blocked Cells", cell.X, cell.Y+1);
                }
                // check if cell is presenting in forbiden cells
                // if not
                // add cell and add to forbiden cells new cells based on vertical or horizontal aligment
                if(i == cells-1)
                {
                    if(isVertical == true)
                    {
                        Cell surroundBottomRightCell = new Cell();
                        surroundBottomRightCell.X = cell.X + 1;
                        surroundBottomRightCell.Y = cell.Y + 1;
                        BlockedCells.Add(surroundBottomRightCell);
                        Console.WriteLine("Added surround Bottom Right Cell {0},{1} to Blocked Cells", cell.X+1, cell.Y+1);

                        Cell surroundBottomCell = new Cell();
                        surroundBottomCell.X = cell.X;
                        surroundBottomCell.Y = cell.Y + 1;
                        BlockedCells.Add(surroundBottomCell);
                        Console.WriteLine("Added surround Bottom Cell {0},{1} to Blocked Cells", cell.X, cell.Y+1);

                        Cell surroundBottomLeftCell = new Cell();
                        surroundBottomLeftCell.X = cell.X - 1;
                        surroundBottomLeftCell.Y = cell.Y + 1;
                        BlockedCells.Add(surroundBottomLeftCell);
                        Console.WriteLine("Added surround Bottom Left Cell {0},{1} to Blocked Cells", cell.X-1, cell.Y+1);
                    }
                    else
                    {
                        Cell surroundUpperRightCell = new Cell();
                        surroundUpperRightCell.X = cell.X + 1;
                        surroundUpperRightCell.Y = cell.Y - 1;
                        BlockedCells.Add(surroundUpperRightCell);
                        Console.WriteLine("Added surround Bottom Left Cell {0},{1} to Blocked Cells", cell.X+1, cell.Y-1);

                        Cell surroundRightCell = new Cell();
                        surroundRightCell.X = cell.X + 1;
                        surroundRightCell.Y = cell.Y;
                        BlockedCells.Add(surroundRightCell);
                        Console.WriteLine("Added surround Right {0},{1} to Blocked Cells", cell.X+1, cell.Y);

                        Cell surroundBottomRightCell = new Cell();
                        surroundBottomRightCell.X = cell.X + 1;
                        surroundBottomRightCell.Y = cell.Y + 1;
                        BlockedCells.Add(surroundBottomRightCell);
                        Console.WriteLine("Added surround Bottom Right Cell {0},{1} to Blocked Cells", cell.X+1, cell.Y+1);
                    }
                }

                ship.Cells.Add(cell);
            }

            Ships.Add(ship);
            return true;
        }
    }
}
