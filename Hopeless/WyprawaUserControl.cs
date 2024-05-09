﻿using HopelessLibary;
using HopelessLibary.Enums;
using HopelessLibary.Intefrace;
using NAudio.Wave;
using System.Data;
using System.Diagnostics.Eventing.Reader;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TextBox;

namespace Hopeless
{
    public partial class WyprawaUserControl : UserControl
    {
        public List<Character> characters { get; set; }
        public Expedition expedition { get; set; }


        private List<ICreature> fightOrder = new();
        private List<ICreature> target = new();
        public delegate void CustomDelegate(bool wynik, Expedition wyprawa);
        public event CustomDelegate eventFirst;
        public event EventHandler FinishButtonClicked;
        public event EventHandler eventChoice;
        public bool eventResult;
        private bool playerActionTaken = false;
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
            try
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
                        target.Clear();
                        activeCharacterLabel.Text = "Aktywna Postać:" + postac.Name;
                        playerActionTaken = false;
                        if (postac.CharacterType != CharacterType.Monster && !postac.IsDead())
                        {
                            skill1Label.Enabled = true;
                            skill2Label.Enabled = true;
                            basicAttackLabel.Enabled = true;

                            if (postac.Skill1 != null)
                            {
                                skill1Label.Text = postac.Skill1.Name;
                                if (postac.Skill1.Cooldown > 0)
                                    skill1Label.Text += Environment.NewLine + "Odnawianie: " + postac.Skill1.Cooldown + " tur";
                            }
                            if (postac.Skill2 != null)
                            {
                                skill2Label.Text = postac.Skill2.Name;
                                if (postac.Skill2.Cooldown > 0)
                                    skill2Label.Text += Environment.NewLine + "Odnawianie: " + postac.Skill2.Cooldown + " tur";
                            }

                            skill1Label.AccessibleDescription = postac.Skill1?.Description;
                            skill2Label.AccessibleDescription = postac.Skill2?.Description;
                            basicAttackLabel.AccessibleDescription = postac.BasicAttackDescription;

                            EventHandler skillClick1 = (s, e) =>
                            {
                                SkillHandlerResponse response;
                                if (postac.Skill1.SkillType == SkillType.AoE)
                                {
                                    response = postac.Skill1?
                                    .SkillHandler
                                    .Invoke(postac, fightOrder);
                                }
                                else
                                {
                                    if (target != null && postac.Skill1.TargetType == TargetType.Enemy && target.Any(x => x.CharacterType == CharacterType.Monster))
                                    {
                                        response = postac.Skill1?
                                    .SkillHandler
                                    .Invoke(postac, target);
                                    }
                                    else if (target != null && postac.Skill1.TargetType == TargetType.Ally && target.Any(x => x.CharacterType != CharacterType.Monster))
                                    {
                                        response = postac.Skill1?
                                         .SkillHandler
                                         .Invoke(postac, target);
                                    }
                                    else
                                        response = null;
                                }
                                if (response == null)
                                {

                                    playerActionTaken = false;
                                    return;
                                }

                                if (response.cd > 0)
                                {
                                    MessageBox.Show("Nie mozesz tego uzyc, poczekaj: " + response.cd + " tur", "Cooldown Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    playerActionTaken = false;
                                    return;
                                }
                                logBattleBox.Text = postac.Name + response.logText + logBattleBox.Text;
                                playerActionTaken = true;

                            };
                            EventHandler skillClick2 = (s, e) =>
                            {
                                SkillHandlerResponse response;
                                if (postac.Skill2.SkillType == SkillType.AoE)
                                {
                                    response = postac.Skill2?
                                    .SkillHandler
                                    .Invoke(postac, fightOrder);
                                }
                                else
                                {
                                    if (target[0] != null && postac.Skill2.TargetType == TargetType.Enemy && target[0].CharacterType == CharacterType.Monster)
                                    {
                                        response = postac.Skill2?
                                    .SkillHandler
                                    .Invoke(postac, target);
                                    }
                                    else if (target[0] != null && postac.Skill2.TargetType == TargetType.Ally && target[0].CharacterType != CharacterType.Monster )
                                    {
                                        response = postac.Skill2?
                                         .SkillHandler
                                         .Invoke(postac, target);
                                    }
                                    else
                                        response = null;
                                }
                                if (response == null)
                                {

                                    playerActionTaken = false;
                                    return;
                                }

                                if (response.cd > 0)
                                {
                                    MessageBox.Show("Nie mozesz tego uzyc, poczekaj: " + response.cd + " tur", "Cooldown Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    playerActionTaken = false;
                                    return;
                                }
                                logBattleBox.Text = postac.Name + response.logText + logBattleBox.Text;
                                playerActionTaken = true;

                            };
                            EventHandler handlerBassicAttack = (s, e) =>
                            {
                                if (target.Count != 0)
                                {
                                    int hp = target[0].CurrentHP;
                                    postac.BasicAttack(target[0], out int dmg);

                                    PlayBasicAttackSound();
                                    playerActionTaken = true;
                                    if (target[0].CurrentHP != hp)
                                        logBattleBox.Text = postac.Name + " atakuje " + target[0].Name + " zadając: " + (hp - target[0].CurrentHP) + " Obrażeń" + Environment.NewLine + logBattleBox.Text;
                                    else
                                        logBattleBox.Text = postac.Name + " atakuje " + target[0].Name + " lecz zrobił unik" + Environment.NewLine + logBattleBox.Text;
                                }

                            };

                            skill1Label.Click += skillClick1;
                            skill2Label.Click += skillClick2;
                            basicAttackLabel.Click += handlerBassicAttack;

                            while (!playerActionTaken)
                            {
                                await Task.Delay(200);
                                if (target.Any(x => x.CharacterType != CharacterType.Monster) || target.Count == 0)
                                    basicAttackLabel.Enabled = false;
                                else
                                    basicAttackLabel.Enabled = true;
                            }

                            skill1Label.Click -= skillClick1;
                            skill2Label.Click -= skillClick2;
                            basicAttackLabel.Click -= handlerBassicAttack;

                            skill1Label.AccessibleDescription = "";
                            skill2Label.AccessibleDescription = "";
                            basicAttackLabel.AccessibleDescription = "";
                            skill1Label.Enabled = false;
                            skill2Label.Enabled = false;
                            basicAttackLabel.Enabled = false;

                            postac.CheckSkillsCd();
                        }
                        else
                        {
                            if (!postac.IsDead())
                            {
                                await Task.Delay(1000);
                               
                                do
                                {
                                    target.Clear();

                                    if (postac.DeBuffs != null && postac.DeBuffs.Count > 0)
                                    {
                                        var debuff = postac.DeBuffs.FirstOrDefault(x => x.Name.Equals("Provoke"));
                                        if (debuff != null)
                                        {
                                            target.Add(characters.FirstOrDefault(x => x.Id == debuff.Caster.Id));
                                        }
                                        else
                                        {
                                            int i = new Random().Next(0, 4);
                                            target.Add(characters[i]);
                                        }


                                    }
                                    else
                                    {
                                        int i = new Random().Next(0, 4);
                                        target.Add(characters[i]);
                                    }

                                } while (target[0].IsDead());
                                int hp = target[0].CurrentHP;

                                postac.BasicAttack(target[0], out int dmg);
                                PlayBasicAttackSound();
                                if (target[0].CurrentHP != hp)
                                    logBattleBox.Text = postac.Name + " atakuje " + target[0].Name + " zadając:" + (hp - target[0].CurrentHP) + " Obrażeń" + Environment.NewLine + logBattleBox.Text;
                                else if (target[0].CurrentHP == hp && target is Rogue)
                                    logBattleBox.Text = postac.Name + " atakuje " + target[0].Name + " lecz zrobił unik" + Environment.NewLine + logBattleBox.Text;
                                else
                                    logBattleBox.Text = postac.Name + " atakuje " + target[0].Name + " lecz zablokowal" + Environment.NewLine + logBattleBox.Text;


                            }

                        }
                        if (CheckStatus())
                        {
                            fightStatus = false;
                            break;

                        }
                        RefreshEffectBox();

                    }

                    foreach (var item in fightOrder)
                        item.CheckBuffsAndDebuffsAndRemoveIfNeeded();


                    RefreshEffectBox();
                    
                };
            }
            catch (Exception ex)
            {

            }
          
        }
        private void RefreshEffectBox()
        {
            effectBox.Clear();
            effectBox.Text += "Aktywne Statusy" + Environment.NewLine;
            List<Buff> allBuffs = new();
            List<DeBuff> allDeBuffs = new();
            List<(string, int)> list = new(0);
            foreach (var item in fightOrder)
            {
                // Utwórz słowniki dla buffów i debuffów oraz ich liczby na aktualnej postaci
                Dictionary<string, int> buffCount = new Dictionary<string, int>();
                Dictionary<string, int> debuffCount = new Dictionary<string, int>();

                if (item.Buffs != null)
                {
                    foreach (Buff buff in item.Buffs)
                    {
                        // Aktualizuj liczbę buffów na postaci
                        if (!buffCount.ContainsKey(buff.Name))
                        {
                            buffCount[buff.Name] = 1;
                        }
                        else
                        {
                            buffCount[buff.Name]++;
                        }
                    }
                }

                if (item.DeBuffs != null)
                {
                    foreach (DeBuff debuff in item.DeBuffs)
                    {
                        
                        if (!debuffCount.ContainsKey(debuff.Name))
                        {
                            debuffCount[debuff.Name] = 1;
                        }
                        else
                        {
                            debuffCount[debuff.Name]++;
                        }
                    }
                }

                // Wyświetl nazwy buffów i ich liczby dla aktualnej postaci
                foreach (var kvp in buffCount)
                {
                    if (kvp.Value > 1)
                        effectBox.Text += item.Name + "-" + kvp.Key + " x" + kvp.Value + "-" + GetBuffUptime(item.Buffs, kvp.Key) + Environment.NewLine;
                    else
                        effectBox.Text += item.Name + "-" + kvp.Key + "-" + GetBuffUptime(item.Buffs, kvp.Key) + Environment.NewLine;
                }

                // Wyświetl nazwy debuffów i ich liczby dla aktualnej postaci
                foreach (var kvp in debuffCount)
                {
                    if (kvp.Value > 1)
                    effectBox.Text += item.Name + "-" + kvp.Key + " x" + kvp.Value + "-" + GetDeBuffUptime(item.DeBuffs, kvp.Key) + Environment.NewLine;
                    else
                    effectBox.Text += item.Name + "-" + kvp.Key + "-" + GetDeBuffUptime(item.DeBuffs, kvp.Key) + Environment.NewLine;

                }
            }


        }
        private int GetBuffUptime(List<Buff> buffs, string buffName)
        {
           
            if (buffs != null)
            {
                foreach (Buff buff in buffs)
                {
                    if (buff.Name == buffName)
                    {
                        return buff.Uptime;
                    }
                }
            }
           return 0;
        }
        private int GetDeBuffUptime(List<DeBuff> debuffs, string debuffName)
        {

            if (debuffs != null)
            {
                foreach (DeBuff debuff in debuffs)
                {
                    if (debuff.Name == debuffName)
                    {
                        return debuff.Uptime;
                    }
                }
            }
            return 0;
        }

        private bool CheckStatus()
        {
            enemy1Health.Value = expedition.Monsters[0].CurrentHP;
            enemy1HealthText.Text = expedition.Monsters[0].CurrentHP + "/" + expedition.Monsters[0].MaxHP;
            if (enemy1Health.Value == 0)
            {
                enemy1Picture.Enabled = false;

                enemy1Picture.BackColor = Color.Black;
            }
            else
            {
                enemy1Picture.BackColor = Color.White;
            }
            enemy2Health.Value = expedition.Monsters[1].CurrentHP;
            enemy2HealthText.Text = expedition.Monsters[1].CurrentHP + "/" + expedition.Monsters[1].MaxHP;
            if (enemy2Health.Value == 0)
            {
                enemy2Picture.Enabled = false;
                enemy2Picture.BackColor = Color.Black;
            }
            else
            {
                enemy2Picture.BackColor = Color.White;
            }
            enemy3Health.Value = expedition.Monsters[2].CurrentHP;
            enemy3HealthText.Text = expedition.Monsters[2].CurrentHP + "/" + expedition.Monsters[2].MaxHP;
            if (enemy3Health.Value == 0)
            {
                enemy3Picture.Enabled = false;
                enemy3Picture.BackColor = Color.Black;
            }
            else
            {
                enemy3Picture.BackColor = Color.White;
            }
            enemy4Health.Value = expedition.Monsters[3].CurrentHP;
            enemy4HealthText.Text = expedition.Monsters[3].CurrentHP + "/" + expedition.Monsters[3].MaxHP;
            if (enemy4Health.Value == 0)
            {
                enemy4Picture.Enabled = false;
                enemy4Picture.BackColor = Color.Black;
            }
            else
            {
                enemy4Picture.BackColor = Color.White;
            }

            character1HealthText.Text = characters[0].CurrentHP + "/" + characters[0].MaxHP;
            character1Health.Value = characters[0].CurrentHP;
            if (character1Health.Value == 0)
            {
                character1Picture.Enabled = false;

                character1Picture.BackColor = Color.Black;
            }
            else
            {
                character1Picture.BackColor = Color.White;
            }


            character2HealthText.Text = characters[1].CurrentHP + "/" + characters[1].MaxHP;
            character2Health.Value = characters[1].CurrentHP;
            if (character2Health.Value == 0)
            {
                character2Picture.Enabled = false;
                character2Picture.BackColor = Color.Black;
            }
            else
            {
                character2Picture.BackColor = Color.White;
            }


            character3HealthText.Text = characters[2].CurrentHP + "/" + characters[2].MaxHP;
            character3Health.Value = characters[2].CurrentHP;
            if (character3Health.Value == 0)
            {
                character3Picture.Enabled = false;
                character3Picture.BackColor = Color.Black;
            }
            else
            {
                character3Picture.BackColor = Color.White;
            }


            character4HealthText.Text = characters[3].CurrentHP + "/" + characters[3].MaxHP;
            character4Health.Value = characters[3].CurrentHP;
            if (character4Health.Value == 0)
            {
                character4Picture.Enabled = false;
                character4Picture.BackColor = Color.Black;
            }
            else
            {
                character4Picture.BackColor = Color.White;
            }


          
  

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
            

            foreach (var item in fightOrder) { 
                item.ClearEffetsAfterBattle();
                if(item.Skill1 != null)
                item.Skill1.Cooldown = 0;
                if (item.Skill2 != null)
                item.Skill2.Cooldown = 0;
            }


        }
        private void InitializeBeforeFight()
        {
            logBattleBox.Clear();
            fightOrder.Clear();

            enemy1Picture.BackColor = Color.White;
            enemy2Picture.BackColor = Color.White;
            enemy3Picture.BackColor = Color.White;
            enemy4Picture.BackColor = Color.White;

            character1Picture.BackColor = Color.White;
            character2Picture.BackColor = Color.White;
            character3Picture.BackColor = Color.White;
            character4Picture.BackColor = Color.White;
            basicAttackLabel.Text = "Atak Bazowy";
            skill1Label.Text = "";
            skill2Label.Text = "";
            skill1Label.MouseHover += SkillMouseHover;
            skill2Label.MouseHover += SkillMouseHover;
            basicAttackLabel.MouseHover += SkillMouseHover;

            character1Name.Text = characters[0].Name;
            character1Picture.Enabled = true;
            character1HealthText.Text = characters[0].CurrentHP + "/" + characters[0].MaxHP;
            character1Health.Maximum = characters[0].MaxHP;
            character1Health.Value = characters[0].CurrentHP;
            character1Picture.Click += Enemy_Click;

            character1Picture.Image = (Image)Properties.Resources.ResourceManager.GetObject(characters[0].CharacterType.ToString().ToLower() + "Picture");

            character2Name.Text = characters[1].Name;
            character2Picture.Enabled = true;
            character2HealthText.Text = characters[1].CurrentHP + "/" + characters[1].MaxHP;
            character2Health.Maximum = characters[1].MaxHP;
            character2Health.Value = characters[1].CurrentHP;
            character2Picture.Click += Enemy_Click;

            character2Picture.Image = (Image)Properties.Resources.ResourceManager.GetObject(characters[1].CharacterType.ToString().ToLower() + "Picture");

            character3Name.Text = characters[2].Name;
            character3Picture.Enabled = true;
            character3HealthText.Text = characters[2].CurrentHP + "/" + characters[2].MaxHP;
            character3Health.Maximum = characters[2].MaxHP;
            character3Health.Value = characters[2].CurrentHP;
            character3Picture.Click += Enemy_Click;

            character3Picture.Image = (Image)Properties.Resources.ResourceManager.GetObject(characters[2].CharacterType.ToString().ToLower() + "Picture");

            character4Name.Text = characters[3].Name;
            character4Picture.Enabled = true;
            character4HealthText.Text = characters[3].CurrentHP + "/" + characters[3].MaxHP;
            character4Health.Maximum = characters[3].MaxHP;
            character4Health.Value = characters[3].CurrentHP;
            character4Picture.Click += Enemy_Click;
            character4Picture.Image = (Image)Properties.Resources.ResourceManager.GetObject(characters[3].CharacterType.ToString().ToLower() + "Picture");


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
            if (enemy1Health.Value == 0)
            {
                enemy1Picture.Enabled = false;

                enemy1Picture.BackColor = Color.Black;
            }
            else
            {
                enemy1Picture.BackColor = Color.White;
            }
             if (enemy2Health.Value == 0)
            {
                enemy2Picture.Enabled = false;
                enemy2Picture.BackColor = Color.Black;
            }
            else
            {
                enemy2Picture.BackColor = Color.White;
            }
            
            if (enemy3Health.Value == 0)
            {
                enemy3Picture.Enabled = false;
                enemy3Picture.BackColor = Color.Black;
            }
            else
            {
                enemy3Picture.BackColor = Color.White;
            }
            
            if (enemy4Health.Value == 0)
            {
                enemy4Picture.Enabled = false;
                enemy4Picture.BackColor = Color.Black;
            }
            else
            {
                enemy4Picture.BackColor = Color.White;
            }

          
            if (character1Health.Value == 0)
            {
                character1Picture.Enabled = false;

                character1Picture.BackColor = Color.Black;
            }
            else
            {
                character1Picture.BackColor = Color.White;
            }


         
            if (character2Health.Value == 0)
            {
                character2Picture.Enabled = false;
                character2Picture.BackColor = Color.Black;
            }
            else
            {
                character2Picture.BackColor = Color.White;
            }


           
            if (character3Health.Value == 0)
            {
                character3Picture.Enabled = false;
                character3Picture.BackColor = Color.Black;
            }
            else
            {
                character3Picture.BackColor = Color.White;
            }


            if (character4Health.Value == 0)
            {
                character4Picture.Enabled = false;
                character4Picture.BackColor = Color.Black;
            }
            else
            {
                character4Picture.BackColor = Color.White;
            }
           

            var pictureBox = sender as PictureBox;

            if (pictureBox != null)
            {
                if (pictureBox.Name.Equals("enemy1Picture"))
                {
                    target.Clear();
                    target.Add(expedition.Monsters[0]); 
                    pictureBox.BackColor = Color.Red;
                }
                else if (pictureBox.Name.Equals("enemy2Picture"))
                {
                    target.Clear();
                    target.Add(expedition.Monsters[1]);
                    pictureBox.BackColor = Color.Red;
                }
                else if (pictureBox.Name.Equals("enemy3Picture"))
                {
                    target.Clear();
                    target.Add(expedition.Monsters[2]);
                    pictureBox.BackColor = Color.Red;
                }
                else if (pictureBox.Name.Equals("enemy4Picture"))
                {
                    target.Clear();
                    target.Add(expedition.Monsters[3]);
                    pictureBox.BackColor = Color.Red;
                }
                else if (pictureBox.Name.Equals("character1Picture"))
                {
                    target.Clear();
                    target.Add(characters[0]);
                    pictureBox.BackColor = Color.Green;
                }
                else if (pictureBox.Name.Equals("character2Picture"))
                {
                    target.Clear();
                    target.Add(characters[1]);
                    pictureBox.BackColor = Color.Green;
                }
                else if (pictureBox.Name.Equals("character3Picture"))
                {
                    target.Clear();
                    target.Add(characters[2]);
                    pictureBox.BackColor = Color.Green;
                }
                else if (pictureBox.Name.Equals("character4Picture"))
                {
                    target.Clear();
                    target.Add(characters[3]);
                    pictureBox.BackColor = Color.Green;
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