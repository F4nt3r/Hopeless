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
    public class Cleric : Character

    {
        private string SKILL_1_DESCRIPTION => "Leczysz wybranego sojusznika mocą Swiatła, istnieje szansa że Cleric wyleczy również siebie" + Environment.NewLine + "Cooldown: 5 tury" + Environment.NewLine + "heal: " + Intelligence + "-" + (Intelligence + 5);
        private string SKILL_2_DESCRIPTION => "Leczysz wszystkich sojuszników mocą Swiatła" + Environment.NewLine + "Cooldown: 5 tury" + Environment.NewLine + "heal: " + Intelligence + "-" + (Intelligence + 2);


        public int BlessingChance { get; set; }
        private Skill skill1;
        public override Skill? Skill1
        {
            get
            {
                if (skill1 == null)
                    skill1 = new("Heal", 0, TargetType.Ally, SkillType.Single, handlerHeal, SKILL_1_DESCRIPTION);

                return skill1;
            }
        }


        private Skill skill2;
        public override Skill? Skill2
        {
            get
            {
                if (skill2 == null)
                    skill2 = new("AoeHeal", 0, TargetType.Ally, SkillType.AoE, handlerAoeHeal, SKILL_2_DESCRIPTION);

                return skill2;
            }
        }

        public Cleric(int id, string name, int experiencePoints, int strength, int dexterity, int intelligence, int currentHP, int maxHP, int resistance, int baseResistance, int critChance, int initiative, int minDmg, int maxDmg, int blessingChance, CharacterType type) : base(id, name, experiencePoints, strength, dexterity, intelligence, currentHP, maxHP, resistance, baseResistance, critChance, initiative, minDmg, maxDmg, type)
        {
            BlessingChance = blessingChance;
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
            MaxHP += 2;
            Intelligence += 2;
        }

        public override void TakeDamage(int damage)
        {
            double finalDmg = damage * ((100 - (double)Resistance) / 100);
            finalDmg = Math.Round(finalDmg);
            if ((int)finalDmg < CurrentHP)
                CurrentHP -= (int)finalDmg;
            else
            {
                CurrentHP = 0;
                SoundEffectHelper.PlayDeathSound();
            }
        }

        private SkillHandlerEvent handlerHeal = (caster, creatures) =>
        {
            if (caster.Skill1 == null)
                return null;

            Cleric? cleric = caster as Cleric;
            if (cleric == null)
                return null;
           
            if (caster.Skill1.Cooldown == 0)
            {
                SoundEffectHelper.PlayHealSound();
                int heal = 0;
                caster.Skill1.Cooldown = 5;
                
                foreach (var item in creatures)
                {
                    if (item.CharacterType == CharacterType.Monster) continue;
                    if (new Random().Next(1, 100) > cleric.CritChance)
                    {

                        heal = new Random().Next(cleric.Intelligence, cleric.Intelligence + 6);
                    }
                    else
                    {
                        heal = new Random().Next(cleric.Intelligence, cleric.Intelligence + 6) * 2;
                    }

                    if (new Random().Next(1, 100) > cleric.BlessingChance)
                    {
                        if (heal < item.MaxHP - item.CurrentHP)
                            item.CurrentHP += heal;
                        else
                            item.CurrentHP = item.MaxHP;
                    }
                    else
                    {

                            if (heal < item.MaxHP - item.CurrentHP)
                            item.CurrentHP += heal;
                            else
                            item.CurrentHP = item.MaxHP;

                            if (heal < cleric.MaxHP - cleric.CurrentHP)
                            cleric.CurrentHP += heal;
                            else
                            cleric.CurrentHP = cleric.MaxHP;
                        
                    }

                }
                return new("  używa umiejętności Heal na lecząc za " + heal + " punktów zdrowia" + Environment.NewLine, 0);

            }
            else
            {
                return new(string.Empty, caster.Skill1.Cooldown);
            }

        };

        private SkillHandlerEvent handlerAoeHeal = (caster, creatures) =>
        {
            if (caster.Skill2 == null)
                return null;

            Cleric? cleric = caster as Cleric;
            if (cleric == null)
                return null;

            if (caster.Skill2.Cooldown == 0)
            {
                SoundEffectHelper.PlayHealSound();

                caster.Skill2.Cooldown = 5;
                int heal = 0;
                foreach (var item in creatures)
                {
                    if (item.CharacterType == CharacterType.Monster) continue;
                    if (new Random().Next(1, 100) > cleric.CritChance)
                    {
                        heal = new Random().Next(cleric.Intelligence, cleric.Intelligence + 3);

                    }
                    else
                    {
                        heal = new Random().Next(cleric.Intelligence, cleric.Intelligence + 3) * 2;
                    }
                    
                        if (!item.IsDead())
                        {
                            if (heal < item.MaxHP - item.CurrentHP)
                                item.CurrentHP += heal;
                            else
                                item.CurrentHP = item.MaxHP;
                        }
                    


                }
                return new(" używa umiejętności AoeHeal na sojuszników lecząc za " + heal + " punktów zdrowia" + Environment.NewLine, 0);

            }
            else
            {
                return new(string.Empty, caster.Skill2.Cooldown);
            }

        };
    }
}
