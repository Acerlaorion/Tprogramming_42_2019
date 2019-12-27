﻿using System;
using System.Collections.Generic;
using System.Text;

namespace RPG
{
    public class MageSkill : IUseSkill
    {
        public void UseSkill(Player user)
        {
            user.Opponent.IsSkipped = true;
            Logger.LogText($"({user.Class}) {user.Name} использует (Заворожение) на ({user.Opponent.Class}) {user.Opponent.Name}.");
        }
    }
}
