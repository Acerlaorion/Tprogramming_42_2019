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
                int AtkOrUseSkill1 = rnd.Next(0, 2);
                int AtkOrUseSkill2 = rnd.Next(0, 2);
                if (AtkOrUseSkill1 == 0 && w.HP > 0)
                {
                    w.Attack();
                }
                else if (AtkOrUseSkill1 == 1 && w.HP > 0)
                {
                    w.UseSkill();
                }
                if (AtkOrUseSkill2 == 0 && w.Opponent.HP > 0)
                {
                    w.Opponent.Attack();
                }
                else if (AtkOrUseSkill2 == 1 && w.Opponent.HP > 0)
                {
                    w.Opponent.UseSkill();
                }
            }
            if (w.HP < 1)
            {
                Logger.LogText($"({w.Class}) {w.Name} погиб!\n");
                w.Opponent.HP = rnd.Next(1, 100);
                w.Opponent.IsDebuffed = false;
                return w;
            }
            else if (w.Opponent.HP < 1)
            {
                Logger.LogText($"({w.Opponent.Class}) {w.Opponent.Name} погиб!\n");
                w.HP = rnd.Next(1, 100);
                w.IsDebuffed = false;
                return w.Opponent;
            }
            throw new Exception("Fatal error");

        }
    }
}
