using HopelessLibary;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Hopeless
{
    public partial class PrzygotowanieUserControl : UserControl
    {
        public List<Character> Characters { get; set; }
        public List<IEkwipunek> Ekwipunek { get; set; }
        public PrzygotowanieUserControl()
        {
            InitializeComponent();
            pictureBox1.Image = Properties.Resources.Prep;

            this.Load += PrzygotowanieUserControl_Load;

        }
        private void PrzygotowanieUserControl_Load(object sender, EventArgs e)
        {
            if (Characters != null && Characters.Any())
            {
                
                knightName.Text += Characters[0].Name;
                knightLevel.Text += Characters[0].Level;
                knightExp.Text += Characters[0].ExperiencePoints;
                knightStrength.Text += Characters[0].Strength;
                knightDexterity.Text += Characters[0].Dexterity;
                knightIntelligence.Text += Characters[0].Intelligence;
                knightHp.Text += Characters[0].CurrentHP + "/" + Characters[0].MaxHP;
                knightResistance.Text += Characters[0].Resistance;
                knightCrit.Text += Characters[0].CritChance;
                knightInitiative.Text += Characters[0].Initiative;
                knightDmg.Text += Characters[0].MinDmg + "-" + Characters[0].MaxDmg;
                if (Characters[0] is Knight knight)
                {
                    if (knight.Weapon != null) knightWeapon.Text = knight.Weapon.Wypisz();
                    else knightWeapon.Text = "Brak";

                }
                

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




        //Przeciaganie przedmiotow

        private void InitializeDragDrop()
        {
            foreach (Control control in Inventory.Controls)
            {
                control.MouseDown += ItemMouseDown;
            }

            knightWeapon.AllowDrop = true;
            knightWeapon.DragDrop += KnightWeapon_DragDrop;
            knightWeapon.DragEnter += KnightWeapon_DragEnter;
            knightWeapon.DragLeave += KnightWeapon_DragLeave;



        }


        private void ItemMouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                Control control = (Control)sender;
                control.DoDragDrop(control.Text, DragDropEffects.Move);
            }
        }

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
            
                
                string draggedItemText = (string)e.Data.GetData(DataFormats.Text);
                knightWeapon.Text = draggedItemText;
                knightWeapon.BackColor = SystemColors.Control;

                IEkwipunek itemToRemove = Ekwipunek.FirstOrDefault(item => item.Wypisz() == draggedItemText);
                Ekwipunek.Remove(itemToRemove);
                RefreshInventory();
            
            

        }

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
                InitializeDragDrop();
            
        }

    }
}
