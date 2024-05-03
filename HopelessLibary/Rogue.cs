using HopelessLibary.Intefrace;
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
        public void Ambush(Monster monster)
        {
            int dmg;
            if (new Random().Next(1, 101) > CritChance)
            {
                dmg = new Random().Next(Dexterity, Dexterity + 6);
            }
            else
            {
                dmg = new Random().Next(Dexterity, Dexterity + 6) * 2;
            }

            monster.TakeDamage(dmg);
        }
        public void CritAndDodgeBuff(bool stan)
        {
            if (stan) { 
            DodgeChance += 100;
            CritChance += 100;
            }
            else
            {
                DodgeChance -= 100;
                CritChance -= 100;
            }
        }
        public override void TakeDamage(int damage)
        {
            double finalDmg;
            if (new Random().Next(1, 101) > DodgeChance)
            {
                finalDmg = damage * ((100 - (double)Resistance) / 100);
                finalDmg = Math.Round(finalDmg);
                if ((int)finalDmg < CurrentHP)
                    CurrentHP -= (int)finalDmg;
                else CurrentHP = 0;
            }
            else
            {

            }
        }

        public override void BasicAttack<T>(T target) 
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
