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
        : this(name,null)
        {
        }
        public Player(string name, Player opponent)
        {
            Name = name;
            Opponent = opponent;
            Skills.Add(new Attack());
        }
        public string Class { get; protected set; }
        public string Name { get; set; }
        public Player Opponent { get; set; } = null;
        public double HP { get; set; } = rnd.Next(1, 100);
        public int Strength { get; } = rnd.Next(1, 99);
        public IUseSkill Usingskill { get; set; }

        public List<IUseSkill> Skills = new List<IUseSkill>();

        public List<string> Effects = new List<string>();
        
        public void UseSkill()
        {
            if (!Effects.Any(item => item == "Заворожение"))
            {
                if (!Effects.Any(item => item == "Огненные стрелы"))
                {
                    Usingskill.UseSkill(this);
                }
                else
                {
                    HP -= 2;
                    Logger.LogText($"({Class}) {Name} получает урон 2 от (Огненные стрелы).");
                    Usingskill.UseSkill(this);
                }
            }
            else
            {
                Logger.LogText($"({Class}) {Name} пропускает ход.");
                Effects.Remove("Заворожение");
            }

        }
    }
}
