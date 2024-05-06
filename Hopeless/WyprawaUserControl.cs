using HopelessLibary;
using HopelessLibary.Intefrace;
using NAudio.Wave;
using System.Data;
using System.Diagnostics.Eventing.Reader;

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
        public event EventHandler eventChoice;
        private Dictionary<string, int> cooldowns = new();
        private Dictionary<string, int> effects = new();
        public bool eventResult;

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

            bool fightStatus = true;
            bool playerActionTaken;
            int tura = 0;
            while (fightStatus)
            {
                tura++;
                turaLabel.Text = "Tura: " + tura;
                foreach (var postac in fightOrder)
                {
                    activeCharacterLabel.Text = "Aktywna Postać:" + postac.Name;
                    playerActionTaken = false;
                    if (postac is Knight && !postac.IsDead())
                    {
                        knightName.BackColor = Color.Cyan;
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

                        skill1Label.AccessibleDescription = "Sprawia, że wszyscy wrogowie skupiają się na postaci Knight" + Environment.NewLine + "Cooldown: 4 tury" + Environment.NewLine + "Czas Trwania: 2 tury";
                        skill2Label.AccessibleDescription = "Uderzasz wszystkich wrogów mocą Swiatła" + Environment.NewLine + "Cooldown: 2 tury" + Environment.NewLine + "DMG: " + knight.Intelligence + "-" + (knight.Intelligence + 2);
                        basicAttackLabel.AccessibleDescription = "Atakujesz Wroga za pomocą swojej broni" + Environment.NewLine + "DMG: " + knight.MinDmg + "-" + knight.MaxDmg;


                        EventHandler handlerBassicAttack = (s, e) =>
                        {
                            if (target != null)
                            {
                                int hp = target.CurrentHP;
                                knight.BasicAttack(target, out int dmg);

                                PlayBasicAttackSound();
                                playerActionTaken = true;
                                if (target.CurrentHP != hp)
                                    logBattleBox.Text = postac.Name + " atakuje " + target.Name + " zadając: " + (hp-target.CurrentHP) + " Obrażeń" + Environment.NewLine + logBattleBox.Text;
                                else
                                    logBattleBox.Text = postac.Name + " atakuje " + target.Name + " lecz zrobił unik" + Environment.NewLine + logBattleBox.Text;
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
                                PlayProvokeSound();
                                logBattleBox.Text = postac.Name + " używa umiejętności Provoke prowokując przeciwnikó" + Environment.NewLine + logBattleBox.Text;
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

                                knight.Purify(expedition.Monsters, out int dmg);
                                PlayPurifySound();
                                logBattleBox.Text = postac.Name + " używa umiejętności Purify na wrogów zadając " + dmg + " obrażeń" + Environment.NewLine + logBattleBox.Text;
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
                        skill1Label.AccessibleDescription = "";
                        skill2Label.AccessibleDescription = "";
                        basicAttackLabel.AccessibleDescription = "";
                        skill1Label.Enabled = true;
                        skill2Label.Enabled = true;
                        knightName.BackColor = Color.LightGray;

                    }
                    else if (postac is Rogue && !postac.IsDead())
                    {
                        Rogue rogue = (Rogue)postac;
                        rogueName.BackColor = Color.Cyan;
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
                        skill1Label.AccessibleDescription = "Uderzasz wybranego wroga w plecy" + Environment.NewLine + "Cooldown: 2 tury" + Environment.NewLine + "DMG: " + rogue.Dexterity + "-" + (rogue.Dexterity + 5);
                        skill2Label.AccessibleDescription = "Sprawia, że nastepny atak Rogue bedzie krytyczny oraz uniknie ataków na czas trwania efektu" + Environment.NewLine + "Cooldown: 4 tury" + Environment.NewLine + "Czas Trwania: 2 tury";

                        basicAttackLabel.AccessibleDescription = "Atakujesz Wroga za pomocą swojej broni" + Environment.NewLine + "DMG: " + rogue.MinDmg + "-" + rogue.MaxDmg;


                        EventHandler handlerBassicAttack = (s, e) =>
                        {
                            if (target != null)
                            {
                                int hp = target.CurrentHP;
                                rogue.BasicAttack(target, out int dmg);

                                PlayBasicAttackSound();
                                playerActionTaken = true;
                                if (target.CurrentHP != hp)
                                    logBattleBox.Text = postac.Name + " atakuje " + target.Name + " zadając:" + (hp - target.CurrentHP) + " Obrażeń" + Environment.NewLine + logBattleBox.Text;
                                else
                                    logBattleBox.Text = postac.Name + " atakuje " + target.Name + " lecz zrobił unik" + Environment.NewLine + logBattleBox.Text;
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
                                    int hp = target.CurrentHP;
                                    rogue.Ambush((Monster)target, out int dmg);
                                    if (target.CurrentHP != hp)
                                        logBattleBox.Text = postac.Name + " używa umiejętności Ambush na " + target.Name + " zadając " + (hp - target.CurrentHP) + " obrażeń" + Environment.NewLine + logBattleBox.Text;
                                    else
                                        logBattleBox.Text = postac.Name + " używa umiejętności Ambush na " + target.Name + " lecz ten zrobił unik" + Environment.NewLine + logBattleBox.Text;

                                    PlayAmbushSound();
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
                                PlayCritAndDodgeBuffSound();
                                logBattleBox.Text = postac.Name + " używa umiejętności CritAndDodgeBuff na sobie" + Environment.NewLine + logBattleBox.Text;
                                cooldowns.Add("CritAndDodgeBuff", 4);
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
                        skill1Label.AccessibleDescription = "";
                        skill2Label.AccessibleDescription = "";
                        basicAttackLabel.AccessibleDescription = "";
                        skill1Label.Enabled = true;
                        skill2Label.Enabled = true;
                        rogueName.BackColor = Color.LightGray;

                    }
                    else if (postac is Cleric && !postac.IsDead())
                    {
                        Cleric cleric = (Cleric)postac;
                        clericName.BackColor = Color.Cyan;
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

                        skill1Label.AccessibleDescription = "Leczysz wybranego sojusznika mocą Swiatła, istnieje szansa że Cleric wyleczy również siebie" + Environment.NewLine + "Cooldown: 6 tury" + Environment.NewLine + "heal: " + cleric.Intelligence + "-" + (cleric.Intelligence + 5);
                        skill2Label.AccessibleDescription = "Leczysz wszystkich sojuszników mocą Swiatła" + Environment.NewLine + "Cooldown: 4 tury" + Environment.NewLine + "heal: " + cleric.Intelligence + "-" + (cleric.Intelligence + 2);
                        basicAttackLabel.AccessibleDescription = "Atakujesz Wroga za pomocą swojej broni" + Environment.NewLine + "DMG: " + cleric.MinDmg + "-" + cleric.MaxDmg;


                        EventHandler handlerBassicAttack = (s, e) =>
                        {
                            if (target != null)
                            {
                                int hp = target.CurrentHP;
                                cleric.BasicAttack(target, out int dmg);

                                PlayBasicAttackSound();
                                playerActionTaken = true;
                                if (target.CurrentHP != hp)
                                    logBattleBox.Text = postac.Name + " atakuje " + target.Name + " zadając:" + (hp - target.CurrentHP) + " Obrażeń" + Environment.NewLine + logBattleBox.Text;
                                else
                                    logBattleBox.Text = postac.Name + " atakuje " + target.Name + " lecz zrobił unik" + Environment.NewLine + logBattleBox.Text;
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

                                cleric.Heal((Character)target, out int heal);
                                PlayHealSound();
                                logBattleBox.Text = postac.Name + " używa umiejętności Heal na " + target.Name + " lecząc za " + heal + " punktów zdrowia" + Environment.NewLine + logBattleBox.Text;
                                cooldowns.Add("Heal", 4);
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

                                cleric.AoeHeal(characters, out int heal);
                                PlayHealSound();
                                logBattleBox.Text = postac.Name + " używa umiejętności AoeHeal na sojuszników lecząc za " + heal + " punktów zdrowia" + Environment.NewLine + logBattleBox.Text;
                                cooldowns.Add("AoeHeal", 6);
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
                        skill1Label.AccessibleDescription = "";
                        skill2Label.AccessibleDescription = "";
                        basicAttackLabel.AccessibleDescription = "";
                        skill1Label.Enabled = true;
                        skill2Label.Enabled = true;
                        clericName.BackColor = Color.LightGray;
                    }
                    else if (postac is Joker && !postac.IsDead())
                    {
                        Joker joker = (Joker)postac;
                        jokerName.BackColor = Color.Cyan;
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

                        skill1Label.AccessibleDescription = "Błogosławisz wszystkich sojusznikow zwiększając ich DMG" + Environment.NewLine + "Cooldown: 5 tury" + Environment.NewLine + "Czas Trwania: 3 tury";
                        skill2Label.AccessibleDescription = "Przeklinasz wszystkich wrogów zmniejszajac ich Odporność" + Environment.NewLine + "Cooldown: 5 tury" + Environment.NewLine + "Czas Trwania: 3 tury";
                        basicAttackLabel.AccessibleDescription = "Atakujesz Wroga za pomocą swojej broni" + Environment.NewLine + "DMG: " + joker.MinDmg + "-" + joker.MaxDmg;


                        EventHandler handlerBassicAttack = (s, e) =>
                        {
                            if (target != null)
                            {
                                if (new Random().Next(1, 101) > joker.DoubleAtackChance)
                                {
                                    int hp = target.CurrentHP;
                                    joker.BasicAttack(target, out int dmg);
                                    if (target.CurrentHP != hp)
                                        logBattleBox.Text = postac.Name + " atakuje " + target.Name + " zadając:" + (hp - target.CurrentHP) + " Obrażeń" + Environment.NewLine + logBattleBox.Text;
                                    else
                                        logBattleBox.Text = postac.Name + " atakuje " + target.Name + " lecz zrobił unik" + Environment.NewLine + logBattleBox.Text;
                                }
                                else
                                {
                                    int hp = target.CurrentHP;
                                    joker.BasicAttack(target, out int dmg);

                                    if (target.CurrentHP != hp)
                                        logBattleBox.Text = postac.Name + " atakuje " + target.Name + " zadając:" + (hp - target.CurrentHP) + " Obrażeń" + Environment.NewLine + logBattleBox.Text;
                                    else
                                        logBattleBox.Text = postac.Name + " atakuje " + target.Name + " lecz zrobił unik" + Environment.NewLine + logBattleBox.Text;
                                    hp = target.CurrentHP;
                                    joker.BasicAttack(target, out dmg);
                                    if (target.CurrentHP != hp)
                                        logBattleBox.Text = postac.Name + " atakuje " + target.Name + " zadając:" + (hp - target.CurrentHP) + " Obrażeń" + Environment.NewLine + logBattleBox.Text;
                                    else
                                        logBattleBox.Text = postac.Name + " atakuje " + target.Name + " lecz zrobił unik" + Environment.NewLine + logBattleBox.Text;
                                }



                                PlayBasicAttackSound();
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
                                PlayAoeBuffSound();
                                logBattleBox.Text = postac.Name + " używa umiejętności AoeBuff na sojuszników" + Environment.NewLine + logBattleBox.Text;
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
                                PlayAoeDebuffSound();
                                logBattleBox.Text = postac.Name + " używa umiejętności AoeDeBuff na wrogów" + Environment.NewLine + logBattleBox.Text;
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
                        skill1Label.AccessibleDescription = "";
                        skill2Label.AccessibleDescription = "";
                        basicAttackLabel.AccessibleDescription = "";
                        skill1Label.Enabled = true;
                        skill2Label.Enabled = true;
                        jokerName.BackColor = Color.LightGray;
                    }
                    else
                    {
                        if (!postac.IsDead())
                        {
                            Monster monster = (Monster)postac;
                            await Task.Delay(1000);
                            do {
                                if (effects.ContainsKey("Provoke") && !characters[0].IsDead())
                                {
                                    target = characters[0];
                                }
                                else
                                {
                                    int i = new Random().Next(0, 4);
                                    target = characters[i];
                                }

                            } while (target.IsDead());
                                int hp = target.CurrentHP;
                        
                            monster.BasicAttack(target, out int dmg);

                            PlayBasicAttackSound();
                            if (target.CurrentHP != hp)
                                logBattleBox.Text = postac.Name + " atakuje " + target.Name + " zadając:" + (hp - target.CurrentHP) + " Obrażeń" + Environment.NewLine + logBattleBox.Text;
                            else if (target.CurrentHP == hp && target is Rogue)
                                logBattleBox.Text = postac.Name + " atakuje " + target.Name + " lecz zrobił unik" + Environment.NewLine + logBattleBox.Text;
                            else
                                logBattleBox.Text = postac.Name + " atakuje " + target.Name + " lecz zablokowal" + Environment.NewLine + logBattleBox.Text;
                        }


                    }
                    if (CheckStatus())
                    {
                        fightStatus = false;
                        break;

                    }
                    RefreshEffectBox();

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
                    RefreshEffectBox();
                }

            };
        }
        private void RefreshEffectBox()
        {
            effectBox.Clear();
            effectBox.Text += "Aktywne Statusy" + Environment.NewLine;

            foreach (var key in effects.Keys.ToList())
            {
                effectBox.Text += key + " : " + effects[key] + Environment.NewLine;


            }
        }
        private bool CheckStatus()
        {
            enemy1Health.Value = expedition.Monsters[0].CurrentHP;
            enemy1HealthText.Text = expedition.Monsters[0].CurrentHP + "/" + expedition.Monsters[0].MaxHP;
            if (enemy1Health.Value == 0)
            {
                enemy1Picture.Enabled = false;


            }
            enemy2Health.Value = expedition.Monsters[1].CurrentHP;
            enemy2HealthText.Text = expedition.Monsters[1].CurrentHP + "/" + expedition.Monsters[1].MaxHP;
            if (enemy2Health.Value == 0)
            {
                enemy2Picture.Enabled = false;

            }
            enemy3Health.Value = expedition.Monsters[2].CurrentHP;
            enemy3HealthText.Text = expedition.Monsters[2].CurrentHP + "/" + expedition.Monsters[2].MaxHP;
            if (enemy3Health.Value == 0)
            {
                enemy3Picture.Enabled = false;

            }
            enemy4Health.Value = expedition.Monsters[3].CurrentHP;
            enemy4HealthText.Text = expedition.Monsters[3].CurrentHP + "/" + expedition.Monsters[3].MaxHP;
            if (enemy4Health.Value == 0)
            {
                enemy4Picture.Enabled = false;

            }

            knightHealthText.Text = characters[0].CurrentHP + "/" + characters[0].MaxHP;
            knightHealth.Value = characters[0].CurrentHP;
            if (knightHealth.Value == 0)
            {
                knightPicture.Enabled = false;

            }



            rogueHealthText.Text = characters[1].CurrentHP + "/" + characters[1].MaxHP;
            rogueHealth.Value = characters[1].CurrentHP;
            if (rogueHealth.Value == 0)
            {
                roguePicture.Enabled = false;

            }



            clericHealthText.Text = characters[2].CurrentHP + "/" + characters[2].MaxHP;
            clericHealth.Value = characters[2].CurrentHP;
            if (clericHealth.Value == 0)
            {
                clericPicture.Enabled = false;

            }


            jokerHealthText.Text = characters[3].CurrentHP + "/" + characters[3].MaxHP;
            jokerHealth.Value = characters[3].CurrentHP;
            if (jokerHealth.Value == 0)
            {
                jokerPicture.Enabled = false;

            }


            target = null;
            enemy1Picture.BackColor = Color.White;
            enemy2Picture.BackColor = Color.White;
            enemy3Picture.BackColor = Color.White;
            enemy4Picture.BackColor = Color.White;

            knightPicture.BackColor = Color.White;
            roguePicture.BackColor = Color.White;
            clericPicture.BackColor = Color.White;
            jokerPicture.BackColor = Color.White;

            if (expedition.Monsters.All(monster => monster.IsDead()))
            {
                PlayWinSound();

                if (expedition.Type == DifficultyType.Event)
                {
                    

                    
                    DialogResult result = MessageBox.Show("Pokonałeś Gauntera'O Dima, Niebywałe!!! Zamierzasz go dobić?","Podejmij Decyzje", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                   
                    if (result == DialogResult.Yes)
                    {
                            PlayEventKillSound();
                           
                    }else
                    {
                            eventChoice?.Invoke(this, EventArgs.Empty);
                            PlayEventSaveSound();
                          
                     }
                 
                    
                }
               
                InitializeAfterFight();

                
                MessageBox.Show("Zwyciestwo!", "Powrot do Bazy", MessageBoxButtons.OK, MessageBoxIcon.Question);
                eventFirst?.Invoke(true, expedition);
                FinishButtonClicked?.Invoke(this, EventArgs.Empty);
                return true;
                

            }
            if (characters.All(character => character.IsDead()))
            {
                InitializeAfterFight();
                PlayLoseSound();
                MessageBox.Show("Porażka!", "Powrot do Bazy", MessageBoxButtons.OK, MessageBoxIcon.Question);

                eventFirst?.Invoke(false, expedition);
                FinishButtonClicked?.Invoke(this, EventArgs.Empty);
                return true;
            }
            return false;
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

        }
        private void InitializeBeforeFight()
        {
            logBattleBox.Clear();
            fightOrder.Clear();
            cooldowns.Clear();
            basicAttackLabel.Text = "Atak Bazowy";
            skill1Label.Text = "";
            skill2Label.Text = "";
            skill1Label.MouseHover += SkillMouseHover;
            skill2Label.MouseHover += SkillMouseHover;
            basicAttackLabel.MouseHover += SkillMouseHover;

            knightName.Text = characters[0].Name;
            knightPicture.Enabled = true;
            knightHealthText.Text = characters[0].CurrentHP + "/" + characters[0].MaxHP;
            knightHealth.Maximum = characters[0].MaxHP;
            knightHealth.Value = characters[0].CurrentHP;
            knightPicture.Click += Enemy_Click;

            knightPicture.Image = Properties.Resources.knightPicture;

            rogueName.Text = characters[1].Name;
            roguePicture.Enabled = true;
            rogueHealthText.Text = characters[1].CurrentHP + "/" + characters[1].MaxHP;
            rogueHealth.Maximum = characters[1].MaxHP;
            rogueHealth.Value = characters[1].CurrentHP;
            roguePicture.Click += Enemy_Click;

            roguePicture.Image = Properties.Resources.roguePicture;

            clericName.Text = characters[2].Name;
            clericPicture.Enabled = true;
            clericHealthText.Text = characters[2].CurrentHP + "/" + characters[2].MaxHP;
            clericHealth.Maximum = characters[2].MaxHP;
            clericHealth.Value = characters[2].CurrentHP;
            clericPicture.Click += Enemy_Click;

            clericPicture.Image = Properties.Resources.clericPicture;

            jokerName.Text = characters[3].Name;
            jokerPicture.Enabled = true;
            jokerHealthText.Text = characters[3].CurrentHP + "/" + characters[3].MaxHP;
            jokerHealth.Maximum = characters[3].MaxHP;
            jokerHealth.Value = characters[3].CurrentHP;
            jokerPicture.Click += Enemy_Click;
            jokerPicture.Image = Properties.Resources.jokerPicture;


            enemy1Name.Text = expedition.Monsters[0].Name;
            enemy1Picture.Enabled = true;
            enemy1HealthText.Text = expedition.Monsters[0].CurrentHP + "/" + expedition.Monsters[0].MaxHP;
            enemy1Health.Maximum = expedition.Monsters[0].MaxHP;
            enemy1Health.Value = expedition.Monsters[0].CurrentHP;
            enemy1Picture.Click += Enemy_Click;

            enemy1Picture.Image = (Image)Properties.Resources.ResourceManager.GetObject(expedition.Monsters[0].Name);

            enemy2Name.Text = expedition.Monsters[1].Name;
            enemy2Picture.Enabled = true;
            enemy2HealthText.Text = expedition.Monsters[1].CurrentHP + "/" + expedition.Monsters[1].MaxHP;
            enemy2Health.Maximum = expedition.Monsters[1].MaxHP;
            enemy2Health.Value = expedition.Monsters[1].CurrentHP;
            enemy2Picture.Click += Enemy_Click;
 
            enemy2Picture.Image = (Image)Properties.Resources.ResourceManager.GetObject(expedition.Monsters[1].Name);

            enemy3Name.Text = expedition.Monsters[2].Name;
            enemy3Picture.Enabled = true;
            enemy3HealthText.Text = expedition.Monsters[2].CurrentHP + "/" + expedition.Monsters[2].MaxHP;
            enemy3Health.Maximum = expedition.Monsters[2].MaxHP;
            enemy3Health.Value = expedition.Monsters[2].CurrentHP;
            enemy3Picture.Click += Enemy_Click;
      
            enemy3Picture.Image = (Image)Properties.Resources.ResourceManager.GetObject(expedition.Monsters[2].Name);

            enemy4Name.Text = expedition.Monsters[3].Name;
            enemy4Picture.Enabled = true;
            enemy4HealthText.Text = expedition.Monsters[3].CurrentHP + "/" + expedition.Monsters[3].MaxHP;
            enemy4Health.Maximum = expedition.Monsters[3].MaxHP;
            enemy4Health.Value = expedition.Monsters[3].CurrentHP;
            enemy4Picture.Click += Enemy_Click;
       
            enemy4Picture.Image = (Image)Properties.Resources.ResourceManager.GetObject(expedition.Monsters[3].Name);




            //Kolejnosc Tur

            fightOrder.AddRange(expedition.Monsters);
            fightOrder.AddRange(characters);
            fightOrder = fightOrder.OrderByDescending(x => x.Initiative).ToList();

            startButton.Enabled = true;
            startButton.Visible = true;
            if(expedition.Type==DifficultyType.Boss && eventResult)
            {
                PlayEventHelpSound();
                MessageBox.Show("Gaunter O'Dim przyszedł się odwdzięczyć za wcześniej!", "Wyrównanie Rachunków", MessageBoxButtons.OK, MessageBoxIcon.Question);
            }
        }

        private void Enemy_Click(object? sender, EventArgs e)
        {
            enemy1Picture.BackColor = Color.White;
            enemy2Picture.BackColor = Color.White;
            enemy3Picture.BackColor = Color.White;
            enemy4Picture.BackColor = Color.White;

            knightPicture.BackColor = Color.White;
            roguePicture.BackColor = Color.White;
            clericPicture.BackColor = Color.White;
            jokerPicture.BackColor = Color.White;

            var pictureBox = sender as PictureBox;

            if (pictureBox != null)
            {
                if (pictureBox.Name.Equals("enemy1Picture"))
                {
                    target = expedition.Monsters[0];
                    pictureBox.BackColor = Color.Yellow;
                }
                else if (pictureBox.Name.Equals("enemy2Picture"))
                {
                    target = expedition.Monsters[1];
                    pictureBox.BackColor = Color.Yellow;
                }
                else if (pictureBox.Name.Equals("enemy3Picture"))
                {
                    target = expedition.Monsters[2];
                    pictureBox.BackColor = Color.Yellow;
                }
                else if (pictureBox.Name.Equals("enemy4Picture"))
                {
                    target = expedition.Monsters[3];
                    pictureBox.BackColor = Color.Yellow;
                }
                else if (pictureBox.Name.Equals("knightPicture"))
                {
                    target = characters[0];
                    pictureBox.BackColor = Color.Yellow;
                }
                else if (pictureBox.Name.Equals("roguePicture"))
                {
                    target = characters[1];
                    pictureBox.BackColor = Color.Yellow;
                }
                else if (pictureBox.Name.Equals("clericPicture"))
                {
                    target = characters[2];
                    pictureBox.BackColor = Color.Yellow;
                }
                else if (pictureBox.Name.Equals("jokerPicture"))
                {
                    target = characters[3];
                    pictureBox.BackColor = Color.Yellow;
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
        private void PlayWinSound()
        {
            Stream equipWeaponStream = Properties.Resources.winSound;
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
        private void PlayLoseSound()
        {
            Stream equipWeaponStream = Properties.Resources.loseSound;
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
        private void PlayAmbushSound()
        {
            Stream equipWeaponStream = Properties.Resources.ambushSound;
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
        private void PlayCritAndDodgeBuffSound()
        {
            Stream equipWeaponStream = Properties.Resources.critAndDodgeBuffSound;
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
        private void PlayHealSound()
        {
            Stream equipWeaponStream = Properties.Resources.healSound;
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
        private void PlayProvokeSound()
        {
            Stream equipWeaponStream = Properties.Resources.provokeSound;
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
        private void PlayPurifySound()
        {
            Stream equipWeaponStream = Properties.Resources.purifySound;
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
        private void PlayAoeBuffSound()
        {
            Stream equipWeaponStream = Properties.Resources.aoeBuffSound;
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
        private void PlayAoeDebuffSound()
        {
            Stream equipWeaponStream = Properties.Resources.aoeDebuffSound;
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
        private void PlayBasicAttackSound()
        {
            Stream equipWeaponStream = Properties.Resources.basicAttackSound;
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
        private void PlayEventKillSound()
        {
            Stream equipWeaponStream = Properties.Resources.killGaunterSound;
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
        private void PlayEventSaveSound()
        {
            Stream equipWeaponStream = Properties.Resources.saveGaunterSound;
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
        private void PlayEventHelpSound()
        {
            Stream equipWeaponStream = Properties.Resources.gaunterHelpSound;
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

        private void SkillMouseHover(object sender, EventArgs e)
        {
            Label label = sender as Label;
            if (label.AccessibleDescription != "  ")
            {
                toolTip.SetToolTip(label, label.AccessibleDescription);
            }

        }
    }
}