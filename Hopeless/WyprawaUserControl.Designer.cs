namespace Hopeless
{
    partial class WyprawaUserControl
    {
        /// <summary> 
        /// Wymagana zmienna projektanta.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Wyczyść wszystkie używane zasoby.
        /// </summary>
        /// <param name="disposing">prawda, jeżeli zarządzane zasoby powinny zostać zlikwidowane; Fałsz w przeciwnym wypadku.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Kod wygenerowany przez Projektanta składników

        /// <summary> 
        /// Metoda wymagana do obsługi projektanta — nie należy modyfikować 
        /// jej zawartości w edytorze kodu.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(WyprawaUserControl));
            pictureBox1 = new PictureBox();
            jokerName = new Label();
            clericName = new Label();
            rogueName = new Label();
            knightName = new Label();
            enemy1Name = new Label();
            enemy2Name = new Label();
            enemy3Name = new Label();
            enemy4Name = new Label();
            winButton = new Button();
            loseButton = new Button();
            jokerHealth = new ProgressBar();
            clericHealth = new ProgressBar();
            rogueHealth = new ProgressBar();
            knightHealth = new ProgressBar();
            enemy1Health = new ProgressBar();
            enemy2Health = new ProgressBar();
            enemy3Health = new ProgressBar();
            enemy4Health = new ProgressBar();
            knightHealthText = new Label();
            rogueHealthText = new Label();
            clericHealthText = new Label();
            jokerHealthText = new Label();
            enemy1HealthText = new Label();
            enemy2HealthText = new Label();
            enemy3HealthText = new Label();
            enemy4HealthText = new Label();
            skill2Label = new Label();
            skill1Label = new Label();
            basicAttackLabel = new Label();
            toolTip = new ToolTip(components);
            logBattleBox = new TextBox();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // pictureBox1
            // 
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(0, -3);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(1372, 861);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 0;
            pictureBox1.TabStop = false;
            // 
            // jokerName
            // 
            jokerName.AutoSize = true;
            jokerName.Location = new Point(71, 741);
            jokerName.Name = "jokerName";
            jokerName.Size = new Size(36, 15);
            jokerName.TabIndex = 12;
            jokerName.Text = "Imie: ";
            // 
            // clericName
            // 
            clericName.AutoSize = true;
            clericName.Location = new Point(192, 741);
            clericName.Name = "clericName";
            clericName.Size = new Size(36, 15);
            clericName.TabIndex = 13;
            clericName.Text = "Imie: ";
            // 
            // rogueName
            // 
            rogueName.AutoSize = true;
            rogueName.Location = new Point(310, 741);
            rogueName.Name = "rogueName";
            rogueName.Size = new Size(36, 15);
            rogueName.TabIndex = 14;
            rogueName.Text = "Imie: ";
            // 
            // knightName
            // 
            knightName.AutoSize = true;
            knightName.Location = new Point(430, 741);
            knightName.Name = "knightName";
            knightName.Size = new Size(36, 15);
            knightName.TabIndex = 15;
            knightName.Text = "Imie: ";
            // 
            // enemy1Name
            // 
            enemy1Name.AutoSize = true;
            enemy1Name.Location = new Point(877, 741);
            enemy1Name.Name = "enemy1Name";
            enemy1Name.Size = new Size(36, 15);
            enemy1Name.TabIndex = 16;
            enemy1Name.Text = "Imie: ";
            // 
            // enemy2Name
            // 
            enemy2Name.AutoSize = true;
            enemy2Name.Location = new Point(994, 741);
            enemy2Name.Name = "enemy2Name";
            enemy2Name.Size = new Size(36, 15);
            enemy2Name.TabIndex = 17;
            enemy2Name.Text = "Imie: ";
            // 
            // enemy3Name
            // 
            enemy3Name.AutoSize = true;
            enemy3Name.Location = new Point(1124, 741);
            enemy3Name.Name = "enemy3Name";
            enemy3Name.Size = new Size(36, 15);
            enemy3Name.TabIndex = 18;
            enemy3Name.Text = "Imie: ";
            // 
            // enemy4Name
            // 
            enemy4Name.AutoSize = true;
            enemy4Name.Location = new Point(1253, 741);
            enemy4Name.Name = "enemy4Name";
            enemy4Name.Size = new Size(36, 15);
            enemy4Name.TabIndex = 19;
            enemy4Name.Text = "Imie: ";
            // 
            // winButton
            // 
            winButton.Location = new Point(718, 811);
            winButton.Name = "winButton";
            winButton.Size = new Size(109, 23);
            winButton.TabIndex = 20;
            winButton.Text = "Zwycięstwo";
            winButton.UseVisualStyleBackColor = true;
            winButton.Click += winButton_Click;
            // 
            // loseButton
            // 
            loseButton.Location = new Point(508, 811);
            loseButton.Name = "loseButton";
            loseButton.Size = new Size(109, 23);
            loseButton.TabIndex = 21;
            loseButton.Text = "Porażka";
            loseButton.UseVisualStyleBackColor = true;
            loseButton.Click += loseButton_Click;
            // 
            // jokerHealth
            // 
            jokerHealth.Location = new Point(38, 759);
            jokerHealth.Name = "jokerHealth";
            jokerHealth.Size = new Size(100, 23);
            jokerHealth.TabIndex = 22;
            // 
            // clericHealth
            // 
            clericHealth.Location = new Point(158, 759);
            clericHealth.Name = "clericHealth";
            clericHealth.Size = new Size(100, 23);
            clericHealth.TabIndex = 23;
            // 
            // rogueHealth
            // 
            rogueHealth.Location = new Point(274, 759);
            rogueHealth.Name = "rogueHealth";
            rogueHealth.Size = new Size(100, 23);
            rogueHealth.TabIndex = 24;
            // 
            // knightHealth
            // 
            knightHealth.Location = new Point(399, 759);
            knightHealth.Name = "knightHealth";
            knightHealth.Size = new Size(100, 23);
            knightHealth.TabIndex = 25;
            // 
            // enemy1Health
            // 
            enemy1Health.Location = new Point(841, 759);
            enemy1Health.Name = "enemy1Health";
            enemy1Health.Size = new Size(100, 23);
            enemy1Health.TabIndex = 26;
            // 
            // enemy2Health
            // 
            enemy2Health.Location = new Point(962, 759);
            enemy2Health.Name = "enemy2Health";
            enemy2Health.Size = new Size(100, 23);
            enemy2Health.TabIndex = 27;
            // 
            // enemy3Health
            // 
            enemy3Health.Location = new Point(1089, 759);
            enemy3Health.Name = "enemy3Health";
            enemy3Health.Size = new Size(100, 23);
            enemy3Health.TabIndex = 28;
            // 
            // enemy4Health
            // 
            enemy4Health.Location = new Point(1221, 759);
            enemy4Health.Name = "enemy4Health";
            enemy4Health.Size = new Size(100, 23);
            enemy4Health.TabIndex = 29;
            // 
            // knightHealthText
            // 
            knightHealthText.AutoSize = true;
            knightHealthText.BackColor = Color.Transparent;
            knightHealthText.Location = new Point(428, 785);
            knightHealthText.Name = "knightHealthText";
            knightHealthText.Size = new Size(38, 15);
            knightHealthText.TabIndex = 30;
            knightHealthText.Text = "label1";
            // 
            // rogueHealthText
            // 
            rogueHealthText.AutoSize = true;
            rogueHealthText.BackColor = Color.Transparent;
            rogueHealthText.Location = new Point(308, 785);
            rogueHealthText.Name = "rogueHealthText";
            rogueHealthText.Size = new Size(38, 15);
            rogueHealthText.TabIndex = 31;
            rogueHealthText.Text = "label1";
            // 
            // clericHealthText
            // 
            clericHealthText.AutoSize = true;
            clericHealthText.BackColor = Color.Transparent;
            clericHealthText.Location = new Point(190, 785);
            clericHealthText.Name = "clericHealthText";
            clericHealthText.Size = new Size(38, 15);
            clericHealthText.TabIndex = 32;
            clericHealthText.Text = "label1";
            // 
            // jokerHealthText
            // 
            jokerHealthText.AutoSize = true;
            jokerHealthText.BackColor = Color.Transparent;
            jokerHealthText.Location = new Point(71, 785);
            jokerHealthText.Name = "jokerHealthText";
            jokerHealthText.Size = new Size(38, 15);
            jokerHealthText.TabIndex = 33;
            jokerHealthText.Text = "label1";
            // 
            // enemy1HealthText
            // 
            enemy1HealthText.AutoSize = true;
            enemy1HealthText.BackColor = Color.Transparent;
            enemy1HealthText.Location = new Point(877, 785);
            enemy1HealthText.Name = "enemy1HealthText";
            enemy1HealthText.Size = new Size(38, 15);
            enemy1HealthText.TabIndex = 34;
            enemy1HealthText.Text = "label1";
            // 
            // enemy2HealthText
            // 
            enemy2HealthText.AutoSize = true;
            enemy2HealthText.BackColor = Color.Transparent;
            enemy2HealthText.Location = new Point(994, 785);
            enemy2HealthText.Name = "enemy2HealthText";
            enemy2HealthText.Size = new Size(38, 15);
            enemy2HealthText.TabIndex = 35;
            enemy2HealthText.Text = "label1";
            // 
            // enemy3HealthText
            // 
            enemy3HealthText.AutoSize = true;
            enemy3HealthText.BackColor = Color.Transparent;
            enemy3HealthText.Location = new Point(1122, 785);
            enemy3HealthText.Name = "enemy3HealthText";
            enemy3HealthText.Size = new Size(38, 15);
            enemy3HealthText.TabIndex = 36;
            enemy3HealthText.Text = "label1";
            // 
            // enemy4HealthText
            // 
            enemy4HealthText.AutoSize = true;
            enemy4HealthText.BackColor = Color.Transparent;
            enemy4HealthText.Location = new Point(1253, 785);
            enemy4HealthText.Name = "enemy4HealthText";
            enemy4HealthText.Size = new Size(38, 15);
            enemy4HealthText.TabIndex = 37;
            enemy4HealthText.Text = "label1";
            // 
            // skill2Label
            // 
            skill2Label.AutoSize = true;
            skill2Label.Location = new Point(38, 33);
            skill2Label.MinimumSize = new Size(80, 80);
            skill2Label.Name = "skill2Label";
            skill2Label.Size = new Size(80, 80);
            skill2Label.TabIndex = 38;
            skill2Label.Text = "label1";
            // 
            // skill1Label
            // 
            skill1Label.AutoSize = true;
            skill1Label.Location = new Point(158, 33);
            skill1Label.MinimumSize = new Size(80, 80);
            skill1Label.Name = "skill1Label";
            skill1Label.Size = new Size(80, 80);
            skill1Label.TabIndex = 39;
            skill1Label.Text = "label2";

            // 
            // basicAttackLabel
            // 
            basicAttackLabel.AutoSize = true;
            basicAttackLabel.Location = new Point(274, 33);
            basicAttackLabel.MinimumSize = new Size(80, 80);
            basicAttackLabel.Name = "basicAttackLabel";
            basicAttackLabel.Size = new Size(80, 80);
            basicAttackLabel.TabIndex = 40;
            basicAttackLabel.Text = "label3";
            // 
            // toolTip
            // 
            toolTip.AutomaticDelay = 200;
            toolTip.AutoPopDelay = 10000;
            toolTip.InitialDelay = 200;
            toolTip.ReshowDelay = 40;
            // 
            // logBattleBox
            // 
            logBattleBox.Enabled = false;
            logBattleBox.Location = new Point(557, 30);
            logBattleBox.MaximumSize = new Size(270, 160);
            logBattleBox.Multiline = true;
            logBattleBox.Name = "logBattleBox";
            logBattleBox.ScrollBars = ScrollBars.Vertical;
            logBattleBox.Size = new Size(270, 160);
            logBattleBox.TabIndex = 41;
            logBattleBox.TextAlign = HorizontalAlignment.Center;
            // 
            // WyprawaUserControl
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(logBattleBox);
            Controls.Add(basicAttackLabel);
            Controls.Add(skill1Label);
            Controls.Add(skill2Label);
            Controls.Add(enemy4HealthText);
            Controls.Add(enemy3HealthText);
            Controls.Add(enemy2HealthText);
            Controls.Add(enemy1HealthText);
            Controls.Add(jokerHealthText);
            Controls.Add(clericHealthText);
            Controls.Add(rogueHealthText);
            Controls.Add(knightHealthText);
            Controls.Add(enemy4Health);
            Controls.Add(enemy3Health);
            Controls.Add(enemy2Health);
            Controls.Add(enemy1Health);
            Controls.Add(knightHealth);
            Controls.Add(rogueHealth);
            Controls.Add(clericHealth);
            Controls.Add(jokerHealth);
            Controls.Add(loseButton);
            Controls.Add(winButton);
            Controls.Add(enemy4Name);
            Controls.Add(enemy3Name);
            Controls.Add(enemy2Name);
            Controls.Add(enemy1Name);
            Controls.Add(knightName);
            Controls.Add(rogueName);
            Controls.Add(clericName);
            Controls.Add(jokerName);
            Controls.Add(pictureBox1);
            Name = "WyprawaUserControl";
            Size = new Size(1424, 861);
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private PictureBox pictureBox1;
        private Label jokerName;
        private Label clericName;
        private Label rogueName;
        private Label knightName;
        private Label enemy1Name;
        private Label enemy2Name;
        private Label enemy3Name;
        private Label enemy4Name;
        private Button winButton;
        private Button loseButton;
        private ProgressBar jokerHealth;
        private ProgressBar clericHealth;
        private ProgressBar rogueHealth;
        private ProgressBar knightHealth;
        private ProgressBar enemy1Health;
        private ProgressBar enemy2Health;
        private ProgressBar enemy3Health;
        private ProgressBar enemy4Health;
        private Label knightHealthText;
        private Label rogueHealthText;
        private Label clericHealthText;
        private Label jokerHealthText;
        private Label enemy1HealthText;
        private Label enemy2HealthText;
        private Label enemy3HealthText;
        private Label enemy4HealthText;
        private Label skill2Label;
        private Label skill1Label;
        private Label basicAttackLabel;
        private ToolTip toolTip;
        private TextBox logBattleBox;
    }
}
