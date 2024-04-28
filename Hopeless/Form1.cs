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

            wyprawaUserControl.eventFirst += wyborWyprawyUserControl.AfterExpedition;
          
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
            Weapon gilded_mace = new Weapon("Z�oty Buzdygan", "Midas to jednak zna sie na robocie", 7, 15, new List<CharacterType> { CharacterType.Cleric, CharacterType.Knight });
            Weapon scarlet_flail = new Weapon("Szkarlatny Cep", "Chodz, pomacam Cie moim cepikiem", 6, 11, new List<CharacterType> { CharacterType.Rogue });
            Weapon dagger = new Weapon("Sztylet", "Maly, ale wariat", 5, 9, new List<CharacterType> { CharacterType.Rogue, CharacterType.Joker });
            Weapon spearofdestiny = new Weapon("Wlocznia Przeznaczenia", "Podobno zdolna zabijac Bogow", 9, 15, new List<CharacterType> { CharacterType.Knight, CharacterType.Cleric });


            // Inicjalizacja armora
            
            Armor lightweightarmour = new Armor("Lekka Zbroja", "Nie wiem czy wogole mo�na to nazwa� zbroj�", 4, new List<CharacterType> { CharacterType.Rogue, CharacterType.Cleric, CharacterType.Joker });
            Armor mediumweightarmour = new Armor("�redni Pancerz", "Handlarz p�aka� jak oddawa�", 7, new List<CharacterType> { CharacterType.Cleric });
            Armor armour = new Armor("Ciezka Zbroja", "W takiej to juz tylko na Jerozolime", 12, new List<CharacterType> { CharacterType.Knight });
            Armor leatherarmor = new Armor("Skorzana Zbroja", "Zrobiona z pierwszorz�dnej sk�ry Cieniostwor�w", 7, new List<CharacterType> { CharacterType.Cleric, CharacterType.Joker, CharacterType.Rogue });
            Armor durableovercoat = new Armor("Wytrzymaly Plaszcz", "Zapewni podstawow� ochrone. Ale nieprzeci�tny wygl�d", 6, new List<CharacterType> { CharacterType.Rogue });
            Armor bronzedchestplate = new Armor("Napiersnik z Brazu", "A� mo�na poczu� sie jak Rzymianin", 9, new List<CharacterType> { CharacterType.Rogue, CharacterType.Knight });
            List<IEkwipunek> pulaEkwipunku = new List<IEkwipunek> { sword, gun, durableovercoat, bronzedchestplate, leatherarmor, armour, axe, lightweightarmour, mediumweightarmour, greatsword , glaive , metal_cudge , sharpened_sickle , gilded_mace , scarlet_flail , dagger , spearofdestiny ,};

            List<IEkwipunek> ekwipunek = new List<IEkwipunek> { sword, gun, armour, axe, lightweightarmour};
            wyborWyprawyUserControl.pulaEkwipunku = pulaEkwipunku;

            // Inicjalizacja Potwor�w

            Monster rat1 = new Monster("Szczur",20,20,20,10,10,20,2,4,33,DifficultyType.Easy);
            Monster rat2 = new Monster("Szczur", 20, 20, 20, 10, 10, 20, 2, 4, 33, DifficultyType.Easy);
            Monster rat3 = new Monster("Szczur", 20, 20, 20, 10, 10, 20, 2, 4, 33, DifficultyType.Easy);
            Monster rat4 = new Monster("Wielki Szczur",30,30,30,15,15,19,3,6,20, DifficultyType.Easy);
            Monster webber1 = new Monster("Pajak",20,15,15,10,10,30,2,4,30,DifficultyType.Easy);
            Monster webber2 = new Monster("Pajak", 20, 15, 15, 10, 10, 30, 2, 4, 30, DifficultyType.Easy);
            Monster webberSpitter1 = new Monster("Pajak Trujacy",25,25,25,15,10,35,5,7,35, DifficultyType.Easy);
            Monster webberSpitter2 = new Monster("Pajak Trujacy", 25, 25, 25, 15, 10, 35, 5, 7, 35, DifficultyType.Easy);
            Monster brigandTrainee1 = new Monster("Poczatkujacy Bandyta", 25, 20, 20, 15, 10, 10, 3, 5, 15, DifficultyType.Easy);
            Monster brigandTrainee2 = new Monster("Poczatkujacy Bandyta", 25, 20, 20, 15, 10, 10, 3, 5, 15, DifficultyType.Easy);
            Monster brigandTrainee3 = new Monster("Poczatkujacy Bandyta", 25, 20, 20, 15, 10, 10, 3, 5, 15, DifficultyType.Easy);
            Monster brigand1 = new Monster("Bandyta", 30, 25, 25, 20, 15, 15, 6, 9, 15, DifficultyType.Easy);
            Monster floutist1 = new Monster("Flecista",30,30,30,25,20,19,5,10,20, DifficultyType.Easy);

            Monster kretoszczur1 = new Monster("Kretoszczur", 20, 20, 20, 10, 10, 20, 2, 4, 33, DifficultyType.Medium);
            Monster kretoszczur2 = new Monster("Kretoszczur", 20, 20, 20, 10, 10, 20, 2, 4, 33, DifficultyType.Medium);
            Monster kretoszczur3 = new Monster("Kretoszczur", 20, 20, 20, 10, 10, 20, 2, 4, 33, DifficultyType.Medium);
            Monster kretoszczur4 = new Monster("Kretoszczur", 30, 30, 30, 15, 15, 19, 3, 6, 20, DifficultyType.Medium);
            List<Monster> monsters = new List<Monster> { rat1, rat2, rat3, rat4, webber1, webber2, webberSpitter1, webberSpitter2, brigandTrainee1, brigandTrainee2, brigandTrainee3, brigand1, floutist1, kretoszczur1, kretoszczur2, kretoszczur3, kretoszczur4 };
            wyborWyprawyUserControl.monsters = monsters;
            // Inicjalizacja Wypraw

            Expedition expedition1 = new Expedition("Kana�y Pary�a","Ale� tu �mierdzi... Serem?",50,DifficultyType.Easy,new List<Monster> { rat1,rat2,rat3,rat4 },100,new List<Weapon> { greatsword },new List<Armor> { mediumweightarmour });
            Expedition expedition2 = new Expedition("Opuszczony Magazyn", "Pono� kiedys sk�adowali tu Jabole", 50, DifficultyType.Easy, new List<Monster> { rat1, rat2, webber1, webber2 }, 100, new List<Weapon> { greatsword }, new List<Armor> { mediumweightarmour });
            Expedition expedition3 = new Expedition("Flecista z Hameln", "Wiesz gdzie mo�esz sobie wsadzi� ten flet...?", 50, DifficultyType.Easy, new List<Monster> { rat1, rat2, rat3, floutist1 }, 100, new List<Weapon> { greatsword }, new List<Armor> { mediumweightarmour });
            Expedition expedition4 = new Expedition("Puszcza Kampinoska", "Wielki Ciemny Las, w ktorym roi sie od pajeczyn", 50, DifficultyType.Easy, new List<Monster> { webber1, webber2, webberSpitter1, webberSpitter2 }, 100, new List<Weapon> { glaive }, new List<Armor> {  });
            Expedition expedition5 = new Expedition("Oboz na Bagnach", "Nielegalna plantacja bagiennego ziela", 50, DifficultyType.Easy, new List<Monster> { brigandTrainee1, brigandTrainee2, brigandTrainee3, brigand1 }, 100, new List<Weapon> { dagger }, new List<Armor> { leatherarmor });
            List<Expedition> expeditons = new List<Expedition> { expedition1, expedition2, expedition3, expedition4, expedition5 };

            // Ustawienie pocz�tkowej widoczno�ci UserControl
            menuUserControl.Visible = true;
            fazaPrzygotowaniaUserControl.Visible = false;
            wyprawaUserControl.Visible = false;
            wyborWyprawyUserControl.Visible = false;

            menuUserControl.NowaGraButtonClicked += (sender, args) =>
            {
                fazaPrzygotowaniaUserControl.Characters = characters;
                fazaPrzygotowaniaUserControl.Ekwipunek = ekwipunek;
                wyborWyprawyUserControl.expeditions = expeditons;
                
                
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

                fazaPrzygotowaniaUserControl.Expeditons = wyborWyprawyUserControl.expeditions;
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

                wyprawaUserControl.expedition = wyborWyprawyUserControl.selectedExpedition;
                wyprawaUserControl.Visible = true;
                
            };
            wyprawaUserControl.FinishButtonClicked += (sender, args) =>
            {
                wyprawaUserControl.Visible = false;
                fazaPrzygotowaniaUserControl.Visible = true;
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
            List<Expedition> expeditons = new List<Expedition>();

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
            wyborWyprawyUserControl.expeditions = expeditons;
        }

    }
}