using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleShip
{
   
    public class Ship
    {
        // data members
        public string Name = "";
        public List<Cell> Cells = new List<Cell>();
        public bool IsAlive = true;

        // methods
        public bool IsWounded(int shootX, int shootY)
        {
            foreach (Cell cell in Cells)
            {
                if(cell.X == shootX && cell.Y == shootY)
                {
                    cell.Alive = false;
                    return true;
                }
            }
            return false;
        }

        public bool IsKilled()
        {
            bool shipKilled = false;

            int killedCells = Cells.Where(currentCell => currentCell.Alive == false).Count();

            //foreach (Cell cell in Cells)
            //{
            //    if (cell.Alive == false)
            //    {
            //        killedCells++;
            //    }
            //}

            if (killedCells == Cells.Count)
            {
                IsAlive = false;
                shipKilled = true;
            }

            return shipKilled;
        }
    }
}
