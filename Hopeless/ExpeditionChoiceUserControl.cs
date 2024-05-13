using HopelessLibary;
using System;
using System.Data;
using System.Diagnostics.Eventing.Reader;
using System.Windows.Forms;
namespace Hopeless
{
    public partial class ExpeditionChoiceUserControl : UserControl
    {
        public List<Expedition> Expeditions { get; set; }
        public List<Monster> Monsters { get; set; }
        public List<IInventory> EquipmentPool { get; set; }
        public Expedition SelectedExpedition { get; set; }
        Dictionary<string, string> QuestDescriptions = new Dictionary<string, string>();
        public event EventHandler EventQuestExist;
        public bool EventQuest;
        public bool EventResult;
        public ExpeditionChoiceUserControl()
        {
            InitializeComponent();
            pictureBox1.Image = Properties.Resources.Prep;
            InitializeExpeditonsNames();

            this.VisibleChanged += ExpeditionChoiceUserControl_VisibleChanged;

        }

        private void ExpeditionChoiceUserControl_VisibleChanged(object? sender, EventArgs e)
        {
            var control = sender as UserControl;
            if (control != null)
            {
                if (control.Visible)
                {
                    InitializeExpeditions();
                    InitializeMouseEvents();
                }

            }
        }



        private void InitializeExpeditonsNames()
        {

            QuestDescriptions.Add("Canals of Novigrad", "It smells... of corpses??");
            QuestDescriptions.Add("Abandoned Warehouse", "Apparently they used to store apples here");
            QuestDescriptions.Add("The Pied Piper of Hamelin", "Do you know where you can put this flute...?");
            QuestDescriptions.Add("Puszcza Kampinoska", "Great Dark Forest, full of spiderwebs");
            QuestDescriptions.Add("Swamp Camp", "Illegal swamp herb plantation");
            QuestDescriptions.Add("A bar in the suburbs", "Full of drunks and... Monsters?!");
            QuestDescriptions.Add("Old Cemetery", "I wonder if they still have any available quarters here?");
            QuestDescriptions.Add("Beshamuntir Castle", "At its end there is said to be a Dragon waiting");
            QuestDescriptions.Add("Red Forest", "Nice here, trees, stumps, dryads... But why do they have knives?");
            QuestDescriptions.Add("Mount Hyjal", "You must clear the area around the World Tree of these monsters");
            QuestDescriptions.Add("Black Gate", "Sauron!!! Get out, I know you're there!");
            QuestDescriptions.Add("Mojave Wasteland", "Before the nukes there was a desert here too, but not as dangerous");
        }

