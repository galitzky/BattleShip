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
        public Cell? Cell = null;

        public Water(int x, int y)
        {
            Cell = new Cell(x, y);
        }

        // methods
     }
}
