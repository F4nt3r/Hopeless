using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HopelessLibary
{
    public class Armor
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public int DmgReduction { get; set; }
        public List<Character> Character { get; set; }

        public Armor(string name, string description, int dmgReduction, List<Character> character)
        {
            Name = name;
            Description = description;
            DmgReduction = dmgReduction;
            Character = character;
        }
    }
}
