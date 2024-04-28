using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HopelessLibary
{
    public class GameState
    {
        public Knight knight {  get; set; }
        public Cleric cleric { get; set; }
        public Joker joker { get; set; }    
        public Rogue rogue { get; set; }    
        public List<Weapon> weapons { get; set; }
        public List<Weapon> equippedWeapons { get; set; }
        public List<Armor> armors { get; set; }
        public List<Armor> equippedArmors { get; set; }
        public List<Expedition> expeditions { get; set; }
        // Dodaj inne pola, jeśli potrzebujesz
    }
}
