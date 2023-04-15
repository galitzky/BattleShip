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
        public bool Alive = true;

        // methods
        public bool IsWounded(int shootX, int shootY)
        {
            Cell? cell = Cells.FirstOrDefault(currentCell => currentCell.X == shootX && currentCell.Y == shootY);

            if (cell == null)
            {
                return false;
            }

            cell.Alive = false;

            return true;
        }

        public bool IsKilled()
        {
            bool shipKilled = false;

            int killedCells = Cells.Where(currentCell => currentCell.Alive == false).Count();

            if (killedCells == Cells.Count)
            {
                Alive = false;
                shipKilled = true;
            }

            return shipKilled;
        }
    }
}
