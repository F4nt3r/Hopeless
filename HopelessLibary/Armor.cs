using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Xml.Linq;
using static HopelessLibary.Weapon;

namespace HopelessLibary
{
    public class Armor : IEkwipunek
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public int DmgReduction { get; set; }
        public Rarity Rarity { get; set; }

        public List<CharacterType> AllowedCharacters { get; set; }
        public Armor () { }
        [JsonConstructor]
        public Armor(string name, string description, int dmgReduction, List<CharacterType> allowedCharacters, Rarity rarity)
        {
            Name = name;
            Description = description;
            DmgReduction = dmgReduction;
            AllowedCharacters = allowedCharacters;
            Rarity = rarity;
        }
        
        public Armor(Armor armor) 
        {
            Name = armor.Name;
            Description = armor.Description;
            DmgReduction = armor.DmgReduction;
            AllowedCharacters = armor.AllowedCharacters;
            Rarity = armor.Rarity;
        }

        public string Wypisz()
        {
            return this.Name;
        }
        public override string? ToString()
        {
            return Name;
        }
        public void Equip(Character target)
        {
            if (!AllowedCharacters.Contains(target.Type))
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
