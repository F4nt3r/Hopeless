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


        public Rogue(string name, int experiencePoints, int strength, int dexterity, int intelligence, int currentHP, int maxHP, int resistance, int critChance, int initiative, int minDmg, int maxDmg, int dodgeChance) : base(name, experiencePoints, strength, dexterity, intelligence, currentHP, maxHP, resistance, critChance, initiative, minDmg, maxDmg)
        {
            DodgeChance = dodgeChance;
        }

       
        

        public override void LevelUp()
        {
            Level++;

        }

        public override void TakeDamage(int damage)
        {

        }

        public override void BasicAttack(Character target)
        {
            throw new NotImplementedException();
        }
    }
}
