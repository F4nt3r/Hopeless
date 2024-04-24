using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static HopelessLibary.Weapon;

namespace HopelessLibary
{
    public class Armor : IEkwipunek
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

        public string Wypisz()
        {
            return this.Name;
        }

        public void Equip(Character target)
        {
            if (!Character.Contains(target))
            {
                throw new ClassArmorException("Ta postac nie moze uzywac tego armora.");
            }
            target.Armor = this;
        }




        [Serializable]
        public class ClassArmorException : Exception
        {
            public ClassArmorException() { }
            public ClassArmorException(string message) : base(message) { }
            public ClassArmorException(string message, Exception inner) : base(message, inner) { }
            protected ClassArmorException(
              System.Runtime.Serialization.SerializationInfo info,
              System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
        }


    }
}
