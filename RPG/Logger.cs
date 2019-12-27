using System;
using System.Collections.Generic;
using System.Text;

namespace RPG
{
    public static class Logger
    {
        public static void LogVS(Player player1)
        {
            Console.WriteLine($"{player1.Class} {player1.Name} vs {player1.Opponent.Class} {player1.Opponent.Name}.");
        }
        public static void LogText(string message)
        {
            Console.WriteLine(message);
        }
    }
}
