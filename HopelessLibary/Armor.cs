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
    public class Armor : IInventory
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public int DmgReduction { get; set; }
        public double Price { get; set; }
        public double SalesPrice { get; set; }
        public Rarity Rarity { get; set; }

        public List<CharacterType> AllowedCharacters { get; set; }
        public Armor () { }
        [JsonConstructor]
        public Armor(string name, string description, int dmgReduction,double price, List<CharacterType> allowedCharacters, Rarity rarity)
        {
            Name = name;
            Description = description;
            DmgReduction = dmgReduction;
            Price = price;
            SalesPrice = (int)(price * 0.20);
            AllowedCharacters = allowedCharacters;
            Rarity = rarity;
        }
        
        public Armor(Armor armor) 
        {
            Name = armor.Name;
            Description = armor.Description;
            DmgReduction = armor.DmgReduction;
            Price = armor.Price;
            SalesPrice = armor.SalesPrice;
            AllowedCharacters = armor.AllowedCharacters;
            Rarity = armor.Rarity;
        }

        public string Display()
        {
            return this.Name;
        }
       
        public void Equip(Character target)
        {
            if (!AllowedCharacters.Contains(target.CharacterType))
            {
                throw new ClassArmorException("This character cannot use this armor.");
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
