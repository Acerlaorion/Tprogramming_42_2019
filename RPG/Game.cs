using System;
using System.Collections.Generic;
namespace RPG
{
    class Game
    {
        private static Random rnd = new Random();
        static Player Battle(Player w)
        {
            while (w.HP > 0 && w.Opponent.HP > 0)
            {
                int AtkOrUseSkill1 = rnd.Next(0, 1);
                int AtkOrUseSkill2 = rnd.Next(0, 1);
                if (AtkOrUseSkill1 == 0)
                {
                    w.Attack();
                }
                else if (AtkOrUseSkill1 == 1)
                {
                    w.UseSkill();
                }
                if (AtkOrUseSkill2 == 0)
                {
                    w.Opponent.Attack();
                }
                else if (AtkOrUseSkill2 == 1)
                {
                    w.Opponent.UseSkill();
                }
            }
            if (w.HP < 1)
            {
                Logger.LogText($"({w.Class}) {w.Name} погиб!\n");
                w.Opponent.HP = rnd.Next(1, 100);
                return w;
            }
            else if (w.Opponent.HP < 1)
            {
                Logger.LogText($"({w.Opponent.Class}) {w.Opponent.Name} погиб!\n");
                w.HP = rnd.Next(1, 100);
                return w.Opponent;
            }
            throw new Exception("Fatal error");

        }
        static void PickOp(List<Player> players)
        {
            int i = 1;
            while (players.Count > i)
            {
                players[i - 1].Opponent = players[i];
                players[i].Opponent = players[i - 1];
                i += 2;
            }
        }
        static void Main(string[] args)
        {
            string[] names = { "WhiteCat", "Vaxei", "Alumetri", "idke", "Micca", "FlyingTuna", "Karthy", "RyuK", "Varvalian",
                                "Mathi", "FGSky", "fieryrage", "firebat92", "chocomint", "Abyssal", "Aireu"};
            Console.Write($"Введите кол-во игроков(1-16):");
            int n = Convert.ToInt32(Console.ReadLine());
            if(n%2!=0)
            {
                throw new Exception("Wrong count players");
            }
            List<Player> players = new List<Player>();
            int i = 1;
            int k = 0;
            int kon = 1;
            while (players.Count < n)
            {
                int c1 = rnd.Next(0, 2);
                int c2 = rnd.Next(0, 2);
                while (c1 == c2) c2 = rnd.Next(0, 2);
                if (c1 == 0)
                {
                    players.Add(new Knight(names[k]));
                }
                if (c1 == 1)
                {
                    players.Add(new Archer(names[k]));
                }
                if (c1 == 2)
                {
                    players.Add(new Mage(names[k]));
                }
                k++;
                if (c2 == 0)
                {
                    players.Add(new Knight(names[k]));
                }
                if (c2 == 1)
                {
                    players.Add(new Archer(names[k]));
                }
                if (c2 == 2)
                {
                    players.Add(new Mage(names[k]));
                }
                k++;
                players[i-1].Opponent = players[i];
                players[i].Opponent = players[i - 1];
                i += 2;
            }

            while(players.Count > 1)
            {
                Logger.LogText($"{kon}-й Кон\n");
                while (true)
                {
                    int randomplayer = rnd.Next(0, players.Count - 1);
                    if (players[randomplayer].Opponent == null)
                    {
                        randomplayer = rnd.Next(0, players.Count - 1);
                    }
                    else
                    {
                        
                        Player tempPlayer = Battle(players[randomplayer]);
                        players[players.IndexOf(tempPlayer)].Opponent.Opponent = null;
                        players[players.IndexOf(tempPlayer)].Opponent = null;
                        players.Remove(tempPlayer);
                    }
                    if(players.Count == 1 || (players[0].Opponent==null && players[1].Opponent == null))
                    {
                        break;
                    }
                }
                PickOp(players);
                kon++;
            }
            Logger.LogText($"({players[0].Class}) {players[0].Name} WINNER!!!");
        }
    }
}
