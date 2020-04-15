using System;
using System.Collections.Generic;
using System.Text;

namespace RPG
{
    public class ArcherSkill : IUseSkill
    {
        public int TimesUsedSkill = 0;
        public void UseSkill(Player user)
        {
            if (TimesUsedSkill < 1)
            {
                user.Opponent.Effects.Add(new FireArrow());
                Logger.LogText($"({user.Class}) {user.Name} использует (Огненные стрелы) на ({user.Opponent.Class}) {user.Opponent.Name}.");
                TimesUsedSkill++;
            }
            else
            {
                user.Usingskill = new Attack();
                user.UseSkill();
            }
        }
    }
}
