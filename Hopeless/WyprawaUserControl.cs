using HopelessLibary;
using HopelessLibary.Intefrace;
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


        private List <ICreature> fightOrder = new();
        private ICreature target;
        public delegate void CustomDelegate(bool wynik, Expedition wyprawa);
        public event CustomDelegate eventFirst;

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
        private async Task Fight()
        {
            int value;
            bool fightStatus = true;
            bool playerActionTaken;
            while (fightStatus)
            {
               foreach (var postac in fightOrder)
                {
                    playerActionTaken = false;
                    if (postac is Knight)
                    {
                        Knight knight = (Knight)postac;
                        playerActionTaken = true;
                        while (!playerActionTaken)
                        {

                        }

                    }
                    else if (postac is Rogue)
                    {
                        Rogue rogue = (Rogue)postac;
                        playerActionTaken = true;
                        while (!playerActionTaken)
                        {

                        }

                    }
                    else if (postac is Cleric)
                    {
                        Cleric cleric = (Cleric)postac;
                        skill1Label.Text = "Heal";
                        skill2Label.Text = "Purify";

                        EventHandler handlerHeal = (s, e) => { cleric.Heal(); };
                        EventHandler handlerPurify = (s, e) => {
                            if (target != null)
                            {
                                target.TakeDamage(cleric.Purify());
                                playerActionTaken = true;

                            }
                        };

                        skill1Label.Click += handlerHeal;
                        skill2Label.Click += handlerPurify;


                        while (!playerActionTaken)
                            await Task.Delay(200);

                        skill1Label.Click -= handlerHeal;
                        skill2Label.Click -= handlerPurify;
                    }
                    else if (postac is Joker)
                    {
                        Joker joker = (Joker)postac;
                        playerActionTaken = true;
                        while (!playerActionTaken)
                        {

                        }
                    }
                    else
                    {

                        Monster monster = (Monster)postac;
   
                    }
                
                   
                }


            };
        }

        private void InitializeAfterFight()
        {

        }
        private void InitializeBeforeFight()
        {
            fightOrder.Clear();

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
                enemy1Name.Click += Enemy_Click;

                enemy2Name.Text = expedition.Monsters[1].Name;
                enemy2HealthText.Text = expedition.Monsters[1].CurrentHP + "/" + expedition.Monsters[1].MaxHP;
                enemy2Health.Maximum = expedition.Monsters[1].MaxHP;
                enemy2Health.Value = expedition.Monsters[1].CurrentHP;
                enemy2Name.Click += Enemy_Click;

                enemy3Name.Text = expedition.Monsters[2].Name;
                enemy3HealthText.Text = expedition.Monsters[2].CurrentHP + "/" + expedition.Monsters[2].MaxHP;
                enemy3Health.Maximum = expedition.Monsters[2].MaxHP;
                enemy3Health.Value = expedition.Monsters[2].CurrentHP;
                enemy3Name.Click += Enemy_Click;

                enemy4Name.Text = expedition.Monsters[3].Name;
                enemy4HealthText.Text = expedition.Monsters[3].CurrentHP + "/" + expedition.Monsters[3].MaxHP;
                enemy4Health.Maximum = expedition.Monsters[3].MaxHP;
                enemy4Health.Value = expedition.Monsters[3].CurrentHP;
                enemy4Name.Click += Enemy_Click;


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

            fightOrder.AddRange(expedition.Monsters);
            fightOrder.AddRange(characters);
            fightOrder = fightOrder.OrderByDescending(x=>x.Initiative).ToList();

        }

        private void Enemy_Click(object? sender, EventArgs e)
        {
            var label = sender as Label;
            if (label != null)
            {
               if(label.Name.Equals("enemy1Name"))
                {
                    target = expedition.Monsters[0];
                }
            }
           
        }

        public event EventHandler FinishButtonClicked;
        private void loseButton_Click(object sender, EventArgs e)
        {
            eventFirst?.Invoke(false, expedition);
            FinishButtonClicked?.Invoke(this, EventArgs.Empty);
        }
        private void winButton_Click(object sender, EventArgs e)
        {
            Fight();
            //eventFirst?.Invoke(true, expedition);
            //FinishButtonClicked?.Invoke(this, EventArgs.Empty);
        }

   
    }
}