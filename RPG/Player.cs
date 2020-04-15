using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace RPG
{
    
    public abstract class Player
    {
        private static readonly Random rnd = new Random();
        public Player()
        : this("Незадано")
        {
        }
        public Player(string name)
        {
            Name = name;
            HP = rnd.Next(1, 100);
            Strength = rnd.Next(1, 99);
            Skills.Add(new Attack());
        }
        public string Class { get; protected set; }
        public string Name { get; set; }
        public Player Opponent { get; set; } = null;
        public double HP { get; set; }
        public int Strength { get; }
        public bool isStunned { get; set; }
        public IUseSkill Usingskill { get; set; }

        public List<IUseSkill> Skills = new List<IUseSkill>();

        public List<IEffect> Effects = new List<IEffect>();
        
        public void UseSkill()
        {           
            Usingskill.UseSkill(this);
        }
        public void ProcEffects()
        {
            for(int i=0;i<Effects.Count;i++)
            {
                Effects[i].Proc(this);
            }
        }
}
}
