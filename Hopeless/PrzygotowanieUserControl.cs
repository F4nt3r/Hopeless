using HopelessLibary;
using NAudio.Wave;
using Newtonsoft.Json;
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
        public Knight knight;
        public Rogue rogue;
        public Cleric cleric;
        public Joker joker;
        public bool eventQuest;
        public bool eventResult;
        public PrzygotowanieUserControl()
        {
            InitializeComponent();
            pictureBox1.Image = Properties.Resources.Prep;
            knightPicture.Image = Properties.Resources.knightPicture;
            roguePicture.Image = Properties.Resources.roguePicture;
            clericPicture.Image = Properties.Resources.clericPicture;
            jokerPicture.Image = Properties.Resources.jokerPicture;
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
                }



            }
        }


        private void RefreshStats()
        {
            knight = (Knight)Characters[0];
            rogue = (Rogue)Characters[1];
            cleric = (Cleric)Characters[2];
            joker = (Joker)Characters[3];
            if (Characters != null && Characters.Any())
            {

                knightName.Text = "Imie: " + knight.Name;
                knightLevel.Text = "Level: " + knight.Level;
                knightExp.Text = "Punkty EXP: " + knight.ExperiencePoints;
                knightStrength.Text = "Sila: " + knight.Strength;
                knightDexterity.Text = "Zrecznosc: " + knight.Dexterity;
                knightIntelligence.Text = "Inteligencja: " + knight.Intelligence;
                knightHp.Text = "HP: " + knight.CurrentHP + "/" + knight.MaxHP;
                knightResistance.Text = "Odpornosc: " + knight.Resistance;
                knightCrit.Text = "Szansa na Kryta: " + knight.CritChance + "%";
                knightInitiative.Text = "Inicjatywa: " + knight.Initiative;
                knightDmg.Text = "Obrazenia Ataku: " + knight.MinDmg + "-" + knight.MaxDmg;
                knightBlock.Text = "Szansa na Blok: " + knight.BlockChance + "%";

                if (knight.Weapon != null)
                {
                    knightWeapon.Text = knight.Weapon.Name;
                    knightWeapon.AccessibleDescription = knight.Weapon.Name + Environment.NewLine + knight.Weapon.Description + Environment.NewLine + knight.Weapon.Rarity + Environment.NewLine + "MinDMG: " + knight.Weapon.MinDmg.ToString() +
                        Environment.NewLine + "MaxDMG: " + knight.Weapon.MaxDmg.ToString() + Environment.NewLine + "Dostepne dla Klas:" + Environment.NewLine +
                    string.Join("," + Environment.NewLine, knight.Weapon.AllowedCharacters.Select(characterType => characterType.ToString())) + Environment.NewLine + "Wartosc:" + Environment.NewLine + knight.Weapon.SalesPrice.ToString();
                    switch (knight.Weapon.Rarity)
                    {
                        case Rarity.Common:
                            knightWeapon.BackColor = Color.LightGray; // Dostosuj kolor do poziomu Rarity
                            break;
                        case Rarity.Rare:
                            knightWeapon.BackColor = Color.LightBlue; // Dostosuj kolor do poziomu Rarity
                            break;
                        case Rarity.Epic:
                            knightWeapon.BackColor = Color.DarkMagenta; // Dostosuj kolor do poziomu Rarity
                            break;
                        case Rarity.Legendary:
                            knightWeapon.BackColor = Color.Orange; // Dostosuj kolor do poziomu Rarity
                            break;
                        default:
                            break;
                    }
                }
                else
                {
                    knightWeapon.Text = "Brak";
                    knightWeapon.AccessibleDescription = "  ";
                }

                if (knight.Armor != null)
                {
                    knightArmor.Text = knight.Armor.Name;
                    knightArmor.AccessibleDescription = knight.Armor.Name + Environment.NewLine + knight.Armor.Description + Environment.NewLine + knight.Armor.Rarity + Environment.NewLine + "DmgReduction: " + knight.Armor.DmgReduction.ToString()
                        + Environment.NewLine + "Dostepne dla Klas:" + Environment.NewLine + string.Join("," + Environment.NewLine, knight.Armor.AllowedCharacters.Select(characterType => characterType.ToString())) + Environment.NewLine + "Wartosc:" + Environment.NewLine + knight.Armor.SalesPrice.ToString();
                    switch (knight.Armor.Rarity)
                    {
                        case Rarity.Common:
                            knightArmor.BackColor = Color.LightGray; // Dostosuj kolor do poziomu Rarity
                            break;
                        case Rarity.Rare:
                            knightArmor.BackColor = Color.LightBlue; // Dostosuj kolor do poziomu Rarity
                            break;
                        case Rarity.Epic:
                            knightArmor.BackColor = Color.DarkMagenta; // Dostosuj kolor do poziomu Rarity
                            break;
                        case Rarity.Legendary:
                            knightArmor.BackColor = Color.Orange; // Dostosuj kolor do poziomu Rarity
                            break;
                        default:
                            break;
                    }
                }
                else
                {
                    knightArmor.Text = "Brak";
                    knightArmor.AccessibleDescription = "  ";
                }






                rogueName.Text = "Imie: " + rogue.Name;
                rogueLevel.Text = "Level: " + rogue.Level;
                rogueExp.Text = "Punkty EXP: " + rogue.ExperiencePoints;
                rogueStrength.Text = "Sila: " + rogue.Strength;
                rogueDexterity.Text = "Zrecznosc: " + rogue.Dexterity;
                rogueIntelligence.Text = "Inteligencja: " + rogue.Intelligence;
                rogueHp.Text = "HP: " + rogue.CurrentHP + "/" + rogue.MaxHP;
                rogueResistance.Text = "Odpornosc: " + rogue.Resistance;
                rogueCrit.Text = "Szansa na Kryta: " + rogue.CritChance + "%";
                rogueInitiative.Text = "Inicjatywa: " + rogue.Initiative;
                rogueDmg.Text = "Obrazenia Ataku: " + rogue.MinDmg + "-" + rogue.MaxDmg;
                rogueDodge.Text = "Szansa na Unik: " + rogue.DodgeChance + "%";
                if (rogue.Weapon != null)
                {
                    rogueWeapon.Text = rogue.Weapon.Name;
                    rogueWeapon.AccessibleDescription = rogue.Weapon.Name + Environment.NewLine + rogue.Weapon.Description + Environment.NewLine + rogue.Weapon.Rarity + Environment.NewLine + "MinDMG: " + rogue.Weapon.MinDmg.ToString() +
                        Environment.NewLine + "MaxDMG: " + rogue.Weapon.MaxDmg.ToString() + Environment.NewLine + "Dostepne dla Klas:" + Environment.NewLine +
                    string.Join("," + Environment.NewLine, rogue.Weapon.AllowedCharacters.Select(characterType => characterType.ToString())) + Environment.NewLine + "Wartosc:" + Environment.NewLine + rogue.Weapon.SalesPrice.ToString();
                    switch (rogue.Weapon.Rarity)
                    {
                        case Rarity.Common:
                            rogueWeapon.BackColor = Color.LightGray; // Dostosuj kolor do poziomu Rarity
                            break;
                        case Rarity.Rare:
                            rogueWeapon.BackColor = Color.LightBlue; // Dostosuj kolor do poziomu Rarity
                            break;
                        case Rarity.Epic:
                            rogueWeapon.BackColor = Color.DarkMagenta; // Dostosuj kolor do poziomu Rarity
                            break;
                        case Rarity.Legendary:
                            rogueWeapon.BackColor = Color.Orange; // Dostosuj kolor do poziomu Rarity
                            break;
                        default:
                            break;
                    }
                }
                else
                {
                    rogueWeapon.Text = "Brak";
                    rogueWeapon.AccessibleDescription = "  ";
                }
                if (rogue.Armor != null)
                {
                    rogueArmor.Text = rogue.Armor.Name;
                    rogueArmor.AccessibleDescription = rogue.Armor.Name + Environment.NewLine + rogue.Armor.Description + Environment.NewLine + rogue.Armor.Rarity + Environment.NewLine + "DmgReduction: " + rogue.Armor.DmgReduction.ToString()
                        + Environment.NewLine + "Dostepne dla Klas:" + Environment.NewLine + string.Join("," + Environment.NewLine, rogue.Armor.AllowedCharacters.Select(characterType => characterType.ToString())) + Environment.NewLine + "Wartosc:" + Environment.NewLine + rogue.Armor.SalesPrice.ToString();
                    switch (rogue.Armor.Rarity)
                    {
                        case Rarity.Common:
                            rogueArmor.BackColor = Color.LightGray; // Dostosuj kolor do poziomu Rarity
                            break;
                        case Rarity.Rare:
                            rogueArmor.BackColor = Color.LightBlue; // Dostosuj kolor do poziomu Rarity
                            break;
                        case Rarity.Epic:
                            rogueArmor.BackColor = Color.DarkMagenta; // Dostosuj kolor do poziomu Rarity
                            break;
                        case Rarity.Legendary:
                            rogueArmor.BackColor = Color.Orange; // Dostosuj kolor do poziomu Rarity
                            break;
                        default:
                            break;
                    }
                }
                else
                {
                    rogueArmor.Text = "Brak";
                    rogueArmor.AccessibleDescription = "  ";
                }




                clericName.Text = "Imie: " + cleric.Name;
                clericLevel.Text = "Level: " + cleric.Level;
                clericExp.Text = "Punkty EXP: " + cleric.ExperiencePoints;
                clericStrength.Text = "Sila: " + cleric.Strength;
                clericDexterity.Text = "Zrecznosc: " + cleric.Dexterity;
                clericIntelligence.Text = "Inteligencja: " + cleric.Intelligence;
                clericHp.Text = "HP: " + cleric.CurrentHP + "/" + cleric.MaxHP;
                clericResistance.Text = "Odpornosc: " + cleric.Resistance;
                clericCrit.Text = "Szansa na Kryta: " + cleric.CritChance + "%";
                clericInitiative.Text = "Inicjatywa: " + cleric.Initiative;
                clericDmg.Text = "Obrazenia Ataku: " + cleric.MinDmg + "-" + cleric.MaxDmg;
                if (cleric.Weapon != null)
                {
                    clericWeapon.Text = cleric.Weapon.Name;
                    clericWeapon.AccessibleDescription = cleric.Weapon.Name + Environment.NewLine + cleric.Weapon.Description + Environment.NewLine + cleric.Weapon.Rarity + Environment.NewLine + "MinDMG: " + cleric.Weapon.MinDmg.ToString() +
                        Environment.NewLine + "MaxDMG: " + cleric.Weapon.MaxDmg.ToString() + Environment.NewLine + "Dostepne dla Klas:" + Environment.NewLine +
                    string.Join("," + Environment.NewLine, cleric.Weapon.AllowedCharacters.Select(characterType => characterType.ToString())) + Environment.NewLine + "Wartosc:" + Environment.NewLine + cleric.Weapon.SalesPrice.ToString();
                    switch (cleric.Weapon.Rarity)
                    {
                        case Rarity.Common:
                            clericWeapon.BackColor = Color.LightGray; // Dostosuj kolor do poziomu Rarity
                            break;
                        case Rarity.Rare:
                            clericWeapon.BackColor = Color.LightBlue; // Dostosuj kolor do poziomu Rarity
                            break;
                        case Rarity.Epic:
                            clericWeapon.BackColor = Color.DarkMagenta; // Dostosuj kolor do poziomu Rarity
                            break;
                        case Rarity.Legendary:
                            clericWeapon.BackColor = Color.Orange; // Dostosuj kolor do poziomu Rarity
                            break;
                        default:
                            break;
                    }
                }
                else
                {
                    clericWeapon.Text = "Brak";
                    clericWeapon.AccessibleDescription = "  ";
                }
                if (cleric.Armor != null)
                {
                    clericArmor.Text = cleric.Armor.Name;
                    clericArmor.AccessibleDescription = cleric.Armor.Name + Environment.NewLine + cleric.Armor.Description + Environment.NewLine + cleric.Armor.Rarity + Environment.NewLine + "DmgReduction: " + cleric.Armor.DmgReduction.ToString()
                    + Environment.NewLine + "Dostepne dla Klas:" + Environment.NewLine + string.Join("," + Environment.NewLine, cleric.Armor.AllowedCharacters.Select(characterType => characterType.ToString())) + Environment.NewLine + "Wartosc:" + Environment.NewLine + cleric.Armor.SalesPrice.ToString();
                    switch (cleric.Armor.Rarity)
                    {
                        case Rarity.Common:
                            clericArmor.BackColor = Color.LightGray; // Dostosuj kolor do poziomu Rarity
                            break;
                        case Rarity.Rare:
                            clericArmor.BackColor = Color.LightBlue; // Dostosuj kolor do poziomu Rarity
                            break;
                        case Rarity.Epic:
                            clericArmor.BackColor = Color.DarkMagenta; // Dostosuj kolor do poziomu Rarity
                            break;
                        case Rarity.Legendary:
                            clericArmor.BackColor = Color.Orange; // Dostosuj kolor do poziomu Rarity
                            break;
                        default:
                            break;
                    }
                }
                else
                {
                    clericArmor.Text = "Brak";
                    clericArmor.AccessibleDescription = "  ";
                }





                jokerName.Text = "Imie: " + joker.Name;
                jokerLevel.Text = "Level: " + joker.Level;
                jokerExp.Text = "Punkty EXP: " + joker.ExperiencePoints;
                jokerStrength.Text = "Sila: " + joker.Strength;
                jokerDexterity.Text = "Zrecznosc: " + joker.Dexterity;
                jokerIntelligence.Text = "Inteligencja: " + joker.Intelligence;
                jokerHp.Text = "HP: " + joker.CurrentHP + "/" + joker.MaxHP;
                jokerResistance.Text = "Odpornosc: " + joker.Resistance;
                jokerCrit.Text = "Szansa na Kryta: " + joker.CritChance + "%";
                jokerInitiative.Text = "Inicjatywa: " + joker.Initiative;
                jokerDmg.Text = "Obrazenia Ataku: " + joker.MinDmg + "-" + joker.MaxDmg;
                if (joker.Weapon != null)
                {
                    jokerWeapon.Text = joker.Weapon.Name;
                    jokerWeapon.AccessibleDescription = joker.Weapon.Name + Environment.NewLine + joker.Weapon.Description + Environment.NewLine + joker.Weapon.Rarity + Environment.NewLine + "MinDMG: " + joker.Weapon.MinDmg.ToString() +
                        Environment.NewLine + "MaxDMG: " + joker.Weapon.MaxDmg.ToString() + Environment.NewLine + "Dostepne dla Klas:" + Environment.NewLine +
                    string.Join("," + Environment.NewLine, joker.Weapon.AllowedCharacters.Select(characterType => characterType.ToString())) + Environment.NewLine + "Wartosc:" + Environment.NewLine + joker.Weapon.SalesPrice.ToString();
                    switch (joker.Weapon.Rarity)
                    {
                        case Rarity.Common:
                            jokerWeapon.BackColor = Color.LightGray; // Dostosuj kolor do poziomu Rarity
                            break;
                        case Rarity.Rare:
                            jokerWeapon.BackColor = Color.LightBlue; // Dostosuj kolor do poziomu Rarity
                            break;
                        case Rarity.Epic:
                            jokerWeapon.BackColor = Color.DarkMagenta; // Dostosuj kolor do poziomu Rarity
                            break;
                        case Rarity.Legendary:
                            jokerWeapon.BackColor = Color.Orange; // Dostosuj kolor do poziomu Rarity
                            break;
                        default:
                            break;
                    }
                }
                else
                {
                    jokerWeapon.Text = "Brak";
                    jokerWeapon.AccessibleDescription = "  ";
                }
                if (joker.Armor != null)
                {
                    jokerArmor.Text = joker.Armor.Name;
                    jokerArmor.AccessibleDescription = joker.Armor.Name + Environment.NewLine + joker.Armor.Description + Environment.NewLine + joker.Armor.Rarity + Environment.NewLine + "DmgReduction: " + joker.Armor.DmgReduction.ToString()
                    + Environment.NewLine + "Dostepne dla Klas:" + Environment.NewLine + string.Join("," + Environment.NewLine, joker.Armor.AllowedCharacters.Select(characterType => characterType.ToString())) + Environment.NewLine + "Wartosc:" + Environment.NewLine + joker.Armor.SalesPrice.ToString();
                    switch (joker.Armor.Rarity)
                    {
                        case Rarity.Common:
                            jokerArmor.BackColor = Color.LightGray; // Dostosuj kolor do poziomu Rarity
                            break;
                        case Rarity.Rare:
                            jokerArmor.BackColor = Color.LightBlue; // Dostosuj kolor do poziomu Rarity
                            break;
                        case Rarity.Epic:
                            jokerArmor.BackColor = Color.DarkMagenta; // Dostosuj kolor do poziomu Rarity
                            break;
                        case Rarity.Legendary:
                            jokerArmor.BackColor = Color.Orange; // Dostosuj kolor do poziomu Rarity
                            break;
                        default:
                            break;
                    }
                }
                else
                {
                    jokerArmor.Text = "Brak";
                    jokerArmor.AccessibleDescription = "  ";
                }



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
            gameState.rogue = rogue;
            gameState.knight = knight;
            gameState.cleric = cleric;
            gameState.joker = joker;

            List<Weapon> weapons = new List<Weapon>();
            List<Weapon> equippedWeapons = new List<Weapon>();
            List<Weapon> shopWeapons = new List<Weapon>();
            List<Armor> armors = new List<Armor>();
            List<Armor> equippedArmors = new List<Armor>();
            List<Armor> shopArmors = new List<Armor>();

            foreach (IEkwipunek item in Ekwipunek)
            {
                if (item is Weapon)
                {
                    weapons.Add((Weapon)item);
                }
                else
                {
                    armors.Add((Armor)item);

                }
            }

            foreach (IEkwipunek item in equipedItems)
            {
                if (item is Weapon)
                {
                    equippedWeapons.Add((Weapon)item);
                }
                else
                {
                    equippedArmors.Add((Armor)item);

                }
            }

            foreach (IEkwipunek item in shopItems)
            {
                if (item is Weapon)
                {
                    shopWeapons.Add((Weapon)item);
                }
                else
                {
                    shopArmors.Add((Armor)item);

                }
            }
            gameState.armors = armors;
            gameState.weapons = weapons;
            gameState.equippedWeapons = equippedWeapons;
            gameState.equippedArmors = equippedArmors;
            gameState.shopWeapons = shopWeapons;
            gameState.shopArmors = shopArmors;
            gameState.expeditions = Expeditons;
            gameState.gold = gold;
            gameState.eventQuest = eventQuest;
            gameState.eventResult = eventResult;
            gameState.gold = gold;
            string json = JsonConvert.SerializeObject(gameState);
            File.WriteAllText("game_state.json", json);
        }

        //Inicjalizacja Przeciagania

        private void InitializeCharactersDragDrop()
        {



            knightWeapon.AllowDrop = true;
            knightWeapon.MouseDown += ItemMouseDown;
            knightWeapon.MouseHover += ItemMouseHover;
            knightWeapon.DragDrop += KnightWeapon_DragDrop;
            knightWeapon.DragEnter += KnightWeapon_DragEnter;
            knightWeapon.DragLeave += KnightWeapon_DragLeave;
            knightArmor.AllowDrop = true;
            knightArmor.MouseDown += ItemMouseDown;
            knightArmor.MouseHover += ItemMouseHover;
            knightArmor.DragDrop += KnightArmor_DragDrop;
            knightArmor.DragEnter += KnightArmor_DragEnter;
            knightArmor.DragLeave += KnightArmor_DragLeave;

            rogueWeapon.AllowDrop = true;
            rogueWeapon.MouseDown += ItemMouseDown;
            rogueWeapon.MouseHover += ItemMouseHover;
            rogueWeapon.DragDrop += RogueWeapon_DragDrop;
            rogueWeapon.DragEnter += RogueWeapon_DragEnter;
            rogueWeapon.DragLeave += RogueWeapon_DragLeave;
            rogueArmor.AllowDrop = true;
            rogueArmor.MouseDown += ItemMouseDown;
            rogueArmor.MouseHover += ItemMouseHover;
            rogueArmor.DragDrop += RogueArmor_DragDrop;
            rogueArmor.DragEnter += RogueArmor_DragEnter;
            rogueArmor.DragLeave += RogueArmor_DragLeave;

            clericWeapon.AllowDrop = true;
            clericWeapon.MouseDown += ItemMouseDown;
            clericWeapon.MouseHover += ItemMouseHover;
            clericWeapon.DragDrop += ClericWeapon_DragDrop;
            clericWeapon.DragEnter += ClericWeapon_DragEnter;
            clericWeapon.DragLeave += ClericWeapon_DragLeave;
            clericArmor.AllowDrop = true;
            clericArmor.MouseDown += ItemMouseDown;
            clericArmor.MouseHover += ItemMouseHover;
            clericArmor.DragDrop += ClericArmor_DragDrop;
            clericArmor.DragEnter += ClericArmor_DragEnter;
            clericArmor.DragLeave += ClericArmor_DragLeave;

            jokerWeapon.AllowDrop = true;
            jokerWeapon.MouseDown += ItemMouseDown;
            jokerWeapon.MouseHover += ItemMouseHover;
            jokerWeapon.DragDrop += JokerWeapon_DragDrop;
            jokerWeapon.DragEnter += JokerWeapon_DragEnter;
            jokerWeapon.DragLeave += JokerWeapon_DragLeave;
            jokerArmor.AllowDrop = true;
            jokerArmor.MouseDown += ItemMouseDown;
            jokerArmor.MouseHover += ItemMouseHover;
            jokerArmor.DragDrop += JokerArmor_DragDrop;
            jokerArmor.DragEnter += JokerArmor_DragEnter;
            jokerArmor.DragLeave += JokerArmor_DragLeave;






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





        //Przeciaganie Knight

        private void KnightWeapon_DragEnter(object sender, DragEventArgs e)
        {
            //knightWeapon.BackColor = Color.LightGray;
            e.Effect = DragDropEffects.Move;
        }

        private void KnightWeapon_DragLeave(object sender, EventArgs e)
        {
            //knightWeapon.BackColor = SystemColors.Control;
        }

        private void KnightWeapon_DragDrop(object sender, DragEventArgs e)
        {
            if (!CheckLabel(lastDraggedLabel))
            {
                try
                {
                    string draggedItemText = (string)e.Data.GetData(DataFormats.Text);
                    IEkwipunek itemToSelect = Ekwipunek.FirstOrDefault(item => item.Wypisz() == draggedItemText && item is Weapon);

                    if (itemToSelect != null)
                    {
                        if (knightWeapon.Text != "Brak")
                        {
                            itemToSelect.Equip(knight);
                            string oldItem = knightWeapon.Text;
                            AddItemToInventory(oldItem, false);
                            equipedItems.Add(itemToSelect);
                            knightWeapon.Text = draggedItemText;
                            knightWeapon.BackColor = SystemColors.Control;

                            Ekwipunek.Remove(itemToSelect);
                            RefreshInventory();
                            knight.UpdateStats();
                            RefreshStats();
                        }
                        else
                        {
                            itemToSelect.Equip(knight);
                            equipedItems.Add(itemToSelect);
                            knightWeapon.Text = draggedItemText;
                            knightWeapon.BackColor = SystemColors.Control;

                            Ekwipunek.Remove(itemToSelect);
                            RefreshInventory();
                            knight.UpdateStats();
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
        private void KnightArmor_DragEnter(object sender, DragEventArgs e)
        {
            //knightArmor.BackColor = Color.LightGray;
            e.Effect = DragDropEffects.Move;
        }

        private void KnightArmor_DragLeave(object sender, EventArgs e)
        {
            //knightArmor.BackColor = SystemColors.Control;
        }

        private void KnightArmor_DragDrop(object sender, DragEventArgs e)
        {
            if (!CheckLabel(lastDraggedLabel))
            {
                try
                {
                    string draggedItemText = (string)e.Data.GetData(DataFormats.Text);
                    IEkwipunek itemToSelect = Ekwipunek.FirstOrDefault(item => item.Wypisz() == draggedItemText && item is Armor);

                    if (itemToSelect != null)
                    {
                        if (knightArmor.Text != "Brak")
                        {
                            itemToSelect.Equip(knight);
                            string oldItem = knightArmor.Text;
                            AddItemToInventory(oldItem, false);
                            equipedItems.Add(itemToSelect);
                            knightArmor.Text = draggedItemText;
                            knightArmor.BackColor = SystemColors.Control;

                            Ekwipunek.Remove(itemToSelect);
                            RefreshInventory();
                            knight.UpdateStats();
                            RefreshStats();
                        }
                        else
                        {
                            itemToSelect.Equip(knight);
                            equipedItems.Add(itemToSelect);
                            knightArmor.Text = draggedItemText;
                            knightArmor.BackColor = SystemColors.Control;

                            Ekwipunek.Remove(itemToSelect);
                            RefreshInventory();
                            knight.UpdateStats();
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


        //Przeciaganie Rogue

        private void RogueWeapon_DragEnter(object sender, DragEventArgs e)
        {
            //rogueWeapon.BackColor = Color.LightGray;
            e.Effect = DragDropEffects.Move;
        }

        private void RogueWeapon_DragLeave(object sender, EventArgs e)
        {
            //rogueWeapon.BackColor = SystemColors.Control;
        }

        private void RogueWeapon_DragDrop(object sender, DragEventArgs e)
        {
            if (!CheckLabel(lastDraggedLabel))
            {
                try
                {
                    string draggedItemText = (string)e.Data.GetData(DataFormats.Text);
                    IEkwipunek itemToSelect = Ekwipunek.FirstOrDefault(item => item.Wypisz() == draggedItemText && item is Weapon);

                    if (itemToSelect != null)
                    {
                        if (rogueWeapon.Text != "Brak")
                        {
                            itemToSelect.Equip(rogue);
                            string oldItem = rogueWeapon.Text;
                            AddItemToInventory(oldItem, false);
                            equipedItems.Add(itemToSelect);
                            rogueWeapon.Text = draggedItemText;
                            rogueWeapon.BackColor = SystemColors.Control;

                            Ekwipunek.Remove(itemToSelect);
                            RefreshInventory();
                            rogue.UpdateStats();
                            RefreshStats();
                        }
                        else
                        {
                            itemToSelect.Equip(rogue);
                            equipedItems.Add(itemToSelect);
                            rogueWeapon.Text = draggedItemText;
                            rogueWeapon.BackColor = SystemColors.Control;

                            Ekwipunek.Remove(itemToSelect);
                            RefreshInventory();
                            rogue.UpdateStats();
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
        private void RogueArmor_DragEnter(object sender, DragEventArgs e)
        {
            //rogueArmor.BackColor = Color.LightGray;
            e.Effect = DragDropEffects.Move;
        }

        private void RogueArmor_DragLeave(object sender, EventArgs e)
        {
            //rogueArmor.BackColor = SystemColors.Control;
        }

        private void RogueArmor_DragDrop(object sender, DragEventArgs e)
        {
            if (!CheckLabel(lastDraggedLabel))
            {
                try
                {
                    string draggedItemText = (string)e.Data.GetData(DataFormats.Text);
                    IEkwipunek itemToSelect = Ekwipunek.FirstOrDefault(item => item.Wypisz() == draggedItemText && item is Armor);

                    if (itemToSelect != null)
                    {
                        if (rogueArmor.Text != "Brak")
                        {
                            itemToSelect.Equip(rogue);
                            string oldItem = rogueArmor.Text;
                            AddItemToInventory(oldItem, false);
                            equipedItems.Add(itemToSelect);
                            rogueArmor.Text = draggedItemText;
                            rogueArmor.BackColor = SystemColors.Control;

                            Ekwipunek.Remove(itemToSelect);
                            RefreshInventory();
                            rogue.UpdateStats();
                            RefreshStats();
                        }
                        else
                        {
                            itemToSelect.Equip(rogue);
                            equipedItems.Add(itemToSelect);
                            rogueArmor.Text = draggedItemText;
                            rogueArmor.BackColor = SystemColors.Control;

                            Ekwipunek.Remove(itemToSelect);
                            RefreshInventory();
                            rogue.UpdateStats();
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




        //Przeciaganie Cleric

        private void ClericWeapon_DragEnter(object sender, DragEventArgs e)
        {
            //clericWeapon.BackColor = Color.LightGray;
            e.Effect = DragDropEffects.Move;
        }

        private void ClericWeapon_DragLeave(object sender, EventArgs e)
        {
            //clericWeapon.BackColor = SystemColors.Control;
        }

        private void ClericWeapon_DragDrop(object sender, DragEventArgs e)
        {
            if (!CheckLabel(lastDraggedLabel))
            {
                try
                {
                    string draggedItemText = (string)e.Data.GetData(DataFormats.Text);
                    IEkwipunek itemToSelect = Ekwipunek.FirstOrDefault(item => item.Wypisz() == draggedItemText && item is Weapon);

                    if (itemToSelect != null)
                    {
                        if (clericWeapon.Text != "Brak")
                        {
                            itemToSelect.Equip(cleric);
                            string oldItem = clericWeapon.Text;
                            AddItemToInventory(oldItem, false);
                            equipedItems.Add(itemToSelect);
                            clericWeapon.Text = draggedItemText;
                            clericWeapon.BackColor = SystemColors.Control;

                            Ekwipunek.Remove(itemToSelect);
                            RefreshInventory();
                            cleric.UpdateStats();
                            RefreshStats();
                        }
                        else
                        {
                            itemToSelect.Equip(cleric);
                            equipedItems.Add(itemToSelect);
                            clericWeapon.Text = draggedItemText;
                            clericWeapon.BackColor = SystemColors.Control;

                            Ekwipunek.Remove(itemToSelect);
                            RefreshInventory();
                            cleric.UpdateStats();
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
        private void ClericArmor_DragEnter(object sender, DragEventArgs e)
        {
            //clericArmor.BackColor = Color.LightGray;
            e.Effect = DragDropEffects.Move;
        }

        private void ClericArmor_DragLeave(object sender, EventArgs e)
        {
            //clericArmor.BackColor = SystemColors.Control;
        }

        private void ClericArmor_DragDrop(object sender, DragEventArgs e)
        {
            if (!CheckLabel(lastDraggedLabel))
            {
                try
                {
                    string draggedItemText = (string)e.Data.GetData(DataFormats.Text);
                    IEkwipunek itemToSelect = Ekwipunek.FirstOrDefault(item => item.Wypisz() == draggedItemText && item is Armor);

                    if (itemToSelect != null)
                    {
                        if (clericArmor.Text != "Brak")
                        {
                            itemToSelect.Equip(cleric);
                            string oldItem = clericArmor.Text;
                            AddItemToInventory(oldItem, false);
                            equipedItems.Add(itemToSelect);
                            clericArmor.Text = draggedItemText;
                            clericArmor.BackColor = SystemColors.Control;

                            Ekwipunek.Remove(itemToSelect);
                            RefreshInventory();
                            cleric.UpdateStats();
                            RefreshStats();
                        }
                        else
                        {
                            itemToSelect.Equip(cleric);
                            equipedItems.Add(itemToSelect);
                            clericArmor.Text = draggedItemText;
                            clericArmor.BackColor = SystemColors.Control;

                            Ekwipunek.Remove(itemToSelect);
                            RefreshInventory();
                            cleric.UpdateStats();
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




        //Przeciaganie Joker

        private void JokerWeapon_DragEnter(object sender, DragEventArgs e)
        {
            //jokerWeapon.BackColor = Color.LightGray;
            e.Effect = DragDropEffects.Move;
        }

        private void JokerWeapon_DragLeave(object sender, EventArgs e)
        {
            //jokerWeapon.BackColor = SystemColors.Control;
        }

        private void JokerWeapon_DragDrop(object sender, DragEventArgs e)
        {
            if (!CheckLabel(lastDraggedLabel))
            {
                try
                {
                    string draggedItemText = (string)e.Data.GetData(DataFormats.Text);
                    IEkwipunek itemToSelect = Ekwipunek.FirstOrDefault(item => item.Wypisz() == draggedItemText && item is Weapon);

                    if (itemToSelect != null)
                    {
                        if (jokerWeapon.Text != "Brak")
                        {
                            itemToSelect.Equip(joker);
                            string oldItem = jokerWeapon.Text;
                            AddItemToInventory(oldItem, false);
                            equipedItems.Add(itemToSelect);
                            jokerWeapon.Text = draggedItemText;
                            jokerWeapon.BackColor = SystemColors.Control;

                            Ekwipunek.Remove(itemToSelect);
                            RefreshInventory();
                            joker.UpdateStats();
                            RefreshStats();
                        }
                        else
                        {
                            itemToSelect.Equip(joker);
                            equipedItems.Add(itemToSelect);
                            jokerWeapon.Text = draggedItemText;
                            jokerWeapon.BackColor = SystemColors.Control;

                            Ekwipunek.Remove(itemToSelect);
                            RefreshInventory();
                            joker.UpdateStats();
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
        private void JokerArmor_DragEnter(object sender, DragEventArgs e)
        {
            //jokerArmor.BackColor = Color.LightGray;
            e.Effect = DragDropEffects.Move;
        }

        private void JokerArmor_DragLeave(object sender, EventArgs e)
        {
            //jokerArmor.BackColor = SystemColors.Control;
        }

        private void JokerArmor_DragDrop(object sender, DragEventArgs e)
        {
            if (!CheckLabel(lastDraggedLabel))
            {
                try
                {
                    string draggedItemText = (string)e.Data.GetData(DataFormats.Text);
                    IEkwipunek itemToSelect = Ekwipunek.FirstOrDefault(item => item.Wypisz() == draggedItemText && item is Armor);

                    if (itemToSelect != null)
                    {
                        if (jokerArmor.Text != "Brak")
                        {
                            itemToSelect.Equip(joker);
                            string oldItem = jokerArmor.Text;
                            AddItemToInventory(oldItem, false);
                            equipedItems.Add(itemToSelect);
                            jokerArmor.Text = draggedItemText;
                            jokerArmor.BackColor = SystemColors.Control;

                            Ekwipunek.Remove(itemToSelect);
                            RefreshInventory();
                            joker.UpdateStats();
                            RefreshStats();
                        }
                        else
                        {
                            itemToSelect.Equip(joker);
                            equipedItems.Add(itemToSelect);
                            jokerArmor.Text = draggedItemText;
                            jokerArmor.BackColor = SystemColors.Control;

                            Ekwipunek.Remove(itemToSelect);
                            RefreshInventory();
                            joker.UpdateStats();
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
                if (lastDraggedLabel == knightWeapon)
                {
                    knight.Weapon = null;
                    PlayEquipWeaponSound();
                }
                knight.UpdateStats();
                if (lastDraggedLabel == knightArmor)
                {
                    knight.Armor = null;
                    PlayEquipArmorSound();
                }
                knight.UpdateStats();
                if (lastDraggedLabel == rogueWeapon)
                {
                    rogue.Weapon = null;
                    PlayEquipWeaponSound();
                }
                rogue.UpdateStats();
                if (lastDraggedLabel == rogueArmor)
                {
                    rogue.Armor = null;
                    PlayEquipArmorSound();
                }
                rogue.UpdateStats();
                if (lastDraggedLabel == clericWeapon)
                {
                    cleric.Weapon = null;
                    PlayEquipWeaponSound();
                }
                cleric.UpdateStats();
                if (lastDraggedLabel == clericArmor)
                {
                    cleric.Armor = null;
                    PlayEquipArmorSound();
                }
                cleric.UpdateStats();
                if (lastDraggedLabel == jokerWeapon)
                {
                    joker.Weapon = null;
                    PlayEquipWeaponSound();
                }
                joker.UpdateStats();
                if (lastDraggedLabel == jokerArmor)
                {
                    joker.Armor = null;
                    PlayEquipArmorSound();
                }
                joker.UpdateStats();


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
            if (label == knightWeapon ||
                label == knightArmor ||
                label == rogueWeapon ||
                label == rogueArmor ||
                label == clericWeapon ||
                label == clericArmor ||
                label == jokerWeapon ||
                label == jokerArmor)
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
                knight.GainExperience(wyprawa.ExperienceGains);
                rogue.GainExperience(wyprawa.ExperienceGains);
                cleric.GainExperience(wyprawa.ExperienceGains);
                joker.GainExperience(wyprawa.ExperienceGains);


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
                knight.Weapon = null; knight.UpdateStats();
                knight.Armor = null; knight.UpdateStats();
                rogue.Weapon = null; rogue.UpdateStats();
                rogue.Armor = null; rogue.UpdateStats();
                cleric.Weapon = null; cleric.UpdateStats();
                cleric.Armor = null; cleric.UpdateStats();
                joker.Weapon = null; joker.UpdateStats();
                joker.Armor = null; joker.UpdateStats();
                RefreshStats();
            }
            knight.CurrentHP = knight.MaxHP;
            rogue.CurrentHP = rogue.MaxHP;
            cleric.CurrentHP = cleric.MaxHP;
            joker.CurrentHP = joker.MaxHP;
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
