using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HopelessLibary
{
    public class Joker : Character
    {



        public Joker(string name, int experiencePoints, int strength, int dexterity, int intelligence, int currentHP, int maxHP, int resistance, int baseResistance, int critChance, int initiative, int minDmg, int maxDmg, CharacterType type) : base(name, experiencePoints, strength, dexterity, intelligence, currentHP, maxHP, resistance, baseResistance, critChance, initiative, minDmg, maxDmg,type)
        {

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

        public override void LevelUp()
        {
            throw new NotImplementedException();
        }

        public override void TakeDamage(int damage)
        {

                double finalDmg = damage * ((double)Resistance / 100);
                finalDmg = Math.Round(finalDmg);
                CurrentHP -= (int)finalDmg;
            
           
        }
    }
}
