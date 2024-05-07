﻿using HopelessLibary;
using System;
using System.Data;
using System.Diagnostics.Eventing.Reader;
using System.Windows.Forms;
namespace Hopeless
{
    public partial class WyborWyprawyUserControl : UserControl
    {
        public List<Expedition> expeditions { get; set; }
        public List<Monster> monsters { get; set; }
        public List<IEkwipunek> pulaEkwipunku { get; set; }
        public Expedition selectedExpedition { get; set; }
        Dictionary<string, string> questDescriptions = new Dictionary<string, string>();
        public event EventHandler eventQuestExist;
        public bool eventQuest;
        public bool eventResult;
        public WyborWyprawyUserControl()
        {
            InitializeComponent();
            pictureBox1.Image = Properties.Resources.Prep;
            InitializeExpeditonsNames();

            this.VisibleChanged += WyborWyprawyUserControl_VisibleChanged;

        }

        private void WyborWyprawyUserControl_VisibleChanged(object? sender, EventArgs e)
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

            questDescriptions.Add("Kanały Nowigradu", "Ależ tu śmierdzi... zwłokami??");
            questDescriptions.Add("Opuszczony Magazyn", "Ponoć kiedys składowali tu Jabole");
            questDescriptions.Add("Flecista z Hameln", "Wiesz gdzie możesz sobie wsadzić ten flet...?");
            questDescriptions.Add("Puszcza Kampinoska", "Wielki Ciemny Las, w ktorym roi sie od pajeczyn");
            questDescriptions.Add("Oboz na Bagnach", "Nielegalna plantacja bagiennego ziela");
            questDescriptions.Add("Bar na przedmieściach", "Pełny pijaków i ... Potworów?!");
            questDescriptions.Add("Stary Cmentarz", "Ciekawe czy mają tu jeszcze jakieś wolne kwatery?");
            questDescriptions.Add("Zamek Beshamuntir", "Na jego końcu ponoć czeka Smok");
            questDescriptions.Add("Czerwony Las", "Ładnie tu, drzewa, pniaki, driady ... Ale czemu mają noże?");
            questDescriptions.Add("Góra Hyjal", "Należy oczyścić okolice Drzewa Świata z tym potworów");
            questDescriptions.Add("Czarna Brama", "Sauron!!! Wyłaź, wiem, że tam jesteś!");
            questDescriptions.Add("Pustkowia Mojave", "Przed atomowką też byla tu pustynia, ale nie tak niebezpieczna");
        }

