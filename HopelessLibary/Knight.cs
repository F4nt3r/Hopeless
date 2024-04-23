﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HopelessLibary
{
    public class Knight : Character { 
         public int BlockChance { get; set; }
        public Weapon Weapon { get; set; }
        public Armor Armor { get; set; }

        public Knight(int blockChance,string name, int experiencePoints, int strength, int dexterity, int intelligence, int currentHP, int maxHP, int magicResistance, int physicalResistance, int critChance, int initiative, int minDmg, int maxDmg) : base(name, experiencePoints, strength, dexterity, intelligence, currentHP, maxHP, magicResistance, physicalResistance, critChance, initiative,minDmg,maxDmg)
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

        public override void BasicAttack()
        {
            throw new NotImplementedException();
        }
    }
}
