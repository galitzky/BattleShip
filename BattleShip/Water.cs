using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleShip
{
    public class Watern /////////
    {
        // data members
        public List<Cell> Cells = new List<Cell>();

        // methods
        public bool IsWaterWounded(int shootX, int shootY)
        {
            foreach (Cell cell in Cells)
            {
                if (cell.X == shootX && cell.Y == shootY)
                {
                    cell.Alive = false;
                    return true;
                }
            }
            return false;
        }
    }
}
