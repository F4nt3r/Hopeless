using HopelessLibary;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows.Forms;
using static HopelessLibary.Armor;
using static HopelessLibary.Weapon;

namespace Hopeless
{
    public partial class PrzygotowanieUserControl : UserControl
    {
        public List<Character> Characters { get; set; }
        public List<IEkwipunek> Ekwipunek { get; set; }
        private List<IEkwipunek> removedItems = new List<IEkwipunek>();
        private Label lastDraggedLabel;
        public Knight knight;
        public Rogue rogue;
        public Cleric cleric;
        public Joker joker;

        public PrzygotowanieUserControl()
        {
            InitializeComponent();
            pictureBox1.Image = Properties.Resources.Prep;

            this.Load += PrzygotowanieUserControl_Load;
            

        }
        private void PrzygotowanieUserControl_Load(object sender, EventArgs e)
        {
            RefreshStats();
            RefreshInventory();
            InitializeDragDrop();
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
                    knightWeapon.AccessibleDescription = knight.Weapon.Name + Environment.NewLine + knight.Weapon.Description + Environment.NewLine + "MinDMG: " + knight.Weapon.MinDmg.ToString() +
                        Environment.NewLine + "MaxDMG: " + knight.Weapon.MaxDmg.ToString();
                }
                else
                {
                    knightWeapon.Text = "Brak";
                    knightWeapon.AccessibleDescription = "  ";
                }
                
