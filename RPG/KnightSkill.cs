using System;
using System.Collections.Generic;
using System.Text;

namespace RPG
{
    public class KnightSkill : IUseSkill
    {
        public void UseSkill(Player user)
        {
            user.Opponent.HP -= user.Strength * 1.3;
            Logger.LogText($"({user.Class}) {user.Name} использует (Удар возмездия) и наносит урон {user.Strength * 1.3} противнику ({user.Opponent.Class}){user.Opponent.Name}.");
        }
    }
}
