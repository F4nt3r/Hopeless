using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HopelessLibary
{
    public class GameState
    {
        public List<Character> Chararacters { get; set; }
        public List<IInventory> Inventory {  get; set; }
        public List<IInventory> Equiped { get; set; }
        public List<IInventory> Shop { get; set; }
      
        public List<Expedition> Expeditions { get; set; }
        public int Gold { get; set; }
        public bool EventQuest {  get; set; }
        public bool EventResult {  get; set; }
        // Dodaj inne pola, jeśli potrzebujesz
    }
}
