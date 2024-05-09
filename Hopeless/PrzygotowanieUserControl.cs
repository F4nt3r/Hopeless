using HopelessLibary;
using NAudio.Wave;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System.Data;
using System.Diagnostics;
using System.Media;
using static HopelessLibary.Armor;
using static HopelessLibary.Weapon;

namespace Hopeless
{
    public partial class PrzygotowanieUserControl : UserControl
    {
        public List<Character> Characters { get; set; }
        public List<Expedition> Expeditons { get; set; }
        public List<IEkwipunek> Ekwipunek { get; set; }
        public List<IEkwipunek> equipedItems = new List<IEkwipunek>();
        public List<IEkwipunek> pulaEkwipunku { get; set; }
        public List<IEkwipunek> shopItems = new List<IEkwipunek>();
        public int gold { get; set; }
        private Label lastDraggedLabel;
        public bool eventQuest;
        public bool eventResult;
        public PrzygotowanieUserControl()
        {
            InitializeComponent();
            pictureBox1.Image = Properties.Resources.Prep;
            InitializeCharactersDragDrop();

            this.VisibleChanged += PrzygotowanieUserControl_VisibleChanged;



        }

        private void PrzygotowanieUserControl_VisibleChanged(object? sender, EventArgs e)
        {
            var control = sender as UserControl;
            if (control != null)
            {
                if (control.Visible)
                {
                    RefreshStats();
                    RefreshInventory();
                    RefreshShop();
                    SaveGameState();
                    character1Picture.Image = (Image)Properties.Resources.ResourceManager.GetObject(Characters[0].CharacterType.ToString().ToLower()+"Picture");
                    character2Picture.Image = (Image)Properties.Resources.ResourceManager.GetObject(Characters[1].CharacterType.ToString().ToLower() + "Picture");
                    character3Picture.Image = (Image)Properties.Resources.ResourceManager.GetObject(Characters[2].CharacterType.ToString().ToLower() + "Picture");
                    character4Picture.Image = (Image)Properties.Resources.ResourceManager.GetObject(Characters[3].CharacterType.ToString().ToLower() + "Picture");
                }



            }
        }


