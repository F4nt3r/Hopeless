using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HopelessLibary
{
    public class Cleric : Character

    {
        public Weapon Weapon { get; set; }
        public Armor Armor { get; set; }
        public Cleric(string name, int experiencePoints, int strength, int dexterity, int intelligence, int currentHP, int maxHP, int magicResistance, int physicalResistance, int critChance, int initiative, int minDmg, int maxDmg) : base(name, experiencePoints, strength, dexterity, intelligence, currentHP, maxHP, magicResistance, physicalResistance, critChance, initiative, minDmg, maxDmg)
        {
            Weapon = null;
            Armor = null;
        }


        public void Heal(Character target)
        {
            int heal;
            if (new Random().Next(1,100) > CritChance)
            {
                heal = Intelligence * 10;
            }
            else
            {
                heal = Intelligence * 10 * 2;
            }
            if (target.MaxHP-target.CurrentHP>heal)
            {
                target.CurrentHP += heal;
            }
            else
            {
                target.CurrentHP = target.MaxHP;
            }
        }

        public void Purify(Character target)
        {
            int dmg;
            if (new Random().Next(1, 100) > CritChance)
            {
                dmg = Intelligence * 10;
            }
            else
            {
                dmg = Intelligence * 10 * 2;
            }

            target.TakeDamage(dmg);
           
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
           CurrentHP -= damage;
        }
    }
}
