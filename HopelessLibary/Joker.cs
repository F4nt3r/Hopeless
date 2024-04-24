using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HopelessLibary
{
    public class Joker : Character
    {



        public Joker(string name, int experiencePoints, int strength, int dexterity, int intelligence, int currentHP, int maxHP, int resistance, int critChance, int initiative, int minDmg, int maxDmg) : base(name, experiencePoints, strength, dexterity, intelligence, currentHP, maxHP, resistance, critChance, initiative, minDmg, maxDmg)
        {

        }

        



        public override void BasicAttack(Character target)
        {
            throw new NotImplementedException();
        }

        public override void LevelUp()
        {
            throw new NotImplementedException();
        }

        public override void TakeDamage(int damage)
        {
            throw new NotImplementedException();
        }
    }
}
