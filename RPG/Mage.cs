using System;
using System.Collections.Generic;
using System.Text;

namespace RPG
{
    public class Mage : Player
    {
        public Mage()
        : this("Незадано")
        {
        }
        public Mage(string name)
        : this(name, null)
        { 
        }
        public Mage(string name, Player opponent)
        : base(name, opponent)
        {
            Class = "Mage";
            Skills.Add(new MageSkill());
        }
        
    }
}