        private void InitializeExpeditions()
        {

            easyExpeditions.Controls.Clear();

            mediumExpeditions.Controls.Clear();

            hardExpeditions.Controls.Clear();

            bossExpeditions.Controls.Clear();

            //Losowanie 3 startowych misji
            if (Expeditions.Count(expedition => expedition.Type == DifficultyType.Easy) > 4)
            {
                var random = new Random();
                var randomExpeditions = Expeditions.Where(expedition => expedition.Type == DifficultyType.Easy).OrderBy(x => random.Next()).Take(3).ToList();
                Expeditions.RemoveAll(expedition => expedition.Type == DifficultyType.Easy && !randomExpeditions.Contains(expedition));

            }



            foreach (Expedition expediton in Expeditions)
            {
                Label label = new Label();
                label.Text = expediton.Name;
                label.AutoSize = false;
                label.Height = 155;
                label.Width = 300;
                label.Font = new Font("Arial", 15);
                label.TextAlign = ContentAlignment.MiddleCenter;
                label.BorderStyle = BorderStyle.FixedSingle;


                label.AccessibleDescription = expediton.Name + Environment.NewLine + expediton.Description + Environment.NewLine + "Gold for the expedition: " + expediton.Gold.ToString() +
                  Environment.NewLine + "EXP for Expedition: " + expediton.ExperienceGains.ToString() + Environment.NewLine + Environment.NewLine +
                  "Possible Weapon Drop:" + Environment.NewLine +
                  string.Join("," + Environment.NewLine, expediton.WeaponRewards.Select(Name => Name.Display())) + Environment.NewLine + Environment.NewLine +
                  "Possible Armor Drop:" + Environment.NewLine +
                  string.Join("," + Environment.NewLine, expediton.ArmorRewards.Select(Name => Name.Display())) + Environment.NewLine + Environment.NewLine +
                   "Monsters:" + Environment.NewLine +
                 string.Join("," + Environment.NewLine, expediton.Monsters.Select(Name => Name.ToString()));
                switch (expediton.Type)
                {
                    case DifficultyType.Event:
                        label.BackColor = Color.Gold;
                        break;
                    case DifficultyType.Easy:
                        label.BackColor = Color.Green;
                        break;
                    case DifficultyType.Medium:
                        label.BackColor = Color.Orange;
                        break;
                    case DifficultyType.Hard:
                        label.BackColor = Color.Red;
                        label.ForeColor = Color.White;
                        break;
                    case DifficultyType.Boss:
                        label.BackColor = Color.Black;
                        label.ForeColor = Color.White;
                        break;
                    default:
                        break;
                }

                if (expediton.Type == DifficultyType.Easy)
                {
                    easyExpeditions.Controls.Add(label);
                }
                else if (expediton.Type == DifficultyType.Medium)
                {
                    mediumExpeditions.Controls.Add(label);
                }
                else if (expediton.Type == DifficultyType.Hard)
                {
                    hardExpeditions.Controls.Add(label);
                }
                else
                {
                    bossExpeditions.Controls.Add(label);
                }
            }
        }
        private void InitializeMouseEvents()
        {

            foreach (Control control in easyExpeditions.Controls)
            {

                control.MouseHover += ExpeditionMouseHover;
                control.MouseClick += ExpeditionMouseClick;
            }
            foreach (Control control in mediumExpeditions.Controls)
            {
                control.MouseHover += ExpeditionMouseHover;
                control.MouseClick += ExpeditionMouseClick;
            }
            foreach (Control control in hardExpeditions.Controls)
            {
                control.MouseHover += ExpeditionMouseHover;
                control.MouseClick += ExpeditionMouseClick;
            }
            foreach (Control control in bossExpeditions.Controls)
            {
                control.MouseHover += ExpeditionMouseHover;
                control.MouseClick += ExpeditionMouseClick;
            }



        }
        private void ExpeditionMouseHover(object sender, EventArgs e)
        {
            Label label = sender as Label;
            string itemDescription = label.AccessibleDescription;
            DescriptionBox.Text = itemDescription;
        }
        public event EventHandler ExpeditionMouseClicked;
        private void ExpeditionMouseClick(object sender, EventArgs e)
        {
            Label label = sender as Label;
            foreach (Expedition expedition in Expeditions)
            {
                if (expedition.Name == label.Text)
                {
                    SelectedExpedition = expedition;
                    if (SelectedExpedition.Type == DifficultyType.Boss && EventResult)
                    {

                        foreach (var monster in SelectedExpedition.Monsters)
                        {
                            if (monster.Name == "The_Sleeper_Guardian")
                            {
                                monster.CurrentHP = 1;
                            }
                        }

                    }
                }
            }


            ExpeditionMouseClicked?.Invoke(this, EventArgs.Empty);
        }
        public event EventHandler returnButtonClicked;
        private void returnButton_Click(object sender, EventArgs e)
        {
            returnButtonClicked?.Invoke(this, EventArgs.Empty);
        }

