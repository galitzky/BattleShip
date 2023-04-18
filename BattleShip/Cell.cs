using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleShip
{
    public enum CellStatus
    {
        Alive,
        WaterHit,
        ShipHit,
        ShipKilled,
    }
    public class Cell
    {
        public int X;
        public int Y;
        public CellStatus Status = CellStatus.Alive;

        public Cell() { }

        public Cell(int x, int y)
        {
            X = x;
            Y = y;
            Status = CellStatus.Alive;
        }
    }
}
