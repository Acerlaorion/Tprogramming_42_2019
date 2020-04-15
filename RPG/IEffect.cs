using System;
using System.Collections.Generic;
using System.Text;

namespace RPG
{
    public interface IEffect
    {
        void Proc(Player owner);
    }
}