        public void AfterExpedition(bool result, Expedition expedition)
        {
            KeyValuePair<string, string> selectedQuest;
            do
            {
                selectedQuest = RandomQuest(QuestDescriptions);
            }
            while (Expeditions.Any(expedition => expedition.Name == selectedQuest.Key));

            if (result)
            {


                Expeditions.Remove(expedition);
                Expedition newExpedition1;
                if (expedition.Type != DifficultyType.Event && expedition.Type != DifficultyType.Boss)
                {
                    newExpedition1 = new Expedition(selectedQuest.Key, selectedQuest.Value, GenerateRandomExp(expedition.Type), expedition.Type, GenerateMonsters(expedition.Type), GenerateRandomGold(expedition.Type), GenerateWeapons(expedition.Type), GenerateArmors(expedition.Type));
                    Expeditions.Add(newExpedition1);
                }

                if (new Random().Next(1, 100) > 1 && !EventQuest)
                {
                    List<Monster> chosen = new List<Monster>();
                    chosen.Add(new Monster(Monsters.FirstOrDefault(monster => monster.Name == "Mirror_Reflection")));
                    chosen.Add(new Monster(Monsters.FirstOrDefault(monster => monster.Name == "Mirror_Reflection")));
                    chosen.Add(new Monster(Monsters.FirstOrDefault(monster => monster.Name == "Mirror_Reflection")));
                    chosen.Add(new Monster(Monsters.FirstOrDefault(monster => monster.Name == "Gaunter_oDim")));
                    newExpedition1 = new Expedition("???", "???????????????????????????????", 300, DifficultyType.Event, chosen, 200, GenerateWeapons(DifficultyType.Boss), GenerateArmors(DifficultyType.Boss));
                    Expeditions.Add(newExpedition1);
                    EventQuest = true;
                    EventQuestExist?.Invoke(this, EventArgs.Empty);
                }







                do
                {
                    selectedQuest = RandomQuest(QuestDescriptions);
                }
                while (Expeditions.Any(expedition => expedition.Name == selectedQuest.Key));



                Expedition newExpedition2;

                if (expedition.Type == DifficultyType.Easy)
                {

                    if (Expeditions.Count(exp => exp.Type == DifficultyType.Medium) < 3)
                    {
                        newExpedition2 = new Expedition(selectedQuest.Key, selectedQuest.Value, GenerateRandomExp(DifficultyType.Medium), DifficultyType.Medium, GenerateMonsters(DifficultyType.Medium), GenerateRandomGold(DifficultyType.Medium), GenerateWeapons(DifficultyType.Medium), GenerateArmors(DifficultyType.Medium));
                        Expeditions.Add(newExpedition2);
                    }
                }
                else if (expedition.Type == DifficultyType.Medium)
                {
                    if (Expeditions.Count(exp => exp.Type == DifficultyType.Hard) < 3)
                    {
                        newExpedition2 = new Expedition(selectedQuest.Key, selectedQuest.Value, GenerateRandomExp(DifficultyType.Hard), DifficultyType.Hard, GenerateMonsters(DifficultyType.Hard), GenerateRandomGold(DifficultyType.Hard), GenerateWeapons(DifficultyType.Hard), GenerateArmors(DifficultyType.Hard));
                        Expeditions.Add(newExpedition2);
                    }
                }
                else if (expedition.Type == DifficultyType.Hard)
                {
                    if (Expeditions.Count(exp => exp.Type == DifficultyType.Boss) < 1)
                    {
                        newExpedition2 = new Expedition("The Sleeper's Cave", "So We Meet at Last", GenerateRandomExp(DifficultyType.Boss), DifficultyType.Boss, GenerateMonsters(DifficultyType.Boss), GenerateRandomGold(DifficultyType.Boss), GenerateWeapons(DifficultyType.Boss), GenerateArmors(DifficultyType.Boss));
                        Expeditions.Add(newExpedition2);
                    }
                }
                else
                {

                }



            }
            else
            {
                Expeditions.Remove(expedition);
                if (expedition.Type != DifficultyType.Event && expedition.Type != DifficultyType.Boss)
                {
                    Expedition newExpedition1 = new Expedition(selectedQuest.Key, selectedQuest.Value, GenerateRandomExp(expedition.Type), expedition.Type, GenerateMonsters(expedition.Type), GenerateRandomGold(expedition.Type), GenerateWeapons(expedition.Type), GenerateArmors(expedition.Type));
                    Expeditions.Add(newExpedition1);
                }
            }

        }

