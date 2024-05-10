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
        public List<Character> characters = new List<Character>();
        public List<Expedition> expeditons= new List<Expedition>();
        public List<IEkwipunek> inventory= new List<IEkwipunek>();
        public List<IEkwipunek> equipedItems = new List<IEkwipunek>();
        public List<IEkwipunek> shopItemsPool=new List<IEkwipunek>();
        public List<IEkwipunek> shopItems = new List<IEkwipunek>();
        public int gold = 0;
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
                    character1Picture.Image = (Image)Properties.Resources.ResourceManager.GetObject(characters[0].CharacterType.ToString().ToLower()+"Picture");
                    character2Picture.Image = (Image)Properties.Resources.ResourceManager.GetObject(characters[1].CharacterType.ToString().ToLower() + "Picture");
                    character3Picture.Image = (Image)Properties.Resources.ResourceManager.GetObject(characters[2].CharacterType.ToString().ToLower() + "Picture");
                    character4Picture.Image = (Image)Properties.Resources.ResourceManager.GetObject(characters[3].CharacterType.ToString().ToLower() + "Picture");
                }



            }
        }


        private void RefreshStats()
        {

            if (characters != null && characters.Any())
            {

                character1Name.Text = "Name: " + characters[0].Name;
                character1Level.Text = "Level: " + characters[0].Level;
                character1Exp.Text = "Experience Points: " + characters[0].ExperiencePoints;
                character1Strength.Text = "Strength: " + characters[0].Strength;
                character1Dexterity.Text = "Dexterity: " + characters[0].Dexterity;
                character1Intelligence.Text = "Intelligence: " + characters[0].Intelligence;
                character1Hp.Text = "HP: " + characters[0].CurrentHP + "/" + characters[0].MaxHP;
                character1Resistance.Text = "Resistance: " + characters[0].Resistance;
                character1Crit.Text = "Critical Chance: " + characters[0].CritChance + "%";
                character1Initiative.Text = "Initiative: " + characters[0].Initiative;
                character1Dmg.Text = "Attack Damage: " + characters[0].MinDmg + "-" + characters[0].MaxDmg;
                if (characters[0].CharacterType == CharacterType.Knight)
                {
                    Knight knight = (Knight)characters[0];
                    character1Block.Text = "Block Chance: " + knight.BlockChance;
                }
                else if (characters[0].CharacterType == CharacterType.Rogue)
                {
                    Rogue rogue = (Rogue)characters[0];
                    character1Block.Text = "Dodge Chance: " + rogue.DodgeChance;
                }
                else if (characters[0].CharacterType == CharacterType.Cleric)
                {
                    Cleric cleric = (Cleric)characters[0];
                    character1Block.Text = "Blessing Chance: " + cleric.BlessingChance;
                }
                else if (characters[0].CharacterType == CharacterType.Joker)
                {
                    Joker joker = (Joker)characters[0];
                    character1Block.Text = "DoubleAttack Chance: " + joker.DoubleAtackChance;
                }
                else
                {
                    character1Block.Text = " ";
                }

                if (characters[0].Weapon != null)
                {
                    character1Weapon.Text = characters[0].Weapon.Name;
                    character1Weapon.AccessibleDescription = characters[0].Weapon.Name + Environment.NewLine + characters[0].Weapon.Description + Environment.NewLine + characters[0].Weapon.Rarity + Environment.NewLine + "Min Damage: " + characters[0].Weapon.MinDmg.ToString() +
                        Environment.NewLine + "Max Damage: " + characters[0].Weapon.MaxDmg.ToString() + Environment.NewLine + "Available for Classes:" + Environment.NewLine +
                    string.Join("," + Environment.NewLine, characters[0].Weapon.AllowedCharacters.Select(characterType => characterType.ToString())) + Environment.NewLine + "Value:" + Environment.NewLine + characters[0].Weapon.SalesPrice.ToString();
                    switch (characters[0].Weapon.Rarity)
                    {
                        case Rarity.Common:
                            character1Weapon.BackColor = Color.LightGray;
                            break;
                        case Rarity.Rare:
                            character1Weapon.BackColor = Color.LightBlue;
                            break;
                        case Rarity.Epic:
                            character1Weapon.BackColor = Color.DarkMagenta;
                            break;
                        case Rarity.Legendary:
                            character1Weapon.BackColor = Color.Orange;
                            break;
                        default:
                            break;
                    }
                }
                else
                {
                    character1Weapon.Text = "None";
                    character1Weapon.AccessibleDescription = "  ";
                }

                if (characters[0].Armor != null)
                {
                    character1Armor.Text = characters[0].Armor.Name;
                    character1Armor.AccessibleDescription = characters[0].Armor.Name + Environment.NewLine + characters[0].Armor.Description + Environment.NewLine + characters[0].Armor.Rarity + Environment.NewLine + "Damage Reduction: " + characters[0].Armor.DmgReduction.ToString()
                        + Environment.NewLine + "Available for Classes:" + Environment.NewLine + string.Join("," + Environment.NewLine, characters[0].Armor.AllowedCharacters.Select(characterType => characterType.ToString())) + Environment.NewLine + "Value:" + Environment.NewLine + characters[0].Armor.SalesPrice.ToString();
                    switch (characters[0].Armor.Rarity)
                    {
                        case Rarity.Common:
                            character1Armor.BackColor = Color.LightGray;
                            break;
                        case Rarity.Rare:
                            character1Armor.BackColor = Color.LightBlue;
                            break;
                        case Rarity.Epic:
                            character1Armor.BackColor = Color.DarkMagenta;
                            break;
                        case Rarity.Legendary:
                            character1Armor.BackColor = Color.Orange;
                            break;
                        default:
                            break;
                    }
                }
                else
                {
                    character1Armor.Text = "None";
                    character1Armor.AccessibleDescription = "  ";
                }
                character1ClassName.Text = characters[0].Name;





                character2Name.Text = "Name: " + characters[1].Name;
                character2Level.Text = "Level: " + characters[1].Level;
                character2Exp.Text = "Experience Points: " + characters[1].ExperiencePoints;
                character2Strength.Text = "Strength: " + characters[1].Strength;
                character2Dexterity.Text = "Dexterity: " + characters[1].Dexterity;
                character2Intelligence.Text = "Intelligence: " + characters[1].Intelligence;
                character2Hp.Text = "HP: " + characters[1].CurrentHP + "/" + characters[1].MaxHP;
                character2Resistance.Text = "Resistance: " + characters[1].Resistance;
                character2Crit.Text = "Critical Chance: " + characters[1].CritChance + "%";
                character2Initiative.Text = "Initiative: " + characters[1].Initiative;
                character2Dmg.Text = "Attack Damage: " + characters[1].MinDmg + "-" + characters[1].MaxDmg;
                if (characters[1].CharacterType == CharacterType.Knight)
                {
                    Knight knight = (Knight)characters[1];
                    character2Block.Text = "Block Chance: " + knight.BlockChance;
                }
                else if (characters[1].CharacterType == CharacterType.Rogue)
                {
                    Rogue rogue = (Rogue)characters[1];
                    character2Block.Text = "Dodge Chance: " + rogue.DodgeChance;
                }
                else if (characters[1].CharacterType == CharacterType.Cleric)
                {
                    Cleric cleric = (Cleric)characters[1];
                    character2Block.Text = "Blessing Chance: " + cleric.BlessingChance;
                }
                else if (characters[1].CharacterType == CharacterType.Joker)
                {
                    Joker joker = (Joker)characters[1];
                    character2Block.Text = "DoubleAttack Chance: " + joker.DoubleAtackChance;
                }
                else
                {
                    character2Block.Text = " ";
                }
                if (characters[1].Weapon != null)
                {
                    character2Weapon.Text = characters[1].Weapon.Name;
                    character2Weapon.AccessibleDescription = characters[1].Weapon.Name + Environment.NewLine + characters[1].Weapon.Description + Environment.NewLine + characters[1].Weapon.Rarity + Environment.NewLine + "Min Damage: " + characters[1].Weapon.MinDmg.ToString() +
                        Environment.NewLine + "Max Damage: " + characters[1].Weapon.MaxDmg.ToString() + Environment.NewLine + "Available for Classes:" + Environment.NewLine +
                    string.Join("," + Environment.NewLine, characters[1].Weapon.AllowedCharacters.Select(characterType => characterType.ToString())) + Environment.NewLine + "Value:" + Environment.NewLine + characters[1].Weapon.SalesPrice.ToString();
                    switch (characters[1].Weapon.Rarity)
                    {
                        case Rarity.Common:
                            character2Weapon.BackColor = Color.LightGray;
                            break;
                        case Rarity.Rare:
                            character2Weapon.BackColor = Color.LightBlue;
                            break;
                        case Rarity.Epic:
                            character2Weapon.BackColor = Color.DarkMagenta;
                            break;
                        case Rarity.Legendary:
                            character2Weapon.BackColor = Color.Orange;
                            break;
                        default:
                            break;
                    }
                }
                else
                {
                    character2Weapon.Text = "None";
                    character2Weapon.AccessibleDescription = "  ";
                }
                if (characters[1].Armor != null)
                {
                    character2Armor.Text = characters[1].Armor.Name;
                    character2Armor.AccessibleDescription = characters[1].Armor.Name + Environment.NewLine + characters[1].Armor.Description + Environment.NewLine + characters[1].Armor.Rarity + Environment.NewLine + "Damage Reduction: " + characters[1].Armor.DmgReduction.ToString()
                        + Environment.NewLine + "Available for Classes:" + Environment.NewLine + string.Join("," + Environment.NewLine, characters[1].Armor.AllowedCharacters.Select(characterType => characterType.ToString())) + Environment.NewLine + "Value:" + Environment.NewLine + characters[1].Armor.SalesPrice.ToString();
                    switch (characters[1].Armor.Rarity)
                    {
                        case Rarity.Common:
                            character2Armor.BackColor = Color.LightGray;
                            break;
                        case Rarity.Rare:
                            character2Armor.BackColor = Color.LightBlue;
                            break;
                        case Rarity.Epic:
                            character2Armor.BackColor = Color.DarkMagenta;
                            break;
                        case Rarity.Legendary:
                            character2Armor.BackColor = Color.Orange;
                            break;
                        default:
                            break;
                    }
                }
                else
                {
                    character2Armor.Text = "None";
                    character2Armor.AccessibleDescription = "  ";
                }
                character2ClassName.Text = characters[1].Name;



                character3Name.Text = "Name: " + characters[2].Name;
                character3Level.Text = "Level: " + characters[2].Level;
                character3Exp.Text = "Experience Points: " + characters[2].ExperiencePoints;
                character3Strength.Text = "Strength: " + characters[2].Strength;
                character3Dexterity.Text = "Dexterity: " + characters[2].Dexterity;
                character3Intelligence.Text = "Intelligence: " + characters[2].Intelligence;
                character3Hp.Text = "HP: " + characters[2].CurrentHP + "/" + characters[2].MaxHP;
                character3Resistance.Text = "Resistance: " + characters[2].Resistance;
                character3Crit.Text = "Critical Chance: " + characters[2].CritChance + "%";
                character3Initiative.Text = "Initiative: " + characters[2].Initiative;
                character3Dmg.Text = "Attack Damage: " + characters[2].MinDmg + "-" + characters[2].MaxDmg;
                if (characters[2].CharacterType == CharacterType.Knight)
                {
                    Knight knight = (Knight)characters[2];
                    character3Block.Text = "Block Chance: " + knight.BlockChance;
                }
                else if (characters[2].CharacterType == CharacterType.Rogue)
                {
                    Rogue rogue = (Rogue)characters[2];
                    character3Block.Text = "Dodge Chance: " + rogue.DodgeChance;
                }
                else if (characters[2].CharacterType == CharacterType.Cleric)
                {
                    Cleric cleric = (Cleric)characters[2];
                    character3Block.Text = "Blessing Chance: " + cleric.BlessingChance;
                }
                else if (characters[2].CharacterType == CharacterType.Joker)
                {
                    Joker joker = (Joker)characters[2];
                    character3Block.Text = "DoubleAttack Chance: " + joker.DoubleAtackChance;
                }
                else
                {
                    character3Block.Text = " ";
                }
                if (characters[2].Weapon != null)
                {
                    character3Weapon.Text = characters[2].Weapon.Name;
                    character3Weapon.AccessibleDescription = characters[2].Weapon.Name + Environment.NewLine + characters[2].Weapon.Description + Environment.NewLine + characters[2].Weapon.Rarity + Environment.NewLine + "Min Damage: " + characters[2].Weapon.MinDmg.ToString() +
                        Environment.NewLine + "Max Damage: " + characters[2].Weapon.MaxDmg.ToString() + Environment.NewLine + "Available for Classes:" + Environment.NewLine +
                    string.Join("," + Environment.NewLine, characters[2].Weapon.AllowedCharacters.Select(characterType => characterType.ToString())) + Environment.NewLine + "Value:" + Environment.NewLine + characters[2].Weapon.SalesPrice.ToString();
                    switch (characters[2].Weapon.Rarity)
                    {
                        case Rarity.Common:
                            character3Weapon.BackColor = Color.LightGray;
                            break;
                        case Rarity.Rare:
                            character3Weapon.BackColor = Color.LightBlue;
                            break;
                        case Rarity.Epic:
                            character3Weapon.BackColor = Color.DarkMagenta;
                            break;
                        case Rarity.Legendary:
                            character3Weapon.BackColor = Color.Orange;
                            break;
                        default:
                            break;
                    }
                }
                else
                {
                    character3Weapon.Text = "None";
                    character3Weapon.AccessibleDescription = "  ";
                }
                if (characters[2].Armor != null)
                {
                    character3Armor.Text = characters[2].Armor.Name;
                    character3Armor.AccessibleDescription = characters[2].Armor.Name + Environment.NewLine + characters[2].Armor.Description + Environment.NewLine + characters[2].Armor.Rarity + Environment.NewLine + "Damage Reduction: " + characters[2].Armor.DmgReduction.ToString()
                    + Environment.NewLine + "Available for Classes:" + Environment.NewLine + string.Join("," + Environment.NewLine, characters[2].Armor.AllowedCharacters.Select(characterType => characterType.ToString())) + Environment.NewLine + "Value:" + Environment.NewLine + characters[2].Armor.SalesPrice.ToString();
                    switch (characters[2].Armor.Rarity)
                    {
                        case Rarity.Common:
                            character3Armor.BackColor = Color.LightGray;
                            break;
                        case Rarity.Rare:
                            character3Armor.BackColor = Color.LightBlue;
                            break;
                        case Rarity.Epic:
                            character3Armor.BackColor = Color.DarkMagenta;
                            break;
                        case Rarity.Legendary:
                            character3Armor.BackColor = Color.Orange;
                            break;
                        default:
                            break;
                    }
                }
                else
                {
                    character3Armor.Text = "None";
                    character3Armor.AccessibleDescription = "  ";
                }
                character3ClassName.Text = characters[2].Name;




                character4Name.Text = "Name: " + characters[3].Name;
                character4Level.Text = "Level: " + characters[3].Level;
                character4Exp.Text = "Experience Points: " + characters[3].ExperiencePoints;
                character4Strength.Text = "Strength: " + characters[3].Strength;
                character4Dexterity.Text = "Dexterity: " + characters[3].Dexterity;
                character4Intelligence.Text = "Intelligence: " + characters[3].Intelligence;
                character4Hp.Text = "HP: " + characters[3].CurrentHP + "/" + characters[3].MaxHP;
                character4Resistance.Text = "Resistance: " + characters[3].Resistance;
                character4Crit.Text = "Critical Chance: " + characters[3].CritChance + "%";
                character4Initiative.Text = "Initiative: " + characters[3].Initiative;
                character4Dmg.Text = "Attack Damage: " + characters[3].MinDmg + "-" + characters[3].MaxDmg;
                if (characters[3].CharacterType == CharacterType.Knight)
                {
                    Knight knight = (Knight)characters[3];
                    character4Block.Text = "Block Chance: " + knight.BlockChance;
                }
                else if (characters[3].CharacterType == CharacterType.Rogue)
                {
                    Rogue rogue = (Rogue)characters[3];
                    character4Block.Text = "Dodge Chance: " + rogue.DodgeChance;
                }
                else if (characters[3].CharacterType == CharacterType.Cleric)
                {
                    Cleric cleric = (Cleric)characters[3];
                    character4Block.Text = "Blessing Chance: " + cleric.BlessingChance;
                }
                else if (characters[3].CharacterType == CharacterType.Joker)
                {
                    Joker joker = (Joker)characters[3];
                    character4Block.Text = "DoubleAttack Chance: " + joker.DoubleAtackChance;
                }
                else
                {
                    character4Block.Text = " ";
                }
                if (characters[3].Weapon != null)
                {
                    character4Weapon.Text = characters[3].Weapon.Name;
                    character4Weapon.AccessibleDescription = characters[3].Weapon.Name + Environment.NewLine + characters[3].Weapon.Description + Environment.NewLine + characters[3].Weapon.Rarity + Environment.NewLine + "Min Damage: " + characters[3].Weapon.MinDmg.ToString() +
                        Environment.NewLine + "Max Damage: " + characters[3].Weapon.MaxDmg.ToString() + Environment.NewLine + "Available for Classes:" + Environment.NewLine +
                    string.Join("," + Environment.NewLine, characters[3].Weapon.AllowedCharacters.Select(characterType => characterType.ToString())) + Environment.NewLine + "Value:" + Environment.NewLine + characters[3].Weapon.SalesPrice.ToString();
                    switch (characters[3].Weapon.Rarity)
                    {
                        case Rarity.Common:
                            character4Weapon.BackColor = Color.LightGray;
                            break;
                        case Rarity.Rare:
                            character4Weapon.BackColor = Color.LightBlue;
                            break;
                        case Rarity.Epic:
                            character4Weapon.BackColor = Color.DarkMagenta;
                            break;
                        case Rarity.Legendary:
                            character4Weapon.BackColor = Color.Orange;
                            break;
                        default:
                            break;
                    }
                }
                else
                {
                    character4Weapon.Text = "None";
                    character4Weapon.AccessibleDescription = "  ";
                }
                if (characters[3].Armor != null)
                {
                    character4Armor.Text = characters[3].Armor.Name;
                    character4Armor.AccessibleDescription = characters[3].Armor.Name + Environment.NewLine + characters[3].Armor.Description + Environment.NewLine + characters[3].Armor.Rarity + Environment.NewLine + "Damage Reduction: " + characters[3].Armor.DmgReduction.ToString()
                    + Environment.NewLine + "Available for Classes:" + Environment.NewLine + string.Join("," + Environment.NewLine, characters[3].Armor.AllowedCharacters.Select(characterType => characterType.ToString())) + Environment.NewLine + "Value:" + Environment.NewLine + characters[3].Armor.SalesPrice.ToString();
                    switch (characters[3].Armor.Rarity)
                    {
                        case Rarity.Common:
                            character4Armor.BackColor = Color.LightGray;
                            break;
                        case Rarity.Rare:
                            character4Armor.BackColor = Color.LightBlue;
                            break;
                        case Rarity.Epic:
                            character4Armor.BackColor = Color.DarkMagenta;
                            break;
                        case Rarity.Legendary:
                            character4Armor.BackColor = Color.Orange;
                            break;
                        default:
                            break;
                    }
                }
                else
                {
                    character4Armor.Text = "None";
                    character4Armor.AccessibleDescription = "  ";
                }
                character4ClassName.Text = characters[3].Name;


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
            gameState.chararacters = characters;


       
            gameState.Ekwipunek = inventory;
            gameState.Shop = shopItems;
            gameState.Equiped = equipedItems;
            gameState.expeditions = expeditons;
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
                if (control.Text != "None")
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
                    IEkwipunek itemToSelect = inventory.FirstOrDefault(item => item.Wypisz() == draggedItemText && item is Weapon);

                    if (itemToSelect != null)
                    {
                        if (character1Weapon.Text != "None")
                        {
                            itemToSelect.Equip(characters[0]);
                            string oldItem = character1Weapon.Text;
                            AddItemToInventory(oldItem, false);
                            equipedItems.Add(itemToSelect);
                            character1Weapon.Text = draggedItemText;
                            character1Weapon.BackColor = SystemColors.Control;

                            inventory.Remove(itemToSelect);
                            RefreshInventory();
                            characters[0].UpdateStats();
                            RefreshStats();
                        }
                        else
                        {
                            itemToSelect.Equip(characters[0]);
                            equipedItems.Add(itemToSelect);
                            character1Weapon.Text = draggedItemText;
                            character1Weapon.BackColor = SystemColors.Control;

                            inventory.Remove(itemToSelect);
                            RefreshInventory();
                            characters[0].UpdateStats();
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
                    IEkwipunek itemToSelect = inventory.FirstOrDefault(item => item.Wypisz() == draggedItemText && item is Armor);

                    if (itemToSelect != null)
                    {
                        if (character1Armor.Text != "None")
                        {
                            itemToSelect.Equip(characters[0]);
                            string oldItem = character1Armor.Text;
                            AddItemToInventory(oldItem, false);
                            equipedItems.Add(itemToSelect);
                            character1Armor.Text = draggedItemText;
                            character1Armor.BackColor = SystemColors.Control;

                            inventory.Remove(itemToSelect);
                            RefreshInventory();
                            characters[0].UpdateStats();
                            RefreshStats();
                        }
                        else
                        {
                            itemToSelect.Equip(characters[0]);
                            equipedItems.Add(itemToSelect);
                            character1Armor.Text = draggedItemText;
                            character1Armor.BackColor = SystemColors.Control;

                            inventory.Remove(itemToSelect);
                            RefreshInventory();
                            characters[0].UpdateStats();
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
                    IEkwipunek itemToSelect = inventory.FirstOrDefault(item => item.Wypisz() == draggedItemText && item is Weapon);

                    if (itemToSelect != null)
                    {
                        if (character2Weapon.Text != "None")
                        {
                            itemToSelect.Equip(characters[1]);
                            string oldItem = character2Weapon.Text;
                            AddItemToInventory(oldItem, false);
                            equipedItems.Add(itemToSelect);
                            character2Weapon.Text = draggedItemText;
                            character2Weapon.BackColor = SystemColors.Control;

                            inventory.Remove(itemToSelect);
                            RefreshInventory();
                            characters[1].UpdateStats();
                            RefreshStats();
                        }
                        else
                        {
                            itemToSelect.Equip(characters[1]);
                            equipedItems.Add(itemToSelect);
                            character2Weapon.Text = draggedItemText;
                            character2Weapon.BackColor = SystemColors.Control;

                            inventory.Remove(itemToSelect);
                            RefreshInventory();
                            characters[1].UpdateStats();
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
                    IEkwipunek itemToSelect = inventory.FirstOrDefault(item => item.Wypisz() == draggedItemText && item is Armor);

                    if (itemToSelect != null)
                    {
                        if (character2Armor.Text != "None")
                        {
                            itemToSelect.Equip(characters[1]);
                            string oldItem = character2Armor.Text;
                            AddItemToInventory(oldItem, false);
                            equipedItems.Add(itemToSelect);
                            character2Armor.Text = draggedItemText;
                            character2Armor.BackColor = SystemColors.Control;

                            inventory.Remove(itemToSelect);
                            RefreshInventory();
                            characters[1].UpdateStats();
                            RefreshStats();
                        }
                        else
                        {
                            itemToSelect.Equip(characters[1]);
                            equipedItems.Add(itemToSelect);
                            character2Armor.Text = draggedItemText;
                            character2Armor.BackColor = SystemColors.Control;

                            inventory.Remove(itemToSelect);
                            RefreshInventory();
                            characters[1].UpdateStats();
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
                    IEkwipunek itemToSelect = inventory.FirstOrDefault(item => item.Wypisz() == draggedItemText && item is Weapon);

                    if (itemToSelect != null)
                    {
                        if (character3Weapon.Text != "None")
                        {
                            itemToSelect.Equip(characters[2]);
                            string oldItem = character3Weapon.Text;
                            AddItemToInventory(oldItem, false);
                            equipedItems.Add(itemToSelect);
                            character3Weapon.Text = draggedItemText;
                            character3Weapon.BackColor = SystemColors.Control;

                            inventory.Remove(itemToSelect);
                            RefreshInventory();
                            characters[2].UpdateStats();
                            RefreshStats();
                        }
                        else
                        {
                            itemToSelect.Equip(characters[2]);
                            equipedItems.Add(itemToSelect);
                            character3Weapon.Text = draggedItemText;
                            character3Weapon.BackColor = SystemColors.Control;

                            inventory.Remove(itemToSelect);
                            RefreshInventory();
                            characters[2].UpdateStats();
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
                    IEkwipunek itemToSelect = inventory.FirstOrDefault(item => item.Wypisz() == draggedItemText && item is Armor);

                    if (itemToSelect != null)
                    {
                        if (character3Armor.Text != "None")
                        {
                            itemToSelect.Equip(characters[2]);
                            string oldItem = character3Armor.Text;
                            AddItemToInventory(oldItem, false);
                            equipedItems.Add(itemToSelect);
                            character3Armor.Text = draggedItemText;
                            character3Armor.BackColor = SystemColors.Control;

                            inventory.Remove(itemToSelect);
                            RefreshInventory();
                            characters[2].UpdateStats();
                            RefreshStats();
                        }
                        else
                        {
                            itemToSelect.Equip(characters[2]);
                            equipedItems.Add(itemToSelect);
                            character3Armor.Text = draggedItemText;
                            character3Armor.BackColor = SystemColors.Control;

                            inventory.Remove(itemToSelect);
                            RefreshInventory();
                            characters[2].UpdateStats();
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
                    IEkwipunek itemToSelect = inventory.FirstOrDefault(item => item.Wypisz() == draggedItemText && item is Weapon);

                    if (itemToSelect != null)
                    {
                        if (character4Weapon.Text != "None")
                        {
                            itemToSelect.Equip(characters[3]);
                            string oldItem = character4Weapon.Text;
                            AddItemToInventory(oldItem, false);
                            equipedItems.Add(itemToSelect);
                            character4Weapon.Text = draggedItemText;
                            character4Weapon.BackColor = SystemColors.Control;

                            inventory.Remove(itemToSelect);
                            RefreshInventory();
                            characters[3].UpdateStats();
                            RefreshStats();
                        }
                        else
                        {
                            itemToSelect.Equip(characters[3]);
                            equipedItems.Add(itemToSelect);
                            character4Weapon.Text = draggedItemText;
                            character4Weapon.BackColor = SystemColors.Control;

                            inventory.Remove(itemToSelect);
                            RefreshInventory();
                            characters[3].UpdateStats();
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
                    IEkwipunek itemToSelect = inventory.FirstOrDefault(item => item.Wypisz() == draggedItemText && item is Armor);

                    if (itemToSelect != null)
                    {
                        if (character4Armor.Text !="None")
                        {
                            itemToSelect.Equip(characters[3]);
                            string oldItem = character4Armor.Text;
                            AddItemToInventory(oldItem, false);
                            equipedItems.Add(itemToSelect);
                            character4Armor.Text = draggedItemText;
                            character4Armor.BackColor = SystemColors.Control;

                            inventory.Remove(itemToSelect);
                            RefreshInventory();
                            characters[3].UpdateStats();
                            RefreshStats();
                        }
                        else
                        {
                            itemToSelect.Equip(characters[3]);
                            equipedItems.Add(itemToSelect);
                            character4Armor.Text = draggedItemText;
                            character4Armor.BackColor = SystemColors.Control;

                            inventory.Remove(itemToSelect);
                            RefreshInventory();
                            characters[3].UpdateStats();
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
                lastDraggedLabel.Text = "None";
                if (lastDraggedLabel == character1Weapon)
                {
                    characters[0].Weapon = null;
                    PlayEquipWeaponSound();
                }
                characters[0].UpdateStats();
                if (lastDraggedLabel == character1Armor)
                {
                    characters[0].Armor = null;
                    PlayEquipArmorSound();
                }
                characters[0].UpdateStats();
                if (lastDraggedLabel == character2Weapon)
                {
                    characters[1].Weapon = null;
                    PlayEquipWeaponSound();
                }
                characters[1].UpdateStats();
                if (lastDraggedLabel == character2Armor)
                {
                    characters[1].Armor = null;
                    PlayEquipArmorSound();
                }
                characters[1].UpdateStats();
                if (lastDraggedLabel == character3Weapon)
                {
                    characters[2].Weapon = null;
                    PlayEquipWeaponSound();
                }
                characters[2].UpdateStats();
                if (lastDraggedLabel == character3Armor)
                {
                    characters[2].Armor = null;
                    PlayEquipArmorSound();
                }
                characters[2].UpdateStats();
                if (lastDraggedLabel == character4Weapon)
                {
                    characters[3].Weapon = null;
                    PlayEquipWeaponSound();
                }
                characters[3].UpdateStats();
                if (lastDraggedLabel == character4Armor)
                {
                    characters[3].Armor = null;
                    PlayEquipArmorSound();
                }
                characters[3].UpdateStats();


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
                    MessageBox.Show("You are missing " + (price - gold) + " gold", "Shop Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    inventory.Add(itemToAdd);
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
                    inventory.Add(itemToAdd);
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

            goldLabel.Text = "Gold: " + gold.ToString();
            Inventory.AutoScroll = true;
            Inventory.Controls.Clear();

            foreach (IEkwipunek item in inventory)
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
                    label.AccessibleDescription = weapon.Name + Environment.NewLine + weapon.Description + Environment.NewLine + weapon.Rarity + Environment.NewLine + "Min Damage: " + weapon.MinDmg.ToString() +
                    Environment.NewLine + "Max Damage: " + weapon.MaxDmg.ToString() + Environment.NewLine + "Available for Classes:" + Environment.NewLine +
                    string.Join("," + Environment.NewLine, weapon.AllowedCharacters.Select(characterType => characterType.ToString())) + Environment.NewLine + "Value:" + Environment.NewLine + weapon.SalesPrice.ToString();
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
                    label.AccessibleDescription = armor.Name + Environment.NewLine + armor.Description + Environment.NewLine + armor.Rarity + Environment.NewLine + "Damage Reduction: " + armor.DmgReduction.ToString() + Environment.NewLine +
                    "Available for Classes:" + Environment.NewLine + string.Join("," + Environment.NewLine, armor.AllowedCharacters.Select(characterType => characterType.ToString())) + Environment.NewLine + "Value:" + Environment.NewLine + armor.SalesPrice.ToString();
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
            inventory = inventory.OrderBy(item => item.Wypisz()).ToList();
            RefreshInventory();
        }

        private void SortKnight_Click(object sender, EventArgs e)
        {
            inventory = SortByAllowedCharacters(CharacterType.Knight);
            RefreshInventory();
        }

        private void SortRogue_Click(object sender, EventArgs e)
        {
            inventory = SortByAllowedCharacters(CharacterType.Rogue);
            RefreshInventory();
        }


        private void SortCleric_Click(object sender, EventArgs e)
        {
            inventory = SortByAllowedCharacters(CharacterType.Cleric);
            RefreshInventory();
        }

        private void SortJoker_Click(object sender, EventArgs e)
        {
            inventory = SortByAllowedCharacters(CharacterType.Joker);
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
                int i = r.Next(0, shopItemsPool.Count);
                if (shopItemsPool[i] is Armor)
                {
                    Armor armor = (Armor)shopItemsPool[i];
                    if ((int)armor.Rarity == 1)
                    {
                        shopItems.Add(new Armor((Armor)shopItemsPool[i]));
                    }

                }
                else
                {
                    Weapon weapon = (Weapon)shopItemsPool[i];
                    if ((int)weapon.Rarity == 1)
                    {
                        shopItems.Add(new Weapon((Weapon)shopItemsPool[i]));
                    }
                }
            } while (shopItems.Count != 4);
            do
            {
                int i = r.Next(0, shopItemsPool.Count);
                if (shopItemsPool[i] is Armor)
                {
                    Armor armor = (Armor)shopItemsPool[i];
                    if ((int)armor.Rarity == 2)
                    {
                        shopItems.Add(new Armor((Armor)shopItemsPool[i]));
                    }

                }
                else
                {
                    Weapon weapon = (Weapon)shopItemsPool[i];
                    if ((int)weapon.Rarity == 2)
                    {
                        shopItems.Add(new Weapon((Weapon)shopItemsPool[i]));
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
                IEkwipunek itemToSelect = inventory.FirstOrDefault(item => item.Wypisz() == draggedItemText);
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

                inventory.Remove(itemToSelect);
                RefreshInventory();
                lastDraggedLabel = null;

                PlaySellAndBuySound();
            }

        }

        private void Roll_Click(object sender, EventArgs e)
        {
            if (25 > gold)
            {
                MessageBox.Show("You are missing " + (25 - gold) + " gold", "Shop Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                    label.AccessibleDescription = weapon.Name + Environment.NewLine + weapon.Description + Environment.NewLine + weapon.Rarity + Environment.NewLine + "Min Damage: " + weapon.MinDmg.ToString() +
                    Environment.NewLine + "Max Damage: " + weapon.MaxDmg.ToString() + Environment.NewLine + "Available for Classes:" + Environment.NewLine +
                    string.Join("," + Environment.NewLine, weapon.AllowedCharacters.Select(characterType => characterType.ToString())) + Environment.NewLine + "Value:" + Environment.NewLine + weapon.SalesPrice.ToString();
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
                    label.AccessibleDescription = armor.Name + Environment.NewLine + armor.Description + Environment.NewLine + armor.Rarity + Environment.NewLine + "Damage Reduction: " + armor.DmgReduction.ToString() + Environment.NewLine +
                    "Available for Classes:" + Environment.NewLine + string.Join("," + Environment.NewLine, armor.AllowedCharacters.Select(characterType => characterType.ToString())) + Environment.NewLine + "Value:" + Environment.NewLine + armor.SalesPrice.ToString();
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




        public void AfterExpedition(bool result, Expedition expedition)
        {

            if (result)
            {
                characters[0].GainExperience(expedition.ExperienceGains);
                characters[1].GainExperience(expedition.ExperienceGains);
                characters[2].GainExperience(expedition.ExperienceGains);
                characters[3].GainExperience(expedition.ExperienceGains);


                gold += expedition.Gold;
                foreach (Weapon weapon in expedition.WeaponRewards)
                {
                    inventory.Add(new Weapon(weapon));
                }
                foreach (Armor armor in expedition.ArmorRewards)
                {
                    inventory.Add(new Armor(armor));
                }
                RefreshInventory();
            }
            else
            {

                equipedItems.Clear();
                characters[0].Weapon = null; characters[0].UpdateStats();
                characters[0].Armor = null; characters[0].UpdateStats();
                characters[1].Weapon = null; characters[1].UpdateStats();
                characters[1].Armor = null; characters[1].UpdateStats();
                characters[2].Weapon = null; characters[2].UpdateStats();
                characters[2].Armor = null; characters[2].UpdateStats();
                characters[3].Weapon = null; characters[3].UpdateStats();
                characters[3].Armor = null; characters[3].UpdateStats();
                RefreshStats();
            }
            characters[0].CurrentHP = characters[0].MaxHP;
            characters[1].CurrentHP = characters[1].MaxHP;
            characters[2].CurrentHP = characters[2].MaxHP;
            characters[3].CurrentHP = characters[3].MaxHP;
        }



        private void exitButton_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Are you sure you want to escape from here?", "Have you lost hope?", MessageBoxButtons.YesNo);
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
            return inventory.OrderByDescending(item =>
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
