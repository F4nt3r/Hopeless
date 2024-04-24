using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HopelessLibary
{
    public class Knight : Character {


        public int BlockChance { get; set; }
        


        public Knight(string name, int experiencePoints, int strength, int dexterity, int intelligence, int currentHP, int maxHP, int resistance, int critChance, int initiative, int minDmg, int maxDmg, int blockChance) : base(name, experiencePoints, strength, dexterity, intelligence, currentHP, maxHP, resistance, critChance, initiative, minDmg, maxDmg)
        {
            BlockChance = blockChance;
            Weapon = null;
            Armor = null;
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
