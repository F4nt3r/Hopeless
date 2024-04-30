using HopelessLibary;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Text;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Hopeless
{
    public partial class WyprawaUserControl : UserControl
    {
        public List<Character> characters { get; set; }
        public Expedition expedition { get; set; }

        private List<Monster> monsters = new List<Monster>();
        Dictionary<int, string> orderDictionary = new Dictionary<int, string>();

        public delegate void CustomDelegate(bool wynik, Expedition wyprawa);
        public event CustomDelegate eventFirst;
        private Skill skill { get; set; }

        public WyprawaUserControl()
        {
            InitializeComponent();
            pictureBox1.Image = Properties.Resources.Wyprawa;
            this.VisibleChanged += WyprawaUserControl_VisibleChanged;
           
        }

        private void WyprawaUserControl_VisibleChanged(object? sender, EventArgs e)
        {
            var control = sender as UserControl;
            if (control != null)
            {
                if (control.Visible)
                {
                    InitializeBeforeFight();
                   
                }

            }
        }
        private void Fight()
        {
            int value;
            bool fightStatus = true;
            bool playerActionTaken;
            while (fightStatus)
            {
                foreach (KeyValuePair<int, string> postac in orderDictionary)
                {
                    if (postac.Value.Equals(characters[0].Name))
                    {
                        Knight knight = (Knight)characters[0];


                    }
                    else if (postac.Value.Equals(characters[1].Name))
                    {
                        Rogue rogue = (Rogue)characters[1];

                    }
                    else if (postac.Value.Equals(characters[2].Name))
                    {
                        Cleric cleric = (Cleric)characters[2];
                        skill1Label.Text = "Heal";

                        skill2Label.Text = "Purify";
                        playerActionTaken = false;
                        while (!playerActionTaken)
                        {
                            
                        }


                    }
                    else if (postac.Value.Equals(characters[3].Name))
                    {
                        Joker joker = (Joker)characters[3];
                    }
                    else
                    {

                        Monster monster = monsters.Find(monster => monster.Name == postac.Value);
                    }

                }


            };
        }

        private void InitializeAfterFight()
        {

        }
        private void InitializeBeforeFight()
        {
            monsters.AddRange(expedition.Monsters);
            basicAttackLabel.Text = "Atak Bazowy";

            knightName.Text = characters[0].Name;
            knightHealthText.Text = characters[0].CurrentHP + "/" + characters[0].MaxHP;
            knightHealth.Value = characters[0].CurrentHP;
            knightHealth.Maximum = characters[0].MaxHP;

            rogueName.Text = characters[1].Name;
            rogueHealthText.Text = characters[1].CurrentHP + "/" + characters[1].MaxHP;
            rogueHealth.Value = characters[1].CurrentHP;
            rogueHealth.Maximum = characters[1].MaxHP;

            clericName.Text = characters[2].Name;
            clericHealthText.Text = characters[2].CurrentHP + "/" + characters[2].MaxHP;
            clericHealth.Value = characters[2].CurrentHP;
            clericHealth.Maximum = characters[2].MaxHP;

            jokerName.Text = characters[3].Name;
            jokerHealthText.Text = characters[3].CurrentHP + "/" + characters[3].MaxHP;
            jokerHealth.Value = characters[3].CurrentHP;
            jokerHealth.Maximum = characters[3].MaxHP;


            if (expedition.Monsters.Count > 1)
            {
                enemy1Name.Text = expedition.Monsters[0].Name;
                enemy1HealthText.Text = expedition.Monsters[0].CurrentHP + "/" + expedition.Monsters[0].MaxHP;
                enemy1Health.Maximum = expedition.Monsters[0].MaxHP;
                enemy1Health.Value = expedition.Monsters[0].CurrentHP;


                enemy2Name.Text = expedition.Monsters[1].Name;
                enemy2HealthText.Text = expedition.Monsters[1].CurrentHP + "/" + expedition.Monsters[1].MaxHP;
                enemy2Health.Maximum = expedition.Monsters[1].MaxHP;
                enemy2Health.Value = expedition.Monsters[1].CurrentHP;


                enemy3Name.Text = expedition.Monsters[2].Name;
                enemy3HealthText.Text = expedition.Monsters[2].CurrentHP + "/" + expedition.Monsters[2].MaxHP;
                enemy3Health.Maximum = expedition.Monsters[2].MaxHP;
                enemy3Health.Value = expedition.Monsters[2].CurrentHP;


                enemy4Name.Text = expedition.Monsters[3].Name;
                enemy4HealthText.Text = expedition.Monsters[3].CurrentHP + "/" + expedition.Monsters[3].MaxHP;
                enemy4Health.Maximum = expedition.Monsters[3].MaxHP;
                enemy4Health.Value = expedition.Monsters[3].CurrentHP;



            }
            else
            {
                enemy1Name.Visible = false;
                enemy1Health.Visible = false;
                enemy1HealthText.Visible = false;

                enemy2Name.Text = expedition.Monsters[0].Name;
                enemy2HealthText.Text = expedition.Monsters[0].CurrentHP + "/" + expedition.Monsters[0].MaxHP;
                enemy2Health.Maximum = expedition.Monsters[0].MaxHP;
                enemy2Health.Value = expedition.Monsters[0].CurrentHP;

                enemy3Name.Visible = false;
                enemy3Health.Visible = false;
                enemy3HealthText.Visible = false;

                enemy4Name.Visible = false;
                enemy4Health.Visible = false;
                enemy4HealthText.Visible = false;
            }

            //Kolejnosc Tur

            List<int> initiatives = new List<int>();
            foreach (Monster monster in monsters)
            {
                initiatives.Add(monster.Initiative);
            }
            foreach (Character character in characters)
            {
                initiatives.Add(character.Initiative);
            }
            initiatives.Add(-1);
            initiatives.Sort();
            initiatives.Reverse();
            int all = characters.Count + monsters.Count;
            int position = 0;
            do
            {

                foreach (Character character in characters)
                {
                    if (initiatives[position] == character.Initiative)
                    {
                        orderDictionary.Add(position, character.Name);
                        position++;
                    }

                }
                foreach (Monster monster in monsters)
                {
                    if (initiatives[position] == monster.Initiative)
                    {
                        orderDictionary.Add(position, monster.Name);
                        position++;
                    }

                }

            } while (orderDictionary.Count != all);
        }

        public event EventHandler FinishButtonClicked;
        private void loseButton_Click(object sender, EventArgs e)
        {
            eventFirst?.Invoke(false, expedition);
            FinishButtonClicked?.Invoke(this, EventArgs.Empty);
        }
        private void winButton_Click(object sender, EventArgs e)
        {

            eventFirst?.Invoke(true, expedition);
            FinishButtonClicked?.Invoke(this, EventArgs.Empty);
        }

   
    }
}