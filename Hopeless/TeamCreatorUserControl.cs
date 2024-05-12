using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using HopelessLibary;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Hopeless
{
    public partial class TeamCreatorUserControl : UserControl
    {

        public List<Character> Characters { get; set; }
        public List<Character> ChooseCharacters = new List<Character>();
        public List<IInventory> CommonInventory { get; set; }
        public List<IInventory> StarterInventory = new List<IInventory>();


        public TeamCreatorUserControl()
        {
            InitializeComponent();
            pictureBox4.Image = Properties.Resources.Prep;
            this.VisibleChanged += TeamCreatorUserControl_VisibleChanged;
        }


        private void TeamCreatorUserControl_VisibleChanged(object? sender, EventArgs e)
        {
            var control = sender as UserControl;
            if (control != null)
            {
                if (control.Visible)
                {
                    LoadClass();
                }



            }
        }


        private void LoadClass()
        {
            character1.AllowDrop = true;
            character1.DragDrop += Character1_DragDrop;
            character1.DragEnter += Character1_DragEnter;
            character1.DragDrop += Character1_DragDrop;

            character2.AllowDrop = true;
            character2.DragDrop += Character2_DragDrop;
            character2.DragEnter += Character2_DragEnter;
            character2.DragDrop += Character2_DragDrop;

            character3.AllowDrop = true;
            character3.DragDrop += Character3_DragDrop;
            character3.DragEnter += Character3_DragEnter;
            character3.DragDrop += Character3_DragDrop;

            character4.AllowDrop = true;
            character4.DragDrop += Character4_DragDrop;
            character4.DragEnter += Character4_DragEnter;
            character4.DragDrop += Character4_DragDrop;

            foreach (Character character in Characters)
            {
                Label label = new Label();
                label.Text = character.Name;
                label.AutoSize = false;
                label.Height = 60;
                label.TextAlign = ContentAlignment.MiddleCenter;
                label.BorderStyle = BorderStyle.FixedSingle;
                CharacterClass.Controls.Add(label);
            }
            foreach (Control control in CharacterClass.Controls)
            {
                control.MouseDown += ItemMouseDown;
                control.MouseHover += ItemMouseHover;
            }


        }

        private void ItemMouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                Control control = (Control)sender;
                control.DoDragDrop(control.Text, DragDropEffects.Move);

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

        private void Character1_DragEnter(object sender, DragEventArgs e)
        {
            //knightWeapon.BackColor = Color.LightGray;
            e.Effect = DragDropEffects.Move;
        }

        private void Character1_DragLeave(object sender, EventArgs e)
        {
            //knightWeapon.BackColor = SystemColors.Control;
        }
        private void Character1_DragDrop(object sender, DragEventArgs e)
        {
            string draggedClassText = (string)e.Data.GetData(DataFormats.Text);
            character1.Text = draggedClassText;

            Character character = Characters.Find(c => c.Name == draggedClassText);
            character1Picture.Image = (Image)Properties.Resources.ResourceManager.GetObject(character.CharacterType.ToString().ToLower() + "Picture");
            character1Name.Text = "Name: ";
            character1TextBox.Text = character.Name;
            character1Level.Text = "Level: " + character.Level;
            character1Exp.Text = "EXP Points: " + character.ExperiencePoints;
            character1Strength.Text = "Strength: " + character.Strength;
            character1Dexterity.Text = "Dexterity: " + character.Dexterity;
            character1Intelligence.Text = "Intelligence: " + character.Intelligence;
            character1Hp.Text = "HP: " + character.CurrentHP + "/" + character.MaxHP;
            character1Resistance.Text = "Resistance: " + character.Resistance;
            character1Crit.Text = "Crit Chance: " + character.CritChance + "%";
            character1Initiative.Text = "Initiative: " + character.Initiative;
            character1Dmg.Text = "Attack Damage: " + character.MinDmg + "-" + character.MaxDmg;
            if (character.CharacterType == CharacterType.Knight)
            {
                Knight knight = (Knight)character;
                character1Block.Text = "Block chance: " + knight.BlockChance;
            }
            else if (character.CharacterType == CharacterType.Rogue)
            {
                Rogue rogue = (Rogue)character;
                character1Block.Text = "Dodge Chance: " + rogue.DodgeChance;
            }
            else if (character.CharacterType == CharacterType.Cleric)
            {
                Cleric cleric = (Cleric)character;
                character1Block.Text = "Blessing Chance: " + cleric.BlessingChance;
            }
            else if (character.CharacterType == CharacterType.Joker)
            {
                Joker joker = (Joker)character;
                character1Block.Text = "DoubleAttack chance: " + joker.DoubleAtackChance;
            }
            else
            {
                character1Block.Text = " ";
            }


            character1Skill1.Text = character.Skill1.Name;
            character1Skill1.MouseHover += ItemMouseHover;
            character1Skill1.AccessibleDescription = character.Skill1?.Description;
            character1Skill2.Text = character.Skill2.Name;
            character1Skill2.MouseHover += ItemMouseHover;
            character1Skill2.AccessibleDescription = character.Skill2?.Description;

            checkTeam();


        }
        private void Character2_DragEnter(object sender, DragEventArgs e)
        {
            //knightWeapon.BackColor = Color.LightGray;
            e.Effect = DragDropEffects.Move;
        }

        private void Character2_DragLeave(object sender, EventArgs e)
        {
            //knightWeapon.BackColor = SystemColors.Control;
        }
        private void Character2_DragDrop(object sender, DragEventArgs e)
        {
            string draggedClassText = (string)e.Data.GetData(DataFormats.Text);
            character2.Text = draggedClassText;

            Character character = Characters.Find(c => c.Name == draggedClassText);
            character2Picture.Image = (Image)Properties.Resources.ResourceManager.GetObject(character.CharacterType.ToString().ToLower() + "Picture");
            character2Name.Text = "Name: ";
            character2TextBox.Text = character.Name;
            character2Level.Text = "Level: " + character.Level;
            character2Exp.Text = "EXP Points: " + character.ExperiencePoints;
            character2Strength.Text = "Strength: " + character.Strength;
            character2Dexterity.Text = "Dexterity: " + character.Dexterity;
            character2Intelligence.Text = "Intelligence: " + character.Intelligence;
            character2Hp.Text = "HP: " + character.CurrentHP + "/" + character.MaxHP;
            character2Resistance.Text = "Resistance: " + character.Resistance;
            character2Crit.Text = "Crit Chance: " + character.CritChance + "%";
            character2Initiative.Text = "Initiative: " + character.Initiative;
            character2Dmg.Text = "Attack Damage: " + character.MinDmg + "-" + character.MaxDmg;
            if (character.CharacterType == CharacterType.Knight)
            {
                Knight knight = (Knight)character;
                character2Block.Text = "Block chance: " + knight.BlockChance;
            }
            else if (character.CharacterType == CharacterType.Rogue)
            {
                Rogue rogue = (Rogue)character;
                character2Block.Text = "Dodge Chance: " + rogue.DodgeChance;
            }
            else if (character.CharacterType == CharacterType.Cleric)
            {
                Cleric cleric = (Cleric)character;
                character2Block.Text = "Blessing Chance: " + cleric.BlessingChance;
            }
            else if (character.CharacterType == CharacterType.Joker)
            {
                Joker joker = (Joker)character;
                character2Block.Text = "DoubleAttack chance: " + joker.DoubleAtackChance;
            }
            else
            {
                character2Block.Text = " ";
            }

            character2Skill1.Text = character.Skill1.Name;
            character2Skill1.MouseHover += ItemMouseHover;
            character2Skill1.AccessibleDescription = character.Skill1?.Description;
            character2Skill2.Text = character.Skill2.Name;
            character2Skill2.MouseHover += ItemMouseHover;
            character2Skill2.AccessibleDescription = character.Skill2?.Description;

            checkTeam();

        }
        private void Character3_DragEnter(object sender, DragEventArgs e)
        {
            //knightWeapon.BackColor = Color.LightGray;
            e.Effect = DragDropEffects.Move;
        }

        private void Character3_DragLeave(object sender, EventArgs e)
        {
            //knightWeapon.BackColor = SystemColors.Control;
        }
        private void Character3_DragDrop(object sender, DragEventArgs e)
        {
            string draggedClassText = (string)e.Data.GetData(DataFormats.Text);
            character3.Text = draggedClassText;

            Character character = Characters.Find(c => c.Name == draggedClassText);
            character3Picture.Image = (Image)Properties.Resources.ResourceManager.GetObject(character.CharacterType.ToString().ToLower() + "Picture");
            character3Name.Text = "Name: ";
            character3TextBox.Text = character.Name;
            character3Level.Text = "Level: " + character.Level;
            character3Exp.Text = "EXP Points: " + character.ExperiencePoints;
            character3Strength.Text = "Strength: " + character.Strength;
            character3Dexterity.Text = "Dexterity: " + character.Dexterity;
            character3Intelligence.Text = "Intelligence: " + character.Intelligence;
            character3Hp.Text = "HP: " + character.CurrentHP + "/" + character.MaxHP;
            character3Resistance.Text = "Resistance: " + character.Resistance;
            character3Crit.Text = "Crit Chance: " + character.CritChance + "%";
            character3Initiative.Text = "Initiative: " + character.Initiative;
            character3Dmg.Text = "Attack Damage: " + character.MinDmg + "-" + character.MaxDmg;
            if (character.CharacterType == CharacterType.Knight)
            {
                Knight knight = (Knight)character;
                character3Block.Text = "Block chance: " + knight.BlockChance;
            }
            else if (character.CharacterType == CharacterType.Rogue)
            {
                Rogue rogue = (Rogue)character;
                character3Block.Text = "Dodge Chance: " + rogue.DodgeChance;
            }
            else if (character.CharacterType == CharacterType.Cleric)
            {
                Cleric cleric = (Cleric)character;
                character3Block.Text = "Blessing Chance: " + cleric.BlessingChance;
            }
            else if (character.CharacterType == CharacterType.Joker)
            {
                Joker joker = (Joker)character;
                character3Block.Text = "DoubleAttack chance: " + joker.DoubleAtackChance;
            }
            else
            {
                character3Block.Text = " ";
            }

            character3Skill1.Text = character.Skill1.Name;
            character3Skill1.MouseHover += ItemMouseHover;
            character3Skill1.AccessibleDescription = character.Skill1?.Description;
            character3Skill2.Text = character.Skill2.Name;
            character3Skill2.MouseHover += ItemMouseHover;
            character3Skill2.AccessibleDescription = character.Skill2?.Description;

            checkTeam();

        }
        private void Character4_DragEnter(object sender, DragEventArgs e)
        {
            //knightWeapon.BackColor = Color.LightGray;
            e.Effect = DragDropEffects.Move;
        }

        private void Character4_DragLeave(object sender, EventArgs e)
        {
            //knightWeapon.BackColor = SystemColors.Control;
        }
        private void Character4_DragDrop(object sender, DragEventArgs e)
        {
            string draggedClassText = (string)e.Data.GetData(DataFormats.Text);
            character4.Text = draggedClassText;

            Character character = Characters.Find(c => c.Name == draggedClassText);
            character4Picture.Image = (Image)Properties.Resources.ResourceManager.GetObject(character.CharacterType.ToString().ToLower() + "Picture");
            character4Name.Text = "Name: ";
            character4TextBox.Text = character.Name;
            character4Level.Text = "Level: " + character.Level;
            character4Exp.Text = "EXP Points: " + character.ExperiencePoints;
            character4Strength.Text = "Strength: " + character.Strength;
            character4Dexterity.Text = "Dexterity: " + character.Dexterity;
            character4Intelligence.Text = "Intelligence: " + character.Intelligence;
            character4Hp.Text = "HP: " + character.CurrentHP + "/" + character.MaxHP;
            character4Resistance.Text = "Resistance: " + character.Resistance;
            character4Crit.Text = "Crit Chance: " + character.CritChance + "%";
            character4Initiative.Text = "Initiative: " + character.Initiative;
            character4Dmg.Text = "Attack Damage: " + character.MinDmg + "-" + character.MaxDmg;
            if (character.CharacterType == CharacterType.Knight)
            {
                Knight knight = (Knight)character;
                character4Block.Text = "Block chance: " + knight.BlockChance;
            }
            else if (character.CharacterType == CharacterType.Rogue)
            {
                Rogue rogue = (Rogue)character;
                character4Block.Text = "Dodge Chance: " + rogue.DodgeChance;
            }
            else if (character.CharacterType == CharacterType.Cleric)
            {
                Cleric cleric = (Cleric)character;
                character4Block.Text = "Blessing Chance: " + cleric.BlessingChance;
            }
            else if (character.CharacterType == CharacterType.Joker)
            {
                Joker joker = (Joker)character;
                character4Block.Text = "DoubleAttack chance: " + joker.DoubleAtackChance;
            }
            else
            {
                character4Block.Text = " ";
            }

            character4Skill1.Text = character.Skill1.Name;
            character4Skill1.MouseHover += ItemMouseHover;
            character4Skill1.AccessibleDescription = character.Skill1?.Description;
            character4Skill2.Text = character.Skill2.Name;
            character4Skill2.MouseHover += ItemMouseHover;
            character4Skill2.AccessibleDescription = character.Skill2?.Description;

            checkTeam();

        }


        private void checkTeam()
        {
            if ((character1.Text != "Character 1" && character2.Text != "Character 2" && character3.Text != "Character 3" && character4.Text != "Character 4"))
            {
                saveTeamButton.Enabled = true;
                rozpocznijButton.Enabled = false;
            }
        }

        private void saveTeamButton_Click(object sender, EventArgs e)
        {
            HashSet<string> uniqueTexts = new HashSet<string>();


            uniqueTexts.Add(character1TextBox.Text);
            uniqueTexts.Add(character2TextBox.Text);
            uniqueTexts.Add(character3TextBox.Text);
            uniqueTexts.Add(character4TextBox.Text);


            if (uniqueTexts.Count == 4)
            {
                ChooseCharacters.Clear();
                StarterInventory.Clear();
                checkClass(character1.Text, character1TextBox.Text, 1);
                checkClass(character2.Text, character2TextBox.Text, 2);
                checkClass(character3.Text, character3TextBox.Text, 3);
                checkClass(character4.Text, character4TextBox.Text, 4);
                rozpocznijButton.Enabled = true;
            }
            else
            {
                MessageBox.Show("Character names must be unique", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }




        }

        private void checkClass(string name, string firstname, int id)
        {
            Character character = Characters.Find(c => c.Name == name);
            if (character.CharacterType == CharacterType.Knight)
            {
                Knight knight = new Knight(id, firstname, 0, 10, 5, 2, 50, 50, 50, 50, 10, 34, 1, 2, 33, CharacterType.Knight);
                ChooseCharacters.Add(knight);
                StarterInventory.Add(new Weapon((Weapon)CommonInventory[0]));
                StarterInventory.Add(new Armor((Armor)CommonInventory[1]));

            }
            else if (character.CharacterType == CharacterType.Rogue)
            {
                Rogue rogue = new Rogue(id, firstname, 0, 2, 10, 5, 35, 35, 30, 30, 50, 70, 1, 2, 33, CharacterType.Rogue);
                ChooseCharacters.Add(rogue);
                StarterInventory.Add(new Weapon((Weapon)CommonInventory[2]));
                StarterInventory.Add(new Armor((Armor)CommonInventory[3]));
            }
            else if (character.CharacterType == CharacterType.Cleric)
            {
                Cleric cleric = new Cleric(id, firstname, 0, 2, 5, 10, 45, 45, 40, 40, 30, 30, 1, 2, 15, CharacterType.Cleric);
                ChooseCharacters.Add(cleric);
                StarterInventory.Add(new Weapon((Weapon)CommonInventory[4]));
                StarterInventory.Add(new Armor((Armor)CommonInventory[5]));
            }
            else if (character.CharacterType == CharacterType.Joker)
            {
                Joker joker = new Joker(id, firstname, 0, 2, 7, 8, 30, 30, 30, 30, 50, 50, 1, 2, 20, CharacterType.Joker);
                ChooseCharacters.Add(joker);
                StarterInventory.Add(new Weapon((Weapon)CommonInventory[6]));
                StarterInventory.Add(new Armor((Armor)CommonInventory[7]));
            }
        }

        public event EventHandler startButtonClicked;
        private void startButton_Click(object sender, EventArgs e)
        {
            startButtonClicked?.Invoke(this, EventArgs.Empty);
        }
    }
}