                if (knight.Armor != null)
                {
                    knightArmor.Text = knight.Armor.Name;
                    knightArmor.AccessibleDescription = knight.Armor.Name + Environment.NewLine + knight.Armor.Description + Environment.NewLine + "DmgReduction: " + knight.Armor.DmgReduction.ToString();
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
                rogueDodge.Text = "Szansa na Blok: " + rogue.DodgeChance + "%";
                if (rogue.Weapon != null) {
                    rogueWeapon.Text = rogue.Weapon.Name;
                    rogueWeapon.AccessibleDescription = rogue.Weapon.Name + Environment.NewLine + rogue.Weapon.Description + Environment.NewLine + "MinDMG: "+ rogue.Weapon.MinDmg.ToString() +
                        Environment.NewLine + "MaxDMG: "+ rogue.Weapon.MaxDmg.ToString();
                }
                else
                {
                    rogueWeapon.Text = "Brak";
                    rogueWeapon.AccessibleDescription = "  ";
                }
                if (rogue.Armor != null)
                {
                    rogueArmor.Text = rogue.Armor.Name;
                    rogueArmor.AccessibleDescription = rogue.Armor.Name + Environment.NewLine + rogue.Armor.Description + Environment.NewLine + "DmgReduction: " + rogue.Armor.DmgReduction.ToString();
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
                    clericWeapon.AccessibleDescription = cleric.Weapon.Name + Environment.NewLine + cleric.Weapon.Description + Environment.NewLine + "MinDMG: " + cleric.Weapon.MinDmg.ToString() +
                        Environment.NewLine + "MaxDMG: " + cleric.Weapon.MaxDmg.ToString();
                }
                else
                {
                    clericWeapon.Text = "Brak";
                    clericWeapon.AccessibleDescription = "  ";
                }
                if (cleric.Armor != null)
                {
                    clericArmor.Text = cleric.Armor.Name;
                    clericArmor.AccessibleDescription = cleric.Armor.Name + Environment.NewLine + cleric.Armor.Description + Environment.NewLine + "DmgReduction: " + cleric.Armor.DmgReduction.ToString();
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
                    jokerWeapon.AccessibleDescription = joker.Weapon.Name + Environment.NewLine + joker.Weapon.Description + Environment.NewLine + "MinDMG: " + joker.Weapon.MinDmg.ToString() +
                        Environment.NewLine + "MaxDMG: " + joker.Weapon.MaxDmg.ToString();
                }
                else
                {
                    jokerWeapon.Text = "Brak";
                    jokerWeapon.AccessibleDescription = "  ";
                }
                if (joker.Armor != null)
                {
                    jokerArmor.Text = joker.Armor.Name;
                    jokerArmor.AccessibleDescription = joker.Armor.Name + Environment.NewLine + joker.Armor.Description + Environment.NewLine + "DmgReduction: " + joker.Armor.DmgReduction.ToString();
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
        }




        //Inicjalizacja Przeciagania

        private void InitializeDragDrop()
        {
            foreach (Control control in Inventory.Controls)
            {
                control.MouseDown += ItemMouseDown;
            }

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


            Inventory.AllowDrop = true;
            Inventory.DragEnter += Inventory_DragEnter;
            Inventory.DragLeave += Inventory_DragLeave;
            Inventory.DragDrop += Inventory_DragDrop;



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
            string itemDescription = label.AccessibleDescription;
            DescriptionBox.Text = itemDescription;
        }





        //Przeciaganie Knight

        private void KnightWeapon_DragEnter(object sender, DragEventArgs e)
        {
            knightWeapon.BackColor = Color.LightGray;
            e.Effect = DragDropEffects.Move;
        }

        private void KnightWeapon_DragLeave(object sender, EventArgs e)
        {
            knightWeapon.BackColor = SystemColors.Control;
        }

        private void KnightWeapon_DragDrop(object sender, DragEventArgs e)
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
                        AddItemToInventory(oldItem);
                        removedItems.Add(itemToSelect);
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
                        removedItems.Add(itemToSelect);
                        knightWeapon.Text = draggedItemText;
                        knightWeapon.BackColor = SystemColors.Control;

                        Ekwipunek.Remove(itemToSelect);
                        RefreshInventory();
                        knight.UpdateStats();
                        RefreshStats();
                    }
                   
                }

            }
            catch (ClassWeaponException ex)
            {
                MessageBox.Show(ex.Message, "Weapon Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
        }
        private void KnightArmor_DragEnter(object sender, DragEventArgs e)
        {
            knightArmor.BackColor = Color.LightGray;
            e.Effect = DragDropEffects.Move;
        }

        private void KnightArmor_DragLeave(object sender, EventArgs e)
        {
            knightArmor.BackColor = SystemColors.Control;
        }

        private void KnightArmor_DragDrop(object sender, DragEventArgs e)
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
                        AddItemToInventory(oldItem);
                        removedItems.Add(itemToSelect);
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
                        removedItems.Add(itemToSelect);
                        knightArmor.Text = draggedItemText;
                        knightArmor.BackColor = SystemColors.Control;

                        Ekwipunek.Remove(itemToSelect);
                        RefreshInventory();
                        knight.UpdateStats();
                        RefreshStats();
                    }

                }

            }
            catch (ClassArmorException ex)
            {
                MessageBox.Show(ex.Message, "Weapon Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        //Przeciaganie Rogue

        private void RogueWeapon_DragEnter(object sender, DragEventArgs e)
        {
            rogueWeapon.BackColor = Color.LightGray;
            e.Effect = DragDropEffects.Move;
        }

        private void RogueWeapon_DragLeave(object sender, EventArgs e)
        {
            rogueWeapon.BackColor = SystemColors.Control;
        }

        private void RogueWeapon_DragDrop(object sender, DragEventArgs e)
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
                        AddItemToInventory(oldItem);
                        removedItems.Add(itemToSelect);
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
                        removedItems.Add(itemToSelect);
                        rogueWeapon.Text = draggedItemText;
                        rogueWeapon.BackColor = SystemColors.Control;

                        Ekwipunek.Remove(itemToSelect);
                        RefreshInventory();
                        rogue.UpdateStats();
                        RefreshStats();
                    }

                }

            }
            catch (ClassWeaponException ex)
            {
                MessageBox.Show(ex.Message, "Weapon Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
        private void RogueArmor_DragEnter(object sender, DragEventArgs e)
        {
            rogueArmor.BackColor = Color.LightGray;
            e.Effect = DragDropEffects.Move;
        }

        private void RogueArmor_DragLeave(object sender, EventArgs e)
        {
            rogueArmor.BackColor = SystemColors.Control;
        }

        private void RogueArmor_DragDrop(object sender, DragEventArgs e)
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
                        AddItemToInventory(oldItem);
                        removedItems.Add(itemToSelect);
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
                        removedItems.Add(itemToSelect);
                        rogueArmor.Text = draggedItemText;
                        rogueArmor.BackColor = SystemColors.Control;

                        Ekwipunek.Remove(itemToSelect);
                        RefreshInventory();
                        rogue.UpdateStats();
                        RefreshStats();
                    }

                }

            }
            catch (ClassArmorException ex)
            {
                MessageBox.Show(ex.Message, "Weapon Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }




        //Przeciaganie Cleric

        private void ClericWeapon_DragEnter(object sender, DragEventArgs e)
        {
            clericWeapon.BackColor = Color.LightGray;
            e.Effect = DragDropEffects.Move;
        }

        private void ClericWeapon_DragLeave(object sender, EventArgs e)
        {
            clericWeapon.BackColor = SystemColors.Control;
        }

        private void ClericWeapon_DragDrop(object sender, DragEventArgs e)
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
                        AddItemToInventory(oldItem);
                        removedItems.Add(itemToSelect);
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
                        removedItems.Add(itemToSelect);
                        clericWeapon.Text = draggedItemText;
                        clericWeapon.BackColor = SystemColors.Control;

                        Ekwipunek.Remove(itemToSelect);
                        RefreshInventory();
                        cleric.UpdateStats();
                        RefreshStats();
                    }

                }

            }
            catch (ClassWeaponException ex)
            {
                MessageBox.Show(ex.Message, "Weapon Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
        private void ClericArmor_DragEnter(object sender, DragEventArgs e)
        {
            clericArmor.BackColor = Color.LightGray;
            e.Effect = DragDropEffects.Move;
        }

        private void ClericArmor_DragLeave(object sender, EventArgs e)
        {
            clericArmor.BackColor = SystemColors.Control;
        }

        private void ClericArmor_DragDrop(object sender, DragEventArgs e)
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
                        AddItemToInventory(oldItem);
                        removedItems.Add(itemToSelect);
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
                        removedItems.Add(itemToSelect);
                        clericArmor.Text = draggedItemText;
                        clericArmor.BackColor = SystemColors.Control;

                        Ekwipunek.Remove(itemToSelect);
                        RefreshInventory();
                        cleric.UpdateStats();
                        RefreshStats();
                    }

                }

            }
            catch (ClassArmorException ex)
            {
                MessageBox.Show(ex.Message, "Weapon Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }




        //Przeciaganie Joker

        private void JokerWeapon_DragEnter(object sender, DragEventArgs e)
        {
            jokerWeapon.BackColor = Color.LightGray;
            e.Effect = DragDropEffects.Move;
        }

        private void JokerWeapon_DragLeave(object sender, EventArgs e)
        {
            jokerWeapon.BackColor = SystemColors.Control;
        }

        private void JokerWeapon_DragDrop(object sender, DragEventArgs e)
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
                        AddItemToInventory(oldItem);
                        removedItems.Add(itemToSelect);
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
                        removedItems.Add(itemToSelect);
                        jokerWeapon.Text = draggedItemText;
                        jokerWeapon.BackColor = SystemColors.Control;

                        Ekwipunek.Remove(itemToSelect);
                        RefreshInventory();
                        joker.UpdateStats();
                        RefreshStats();
                    }

                }

            }
            catch (ClassWeaponException ex)
            {
                MessageBox.Show(ex.Message, "Weapon Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
        private void JokerArmor_DragEnter(object sender, DragEventArgs e)
        {
            jokerArmor.BackColor = Color.LightGray;
            e.Effect = DragDropEffects.Move;
        }

        private void JokerArmor_DragLeave(object sender, EventArgs e)
        {
            jokerArmor.BackColor = SystemColors.Control;
        }

        private void JokerArmor_DragDrop(object sender, DragEventArgs e)
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
                        AddItemToInventory(oldItem);
                        removedItems.Add(itemToSelect);
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
                        removedItems.Add(itemToSelect);
                        jokerArmor.Text = draggedItemText;
                        jokerArmor.BackColor = SystemColors.Control;

                        Ekwipunek.Remove(itemToSelect);
                        RefreshInventory();
                        joker.UpdateStats();
                        RefreshStats();
                    }

                }

            }
            catch (ClassArmorException ex)
            {
                MessageBox.Show(ex.Message, "Weapon Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }








        // Przeciaganie do ekwipunka


        private void Inventory_DragEnter(object sender, DragEventArgs e)
        {
            Control control = (Control)sender;
            control.BackColor = Color.LightGray;
            e.Effect = DragDropEffects.Move;
        }

        private void Inventory_DragLeave(object sender, EventArgs e)
        {
            Control control = (Control)sender;
            control.BackColor = SystemColors.Control;
        }

        private void Inventory_DragDrop(object sender, DragEventArgs e)
        {
            Control control = (Control)sender;
            control.BackColor = SystemColors.Control;

            string draggedItemText = (string)e.Data.GetData(DataFormats.Text);
            

            if (lastDraggedLabel != null && !Ekwipunek.Any(item => item.Wypisz() == draggedItemText))
            {
                lastDraggedLabel.Text = "Brak";
                if (lastDraggedLabel == knightWeapon) knight.Weapon = null; knight.UpdateStats();
                if (lastDraggedLabel == knightArmor) knight.Armor = null; knight.UpdateStats();
                if (lastDraggedLabel == rogueWeapon) rogue.Weapon = null; rogue.UpdateStats();
                if (lastDraggedLabel == rogueArmor) rogue.Armor = null; rogue.UpdateStats();
                if (lastDraggedLabel == clericWeapon) cleric.Weapon = null; cleric.UpdateStats();
                if (lastDraggedLabel == clericArmor) cleric.Armor = null; cleric.UpdateStats();
                if (lastDraggedLabel == jokerWeapon) joker.Weapon = null; joker.UpdateStats();
                if (lastDraggedLabel == jokerArmor) joker.Armor = null; joker.UpdateStats();


                AddItemToInventory(draggedItemText);
                RefreshStats();
            }
            
        }


        private void AddItemToInventory(string itemName)
        {
            IEkwipunek itemToAdd = removedItems.FirstOrDefault(item => item != null && item.Wypisz() == itemName);
            if (itemToAdd != null && !Ekwipunek.Contains(itemToAdd))
            {
                Ekwipunek.Add(itemToAdd);
                removedItems.Remove(itemToAdd);
                RefreshInventory();
            }
        }





        // Odswiezanie ekwipunku
        private void RefreshInventory()
        {
            
                Inventory.Controls.Clear();

                foreach (IEkwipunek item in Ekwipunek)
                {
                    Label label = new Label();
                    label.Text = item.Wypisz();
                    label.AutoSize = false;
                    label.Height = 30;
                    label.TextAlign = ContentAlignment.MiddleCenter;
                    label.BorderStyle = BorderStyle.FixedSingle;
                    if(item is Weapon)
                    {
                        Weapon weapon = (Weapon)item;
                        label.AccessibleDescription = weapon.Name + Environment.NewLine + weapon.Description + Environment.NewLine + "MinDMG: " + weapon.MinDmg.ToString() +
                        Environment.NewLine + "MaxDMG: " + weapon.MaxDmg.ToString();
                    }
                    if(item is Armor)
                    {
                        Armor armor = (Armor)item;
                        label.AccessibleDescription = armor.Name + Environment.NewLine + armor.Description + Environment.NewLine + "DmgReduction: " + armor.DmgReduction.ToString();
                }
                    Inventory.Controls.Add(label);
                }
                foreach (Control control in Inventory.Controls)
                {
                    control.MouseDown += ItemMouseDown;
                    control.MouseHover += ItemMouseHover;
                }

        }

        

    }
}
