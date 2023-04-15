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

        public Cell() { }

        public Cell(int x, int y)
        {
            X = x;
            Y = y;
            Alive = true;
        }
    }
}
