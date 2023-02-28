using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleShip
{
    public class User
    {
        public Ship? Shoot(int x, int y, Board board)
        {
            foreach (Ship ship in board.Ships)
            {
                foreach (Cell cell in ship.Cells)
                {
                    if(cell.X == x && cell.Y == y)
                    {
                        return ship;
                    }
                }
            }

            return null;
        }
    }
}
