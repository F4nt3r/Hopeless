using HopelessLibary.Intefrace;

namespace HopelessLibary
{
    [Serializable] public abstract class Character: ICreature
    {
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

        public CharacterType Type { get; set; }
        public Weapon Weapon { get; set; }
        public Armor Armor { get; set; }


        public Character(string name, int experiencePoints, int strength, int dexterity, int intelligence, int currentHP, int maxHP, int resistance, int baseResistance, int critChance, int initiative,int minDmg,int maxDmg, CharacterType type)
        {
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
            Type = type;
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

    }
}