        private void RefreshStats()
        {

            if (Characters != null && Characters.Any())
            {

                character1Name.Text = "Imie: " + Characters[0].Name;
                character1Level.Text = "Level: " + Characters[0].Level;
                character1Exp.Text = "Punkty EXP: " + Characters[0].ExperiencePoints;
                character1Strength.Text = "Sila: " + Characters[0].Strength;
                character1Dexterity.Text = "Zrecznosc: " + Characters[0].Dexterity;
                character1Intelligence.Text = "Inteligencja: " + Characters[0].Intelligence;
                character1Hp.Text = "HP: " + Characters[0].CurrentHP + "/" + Characters[0].MaxHP;
                character1Resistance.Text = "Odpornosc: " + Characters[0].Resistance;
                character1Crit.Text = "Szansa na Kryta: " + Characters[0].CritChance + "%";
                character1Initiative.Text = "Inicjatywa: " + Characters[0].Initiative;
                character1Dmg.Text = "Obrazenia Ataku: " + Characters[0].MinDmg + "-" + Characters[0].MaxDmg;
                if (Characters[0].CharacterType == CharacterType.Knight)
                {
                    Knight knight = (Knight)Characters[0];
                    character1Block.Text = "Szansa na Blok: " + knight.BlockChance;
                }
                else if (Characters[0].CharacterType == CharacterType.Rogue)
                {
                    Rogue rogue = (Rogue)Characters[0];
                    character1Block.Text = "Szansa na Unik: " + rogue.DodgeChance;
                }
                else if (Characters[0].CharacterType == CharacterType.Cleric)
                {
                    Cleric cleric = (Cleric)Characters[0];
                    character1Block.Text = "Szansa na Blogoslawienstwo: " + cleric.BlessingChance;
                }
                else if (Characters[0].CharacterType == CharacterType.Joker)
                {
                    Joker joker = (Joker)Characters[0];
                    character1Block.Text = "Szansa na DoubleAttack: " + joker.DoubleAtackChance;
                }
                else
                {
                    character1Block.Text = " ";
                }

                if (Characters[0].Weapon != null)
                {
                    character1Weapon.Text = Characters[0].Weapon.Name;
                    character1Weapon.AccessibleDescription = Characters[0].Weapon.Name + Environment.NewLine + Characters[0].Weapon.Description + Environment.NewLine + Characters[0].Weapon.Rarity + Environment.NewLine + "MinDMG: " + Characters[0].Weapon.MinDmg.ToString() +
                        Environment.NewLine + "MaxDMG: " + Characters[0].Weapon.MaxDmg.ToString() + Environment.NewLine + "Dostepne dla Klas:" + Environment.NewLine +
                    string.Join("," + Environment.NewLine, Characters[0].Weapon.AllowedCharacters.Select(characterType => characterType.ToString())) + Environment.NewLine + "Wartosc:" + Environment.NewLine + Characters[0].Weapon.SalesPrice.ToString();
                    switch (Characters[0].Weapon.Rarity)
                    {
                        case Rarity.Common:
                            character1Weapon.BackColor = Color.LightGray; // Dostosuj kolor do poziomu Rarity
                            break;
                        case Rarity.Rare:
                            character1Weapon.BackColor = Color.LightBlue; // Dostosuj kolor do poziomu Rarity
                            break;
                        case Rarity.Epic:
                            character1Weapon.BackColor = Color.DarkMagenta; // Dostosuj kolor do poziomu Rarity
                            break;
                        case Rarity.Legendary:
                            character1Weapon.BackColor = Color.Orange; // Dostosuj kolor do poziomu Rarity
                            break;
                        default:
                            break;
                    }
                }
                else
                {
                    character1Weapon.Text = "Brak";
                    character1Weapon.AccessibleDescription = "  ";
                }

                if (Characters[0].Armor != null)
                {
                    character1Armor.Text = Characters[0].Armor.Name;
                    character1Armor.AccessibleDescription = Characters[0].Armor.Name + Environment.NewLine + Characters[0].Armor.Description + Environment.NewLine + Characters[0].Armor.Rarity + Environment.NewLine + "DmgReduction: " + Characters[0].Armor.DmgReduction.ToString()
                        + Environment.NewLine + "Dostepne dla Klas:" + Environment.NewLine + string.Join("," + Environment.NewLine, Characters[0].Armor.AllowedCharacters.Select(characterType => characterType.ToString())) + Environment.NewLine + "Wartosc:" + Environment.NewLine + Characters[0].Armor.SalesPrice.ToString();
                    switch (Characters[0].Armor.Rarity)
                    {
                        case Rarity.Common:
                            character1Armor.BackColor = Color.LightGray; // Dostosuj kolor do poziomu Rarity
                            break;
                        case Rarity.Rare:
                            character1Armor.BackColor = Color.LightBlue; // Dostosuj kolor do poziomu Rarity
                            break;
                        case Rarity.Epic:
                            character1Armor.BackColor = Color.DarkMagenta; // Dostosuj kolor do poziomu Rarity
                            break;
                        case Rarity.Legendary:
                            character1Armor.BackColor = Color.Orange; // Dostosuj kolor do poziomu Rarity
                            break;
                        default:
                            break;
                    }
                }
                else
                {
                    character1Armor.Text = "Brak";
                    character1Armor.AccessibleDescription = "  ";
                }
                character1ClassName.Text = Characters[0].Name;





                character2Name.Text = "Imie: " + Characters[1].Name;
                character2Level.Text = "Level: " + Characters[1].Level;
                character2Exp.Text = "Punkty EXP: " + Characters[1].ExperiencePoints;
                character2Strength.Text = "Sila: " + Characters[1].Strength;
                character2Dexterity.Text = "Zrecznosc: " + Characters[1].Dexterity;
                character2Intelligence.Text = "Inteligencja: " + Characters[1].Intelligence;
                character2Hp.Text = "HP: " + Characters[1].CurrentHP + "/" + Characters[1].MaxHP;
                character2Resistance.Text = "Odpornosc: " + Characters[1].Resistance;
                character2Crit.Text = "Szansa na Kryta: " + Characters[1].CritChance + "%";
                character2Initiative.Text = "Inicjatywa: " + Characters[1].Initiative;
                character2Dmg.Text = "Obrazenia Ataku: " + Characters[1].MinDmg + "-" + Characters[1].MaxDmg;
                if (Characters[1].CharacterType == CharacterType.Knight)
                {
                    Knight knight = (Knight)Characters[1];
                    character2Block.Text = "Szansa na Blok: " + knight.BlockChance;
                }
                else if (Characters[1].CharacterType == CharacterType.Rogue)
                {
                    Rogue rogue = (Rogue)Characters[1];
                    character2Block.Text = "Szansa na Unik: " + rogue.DodgeChance;
                }
                else if (Characters[1].CharacterType == CharacterType.Cleric)
                {
                    Cleric cleric = (Cleric)Characters[1];
                    character2Block.Text = "Szansa na Blogoslawienstwo: " + cleric.BlessingChance;
                }
                else if (Characters[1].CharacterType == CharacterType.Joker)
                {
                    Joker joker = (Joker)Characters[1];
                    character2Block.Text = "Szansa na DoubleAttack: " + joker.DoubleAtackChance;
                }
                else
                {
                    character2Block.Text = " ";
                }
                if (Characters[1].Weapon != null)
                {
                    character2Weapon.Text = Characters[1].Weapon.Name;
                    character2Weapon.AccessibleDescription = Characters[1].Weapon.Name + Environment.NewLine + Characters[1].Weapon.Description + Environment.NewLine + Characters[1].Weapon.Rarity + Environment.NewLine + "MinDMG: " + Characters[1].Weapon.MinDmg.ToString() +
                        Environment.NewLine + "MaxDMG: " + Characters[1].Weapon.MaxDmg.ToString() + Environment.NewLine + "Dostepne dla Klas:" + Environment.NewLine +
                    string.Join("," + Environment.NewLine, Characters[1].Weapon.AllowedCharacters.Select(characterType => characterType.ToString())) + Environment.NewLine + "Wartosc:" + Environment.NewLine + Characters[1].Weapon.SalesPrice.ToString();
                    switch (Characters[1].Weapon.Rarity)
                    {
                        case Rarity.Common:
                            character2Weapon.BackColor = Color.LightGray; // Dostosuj kolor do poziomu Rarity
                            break;
                        case Rarity.Rare:
                            character2Weapon.BackColor = Color.LightBlue; // Dostosuj kolor do poziomu Rarity
                            break;
                        case Rarity.Epic:
                            character2Weapon.BackColor = Color.DarkMagenta; // Dostosuj kolor do poziomu Rarity
                            break;
                        case Rarity.Legendary:
                            character2Weapon.BackColor = Color.Orange; // Dostosuj kolor do poziomu Rarity
                            break;
                        default:
                            break;
                    }
                }
                else
                {
                    character2Weapon.Text = "Brak";
                    character2Weapon.AccessibleDescription = "  ";
                }
                if (Characters[1].Armor != null)
                {
                    character2Armor.Text = Characters[1].Armor.Name;
                    character2Armor.AccessibleDescription = Characters[1].Armor.Name + Environment.NewLine + Characters[1].Armor.Description + Environment.NewLine + Characters[1].Armor.Rarity + Environment.NewLine + "DmgReduction: " + Characters[1].Armor.DmgReduction.ToString()
                        + Environment.NewLine + "Dostepne dla Klas:" + Environment.NewLine + string.Join("," + Environment.NewLine, Characters[1].Armor.AllowedCharacters.Select(characterType => characterType.ToString())) + Environment.NewLine + "Wartosc:" + Environment.NewLine + Characters[1].Armor.SalesPrice.ToString();
                    switch (Characters[1].Armor.Rarity)
                    {
                        case Rarity.Common:
                            character2Armor.BackColor = Color.LightGray; // Dostosuj kolor do poziomu Rarity
                            break;
                        case Rarity.Rare:
                            character2Armor.BackColor = Color.LightBlue; // Dostosuj kolor do poziomu Rarity
                            break;
                        case Rarity.Epic:
                            character2Armor.BackColor = Color.DarkMagenta; // Dostosuj kolor do poziomu Rarity
                            break;
                        case Rarity.Legendary:
                            character2Armor.BackColor = Color.Orange; // Dostosuj kolor do poziomu Rarity
                            break;
                        default:
                            break;
                    }
                }
                else
                {
                    character2Armor.Text = "Brak";
                    character2Armor.AccessibleDescription = "  ";
                }
                character2ClassName.Text = Characters[1].Name;



                character3Name.Text = "Imie: " + Characters[2].Name;
                character3Level.Text = "Level: " + Characters[2].Level;
                character3Exp.Text = "Punkty EXP: " + Characters[2].ExperiencePoints;
                character3Strength.Text = "Sila: " + Characters[2].Strength;
                character3Dexterity.Text = "Zrecznosc: " + Characters[2].Dexterity;
                character3Intelligence.Text = "Inteligencja: " + Characters[2].Intelligence;
                character3Hp.Text = "HP: " + Characters[2].CurrentHP + "/" + Characters[2].MaxHP;
                character3Resistance.Text = "Odpornosc: " + Characters[2].Resistance;
                character3Crit.Text = "Szansa na Kryta: " + Characters[2].CritChance + "%";
                character3Initiative.Text = "Inicjatywa: " + Characters[2].Initiative;
                character3Dmg.Text = "Obrazenia Ataku: " + Characters[2].MinDmg + "-" + Characters[2].MaxDmg;
                if (Characters[2].CharacterType == CharacterType.Knight)
                {
                    Knight knight = (Knight)Characters[2];
                    character3Block.Text = "Szansa na Blok: " + knight.BlockChance;
                }
                else if (Characters[2].CharacterType == CharacterType.Rogue)
                {
                    Rogue rogue = (Rogue)Characters[2];
                    character3Block.Text = "Szansa na Unik: " + rogue.DodgeChance;
                }
                else if (Characters[2].CharacterType == CharacterType.Cleric)
                {
                    Cleric cleric = (Cleric)Characters[2];
                    character3Block.Text = "Szansa na Blogoslawienstwo: " + cleric.BlessingChance;
                }
                else if (Characters[2].CharacterType == CharacterType.Joker)
                {
                    Joker joker = (Joker)Characters[2];
                    character3Block.Text = "Szansa na DoubleAttack: " + joker.DoubleAtackChance;
                }
                else
                {
                    character3Block.Text = " ";
                }
                if (Characters[2].Weapon != null)
                {
                    character3Weapon.Text = Characters[2].Weapon.Name;
                    character3Weapon.AccessibleDescription = Characters[2].Weapon.Name + Environment.NewLine + Characters[2].Weapon.Description + Environment.NewLine + Characters[2].Weapon.Rarity + Environment.NewLine + "MinDMG: " + Characters[2].Weapon.MinDmg.ToString() +
                        Environment.NewLine + "MaxDMG: " + Characters[2].Weapon.MaxDmg.ToString() + Environment.NewLine + "Dostepne dla Klas:" + Environment.NewLine +
                    string.Join("," + Environment.NewLine, Characters[2].Weapon.AllowedCharacters.Select(characterType => characterType.ToString())) + Environment.NewLine + "Wartosc:" + Environment.NewLine + Characters[2].Weapon.SalesPrice.ToString();
                    switch (Characters[2].Weapon.Rarity)
                    {
                        case Rarity.Common:
                            character3Weapon.BackColor = Color.LightGray; // Dostosuj kolor do poziomu Rarity
                            break;
                        case Rarity.Rare:
                            character3Weapon.BackColor = Color.LightBlue; // Dostosuj kolor do poziomu Rarity
                            break;
                        case Rarity.Epic:
                            character3Weapon.BackColor = Color.DarkMagenta; // Dostosuj kolor do poziomu Rarity
                            break;
                        case Rarity.Legendary:
                            character3Weapon.BackColor = Color.Orange; // Dostosuj kolor do poziomu Rarity
                            break;
                        default:
                            break;
                    }
                }
                else
                {
                    character3Weapon.Text = "Brak";
                    character3Weapon.AccessibleDescription = "  ";
                }
                if (Characters[2].Armor != null)
                {
                    character3Armor.Text = Characters[2].Armor.Name;
                    character3Armor.AccessibleDescription = Characters[2].Armor.Name + Environment.NewLine + Characters[2].Armor.Description + Environment.NewLine + Characters[2].Armor.Rarity + Environment.NewLine + "DmgReduction: " + Characters[2].Armor.DmgReduction.ToString()
                    + Environment.NewLine + "Dostepne dla Klas:" + Environment.NewLine + string.Join("," + Environment.NewLine, Characters[2].Armor.AllowedCharacters.Select(characterType => characterType.ToString())) + Environment.NewLine + "Wartosc:" + Environment.NewLine + Characters[2].Armor.SalesPrice.ToString();
                    switch (Characters[2].Armor.Rarity)
                    {
                        case Rarity.Common:
                            character3Armor.BackColor = Color.LightGray; // Dostosuj kolor do poziomu Rarity
                            break;
                        case Rarity.Rare:
                            character3Armor.BackColor = Color.LightBlue; // Dostosuj kolor do poziomu Rarity
                            break;
                        case Rarity.Epic:
                            character3Armor.BackColor = Color.DarkMagenta; // Dostosuj kolor do poziomu Rarity
                            break;
                        case Rarity.Legendary:
                            character3Armor.BackColor = Color.Orange; // Dostosuj kolor do poziomu Rarity
                            break;
                        default:
                            break;
                    }
                }
                else
                {
                    character3Armor.Text = "Brak";
                    character3Armor.AccessibleDescription = "  ";
                }
                character3ClassName.Text = Characters[2].Name;




                character4Name.Text = "Imie: " + Characters[3].Name;
                character4Level.Text = "Level: " + Characters[3].Level;
                character4Exp.Text = "Punkty EXP: " + Characters[3].ExperiencePoints;
                character4Strength.Text = "Sila: " + Characters[3].Strength;
                character4Dexterity.Text = "Zrecznosc: " + Characters[3].Dexterity;
                character4Intelligence.Text = "Inteligencja: " + Characters[3].Intelligence;
                character4Hp.Text = "HP: " + Characters[3].CurrentHP + "/" + Characters[3].MaxHP;
                character4Resistance.Text = "Odpornosc: " + Characters[3].Resistance;
                character4Crit.Text = "Szansa na Kryta: " + Characters[3].CritChance + "%";
                character4Initiative.Text = "Inicjatywa: " + Characters[3].Initiative;
                character4Dmg.Text = "Obrazenia Ataku: " + Characters[3].MinDmg + "-" + Characters[3].MaxDmg;
                if (Characters[3].CharacterType == CharacterType.Knight)
                {
                    Knight knight = (Knight)Characters[3];
                    character4Block.Text = "Szansa na Blok: " + knight.BlockChance;
                }
                else if (Characters[3].CharacterType == CharacterType.Rogue)
                {
                    Rogue rogue = (Rogue)Characters[3];
                    character4Block.Text = "Szansa na Unik: " + rogue.DodgeChance;
                }
                else if (Characters[3].CharacterType == CharacterType.Cleric)
                {
                    Cleric cleric = (Cleric)Characters[3];
                    character4Block.Text = "Szansa na Blogoslawienstwo: " + cleric.BlessingChance;
                }
                else if (Characters[3].CharacterType == CharacterType.Joker)
                {
                    Joker joker = (Joker)Characters[3];
                    character4Block.Text = "Szansa na DoubleAttack: " + joker.DoubleAtackChance;
                }
                else
                {
                    character4Block.Text = " ";
                }
                if (Characters[3].Weapon != null)
                {
                    character4Weapon.Text = Characters[3].Weapon.Name;
                    character4Weapon.AccessibleDescription = Characters[3].Weapon.Name + Environment.NewLine + Characters[3].Weapon.Description + Environment.NewLine + Characters[3].Weapon.Rarity + Environment.NewLine + "MinDMG: " + Characters[3].Weapon.MinDmg.ToString() +
                        Environment.NewLine + "MaxDMG: " + Characters[3].Weapon.MaxDmg.ToString() + Environment.NewLine + "Dostepne dla Klas:" + Environment.NewLine +
                    string.Join("," + Environment.NewLine, Characters[3].Weapon.AllowedCharacters.Select(characterType => characterType.ToString())) + Environment.NewLine + "Wartosc:" + Environment.NewLine + Characters[3].Weapon.SalesPrice.ToString();
                    switch (Characters[3].Weapon.Rarity)
                    {
                        case Rarity.Common:
                            character4Weapon.BackColor = Color.LightGray; // Dostosuj kolor do poziomu Rarity
                            break;
                        case Rarity.Rare:
                            character4Weapon.BackColor = Color.LightBlue; // Dostosuj kolor do poziomu Rarity
                            break;
                        case Rarity.Epic:
                            character4Weapon.BackColor = Color.DarkMagenta; // Dostosuj kolor do poziomu Rarity
                            break;
                        case Rarity.Legendary:
                            character4Weapon.BackColor = Color.Orange; // Dostosuj kolor do poziomu Rarity
                            break;
                        default:
                            break;
                    }
                }
                else
                {
                    character4Weapon.Text = "Brak";
                    character4Weapon.AccessibleDescription = "  ";
                }
                if (Characters[3].Armor != null)
                {
                    character4Armor.Text = Characters[3].Armor.Name;
                    character4Armor.AccessibleDescription = Characters[3].Armor.Name + Environment.NewLine + Characters[3].Armor.Description + Environment.NewLine + Characters[3].Armor.Rarity + Environment.NewLine + "DmgReduction: " + Characters[3].Armor.DmgReduction.ToString()
                    + Environment.NewLine + "Dostepne dla Klas:" + Environment.NewLine + string.Join("," + Environment.NewLine, Characters[3].Armor.AllowedCharacters.Select(characterType => characterType.ToString())) + Environment.NewLine + "Wartosc:" + Environment.NewLine + Characters[3].Armor.SalesPrice.ToString();
                    switch (Characters[3].Armor.Rarity)
                    {
                        case Rarity.Common:
                            character4Armor.BackColor = Color.LightGray; // Dostosuj kolor do poziomu Rarity
                            break;
                        case Rarity.Rare:
                            character4Armor.BackColor = Color.LightBlue; // Dostosuj kolor do poziomu Rarity
                            break;
                        case Rarity.Epic:
                            character4Armor.BackColor = Color.DarkMagenta; // Dostosuj kolor do poziomu Rarity
                            break;
                        case Rarity.Legendary:
                            character4Armor.BackColor = Color.Orange; // Dostosuj kolor do poziomu Rarity
                            break;
                        default:
                            break;
                    }
                }
                else
                {
                    character4Armor.Text = "Brak";
                    character4Armor.AccessibleDescription = "  ";
                }
                character4ClassName.Text = Characters[3].Name;


            }
        }


