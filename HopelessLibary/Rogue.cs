using HopelessLibary.Enums;
using HopelessLibary.Helpers;
using HopelessLibary.Intefrace;
using NAudio.CoreAudioApi;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace HopelessLibary
{
    [Serializable]
    public class Rogue :Character
    {
        private string SKILL_1_DESCRIPTION => "You hit the selected enemy in the back" + Environment.NewLine + "Cooldown: 2 turns" + Environment.NewLine + "DMG: " + Dexterity + "-" + (Dexterity + 5);
        private string SKILL_2_DESCRIPTION => "Makes Rogue's next attack critical and more powerfull attacks for the duration of the effect" + Environment.NewLine + "Cooldown: 4 turns" + Environment.NewLine + "Duration: 2 turns";
        public int DodgeChance { get; set; }

        private Skill skill1;
        public override Skill? Skill1
        {
            get
            {
                if (skill1 == null)
                    skill1 = new("Ambush", 0, TargetType.Enemy, SkillType.Single, handlerAmbush, SKILL_1_DESCRIPTION);

                return skill1;
            }
        }


        private Skill skill2;
        public override Skill? Skill2
        {
            get
            {
                if (skill2 == null)
                    skill2 = new("CritAndDmgBuff", 0, TargetType.Ally, SkillType.Self, handlerCritAndDmgBuff, SKILL_2_DESCRIPTION);

                return skill2;
            }
        }
        [JsonConstructor]
        public Rogue(int id, string name, int experiencePoints, int strength, int dexterity, int intelligence, int currentHP, int maxHP, int resistance, int baseResistance, int critChance, int initiative, int minDmg, int maxDmg, int dodgeChance, CharacterType type) : base(id,name, experiencePoints, strength, dexterity, intelligence, currentHP, maxHP, resistance, baseResistance, critChance, initiative, minDmg, maxDmg, type)
        {
            DodgeChance = dodgeChance;
        }
        public Rogue(Rogue existingRogue)
      : base(existingRogue.Id, existingRogue.Name, existingRogue.ExperiencePoints, existingRogue.Strength, existingRogue.Dexterity, existingRogue.Intelligence, existingRogue.CurrentHP, existingRogue.MaxHP, existingRogue.Resistance, existingRogue.BaseResistance, existingRogue.CritChance, existingRogue.Initiative, existingRogue.MinDmg, existingRogue.MaxDmg, existingRogue.CharacterType)
        {
            DodgeChance = existingRogue.DodgeChance;
        }

        public override void LevelUp()
        {
            Level++;
            Dexterity += 2;
            DodgeChance += 1;
            MaxHP += 1;
        }
     
        public override void TakeDamage(int damage)
        {
            double finalDmg;
            if (new Random().Next(1, 101) > DodgeChance)
            {
                finalDmg = damage * ((100 - (double)Resistance) / 100);
                finalDmg = Math.Round(finalDmg);
                if ((int)finalDmg < CurrentHP)
                {
                    SoundEffectHelper.PlayHitSound();
                    CurrentHP -= (int)finalDmg;
                }
                    
                else
                {
                    CurrentHP = 0;
                    SoundEffectHelper.PlayDeathSound();
                }
            }
            else
            {
                SoundEffectHelper.PlayDodgeSound();
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

        private SkillHandlerEvent handlerAmbush = (caster, creatures) =>
        {
            if (caster.Skill1 == null)
                return null;

            Rogue? lotr = caster as Rogue;
            if (lotr == null)
                return null;
            if (caster.Skill1.Cooldown == 0)
            {
                SoundEffectHelper.PlayAmbushSound();

                caster.Skill1.Cooldown = 3;
                int hp = 0;
                int hpAfter = 0;
                foreach (var item in creatures)
                {
                    if (item.CharacterType != CharacterType.Monster) continue;
                    int dmg = 0;
                    
                    if (new Random().Next(1, 101) > lotr.CritChance)
                    {
                        dmg = new Random().Next(lotr.Dexterity, lotr.Dexterity + 6);
                    }
                    else
                    {
                        dmg = new Random().Next(lotr.Dexterity, lotr.Dexterity + 6) * 2;
                    }
                    hp = item.CurrentHP;
                    item.TakeDamage(dmg);
                    hpAfter = item.CurrentHP;
                }
                if (hp != hpAfter)
                    return new(" uses Ambush skill dealing " + (hp - hpAfter) + " damage" + Environment.NewLine, 0);
                else
                    return new(" uses Ambush skill but Ambush dodged" + Environment.NewLine, 0);

            }
            else
            {
                return new(string.Empty, caster.Skill1.Cooldown);
            }
        };
        private SkillHandlerEvent handlerCritAndDmgBuff = (caster, creatures) =>
        {
            if (caster.Skill2 == null)
                return null;

            Rogue? lotr = caster as Rogue;
            if (lotr == null)
                return null;

            if (caster.Skill2.Cooldown == 0)
            {
                SoundEffectHelper.PlayACritAndDmgBuffSound();

                caster.Skill2.Cooldown = 3;

                if (lotr.Buffs != null)
                    lotr.AddBuff(new Buff(caster.Skill2.Name, 0, 100, 2, 2, 2, lotr));

                else {
                    lotr.Buffs = new List<Buff>();
                    lotr.AddBuff(new Buff(caster.Skill2.Name, 0, 100, 2, 2, 2, lotr));
                }
                return new(" uses the CritAndDmgBuff skill on itself" + Environment.NewLine, 0);
              

            }
            else
            {
                return new(string.Empty, caster.Skill2.Cooldown);
            }
        };
    }
}
