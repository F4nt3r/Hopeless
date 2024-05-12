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
        private TeamCreatorUserControl TeamCreatorUserControl;
        private PreparationUserControl preparationsUserControl;
        private ExpeditionUserControl expeditionUserControl;
        private ExpeditionChoiceUserControl expeditionChoiceUserControl;
        private List<Character> characters;
        public Form1()
        {
            InitializeComponent();

            // Inicjalizacja UserControl
            menuUserControl = new MenuUserControl();
            TeamCreatorUserControl = new TeamCreatorUserControl();
            preparationsUserControl = new PreparationUserControl();
            expeditionUserControl = new ExpeditionUserControl();
            expeditionChoiceUserControl= new ExpeditionChoiceUserControl();
            Controls.Add(menuUserControl);
            Controls.Add(TeamCreatorUserControl);
            Controls.Add(preparationsUserControl);
            Controls.Add(expeditionUserControl);
            Controls.Add(expeditionChoiceUserControl);


            expeditionUserControl.EventFirst += expeditionChoiceUserControl.AfterExpedition;
            expeditionUserControl.EventFirst += preparationsUserControl.AfterExpedition;
            // Inicjalizacja postaci
            Knight knight = new Knight(1, "Knight", 0, 10, 5, 2, 50, 50, 50, 50, 10, 34, 1, 2, 33, CharacterType.Knight);
            Rogue rogue = new Rogue(2, "Rogue", 0, 2, 10, 5, 35, 35, 30, 30, 50, 70, 1, 2, 33, CharacterType.Rogue);
            Cleric cleric = new Cleric(3, "Cleric", 0, 2, 5, 10, 45, 45, 40, 40, 30, 30, 1, 2, 20, CharacterType.Cleric);
            Joker joker = new Joker(4, "Joker", 0, 2, 7, 8, 30, 30, 30, 30, 50, 50, 1, 2, 20, CharacterType.Joker);
            characters = new List<Character> { knight, rogue, cleric, joker };

            // Inicjalizacja broni

            Weapon sword = new Weapon("Steel Sword", "Ordinary Steel Sword", 2, 6, 20, new List<CharacterType> { CharacterType.Knight }, Rarity.Common);
            Weapon axe = new Weapon("Battle Axe", "Axe Description", 3, 6, 20, new List<CharacterType> { CharacterType.Joker }, Rarity.Common);
            Weapon gun = new Weapon("Scale Gun", "Gun Description", 3, 6, 20, new List<CharacterType> { CharacterType.Rogue }, Rarity.Common);
            Weapon ritual_knife = new Weapon("Ritual Knife", "Knife Description", 1, 4, 20, new List<CharacterType> { CharacterType.Cleric }, Rarity.Common);

            Weapon greatsword = new Weapon("Great Steel Sword", "Sword Description", 5, 8, 20, new List<CharacterType> { CharacterType.Knight }, Rarity.Rare);
            Weapon crossbow = new Weapon("Crossbow", "Description", 4, 7, 250, new List<CharacterType> { CharacterType.Rogue, CharacterType.Joker }, Rarity.Rare);
            Weapon glaive = new Weapon("Glaive", "Simple Polearm", 3, 8, 100, new List<CharacterType> { CharacterType.Knight, CharacterType.Cleric }, Rarity.Rare);
            Weapon metal_cudge = new Weapon("Metal Stick", "Beautiful in its simplicity", 4, 8, 100, new List<CharacterType> { CharacterType.Joker, CharacterType.Cleric }, Rarity.Rare);
            Weapon sharpened_sickle = new Weapon("Sharpened Sickle", "The only thing missing is the hammer", 5, 8, 100, new List<CharacterType> { CharacterType.Joker }, Rarity.Rare);
            Weapon gilded_mace = new Weapon("Golden Mace", "Midas knows his job after all", 5, 10, 100, new List<CharacterType> { CharacterType.Cleric, CharacterType.Knight }, Rarity.Rare);
            Weapon scarlet_flail = new Weapon("Scarlet Flail", "Come, let me feel you with my flail", 4, 10, 100, new List<CharacterType> { CharacterType.Rogue }, Rarity.Rare);
            Weapon dagger = new Weapon("Dagger", "Small but crazy", 2, 11, 100, new List<CharacterType> { CharacterType.Rogue, CharacterType.Joker }, Rarity.Rare);

            Weapon musket = new Weapon("Musket", "Iconic Civil War Weapon", 8, 13, 250, new List<CharacterType> { CharacterType.Rogue, CharacterType.Cleric, CharacterType.Joker }, Rarity.Epic);
            Weapon spearofdestiny = new Weapon("Spear of Destiny", "Supposedly able to kill Gods", 9, 13, 250, new List<CharacterType> { CharacterType.Knight, CharacterType.Cleric }, Rarity.Epic);
            Weapon heavy_crossbow = new Weapon("Heavy Crossbow", "Description", 8, 12, 250, new List<CharacterType> { CharacterType.Rogue, CharacterType.Joker }, Rarity.Epic);
            Weapon claw_of_beliar = new Weapon("Claw of Beliar", "Created by Beliar himself", 9, 14, 250, new List<CharacterType> { CharacterType.Knight }, Rarity.Epic);

            Weapon ulumulu = new Weapon("Ulu-Mulu", "Orc Sign of Friendship", 14, 17, 500, new List<CharacterType> { CharacterType.Knight }, Rarity.Legendary);
            Weapon hiddenblade = new Weapon("Hidden Blade", "Silent, quick work", 15, 18, 500, new List<CharacterType> { CharacterType.Rogue, CharacterType.Joker }, Rarity.Legendary);
            Weapon pieceofeden = new Weapon("Paradise Apple", "Created by those who came before us", 17, 19, 1000, new List<CharacterType> { CharacterType.Rogue, CharacterType.Joker, CharacterType.Knight, CharacterType.Cleric }, Rarity.Legendary);
            // Inicjalizacja armora


            Armor lightweightarmour = new Armor("Light Armor", "I don't know if you can even call it armor", 2,20, new List<CharacterType> { CharacterType.Rogue, CharacterType.Cleric, CharacterType.Joker }, Rarity.Common);
            Armor mediumweightarmour = new Armor("Medium Armor", "The trader cried as he passed away", 4,20, new List<CharacterType> { CharacterType.Cleric }, Rarity.Common);
            Armor armour = new Armor("Heavy Armor", "Only in Jerusalem with this type of armor", 5,20, new List<CharacterType> { CharacterType.Knight }, Rarity.Common);

            Armor leatherarmor = new Armor("Leather Armor", "Made from premium Shadow Creature leather", 6, 150, new List<CharacterType> { CharacterType.Cleric, CharacterType.Joker, CharacterType.Rogue }, Rarity.Rare);
            Armor durableovercoat = new Armor("Durable Overcoat", "Provides basic protection. But looks extraordinary", 7, 150, new List<CharacterType> { CharacterType.Rogue }, Rarity.Rare);
            Armor bronzedchestplate = new Armor("Bronze breastplate", "You can feel like a Roman", 8, 150, new List<CharacterType> { CharacterType.Cleric, CharacterType.Knight }, Rarity.Rare);

            Armor mercenaryarmor = new Armor("Mercenary Armor", "Common Mercenary Thug Armor", 9, 250, new List<CharacterType> { CharacterType.Cleric, CharacterType.Knight, CharacterType.Rogue, CharacterType.Joker }, Rarity.Epic);
            Armor temeriaarmor = new Armor("Armor of the Blue Stripes", "For true patriots", 10, 250, new List<CharacterType> { CharacterType.Joker, CharacterType.Rogue }, Rarity.Epic);
            Armor magicorearmor = new Armor("Armor of Magic Ore", "Infiltrated Magic", 12, 250, new List<CharacterType> { CharacterType.Knight, CharacterType.Cleric }, Rarity.Epic);


            Armor paladinarmor = new Armor("Paladin Armor", "Once armor of magical warriors", 16, 1000, new List<CharacterType> { CharacterType.Cleric, CharacterType.Knight }, Rarity.Legendary);
            Armor saskiaarmor = new Armor("Saxon Armor", "Dragonwoman Armor", 14, 1000, new List<CharacterType> { CharacterType.Cleric, CharacterType.Knight }, Rarity.Legendary);
            Armor zorro = new Armor("Zorro Suit", "Conceals as good as it looks", 12, 1000, new List<CharacterType> { CharacterType.Rogue, CharacterType.Joker }, Rarity.Legendary);

            List<IInventory> pulaEkwipunku = new List<IInventory> { magicorearmor,zorro,claw_of_beliar,crossbow, mercenaryarmor, paladinarmor, heavy_crossbow, ulumulu, sword, gun, durableovercoat, bronzedchestplate, leatherarmor, armour, axe, lightweightarmour, mediumweightarmour, greatsword , glaive , metal_cudge , sharpened_sickle , gilded_mace , scarlet_flail , dagger , spearofdestiny , temeriaarmor , saskiaarmor, hiddenblade,
            musket, ritual_knife, pieceofeden};

            List<IInventory> ekwipunek = new List<IInventory> {};
            List<IInventory> CommonIventory = new List<IInventory> { new Weapon(sword),new Armor(armour), new Weapon(gun),new Armor(lightweightarmour), new Weapon(ritual_knife),new Armor(mediumweightarmour), new Weapon(axe),new Armor(lightweightarmour) };
            preparationsUserControl.shopItemsPool = pulaEkwipunku;
            expeditionChoiceUserControl.EquipmentPool = pulaEkwipunku;

            // Inicjalizacja Potworów
            Monster maggot = new Monster("Bug", 20, 20, 20, 10, 10, 20, 5, 8, 33, DifficultyType.Easy);
            Monster webber = new Monster("Spider", 20, 15, 15, 10, 10, 30, 4, 7, 30, DifficultyType.Easy);
            Monster webberSpitter = new Monster("Poisonous_Spider", 25, 25, 25, 15, 10, 35, 6, 8, 35, DifficultyType.Easy);
            Monster brigandTrainee = new Monster("Beginner_Bandy", 25, 20, 20, 15, 10, 10, 6, 9, 15, DifficultyType.Easy);
            Monster brigand = new Monster("Bandit", 30, 25, 25, 20, 15, 15, 6, 9, 15, DifficultyType.Easy);
            Monster floutist = new Monster("Fluutist", 30, 30, 30, 25, 20, 19, 5, 10, 20, DifficultyType.Easy);
            Monster leech = new Monster("Leech", 20, 25, 25, 10, 15, 25, 5, 8, 30, DifficultyType.Easy);
            Monster voider = new Monster("Abyss", 15, 15, 15, 10, 10, 10, 6, 10, 25, DifficultyType.Easy);
            Monster tentacles = new Monster("Void_Tentacles", 15, 10, 10, 10, 10, 25, 6, 8, 30, DifficultyType.Easy);
            Monster wildDog = new Monster("Wild_Dog", 10, 20, 20, 15, 15, 10, 5, 8, 10, DifficultyType.Easy);

            Monster boneShielder = new Monster("Skeleton_Shielder", 20, 30, 30, 10, 10, 20, 9, 13, 33, DifficultyType.Medium);
            Monster gargoyle = new Monster("Gargoyle", 45, 40, 40, 15, 15, 10, 7, 13, 25, DifficultyType.Medium);
            Monster boneSoldier = new Monster("Skeleton_Warrior", 45, 30, 30, 10, 15, 15, 9, 13, 10, DifficultyType.Medium);
            Monster boneArbalest = new Monster("Skeleton_Arbalest", 40, 25, 25, 10, 20, 15, 10, 12, 10, DifficultyType.Medium);
            Monster ghoul = new Monster("Ghoul", 45, 35, 35, 25, 15, 10, 10, 15, 20, DifficultyType.Medium);
            Monster rattler = new Monster("Rattlesnake", 40, 30, 30, 10, 25, 40, 10, 14, 45, DifficultyType.Medium);
            Monster creeper = new Monster("Creeper", 45, 35, 35, 15, 15, 10, 9, 13, 15, DifficultyType.Medium);
            Monster orkwarrior = new Monster("Orc_Warrior", 40, 35, 35, 15, 20, 10, 11, 15, 20, DifficultyType.Medium);
            Monster penitent = new Monster("Penitent", 35, 40, 40, 15, 15, 15, 8, 16, 15, DifficultyType.Medium);
            Monster arachas = new Monster("Cultist", 40, 55, 55, 35, 10, 10, 10, 17, 10, DifficultyType.Medium);

            Monster giant = new Monster("Giant", 75, 55, 55, 30, 20, 10, 15, 20, 5, DifficultyType.Hard);

            Monster cannon = new Monster("Cannon", 75, 55, 55, 40, 15, 10, 16, 25, 5, DifficultyType.Hard);

            Monster ghost = new Monster("Ghost", 80, 50, 50, 20, 15, 20, 20, 26, 30, DifficultyType.Hard);

            Monster bigCrab = new Monster("Big_Crab", 75, 55, 55, 15, 15, 15, 20, 25, 10, DifficultyType.Hard);
            Monster leszy = new Monster("Leshy", 70, 55, 55, 25, 15, 15, 19, 24, 10, DifficultyType.Hard);
            Monster vampire = new Monster("Higher_Vampire", 50, 45, 45, 30, 10, 15, 22, 26, 20, DifficultyType.Hard);

            Monster sleeper = new Monster("The_Sleeper", 100, 200, 200, 35, 15, 50, 30, 38, 15, DifficultyType.Boss);
            Monster sleeperGuard = new Monster("The_Sleeper_Guardian", 100, 150, 150, 35, 15, 40, 13, 20, 10, DifficultyType.Boss);
            Monster gaunter = new Monster("Gaunter_oDim", 100, 2, 2, 40, 20, 50, 25, 29, 15, DifficultyType.Event);
            Monster mirage = new Monster("Mirror_Reflection", 100, 2, 2, 40, 20, 30, 18, 24, 15, DifficultyType.Event);

            List<Monster> monsters = new List<Monster> { gaunter, mirage, sleeperGuard, arachas,vampire, wildDog, penitent, tentacles, orkwarrior, leszy, sleeper, gargoyle, boneSoldier, boneArbalest, rattler, creeper, cannon, bigCrab, ghost, giant, ghoul, maggot, webber, webberSpitter, brigandTrainee, brigand, floutist, boneShielder };
            expeditionChoiceUserControl.Monsters = monsters;
            // Inicjalizacja Wypraw
            Expedition expedition1 = new Expedition("Canals of Novigrad", "It smells... of corpses in here?", 50, DifficultyType.Easy, new List<Monster> { new Monster(maggot), new Monster(maggot), new Monster(maggot), new Monster(maggot) }, 30, new List<Weapon> { greatsword }, new List<Armor> { mediumweightarmour });
            Expedition expedition2 = new Expedition("Abandoned Warehouse", "Apparently they used to store Apples here", 50, DifficultyType.Easy, new List<Monster> { new Monster(maggot), new Monster(maggot), new Monster(webber), new Monster(webber) }, 30, new List<Weapon> { greatsword }, new List<Armor> { mediumweightarmour });
            Expedition expedition3 = new Expedition("The Pied Piper of Hamelin", "Do you know where I can put this flute...?", 50, DifficultyType.Easy, new List<Monster> { new Monster(maggot), new Monster(maggot), new Monster(maggot), new Monster(floutist) }, 30, new List<Weapon> { greatsword }, new List<Armor> { mediumweightarmour });
            Expedition expedition4 = new Expedition("Puszcza Kampinoska", "Great Dark Forest, full of spiderwebs", 50, DifficultyType.Easy, new List<Monster> { new Monster(webber), new Monster(webber), new Monster(webberSpitter), new Monster(webberSpitter) }, 30, new List<Weapon> { glaive }, new List<Armor> { });
            Expedition expedition5 = new Expedition("Swamp Camp", "Illegal swamp herb plantation", 50, DifficultyType.Easy, new List<Monster> { new Monster(brigandTrainee), new Monster(brigandTrainee), new Monster(brigandTrainee), new Monster(brigand) }, 30, new List<Weapon> { dagger }, new List<Armor> { leatherarmor }); List<Expedition> expeditons = new List<Expedition> { expedition1, expedition2, expedition3, expedition4, expedition5 };

            // Ustawienie pocz¹tkowej widocznoœci UserControl
            menuUserControl.Visible = true;
            TeamCreatorUserControl.Visible = false;
            preparationsUserControl.Visible = false;
            expeditionUserControl.Visible = false;
            expeditionChoiceUserControl.Visible = false;


            SoundPlayer backgroundMusicPlayer = new SoundPlayer(Properties.Resources.menuSong);
            SoundPlayer fightMusicPlayer = new SoundPlayer(Properties.Resources.normalFight);
            SoundPlayer bossFightMusicPlayer = new SoundPlayer(Properties.Resources.bossFight);
            SoundPlayer eventFightMusicPlayer = new SoundPlayer(Properties.Resources.eventSong);
            backgroundMusicPlayer.PlayLooping();

            menuUserControl.NewGameButtonClicked += (sender, args) =>
            {
                //fazaPrzygotowaniaUserControl.Characters = characters;
                //fazaPrzygotowaniaUserControl.Ekwipunek = ekwipunek;
                //wyborWyprawyUserControl.expeditions = expeditons;
                //fazaPrzygotowaniaUserControl.gold = 100;
                //fazaPrzygotowaniaUserControl.Expeditons = wyborWyprawyUserControl.expeditions;

                //fazaPrzygotowaniaUserControl.GenerateShop();
                //fazaPrzygotowaniaUserControl.Visible = true;


                TeamCreatorUserControl.Characters = characters;
                TeamCreatorUserControl.CommonInventory = CommonIventory;
                TeamCreatorUserControl.Visible = true;
                menuUserControl.Visible = false;
            };

            TeamCreatorUserControl.startButtonClicked += (sender, args) =>
            {
                ekwipunek = TeamCreatorUserControl.StarterInventory.ToList();
                preparationsUserControl.characters = TeamCreatorUserControl.ChooseCharacters;
                preparationsUserControl.inventory = ekwipunek;
                expeditionChoiceUserControl.Expeditions = expeditons;
                preparationsUserControl.gold = 100;
                preparationsUserControl.expeditons = expeditionChoiceUserControl.Expeditions;

                preparationsUserControl.GenerateShop();
                preparationsUserControl.Visible = true;
                TeamCreatorUserControl.Visible = false;
            };

            menuUserControl.ContinueGreButtonClicked += (sender, args) =>
            {

                loadGame();
                preparationsUserControl.Visible = true;
                menuUserControl.Visible = false;
            };
         

            preparationsUserControl.WyruszButtonClicked += (sender, args) =>
            {

               
                preparationsUserControl.Visible = false;
                expeditionChoiceUserControl.Visible = true;


                expeditionUserControl.Characters = preparationsUserControl.characters;


            };
            expeditionChoiceUserControl.returnButtonClicked += (sender, args) =>
            {
                preparationsUserControl.Visible = true;
                expeditionChoiceUserControl.Visible = false;
            };

            expeditionChoiceUserControl.ExpeditionMouseClicked += (sender, args) =>
            {
                expeditionChoiceUserControl.Visible = false;

                expeditionUserControl.Expedition = expeditionChoiceUserControl.SelectedExpedition;

               


                backgroundMusicPlayer.Stop();
                if (expeditionUserControl.Expedition.Type == DifficultyType.Boss)
                    bossFightMusicPlayer.PlayLooping();
                else if (expeditionUserControl.Expedition.Type == DifficultyType.Event)
                {
                    eventFightMusicPlayer.PlayLooping();
                }
                else
                    fightMusicPlayer.PlayLooping();

               expeditionUserControl.Visible = true;
                
            };
            expeditionChoiceUserControl.EventQuestExist += (sender, args) =>
            {
                preparationsUserControl.eventQuest = expeditionChoiceUserControl.EventQuest;
            };
            expeditionUserControl.EventChoice += (sender, args) =>
            {
               expeditionChoiceUserControl.EventResult = true;
               preparationsUserControl.eventResult = true;
                expeditionUserControl.EventResult = true;
            };
            expeditionUserControl.FinishButtonClicked += (sender, args) =>
            {
                bossFightMusicPlayer.Stop();
                fightMusicPlayer.Stop();
                backgroundMusicPlayer.PlayLooping();
               expeditionUserControl.Visible = false;
                preparationsUserControl.Visible = true;
            };


        }
        public void loadGame()
        {
            string jsonData = File.ReadAllText("game_state.json");


            List<IInventory> equippedEkwipunek = new List<IInventory>();
            List<IInventory> shopItems = new List<IInventory>();
            List<Character> characters = new List<Character>();
            List<IInventory> ekwipunek = new List<IInventory>();
            List<Expedition> expeditons = new List<Expedition>();

            GameState gameState = JsonConvert.DeserializeObject<GameState>(jsonData, new JsonSerializerSettings
            {
                TypeNameHandling = TypeNameHandling.Auto
            });


            characters.AddRange(gameState.Chararacters);
            equippedEkwipunek.AddRange(gameState.Equiped);
            ekwipunek.AddRange(gameState.Inventory);           
            expeditons.AddRange(gameState.Expeditions);
            shopItems.AddRange(gameState.Shop);
  

            preparationsUserControl.eventQuest=gameState.EventQuest;
            preparationsUserControl.eventResult = gameState.EventResult;
            expeditionChoiceUserControl.EventQuest=gameState.EventQuest;
            expeditionChoiceUserControl.EventResult = gameState.EventResult;
            expeditionUserControl.EventResult=gameState.EventResult;
            preparationsUserControl.expeditons = expeditons;
            preparationsUserControl.characters = characters;
            preparationsUserControl.inventory = ekwipunek;
            preparationsUserControl.equipedItems = equippedEkwipunek;
            expeditionChoiceUserControl.Expeditions = expeditons;
            preparationsUserControl.gold = gameState.Gold;
            preparationsUserControl.shopItems = shopItems;
        }
      
    }
}