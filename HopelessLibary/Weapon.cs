using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HopelessLibary
{
    public class Weapon
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public int MinDmg { get; set; }
        public int MaxDmg { get; set; }
        public List<Character> Character { get; set; }

        public Weapon(string name, string description, int minDmg, int maxDmg, List<Character> character)
        {
            Name = name;
            Description = description;
            MinDmg = minDmg;
            MaxDmg = maxDmg;
            Character = character;
        }
    }
}
