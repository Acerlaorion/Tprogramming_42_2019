using System;
using System.Collections.Generic;
namespace RPG
{
    class Game
    {
        static void Main(string[] args)
        {
            string[] names = { "WhiteCat", "Vaxei", "Alumetri", "idke", "Micca", "FlyingTuna", "Karthy", "RyuK", "Varvalian",
                                "Mathi", "FGSky", "fieryrage", "firebat92", "chocomint", "Abyssal", "Aireu"};
            int n = 0;
            try
            {
                Console.Write($"Введите кол-во игроков(1-16):");
                string nString = Console.ReadLine();
                n = Convert.ToInt32(nString);
            }
            catch (System.FormatException)
            {
                Console.Write($"Введите кол-во игроков(1-16):");
                string nString = Console.ReadLine();
                n = Convert.ToInt32(nString);
            }
            while (n % 2 != 0 || n <= 0)
            {
                Console.Write($"Введите кол-во игроков(1-16):");
                n = Convert.ToInt32(Console.ReadLine());
            }
            Random rnd = new Random();
            List<Player> players = new List<Player>();
            List<Player> winners = new List<Player>();
            int k = 0;
            int kon = 1;
            while (players.Count < n)
            {
                int c1 = rnd.Next(0, 3);
                switch (c1)
                {
                    case 0:
                        players.Add(new Knight(names[k]));
                        break;
                    case 1:
                        players.Add(new Archer(names[k]));
                        break;
                    case 2:
                        players.Add(new Mage(names[k]));
                        break;
                }
                k++;
            }
            Logger.LogText($"{kon++}-й Кон\n");
            while (players.Count + winners.Count > 1)
            {
                if (players.Count > 1 && !(players.Count < 2))
                {
                    Player tempPlayer = ClassBattle.Battle(players[PickPlayers.PickOp(players)]);
                    winners.Add(tempPlayer.Opponent);
                    players.Remove(tempPlayer.Opponent);
                    players[players.IndexOf(tempPlayer)].Opponent.Opponent = null;
                    players.Remove(tempPlayer);
                }
                else
                {
                    Logger.LogText($"{kon}-й Кон\n");
                    players.AddRange(winners);
                    winners.Clear();
                    kon++;
                }
            }
            Logger.LogText($"({winners[0].Class}) {winners[0].Name} WINNER!!!");
        }
    }
}