        private KeyValuePair<string, string> RandomQuest(Dictionary<string, string> quests)
        {
            // Generowanie losowego indeksu
            Random rand = new Random();
            int index = rand.Next(0, quests.Count);

            // Pobranie pary klucz-wartość na podstawie wylosowanego indeksu
            string[] keys = new string[quests.Count];
            quests.Keys.CopyTo(keys, 0);
            string selectedKey = keys[index];
            return new KeyValuePair<string, string>(selectedKey, quests[selectedKey]);
        }
        private int GenerateRandomGold(DifficultyType difficulty)
        {
            Random rand = new Random();
            int minRange, maxRange;

            switch (difficulty)
            {
                case DifficultyType.Easy:
                    minRange = 20;
                    maxRange = 40;
                    break;
                case DifficultyType.Medium:
                    minRange = 35;
                    maxRange = 55;
                    break;
                case DifficultyType.Hard:
                    minRange = 45;
                    maxRange = 70;
                    break;
                case DifficultyType.Boss:
                    minRange = 100;
                    maxRange = 150;
                    break;
                default:
                    throw new ArgumentException("Unknown difficulty level.");
            }

            return rand.Next(minRange, maxRange + 1);
        }
        private int GenerateRandomExp(DifficultyType difficulty)
        {
            Random rand = new Random();
            int minRange, maxRange;

            switch (difficulty)
            {
                case DifficultyType.Easy:
                    minRange = 50;
                    maxRange = 100;
                    break;
                case DifficultyType.Medium:
                    minRange = 75;
                    maxRange = 150;
                    break;
                case DifficultyType.Hard:
                    minRange = 100;
                    maxRange = 200;
                    break;
                case DifficultyType.Boss:
                    minRange = 250;
                    maxRange = 300;
                    break;
                default:
                    throw new ArgumentException("Unknown difficulty level.");
            }

            return rand.Next(minRange, maxRange + 1);
        }
        private List<Monster> GenerateMonsters(DifficultyType difficulty)
        {

            List<Monster> wybrane = new List<Monster>();
            Random r = new Random();

            if (difficulty != DifficultyType.Boss)
            {
                while (wybrane.Count != 4)
                {
                    int i = r.Next(0, Monsters.Count);

                    if (Monsters[i].Type == difficulty)
                    {
                        wybrane.Add(new Monster(Monsters[i]));
                    }

                }
            }
            else
            {
                wybrane.Add(new Monster(Monsters.FirstOrDefault(monster => monster.Name == "The_Sleeper_Guardian")));
                wybrane.Add(new Monster(Monsters.FirstOrDefault(monster => monster.Name == "The_Sleeper_Guardian")));
                wybrane.Add(new Monster(Monsters.FirstOrDefault(monster => monster.Name == "The_Sleeper_Guardian")));
                wybrane.Add(new Monster(Monsters.FirstOrDefault(monster => monster.Name == "The_Sleeper")));


            }

            return wybrane;

        }
        //Jak Dodamy Rarity do itemow to trzeba tutaj dac sprawdzenie rzadkosci
        private List<Weapon> GenerateWeapons(DifficultyType difficulty)
        {




            // Konwersja Enumów na wartości liczbowe (int) i porównanie

            List<Weapon> wybrane = new List<Weapon>();
            Random r = new Random();
            do
            {
                int i = r.Next(0, EquipmentPool.Count);

                if (EquipmentPool[i] is Weapon)
                {
                    Weapon weapon = (Weapon)EquipmentPool[i];
                    if ((int)weapon.Rarity == (int)difficulty)
                    {
                        wybrane.Add((Weapon)EquipmentPool[i]);
                    }


                }
            } while (wybrane.Count == 0);


            return wybrane;

        }
        private List<Armor> GenerateArmors(DifficultyType difficulty)
        {

            List<Armor> wybrane = new List<Armor>();
            Random r = new Random();
            do
            {
                int i = r.Next(0, EquipmentPool.Count);
                if (EquipmentPool[i] is Armor)
                {
                    Armor armor = (Armor)EquipmentPool[i];
                    if ((int)armor.Rarity == (int)difficulty)
                    {
                        wybrane.Add((Armor)EquipmentPool[i]);
                    }

                }
            } while (wybrane.Count == 0);


            return wybrane;

        }
    }
}
