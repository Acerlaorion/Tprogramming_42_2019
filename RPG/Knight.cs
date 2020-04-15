using System;
using System.Collections.Generic;
using System.Text;

namespace RPG
{
    public class Knight : Player
    {
        public Knight()
        : this("Незадано")
        {
        }
        public Knight(string name)
        :base(name)
        {
            Skills.Add(new KnightSkill());
            Class = "Knight";
        }
        
    }
}