        private void InitializeExpeditions()
        {

            easyExpeditions.Controls.Clear();

            mediumExpeditions.Controls.Clear();

            hardExpeditions.Controls.Clear();

            bossExpeditions.Controls.Clear();

            //Losowanie 3 startowych misji
            if (expeditions.Count(expedition => expedition.Type == DifficultyType.Easy) > 4)
            {
                var random = new Random();
                var randomExpeditions = expeditions.Where(expedition => expedition.Type == DifficultyType.Easy).OrderBy(x => random.Next()).Take(3).ToList();
                expeditions.RemoveAll(expedition => expedition.Type == DifficultyType.Easy && !randomExpeditions.Contains(expedition));

            }



            foreach (Expedition expediton in expeditions)
            {
                Label label = new Label();
                label.Text = expediton.Name;
                label.AutoSize = false;
                label.Height = 155;
                label.Width = 300;
                label.Font = new Font("Arial", 15);
                label.TextAlign = ContentAlignment.MiddleCenter;
                label.BorderStyle = BorderStyle.FixedSingle;


                label.AccessibleDescription = expediton.Name + Environment.NewLine + expediton.Description + Environment.NewLine + "Złoto za wyprawe: " + expediton.Gold.ToString() +
                Environment.NewLine + "EXP za wyprawe: " + expediton.ExperienceGains.ToString() + Environment.NewLine + Environment.NewLine +
                "Możliwy Drop Broni:" + Environment.NewLine +
                string.Join("," + Environment.NewLine, expediton.WeaponRewards.Select(Name => Name.ToString())) + Environment.NewLine + Environment.NewLine +
                "Możliwy Drop Zbroii:" + Environment.NewLine +
                string.Join("," + Environment.NewLine, expediton.ArmorRewards.Select(Name => Name.ToString())) + Environment.NewLine + Environment.NewLine +
                 "Potwory:" + Environment.NewLine +
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
            foreach (Expedition expedition in expeditions)
            {
                if (expedition.Name == label.Text)
                {
                    selectedExpedition = expedition;
                    if(selectedExpedition.Type == DifficultyType.Boss && eventResult)
                    {
                       
                            foreach (var monster in selectedExpedition.Monsters)
                            {
                                if (monster.Name == "Strażnik Śniącego")
                                {
                                    monster.CurrentHP = 1;
                                }
                            }
                        
                    }
                }
            }


            ExpeditionMouseClicked?.Invoke(this, EventArgs.Empty);
        }
        public event EventHandler powrotButtonClicked;
        private void powrotButton_Click(object sender, EventArgs e)
        {
            powrotButtonClicked?.Invoke(this, EventArgs.Empty);
        }

        public void AfterExpedition(bool wynik, Expedition wyprawa)
        {
            KeyValuePair<string, string> selectedQuest;
            do
            {
                selectedQuest = RandomQuest(questDescriptions);
            }
            while (expeditions.Any(expedition => expedition.Name == selectedQuest.Key));

            if (wynik)
            {


                expeditions.Remove(wyprawa);
                Expedition newExpedition1;
                if (wyprawa.Type != DifficultyType.Event && wyprawa.Type != DifficultyType.Boss)
                {
                    newExpedition1 = new Expedition(selectedQuest.Key, selectedQuest.Value, GenerateRandomExp(wyprawa.Type), wyprawa.Type, GenerateMonsters(wyprawa.Type), GenerateRandomGold(wyprawa.Type), GenerateWeapons(wyprawa.Type), GenerateArmors(wyprawa.Type));
                    expeditions.Add(newExpedition1);
                }

                if (new Random().Next(1, 100) > 1 && !eventQuest)
                {
                    List<Monster> wybrane = new List<Monster>();
                    wybrane.Add(new Monster(monsters.FirstOrDefault(monster => monster.Name == "Odbicie_Lustrzane")));
                    wybrane.Add(new Monster(monsters.FirstOrDefault(monster => monster.Name == "Odbicie_Lustrzane")));
                    wybrane.Add(new Monster(monsters.FirstOrDefault(monster => monster.Name == "Odbicie_Lustrzane")));
                    wybrane.Add(new Monster(monsters.FirstOrDefault(monster => monster.Name == "Gaunter_oDim")));
                    newExpedition1 = new Expedition("???", "???????????????????????????????", 300, DifficultyType.Event, wybrane, 200, GenerateWeapons(DifficultyType.Boss), GenerateArmors(DifficultyType.Boss));
                    expeditions.Add(newExpedition1);
                    eventQuest = true;
                    eventQuestExist?.Invoke(this, EventArgs.Empty);
                }







                do
                {
                    selectedQuest = RandomQuest(questDescriptions);
                }
                while (expeditions.Any(expedition => expedition.Name == selectedQuest.Key));



                Expedition newExpedition2;

                if (wyprawa.Type == DifficultyType.Easy)
                {

                    if (expeditions.Count(exp => exp.Type == DifficultyType.Medium) < 3)
                    {
                        newExpedition2 = new Expedition(selectedQuest.Key, selectedQuest.Value, GenerateRandomExp(DifficultyType.Medium), DifficultyType.Medium, GenerateMonsters(DifficultyType.Medium), GenerateRandomGold(DifficultyType.Medium), GenerateWeapons(DifficultyType.Medium), GenerateArmors(DifficultyType.Medium));
                        expeditions.Add(newExpedition2);
                    }
                }
                else if (wyprawa.Type == DifficultyType.Medium)
                {
                    if (expeditions.Count(exp => exp.Type == DifficultyType.Hard) < 3)
                    {
                        newExpedition2 = new Expedition(selectedQuest.Key, selectedQuest.Value, GenerateRandomExp(DifficultyType.Hard), DifficultyType.Hard, GenerateMonsters(DifficultyType.Hard), GenerateRandomGold(DifficultyType.Hard), GenerateWeapons(DifficultyType.Hard), GenerateArmors(DifficultyType.Hard));
                        expeditions.Add(newExpedition2);
                    }
                }
                else if (wyprawa.Type == DifficultyType.Hard)
                {
                    if (expeditions.Count(exp => exp.Type == DifficultyType.Boss) < 1)
                    {
                        newExpedition2 = new Expedition("Jaskinia Sniacego", "A wiec w koncu się spotykamy", GenerateRandomExp(DifficultyType.Boss), DifficultyType.Boss, GenerateMonsters(DifficultyType.Boss), GenerateRandomGold(DifficultyType.Boss), GenerateWeapons(DifficultyType.Boss), GenerateArmors(DifficultyType.Boss));
                        expeditions.Add(newExpedition2);
                    }
                }
                else
                {

                }



            }
            else
            {
                expeditions.Remove(wyprawa);
                if (wyprawa.Type != DifficultyType.Event && wyprawa.Type != DifficultyType.Boss) { 
                    Expedition newExpedition1 = new Expedition(selectedQuest.Key, selectedQuest.Value, GenerateRandomExp(wyprawa.Type), wyprawa.Type, GenerateMonsters(wyprawa.Type), GenerateRandomGold(wyprawa.Type), GenerateWeapons(wyprawa.Type), GenerateArmors(wyprawa.Type));
                expeditions.Add(newExpedition1);
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
                    throw new ArgumentException("Nieznany poziom trudności.");
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
                    throw new ArgumentException("Nieznany poziom trudności.");
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
                    int i = r.Next(0, monsters.Count);

                    if (monsters[i].Type == difficulty)
                    {
                        wybrane.Add(new Monster(monsters[i]));
                    }

                }
            }
            else
            {
                wybrane.Add(new Monster(monsters.FirstOrDefault(monster => monster.Name == "Straznik_Sniacego")));
                wybrane.Add(new Monster(monsters.FirstOrDefault(monster => monster.Name == "Straznik_Sniacego")));
                wybrane.Add(new Monster(monsters.FirstOrDefault(monster => monster.Name == "Straznik_Sniacego")));
                wybrane.Add(new Monster(monsters.FirstOrDefault(monster => monster.Name == "Sniacy")));

                if (eventResult)
                {
                    foreach (var monster in wybrane)
                    {
                        if (monster.Name == "Straznik_Sniacego")
                        {
                            monster.CurrentHP = 1;
                        }
                    }
                }
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
                int i = r.Next(0, pulaEkwipunku.Count);

                if (pulaEkwipunku[i] is Weapon)
                {
                    Weapon weapon = (Weapon)pulaEkwipunku[i];
                    if ((int)weapon.Rarity == (int)difficulty)
                    {
                        wybrane.Add((Weapon)pulaEkwipunku[i]);
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
                int i = r.Next(0, pulaEkwipunku.Count);
                if (pulaEkwipunku[i] is Armor)
                {
                    Armor armor = (Armor)pulaEkwipunku[i];
                    if ((int)armor.Rarity == (int)difficulty)
                    {
                        wybrane.Add((Armor)pulaEkwipunku[i]);
                    }

                }
            } while (wybrane.Count == 0);


            return wybrane;

        }
    }
}
