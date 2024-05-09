using HopelessLibary.Enums;
using HopelessLibary.Helpers;
using HopelessLibary.Intefrace;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HopelessLibary
{
    [Serializable]
    public class Joker : Character
    {
        private string SKILL_1_DESCRIPTION => "Błogosławisz wszystkich sojusznikow zwiększając ich DMG" + Environment.NewLine + "Cooldown: 5 tury" + Environment.NewLine + "Czas Trwania: 3 tury";
        private string SKILL_2_DESCRIPTION => "Przeklinasz wszystkich wrogów zmniejszajac ich Odporność" + Environment.NewLine + "Cooldown: 5 tury" + Environment.NewLine + "Czas Trwania: 3 tury";

        public int DoubleAtackChance { get; set; }

        private Skill skill1;
        public override Skill? Skill1
        {
            get
            {
                if (skill1 == null)
                    skill1 = new("AoeBuff", 0, TargetType.Ally, SkillType.AoE, handlerAoeBuff, SKILL_1_DESCRIPTION);

                return skill1;
            }
        }


        private Skill skill2;
        public override Skill? Skill2
        {
            get
            {
                if (skill2 == null)
                    skill2 = new("AoeDeBuff", 0, TargetType.Enemy, SkillType.AoE, handlerAoeDeBuff, SKILL_2_DESCRIPTION);

                return skill2;
            }
        }

        public Joker(int id, string name, int experiencePoints, int strength, int dexterity, int intelligence, int currentHP, int maxHP, int resistance, int baseResistance, int critChance, int initiative, int minDmg, int maxDmg, int doubleAtackChance, CharacterType type) : base(id, name, experiencePoints, strength, dexterity, intelligence, currentHP, maxHP, resistance, baseResistance, critChance, initiative, minDmg, maxDmg,type)
        {
            DoubleAtackChance = doubleAtackChance;
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

        public override void LevelUp()
        {
            Level++;
            MaxHP += 1;
            DoubleAtackChance += 1;

        }

        public override void TakeDamage(int damage)
        {

                double finalDmg = damage * ((100 - (double)Resistance) / 100);
                finalDmg = Math.Round(finalDmg);

                if((int)finalDmg<CurrentHP)
                CurrentHP -= (int)finalDmg;
            else
            {
                CurrentHP = 0;
                SoundEffectHelper.PlayDeathSound();
            }

        }

     

        private SkillHandlerEvent handlerAoeBuff = (caster, creatures) =>
        {
            if (caster.Skill1 == null)
                return null;

            Joker? joker = caster as Joker;
            if (joker == null)
                return null;

            if (caster.Skill1.Cooldown == 0)
            {
                SoundEffectHelper.PlayAoeBuffSound();

                caster.Skill1.Cooldown = 5;
                foreach (var item in creatures)
                {
                    if (item.CharacterType == CharacterType.Monster) continue;

                    if (item.Buffs != null)
                        item.AddBuff(new Buff(caster.Skill1.Name, 0, 10, 3, 3, 2, joker));

                    else
                    {
                        item.Buffs = new List<Buff>();
                        item.AddBuff(new Buff(caster.Skill1.Name, 0, 10, 3, 3, 2, joker));
                    }
                }
                return new(" używa umiejętności AoeBuff na sojuszników" + Environment.NewLine, 0);

            }
            else
            {
                return new(string.Empty, caster.Skill1.Cooldown);
            }

        };

        private SkillHandlerEvent handlerAoeDeBuff = (caster, creatures) =>
        {
            if (caster.Skill2 == null)
                return null;

            Joker? joker = caster as Joker;
            if (joker == null)
                return null;

            if (caster.Skill2.Cooldown == 0)
            {
                SoundEffectHelper.PlayAoeDeBuffSound();

                caster.Skill2.Cooldown = 5;
                foreach (var item in creatures)
                {
                    if (item.CharacterType != CharacterType.Monster) continue;

                    if (item.DeBuffs != null)
                        item.AddDeBuff(new DeBuff(caster.Skill2.Name, 10, 0, 0, 0, 2, joker));

                    else
                    {
                        item.DeBuffs = new List<DeBuff>();
                        item.AddDeBuff(new DeBuff(caster.Skill2.Name, 10, 0, 0, 0, 2, joker));
                    }
                }
                return new(" używa umiejętności AoeDeBuff na przeciwnikow" + Environment.NewLine, 0);

            }
            else
            {
                return new(string.Empty, caster.Skill2.Cooldown);
            }

        };
    }
}
