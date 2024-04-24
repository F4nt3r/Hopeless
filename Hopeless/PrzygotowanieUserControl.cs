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

        public PrzygotowanieUserControl()
        {
            InitializeComponent();
            pictureBox1.Image = Properties.Resources.Prep;

            this.Load += PrzygotowanieUserControl_Load;
            

        }
        private void PrzygotowanieUserControl_Load(object sender, EventArgs e)
        {
            knight = (Knight)Characters[0];
            if (Characters != null && Characters.Any())
            {
                
                knightName.Text += knight.Name;
                knightLevel.Text += knight.Level;
                knightExp.Text += knight.ExperiencePoints;
                knightStrength.Text += knight.Strength;
                knightDexterity.Text += knight.Dexterity;
                knightIntelligence.Text += knight.Intelligence;
                knightHp.Text += knight.CurrentHP + "/" + knight.MaxHP;
                knightResistance.Text += knight.Resistance;
                knightCrit.Text += knight.CritChance+"%";
                knightInitiative.Text += knight.Initiative;
                knightDmg.Text += knight.MinDmg + "-" + knight.MaxDmg;
                knightBlock.Text += knight.BlockChance + "%";

                if (knight.Weapon != null) knightWeapon.Text = knight.Weapon.Name;
                else knightWeapon.Text = "Brak";
                if (knight.Armor != null) knightArmor.Text = knight.Armor.Name;
                else knightArmor.Text = "Brak";

                

                rogueName.Text += Characters[1].Name;
                rogueLevel.Text += Characters[1].Level;
                rogueExp.Text += Characters[1].ExperiencePoints;
                rogueStrength.Text += Characters[1].Strength;
                rogueDexterity.Text += Characters[1].Dexterity;
                rogueIntelligence.Text += Characters[1].Intelligence;
                rogueHp.Text += Characters[1].CurrentHP + "/" + Characters[1].MaxHP;
                rogueResistance.Text += Characters[1].Resistance;
                rogueCrit.Text += Characters[1].CritChance;
                rogueInitiative.Text += Characters[1].Initiative;
                rogueDmg.Text += Characters[1].MinDmg + "-" + Characters[1].MaxDmg;

                clericName.Text += Characters[2].Name;
                clericLevel.Text += Characters[2].Level;
                clericExp.Text += Characters[2].ExperiencePoints;
                clericStrength.Text += Characters[2].Strength;
                clericDexterity.Text += Characters[2].Dexterity;
                clericIntelligence.Text += Characters[2].Intelligence;
                clericHp.Text += Characters[2].CurrentHP + "/" + Characters[2].MaxHP;
                clericResistance.Text += Characters[2].Resistance;
                clericCrit.Text += Characters[2].CritChance;
                clericInitiative.Text += Characters[2].Initiative;
                clericDmg.Text += Characters[2].MinDmg + "-" + Characters[2].MaxDmg;

                jokerName.Text += Characters[3].Name;
                jokerLevel.Text += Characters[3].Level;
                jokerExp.Text += Characters[3].ExperiencePoints;
                jokerStrength.Text += Characters[3].Strength;
                jokerDexterity.Text += Characters[3].Dexterity;
                jokerIntelligence.Text += Characters[3].Intelligence;
                jokerHp.Text += Characters[3].CurrentHP + "/" + Characters[3].MaxHP;
                jokerResistance.Text += Characters[3].Resistance;
                jokerCrit.Text += Characters[3].CritChance;
                jokerInitiative.Text += Characters[3].Initiative;
                jokerDmg.Text += Characters[3].MinDmg + "-" + Characters[3].MaxDmg;


            }

            if (Ekwipunek != null && Ekwipunek.Any())
            {
                foreach (IEkwipunek item in Ekwipunek)
                {
                    Label label = new Label();
                    label.Text = item.Wypisz();
                    label.AutoSize = false;
                    label.Height = 30;
                    label.TextAlign = ContentAlignment.MiddleCenter;
                    label.BorderStyle = BorderStyle.FixedSingle;
                    Inventory.Controls.Add(label);

                }

            }


            InitializeDragDrop();




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
            knightWeapon.DragDrop += KnightWeapon_DragDrop;
            knightWeapon.DragEnter += KnightWeapon_DragEnter;
            knightWeapon.DragLeave += KnightWeapon_DragLeave;


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
                        string oldItem = knightWeapon.Text;
                        AddItemToInventory(oldItem);

                    }
                    itemToSelect.Equip(knight);
                    removedItems.Add(itemToSelect);
                    knightWeapon.Text = draggedItemText;
                    knightWeapon.BackColor = SystemColors.Control;

                    Ekwipunek.Remove(itemToSelect);
                    RefreshInventory();

                }



            }
            catch (ClassWeaponException ex)
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

            Knight knight = (Knight)Characters[0];
            

            if (lastDraggedLabel != null && lastDraggedLabel.Text != draggedItemText)
            {
                lastDraggedLabel.Text = "Brak";
                knight.Weapon = null;
            }
            AddItemToInventory(draggedItemText);
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
                    Inventory.Controls.Add(label);
                }
                foreach (Control control in Inventory.Controls)
                {
                    control.MouseDown += ItemMouseDown;
                }

        }

    }
}
