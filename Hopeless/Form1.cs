using HopelessLibary;
using Newtonsoft.Json;

namespace Hopeless
{
    public partial class Form1 : Form
    {
        private MenuUserControl menuUserControl;
        private PrzygotowanieUserControl fazaPrzygotowaniaUserControl;
        private WyprawaUserControl wyprawaUserControl;
        private List<Character> characters;
        public Form1()
        {
            InitializeComponent();

            // Inicjalizacja UserControl
            menuUserControl = new MenuUserControl();
            fazaPrzygotowaniaUserControl = new PrzygotowanieUserControl();
            wyprawaUserControl = new WyprawaUserControl();
            Controls.Add(menuUserControl);
            Controls.Add(fazaPrzygotowaniaUserControl);
            Controls.Add(wyprawaUserControl);

            // Inicjalizacja postaci
            Knight knight = new Knight("Lancelot",0,10,5,2,50,50,50,10,34,1,2,33,CharacterType.Knight);
            Rogue rogue = new Rogue("Astarion",0,2,10,5,35,35,30,50,70,1,2,33, CharacterType.Rogue);
            Cleric cleric = new Cleric("Melitele",0,2,5,10,45,45,40,30,30,1,2, CharacterType.Cleric);
            Joker joker = new Joker("Jaskier",0,2,7,8,30,30,30,50,50,1,2, CharacterType.Joker);
            characters = new List<Character> { knight,rogue,cleric,joker };
            

            // Inicjalizacja broni
            Weapon sword = new Weapon("Miecz Stalowy", "Opis Miecza", 5, 12,new List<CharacterType> {CharacterType.Knight});
            Weapon axe = new Weapon("Topor Bojowy", "Opis Topora", 8, 13, new List<CharacterType> { CharacterType.Knight });
            Weapon gun = new Weapon("Pistolet Skalkowy", "Opis Pistoletu", 5, 12, new List<CharacterType> { CharacterType.Rogue });
            
            // Inicjalizacja armora
            Armor armour = new Armor("Ciezka Zbroja", "Opis Zbroi",12, new List<CharacterType> { CharacterType.Knight });
            Armor lightweightarmour = new Armor("Lekka Zbroja", "Opis Zbroi", 5, new List<CharacterType> { CharacterType.Rogue, CharacterType.Cleric, CharacterType.Joker });

            List<IEkwipunek> ekwipunek = new List<IEkwipunek> { sword, gun, armour, axe, lightweightarmour };
            

          


            

            // Ustawienie pocz¹tkowej widocznoœci UserControl
            menuUserControl.Visible = true;
            fazaPrzygotowaniaUserControl.Visible = false;
            wyprawaUserControl.Visible = false;

           
            menuUserControl.NowaGraButtonClicked += (sender, args) =>
            {
                fazaPrzygotowaniaUserControl.Characters = characters;
                fazaPrzygotowaniaUserControl.Ekwipunek = ekwipunek;
                fazaPrzygotowaniaUserControl.Visible = true;
                menuUserControl.Visible = false;
            };

            menuUserControl.KontynuujGreButtonClicked += (sender, args) =>
            {

                loadGame();
                fazaPrzygotowaniaUserControl.Visible = true;
                menuUserControl.Visible = false;
            };


            fazaPrzygotowaniaUserControl.WyruszButtonClicked += (sender, args) =>
            {
                fazaPrzygotowaniaUserControl.Visible = false;
                wyprawaUserControl.Visible = true;
            };
        }

        public void loadGame()
        {
            string jsonData = File.ReadAllText("game_state.json");


            GameState gameState = new GameState();
            List<Weapon> weapons = new List<Weapon>();
            List<Weapon> equippedWeapons = new List<Weapon>();
            List<Armor> armors = new List<Armor>();
            List<Armor> equippedArmors = new List<Armor>();
            List<IEkwipunek> equippedEkwipunek = new List<IEkwipunek>();
            List<Character> characters = new List<Character>();
            List<IEkwipunek> ekwipunek = new List<IEkwipunek>();

            gameState = JsonConvert.DeserializeObject<GameState>(jsonData);


            characters.Add(gameState.knight);
            characters.Add(gameState.rogue);
            characters.Add(gameState.cleric);
            characters.Add(gameState.joker);
            equippedEkwipunek.AddRange(gameState.equippedWeapons);
            equippedEkwipunek.AddRange(gameState.equippedArmors);
            ekwipunek.AddRange(gameState.weapons);
            ekwipunek.AddRange(gameState.armors);

            fazaPrzygotowaniaUserControl.Characters = characters;
            fazaPrzygotowaniaUserControl.Ekwipunek = ekwipunek;
            fazaPrzygotowaniaUserControl.equipedItems = equippedEkwipunek;
        }

    }
}