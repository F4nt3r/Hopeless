using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HopelessLibary
{
    public class Cleric : Character

    {




        public Cleric(string name, int experiencePoints, int strength, int dexterity, int intelligence, int currentHP, int maxHP, int resistance, int baseResistance, int critChance, int initiative, int minDmg, int maxDmg, CharacterType type) : base(name, experiencePoints, strength, dexterity, intelligence, currentHP, maxHP, resistance, baseResistance, critChance, initiative, minDmg, maxDmg, type)
        {

        }





        public void Heal (Character character)
        {
            int heal;
            if (new Random().Next(1, 100) > CritChance)
            {
                heal = Intelligence * 3;
            }
            else
            {
                heal = Intelligence * 3 * 2;
            }
            if (heal < character.MaxHP - character.CurrentHP)
                character.CurrentHP += heal;
            else
                character.CurrentHP = character.MaxHP;

        }

        public void AoeHeal(List<Character> characters)
        {
            int heal;
            if (new Random().Next(1, 100) > CritChance)
            {
                heal = Intelligence;
               
            }
            else
            {
                heal = Intelligence * 2;
            }
            foreach (Character character in characters)
            {
                if (heal < character.MaxHP - character.CurrentHP)
                    character.CurrentHP += heal;
                else
                    character.CurrentHP = character.MaxHP;
            }


        }


        public override int BasicAttack()
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

            return dmg;
        }

        public override void LevelUp()
        {
            Level++;
        }

        public override void TakeDamage(int damage)
        {
            double finalDmg = damage * ((1 - (double)Resistance) / 100);
            finalDmg = Math.Round(finalDmg);
            CurrentHP -= (int)finalDmg;
        }
    }
}
