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
        : base(name)
        {
            Class = "Mage";
            Skills.Add(new MageSkill());
        }
        
    }
}
