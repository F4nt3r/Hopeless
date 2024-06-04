using HopelessLibary.Helpers;
using HopelessLibary.Intefrace;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace HopelessLibary
{
    public class Monster: ICreature
    {
        public string Name { get; set; }
        public int ExperienceGains { get; set; }
        public int CurrentHP { get; set; }
        public int MaxHP { get; set; }
        public int Resistance { get; set; }
        public int CritChance { get; set; }
        public int Initiative { get; set; }
        public int MinDmg { get; set; }
        public int MaxDmg { get; set; }
        public int DodgeChance { get; set; }
        public DifficultyType Type { get; set; }
        public List<Buff> Buffs { get ; set; }
        public List<DeBuff> DeBuffs { get; set ; }



        public CharacterType CharacterType { get ; set; }

        public Skill? Skill1 { get; } = null;

        public Skill? Skill2 { get;  } = null;
        public Point Location { get; set; }

        public Monster() { }
        [JsonConstructor]
        public Monster(string name, int experienceGains,  int currentHP, int maxHP, int resistance, int critChance, int initiative, int minDmg, int maxDmg, int dodgeChance, DifficultyType type)
        {
            Name = name;
            ExperienceGains = experienceGains;

            CurrentHP = currentHP;
            MaxHP = maxHP;
            Resistance = resistance;
            CritChance = critChance;
            Initiative = initiative;
            MinDmg = minDmg;
            MaxDmg = maxDmg;
            DodgeChance = dodgeChance;
            Type = type;
            CharacterType = CharacterType.Monster;
        }
        public Monster(Monster monster){
            Name = monster.Name;
            ExperienceGains = monster.ExperienceGains;
            CurrentHP = monster.CurrentHP;
            MaxHP = monster.MaxHP;
            Resistance = monster.Resistance;
            CritChance = monster.CritChance;
            Initiative = monster.Initiative;
            MinDmg = monster.MinDmg;
            MaxDmg = monster.MaxDmg;
            DodgeChance = monster.DodgeChance;
            Type = monster.Type;
            CharacterType = CharacterType.Monster;
        }
        public void BasicAttack<T>(T target,out int dmg) where T : ICreature
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

        public void TakeDamage(int damage)
        {
            double finalDmg;
            if (new Random().Next(1, 101) > DodgeChance)
            {
                finalDmg = damage * ((100-(double)Resistance) / 100);
                finalDmg = Math.Round(finalDmg);
                if ((int)finalDmg < CurrentHP)
                    CurrentHP -= (int)finalDmg;
                else
                {
                    CurrentHP = 0;
                    SoundEffectHelper.PlayDeathSound();
                }
            }
            else
            {

            }
        }
        public void AddBuff(Buff buff)
        {
            if (buff == null)
                return;

            if (Buffs == null)
                Buffs = new();

            Buffs.Add(buff);

            this.Resistance += buff.Resistance;
            this.CritChance += buff.CritChance;
            this.MinDmg += buff.MinDmg;
            this.MaxDmg += buff.MaxDmg;

        }
        public void AddDeBuff(DeBuff debuff)
        {
            if (debuff == null)
                return;

            if (DeBuffs == null)
                DeBuffs = new();

            DeBuffs.Add(debuff);

            this.Resistance -= debuff.Resistance;
            this.CritChance -= debuff.CritChance;
            this.MinDmg -= debuff.MinDmg;
            this.MaxDmg -= debuff.MaxDmg;

        }
        public bool IsDead()
        {
            return CurrentHP <= 0;
        }

        public override string? ToString()
        {
            return Name;
        }

        public void CheckBuffsAndDebuffsAndRemoveIfNeeded()
        {

            if (Buffs != null)
            {

                for (int i = Buffs.Count; i > 0; i--)
                {
                    Buffs[i - 1].Uptime -= 1;
                    if (Buffs[i - 1].Uptime > 0) continue;

                    this.Resistance -= Buffs[i - 1].Resistance;
                    this.CritChance -= Buffs[i - 1].CritChance;
                    this.MinDmg -= Buffs[i - 1].MinDmg;
                    this.MaxDmg -= Buffs[i - 1].MaxDmg;
                    this.Resistance -= Buffs[i - 1].Resistance;
                    Buffs.RemoveAt(i - 1);

                }
            }

            if (DeBuffs != null)
            {
                for (int i = DeBuffs.Count; i > 0; i--)
                {
                    DeBuffs[i - 1].Uptime -= 1;
                    if (DeBuffs[i - 1].Uptime > 0) continue;

                    this.Resistance -= DeBuffs[i - 1].Resistance;
                    this.CritChance -= DeBuffs[i - 1].CritChance;
                    this.MinDmg -= DeBuffs[i - 1].MinDmg;
                    this.MaxDmg -= DeBuffs[i - 1].MaxDmg;
                    this.Resistance -= DeBuffs[i - 1].Resistance;
                    DeBuffs.RemoveAt(i - 1);

                }
            }

        }

        public void ClearEffetsAfterBattle()
        {
            if (Buffs != null)
            {

                for (int i = Buffs.Count; i > 0; i--)
                {


                    this.Resistance -= Buffs[i - 1].Resistance;
                    this.CritChance -= Buffs[i - 1].CritChance;
                    this.MinDmg -= Buffs[i - 1].MinDmg;
                    this.MaxDmg -= Buffs[i - 1].MaxDmg;
                    this.Resistance -= Buffs[i - 1].Resistance;
                    Buffs.RemoveAt(i - 1);

                }
            }

            if (DeBuffs != null)
            {
                for (int i = DeBuffs.Count; i > 0; i--)
                {


                    this.Resistance -= DeBuffs[i - 1].Resistance;
                    this.CritChance -= DeBuffs[i - 1].CritChance;
                    this.MinDmg -= DeBuffs[i - 1].MinDmg;
                    this.MaxDmg -= DeBuffs[i - 1].MaxDmg;
                    this.Resistance -= DeBuffs[i - 1].Resistance;
                    DeBuffs.RemoveAt(i - 1);

                }
            }
        }

        public void CheckSkillsCd()
        {
            if (Skill1 != null && Skill1.Cooldown != 0)
                Skill1.Cooldown -= 1;
            if (Skill2 != null && Skill2.Cooldown != 0)
                Skill2.Cooldown -= 1;
        }
    }
}
