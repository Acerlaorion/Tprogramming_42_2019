using System;
using System.Collections.Generic;
using System.Text;

namespace RPG
{
    public class Archer : Player
    {
        public Archer()
        : this("Незадано")
        { 
        }
        public Archer(string name)
        : base(name)
        {
            Skills.Add(new ArcherSkill());
            Class = "Archer";
        }
        
    }
}
