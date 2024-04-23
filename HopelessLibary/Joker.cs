using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HopelessLibary
{
    public class Joker : Character
    {
        public Weapon Weapon { get; set; }
        public Armor Armor { get; set; }

        public Joker(string name, int experiencePoints, int strength, int dexterity, int intelligence, int currentHP, int maxHP, int magicResistance, int physicalResistance, int critChance, int initiative, int minDmg, int maxDmg) : base(name, experiencePoints, strength, dexterity, intelligence, currentHP, maxHP, magicResistance, physicalResistance, critChance, initiative, minDmg, maxDmg)
        {
            Weapon = null;
            Armor = null;
        }

        public override void BasicAttack()
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
