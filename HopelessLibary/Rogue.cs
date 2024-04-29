using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace HopelessLibary
{
    public class Rogue :Character
    {

        public int DodgeChance { get; set; }


        public Rogue(string name, int experiencePoints, int strength, int dexterity, int intelligence, int currentHP, int maxHP, int resistance, int baseResistance, int critChance, int initiative, int minDmg, int maxDmg, int dodgeChance, CharacterType type) : base(name, experiencePoints, strength, dexterity, intelligence, currentHP, maxHP, resistance, baseResistance, critChance, initiative, minDmg, maxDmg, type)
        {
            DodgeChance = dodgeChance;
        }

       
        

        public override void LevelUp()
        {
            Level++;

        }

        public override void TakeDamage(int damage)
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

        public override void BasicAttack(Character target)
        {
            int dmg;
            if (new Random().Next(1, 101) > CritChance)
            {
                dmg = new Random().Next(MinDmg, MaxDmg + 1);
            }
            else
            {
                dmg = new Random().Next(MinDmg, MaxDmg + 1) * 2;
            }

            target.TakeDamage(dmg);
        }
    }
}
