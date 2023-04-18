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
        public string? Name = "";
        public List<Cell> Cells = new List<Cell>();
        public bool Alive = true;

        // methods
       
        public bool IsKilled()
        {
            bool shipKilled = false;

            int killedCells = Cells.Where(currentCell => currentCell.Status == CellStatus.ShipHit).Count();

            if (killedCells == Cells.Count)
            {
                Alive = false;
                shipKilled = true;
                Cells = Cells.Select(cell => { cell.Status = CellStatus.ShipKilled; return cell; }).ToList();
            }

            return shipKilled;
        }
    }
}
