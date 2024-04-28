using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace HopelessLibary
{
    public class Weapon : IEkwipunek
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public int MinDmg { get; set; }
        public int MaxDmg { get; set; }

        public List<CharacterType> AllowedCharacters { get; set; }

        public Weapon(string name, string description, int minDmg, int maxDmg, List<CharacterType> allowedCharacters)
        {
            Name = name;
            Description = description;
            MinDmg = minDmg;
            MaxDmg = maxDmg;
            AllowedCharacters = allowedCharacters;
        }
        public Weapon(Weapon weapon)
        {
            Name = weapon.Name;
            Description = weapon.Description;
            MinDmg = weapon.MinDmg;
            MaxDmg = weapon.MaxDmg;
            AllowedCharacters = weapon.AllowedCharacters;
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
                throw new ClassWeaponException("Ta postac nie moze uzywac tej broni.");
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
