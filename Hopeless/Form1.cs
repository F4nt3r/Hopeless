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
            wyprawaUserControl.eventFirst += fazaPrzygotowaniaUserControl.AfterExpedition;
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
            Weapon gilded_mace = new Weapon("Z³oty Buzdygan", "Midas to jednak zna sie na robocie", 7, 15, new List<CharacterType> { CharacterType.Cleric, CharacterType.Knight });
            Weapon scarlet_flail = new Weapon("Szkarlatny Cep", "Chodz, pomacam Cie moim cepikiem", 6, 11, new List<CharacterType> { CharacterType.Rogue });
            Weapon dagger = new Weapon("Sztylet", "Maly, ale wariat", 5, 9, new List<CharacterType> { CharacterType.Rogue, CharacterType.Joker });
            Weapon spearofdestiny = new Weapon("Wlocznia Przeznaczenia", "Podobno zdolna zabijac Bogow", 9, 15, new List<CharacterType> { CharacterType.Knight, CharacterType.Cleric });
            Weapon crossbow = new Weapon("Kusza", "Opis", 4, 7, new List<CharacterType> { CharacterType.Rogue, CharacterType.Joker });
            Weapon heavy_crossbow = new Weapon("Ciezka Kusza", "Opis", 7, 10, new List<CharacterType> { CharacterType.Rogue, CharacterType.Joker });
            Weapon ulumulu = new Weapon("Ulu-Mulu", "Orkowy Znak Przyjazni", 9, 15, new List<CharacterType> { CharacterType.Knight });

            // Inicjalizacja armora
            Armor paladinarmor = new Armor("Pancerz Paladyna", "Niegdys zbroja magicznych wojownikow", 11, new List<CharacterType> { CharacterType.Cleric, CharacterType.Knight });
            Armor mercenaryarmor = new Armor("Pancerz Najemnika", "Pospolity pancerz najemnych zbirow", 6, new List<CharacterType> { CharacterType.Cleric, CharacterType.Knight, CharacterType.Rogue, CharacterType.Joker });
            Armor lightweightarmour = new Armor("Lekka Zbroja", "Nie wiem czy wogole mo¿na to nazwaæ zbroj¹", 4, new List<CharacterType> { CharacterType.Rogue, CharacterType.Cleric, CharacterType.Joker });
            Armor mediumweightarmour = new Armor("Œredni Pancerz", "Handlarz p³aka³ jak oddawa³", 7, new List<CharacterType> { CharacterType.Cleric });
            Armor armour = new Armor("Ciezka Zbroja", "W takiej to juz tylko na Jerozolime", 12, new List<CharacterType> { CharacterType.Knight });
            Armor leatherarmor = new Armor("Skorzana Zbroja", "Zrobiona z pierwszorzêdnej skóry Cieniostworów", 7, new List<CharacterType> { CharacterType.Cleric, CharacterType.Joker, CharacterType.Rogue });
            Armor durableovercoat = new Armor("Wytrzymaly Plaszcz", "Zapewni podstawow¹ ochrone. Ale nieprzeciêtny wygl¹d", 6, new List<CharacterType> { CharacterType.Rogue });
            Armor bronzedchestplate = new Armor("Napiersnik z Brazu", "A¿ mo¿na poczuæ sie jak Rzymianin", 9, new List<CharacterType> { CharacterType.Rogue, CharacterType.Knight });
            List<IEkwipunek> pulaEkwipunku = new List<IEkwipunek> { crossbow, mercenaryarmor, paladinarmor, heavy_crossbow, ulumulu, sword, gun, durableovercoat, bronzedchestplate, leatherarmor, armour, axe, lightweightarmour, mediumweightarmour, greatsword , glaive , metal_cudge , sharpened_sickle , gilded_mace , scarlet_flail , dagger , spearofdestiny ,};

            List<IEkwipunek> ekwipunek = new List<IEkwipunek> { new Weapon(sword), new Weapon(gun), new Armor(armour), new Weapon(axe), new Armor(lightweightarmour), new Armor(lightweightarmour) };
            wyborWyprawyUserControl.pulaEkwipunku = pulaEkwipunku;

            // Inicjalizacja Potworów

            Monster rat = new Monster("Szczur",20,20,20,10,10,20,2,4,33,DifficultyType.Easy);        
            Monster webber = new Monster("Pajak",20,15,15,10,10,30,2,4,30,DifficultyType.Easy);  
            Monster webberSpitter = new Monster("Pajak Trujacy",25,25,25,15,10,35,5,7,35, DifficultyType.Easy);         
            Monster brigandTrainee = new Monster("Poczatkujacy Bandyta", 25, 20, 20, 15, 10, 10, 3, 5, 15, DifficultyType.Easy);
            Monster brigand = new Monster("Bandyta", 30, 25, 25, 20, 15, 15, 6, 9, 15, DifficultyType.Easy);
            Monster floutist = new Monster("Flecista",30,30,30,25,20,19,5,10,20, DifficultyType.Easy);
            Monster goblin = new Monster("Goblin", 20, 25, 25, 10, 15, 25, 3, 6, 30, DifficultyType.Easy);
            Monster scierwojad = new Monster("Scierwojad", 15, 15, 15, 10, 10, 10, 2, 3, 25, DifficultyType.Easy);
            Monster kretoszczur = new Monster("Kretoszczur", 20, 20, 20, 10, 10, 20, 2, 4, 33, DifficultyType.Medium);
            Monster gargoyle = new Monster("Gargulec", 45, 40, 40, 15, 15, 10, 7, 10, 25, DifficultyType.Medium);
            Monster boneSoldier = new Monster("Szkielet Wojownik", 45, 30, 30, 10, 15, 15, 5, 11, 10, DifficultyType.Medium);
            Monster boneArbalest = new Monster("Szkielet Kusznik", 40, 25, 25, 10, 20, 15, 6, 9, 10, DifficultyType.Medium);
            Monster ghoul = new Monster("Ghoul", 45, 35, 35, 25, 15, 10, 8, 12, 20, DifficultyType.Medium);
            Monster rattler = new Monster("Grzechotnik", 40, 30, 30, 10, 25, 40, 5, 9, 45, DifficultyType.Medium);
            Monster pelzacz = new Monster("Pelzacz", 45, 35, 35, 15, 15, 10, 7, 10, 15, DifficultyType.Medium);
            Monster giant = new Monster("Gigant", 75, 55, 55, 30, 20, 10, 12, 16, 5, DifficultyType.Hard);
            Monster golem = new Monster("Golem", 75, 50, 50, 40, 15, 10, 10, 13, 5, DifficultyType.Hard);
            Monster dragon = new Monster("Smok", 80, 60, 60, 20, 15, 20, 11, 16, 20, DifficultyType.Hard);
            Monster darkKnight = new Monster("Mroczny Rycerz", 75, 55, 55, 15, 15, 15, 9, 14, 10, DifficultyType.Hard);
            Monster sleeper = new Monster("Œni¹cy",100,200,200,50,15,50,15,22,15, DifficultyType.Boss);

            
            List<Monster> monsters = new List<Monster> { sleeper,gargoyle, boneSoldier, boneArbalest, rattler, pelzacz, golem, darkKnight, dragon, giant, ghoul, rat, webber, webberSpitter, brigandTrainee, brigand, floutist, kretoszczur };
            wyborWyprawyUserControl.monsters = monsters;
            // Inicjalizacja Wypraw

            Expedition expedition1 = new Expedition("Kana³y Pary¿a","Ale¿ tu œmierdzi... Serem?",50,DifficultyType.Easy,new List<Monster> { new Monster(rat), new Monster(rat), new Monster(rat), new Monster(rat) },100,new List<Weapon> { greatsword },new List<Armor> { mediumweightarmour });
            Expedition expedition2 = new Expedition("Opuszczony Magazyn", "Ponoæ kiedys sk³adowali tu Jabole", 50, DifficultyType.Easy, new List<Monster> { new Monster(rat), new Monster(rat), new Monster(webber), new Monster(webber) }, 100, new List<Weapon> { greatsword }, new List<Armor> { mediumweightarmour });
            Expedition expedition3 = new Expedition("Flecista z Hameln", "Wiesz gdzie mo¿esz sobie wsadziæ ten flet...?", 50, DifficultyType.Easy, new List<Monster> { new Monster(rat), new Monster(rat), new Monster(rat), new Monster(floutist) }, 100, new List<Weapon> { greatsword }, new List<Armor> { mediumweightarmour });
            Expedition expedition4 = new Expedition("Puszcza Kampinoska", "Wielki Ciemny Las, w ktorym roi sie od pajeczyn", 50, DifficultyType.Easy, new List<Monster> { new Monster(webber),new Monster(webber), new Monster(webberSpitter), new Monster(webberSpitter) }, 100, new List<Weapon> { glaive }, new List<Armor> {  });
            Expedition expedition5 = new Expedition("Oboz na Bagnach", "Nielegalna plantacja bagiennego ziela", 50, DifficultyType.Easy, new List<Monster> { new Monster(brigandTrainee), new Monster(brigandTrainee), new Monster(brigandTrainee), new Monster(brigand) }, 100, new List<Weapon> { dagger }, new List<Armor> { leatherarmor });
            List<Expedition> expeditons = new List<Expedition> { expedition1, expedition2, expedition3, expedition4, expedition5 };

            // Ustawienie pocz¹tkowej widocznoœci UserControl
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