using HopelessLibary.Enums;
using HopelessLibary.Helpers;
using HopelessLibary.Intefrace;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace HopelessLibary
{
    [Serializable]
    public class Knight : Character {

        private string SKILL_1_DESCRIPTION => "Sprawia, że wszyscy wrogowie skupiają się na postaci Knight" + Environment.NewLine + "Cooldown: 4 tury" + Environment.NewLine + "Czas Trwania: 2 tury";
        private string SKILL_2_DESCRIPTION => "Uderzasz wszystkich wrogów mocą Swiatła" + Environment.NewLine + "Cooldown: 2 tury" + Environment.NewLine + "DMG: " + Intelligence + "-" + (Intelligence + 2);
        [JsonPropertyName("BlockChance")]
        public int BlockChance { get; set; }

        private Skill skill1;
        public override Skill? Skill1 { 
            get
            {
                if(skill1 == null) 
                  skill1  = new("Provoke", 0, TargetType.Enemy, SkillType.AoE, handlerProvoke, SKILL_1_DESCRIPTION);

                return skill1;
            }  
        }

        private Skill skill2;
        public override Skill? Skill2
        {
            get
            {
                if (skill2 == null)
                    skill2 = new("Purify", 0, TargetType.Enemy, SkillType.AoE, handlerPurify, SKILL_2_DESCRIPTION);

                return skill2;
            }
        }

        public Knight(string name, int experiencePoints, int strength, int dexterity, int intelligence, int currentHP, int maxHP, int resistance, int baseResistance, int critChance, int initiative, int minDmg, int maxDmg, int blockChance, CharacterType type) : base(name, experiencePoints, strength, dexterity, intelligence, currentHP, maxHP, resistance, baseResistance, critChance, initiative, minDmg, maxDmg, type)
        {
            BlockChance = blockChance;

        }


        public override void LevelUp()
        {
            Level++;
            MaxHP += 3;
            Strength += 2;
            Intelligence += 2;
        }

        public override void TakeDamage(int damage)
        {
            double finalDmg;
            if (new Random().Next(1, 101) > BlockChance)
            {
                finalDmg = damage * ((100 - (double)Resistance) / 100);
                finalDmg = Math.Round(finalDmg);
                if ((int)finalDmg < CurrentHP)
                    CurrentHP -= (int)finalDmg;
                else {  
                    CurrentHP = 0;
                    SoundEffectHelper.PlayDeathSound();
                }
            }
            else
            {
              
            }
          
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


      
        private SkillHandlerEvent handlerProvoke = (caster,creatures) =>
        {
            if (caster.Skill1 == null)
                return null;

            Knight? rycerz = caster as Knight;
            if (rycerz == null)
                return null;

            if (caster.Skill1.Cooldown == 0)
            {
                SoundEffectHelper.PlayProvokeSound();
               
                caster.Skill1.Cooldown = 3;
                foreach (var item in creatures)
                {   if(item.CharacterType != CharacterType.Monster) continue;


                    if (item.DeBuffs != null)
                        item.AddDeBuff(new DeBuff(caster.Skill1.Name, 0, 0, 0, 0, 2, rycerz));

                    else
                    {
                        item.DeBuffs = new List<DeBuff>();
                        item.AddDeBuff(new DeBuff(caster.Skill1.Name, 0, 0, 0, 0, 2, rycerz));
                    }
                   
                }
                return new(" używa umiejętności Provoke prowokując przeciwników" + Environment.NewLine, 0);

            }
            else
            {
                return new(string.Empty, caster.Skill1.Cooldown);
            }
          
        };
       
        private SkillHandlerEvent handlerPurify = (caster, creatures) =>
        {
            if (caster.Skill2 == null)
                return null;

            Knight? rycerz = caster as Knight;
            if (rycerz == null)
                return null;
            
            if (caster.Skill2.Cooldown == 0)
            {
                SoundEffectHelper.PlayPurifySound();
                caster.Skill2.Cooldown = 3;
                int dmg = 0;
                if (new Random().Next(1, 101) > rycerz.CritChance)
                {
                    dmg = new Random().Next(rycerz.Intelligence, rycerz.Intelligence + 3);
                }
                else
                {
                    dmg = new Random().Next(rycerz.Intelligence, rycerz.Intelligence + 3) * 2;
                }

                foreach (var item in creatures)
                {
                    if (item.CharacterType != CharacterType.Monster) continue;

                    item.TakeDamage(dmg);
                }
                return new(" używa umiejętności Purify na wrogów zadając " + dmg + " obrażeń" + Environment.NewLine, 0);

            }
            else
            {
                return new(string.Empty, caster.Skill2.Cooldown);
            }

           
        };
    }
}
