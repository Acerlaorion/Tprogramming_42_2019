using System;
using System.Collections.Generic;
using System.Text;

namespace RPG
{
    public static class ClassBattle
    {
        public static Player Battle(Player w)
        {
            Random rnd = new Random();
            while (w.HP > 0 && w.Opponent.HP > 0)
            {
                int RandomSkill1 = rnd.Next(0, w.Skills.Count);
                int RandomSkill2 = rnd.Next(0, w.Opponent.Skills.Count);
                if (w.HP > 0)
                {
                    w.Usingskill = w.Skills[RandomSkill1];
                    w.UseSkill();
                }
                if (w.Opponent.HP > 0)
                {
                    w.Opponent.Usingskill = w.Opponent.Skills[RandomSkill2];
                    w.Opponent.UseSkill();
                }
            }
            if (w.HP < 1)
            {
                Logger.LogText($"({w.Class}) {w.Name} погиб!\n");
                w.Opponent.HP = rnd.Next(1, 100);
                w.Opponent.Effects.Remove("Огненные стрелы");
                return w;
            }
            else if (w.Opponent.HP < 1)
            {
                Logger.LogText($"({w.Opponent.Class}) {w.Opponent.Name} погиб!\n");
                w.HP = rnd.Next(1, 100);
                w.Effects.Remove("Огненные стрелы");
                return w.Opponent;
            }
            throw new Exception("Fatal error");

        }
    }
}
