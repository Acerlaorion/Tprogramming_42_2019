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
            Console.Write($"Введите кол-во игроков(1-16):");
            int n = Convert.ToInt32(Console.ReadLine());
            Random rnd = new Random();
            List<Player> players = new List<Player>();
            int kon = 1;
            
            int i = 1;
            int k = 0;
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
            
            while (true)
            {
                int w = rnd.Next(0, players.Count - 1);
                while (players[w].HP > 0 && players[w].Opponent.HP > 0)
                {
                    int AtkOrUseSkill1 = rnd.Next(0, 1);
                    int AtkOrUseSkill2 = rnd.Next(0, 1);
                    if (AtkOrUseSkill1 == 0)
                    {
                        players[w].Attack();
                    }
                    else if (AtkOrUseSkill1 == 1)
                    {
                        players[w].UseSkill();
                    }
                    if (AtkOrUseSkill2 == 0)
                    {
                        players[w].Opponent.Attack();
                    }
                    else if (AtkOrUseSkill2 == 1)
                    {
                        players[w].Opponent.UseSkill();
                    }
                }
                if (players[w].HP < 1)
                {
                    Logger.LogText($"{players[w].Class} {players[w].Name} погиб!");
                    players.Remove(players[w]);
                    players[w].Opponent.HP = rnd.Next(1, 100);
                    kon++;
                }
                else if (players[w].Opponent.HP < 1)
                {
                    Logger.LogText($"{players[w].Opponent.Class} {players[w].Opponent.Name} погиб!");
                    players.Remove(players[w].Opponent);
                    players[w].HP = rnd.Next(1, 100);
                    kon++;
                }
            }
        }
    }
}
