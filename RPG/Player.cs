using System;
using System.Collections.Generic;
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
        }
        public string Class { get; protected set; }
        public string Name { get; set; }
        public Player Opponent { get; set; } = null;
        public double HP { get; set; } = rnd.Next(1, 100);
        public int Strength { get; } = rnd.Next(1, 99);
        public bool IsDebuffed { get; set; } = false;
        public bool IsSkipped { get; set; } = false;
        internal IUseSkill Usingskill { get; set; }

        public void Skip()
        {

        }
        public virtual void Attack()
        {
            if (!IsSkipped)
            {
                if (!IsDebuffed)
                {
                    Opponent.HP -= Strength;
                    Logger.LogText($"({Class}) {Name} наносит урон {Strength} противнику ({Opponent.Class}) {Opponent.Name}.");
                }
                else
                {
                    HP -= 2;
                    Logger.LogText($"({Class}) {Name} получает урон 2 от (Огненные стрелы).");
                    Opponent.HP -= Strength;
                    Logger.LogText($"({Class}) {Name} наносит урон {Strength} противнику ({Opponent.Class}) {Opponent.Name}.");
                }
            }
            else
            {
                Logger.LogText($"({Class}) {Name} пропускает ход.");
            }
        }
        public void UseSkill()
        {
            if (!IsSkipped)
            {
                if (!IsDebuffed)
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
            }
            
        }
    }
}
