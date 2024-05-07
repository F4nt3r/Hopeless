using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HopelessLibary
{
    public class GameState
    {
        public List<Character> chararacters { get; set; }
        public List<IEkwipunek> Ekwipunek {  get; set; }
        public List<IEkwipunek> Equiped { get; set; }
        public List<IEkwipunek> Shop { get; set; }
      
        public List<Expedition> expeditions { get; set; }
        public int gold { get; set; }
        public bool eventQuest {  get; set; }
        public bool eventResult {  get; set; }
        // Dodaj inne pola, jeśli potrzebujesz
    }
}
