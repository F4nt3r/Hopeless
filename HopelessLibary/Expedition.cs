using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HopelessLibary
{
    public class Expedition
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public int ExperienceGains { get; set; }
        public DifficultyType Type { get; set; }
        public List<Monster> Monsters { get; set; }
        public int Gold { get; set; }
        public List<Weapon> WeaponRewards { get; set; }
        public List<Armor> ArmorRewards { get; set; }

        public Expedition(string name, string description, int experienceGains, DifficultyType type, List<Monster> monsters, int gold, List<Weapon> weaponRewards, List<Armor> armorRewards)
        {
            Name = name;
            Description = description;
            ExperienceGains = experienceGains;
            Type = type;
            Monsters = monsters;
            Gold = gold;
            WeaponRewards = weaponRewards;
            ArmorRewards = armorRewards;
        }
    }
}
