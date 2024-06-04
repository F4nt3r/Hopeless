using HopelessLibary;
using HopelessLibary.Enums;
using HopelessLibary.Intefrace;
using NAudio.Wave;
using System.Data;
using System.Diagnostics.Eventing.Reader;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TextBox;

namespace Hopeless
{
    public partial class ExpeditionUserControl : UserControl
    {
        public List<Character> Characters { get; set; }
        public Expedition Expedition { get; set; }


        private List<ICreature> fightOrder = new();
        private List<ICreature> target = new();
        public delegate void CustomDelegate(bool result, Expedition expedition);
        public event CustomDelegate EventFirst;
        public event EventHandler FinishButtonClicked;
        public event EventHandler EventChoice;
        public bool EventResult;
        private bool playerActionTaken = false;
        public List<PictureBox> pictureBoxes = new();
        public ExpeditionUserControl()
        {
            InitializeComponent();
            pictureBox1.Image = Properties.Resources.Wyprawa;
            this.VisibleChanged += ExpeditionUserControl_VisibleChanged;

        }

        private void ExpeditionUserControl_VisibleChanged(object? sender, EventArgs e)
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
                int turn = 0;
                while (fightStatus)
                {
                    turn++;
                    turaLabel.Text = "Turn: " + turn;
                    foreach (var figure in fightOrder)
                    {
                        target.Clear();
                        activeCharacterLabel.Text = "Active Character:" + figure.Name;
                        playerActionTaken = false;
                        if (figure.CharacterType != CharacterType.Monster && !figure.IsDead())
                        {
                            skill1Label.Enabled = true;
                            skill2Label.Enabled = true;
                            basicAttackLabel.Enabled = true;

                            if (figure.Skill1 != null)
                            {
                                skill1Label.Text = figure.Skill1.Name;
                                if (figure.Skill1.Cooldown > 0)
                                    skill1Label.Text += Environment.NewLine + "Cooldown: " + figure.Skill1.Cooldown + " turns";
                            }
                            if (figure.Skill2 != null)
                            {
                                skill2Label.Text = figure.Skill2.Name;
                                if (figure.Skill2.Cooldown > 0)
                                    skill2Label.Text += Environment.NewLine + "Cooldown: " + figure.Skill2.Cooldown + " turns";
                            }

                            skill1Label.AccessibleDescription = figure.Skill1?.Description;
                            skill2Label.AccessibleDescription = figure.Skill2?.Description;
                            basicAttackLabel.AccessibleDescription = figure.BasicAttackDescription;

                            EventHandler skillClick1 = (s, e) =>
                            {
                                SkillHandlerResponse response;
                                if (figure.Skill1.SkillType == SkillType.AoE)
                                {
                                    response = figure.Skill1?
                                    .SkillHandler
                                    .Invoke(figure, fightOrder);

                                 
                                }
                                else
                                {
                                    if (target != null && figure.Skill1.TargetType == TargetType.Enemy && target.Any(x => x.CharacterType == CharacterType.Monster))
                                    {
                                        response = figure.Skill1?
                                    .SkillHandler
                                    .Invoke(figure, target);

                                    }
                                    else if (target != null && figure.Skill1.TargetType == TargetType.Ally && target.Any(x => x.CharacterType != CharacterType.Monster))
                                    {
                                        response = figure.Skill1?
                                         .SkillHandler
                                         .Invoke(figure, target);
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
                                    MessageBox.Show("You can't use it right now, wait: " + response.cd + " turns", "Cooldown Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    playerActionTaken = false;
                                    return;
                                }
                                logBattleBox.Text = figure.Name + response.logText + logBattleBox.Text;
                                playerActionTaken = true;

                            };
                            EventHandler skillClick2 = (s, e) =>
                            {
                                SkillHandlerResponse response;
                                if (figure.Skill2.SkillType == SkillType.AoE)
                                {
                                    response = figure.Skill2?
                                    .SkillHandler
                                    .Invoke(figure, fightOrder);
                                }
                                else
                                {
                                    if (target[0] != null && figure.Skill2.TargetType == TargetType.Enemy && target[0].CharacterType == CharacterType.Monster)
                                    {
                                        response = figure.Skill2?
                                    .SkillHandler
                                    .Invoke(figure, target);
                                    }
                                    else if (target[0] != null && figure.Skill2.TargetType == TargetType.Ally && target[0].CharacterType != CharacterType.Monster)
                                    {
                                        response = figure.Skill2?
                                         .SkillHandler
                                         .Invoke(figure, target);
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
                                    MessageBox.Show("You can't use it right now, wait: " + response.cd + " turns", "Cooldown Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    playerActionTaken = false;
                                    return;
                                }
                                logBattleBox.Text = figure.Name + response.logText + logBattleBox.Text;
                                playerActionTaken = true;

                            };
                            EventHandler handlerBassicAttack = async (s, e) =>
                            {
                                if (target.Count != 0)
                                {
                                    int hp = target[0].CurrentHP;
                                    figure.BasicAttack(target[0], out int dmg);



                                    PlayBasicAttackSound();


                                    playerActionTaken = true;
                                    if (target[0].CurrentHP != hp) { 
                                    logBattleBox.Text = figure.Name + " attacks " + target[0].Name + " deals: " + (hp - target[0].CurrentHP) + " damage" + Environment.NewLine + logBattleBox.Text;
                                    PictureBox targetPictureBox = pictureBoxes.FirstOrDefault(p => p.Location == target[0].Location);
                                    if (targetPictureBox != null)
                                    {
                                        await ShakeAnimation(targetPictureBox);
                                    }
                                    }
                                else
                                    logBattleBox.Text = figure.Name + " attacks " + target[0].Name + " but he dodge" + Environment.NewLine + logBattleBox.Text;

                                 
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

                            figure.CheckSkillsCd();
                        }
                        else
                        {
                            if (!figure.IsDead())
                            {
                                await Task.Delay(1000);

                                do
                                {
                                    target.Clear();

                                    if (figure.DeBuffs != null && figure.DeBuffs.Count > 0)
                                    {
                                        var debuff = figure.DeBuffs.FirstOrDefault(x => x.Name.Equals("Provoke"));
                                        if (debuff != null)
                                        {
                                            target.Add(Characters.FirstOrDefault(x => x.Id == debuff.Caster.Id));
                                        }
                                        else
                                        {
                                            int i = new Random().Next(0, 4);
                                            target.Add(Characters[i]);
                                        }


                                    }
                                    else
                                    {
                                        int i = new Random().Next(0, 4);
                                        target.Add(Characters[i]);
                                    }

                                } while (target[0].IsDead());
                                int hp = target[0].CurrentHP;

                                figure.BasicAttack(target[0], out int dmg);
                                PlayBasicAttackSound();
                               
                                if (target[0].CurrentHP != hp)
                                {                          
                                    logBattleBox.Text = figure.Name + " attacks " + target[0].Name + " deals:" + (hp - target[0].CurrentHP) + " damage" + Environment.NewLine + logBattleBox.Text;
                                    PictureBox targetPictureBox = pictureBoxes.FirstOrDefault(p => p.Location == target[0].Location);
                                    if (targetPictureBox != null)
                                    {
                                        await ShakeAnimation(targetPictureBox);
                                    }
                                }
                                else if (target[0].CurrentHP == hp && target is Rogue)
                                    logBattleBox.Text = figure.Name + " attacks " + target[0].Name + " but he dodge" + Environment.NewLine + logBattleBox.Text;
                                else
                                    logBattleBox.Text = figure.Name + " attacks " + target[0].Name + " but he blocked" + Environment.NewLine + logBattleBox.Text;

                               

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
     

        private async Task ShakeAnimation(PictureBox picture)
        {
            var originalLocation = picture.Location;
            Random random = new Random();
            int shakeAmplitude = 4;
            int shakeDuration = 500; 
            int shakeCount = 20;

            for (int i = 0; i < shakeCount; i++)
            {
                int offsetX = random.Next(-shakeAmplitude, shakeAmplitude);
                int offsetY = random.Next(-shakeAmplitude, shakeAmplitude);
                picture.Location = new Point(originalLocation.X + offsetX, originalLocation.Y + offsetY);
                await Task.Delay(shakeDuration / shakeCount);
            }

            picture.Location = originalLocation;
        }




        private void RefreshEffectBox()
        {
            effectBox.Clear();
            effectBox.Text += "Active Statuses:" + Environment.NewLine;
            foreach (var item in fightOrder)
            {

                Dictionary<string, int> buffCount = new Dictionary<string, int>();
                Dictionary<string, int> debuffCount = new Dictionary<string, int>();

                if (item.Buffs != null)
                {
                    foreach (Buff buff in item.Buffs)
                    {

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


                foreach (var kvp in buffCount)
                {
                    if (kvp.Value > 1)
                        effectBox.Text += item.Name + "|" + kvp.Key + " x" + kvp.Value + "|" + GetBuffUptime(item.Buffs, kvp.Key) + Environment.NewLine;
                    else
                        effectBox.Text += item.Name + "|" + kvp.Key + "|" + GetBuffUptime(item.Buffs, kvp.Key) + Environment.NewLine;
                }

                foreach (var kvp in debuffCount)
                {
                    if (kvp.Value > 1)
                        effectBox.Text += item.Name + "|" + kvp.Key + " x" + kvp.Value + "|" + GetDeBuffUptime(item.DeBuffs, kvp.Key) + Environment.NewLine;
                    else
                        effectBox.Text += item.Name + "|" + kvp.Key + "|" + GetDeBuffUptime(item.DeBuffs, kvp.Key) + Environment.NewLine;

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
            enemy1Health.Value = Expedition.Monsters[0].CurrentHP;
            enemy1HealthText.Text = Expedition.Monsters[0].CurrentHP + "/" + Expedition.Monsters[0].MaxHP;
            if (enemy1Health.Value == 0)
            {
                enemy1Picture.Enabled = false;

                enemy1Picture.BackColor = Color.Black;
            }
            else
            {
                enemy1Picture.BackColor = Color.White;
            }
            enemy2Health.Value = Expedition.Monsters[1].CurrentHP;
            enemy2HealthText.Text = Expedition.Monsters[1].CurrentHP + "/" + Expedition.Monsters[1].MaxHP;
            if (enemy2Health.Value == 0)
            {
                enemy2Picture.Enabled = false;
                enemy2Picture.BackColor = Color.Black;
            }
            else
            {
                enemy2Picture.BackColor = Color.White;
            }
            enemy3Health.Value = Expedition.Monsters[2].CurrentHP;
            enemy3HealthText.Text = Expedition.Monsters[2].CurrentHP + "/" + Expedition.Monsters[2].MaxHP;
            if (enemy3Health.Value == 0)
            {
                enemy3Picture.Enabled = false;
                enemy3Picture.BackColor = Color.Black;
            }
            else
            {
                enemy3Picture.BackColor = Color.White;
            }
            enemy4Health.Value = Expedition.Monsters[3].CurrentHP;
            enemy4HealthText.Text = Expedition.Monsters[3].CurrentHP + "/" + Expedition.Monsters[3].MaxHP;
            if (enemy4Health.Value == 0)
            {
                enemy4Picture.Enabled = false;
                enemy4Picture.BackColor = Color.Black;
            }
            else
            {
                enemy4Picture.BackColor = Color.White;
            }

            character1HealthText.Text = Characters[0].CurrentHP + "/" + Characters[0].MaxHP;
            character1Health.Value = Characters[0].CurrentHP;
            if (character1Health.Value == 0)
            {
                character1Picture.Enabled = false;

                character1Picture.BackColor = Color.Black;
            }
            else
            {
                character1Picture.BackColor = Color.White;
            }


            character2HealthText.Text = Characters[1].CurrentHP + "/" + Characters[1].MaxHP;
            character2Health.Value = Characters[1].CurrentHP;
            if (character2Health.Value == 0)
            {
                character2Picture.Enabled = false;
                character2Picture.BackColor = Color.Black;
            }
            else
            {
                character2Picture.BackColor = Color.White;
            }


            character3HealthText.Text = Characters[2].CurrentHP + "/" + Characters[2].MaxHP;
            character3Health.Value = Characters[2].CurrentHP;
            if (character3Health.Value == 0)
            {
                character3Picture.Enabled = false;
                character3Picture.BackColor = Color.Black;
            }
            else
            {
                character3Picture.BackColor = Color.White;
            }


            character4HealthText.Text = Characters[3].CurrentHP + "/" + Characters[3].MaxHP;
            character4Health.Value = Characters[3].CurrentHP;
            if (character4Health.Value == 0)
            {
                character4Picture.Enabled = false;
                character4Picture.BackColor = Color.Black;
            }
            else
            {
                character4Picture.BackColor = Color.White;
            }





            if (Expedition.Monsters.All(monster => monster.IsDead()))
            {
                PlayWinSound();

                if (Expedition.Type == DifficultyType.Event)
                {



                    DialogResult result = MessageBox.Show("You defeated Gaunter'O Dim, Amazing!!! Are You Going to Exile Him?", "Make Your Decisions", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                    if (result == DialogResult.Yes)
                    {
                        PlayEventKillSound();
                        Expedition.Gold += 150;

                    }
                    else
                    {
                        EventChoice?.Invoke(this, EventArgs.Empty);
                        PlayEventSaveSound();

                    }


                }

                InitializeAfterFight();


                MessageBox.Show("Win!", "Return to Base", MessageBoxButtons.OK, MessageBoxIcon.Question);
                EventFirst?.Invoke(true, Expedition);
                FinishButtonClicked?.Invoke(this, EventArgs.Empty);
                return true;


            }
            if (Characters.All(character => character.IsDead()))
            {
                InitializeAfterFight();
                PlayLoseSound();
                MessageBox.Show("Lose!", "Return to Base", MessageBoxButtons.OK, MessageBoxIcon.Question);

                EventFirst?.Invoke(false, Expedition);
                FinishButtonClicked?.Invoke(this, EventArgs.Empty);
                return true;
            }
            return false;
        }
        private void InitializeAfterFight()
        {


            foreach (var item in fightOrder)
            {
                item.ClearEffetsAfterBattle();
                if (item.Skill1 != null)
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

            Characters[0].Location = character1Picture.Location;
            Characters[1].Location = character2Picture.Location;
            Characters[2].Location = character3Picture.Location;
            Characters[3].Location = character4Picture.Location;

            Expedition.Monsters[0].Location = enemy1Picture.Location;
            Expedition.Monsters[1].Location = enemy2Picture.Location;
            Expedition.Monsters[2].Location = enemy3Picture.Location;
            Expedition.Monsters[3].Location = enemy4Picture.Location;

            foreach (Control control in this.Controls)
            {
                if (control is PictureBox)
                {
                   pictureBoxes.Add(control as PictureBox);
                }

            }

            basicAttackLabel.Text = "Base Attack";
            skill1Label.Text = "";
            skill2Label.Text = "";
            skill1Label.MouseHover += SkillMouseHover;
            skill2Label.MouseHover += SkillMouseHover;
            basicAttackLabel.MouseHover += SkillMouseHover;

            character1Name.Text = Characters[0].Name;
            character1Picture.Enabled = true;
            character1HealthText.Text = Characters[0].CurrentHP + "/" + Characters[0].MaxHP;
            character1Health.Maximum = Characters[0].MaxHP;
            character1Health.Value = Characters[0].CurrentHP;
            character1Picture.Click += Enemy_Click;

            character1Picture.Image = (Image)Properties.Resources.ResourceManager.GetObject(Characters[0].CharacterType.ToString().ToLower() + "Picture");

            character2Name.Text = Characters[1].Name;
            character2Picture.Enabled = true;
            character2HealthText.Text = Characters[1].CurrentHP + "/" + Characters[1].MaxHP;
            character2Health.Maximum = Characters[1].MaxHP;
            character2Health.Value = Characters[1].CurrentHP;
            character2Picture.Click += Enemy_Click;

            character2Picture.Image = (Image)Properties.Resources.ResourceManager.GetObject(Characters[1].CharacterType.ToString().ToLower() + "Picture");

            character3Name.Text = Characters[2].Name;
            character3Picture.Enabled = true;
            character3HealthText.Text = Characters[2].CurrentHP + "/" + Characters[2].MaxHP;
            character3Health.Maximum = Characters[2].MaxHP;
            character3Health.Value = Characters[2].CurrentHP;
            character3Picture.Click += Enemy_Click;

            character3Picture.Image = (Image)Properties.Resources.ResourceManager.GetObject(Characters[2].CharacterType.ToString().ToLower() + "Picture");

            character4Name.Text = Characters[3].Name;
            character4Picture.Enabled = true;
            character4HealthText.Text = Characters[3].CurrentHP + "/" + Characters[3].MaxHP;
            character4Health.Maximum = Characters[3].MaxHP;
            character4Health.Value = Characters[3].CurrentHP;
            character4Picture.Click += Enemy_Click;
            character4Picture.Image = (Image)Properties.Resources.ResourceManager.GetObject(Characters[3].CharacterType.ToString().ToLower() + "Picture");


            enemy1Name.Text = Expedition.Monsters[0].Name;
            enemy1Picture.Enabled = true;
            enemy1HealthText.Text = Expedition.Monsters[0].CurrentHP + "/" + Expedition.Monsters[0].MaxHP;
            enemy1Health.Maximum = Expedition.Monsters[0].MaxHP;
            enemy1Health.Value = Expedition.Monsters[0].CurrentHP;
            enemy1Picture.Click += Enemy_Click;

            enemy1Picture.Image = (Image)Properties.Resources.ResourceManager.GetObject(Expedition.Monsters[0].Name);

            enemy2Name.Text = Expedition.Monsters[1].Name;
            enemy2Picture.Enabled = true;
            enemy2HealthText.Text = Expedition.Monsters[1].CurrentHP + "/" + Expedition.Monsters[1].MaxHP;
            enemy2Health.Maximum = Expedition.Monsters[1].MaxHP;
            enemy2Health.Value = Expedition.Monsters[1].CurrentHP;
            enemy2Picture.Click += Enemy_Click;

            enemy2Picture.Image = (Image)Properties.Resources.ResourceManager.GetObject(Expedition.Monsters[1].Name);

            enemy3Name.Text = Expedition.Monsters[2].Name;
            enemy3Picture.Enabled = true;
            enemy3HealthText.Text = Expedition.Monsters[2].CurrentHP + "/" + Expedition.Monsters[2].MaxHP;
            enemy3Health.Maximum = Expedition.Monsters[2].MaxHP;
            enemy3Health.Value = Expedition.Monsters[2].CurrentHP;
            enemy3Picture.Click += Enemy_Click;

            enemy3Picture.Image = (Image)Properties.Resources.ResourceManager.GetObject(Expedition.Monsters[2].Name);

            enemy4Name.Text = Expedition.Monsters[3].Name;
            enemy4Picture.Enabled = true;
            enemy4HealthText.Text = Expedition.Monsters[3].CurrentHP + "/" + Expedition.Monsters[3].MaxHP;
            enemy4Health.Maximum = Expedition.Monsters[3].MaxHP;
            enemy4Health.Value = Expedition.Monsters[3].CurrentHP;
            enemy4Picture.Click += Enemy_Click;

            enemy4Picture.Image = (Image)Properties.Resources.ResourceManager.GetObject(Expedition.Monsters[3].Name);




            //Kolejnosc Tur

            fightOrder.AddRange(Expedition.Monsters);
            fightOrder.AddRange(Characters);
            fightOrder = fightOrder.OrderByDescending(x => x.Initiative).ToList();

            startButton.Enabled = true;
            startButton.Visible = true;
            if (Expedition.Type == DifficultyType.Boss && EventResult)
            {
                PlayEventHelpSound();
                MessageBox.Show("Gaunter O'Dim came to return the favor from earlier!", "Settlement of Accounts", MessageBoxButtons.OK, MessageBoxIcon.Question);
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
                    target.Add(Expedition.Monsters[0]);
                    pictureBox.BackColor = Color.Red;
                }
                else if (pictureBox.Name.Equals("enemy2Picture"))
                {
                    target.Clear();
                    target.Add(Expedition.Monsters[1]);
                    pictureBox.BackColor = Color.Red;
                }
                else if (pictureBox.Name.Equals("enemy3Picture"))
                {
                    target.Clear();
                    target.Add(Expedition.Monsters[2]);
                    pictureBox.BackColor = Color.Red;
                }
                else if (pictureBox.Name.Equals("enemy4Picture"))
                {
                    target.Clear();
                    target.Add(Expedition.Monsters[3]);
                    pictureBox.BackColor = Color.Red;
                }
                else if (pictureBox.Name.Equals("character1Picture"))
                {
                    target.Clear();
                    target.Add(Characters[0]);
                    pictureBox.BackColor = Color.Green;
                }
                else if (pictureBox.Name.Equals("character2Picture"))
                {
                    target.Clear();
                    target.Add(Characters[1]);
                    pictureBox.BackColor = Color.Green;
                }
                else if (pictureBox.Name.Equals("character3Picture"))
                {
                    target.Clear();
                    target.Add(Characters[2]);
                    pictureBox.BackColor = Color.Green;
                }
                else if (pictureBox.Name.Equals("character4Picture"))
                {
                    target.Clear();
                    target.Add(Characters[3]);
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