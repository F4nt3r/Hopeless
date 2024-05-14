using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace HopelessLibary
{

    public interface IInventory
    {
        string Name { get; set; }
        string Display();
        void Equip(Character target);
        List<CharacterType> AllowedCharacters { get; set; }

    }
}
