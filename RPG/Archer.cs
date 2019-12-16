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
        : this(name, null)
        {
        }
        public Archer(string name, Player opponent)
        : base(name, opponent)
        {
            Class = "Archer";
            Usingskill = new ArcherSkill();
        }
        
    }
}
