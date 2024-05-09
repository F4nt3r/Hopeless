using HopelessLibary;
using Newtonsoft.Json;
using System.DirectoryServices.ActiveDirectory;
using System.Media;
using System.Reflection;

namespace Hopeless
{
    public partial class Form1 : Form
    {
        private MenuUserControl menuUserControl;
        private KreatorUserControl kreatorUserControl;
        private PrzygotowanieUserControl fazaPrzygotowaniaUserControl;
        private WyprawaUserControl wyprawaUserControl;
        private WyborWyprawyUserControl wyborWyprawyUserControl;
        private List<Character> characters;
        public Form1()
        {
            InitializeComponent();

            // Inicjalizacja UserControl
            menuUserControl = new MenuUserControl();
            kreatorUserControl = new KreatorUserControl();
            fazaPrzygotowaniaUserControl = new PrzygotowanieUserControl();
            wyprawaUserControl = new WyprawaUserControl();
            wyborWyprawyUserControl= new WyborWyprawyUserControl();
            Controls.Add(menuUserControl);
            Controls.Add(kreatorUserControl);
            Controls.Add(fazaPrzygotowaniaUserControl);
            Controls.Add(wyprawaUserControl);
            Controls.Add(wyborWyprawyUserControl);


            wyprawaUserControl.eventFirst += wyborWyprawyUserControl.AfterExpedition;
            wyprawaUserControl.eventFirst += fazaPrzygotowaniaUserControl.AfterExpedition;
            // Inicjalizacja postaci
            Knight knight = new Knight(1,"Knight",0,10,5,2,50,50,50,50,10,34,1,2,33,CharacterType.Knight);
            Rogue rogue = new Rogue(2,"Rogue",0,2,10,5,35,35,30,30,50,70,1,2,33, CharacterType.Rogue);
            Cleric cleric = new Cleric(3,"Cleric",0,2,5,10,45,45,40,40,30,30,1,2,15, CharacterType.Cleric);
            Joker joker = new Joker(4,"Joker",0,2,7,8,30,30,30,30,50,50,1,2,20, CharacterType.Joker);
            characters = new List<Character> { knight,rogue,cleric,joker };
            

            // Inicjalizacja broni

            Weapon sword = new Weapon("Miecz Stalowy", "Zwyczajny stalowy miecz", 2, 6,20,new List<CharacterType> {CharacterType.Knight},Rarity.Common);
            Weapon axe = new Weapon("Topor Bojowy", "Opis Topora", 3, 6,20, new List<CharacterType> { CharacterType.Joker }, Rarity.Common);
            Weapon gun = new Weapon("Pistolet Skalkowy", "Opis Pistoletu", 3, 6,20, new List<CharacterType> { CharacterType.Rogue }, Rarity.Common);
            Weapon ritual_knife = new Weapon("Noz Rytualny", "Opis noza", 1, 4, 20, new List<CharacterType> { CharacterType.Cleric }, Rarity.Common);


            Weapon greatsword = new Weapon("Wielki Miecz Stalowy", "Opis Miecza", 5, 8,20, new List<CharacterType> { CharacterType.Knight }, Rarity.Rare);
            Weapon crossbow = new Weapon("Kusza", "Opis", 4, 7, 250, new List<CharacterType> { CharacterType.Rogue, CharacterType.Joker }, Rarity.Rare);
            Weapon glaive = new Weapon("Glewia", "Prosta Bron Drzewcowa", 3, 8,100, new List<CharacterType> { CharacterType.Knight, CharacterType.Cleric }, Rarity.Rare);
            Weapon metal_cudge = new Weapon("Metalowa Palka", "Piekna w swojej prostocie", 4, 8,100, new List<CharacterType> { CharacterType.Joker, CharacterType.Cleric }, Rarity.Rare);
            Weapon sharpened_sickle = new Weapon("Zaostrzony Sierp", "Brakuje tylko mlota do zestawu", 5, 8,100, new List<CharacterType> { CharacterType.Joker}, Rarity.Rare);
            Weapon gilded_mace = new Weapon("Z³oty Buzdygan", "Midas to jednak zna sie na robocie", 5, 10,100, new List<CharacterType> { CharacterType.Cleric, CharacterType.Knight }, Rarity.Rare);
            Weapon scarlet_flail = new Weapon("Szkarlatny Cep", "Chodz, pomacam Cie moim cepikiem", 4, 10,100, new List<CharacterType> { CharacterType.Rogue }, Rarity.Rare);
            Weapon dagger = new Weapon("Sztylet", "Maly, ale wariat", 2, 11,100, new List<CharacterType> { CharacterType.Rogue, CharacterType.Joker }, Rarity.Rare);

            Weapon musket = new Weapon("Muszkiet", "Kultowa bron wojny secesyjskiej", 8, 13, 250, new List<CharacterType> { CharacterType.Rogue, CharacterType.Cleric, CharacterType.Joker }, Rarity.Epic);
            Weapon spearofdestiny = new Weapon("Wlocznia Przeznaczenia", "Podobno zdolna zabijac Bogow", 9, 13,250, new List<CharacterType> { CharacterType.Knight, CharacterType.Cleric }, Rarity.Epic);
            Weapon heavy_crossbow = new Weapon("Ciezka Kusza", "Opis", 8, 12,250, new List<CharacterType> { CharacterType.Rogue, CharacterType.Joker }, Rarity.Epic);
            Weapon claw_of_beliar = new Weapon("Szpon Beliara", "Stworzony przez samego Beliara", 9, 14, 250, new List<CharacterType> { CharacterType.Knight }, Rarity.Epic);

            Weapon ulumulu = new Weapon("Ulu-Mulu", "Orkowy Znak Przyjazni", 14, 17,500, new List<CharacterType> { CharacterType.Knight }, Rarity.Legendary);
            Weapon hiddenblade = new Weapon("Ukryte Ostrze", "Cicha, szybka robota", 15, 18, 500, new List<CharacterType> { CharacterType.Rogue,CharacterType.Joker }, Rarity.Legendary);
            Weapon pieceofeden = new Weapon("Rajskie Jablko", "Stworzone przez tych co byli przed nami", 17, 19, 1000, new List<CharacterType> { CharacterType.Rogue, CharacterType.Joker, CharacterType.Knight, CharacterType.Cleric }, Rarity.Legendary);

            // Inicjalizacja armora


            Armor lightweightarmour = new Armor("Lekka Zbroja", "Nie wiem czy wogole mozna to nazwac zbroja", 2,20, new List<CharacterType> { CharacterType.Rogue, CharacterType.Cleric, CharacterType.Joker }, Rarity.Common);
            Armor mediumweightarmour = new Armor("Sredni Pancerz", "Handlarz plakal jak oddawal", 4,20, new List<CharacterType> { CharacterType.Cleric }, Rarity.Common);
            Armor armour = new Armor("Ciezka Zbroja", "W takiej to juz tylko na Jerozolime", 5,20, new List<CharacterType> { CharacterType.Knight }, Rarity.Common);

            Armor leatherarmor = new Armor("Skorzana Zbroja", "Zrobiona z pierwszorzêdnej skóry Cieniostworów", 6,150, new List<CharacterType> { CharacterType.Cleric, CharacterType.Joker, CharacterType.Rogue }, Rarity.Rare);
            Armor durableovercoat = new Armor("Wytrzymaly Plaszcz", "Zapewni podstawow¹ ochrone. Ale nieprzeciêtny wygl¹d", 7,150, new List<CharacterType> { CharacterType.Rogue }, Rarity.Rare);
            Armor bronzedchestplate = new Armor("Napiersnik z Brazu", "A¿ mo¿na poczuæ sie jak Rzymianin", 8,150, new List<CharacterType> { CharacterType.Cleric, CharacterType.Knight }, Rarity.Rare);

            Armor mercenaryarmor = new Armor("Pancerz Najemnika", "Pospolity pancerz najemnych zbirow", 9, 250, new List<CharacterType> { CharacterType.Cleric, CharacterType.Knight, CharacterType.Rogue, CharacterType.Joker }, Rarity.Epic);
            Armor temeriaarmor = new Armor("Pancerz Niebieskich Pasow", "Dla prawdziwych patriotow", 10, 250, new List<CharacterType> { CharacterType.Joker, CharacterType.Rogue}, Rarity.Epic);
            Armor magicorearmor = new Armor("Zbroja z Magicznej Rudy","Przesiaknieta Magia",12,250, new List<CharacterType> { CharacterType.Knight, CharacterType.Cleric}, Rarity.Epic);


            Armor paladinarmor = new Armor("Pancerz Paladyna", "Niegdys zbroja magicznych wojownikow", 16, 1000, new List<CharacterType> { CharacterType.Cleric, CharacterType.Knight }, Rarity.Legendary);
            Armor saskiaarmor = new Armor("Pancerz Saski", "Pancerz Smokobojczyni", 14, 1000, new List<CharacterType> { CharacterType.Cleric, CharacterType.Knight }, Rarity.Legendary);
            Armor zorro = new Armor("Stroj Zorro","Maskuje tak dobrze jak wyglada",12,1000, new List<CharacterType> { CharacterType.Rogue, CharacterType.Joker }, Rarity.Legendary);

            List<IEkwipunek> pulaEkwipunku = new List<IEkwipunek> { magicorearmor,zorro,claw_of_beliar,crossbow, mercenaryarmor, paladinarmor, heavy_crossbow, ulumulu, sword, gun, durableovercoat, bronzedchestplate, leatherarmor, armour, axe, lightweightarmour, mediumweightarmour, greatsword , glaive , metal_cudge , sharpened_sickle , gilded_mace , scarlet_flail , dagger , spearofdestiny , temeriaarmor , saskiaarmor, hiddenblade,
            musket, ritual_knife, pieceofeden};

            List<IEkwipunek> ekwipunek = new List<IEkwipunek> {};
            List<IEkwipunek> CommonIventory = new List<IEkwipunek> { new Weapon(sword),new Armor(armour), new Weapon(gun),new Armor(lightweightarmour), new Weapon(ritual_knife),new Armor(mediumweightarmour), new Weapon(axe),new Armor(lightweightarmour) };
            fazaPrzygotowaniaUserControl.pulaEkwipunku = pulaEkwipunku;
            wyborWyprawyUserControl.pulaEkwipunku = pulaEkwipunku;

            // Inicjalizacja Potworów

            Monster maggot = new Monster("Robal", 20,20,20,10,10,20,5,8,33,DifficultyType.Easy);        
            Monster webber = new Monster("Pajak",20,15,15,10,10,30,4,7,30,DifficultyType.Easy);  
            Monster webberSpitter = new Monster("Pajak_Trujacy",25,25,25,15,10,35,6,8,35, DifficultyType.Easy);         
            Monster brigandTrainee = new Monster("Poczatkujacy_Bandyta", 25, 20, 20, 15, 10, 10, 6, 9, 15, DifficultyType.Easy);
            Monster brigand = new Monster("Bandyta", 30, 25, 25, 20, 15, 15, 6, 9, 15, DifficultyType.Easy);
            Monster floutist = new Monster("Flecista",30,30,30,25,20,19,5,10,20, DifficultyType.Easy);
            Monster pijawka = new Monster("Pijawka", 20, 25, 25, 10, 15, 25, 5, 8, 30, DifficultyType.Easy);
            Monster voider = new Monster("Otchlaniec", 15, 15, 15, 10, 10, 10, 6, 10, 25, DifficultyType.Easy);
            Monster tentacles = new Monster("Macki_Otchlani", 15, 10, 10, 10, 10, 25, 6, 8, 30, DifficultyType.Easy);
            Monster wildDog = new Monster("Dziki_Pies", 10, 20, 20, 15, 15, 10, 5, 8, 10, DifficultyType.Easy);


            Monster boneShielder = new Monster("Szkielet_Tarczownik", 20, 30, 30, 10, 10, 20, 9, 13, 33, DifficultyType.Medium);
            Monster gargoyle = new Monster("Gargulec", 45, 40, 40, 15, 15, 10, 7, 13, 25, DifficultyType.Medium);
            Monster boneSoldier = new Monster("Szkielet_Wojownik", 45, 30, 30, 10, 15, 15, 9, 13, 10, DifficultyType.Medium);
            Monster boneArbalest = new Monster("Szkielet_Kusznik", 40, 25, 25, 10, 20, 15, 10, 12, 10, DifficultyType.Medium);
            Monster ghoul = new Monster("Ghoul", 45, 35, 35, 25, 15, 10, 10, 15, 20, DifficultyType.Medium);
            Monster rattler = new Monster("Grzechotnik", 40, 30, 30, 10, 25, 40, 10, 14, 45, DifficultyType.Medium);
            Monster pelzacz = new Monster("Pelzacz", 45, 35, 35, 15, 15, 10, 9, 13, 15, DifficultyType.Medium);
            Monster orkwarrior = new Monster("Ork_Wojownik", 40, 35, 35, 15, 20, 10, 11, 15, 20, DifficultyType.Medium);
            Monster pokutnik = new Monster("Pokutnik", 35, 40, 40, 15, 15, 15, 8, 16, 15, DifficultyType.Medium);
            Monster arachas = new Monster("Kultysta", 40, 55, 55, 35, 10, 10, 10, 17, 10, DifficultyType.Medium);

            Monster giant = new Monster("Gigant", 75, 55, 55, 30, 20, 10, 15, 20, 5, DifficultyType.Hard);

            Monster armata = new Monster("Armata", 75, 55, 55, 40, 15, 10, 16, 25, 5, DifficultyType.Hard);

            Monster ghost = new Monster("Widmo", 80, 50, 50, 20, 15, 20, 20, 26, 30, DifficultyType.Hard);

            Monster bigCrab = new Monster("Wielki_Krab", 75, 55, 55, 15, 15, 15, 20, 25, 10, DifficultyType.Hard);
            Monster Leszy = new Monster("Leszy", 70, 55, 55, 25, 15, 15, 19, 24, 10, DifficultyType.Hard);
            Monster vampire = new Monster("Wampir_Wyzszy", 50, 45, 45, 30, 10, 15, 22, 26, 20, DifficultyType.Hard);

            Monster sleeper = new Monster("Sniacy", 100,200,200,35,15,50,30,38,15, DifficultyType.Boss);
            Monster sleeperGuard = new Monster("Straznik_Sniacego",100,150,150,35,15,40,13,20,10,DifficultyType.Boss);
            Monster gaunter = new Monster("Gaunter_oDim", 100, 2, 2, 40, 20, 50, 25, 29, 15, DifficultyType.Event);
            Monster mirage = new Monster("Odbicie_Lustrzane",100,2,2,40,20,30,18,24,15, DifficultyType.Event);

            List<Monster> monsters = new List<Monster> { gaunter, mirage, sleeperGuard, arachas,vampire, wildDog, pokutnik, tentacles, orkwarrior, Leszy, sleeper, gargoyle, boneSoldier, boneArbalest, rattler, pelzacz, armata, bigCrab, ghost, giant, ghoul, maggot, webber, webberSpitter, brigandTrainee, brigand, floutist, boneShielder };
            wyborWyprawyUserControl.monsters = monsters;
            // Inicjalizacja Wypraw

            Expedition expedition1 = new Expedition("Kana³y Nowigradu", "Ale¿ tu œmierdzi... zw³okami??", 50,DifficultyType.Easy,new List<Monster> { new Monster(maggot), new Monster(maggot), new Monster(maggot), new Monster(maggot) },30,new List<Weapon> { greatsword },new List<Armor> { mediumweightarmour });
            Expedition expedition2 = new Expedition("Opuszczony Magazyn", "Ponoæ kiedys sk³adowali tu Jabole", 50, DifficultyType.Easy, new List<Monster> { new Monster(maggot), new Monster(maggot), new Monster(webber), new Monster(webber) }, 30, new List<Weapon> { greatsword }, new List<Armor> { mediumweightarmour });
            Expedition expedition3 = new Expedition("Flecista z Hameln", "Wiesz gdzie mo¿esz sobie wsadziæ ten flet...?", 50, DifficultyType.Easy, new List<Monster> { new Monster(maggot), new Monster(maggot), new Monster(maggot), new Monster(floutist) }, 30, new List<Weapon> { greatsword }, new List<Armor> { mediumweightarmour });
            Expedition expedition4 = new Expedition("Puszcza Kampinoska", "Wielki Ciemny Las, w ktorym roi sie od pajeczyn", 50, DifficultyType.Easy, new List<Monster> { new Monster(webber),new Monster(webber), new Monster(webberSpitter), new Monster(webberSpitter) }, 30, new List<Weapon> { glaive }, new List<Armor> {  });
            Expedition expedition5 = new Expedition("Oboz na Bagnach", "Nielegalna plantacja bagiennego ziela", 50, DifficultyType.Easy, new List<Monster> { new Monster(brigandTrainee), new Monster(brigandTrainee), new Monster(brigandTrainee), new Monster(brigand) }, 30, new List<Weapon> { dagger }, new List<Armor> { leatherarmor });
            List<Expedition> expeditons = new List<Expedition> { expedition1, expedition2, expedition3, expedition4, expedition5 };

            // Ustawienie pocz¹tkowej widocznoœci UserControl
            menuUserControl.Visible = true;
            kreatorUserControl.Visible = false;
            fazaPrzygotowaniaUserControl.Visible = false;
            wyprawaUserControl.Visible = false;
            wyborWyprawyUserControl.Visible = false;


            SoundPlayer backgroundMusicPlayer = new SoundPlayer(Properties.Resources.menuSong);
            SoundPlayer fightMusicPlayer = new SoundPlayer(Properties.Resources.normalFight);
            SoundPlayer bossFightMusicPlayer = new SoundPlayer(Properties.Resources.bossFight);
            SoundPlayer eventFightMusicPlayer = new SoundPlayer(Properties.Resources.eventSong);
            backgroundMusicPlayer.PlayLooping();

            menuUserControl.NowaGraButtonClicked += (sender, args) =>
            {
                //fazaPrzygotowaniaUserControl.Characters = characters;
                //fazaPrzygotowaniaUserControl.Ekwipunek = ekwipunek;
                //wyborWyprawyUserControl.expeditions = expeditons;
                //fazaPrzygotowaniaUserControl.gold = 100;
                //fazaPrzygotowaniaUserControl.Expeditons = wyborWyprawyUserControl.expeditions;

                //fazaPrzygotowaniaUserControl.GenerateShop();
                //fazaPrzygotowaniaUserControl.Visible = true;


                kreatorUserControl.Characters = characters;
                kreatorUserControl.CommonInventory = CommonIventory;
                kreatorUserControl.Visible = true;
                menuUserControl.Visible = false;
            };

            kreatorUserControl.RozpocznijButtonClicked += (sender, args) =>
            {
                ekwipunek = kreatorUserControl.StarterInventory.ToList();
                fazaPrzygotowaniaUserControl.Characters = kreatorUserControl.ChooseCharacters;
                fazaPrzygotowaniaUserControl.Ekwipunek = ekwipunek;
                wyborWyprawyUserControl.expeditions = expeditons;
                fazaPrzygotowaniaUserControl.gold = 100;
                fazaPrzygotowaniaUserControl.Expeditons = wyborWyprawyUserControl.expeditions;

                fazaPrzygotowaniaUserControl.GenerateShop();
                fazaPrzygotowaniaUserControl.Visible = true;
                kreatorUserControl.Visible = false;
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
                wyborWyprawyUserControl.Visible = true;


                wyprawaUserControl.characters = fazaPrzygotowaniaUserControl.Characters;


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

               


                backgroundMusicPlayer.Stop();
                if (wyprawaUserControl.expedition.Type == DifficultyType.Boss)
                    bossFightMusicPlayer.PlayLooping();
                else if (wyprawaUserControl.expedition.Type == DifficultyType.Event)
                {
                    eventFightMusicPlayer.PlayLooping();
                }
                else
                    fightMusicPlayer.PlayLooping();

               wyprawaUserControl.Visible = true;
                
            };
            wyborWyprawyUserControl.eventQuestExist += (sender, args) =>
            {
                fazaPrzygotowaniaUserControl.eventQuest = wyborWyprawyUserControl.eventQuest;
            };
            wyprawaUserControl.eventChoice += (sender, args) =>
            {
               wyborWyprawyUserControl.eventResult = true;
               fazaPrzygotowaniaUserControl.eventResult = true;
                wyprawaUserControl.eventResult = true;
            };
            wyprawaUserControl.FinishButtonClicked += (sender, args) =>
            {
                bossFightMusicPlayer.Stop();
                fightMusicPlayer.Stop();
                backgroundMusicPlayer.PlayLooping();
               wyprawaUserControl.Visible = false;
                fazaPrzygotowaniaUserControl.Visible = true;
            };


        }
        public void loadGame()
        {
            string jsonData = File.ReadAllText("game_state.json");


            List<IEkwipunek> equippedEkwipunek = new List<IEkwipunek>();
            List<IEkwipunek> shopItems = new List<IEkwipunek>();
            List<Character> characters = new List<Character>();
            List<IEkwipunek> ekwipunek = new List<IEkwipunek>();
            List<Expedition> expeditons = new List<Expedition>();

            GameState gameState = JsonConvert.DeserializeObject<GameState>(jsonData, new JsonSerializerSettings
            {
                TypeNameHandling = TypeNameHandling.Auto
            });


            characters.AddRange(gameState.chararacters);
            equippedEkwipunek.AddRange(gameState.Equiped);
            ekwipunek.AddRange(gameState.Ekwipunek);           
            expeditons.AddRange(gameState.expeditions);
            shopItems.AddRange(gameState.Shop);
  

            fazaPrzygotowaniaUserControl.eventQuest=gameState.eventQuest;
            fazaPrzygotowaniaUserControl.eventResult = gameState.eventResult;
            wyborWyprawyUserControl.eventQuest=gameState.eventQuest;
            wyborWyprawyUserControl.eventResult = gameState.eventResult;
            wyprawaUserControl.eventResult=gameState.eventResult;
            fazaPrzygotowaniaUserControl.Expeditons = expeditons;
            fazaPrzygotowaniaUserControl.Characters = characters;
            fazaPrzygotowaniaUserControl.Ekwipunek = ekwipunek;
            fazaPrzygotowaniaUserControl.equipedItems = equippedEkwipunek;
            wyborWyprawyUserControl.expeditions = expeditons;
            fazaPrzygotowaniaUserControl.gold = gameState.gold;
            fazaPrzygotowaniaUserControl.shopItems = shopItems;
        }
      
    }
}