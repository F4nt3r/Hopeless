using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace HopelessLibary
{
    public class Monster
    {


        public string Name { get; set; }
        public int ExperienceGains { get; set; }
        public int CurrentHP { get; set; }
        public int MaxHP { get; set; }
        public int Resistance { get; set; }
        public int CritChance { get; set; }
        public int Initiative { get; set; }
        public int MinDmg { get; set; }
        public int MaxDmg { get; set; }
        public int DodgeChance { get; set; }
        public DifficultyType Type { get; set; }
        public Monster() { }
        [JsonConstructor]
        public Monster(string name, int experienceGains,  int currentHP, int maxHP, int resistance, int critChance, int initiative, int minDmg, int maxDmg, int dodgeChance, DifficultyType type)
        {
            Name = name;
            ExperienceGains = experienceGains;

            CurrentHP = currentHP;
            MaxHP = maxHP;
            Resistance = resistance;
            CritChance = critChance;
            Initiative = initiative;
            MinDmg = minDmg;
            MaxDmg = maxDmg;
            DodgeChance = dodgeChance;
            Type = type;
        }
        public Monster(Monster monster){
            Name = monster.Name;
            ExperienceGains = monster.ExperienceGains;
            CurrentHP = monster.CurrentHP;
            MaxHP = monster.MaxHP;
            Resistance = monster.Resistance;
            CritChance = monster.CritChance;
            Initiative = monster.Initiative;
            MinDmg = monster.MinDmg;
            MaxDmg = monster.MaxDmg;
            DodgeChance = monster.DodgeChance;
            Type = monster.Type;
        }
        public void BasicAttack(Character target)
        {
            int dmg;
            if (new Random().Next(1, 101) > CritChance)
            {
                dmg = new Random().Next(MinDmg, MaxDmg+1);
            }
            else
            {
                dmg = new Random().Next(MinDmg, MaxDmg + 1)*2;
            }

            target.TakeDamage(dmg);
        }

        public void TakeDamage(int damage)
        {
            double finalDmg;
            if (new Random().Next(1, 101) > DodgeChance)
            {
                finalDmg = damage * ((double)Resistance / 100);
                finalDmg = Math.Round(finalDmg);
                CurrentHP -= (int)finalDmg;
            }
            else
            {

            }
        }

        public bool IsDead()
        {
            return CurrentHP <= 0;
        }

        public override string? ToString()
        {
            return Name;
        }
    }
}
