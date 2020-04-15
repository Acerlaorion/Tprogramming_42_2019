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
                w.ProcEffects();
                if (w.isStunned == false)
                {
                    w.Usingskill = w.Skills[RandomSkill1];
                    w.UseSkill();
                }
                else
                {
                    w.isStunned = false;
                    for (int i = 0; i < w.Effects.Count; i++)
                    {
                        if (w.Effects[i] is Skip)
                        {
                            w.Effects.RemoveAt(i);
                            i--;
                        }
                    }
                }
                w.Opponent.ProcEffects();
                if (w.Opponent.HP > 0)
                {
                    if (w.Opponent.isStunned == false)
                    {
                        w.Opponent.Usingskill = w.Opponent.Skills[RandomSkill2];
                        w.Opponent.UseSkill();
                    }
                    else 
                    {
                        w.Opponent.isStunned = false;
                        for (int i = 0; i < w.Effects.Count; i++)
                        {
                            if (w.Opponent.Effects[i] is Skip)
                            {
                                w.Opponent.Effects.RemoveAt(i);
                                i--;
                            }
                        }
                    }
                }
            }
            if (w.HP < 1)
            {
                Logger.LogText($"({w.Class}) {w.Name} погиб!\n");
                w.Opponent.HP = rnd.Next(1, 100);
                w.Opponent.Effects.Clear();
                return w;
            }
            else if (w.Opponent.HP < 1)
            {
                Logger.LogText($"({w.Opponent.Class}) {w.Opponent.Name} погиб!\n");
                w.HP = rnd.Next(1, 100);
                w.Effects.Clear();
                return w.Opponent;
            }
            throw new Exception("Fatal error");

        }
    }
}
