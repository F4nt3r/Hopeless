using HopelessLibary;
using HopelessLibary.Intefrace;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
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


        private List<ICreature> fightOrder = new();
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
            Dictionary<string, int> cooldowns = new();
            while (fightStatus)
            {
                foreach (var postac in fightOrder)
                {
                    playerActionTaken = false;
                    if (postac is Knight)
                    {
                        Knight knight = (Knight)postac;
                        if (cooldowns.ContainsKey("Slash"))
                        {
                            cooldowns.TryGetValue("Slash", out int tury);
                            skill1Label.Text = "Slash" + Environment.NewLine +"Odnawianie: "+ tury + " tur";
                        }
                        else
                        {
                            skill1Label.Text = "Slash";
                        }
                        if (cooldowns.ContainsKey("Purify"))
                        {
                            cooldowns.TryGetValue("Purify", out int tury);
                            skill2Label.Text = "Purify" + Environment.NewLine + "Odnawianie: " + tury + " tur";
                        }
                        else
                        {
                            skill2Label.Text = "Purify";
                        }
                        EventHandler handlerBassicAttack = (s, e) => {
                            if (target != null)
                            {
                                target.TakeDamage(knight.BasicAttack());
                                playerActionTaken = true;

                            }

                        };

                        EventHandler handlerSlash = (s, e) => {
                            if (target != null)
                            {
                                if (cooldowns.ContainsKey("Slash"))
                                {

                                    cooldowns.TryGetValue("Slash", out int tury);
                                    MessageBox.Show("Nie mozesz tego uzyc, poczekaj: " + tury + " tur", "Cooldown Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                }
                                else
                                {
                                    knight.Slash((Monster)target);
                                    cooldowns.Add("Slash", 3);
                                    playerActionTaken = true;
                                }
                               
                                

                            }
                            
                        };

                        EventHandler handlerPurify = (s, e) =>
                        {
                            if (target != null)
                            {
                                if (cooldowns.ContainsKey("Purify"))
                                {

                                    cooldowns.TryGetValue("Purify", out int tury);
                                    MessageBox.Show("Nie mozesz tego uzyc, poczekaj: " + tury + " tur", "Cooldown Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                }
                                else { 
                                    knight.Purify((Monster)target);
                                cooldowns.Add("Purify", 3);
                                playerActionTaken = true;
                                }
                            }
                        };

                        skill1Label.Click += handlerSlash;
                        skill2Label.Click += handlerPurify;
                        basicAttackLabel.Click += handlerBassicAttack;

                        while (!playerActionTaken)
                        {
                            await Task.Delay(200);
                            
                            if (target is Character) { 
                                skill1Label.Enabled = false;
                                skill2Label.Enabled = false;
                            }
                            else { 
                                skill1Label.Enabled = true;
                                skill2Label.Enabled = true;
                        }
                    }

                        skill1Label.Click -= handlerSlash;
                        skill2Label.Click -= handlerPurify;
                        basicAttackLabel.Click -= handlerPurify;
                        skill1Label.Enabled = true;
                        skill2Label.Enabled = true;

                    }
                    else if (postac is Rogue)
                    {
                        Rogue rogue = (Rogue)postac;
                        if (cooldowns.ContainsKey("Ambush"))
                        {
                            cooldowns.TryGetValue("Ambush", out int tury);
                            skill1Label.Text = "Ambush" + Environment.NewLine + "Odnawianie: " + tury + " tur";
                        }
                        else
                        {
                            skill1Label.Text = "Ambush";
                        }
                        if (cooldowns.ContainsKey("CritAndDodgeBuff"))
                        {
                            cooldowns.TryGetValue("CritAndDodgeBuff", out int tury);
                            skill2Label.Text = "CritAndDodgeBuff" + Environment.NewLine + "Odnawianie: " + tury + " tur";
                        }
                        else
                        {
                            skill2Label.Text = "CritAndDodgeBuff";
                        }
                        EventHandler handlerBassicAttack = (s, e) => {
                            if (target != null)
                            {
                                target.TakeDamage(rogue.BasicAttack());
                                playerActionTaken = true;

                            }

                        };


                        EventHandler handlerAmbush = (s, e) => {
                            if (target != null)
                            {
                                if (cooldowns.ContainsKey("Ambush"))
                                {

                                    cooldowns.TryGetValue("Ambush", out int tury);
                                    MessageBox.Show("Nie mozesz tego uzyc, poczekaj: " + tury + " tur", "Cooldown Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                }
                                else
                                {
                                    rogue.Ambush((Monster)target);
                                    cooldowns.Add("Ambush", 3);
                                    playerActionTaken = true;
                                }
                            }

                        };

                        EventHandler handlerCritAndDodgeBuff = (s, e) =>
                        {
                            if (cooldowns.ContainsKey("CritAndDodgeBuff"))
                            {

                                cooldowns.TryGetValue("CritAndDodgeBuff", out int tury);
                                MessageBox.Show("Nie mozesz tego uzyc, poczekaj: " + tury + " tur", "Cooldown Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                            else
                            {

                                rogue.CritAndDodgeBuff();
                                cooldowns.Add("CritAndDodgeBuff", 3);
                                playerActionTaken = true;

                            }
                        };

                        skill1Label.Click += handlerAmbush;
                        skill2Label.Click += handlerCritAndDodgeBuff;
                        basicAttackLabel.Click += handlerBassicAttack;

                        while (!playerActionTaken)
                        {
                            await Task.Delay(200);
                            if (target is Character)
                                skill1Label.Enabled = false;
                            else
                                skill1Label.Enabled = true;
                        }
                        skill1Label.Click -= handlerAmbush;
                        skill2Label.Click -= handlerCritAndDodgeBuff;
                        basicAttackLabel.Click -= handlerBassicAttack;
                        skill1Label.Enabled = true;
                        skill2Label.Enabled = true;

                    }
                    else if (postac is Cleric)
                    {
                        Cleric cleric = (Cleric)postac;
                        if (cooldowns.ContainsKey("Heal"))
                        {
                            cooldowns.TryGetValue("Heal", out int tury);
                            skill1Label.Text = "Heal" + Environment.NewLine + "Odnawianie: " + tury + " tur";
                        }
                        else
                        {
                            skill1Label.Text = "Heal";
                        }
                        if (cooldowns.ContainsKey("AoeHeal"))
                        {
                            cooldowns.TryGetValue("AoeHeal", out int tury);
                            skill2Label.Text = "AoeHeal" + Environment.NewLine + "Odnawianie: " + tury + " tur";
                        }
                        else
                        {
                            skill2Label.Text = "AoeHeal";
                        }
                        EventHandler handlerBassicAttack = (s, e) => {
                            if (target != null)
                            {
                                target.TakeDamage(cleric.BasicAttack());
                                playerActionTaken = true;

                            }

                        };
                        EventHandler handlerHeal = (s, e) => {
                            if (cooldowns.ContainsKey("Heal"))
                            {

                                cooldowns.TryGetValue("Heal", out int tury);
                                MessageBox.Show("Nie mozesz tego uzyc, poczekaj: " + tury + " tur", "Cooldown Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                            else
                            {
                                cleric.Heal((Character)target);
                                cooldowns.Add("Heal", 3);
                                playerActionTaken = true;
                            }
                        };

                        EventHandler handlerAoeHeal = (s, e) =>
                        {
                            if (cooldowns.ContainsKey("AoeHeal"))
                            {

                                cooldowns.TryGetValue("AoeHeal", out int tury);
                                MessageBox.Show("Nie mozesz tego uzyc, poczekaj: " + tury + " tur", "Cooldown Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                            else
                            {
                                cleric.AoeHeal(characters);
                                cooldowns.Add("AoeHeal", 3);
                                playerActionTaken = true;
                            }
                            
                        };

                        skill1Label.Click += handlerHeal;
                        skill2Label.Click += handlerAoeHeal;
                        basicAttackLabel.Click += handlerBassicAttack;

                        while (!playerActionTaken)
                        {
                            await Task.Delay(200);
                            if(target is Character) 
                                skill1Label.Enabled = true;
                            else
                                skill1Label.Enabled = false;
                        }
                            

                        skill1Label.Click -= handlerHeal;
                        skill2Label.Click -= handlerAoeHeal;
                        basicAttackLabel.Click -= handlerBassicAttack;
                        skill1Label.Enabled = true;
                        skill2Label.Enabled = true;
                    }
                    else if (postac is Joker)
                    {
                        Joker joker = (Joker)postac;
                        if (cooldowns.ContainsKey("AoeBuff"))
                        {
                            cooldowns.TryGetValue("AoeBuff", out int tury);
                            skill1Label.Text = "AoeBuff" + Environment.NewLine + "Odnawianie: " + tury + " tur";
                        }
                        else
                        {
                            skill1Label.Text = "AoeBuff";
                        }
                        if (cooldowns.ContainsKey("AoeDeBuff"))
                        {
                            cooldowns.TryGetValue("AoeDeBuff", out int tury);
                            skill2Label.Text = "AoeDeBuff" + Environment.NewLine + "Odnawianie: " + tury + " tur";
                        }
                        else
                        {
                            skill2Label.Text = "AoeDeBuff";
                        }
                        EventHandler handlerBassicAttack = (s, e) => {
                            if (target != null)
                            {

                                target.TakeDamage(joker.BasicAttack());
                                playerActionTaken = true;

                            }

                        };
                        EventHandler handlerAoeBuff = (s, e) => {
                            if (cooldowns.ContainsKey("AoeBuff"))
                            {

                                cooldowns.TryGetValue("AoeBuff", out int tury);
                                MessageBox.Show("Nie mozesz tego uzyc, poczekaj: " + tury + " tur", "Cooldown Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                            else
                            {
                                joker.AoeBuff(characters);
                                cooldowns.Add("AoeBuff", 3);
                                playerActionTaken = true;
                            }
                        };

                        EventHandler handlerAoeDeBuff = (s, e) =>
                        {
                            if (cooldowns.ContainsKey("AoeDeBuff"))
                            {

                                cooldowns.TryGetValue("AoeDeBuff", out int tury);
                                MessageBox.Show("Nie mozesz tego uzyc, poczekaj: " + tury + " tur", "Cooldown Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                            else
                            {
                                joker.AoeDeBuff(expedition.Monsters);
                                cooldowns.Add("AoeDeBuff", 3);
                                playerActionTaken = true;

                            }
                        };

                        skill1Label.Click += handlerAoeBuff;
                        skill2Label.Click += handlerAoeDeBuff;
                        basicAttackLabel.Click += handlerBassicAttack;

                        while (!playerActionTaken)
                            await Task.Delay(200);

                        skill1Label.Click -= handlerAoeBuff;
                        skill2Label.Click -= handlerAoeDeBuff;
                        basicAttackLabel.Click -= handlerBassicAttack;
                        skill1Label.Enabled = true;
                        skill2Label.Enabled = true;
                    }
                    else
                    {

                        Monster monster = (Monster)postac;

                    }

                  
                }
                foreach (var key in cooldowns.Keys.ToList())
                {
                    cooldowns[key]--;

                    // Jeśli wartość spadła do zera, usuń klucz ze słownika
                    if (cooldowns[key] == 0)
                    {
                        cooldowns.Remove(key);
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
            knightName.Click += Enemy_Click;

            rogueName.Text = characters[1].Name;
            rogueHealthText.Text = characters[1].CurrentHP + "/" + characters[1].MaxHP;
            rogueHealth.Value = characters[1].CurrentHP;
            rogueHealth.Maximum = characters[1].MaxHP;
            rogueName.Click += Enemy_Click;

            clericName.Text = characters[2].Name;
            clericHealthText.Text = characters[2].CurrentHP + "/" + characters[2].MaxHP;
            clericHealth.Value = characters[2].CurrentHP;
            clericHealth.Maximum = characters[2].MaxHP;
            clericName.Click += Enemy_Click;

            jokerName.Text = characters[3].Name;
            jokerHealthText.Text = characters[3].CurrentHP + "/" + characters[3].MaxHP;
            jokerHealth.Value = characters[3].CurrentHP;
            jokerHealth.Maximum = characters[3].MaxHP;
            jokerName.Click += Enemy_Click;

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
                fightOrder = fightOrder.OrderByDescending(x => x.Initiative).ToList();

            }

            private void Enemy_Click(object? sender, EventArgs e)
            {
                enemy1Name.BackColor = Color.White;
                enemy2Name.BackColor = Color.White;
                enemy3Name.BackColor = Color.White;
                enemy4Name.BackColor = Color.White;

                knightName.BackColor = Color.White;
                rogueName.BackColor = Color.White;
                clericName.BackColor = Color.White;
                jokerName.BackColor = Color.White;
                var label = sender as Label;
                if (label != null)
                {
                    if (label.Name.Equals("enemy1Name"))
                    {
                        target = expedition.Monsters[0];
                        label.BackColor = Color.Yellow;
                    }
                    else if (label.Name.Equals("enemy2Name"))
                    {
                        target = expedition.Monsters[1];
                        label.BackColor = Color.Yellow;
                    }
                    else if (label.Name.Equals("enemy3Name"))
                    {
                        target = expedition.Monsters[2];
                        label.BackColor = Color.Yellow;
                    }
                    else if (label.Name.Equals("enemy4Name"))
                    {
                        target = expedition.Monsters[3];
                        label.BackColor = Color.Yellow;
                    }
                    else if (label.Name.Equals("knightName"))
                    {
                        target = characters[0];
                        label.BackColor = Color.Yellow;
                    }
                    else if (label.Name.Equals("rogueName"))
                    {
                        target = characters[1];
                        label.BackColor = Color.Yellow;
                    }
                    else if (label.Name.Equals("clericName"))
                    {
                        target = characters[2];
                        label.BackColor = Color.Yellow;
                    }
                    else if (label.Name.Equals("jokerName"))
                    {
                        target = characters[3];
                        label.BackColor = Color.Yellow;
                    }
                    else
                    {
                        target = null;
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