        public event EventHandler WyruszButtonClicked;
        private void wyruszButton_Click(object sender, EventArgs e)
        {

            WyruszButtonClicked?.Invoke(this, EventArgs.Empty);
            SaveGameState();




        }


        public void SaveGameState()
        {

            GameState gameState = new GameState();
            gameState.chararacters = Characters;


       
            gameState.Ekwipunek = Ekwipunek;
            gameState.Shop = shopItems;
            gameState.Equiped = equipedItems;
            gameState.expeditions = Expeditons;
            gameState.gold = gold;
            gameState.eventQuest = eventQuest;
            gameState.eventResult = eventResult;
            gameState.gold = gold;

             string json = JsonConvert.SerializeObject(gameState, Formatting.Indented, new JsonSerializerSettings()
           {
                TypeNameHandling = TypeNameHandling.Auto,
          
            ReferenceLoopHandling = ReferenceLoopHandling.Serialize
             });
           File.WriteAllText("game_state.json", json);
        }

        //Inicjalizacja Przeciagania

        private void InitializeCharactersDragDrop()
        {



            character1Weapon.AllowDrop = true;
            character1Weapon.MouseDown += ItemMouseDown;
            character1Weapon.MouseHover += ItemMouseHover;
            character1Weapon.DragDrop += character1Weapon_DragDrop;
            character1Weapon.DragEnter += character1Weapon_DragEnter;
            character1Weapon.DragLeave += character1Weapon_DragLeave;
            character1Armor.AllowDrop = true;
            character1Armor.MouseDown += ItemMouseDown;
            character1Armor.MouseHover += ItemMouseHover;
            character1Armor.DragDrop += character1Armor_DragDrop;
            character1Armor.DragEnter += character1Armor_DragEnter;
            character1Armor.DragLeave += character1Armor_DragLeave;

            character2Weapon.AllowDrop = true;
            character2Weapon.MouseDown += ItemMouseDown;
            character2Weapon.MouseHover += ItemMouseHover;
            character2Weapon.DragDrop += character2Weapon_DragDrop;
            character2Weapon.DragEnter += character2Weapon_DragEnter;
            character2Weapon.DragLeave += character2Weapon_DragLeave;
            character2Armor.AllowDrop = true;
            character2Armor.MouseDown += ItemMouseDown;
            character2Armor.MouseHover += ItemMouseHover;
            character2Armor.DragDrop += character2Armor_DragDrop;
            character2Armor.DragEnter += character2Armor_DragEnter;
            character2Armor.DragLeave += character2Armor_DragLeave;

            character3Weapon.AllowDrop = true;
            character3Weapon.MouseDown += ItemMouseDown;
            character3Weapon.MouseHover += ItemMouseHover;
            character3Weapon.DragDrop += character3Weapon_DragDrop;
            character3Weapon.DragEnter += character3Weapon_DragEnter;
            character3Weapon.DragLeave += character3Weapon_DragLeave;
            character3Armor.AllowDrop = true;
            character3Armor.MouseDown += ItemMouseDown;
            character3Armor.MouseHover += ItemMouseHover;
            character3Armor.DragDrop += character3Armor_DragDrop;
            character3Armor.DragEnter += character3Armor_DragEnter;
            character3Armor.DragLeave += character3Armor_DragLeave;

            character4Weapon.AllowDrop = true;
            character4Weapon.MouseDown += ItemMouseDown;
            character4Weapon.MouseHover += ItemMouseHover;
            character4Weapon.DragDrop += character4Weapon_DragDrop;
            character4Weapon.DragEnter += character4Weapon_DragEnter;
            character4Weapon.DragLeave += character4Weapon_DragLeave;
            character4Armor.AllowDrop = true;
            character4Armor.MouseDown += ItemMouseDown;
            character4Armor.MouseHover += ItemMouseHover;
            character4Armor.DragDrop += character4Armor_DragDrop;
            character4Armor.DragEnter += character4Armor_DragEnter;
            character4Armor.DragLeave += character4Armor_DragLeave;






        }

