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
        public Weapon Weapon { get; set; }
        public Armor Armor { get; set; }

        public Rogue(int dodgeChance,  string name, int experiencePoints, int strength, int dexterity, int intelligence, int currentHP, int maxHP, int magicResistance, int physicalResistance, int critChance, int initiative, int minDmg, int maxDmg) : base(name, experiencePoints, strength, dexterity, intelligence, currentHP, maxHP, magicResistance, physicalResistance, critChance, initiative, minDmg, maxDmg)
        {
            DodgeChance = dodgeChance;
            Weapon=null;
            Armor=null;

        }

        public override void LevelUp()
        {
            Level++;

        }

        public override void TakeDamage(int damage)
        {

        }

        public override void BasicAttack()
        {
            throw new NotImplementedException();
        }
    }
}
