using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HopelessLibary
{
    public class DeBuff
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Resistance { get; set; } = 0;
        public int CritChance { get; set; } = 0;
        public int MinDmg { get; set; } = 0;
        public int MaxDmg { get; set; } = 0;
        public int Uptime { get; set; } = 0;
        public Character Caster { get; set; }
        public DeBuff(string name, int resistance, int critChance, int minDmg, int maxDmg, int uptime, Character caster)
        {
            Name = name;
            Resistance = resistance;
            CritChance = critChance;
            MinDmg = minDmg;
            MaxDmg = maxDmg;
            Uptime = uptime;
            Caster = caster;
        }
        public DeBuff() { }
    }
}