        private void ItemMouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                Control control = (Control)sender;
                if (control.Text != "Brak")
                {
                    lastDraggedLabel = (Label)control;
                    control.DoDragDrop(control.Text, DragDropEffects.Move);
                }
            }
        }

        private void ItemMouseHover(object sender, EventArgs e)
        {
            Label label = sender as Label;
            if (label.AccessibleDescription != "  ")
            {
                toolTip1.SetToolTip(label, label.AccessibleDescription);
            }

        }





        //Przeciaganie character1

        private void character1Weapon_DragEnter(object sender, DragEventArgs e)
        {
            //knightWeapon.BackColor = Color.LightGray;
            e.Effect = DragDropEffects.Move;
        }

        private void character1Weapon_DragLeave(object sender, EventArgs e)
        {
            //knightWeapon.BackColor = SystemColors.Control;
        }

        private void character1Weapon_DragDrop(object sender, DragEventArgs e)
        {
            if (!CheckLabel(lastDraggedLabel))
            {
                try
                {
                    string draggedItemText = (string)e.Data.GetData(DataFormats.Text);
                    IEkwipunek itemToSelect = Ekwipunek.FirstOrDefault(item => item.Wypisz() == draggedItemText && item is Weapon);

                    if (itemToSelect != null)
                    {
                        if (character1Weapon.Text != "Brak")
                        {
                            itemToSelect.Equip(Characters[0]);
                            string oldItem = character1Weapon.Text;
                            AddItemToInventory(oldItem, false);
                            equipedItems.Add(itemToSelect);
                            character1Weapon.Text = draggedItemText;
                            character1Weapon.BackColor = SystemColors.Control;

                            Ekwipunek.Remove(itemToSelect);
                            RefreshInventory();
                            Characters[0].UpdateStats();
                            RefreshStats();
                        }
                        else
                        {
                            itemToSelect.Equip(Characters[0]);
                            equipedItems.Add(itemToSelect);
                            character1Weapon.Text = draggedItemText;
                            character1Weapon.BackColor = SystemColors.Control;

                            Ekwipunek.Remove(itemToSelect);
                            RefreshInventory();
                            Characters[0].UpdateStats();
                            RefreshStats();
                        }
                        PlayEquipWeaponSound();
                    }

                }
                catch (ClassWeaponException ex)
                {
                    MessageBox.Show(ex.Message, "Weapon Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }


        }
        private void character1Armor_DragEnter(object sender, DragEventArgs e)
        {
            //knightArmor.BackColor = Color.LightGray;
            e.Effect = DragDropEffects.Move;
        }

        private void character1Armor_DragLeave(object sender, EventArgs e)
        {
            //knightArmor.BackColor = SystemColors.Control;
        }

        private void character1Armor_DragDrop(object sender, DragEventArgs e)
        {
            if (!CheckLabel(lastDraggedLabel))
            {
                try
                {
                    string draggedItemText = (string)e.Data.GetData(DataFormats.Text);
                    IEkwipunek itemToSelect = Ekwipunek.FirstOrDefault(item => item.Wypisz() == draggedItemText && item is Armor);

                    if (itemToSelect != null)
                    {
                        if (character1Armor.Text != "Brak")
                        {
                            itemToSelect.Equip(Characters[0]);
                            string oldItem = character1Armor.Text;
                            AddItemToInventory(oldItem, false);
                            equipedItems.Add(itemToSelect);
                            character1Armor.Text = draggedItemText;
                            character1Armor.BackColor = SystemColors.Control;

                            Ekwipunek.Remove(itemToSelect);
                            RefreshInventory();
                            Characters[0].UpdateStats();
                            RefreshStats();
                        }
                        else
                        {
                            itemToSelect.Equip(Characters[0]);
                            equipedItems.Add(itemToSelect);
                            character1Armor.Text = draggedItemText;
                            character1Armor.BackColor = SystemColors.Control;

                            Ekwipunek.Remove(itemToSelect);
                            RefreshInventory();
                            Characters[0].UpdateStats();
                            RefreshStats();
                        }
                        PlayEquipArmorSound();
                    }

                }
                catch (ClassArmorException ex)
                {
                    MessageBox.Show(ex.Message, "Weapon Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }


        }


        //Przeciaganie character2

        private void character2Weapon_DragEnter(object sender, DragEventArgs e)
        {
            //rogueWeapon.BackColor = Color.LightGray;
            e.Effect = DragDropEffects.Move;
        }

        private void character2Weapon_DragLeave(object sender, EventArgs e)
        {
            //rogueWeapon.BackColor = SystemColors.Control;
        }

        private void character2Weapon_DragDrop(object sender, DragEventArgs e)
        {
            if (!CheckLabel(lastDraggedLabel))
            {
                try
                {
                    string draggedItemText = (string)e.Data.GetData(DataFormats.Text);
                    IEkwipunek itemToSelect = Ekwipunek.FirstOrDefault(item => item.Wypisz() == draggedItemText && item is Weapon);

                    if (itemToSelect != null)
                    {
                        if (character2Weapon.Text != "Brak")
                        {
                            itemToSelect.Equip(Characters[1]);
                            string oldItem = character2Weapon.Text;
                            AddItemToInventory(oldItem, false);
                            equipedItems.Add(itemToSelect);
                            character2Weapon.Text = draggedItemText;
                            character2Weapon.BackColor = SystemColors.Control;

                            Ekwipunek.Remove(itemToSelect);
                            RefreshInventory();
                            Characters[1].UpdateStats();
                            RefreshStats();
                        }
                        else
                        {
                            itemToSelect.Equip(Characters[1]);
                            equipedItems.Add(itemToSelect);
                            character2Weapon.Text = draggedItemText;
                            character2Weapon.BackColor = SystemColors.Control;

                            Ekwipunek.Remove(itemToSelect);
                            RefreshInventory();
                            Characters[1].UpdateStats();
                            RefreshStats();
                        }
                        PlayEquipWeaponSound();
                    }

                }
                catch (ClassWeaponException ex)
                {
                    MessageBox.Show(ex.Message, "Weapon Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }


        }
        private void character2Armor_DragEnter(object sender, DragEventArgs e)
        {
            //rogueArmor.BackColor = Color.LightGray;
            e.Effect = DragDropEffects.Move;
        }

        private void character2Armor_DragLeave(object sender, EventArgs e)
        {
            //rogueArmor.BackColor = SystemColors.Control;
        }

        private void character2Armor_DragDrop(object sender, DragEventArgs e)
        {
            if (!CheckLabel(lastDraggedLabel))
            {
                try
                {
                    string draggedItemText = (string)e.Data.GetData(DataFormats.Text);
                    IEkwipunek itemToSelect = Ekwipunek.FirstOrDefault(item => item.Wypisz() == draggedItemText && item is Armor);

                    if (itemToSelect != null)
                    {
                        if (character2Armor.Text != "Brak")
                        {
                            itemToSelect.Equip(Characters[1]);
                            string oldItem = character2Armor.Text;
                            AddItemToInventory(oldItem, false);
                            equipedItems.Add(itemToSelect);
                            character2Armor.Text = draggedItemText;
                            character2Armor.BackColor = SystemColors.Control;

                            Ekwipunek.Remove(itemToSelect);
                            RefreshInventory();
                            Characters[1].UpdateStats();
                            RefreshStats();
                        }
                        else
                        {
                            itemToSelect.Equip(Characters[1]);
                            equipedItems.Add(itemToSelect);
                            character2Armor.Text = draggedItemText;
                            character2Armor.BackColor = SystemColors.Control;

                            Ekwipunek.Remove(itemToSelect);
                            RefreshInventory();
                            Characters[1].UpdateStats();
                            RefreshStats();
                        }
                        PlayEquipArmorSound();
                    }

                }
                catch (ClassArmorException ex)
                {
                    MessageBox.Show(ex.Message, "Weapon Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }


        }




        //Przeciaganie character3

        private void character3Weapon_DragEnter(object sender, DragEventArgs e)
        {
            //clericWeapon.BackColor = Color.LightGray;
            e.Effect = DragDropEffects.Move;
        }

        private void character3Weapon_DragLeave(object sender, EventArgs e)
        {
            //clericWeapon.BackColor = SystemColors.Control;
        }

        private void character3Weapon_DragDrop(object sender, DragEventArgs e)
        {
            if (!CheckLabel(lastDraggedLabel))
            {
                try
                {
                    string draggedItemText = (string)e.Data.GetData(DataFormats.Text);
                    IEkwipunek itemToSelect = Ekwipunek.FirstOrDefault(item => item.Wypisz() == draggedItemText && item is Weapon);

                    if (itemToSelect != null)
                    {
                        if (character3Weapon.Text != "Brak")
                        {
                            itemToSelect.Equip(Characters[2]);
                            string oldItem = character3Weapon.Text;
                            AddItemToInventory(oldItem, false);
                            equipedItems.Add(itemToSelect);
                            character3Weapon.Text = draggedItemText;
                            character3Weapon.BackColor = SystemColors.Control;

                            Ekwipunek.Remove(itemToSelect);
                            RefreshInventory();
                            Characters[2].UpdateStats();
                            RefreshStats();
                        }
                        else
                        {
                            itemToSelect.Equip(Characters[2]);
                            equipedItems.Add(itemToSelect);
                            character3Weapon.Text = draggedItemText;
                            character3Weapon.BackColor = SystemColors.Control;

                            Ekwipunek.Remove(itemToSelect);
                            RefreshInventory();
                            Characters[2].UpdateStats();
                            RefreshStats();
                        }
                        PlayEquipWeaponSound();

                    }

                }
                catch (ClassWeaponException ex)
                {
                    MessageBox.Show(ex.Message, "Weapon Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }


        }
        private void character3Armor_DragEnter(object sender, DragEventArgs e)
        {
            //clericArmor.BackColor = Color.LightGray;
            e.Effect = DragDropEffects.Move;
        }

        private void character3Armor_DragLeave(object sender, EventArgs e)
        {
            //clericArmor.BackColor = SystemColors.Control;
        }

        private void character3Armor_DragDrop(object sender, DragEventArgs e)
        {
            if (!CheckLabel(lastDraggedLabel))
            {
                try
                {
                    string draggedItemText = (string)e.Data.GetData(DataFormats.Text);
                    IEkwipunek itemToSelect = Ekwipunek.FirstOrDefault(item => item.Wypisz() == draggedItemText && item is Armor);

                    if (itemToSelect != null)
                    {
                        if (character3Armor.Text != "Brak")
                        {
                            itemToSelect.Equip(Characters[2]);
                            string oldItem = character3Armor.Text;
                            AddItemToInventory(oldItem, false);
                            equipedItems.Add(itemToSelect);
                            character3Armor.Text = draggedItemText;
                            character3Armor.BackColor = SystemColors.Control;

                            Ekwipunek.Remove(itemToSelect);
                            RefreshInventory();
                            Characters[2].UpdateStats();
                            RefreshStats();
                        }
                        else
                        {
                            itemToSelect.Equip(Characters[2]);
                            equipedItems.Add(itemToSelect);
                            character3Armor.Text = draggedItemText;
                            character3Armor.BackColor = SystemColors.Control;

                            Ekwipunek.Remove(itemToSelect);
                            RefreshInventory();
                            Characters[2].UpdateStats();
                            RefreshStats();
                        }
                        PlayEquipArmorSound();
                    }

                }
                catch (ClassArmorException ex)
                {
                    MessageBox.Show(ex.Message, "Weapon Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }


        }




        //Przeciaganie character4

        private void character4Weapon_DragEnter(object sender, DragEventArgs e)
        {
            //jokerWeapon.BackColor = Color.LightGray;
            e.Effect = DragDropEffects.Move;
        }

        private void character4Weapon_DragLeave(object sender, EventArgs e)
        {
            //jokerWeapon.BackColor = SystemColors.Control;
        }

        private void character4Weapon_DragDrop(object sender, DragEventArgs e)
        {
            if (!CheckLabel(lastDraggedLabel))
            {
                try
                {
                    string draggedItemText = (string)e.Data.GetData(DataFormats.Text);
                    IEkwipunek itemToSelect = Ekwipunek.FirstOrDefault(item => item.Wypisz() == draggedItemText && item is Weapon);

                    if (itemToSelect != null)
                    {
                        if (character4Weapon.Text != "Brak")
                        {
                            itemToSelect.Equip(Characters[3]);
                            string oldItem = character4Weapon.Text;
                            AddItemToInventory(oldItem, false);
                            equipedItems.Add(itemToSelect);
                            character4Weapon.Text = draggedItemText;
                            character4Weapon.BackColor = SystemColors.Control;

                            Ekwipunek.Remove(itemToSelect);
                            RefreshInventory();
                            Characters[3].UpdateStats();
                            RefreshStats();
                        }
                        else
                        {
                            itemToSelect.Equip(Characters[3]);
                            equipedItems.Add(itemToSelect);
                            character4Weapon.Text = draggedItemText;
                            character4Weapon.BackColor = SystemColors.Control;

                            Ekwipunek.Remove(itemToSelect);
                            RefreshInventory();
                            Characters[3].UpdateStats();
                            RefreshStats();

                        }
                        PlayEquipWeaponSound();

                    }

                }
                catch (ClassWeaponException ex)
                {
                    MessageBox.Show(ex.Message, "Weapon Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }


        }
        private void character4Armor_DragEnter(object sender, DragEventArgs e)
        {
            //jokerArmor.BackColor = Color.LightGray;
            e.Effect = DragDropEffects.Move;
        }

        private void character4Armor_DragLeave(object sender, EventArgs e)
        {
            //jokerArmor.BackColor = SystemColors.Control;
        }

        private void character4Armor_DragDrop(object sender, DragEventArgs e)
        {
            if (!CheckLabel(lastDraggedLabel))
            {
                try
                {
                    string draggedItemText = (string)e.Data.GetData(DataFormats.Text);
                    IEkwipunek itemToSelect = Ekwipunek.FirstOrDefault(item => item.Wypisz() == draggedItemText && item is Armor);

                    if (itemToSelect != null)
                    {
                        if (character4Armor.Text != "Brak")
                        {
                            itemToSelect.Equip(Characters[3]);
                            string oldItem = character4Armor.Text;
                            AddItemToInventory(oldItem, false);
                            equipedItems.Add(itemToSelect);
                            character4Armor.Text = draggedItemText;
                            character4Armor.BackColor = SystemColors.Control;

                            Ekwipunek.Remove(itemToSelect);
                            RefreshInventory();
                            Characters[3].UpdateStats();
                            RefreshStats();
                        }
                        else
                        {
                            itemToSelect.Equip(Characters[3]);
                            equipedItems.Add(itemToSelect);
                            character4Armor.Text = draggedItemText;
                            character4Armor.BackColor = SystemColors.Control;

                            Ekwipunek.Remove(itemToSelect);
                            RefreshInventory();
                            Characters[3].UpdateStats();
                            RefreshStats();

                        }
                        PlayEquipArmorSound();
                    }

                }
                catch (ClassArmorException ex)
                {
                    MessageBox.Show(ex.Message, "Weapon Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }


        }








        // Przeciaganie do ekwipunka


        private void Inventory_DragEnter(object sender, DragEventArgs e)
        {
            Control control = (Control)sender;
            //control.BackColor = Color.LightGray;
            e.Effect = DragDropEffects.Move;
        }

        private void Inventory_DragLeave(object sender, EventArgs e)
        {
            Control control = (Control)sender;
            //control.BackColor = SystemColors.Control;
        }

        private void Inventory_DragDrop(object sender, DragEventArgs e)
        {
            Control control = (Control)sender;
            //control.BackColor = SystemColors.Control;

            string draggedItemText = (string)e.Data.GetData(DataFormats.Text);


            if (lastDraggedLabel != null && CheckLabel(lastDraggedLabel))
            {
                lastDraggedLabel.Text = "Brak";
                if (lastDraggedLabel == character1Weapon)
                {
                    Characters[0].Weapon = null;
                    PlayEquipWeaponSound();
                }
                Characters[0].UpdateStats();
                if (lastDraggedLabel == character1Armor)
                {
                    Characters[0].Armor = null;
                    PlayEquipArmorSound();
                }
                Characters[0].UpdateStats();
                if (lastDraggedLabel == character2Weapon)
                {
                    Characters[1].Weapon = null;
                    PlayEquipWeaponSound();
                }
                Characters[1].UpdateStats();
                if (lastDraggedLabel == character2Armor)
                {
                    Characters[1].Armor = null;
                    PlayEquipArmorSound();
                }
                Characters[1].UpdateStats();
                if (lastDraggedLabel == character3Weapon)
                {
                    Characters[2].Weapon = null;
                    PlayEquipWeaponSound();
                }
                Characters[2].UpdateStats();
                if (lastDraggedLabel == character3Armor)
                {
                    Characters[2].Armor = null;
                    PlayEquipArmorSound();
                }
                Characters[2].UpdateStats();
                if (lastDraggedLabel == character4Weapon)
                {
                    Characters[3].Weapon = null;
                    PlayEquipWeaponSound();
                }
                Characters[3].UpdateStats();
                if (lastDraggedLabel == character4Armor)
                {
                    Characters[3].Armor = null;
                    PlayEquipArmorSound();
                }
                Characters[3].UpdateStats();


                AddItemToInventory(draggedItemText, false);
                RefreshStats();
                lastDraggedLabel = null;

            }
            else if (Shop.Controls.Contains(lastDraggedLabel))
            {
                AddItemToInventory(draggedItemText, true);
                lastDraggedLabel = null;
            }

        }


        private void AddItemToInventory(string itemName, bool ShopItem)
        {
            if (ShopItem)
            {
                int price;
                IEkwipunek itemToAdd = shopItems.FirstOrDefault(item => item != null && item.Wypisz() == itemName);
                if (itemToAdd is Weapon)
                {
                    Weapon weapon = (Weapon)itemToAdd;
                    price = (int)weapon.Price;
                }
                else
                {
                    Armor armor = (Armor)itemToAdd;
                    price = (int)armor.Price;
                }

                if (price > gold)
                {
                    MessageBox.Show("Brakuje ci " + (price - gold) + " golda", "Shop Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    Ekwipunek.Add(itemToAdd);
                    shopItems.Remove(itemToAdd);
                    gold -= price;
                    RefreshInventory();
                    RefreshShop();
                    PlaySellAndBuySound();
                }


            }
            else
            {
                IEkwipunek itemToAdd = equipedItems.FirstOrDefault(item => item != null && item.Wypisz() == itemName);
                if (itemToAdd != null)
                {
                    Ekwipunek.Add(itemToAdd);
                    equipedItems.Remove(itemToAdd);
                    RefreshInventory();
                }
            }

        }

        //Logika Przenoszenia
        private bool CheckLabel(Label label)
        {
            if (label == character1Weapon ||
                label == character1Armor ||
                label == character2Weapon ||
                label == character2Armor ||
                label == character3Weapon ||
                label == character3Armor ||
                label == character4Weapon ||
                label == character4Armor)
            {
                return true;
            }
            else return false;
        }



        // Odswiezanie ekwipunku
        private void RefreshInventory()
        {

            goldLabel.Text = "Złoto: " + gold.ToString();
            Inventory.AutoScroll = true;
            Inventory.Controls.Clear();

            foreach (IEkwipunek item in Ekwipunek)
            {
                Label label = new Label();
                label.Text = item.Wypisz();
                label.AutoSize = false;
                label.Height = 60;
                label.TextAlign = ContentAlignment.MiddleCenter;
                label.BorderStyle = BorderStyle.FixedSingle;
                if (item is Weapon)
                {
                    Weapon weapon = (Weapon)item;
                    label.AccessibleDescription = weapon.Name + Environment.NewLine + weapon.Description + Environment.NewLine + weapon.Rarity + Environment.NewLine + "MinDMG: " + weapon.MinDmg.ToString() +
                    Environment.NewLine + "MaxDMG: " + weapon.MaxDmg.ToString() + Environment.NewLine + "Dostepne dla Klas:" + Environment.NewLine +
                    string.Join("," + Environment.NewLine, weapon.AllowedCharacters.Select(characterType => characterType.ToString())) + Environment.NewLine + "Wartosc:" + Environment.NewLine + weapon.SalesPrice.ToString();
                    switch (weapon.Rarity)
                    {
                        case Rarity.Common:
                            label.BackColor = Color.LightGray; // Dostosuj kolor do poziomu Rarity
                            break;
                        case Rarity.Rare:
                            label.BackColor = Color.LightBlue; // Dostosuj kolor do poziomu Rarity
                            break;
                        case Rarity.Epic:
                            label.BackColor = Color.DarkMagenta; // Dostosuj kolor do poziomu Rarity
                            break;
                        case Rarity.Legendary:
                            label.BackColor = Color.Orange; // Dostosuj kolor do poziomu Rarity
                            break;
                        default:
                            break;
                    }
                }
                if (item is Armor)
                {
                    Armor armor = (Armor)item;
                    label.AccessibleDescription = armor.Name + Environment.NewLine + armor.Description + Environment.NewLine + armor.Rarity + Environment.NewLine + "DmgReduction: " + armor.DmgReduction.ToString() + Environment.NewLine +
                    "Dostepne dla Klas:" + Environment.NewLine + string.Join("," + Environment.NewLine, armor.AllowedCharacters.Select(characterType => characterType.ToString())) + Environment.NewLine + "Wartosc:" + Environment.NewLine + armor.SalesPrice.ToString();
                    switch (armor.Rarity)
                    {
                        case Rarity.Common:
                            label.BackColor = Color.LightGray; // Dostosuj kolor do poziomu Rarity
                            break;
                        case Rarity.Rare:
                            label.BackColor = Color.LightBlue; // Dostosuj kolor do poziomu Rarity
                            break;
                        case Rarity.Epic:
                            label.BackColor = Color.DarkMagenta; // Dostosuj kolor do poziomu Rarity
                            break;
                        case Rarity.Legendary:
                            label.BackColor = Color.Orange; // Dostosuj kolor do poziomu Rarity
                            break;
                        default:
                            break;
                    }
                }
                Inventory.Controls.Add(label);
            }
            foreach (Control control in Inventory.Controls)
            {
                control.MouseDown += ItemMouseDown;
                control.MouseHover += ItemMouseHover;
            }
            Inventory.AllowDrop = true;
            Inventory.DragEnter += Inventory_DragEnter;
            Inventory.DragLeave += Inventory_DragLeave;
            Inventory.DragDrop += Inventory_DragDrop;

        }


        //Sortowanie Ekwipunku

        private void SortAll_Click(object sender, EventArgs e)
        {
            Ekwipunek = Ekwipunek.OrderBy(item => item.Wypisz()).ToList();
            RefreshInventory();
        }

        private void SortKnight_Click(object sender, EventArgs e)
        {
            Ekwipunek = SortByAllowedCharacters(CharacterType.Knight);
            RefreshInventory();
        }

        private void SortRogue_Click(object sender, EventArgs e)
        {
            Ekwipunek = SortByAllowedCharacters(CharacterType.Rogue);
            RefreshInventory();
        }


        private void SortCleric_Click(object sender, EventArgs e)
        {
            Ekwipunek = SortByAllowedCharacters(CharacterType.Cleric);
            RefreshInventory();
        }

        private void SortJoker_Click(object sender, EventArgs e)
        {
            Ekwipunek = SortByAllowedCharacters(CharacterType.Joker);
            RefreshInventory();
        }


        //Sklep generowanie towaru itp
        public void GenerateShop()
        {
            shopItems.Clear();
            //generowanie zawartosci sklepu
            Random r = new Random();
            do
            {
                int i = r.Next(0, pulaEkwipunku.Count);
                if (pulaEkwipunku[i] is Armor)
                {
                    Armor armor = (Armor)pulaEkwipunku[i];
                    if ((int)armor.Rarity == 1)
                    {
                        shopItems.Add(new Armor((Armor)pulaEkwipunku[i]));
                    }

                }
                else
                {
                    Weapon weapon = (Weapon)pulaEkwipunku[i];
                    if ((int)weapon.Rarity == 1)
                    {
                        shopItems.Add(new Weapon((Weapon)pulaEkwipunku[i]));
                    }
                }
            } while (shopItems.Count != 4);
            do
            {
                int i = r.Next(0, pulaEkwipunku.Count);
                if (pulaEkwipunku[i] is Armor)
                {
                    Armor armor = (Armor)pulaEkwipunku[i];
                    if ((int)armor.Rarity == 2)
                    {
                        shopItems.Add(new Armor((Armor)pulaEkwipunku[i]));
                    }

                }
                else
                {
                    Weapon weapon = (Weapon)pulaEkwipunku[i];
                    if ((int)weapon.Rarity == 2)
                    {
                        shopItems.Add(new Weapon((Weapon)pulaEkwipunku[i]));
                    }
                }
            } while (shopItems.Count != 6);
            RefreshShop();

        }


        private void Shop_DragEnter(object sender, DragEventArgs e)
        {
            Control control = (Control)sender;
            //control.BackColor = Color.LightGray;
            e.Effect = DragDropEffects.Move;
        }

        private void Shop_DragLeave(object sender, EventArgs e)
        {
            Control control = (Control)sender;
            //control.BackColor = SystemColors.Control;
        }

        private async void Shop_DragDrop(object sender, DragEventArgs e)
        {

            if (lastDraggedLabel != null && !CheckLabel(lastDraggedLabel) && Inventory.Controls.Contains(lastDraggedLabel))
            {
                Control control = (Control)sender;
                //control.BackColor = SystemColors.Control;
                string draggedItemText = (string)e.Data.GetData(DataFormats.Text);
                IEkwipunek itemToSelect = Ekwipunek.FirstOrDefault(item => item.Wypisz() == draggedItemText);
                if (itemToSelect is Weapon)
                {
                    Weapon weapon = (Weapon)itemToSelect;
                    gold += (int)weapon.SalesPrice;
                }
                else
                {
                    Armor armor = (Armor)itemToSelect;
                    gold += (int)armor.SalesPrice;
                }

                Ekwipunek.Remove(itemToSelect);
                RefreshInventory();
                lastDraggedLabel = null;

                PlaySellAndBuySound();
            }

        }

        private void Roll_Click(object sender, EventArgs e)
        {
            if (25 > gold)
            {
                MessageBox.Show("Brakuje ci " + (25 - gold) + " golda", "Shop Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                gold -= 25;
                RefreshInventory();
                GenerateShop();
                PlayRollShopSound();
            }
        }



        // odswiezanie sklepu
        private void RefreshShop()
        {
            Shop.Controls.Clear();

            foreach (IEkwipunek item in shopItems)
            {
                Label label = new Label();
                label.Text = item.Wypisz();
                label.AutoSize = false;
                label.Height = 60;
                label.TextAlign = ContentAlignment.MiddleCenter;
                label.BorderStyle = BorderStyle.FixedSingle;
                if (item is Weapon)
                {
                    Weapon weapon = (Weapon)item;
                    label.AccessibleDescription = weapon.Name + Environment.NewLine + weapon.Description + Environment.NewLine + weapon.Rarity + Environment.NewLine + "MinDMG: " + weapon.MinDmg.ToString() +
                    Environment.NewLine + "MaxDMG: " + weapon.MaxDmg.ToString() + Environment.NewLine + "Dostepne dla Klas:" + Environment.NewLine +
                    string.Join("," + Environment.NewLine, weapon.AllowedCharacters.Select(characterType => characterType.ToString())) + Environment.NewLine + "Cena:" + Environment.NewLine + weapon.Price.ToString();
                    switch (weapon.Rarity)
                    {
                        case Rarity.Common:
                            label.BackColor = Color.LightGray;
                            break;
                        case Rarity.Rare:
                            label.BackColor = Color.LightBlue;
                            break;
                        case Rarity.Epic:
                            label.BackColor = Color.DarkMagenta;
                            break;
                        case Rarity.Legendary:
                            label.BackColor = Color.Orange;
                            break;
                        default:
                            break;
                    }
                }
                if (item is Armor)
                {
                    Armor armor = (Armor)item;
                    label.AccessibleDescription = armor.Name + Environment.NewLine + armor.Description + Environment.NewLine + armor.Rarity + Environment.NewLine + "DmgReduction: " + armor.DmgReduction.ToString() + Environment.NewLine +
                    "Dostepne dla Klas:" + Environment.NewLine + string.Join("," + Environment.NewLine, armor.AllowedCharacters.Select(characterType => characterType.ToString())) + Environment.NewLine + "Cena:" + Environment.NewLine + armor.Price.ToString();
                    switch (armor.Rarity)
                    {
                        case Rarity.Common:
                            label.BackColor = Color.LightGray;
                            break;
                        case Rarity.Rare:
                            label.BackColor = Color.LightBlue;
                            break;
                        case Rarity.Epic:
                            label.BackColor = Color.DarkMagenta;
                            break;
                        case Rarity.Legendary:
                            label.BackColor = Color.Orange;
                            break;
                        default:
                            break;
                    }
                }
                Shop.Controls.Add(label);
            }
            foreach (Control control in Shop.Controls)
            {
                control.MouseDown += ItemMouseDown;
                control.MouseHover += ItemMouseHover;
            }
            Shop.AllowDrop = true;
            Shop.DragEnter += Shop_DragEnter;
            Shop.DragLeave += Shop_DragLeave;
            Shop.DragDrop += Shop_DragDrop;
        }




        public void AfterExpedition(bool wynik, Expedition wyprawa)
        {

            if (wynik)
            {
                Characters[0].GainExperience(wyprawa.ExperienceGains);
                Characters[1].GainExperience(wyprawa.ExperienceGains);
                Characters[2].GainExperience(wyprawa.ExperienceGains);
                Characters[3].GainExperience(wyprawa.ExperienceGains);


                gold += wyprawa.Gold;
                foreach (Weapon weapon in wyprawa.WeaponRewards)
                {
                    Ekwipunek.Add(new Weapon(weapon));
                }
                foreach (Armor armor in wyprawa.ArmorRewards)
                {
                    Ekwipunek.Add(new Armor(armor));
                }
                RefreshInventory();
            }
            else
            {

                equipedItems.Clear();
                Characters[0].Weapon = null; Characters[0].UpdateStats();
                Characters[0].Armor = null; Characters[0].UpdateStats();
                Characters[1].Weapon = null; Characters[1].UpdateStats();
                Characters[1].Armor = null; Characters[1].UpdateStats();
                Characters[2].Weapon = null; Characters[2].UpdateStats();
                Characters[2].Armor = null; Characters[2].UpdateStats();
                Characters[3].Weapon = null; Characters[3].UpdateStats();
                Characters[3].Armor = null; Characters[3].UpdateStats();
                RefreshStats();
            }
            Characters[0].CurrentHP = Characters[0].MaxHP;
            Characters[1].CurrentHP = Characters[1].MaxHP;
            Characters[2].CurrentHP = Characters[2].MaxHP;
            Characters[3].CurrentHP = Characters[3].MaxHP;
        }



        private void exitButton_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Czy aby napewno chcesz stad uciec?", "Straciłeś Nadzieje?", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                SaveGameState();
                Application.Exit();
            }
        }
        private void PlaySellAndBuySound()
        {
            Stream equipWeaponStream = Properties.Resources.sellandbuySound;
            MemoryStream memoryStream = new MemoryStream();
            equipWeaponStream.CopyTo(memoryStream);
            memoryStream.Position = 0;
            WaveStream waveStream = new WaveFileReader(memoryStream);

            WaveOut out1 = new();
            out1.Init(waveStream);
            out1.Play();

            out1.PlaybackStopped += (s, args) =>
            {
                waveStream.Dispose();
            };
        }
        private void PlayEquipWeaponSound()
        {
            Stream equipWeaponStream = Properties.Resources.equipWeapon;
            MemoryStream memoryStream = new MemoryStream();
            equipWeaponStream.CopyTo(memoryStream);
            memoryStream.Position = 0;
            WaveStream waveStream = new WaveFileReader(memoryStream);

            WaveOut out1 = new();
            out1.Init(waveStream);
            out1.Play();

            out1.PlaybackStopped += (s, args) =>
            {
                waveStream.Dispose();
            };

        }
        private void PlayEquipArmorSound()
        {
            Stream equipWeaponStream = Properties.Resources.equipArmor;
            MemoryStream memoryStream = new MemoryStream();
            equipWeaponStream.CopyTo(memoryStream);
            memoryStream.Position = 0;
            WaveStream waveStream = new WaveFileReader(memoryStream);

            WaveOut out1 = new();
            out1.Init(waveStream);
            out1.Play();

            out1.PlaybackStopped += (s, args) =>
            {
                waveStream.Dispose();
            };
        }
        private void PlayRollShopSound()
        {
            Stream equipWeaponStream = Properties.Resources.rollSound;
            MemoryStream memoryStream = new MemoryStream();
            equipWeaponStream.CopyTo(memoryStream);
            memoryStream.Position = 0;
            WaveStream waveStream = new WaveFileReader(memoryStream);

            WaveOut out1 = new();
            out1.Init(waveStream);
            out1.Play();

            out1.PlaybackStopped += (s, args) =>
            {
                waveStream.Dispose();
            };
        }


        private List<IEkwipunek> SortByAllowedCharacters(CharacterType characterType)
        {
            return Ekwipunek.OrderByDescending(item =>
            {
                if (item is Weapon weapon)
                {
                    return weapon.AllowedCharacters.Contains(characterType) ? 1 : 0;
                }
                else if (item is Armor armor)
                {
                    return armor.AllowedCharacters.Contains(characterType) ? 1 : 0;
                }
                return -1;
            }).ToList();
        }

        
    }
}
