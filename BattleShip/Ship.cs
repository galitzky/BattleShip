using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleShip
{
    public class Cell
    {
        public int X;
        public int Y;
        public bool Alive = true;
    }
    public class Ship
    {
        public string Name = "";
        public List<Cell> Cells = new List<Cell>();
        public bool IsAlive = true;
        public bool IsWounded(int x, int y)
        {
            foreach (Cell cell in Cells)
            {
                if(cell.X == x && cell.Y == y)
                {
                    cell.Alive = false;
                    return true;
                }
            }
            return false;
        }

        public bool IsKilled(int x, int y)
        {
            bool shipKilled = false;

            int killedCells = 0;

            foreach (Cell cell in Cells)
            {
                if (cell.Alive == false)
                {
                    killedCells++;
                }
            }

            if (killedCells == Cells.Count)
            {
                IsAlive = false;
                shipKilled = true;
            }

            return shipKilled;
        }
    }
}
