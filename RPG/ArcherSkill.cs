using System;
using System.Collections.Generic;
using System.Text;

namespace RPG
{
    public class ArcherSkill : IUseSkill
    {
        public void UseSkill(Player user)
        {
            user.Opponent.IsDebuffed = true;
            Logger.LogText($"({user.Class}) {user.Name} использует (Огненные стрелы) на ({user.Opponent.Class}) {user.Opponent.Name}.");
        }
    }
}
