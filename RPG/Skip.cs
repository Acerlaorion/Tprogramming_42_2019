using System;
using System.Collections.Generic;
using System.Text;

namespace RPG
{
    public class Skip : IEffect
    {
        public void Proc(Player owner)
        {
            owner.isStunned = true;
            Logger.LogText($"({owner.Class}) {owner.Name} пропускает ход.");
        }
    }
}
