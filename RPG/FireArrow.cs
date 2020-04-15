    using System;
using System.Collections.Generic;
using System.Text;

namespace RPG
{
    public class FireArrow : IEffect
    {
        public const int DamageFireArrow = 2;
        public void Proc(Player owner)
        {
            owner.HP -= DamageFireArrow;
            Logger.LogText($"({owner.Class}) {owner.Name} получает урон {DamageFireArrow} от эффекта Fire Arrow.");
        }
    }
}
