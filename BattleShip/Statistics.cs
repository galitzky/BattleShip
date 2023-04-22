using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleShip
{
    public class Statistics
    {
        public int TotalShots { get; set; }  = 0;
        public int MissedShots { get; set; } = 0;
        public int TotalDecs { get; set; } = 0;
        public int TotalShips { get; set; } = 0;


        public int InjuredMyDecs { get; set; } = 0;
        public int InjuredEnemyDecs { get; set; } = 0;

        public int KilledMyShips { get; set; } = 0;
        public int KilledEnemyShips { get; set; } = 0;

        public void Show()
        {
            Console.WriteLine("{0} {1} {2}", "Total shots:", TotalShots, '\t');
            Console.WriteLine("{0} {1} {2}", "Missed Shots:", MissedShots, '\t');
            Console.WriteLine("{0} {1} {2}", "My Fleet: Injured Decs:", InjuredMyDecs, '\t');
            Console.WriteLine("{0} {1} {2}", "My Fleet: Sunken Ships:", KilledMyShips, '\t');
            Console.WriteLine("{0} {1} {2}", "Enemy Fleet: Injured Decs:", InjuredEnemyDecs, '\t');
            Console.WriteLine("{0} {1} {2}", "Enemy Fleet: Sunken Ships:", KilledEnemyShips, '\t');
        }
    }
}
