using HopelessLibary.Intefrace;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HopelessLibary
{
    [Serializable]
    public class Joker : Character
    {

        public int DoubleAtackChance { get; set; }

        public Joker(string name, int experiencePoints, int strength, int dexterity, int intelligence, int currentHP, int maxHP, int resistance, int baseResistance, int critChance, int initiative, int minDmg, int maxDmg, int doubleAtackChance, CharacterType type) : base(name, experiencePoints, strength, dexterity, intelligence, currentHP, maxHP, resistance, baseResistance, critChance, initiative, minDmg, maxDmg,type)
        {
            DoubleAtackChance = doubleAtackChance;
        }

     

        public override void BasicAttack<T>(T target, out int dmg) 
        {
     
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
            Level++;
            MaxHP += 1;
            DoubleAtackChance += 1;

        }

        public override void TakeDamage(int damage)
        {

                double finalDmg = damage * ((100 - (double)Resistance) / 100);
                finalDmg = Math.Round(finalDmg);

                if((int)finalDmg<CurrentHP)
                CurrentHP -= (int)finalDmg;
                else CurrentHP = 0;
           
        }

        public void AoeBuff(List<Character> characters,bool stan)
        {
            
            foreach (Character character in characters)
            {
                if (stan)
                {
                    character.MinDmg += 3;
                    character.MaxDmg += 3;
                }
                else
                {
                    character.MinDmg -= 3;
                    character.MaxDmg -= 3;
                }
               
            }
        }
        public void AoeDeBuff(List<Monster> monsters, bool stan)
        {

            foreach (Monster monster in monsters)
            {
                if (stan)
                {
                    monster.Resistance -= 10;
                }
                else
                {
                    monster.Resistance += 10;
                }

            }
        }
    }
}
