using HopelessLibary;
using Newtonsoft.Json;

namespace Hopeless
{
    public partial class Form1 : Form
    {
        private MenuUserControl menuUserControl;
        private PrzygotowanieUserControl fazaPrzygotowaniaUserControl;
        private WyprawaUserControl wyprawaUserControl;
        private WyborWyprawyUserControl wyborWyprawyUserControl;
        private List<Character> characters;
        public Form1()
        {
            InitializeComponent();

            // Inicjalizacja UserControl
            menuUserControl = new MenuUserControl();
            fazaPrzygotowaniaUserControl = new PrzygotowanieUserControl();
            wyprawaUserControl = new WyprawaUserControl();
            wyborWyprawyUserControl= new WyborWyprawyUserControl();
            Controls.Add(menuUserControl);
            Controls.Add(fazaPrzygotowaniaUserControl);
            Controls.Add(wyprawaUserControl);
            Controls.Add(wyborWyprawyUserControl);

            wyprawaUserControl.eventFirst += wyborWyprawyUserControl.AfterWin;
            wyprawaUserControl.eventFirst += wyborWyprawyUserControl.AfterLose;
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
            Weapon greatsword = new Weapon("Wielki Miecz Stalowy", "Opis Miecza", 7, 15, new List<CharacterType> { CharacterType.Knight });
            Weapon glaive = new Weapon("Glewia", "Prosta Bron Drzewcowa", 3, 9, new List<CharacterType> { CharacterType.Knight, CharacterType.Cleric });
            Weapon metal_cudge = new Weapon("Metalowa Palka", "Piekna w swojej prostocie", 2, 6, new List<CharacterType> { CharacterType.Joker, CharacterType.Cleric });
            Weapon sharpened_sickle = new Weapon("Zaostrzony Sierp", "Brakuje tylko mlota do zestawu", 4, 8, new List<CharacterType> { CharacterType.Joker});
            Weapon gilded_mace = new Weapon("Pozlacany Buzdygan", "Opis Buzdyganu", 7, 15, new List<CharacterType> { CharacterType.Cleric, CharacterType.Knight });
            Weapon scarlet_flail = new Weapon("Szkarlatny Cep", "Chodz, pomacam Cie moim cepikiem", 6, 11, new List<CharacterType> { CharacterType.Rogue });
            Weapon dagger = new Weapon("Sztylet", "Maly, ale wariat", 5, 9, new List<CharacterType> { CharacterType.Rogue, CharacterType.Joker });
            Weapon spearofdestiny = new Weapon("Wlocznia Przeznaczenia", "Podobno zdolna zabijac Bogow", 9, 15, new List<CharacterType> { CharacterType.Knight, CharacterType.Cleric });


            // Inicjalizacja armora
            
            Armor lightweightarmour = new Armor("Lekka Zbroja", "Opis Zbroi", 5, new List<CharacterType> { CharacterType.Rogue, CharacterType.Cleric, CharacterType.Joker });
            Armor mediumweightarmour = new Armor("Srednia Zbroja", "Opis Zbroi", 7, new List<CharacterType> { CharacterType.Cleric });
            Armor armour = new Armor("Ciezka Zbroja", "Opis Zbroi", 12, new List<CharacterType> { CharacterType.Knight });
            Armor leatherarmor = new Armor("Skorzana Zbroja", "Opis Zbroi", 7, new List<CharacterType> { CharacterType.Cleric, CharacterType.Joker, CharacterType.Rogue });
            Armor durableovercoat = new Armor("Wytrzymaly Plaszcz", "Opis Plaszcza", 6, new List<CharacterType> { CharacterType.Rogue });
            Armor bronzedchestplate = new Armor("Napiersnik z Brazu", "Opis zbroi", 9, new List<CharacterType> { CharacterType.Rogue, CharacterType.Knight });

            List<IEkwipunek> ekwipunek = new List<IEkwipunek> { sword, gun, armour, axe, lightweightarmour};


            // Inicjalizacja Potworów

            Monster rat1 = new Monster("Szczur",20,20,20,10,10,20,2,4,33,DifficultyType.Easy);
            Monster rat2 = new Monster("Szczur", 20, 20, 20, 10, 10, 20, 2, 4, 33, DifficultyType.Easy);
            Monster rat3 = new Monster("Szczur", 20, 20, 20, 10, 10, 20, 2, 4, 33, DifficultyType.Easy);
            Monster rat4 = new Monster("Szczur", 20, 20, 20, 10, 10, 20, 2, 4, 33, DifficultyType.Easy);
            Monster webber1 = new Monster("Pajak",20,15,15,10,10,30,2,4,30,DifficultyType.Easy);
            Monster webber2 = new Monster("Pajak", 20, 15, 15, 10, 10, 30, 2, 4, 30, DifficultyType.Easy);
            Monster webberSpitter1 = new Monster("Pajak Trujacy",25,25,25,15,10,35,5,7,35, DifficultyType.Easy);
            Monster webberSpitter2 = new Monster("Pajak Trujacy", 25, 25, 25, 15, 10, 35, 5, 7, 35, DifficultyType.Easy);
            Monster brigandTrainee1 = new Monster("Poczatkujacy Bandyta", 25, 20, 20, 15, 10, 10, 3, 5, 15, DifficultyType.Easy);
            Monster brigandTrainee2 = new Monster("Poczatkujacy Bandyta", 25, 20, 20, 15, 10, 10, 3, 5, 15, DifficultyType.Easy);
            Monster brigandTrainee3 = new Monster("Poczatkujacy Bandyta", 25, 20, 20, 15, 10, 10, 3, 5, 15, DifficultyType.Easy);
            Monster brigand1 = new Monster("Bandyta", 30, 25, 25, 20, 15, 15, 6, 9, 15, DifficultyType.Easy);

            // Inicjalizacja Wypraw

            Expediton expedition1 = new Expediton("Kana³y Pary¿a","Ale¿ tu œmierdzi... Serem?",50,DifficultyType.Easy,new List<Monster> { rat1,rat2,rat3,rat4 },100,new List<Weapon> { greatsword },new List<Armor> { mediumweightarmour });
            Expediton expedition2 = new Expediton("Kana³y UWS", "Wydostaj¹ siê przez ¿eñsk¹ toalete", 50, DifficultyType.Easy, new List<Monster> { rat1, rat2, rat3, rat4 }, 100, new List<Weapon> { greatsword }, new List<Armor> { mediumweightarmour });
            Expediton expedition3 = new Expediton("Kana³y Warszawy", "Ale¿ tu œmierdzi... Aco tu robi DUDU", 50, DifficultyType.Easy, new List<Monster> { rat1, rat2, rat3, rat4 }, 100, new List<Weapon> { greatsword }, new List<Armor> { mediumweightarmour });
            Expediton expedition4 = new Expediton("Puszcza Kampinoska", "Wielki Ciemny Las, w ktorym roi sie od pajeczyn", 50, DifficultyType.Easy, new List<Monster> { webber1, webber2, webberSpitter1, webberSpitter2 }, 100, new List<Weapon> { glaive }, new List<Armor> {  });
            Expediton expedition5 = new Expediton("Oboz na Bagnach", "Nielegalna plantacja bagiennego ziela", 50, DifficultyType.Easy, new List<Monster> { brigandTrainee1, brigandTrainee2, brigandTrainee3, brigand1 }, 100, new List<Weapon> { dagger }, new List<Armor> { leatherarmor });
            List<Expediton> expeditons = new List<Expediton> { expedition1, expedition2, expedition3, expedition4, expedition5 };

            // Ustawienie pocz¹tkowej widocznoœci UserControl
            menuUserControl.Visible = true;
            fazaPrzygotowaniaUserControl.Visible = false;
            wyprawaUserControl.Visible = false;
            wyborWyprawyUserControl.Visible = false;

            menuUserControl.NowaGraButtonClicked += (sender, args) =>
            {
                fazaPrzygotowaniaUserControl.Characters = characters;
                fazaPrzygotowaniaUserControl.Ekwipunek = ekwipunek;
                wyborWyprawyUserControl.Expeditions = expeditons;
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

                fazaPrzygotowaniaUserControl.Expeditons = wyborWyprawyUserControl.Expeditions;
                fazaPrzygotowaniaUserControl.Visible = false;
                wyborWyprawyUserControl.Visible = true;


                wyprawaUserControl.Characters = fazaPrzygotowaniaUserControl.Characters;


            };
            wyborWyprawyUserControl.powrotButtonClicked += (sender, args) =>
            {
                fazaPrzygotowaniaUserControl.Visible = true;
                wyborWyprawyUserControl.Visible = false;
            };
            wyborWyprawyUserControl.ExpeditionMouseClicked += (sender, args) =>
            {
                wyborWyprawyUserControl.Visible = false;

                wyprawaUserControl.Expedition = wyborWyprawyUserControl.SelectedExpedition;
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
            List<Expediton> expeditons = new List<Expediton>();

            gameState = JsonConvert.DeserializeObject<GameState>(jsonData);


            characters.Add(gameState.knight);
            characters.Add(gameState.rogue);
            characters.Add(gameState.cleric);
            characters.Add(gameState.joker);
            equippedEkwipunek.AddRange(gameState.equippedWeapons);
            equippedEkwipunek.AddRange(gameState.equippedArmors);
            ekwipunek.AddRange(gameState.weapons);
            ekwipunek.AddRange(gameState.armors);
            expeditons.AddRange(gameState.expeditions);

            fazaPrzygotowaniaUserControl.Characters = characters;
            fazaPrzygotowaniaUserControl.Ekwipunek = ekwipunek;
            fazaPrzygotowaniaUserControl.equipedItems = equippedEkwipunek;
            wyborWyprawyUserControl.Expeditions = expeditons;
        }

    }
}