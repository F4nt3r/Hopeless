using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace HopelessLibary
{
    public class Weapon : IInventory
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public int MinDmg { get; set; }
        public int MaxDmg { get; set; }
        public double Price { get; set; }
        public double SalesPrice { get; set; }

        public List<CharacterType> AllowedCharacters { get; set; }
        public Rarity Rarity { get; set; }

        public Weapon() { }
        [JsonConstructor]
        public Weapon(string name, string description, int minDmg, int maxDmg, double price, List<CharacterType> allowedCharacters,Rarity rarity)
        {
            Name = name;
            Description = description;
            MinDmg = minDmg;
            MaxDmg = maxDmg;
            Price = price;
            SalesPrice = (int)(price * 0.20);
            AllowedCharacters = allowedCharacters;
            Rarity = rarity;
        }
        
        public Weapon(Weapon weapon)
        {
            Name = weapon.Name;
            Description = weapon.Description;
            MinDmg = weapon.MinDmg;
            MaxDmg = weapon.MaxDmg;
            Price = weapon.Price;
            SalesPrice = weapon.SalesPrice;
            AllowedCharacters = weapon.AllowedCharacters;
            Rarity = weapon.Rarity;
        }

        public string Display()
        {
            return this.Name;
        }

       
        public void Equip(Character target)
        {
            if (!AllowedCharacters.Contains(target.CharacterType))
            {
                throw new ClassWeaponException("This character cannot use this weapon.");
            }
            target.Weapon = this;
        }




        [Serializable]
        public class ClassWeaponException : Exception
        {
            public ClassWeaponException() { }
            public ClassWeaponException(string message) : base(message) { }
            public ClassWeaponException(string message, Exception inner) : base(message, inner) { }
            protected ClassWeaponException(
              System.Runtime.Serialization.SerializationInfo info,
              System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
        }

    }
}
