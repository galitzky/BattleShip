using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleShip
{
    public class Water
    {
        // data members
        public List<Cell> Cells = new List<Cell>();

        // methods
        public bool IsWaterWounded(int shootX, int shootY)
        {
            Cell? cell = Cells.FirstOrDefault(cell => cell.X == shootX && cell.Y == shootY);
            if (cell == null)
            {
                return false;
            }
            return true;
        }
    }
}
