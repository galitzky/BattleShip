using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleShip
{
    public enum CellStatus
    {
        Alive = 0,
        WaterHit = 1,
        ShipHit = 2,
        ShipKilled = 3,
    }
    public class Cell
    {
        // data members
        public int X;
        public int Y;
        public CellStatus Status = CellStatus.Alive;

        // constructors
        public Cell()
        {
        }

        public Cell(int x, int y)
        {
            X = x;
            Y = y;
            Status = CellStatus.Alive;
        }

        // methods
    }
}
