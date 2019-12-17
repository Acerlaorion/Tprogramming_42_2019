using System;
using System.Collections.Generic;
using System.Text;

namespace RPG
{
    public class PickPlayers
    {
        public static int PickOp(List<Player> players)
        {
            Random rnd = new Random();
            int randomplayer1 = rnd.Next(0, players.Count);
            int randomplayer2 = rnd.Next(0, players.Count);
            while(randomplayer1 == randomplayer2)
            {
                randomplayer2 = rnd.Next(0, players.Count);
            }
            players[randomplayer1].Opponent = players[randomplayer2];
            players[randomplayer2].Opponent = players[randomplayer1];
            return randomplayer1;
        }
    }
}
