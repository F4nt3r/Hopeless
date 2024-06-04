using HopelessLibary.Intefrace;
using System.Drawing;

namespace HopelessLibary
{
    [Serializable] public abstract class Character: ICreature
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Level { get; set; }
        public int ExperiencePoints { get; set; }
        public int Strength { get; set; }
        public int Dexterity { get; set; }
        public int Intelligence { get; set; }
        public int CurrentHP { get; set; }
        public int MaxHP { get; set; }
        public int Resistance { get; set; }
        public int BaseResistance { get; set; }
        public int CritChance { get; set; }
        public int Initiative { get; set; }
        public int MinDmg { get; set; }
        public int MaxDmg { get; set; }


        public Weapon Weapon { get; set; }
        public Armor Armor { get; set; }
        public List<Buff> Buffs { get; set; }
        public List<DeBuff> DeBuffs { get; set; }
        public abstract Skill? Skill1 { get; }
        public abstract Skill? Skill2 { get; }
 
        public CharacterType CharacterType { get; set ; }
        public Point Location { get; set; }
        

        public Character(int id,string name, int experiencePoints, int strength, int dexterity, int intelligence, int currentHP, int maxHP, int resistance, int baseResistance, int critChance, int initiative,int minDmg,int maxDmg, CharacterType type)
        {
            Id = id;
            Name = name;
            Level = 1;
            ExperiencePoints = experiencePoints;
            Strength = strength;
            Dexterity = dexterity;
            Intelligence = intelligence;
            CurrentHP = currentHP;
            MaxHP = maxHP;
            Resistance = resistance;
            BaseResistance = baseResistance;
            CritChance = critChance;
            Initiative = initiative;
            MinDmg = minDmg;
            MaxDmg = maxDmg;
            CharacterType = type;
            Weapon = null;
            Armor = null;
        }

        public abstract void BasicAttack<T>(T target,out int dmg) where T : ICreature;

        public abstract void TakeDamage(int damage);

        public bool IsDead()
        {
            return CurrentHP <= 0;
        }

        public abstract void LevelUp();
        
        public void GainExperience(int exp)
        {
            ExperiencePoints += exp;
            while (ExperiencePoints >= Level * 100)
            {
                LevelUp();
                ExperiencePoints -= (Level-1) * 100;
            }
        }

        public void UpdateStats()
        {
            
            if(Weapon != null)
            {
                MinDmg = 1 + Weapon.MinDmg;
                MaxDmg = 2 + Weapon.MaxDmg;
            }
            else
            {
                MinDmg = 1;
                MaxDmg = 2;
            }

            if (Armor != null)
            {
                Resistance = BaseResistance + Armor.DmgReduction;
            }
            else
            {
                Resistance = BaseResistance;
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
        public void CheckSkillsCd()
        {
            if(Skill1 != null && Skill1.Cooldown != 0)
                    Skill1.Cooldown -= 1;
            if (Skill2 != null && Skill2.Cooldown != 0)
                    Skill2.Cooldown -= 1;
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
            
            if(DeBuffs != null)
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
            
            if(DeBuffs != null)
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
    }
}
