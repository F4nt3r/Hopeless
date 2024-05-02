﻿using HopelessLibary;
using HopelessLibary.Intefrace;
using System.Data;

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
        public event EventHandler FinishButtonClicked;
        private Dictionary<string, int> cooldowns = new();
        private Dictionary<string, int> effects = new();
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
                    if (postac is Knight && !postac.IsDead())
                    {
                        Knight knight = (Knight)postac;
                        if (cooldowns.ContainsKey("Provoke"))
                        {
                            cooldowns.TryGetValue("Provoke", out int tury);
                            skill1Label.Text = "Provoke" + Environment.NewLine + "Odnawianie: " + tury + " tur";
                        }
                        else
                        {
                            skill1Label.Text = "Provoke";
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
                        EventHandler handlerBassicAttack = (s, e) =>
                        {
                            if (target != null)
                            {
                                knight.BasicAttack(target);

                                playerActionTaken = true;

                            }

                        };

                        EventHandler handlerProvoke = (s, e) =>
                        {

                            if (cooldowns.ContainsKey("Provoke"))
                            {

                                cooldowns.TryGetValue("Provoke", out int tury);
                                MessageBox.Show("Nie mozesz tego uzyc, poczekaj: " + tury + " tur", "Cooldown Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                            else
                            {
                                knight.Provoke(true);
                                cooldowns.Add("Provoke", 4);
                                effects.Add("Provoke", 2);
                                playerActionTaken = true;
                            }





                        };

                        EventHandler handlerPurify = (s, e) =>
                        {

                            if (cooldowns.ContainsKey("Purify"))
                            {

                                cooldowns.TryGetValue("Purify", out int tury);
                                MessageBox.Show("Nie mozesz tego uzyc, poczekaj: " + tury + " tur", "Cooldown Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                            else
                            {
                                knight.Purify(expedition.Monsters);
                                cooldowns.Add("Purify", 3);
                                playerActionTaken = true;
                            }

                        };

                        skill1Label.Click += handlerProvoke;
                        skill2Label.Click += handlerPurify;
                        basicAttackLabel.Click += handlerBassicAttack;

                        while (!playerActionTaken)
                        {
                            await Task.Delay(200);
                            if (target is Character)
                                basicAttackLabel.Enabled = false;
                            else
                                basicAttackLabel.Enabled = true;
                        }

                        skill1Label.Click -= handlerProvoke;
                        skill2Label.Click -= handlerPurify;
                        basicAttackLabel.Click -= handlerBassicAttack;
                        skill1Label.Enabled = true;
                        skill2Label.Enabled = true;
                        CheckStatus();

                    }
                    else if (postac is Rogue && !postac.IsDead())
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
                        EventHandler handlerBassicAttack = (s, e) =>
                        {
                            if (target != null)
                            {
                                rogue.BasicAttack(target);

                                playerActionTaken = true;

                            }

                        };


                        EventHandler handlerAmbush = (s, e) =>
                        {
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

                                rogue.CritAndDodgeBuff(true);
                                cooldowns.Add("CritAndDodgeBuff", 3);
                                effects.Add("CritAndDodgeBuff", 2);
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
                            {
                                skill1Label.Enabled = false;
                                basicAttackLabel.Enabled = false;
                            }
                            else
                            {
                                skill1Label.Enabled = true;
                                basicAttackLabel.Enabled = true;
                            }
                        }
                        skill1Label.Click -= handlerAmbush;
                        skill2Label.Click -= handlerCritAndDodgeBuff;
                        basicAttackLabel.Click -= handlerBassicAttack;
                        skill1Label.Enabled = true;
                        skill2Label.Enabled = true;
                        CheckStatus();

                    }
                    else if (postac is Cleric && !postac.IsDead())
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
                        EventHandler handlerBassicAttack = (s, e) =>
                        {
                            if (target != null)
                            {
                                cleric.BasicAttack(target);
                                playerActionTaken = true;

                            }

                        };
                        EventHandler handlerHeal = (s, e) =>
                        {
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
                            if (target is Character)
                            {
                                skill1Label.Enabled = true;
                                basicAttackLabel.Enabled = false;
                            }
                            else
                            {
                                basicAttackLabel.Enabled = true;
                                skill1Label.Enabled = false;
                            }

                        }


                        skill1Label.Click -= handlerHeal;
                        skill2Label.Click -= handlerAoeHeal;
                        basicAttackLabel.Click -= handlerBassicAttack;
                        skill1Label.Enabled = true;
                        skill2Label.Enabled = true;
                        CheckStatus();
                    }
                    else if (postac is Joker && !postac.IsDead())
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
                        EventHandler handlerBassicAttack = (s, e) =>
                        {
                            if (target != null)
                            {

                                joker.BasicAttack(target);
                                playerActionTaken = true;

                            }

                        };
                        EventHandler handlerAoeBuff = (s, e) =>
                        {
                            if (cooldowns.ContainsKey("AoeBuff"))
                            {

                                cooldowns.TryGetValue("AoeBuff", out int tury);
                                MessageBox.Show("Nie mozesz tego uzyc, poczekaj: " + tury + " tur", "Cooldown Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                            else
                            {
                                joker.AoeBuff(characters, true);
                                cooldowns.Add("AoeBuff", 5);
                                effects.Add("AoeBuff", 3);
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
                                joker.AoeDeBuff(expedition.Monsters, true);
                                cooldowns.Add("AoeDeBuff", 5);
                                effects.Add("AoeDeBuff", 3);
                                playerActionTaken = true;

                            }
                        };

                        skill1Label.Click += handlerAoeBuff;
                        skill2Label.Click += handlerAoeDeBuff;
                        basicAttackLabel.Click += handlerBassicAttack;

                        while (!playerActionTaken)
                        {
                            await Task.Delay(200);
                            if (target is Character)
                            {
                                basicAttackLabel.Enabled = false;
                            }
                            else
                            {
                                basicAttackLabel.Enabled = true;

                            }

                        }

                        skill1Label.Click -= handlerAoeBuff;
                        skill2Label.Click -= handlerAoeDeBuff;
                        basicAttackLabel.Click -= handlerBassicAttack;
                        skill1Label.Enabled = true;
                        skill2Label.Enabled = true;
                        CheckStatus();
                    }
                    else
                    {
                        if (!postac.IsDead())
                        {
                            Monster monster = (Monster)postac;
                            if (effects.ContainsKey("Provoke"))
                            {
                                target = characters[0];
                            }
                            else
                            {
                                int i = new Random().Next(0, 4);
                                target = characters[i];
                            }
                           
                            monster.BasicAttack(target);
                            CheckStatus();
                        }

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
                foreach (var key in effects.Keys.ToList())
                {
                    effects[key]--;

                    // Jeśli wartość spadła do zera, usuń klucz ze słownika
                    if (effects[key] == 0)
                    {
                        if (key.Equals("Provoke"))
                        {
                            Knight knight = (Knight)characters[0];
                            knight.Provoke(false);
                        }
                        if (key.Equals("CritAndDodgeBuff"))
                        {
                            Rogue rogue = (Rogue)characters[1];
                            rogue.CritAndDodgeBuff(false);
                        }
                        if (key.Equals("AoeBuff"))
                        {
                            Joker joker = (Joker)characters[3];
                            joker.AoeBuff(characters, false);
                        }
                        if (key.Equals("AoeDeBuff"))
                        {
                            Joker joker = (Joker)characters[3];
                            joker.AoeDeBuff(expedition.Monsters, false);
                        }

                        effects.Remove(key);


                    }
                }

            };
        }
        private void CheckStatus()
        {
            enemy1Health.Value = expedition.Monsters[0].CurrentHP;
            enemy1HealthText.Text = expedition.Monsters[0].CurrentHP + "/" + expedition.Monsters[0].MaxHP;
            if (enemy1Health.Value == 0)
            {
                enemy1Name.Enabled = false;


            }
            enemy2Health.Value = expedition.Monsters[1].CurrentHP;
            enemy2HealthText.Text = expedition.Monsters[1].CurrentHP + "/" + expedition.Monsters[1].MaxHP;
            if (enemy2Health.Value == 0)
            {
                enemy2Name.Enabled = false;

            }
            enemy3Health.Value = expedition.Monsters[2].CurrentHP;
            enemy3HealthText.Text = expedition.Monsters[2].CurrentHP + "/" + expedition.Monsters[2].MaxHP;
            if (enemy3Health.Value == 0)
            {
                enemy3Name.Enabled = false;

            }
            enemy4Health.Value = expedition.Monsters[3].CurrentHP;
            enemy4HealthText.Text = expedition.Monsters[3].CurrentHP + "/" + expedition.Monsters[3].MaxHP;
            if (enemy4Health.Value == 0)
            {
                enemy4Name.Enabled = false;

            }

            knightHealthText.Text = characters[0].CurrentHP + "/" + characters[0].MaxHP;
            knightHealth.Value = characters[0].CurrentHP;
            if (knightHealth.Value == 0)
            {
                knightName.Enabled = false;

            }



            rogueHealthText.Text = characters[1].CurrentHP + "/" + characters[1].MaxHP;
            rogueHealth.Value = characters[1].CurrentHP;
            if (rogueHealth.Value == 0)
            {
                rogueName.Enabled = false;

            }



            clericHealthText.Text = characters[2].CurrentHP + "/" + characters[2].MaxHP;
            clericHealth.Value = characters[2].CurrentHP;
            if (clericHealth.Value == 0)
            {
                clericName.Enabled = false;

            }


            jokerHealthText.Text = characters[3].CurrentHP + "/" + characters[3].MaxHP;
            jokerHealth.Value = characters[3].CurrentHP;
            if (jokerHealth.Value == 0)
            {
                jokerName.Enabled = false;

            }


            target = null;
            enemy1Name.BackColor = Color.White;
            enemy2Name.BackColor = Color.White;
            enemy3Name.BackColor = Color.White;
            enemy4Name.BackColor = Color.White;

            knightName.BackColor = Color.White;
            rogueName.BackColor = Color.White;
            clericName.BackColor = Color.White;
            jokerName.BackColor = Color.White;

            if (expedition.Monsters.All(monster => monster.IsDead()))
            {

                MessageBox.Show("Zwyciestwo!", "Powrot do Bazy", MessageBoxButtons.OK, MessageBoxIcon.Question);
                InitializeAfterFight();
                eventFirst?.Invoke(true, expedition);
                FinishButtonClicked?.Invoke(this, EventArgs.Empty);

            }
            if (characters.All(character => character.IsDead()))
            {
                MessageBox.Show("Porażka!", "Powrot do Bazy", MessageBoxButtons.OK, MessageBoxIcon.Question);
                InitializeAfterFight();
                eventFirst?.Invoke(false, expedition);
                FinishButtonClicked?.Invoke(this, EventArgs.Empty);
            }
        }
        private void InitializeAfterFight()
        {
           cooldowns.Clear();
           
            foreach (var key in effects.Keys.ToList())
            {
           

              
                
                    if (key.Equals("Provoke"))
                    {
                        Knight knight = (Knight)characters[0];
                        knight.Provoke(false);
                    }
                    if (key.Equals("CritAndDodgeBuff"))
                    {
                        Rogue rogue = (Rogue)characters[1];
                        rogue.CritAndDodgeBuff(false);
                    }
                    if (key.Equals("AoeBuff"))
                    {
                        Joker joker = (Joker)characters[3];
                        joker.AoeBuff(characters, false);
                    }
                    if (key.Equals("AoeDeBuff"))
                    {
                        Joker joker = (Joker)characters[3];
                        joker.AoeDeBuff(expedition.Monsters, false);
                    }

                   

            }
            effects.Clear();
            characters[0].CurrentHP = characters[0].MaxHP;
            characters[1].CurrentHP = characters[1].MaxHP;
            characters[2].CurrentHP = characters[2].MaxHP;
            characters[3].CurrentHP = characters[3].MaxHP;
        }
        private void InitializeBeforeFight()
        {
            fightOrder.Clear();

            basicAttackLabel.Text = "Atak Bazowy";

            knightName.Text = characters[0].Name;
            knightName.Enabled = true;
            knightHealthText.Text = characters[0].CurrentHP + "/" + characters[0].MaxHP;
            knightHealth.Value = characters[0].CurrentHP;
            knightHealth.Maximum = characters[0].MaxHP;
            knightName.Click += Enemy_Click;

            rogueName.Text = characters[1].Name;
            rogueName.Enabled = true;
            rogueHealthText.Text = characters[1].CurrentHP + "/" + characters[1].MaxHP;
            rogueHealth.Value = characters[1].CurrentHP;
            rogueHealth.Maximum = characters[1].MaxHP;
            rogueName.Click += Enemy_Click;

            clericName.Text = characters[2].Name;
            clericName.Enabled = true;
            clericHealthText.Text = characters[2].CurrentHP + "/" + characters[2].MaxHP;
            clericHealth.Value = characters[2].CurrentHP;
            clericHealth.Maximum = characters[2].MaxHP;
            clericName.Click += Enemy_Click;

            jokerName.Text = characters[3].Name;
            jokerName.Enabled = true;
            jokerHealthText.Text = characters[3].CurrentHP + "/" + characters[3].MaxHP;
            jokerHealth.Value = characters[3].CurrentHP;
            jokerHealth.Maximum = characters[3].MaxHP;
            jokerName.Click += Enemy_Click;

            
                enemy1Name.Text = expedition.Monsters[0].Name;
            enemy1Name.Enabled = true;
                enemy1HealthText.Text = expedition.Monsters[0].CurrentHP + "/" + expedition.Monsters[0].MaxHP;
                enemy1Health.Maximum = expedition.Monsters[0].MaxHP;
                enemy1Health.Value = expedition.Monsters[0].CurrentHP;
                enemy1Name.Click += Enemy_Click;

                enemy2Name.Text = expedition.Monsters[1].Name;
            enemy2Name.Enabled = true;
                enemy2HealthText.Text = expedition.Monsters[1].CurrentHP + "/" + expedition.Monsters[1].MaxHP;
                enemy2Health.Maximum = expedition.Monsters[1].MaxHP;
                enemy2Health.Value = expedition.Monsters[1].CurrentHP;
                enemy2Name.Click += Enemy_Click;

                enemy3Name.Text = expedition.Monsters[2].Name;
            enemy3Name.Enabled = true;
                enemy3HealthText.Text = expedition.Monsters[2].CurrentHP + "/" + expedition.Monsters[2].MaxHP;
                enemy3Health.Maximum = expedition.Monsters[2].MaxHP;
                enemy3Health.Value = expedition.Monsters[2].CurrentHP;
                enemy3Name.Click += Enemy_Click;

                enemy4Name.Text = expedition.Monsters[3].Name;
            enemy4Name.Enabled = true;
                enemy4HealthText.Text = expedition.Monsters[3].CurrentHP + "/" + expedition.Monsters[3].MaxHP;
                enemy4Health.Maximum = expedition.Monsters[3].MaxHP;
                enemy4Health.Value = expedition.Monsters[3].CurrentHP;
                enemy4Name.Click += Enemy_Click;

            
           

            //Kolejnosc Tur

            fightOrder.AddRange(expedition.Monsters);
            fightOrder.AddRange(characters);
            fightOrder = fightOrder.OrderByDescending(x => x.Initiative).ToList();

            startButton.Enabled = true;
            startButton.Visible = true;

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

        private void startButton_Click(object sender, EventArgs e)
        {
            Fight();
            startButton.Enabled = false;
            startButton.Visible = false;
        }
    }
}