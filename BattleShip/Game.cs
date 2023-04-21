using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Intrinsics.X86;
using System.Text;
using System.Threading.Tasks;

namespace BattleShip
{
    public class Game
    {
        // data memberes
        User? User1 = null;
        User? User2 = null;

        bool debugMode = true;

        // methods
        public void StartGame(int axisX, int axisY)
        {
            int ships = 2;
            string? name1 = "";
            string? name2 = "";

            if (debugMode == true)
            {
                name1 = "Shon";
                name2 = "Daniel";
            }

            if(debugMode == false)
            {
                Console.WriteLine("Who is player 1?");
                name1 = Console.ReadLine();
            }

            User1 = new User(name1);
            User1.InitBoards(axisX, axisY);
            User1.CreateShips(ships, debugMode);
            User1.ActiveBoard.DrawBoardWithShips("Capitan " + User1.Name + " it's your Ships");
            User1.EnemyBoard.DrawBoardWithShips("Battle field");

            if (debugMode == false)
            {
                Console.WriteLine("Who is player 2?");
                name2 = Console.ReadLine();
            }
            
            User2 = new User(name2);
            User2.InitBoards(axisX, axisY);
            User2.CreateShips(ships, debugMode);
            User2.ActiveBoard.DrawBoardWithShips("Capitan " + User2.Name + " it's your Ships");
            User2.EnemyBoard.DrawBoardWithShips("Battle field");
        }
        public void ExecuteGame()
        {
            User? activeUser = User1;
            User? notActiveUser = User2;

            Console.WriteLine("Admirals are you ready?");
            Console.ReadKey();
            Console.Clear();

            while (true) 
            {
                Console.WriteLine("Admiral {0} now it's your turn!", activeUser?.Name);

                activeUser?.ActiveBoard.DrawBoardWithShips(string.Format("Our fleet. Commander Admiral {0}", activeUser?.Name));
                activeUser?.EnemyBoard.DrawBoardWithShips(string.Format("Enemy's fleet. Commander Admiral {0}", notActiveUser?.Name));

                Console.WriteLine("Enter shoot coordinate X: ");

                bool isShootX = int.TryParse(Console.ReadLine(), out int shootX);

                Console.WriteLine("Enter shoot coordinate Y: ");
                bool isShootY = int.TryParse(Console.ReadLine(), out int shootY);

                if (!isShootX || !isShootY)
                {
                    Console.WriteLine("Next time please enter a valid X and Y parameters");
                    notActiveUser = activeUser;
                    activeUser = activeUser == User1 ? User2 : User1;
                    continue;
                }

                Ship? ship = activeUser?.Shoot(shootY, shootX, notActiveUser, activeUser);

                if (ship == null)
                {
                    Console.WriteLine("Admiral {0}, you missed :(. Coordinates: {1}, {2}", activeUser?.Name, shootX, shootY);
                    Console.WriteLine("Your status Admiral --------------------------------------------------------------");
                    activeUser?.EnemyBoard.DrawBoardWithShips(string.Format("{0} Board", notActiveUser?.Name));
                    activeUser?.Statistics.Show();
                    Console.ReadKey();
                    Console.Clear();

                    notActiveUser = activeUser;
                    activeUser = activeUser == User1 ? User2 : User1;
                }
                else
                {
                    Console.WriteLine("Good shoot Admiral! Enemy ship '{0}' was wounded", ship.Name);

                    if (ship.IsKilled() == true)
                    {
                        Console.WriteLine("Great Admiral! Enemy ship '{0}' was killed", ship.Name);
                    }
                }
            }
        }
    }
}
