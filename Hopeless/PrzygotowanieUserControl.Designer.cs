namespace Hopeless
{
    partial class PrzygotowanieUserControl
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
            pictureBox1 = new PictureBox();
            wyruszButton = new Button();
            tabControl3 = new TabControl();
            clericPostac = new TabPage();
            pictureBox2 = new PictureBox();
            clericStatystyki = new TabPage();
            clericDmg = new Label();
            clericName = new Label();
            clericInitiative = new Label();
            clericLevel = new Label();
            clericCrit = new Label();
            clericExp = new Label();
            clericResistance = new Label();
            clericStrength = new Label();
            clericHp = new Label();
            clericDexterity = new Label();
            clericIntelligence = new Label();
            clericEkwipunek = new TabPage();
            clericArmor = new Label();
            clericWeapon = new Label();
            tabControl5 = new TabControl();
            roguePostac = new TabPage();
            pictureBox4 = new PictureBox();
            rogueStatystyki = new TabPage();
            rogueDodge = new Label();
            rogueDmg = new Label();
            rogueInitiative = new Label();
            rogueCrit = new Label();
            rogueResistance = new Label();
            rogueHp = new Label();
            rogueIntelligence = new Label();
            rogueDexterity = new Label();
            rogueStrength = new Label();
            rogueExp = new Label();
            rogueLevel = new Label();
            rogueName = new Label();
            rogueEkwipunek = new TabPage();
            rogueArmor = new Label();
            rogueWeapon = new Label();
            tabControl1 = new TabControl();
            knightPostac = new TabPage();
            pictureBox3 = new PictureBox();
            knightStatystyki = new TabPage();
            knightBlock = new Label();
            knightDmg = new Label();
            knightInitiative = new Label();
            knightCrit = new Label();
            knightResistance = new Label();
            knightHp = new Label();
            knightIntelligence = new Label();
            knightDexterity = new Label();
            knightStrength = new Label();
            knightExp = new Label();
            knightLevel = new Label();
            knightName = new Label();
            knightEkwipunek = new TabPage();
            knightArmor = new Label();
            knightWeapon = new Label();
            tabControl2 = new TabControl();
            jokerPostac = new TabPage();
            pictureBox5 = new PictureBox();
            jokerStatystyki = new TabPage();
            jokerDmg = new Label();
            jokerName = new Label();
            jokerInitiative = new Label();
            jokerLevel = new Label();
            jokerCrit = new Label();
            jokerExp = new Label();
            jokerResistance = new Label();
            jokerStrength = new Label();
            jokerHp = new Label();
            jokerDexterity = new Label();
            jokerIntelligence = new Label();
            jokerEkwipunek = new TabPage();
            jokerArmor = new Label();
            jokerWeapon = new Label();
            Inventory = new FlowLayoutPanel();
            backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            goldLabel = new Label();
            toolTip1 = new ToolTip(components);
            Shop = new FlowLayoutPanel();
            Roll = new Button();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            tabControl3.SuspendLayout();
            clericPostac.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            clericStatystyki.SuspendLayout();
            clericEkwipunek.SuspendLayout();
            tabControl5.SuspendLayout();
            roguePostac.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox4).BeginInit();
            rogueStatystyki.SuspendLayout();
            rogueEkwipunek.SuspendLayout();
            tabControl1.SuspendLayout();
            knightPostac.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox3).BeginInit();
            knightStatystyki.SuspendLayout();
            knightEkwipunek.SuspendLayout();
            tabControl2.SuspendLayout();
            jokerPostac.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox5).BeginInit();
            jokerStatystyki.SuspendLayout();
            jokerEkwipunek.SuspendLayout();
            SuspendLayout();
            // 
            // pictureBox1
            // 
            pictureBox1.Location = new Point(0, 0);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(1382, 861);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 0;
            pictureBox1.TabStop = false;
            // 
            // wyruszButton
            // 
            wyruszButton.Location = new Point(1263, 800);
            wyruszButton.Name = "wyruszButton";
            wyruszButton.Size = new Size(150, 50);
            wyruszButton.TabIndex = 0;
            wyruszButton.Text = "Wyruszam";
            wyruszButton.UseVisualStyleBackColor = true;
            wyruszButton.Click += wyruszButton_Click;
            // 
            // tabControl3
            // 
            tabControl3.Controls.Add(clericPostac);
            tabControl3.Controls.Add(clericStatystyki);
            tabControl3.Controls.Add(clericEkwipunek);
            tabControl3.Location = new Point(640, 70);
            tabControl3.Name = "tabControl3";
            tabControl3.SelectedIndex = 0;
            tabControl3.Size = new Size(200, 336);
            tabControl3.TabIndex = 3;
            // 
            // clericPostac
            // 
            clericPostac.BackColor = Color.Transparent;
            clericPostac.Controls.Add(pictureBox2);
            clericPostac.Location = new Point(4, 24);
            clericPostac.Name = "clericPostac";
            clericPostac.Padding = new Padding(3);
            clericPostac.Size = new Size(192, 308);
            clericPostac.TabIndex = 0;
            clericPostac.Text = "Postac";
            // 
            // pictureBox2
            // 
            pictureBox2.Dock = DockStyle.Fill;
            pictureBox2.Location = new Point(3, 3);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new Size(186, 302);
            pictureBox2.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox2.TabIndex = 0;
            pictureBox2.TabStop = false;
            // 
            // clericStatystyki
            // 
            clericStatystyki.Controls.Add(clericDmg);
            clericStatystyki.Controls.Add(clericName);
            clericStatystyki.Controls.Add(clericInitiative);
            clericStatystyki.Controls.Add(clericLevel);
            clericStatystyki.Controls.Add(clericCrit);
            clericStatystyki.Controls.Add(clericExp);
            clericStatystyki.Controls.Add(clericResistance);
            clericStatystyki.Controls.Add(clericStrength);
            clericStatystyki.Controls.Add(clericHp);
            clericStatystyki.Controls.Add(clericDexterity);
            clericStatystyki.Controls.Add(clericIntelligence);
            clericStatystyki.Location = new Point(4, 24);
            clericStatystyki.Name = "clericStatystyki";
            clericStatystyki.Padding = new Padding(3);
            clericStatystyki.Size = new Size(192, 308);
            clericStatystyki.TabIndex = 1;
            clericStatystyki.Text = "Statystyki";
            clericStatystyki.UseVisualStyleBackColor = true;
            // 
            // clericDmg
            // 
            clericDmg.AutoSize = true;
            clericDmg.Location = new Point(6, 250);
            clericDmg.Name = "clericDmg";
            clericDmg.Size = new Size(103, 15);
            clericDmg.TabIndex = 32;
            clericDmg.Text = "Obrażenia Ataku:  ";
            // 
            // clericName
            // 
            clericName.AutoSize = true;
            clericName.Location = new Point(6, 3);
            clericName.Name = "clericName";
            clericName.Size = new Size(36, 15);
            clericName.TabIndex = 22;
            clericName.Text = "Imie: ";
            // 
            // clericInitiative
            // 
            clericInitiative.AutoSize = true;
            clericInitiative.Location = new Point(6, 224);
            clericInitiative.Name = "clericInitiative";
            clericInitiative.Size = new Size(69, 15);
            clericInitiative.TabIndex = 31;
            clericInitiative.Text = "Inicjatywa:  ";
            // 
            // clericLevel
            // 
            clericLevel.AutoSize = true;
            clericLevel.Location = new Point(6, 27);
            clericLevel.Name = "clericLevel";
            clericLevel.Size = new Size(40, 15);
            clericLevel.TabIndex = 23;
            clericLevel.Text = "Level: ";
            // 
            // clericCrit
            // 
            clericCrit.AutoSize = true;
            clericCrit.Location = new Point(6, 200);
            clericCrit.Name = "clericCrit";
            clericCrit.Size = new Size(97, 15);
            clericCrit.TabIndex = 30;
            clericCrit.Text = "Szansa na Kryta:  ";
            // 
            // clericExp
            // 
            clericExp.AutoSize = true;
            clericExp.Location = new Point(6, 52);
            clericExp.Name = "clericExp";
            clericExp.Size = new Size(73, 15);
            clericExp.TabIndex = 24;
            clericExp.Text = "Punkty EXP: ";
            // 
            // clericResistance
            // 
            clericResistance.AutoSize = true;
            clericResistance.Location = new Point(6, 175);
            clericResistance.Name = "clericResistance";
            clericResistance.Size = new Size(75, 15);
            clericResistance.TabIndex = 29;
            clericResistance.Text = "Odpornosc:  ";
            // 
            // clericStrength
            // 
            clericStrength.AutoSize = true;
            clericStrength.Location = new Point(8, 77);
            clericStrength.Name = "clericStrength";
            clericStrength.Size = new Size(31, 15);
            clericStrength.TabIndex = 25;
            clericStrength.Text = "Siła: ";
            // 
            // clericHp
            // 
            clericHp.AutoSize = true;
            clericHp.Location = new Point(6, 151);
            clericHp.Name = "clericHp";
            clericHp.Size = new Size(32, 15);
            clericHp.TabIndex = 28;
            clericHp.Text = "HP:  ";
            // 
            // clericDexterity
            // 
            clericDexterity.AutoSize = true;
            clericDexterity.Location = new Point(6, 102);
            clericDexterity.Name = "clericDexterity";
            clericDexterity.Size = new Size(66, 15);
            clericDexterity.TabIndex = 26;
            clericDexterity.Text = "Zrecznosc: ";
            // 
            // clericIntelligence
            // 
            clericIntelligence.AutoSize = true;
            clericIntelligence.Location = new Point(6, 126);
            clericIntelligence.Name = "clericIntelligence";
            clericIntelligence.Size = new Size(77, 15);
            clericIntelligence.TabIndex = 27;
            clericIntelligence.Text = "Inteligencja:  ";
            // 
            // clericEkwipunek
            // 
            clericEkwipunek.Controls.Add(clericArmor);
            clericEkwipunek.Controls.Add(clericWeapon);
            clericEkwipunek.Location = new Point(4, 24);
            clericEkwipunek.Name = "clericEkwipunek";
            clericEkwipunek.Padding = new Padding(3);
            clericEkwipunek.Size = new Size(192, 308);
            clericEkwipunek.TabIndex = 2;
            clericEkwipunek.Text = "Ekwipunek";
            clericEkwipunek.UseVisualStyleBackColor = true;
            // 
            // clericArmor
            // 
            clericArmor.Location = new Point(115, 51);
            clericArmor.MinimumSize = new Size(60, 60);
            clericArmor.Name = "clericArmor";
            clericArmor.Size = new Size(60, 60);
            clericArmor.TabIndex = 3;
            clericArmor.Text = "Armor";
            clericArmor.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // clericWeapon
            // 
            clericWeapon.AllowDrop = true;
            clericWeapon.Location = new Point(24, 51);
            clericWeapon.MinimumSize = new Size(60, 60);
            clericWeapon.Name = "clericWeapon";
            clericWeapon.Size = new Size(60, 60);
            clericWeapon.TabIndex = 2;
            clericWeapon.Text = "Bron";
            clericWeapon.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // tabControl5
            // 
            tabControl5.Controls.Add(roguePostac);
            tabControl5.Controls.Add(rogueStatystyki);
            tabControl5.Controls.Add(rogueEkwipunek);
            tabControl5.Location = new Point(353, 70);
            tabControl5.Name = "tabControl5";
            tabControl5.SelectedIndex = 0;
            tabControl5.Size = new Size(200, 336);
            tabControl5.TabIndex = 5;
            // 
            // roguePostac
            // 
            roguePostac.Controls.Add(pictureBox4);
            roguePostac.Location = new Point(4, 24);
            roguePostac.Name = "roguePostac";
            roguePostac.Padding = new Padding(3);
            roguePostac.Size = new Size(192, 308);
            roguePostac.TabIndex = 0;
            roguePostac.Text = "Postac";
            roguePostac.UseVisualStyleBackColor = true;
            // 
            // pictureBox4
            // 
            pictureBox4.Dock = DockStyle.Fill;
            pictureBox4.Location = new Point(3, 3);
            pictureBox4.Name = "pictureBox4";
            pictureBox4.Size = new Size(186, 302);
            pictureBox4.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox4.TabIndex = 0;
            pictureBox4.TabStop = false;
            // 
            // rogueStatystyki
            // 
            rogueStatystyki.Controls.Add(rogueDodge);
            rogueStatystyki.Controls.Add(rogueDmg);
            rogueStatystyki.Controls.Add(rogueInitiative);
            rogueStatystyki.Controls.Add(rogueCrit);
            rogueStatystyki.Controls.Add(rogueResistance);
            rogueStatystyki.Controls.Add(rogueHp);
            rogueStatystyki.Controls.Add(rogueIntelligence);
            rogueStatystyki.Controls.Add(rogueDexterity);
            rogueStatystyki.Controls.Add(rogueStrength);
            rogueStatystyki.Controls.Add(rogueExp);
            rogueStatystyki.Controls.Add(rogueLevel);
            rogueStatystyki.Controls.Add(rogueName);
            rogueStatystyki.Location = new Point(4, 24);
            rogueStatystyki.Name = "rogueStatystyki";
            rogueStatystyki.Padding = new Padding(3);
            rogueStatystyki.Size = new Size(192, 308);
            rogueStatystyki.TabIndex = 1;
            rogueStatystyki.Text = "Statystyki";
            rogueStatystyki.UseVisualStyleBackColor = true;
            // 
            // rogueDodge
            // 
            rogueDodge.AutoSize = true;
            rogueDodge.Location = new Point(6, 275);
            rogueDodge.Name = "rogueDodge";
            rogueDodge.Size = new Size(94, 15);
            rogueDodge.TabIndex = 22;
            rogueDodge.Text = "Szansa na Unik:  ";
            // 
            // rogueDmg
            // 
            rogueDmg.AutoSize = true;
            rogueDmg.Location = new Point(6, 250);
            rogueDmg.Name = "rogueDmg";
            rogueDmg.Size = new Size(103, 15);
            rogueDmg.TabIndex = 21;
            rogueDmg.Text = "Obrażenia Ataku:  ";
            // 
            // rogueInitiative
            // 
            rogueInitiative.AutoSize = true;
            rogueInitiative.Location = new Point(6, 224);
            rogueInitiative.Name = "rogueInitiative";
            rogueInitiative.Size = new Size(69, 15);
            rogueInitiative.TabIndex = 20;
            rogueInitiative.Text = "Inicjatywa:  ";
            // 
            // rogueCrit
            // 
            rogueCrit.AutoSize = true;
            rogueCrit.Location = new Point(6, 200);
            rogueCrit.Name = "rogueCrit";
            rogueCrit.Size = new Size(97, 15);
            rogueCrit.TabIndex = 19;
            rogueCrit.Text = "Szansa na Kryta:  ";
            // 
            // rogueResistance
            // 
            rogueResistance.AutoSize = true;
            rogueResistance.Location = new Point(6, 175);
            rogueResistance.Name = "rogueResistance";
            rogueResistance.Size = new Size(75, 15);
            rogueResistance.TabIndex = 18;
            rogueResistance.Text = "Odpornosc:  ";
            // 
            // rogueHp
            // 
            rogueHp.AutoSize = true;
            rogueHp.Location = new Point(6, 151);
            rogueHp.Name = "rogueHp";
            rogueHp.Size = new Size(32, 15);
            rogueHp.TabIndex = 17;
            rogueHp.Text = "HP:  ";
            // 
            // rogueIntelligence
            // 
            rogueIntelligence.AutoSize = true;
            rogueIntelligence.Location = new Point(6, 126);
            rogueIntelligence.Name = "rogueIntelligence";
            rogueIntelligence.Size = new Size(77, 15);
            rogueIntelligence.TabIndex = 16;
            rogueIntelligence.Text = "Inteligencja:  ";
            // 
            // rogueDexterity
            // 
            rogueDexterity.AutoSize = true;
            rogueDexterity.Location = new Point(6, 102);
            rogueDexterity.Name = "rogueDexterity";
            rogueDexterity.Size = new Size(66, 15);
            rogueDexterity.TabIndex = 15;
            rogueDexterity.Text = "Zrecznosc: ";
            // 
            // rogueStrength
            // 
            rogueStrength.AutoSize = true;
            rogueStrength.Location = new Point(8, 77);
            rogueStrength.Name = "rogueStrength";
            rogueStrength.Size = new Size(31, 15);
            rogueStrength.TabIndex = 14;
            rogueStrength.Text = "Siła: ";
            // 
            // rogueExp
            // 
            rogueExp.AutoSize = true;
            rogueExp.Location = new Point(6, 52);
            rogueExp.Name = "rogueExp";
            rogueExp.Size = new Size(73, 15);
            rogueExp.TabIndex = 13;
            rogueExp.Text = "Punkty EXP: ";
            // 
            // rogueLevel
            // 
            rogueLevel.AutoSize = true;
            rogueLevel.Location = new Point(6, 27);
            rogueLevel.Name = "rogueLevel";
            rogueLevel.Size = new Size(40, 15);
            rogueLevel.TabIndex = 12;
            rogueLevel.Text = "Level: ";
            // 
            // rogueName
            // 
            rogueName.AutoSize = true;
            rogueName.Location = new Point(6, 3);
            rogueName.Name = "rogueName";
            rogueName.Size = new Size(36, 15);
            rogueName.TabIndex = 11;
            rogueName.Text = "Imie: ";
            // 
            // rogueEkwipunek
            // 
            rogueEkwipunek.Controls.Add(rogueArmor);
            rogueEkwipunek.Controls.Add(rogueWeapon);
            rogueEkwipunek.Location = new Point(4, 24);
            rogueEkwipunek.Name = "rogueEkwipunek";
            rogueEkwipunek.Padding = new Padding(3);
            rogueEkwipunek.Size = new Size(192, 308);
            rogueEkwipunek.TabIndex = 2;
            rogueEkwipunek.Text = "Ekwipunek";
            rogueEkwipunek.UseVisualStyleBackColor = true;
            // 
            // rogueArmor
            // 
            rogueArmor.Location = new Point(112, 51);
            rogueArmor.MinimumSize = new Size(60, 60);
            rogueArmor.Name = "rogueArmor";
            rogueArmor.Size = new Size(60, 60);
            rogueArmor.TabIndex = 2;
            rogueArmor.Text = "Armor";
            rogueArmor.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // rogueWeapon
            // 
            rogueWeapon.AllowDrop = true;
            rogueWeapon.Location = new Point(16, 51);
            rogueWeapon.MinimumSize = new Size(60, 60);
            rogueWeapon.Name = "rogueWeapon";
            rogueWeapon.Size = new Size(60, 60);
            rogueWeapon.TabIndex = 1;
            rogueWeapon.Text = "Bron";
            rogueWeapon.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // tabControl1
            // 
            tabControl1.Controls.Add(knightPostac);
            tabControl1.Controls.Add(knightStatystyki);
            tabControl1.Controls.Add(knightEkwipunek);
            tabControl1.Location = new Point(67, 70);
            tabControl1.Name = "tabControl1";
            tabControl1.SelectedIndex = 0;
            tabControl1.Size = new Size(200, 336);
            tabControl1.TabIndex = 6;
            // 
            // knightPostac
            // 
            knightPostac.Controls.Add(pictureBox3);
            knightPostac.Location = new Point(4, 24);
            knightPostac.Name = "knightPostac";
            knightPostac.Padding = new Padding(3);
            knightPostac.Size = new Size(192, 308);
            knightPostac.TabIndex = 0;
            knightPostac.Text = "Postac";
            knightPostac.UseVisualStyleBackColor = true;
            // 
            // pictureBox3
            // 
            pictureBox3.Dock = DockStyle.Fill;
            pictureBox3.Location = new Point(3, 3);
            pictureBox3.Name = "pictureBox3";
            pictureBox3.Size = new Size(186, 302);
            pictureBox3.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox3.TabIndex = 0;
            pictureBox3.TabStop = false;
            // 
            // knightStatystyki
            // 
            knightStatystyki.Controls.Add(knightBlock);
            knightStatystyki.Controls.Add(knightDmg);
            knightStatystyki.Controls.Add(knightInitiative);
            knightStatystyki.Controls.Add(knightCrit);
            knightStatystyki.Controls.Add(knightResistance);
            knightStatystyki.Controls.Add(knightHp);
            knightStatystyki.Controls.Add(knightIntelligence);
            knightStatystyki.Controls.Add(knightDexterity);
            knightStatystyki.Controls.Add(knightStrength);
            knightStatystyki.Controls.Add(knightExp);
            knightStatystyki.Controls.Add(knightLevel);
            knightStatystyki.Controls.Add(knightName);
            knightStatystyki.Location = new Point(4, 24);
            knightStatystyki.Name = "knightStatystyki";
            knightStatystyki.Padding = new Padding(3);
            knightStatystyki.Size = new Size(192, 308);
            knightStatystyki.TabIndex = 1;
            knightStatystyki.Text = "Statystyki";
            knightStatystyki.UseVisualStyleBackColor = true;
            // 
            // knightBlock
            // 
            knightBlock.AutoSize = true;
            knightBlock.Location = new Point(8, 282);
            knightBlock.Name = "knightBlock";
            knightBlock.Size = new Size(90, 15);
            knightBlock.TabIndex = 11;
            knightBlock.Text = "Szansa na Blok: ";
            // 
            // knightDmg
            // 
            knightDmg.AutoSize = true;
            knightDmg.Location = new Point(6, 250);
            knightDmg.Name = "knightDmg";
            knightDmg.Size = new Size(103, 15);
            knightDmg.TabIndex = 10;
            knightDmg.Text = "Obrażenia Ataku:  ";
            // 
            // knightInitiative
            // 
            knightInitiative.AutoSize = true;
            knightInitiative.Location = new Point(6, 224);
            knightInitiative.Name = "knightInitiative";
            knightInitiative.Size = new Size(69, 15);
            knightInitiative.TabIndex = 9;
            knightInitiative.Text = "Inicjatywa:  ";
            // 
            // knightCrit
            // 
            knightCrit.AutoSize = true;
            knightCrit.Location = new Point(6, 200);
            knightCrit.Name = "knightCrit";
            knightCrit.Size = new Size(97, 15);
            knightCrit.TabIndex = 8;
            knightCrit.Text = "Szansa na Kryta:  ";
            // 
            // knightResistance
            // 
            knightResistance.AutoSize = true;
            knightResistance.Location = new Point(6, 175);
            knightResistance.Name = "knightResistance";
            knightResistance.Size = new Size(75, 15);
            knightResistance.TabIndex = 7;
            knightResistance.Text = "Odpornosc:  ";
            // 
            // knightHp
            // 
            knightHp.AutoSize = true;
            knightHp.Location = new Point(6, 151);
            knightHp.Name = "knightHp";
            knightHp.Size = new Size(32, 15);
            knightHp.TabIndex = 6;
            knightHp.Text = "HP:  ";
            // 
            // knightIntelligence
            // 
            knightIntelligence.AutoSize = true;
            knightIntelligence.Location = new Point(6, 126);
            knightIntelligence.Name = "knightIntelligence";
            knightIntelligence.Size = new Size(77, 15);
            knightIntelligence.TabIndex = 5;
            knightIntelligence.Text = "Inteligencja:  ";
            // 
            // knightDexterity
            // 
            knightDexterity.AutoSize = true;
            knightDexterity.Location = new Point(6, 102);
            knightDexterity.Name = "knightDexterity";
            knightDexterity.Size = new Size(66, 15);
            knightDexterity.TabIndex = 4;
            knightDexterity.Text = "Zrecznosc: ";
            // 
            // knightStrength
            // 
            knightStrength.AutoSize = true;
            knightStrength.Location = new Point(8, 77);
            knightStrength.Name = "knightStrength";
            knightStrength.Size = new Size(31, 15);
            knightStrength.TabIndex = 3;
            knightStrength.Text = "Siła: ";
            // 
            // knightExp
            // 
            knightExp.AutoSize = true;
            knightExp.Location = new Point(6, 52);
            knightExp.Name = "knightExp";
            knightExp.Size = new Size(73, 15);
            knightExp.TabIndex = 2;
            knightExp.Text = "Punkty EXP: ";
            // 
            // knightLevel
            // 
            knightLevel.AutoSize = true;
            knightLevel.Location = new Point(6, 27);
            knightLevel.Name = "knightLevel";
            knightLevel.Size = new Size(40, 15);
            knightLevel.TabIndex = 1;
            knightLevel.Text = "Level: ";
            // 
            // knightName
            // 
            knightName.AutoSize = true;
            knightName.Location = new Point(6, 3);
            knightName.Name = "knightName";
            knightName.Size = new Size(36, 15);
            knightName.TabIndex = 0;
            knightName.Text = "Imie: ";
            // 
            // knightEkwipunek
            // 
            knightEkwipunek.Controls.Add(knightArmor);
            knightEkwipunek.Controls.Add(knightWeapon);
            knightEkwipunek.Location = new Point(4, 24);
            knightEkwipunek.Name = "knightEkwipunek";
            knightEkwipunek.Padding = new Padding(3);
            knightEkwipunek.Size = new Size(192, 308);
            knightEkwipunek.TabIndex = 2;
            knightEkwipunek.Text = "Ekwipunek";
            knightEkwipunek.UseVisualStyleBackColor = true;
            // 
            // knightArmor
            // 
            knightArmor.Location = new Point(115, 51);
            knightArmor.MinimumSize = new Size(60, 60);
            knightArmor.Name = "knightArmor";
            knightArmor.Size = new Size(60, 60);
            knightArmor.TabIndex = 1;
            knightArmor.Text = "Armor";
            knightArmor.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // knightWeapon
            // 
            knightWeapon.AllowDrop = true;
            knightWeapon.Location = new Point(6, 51);
            knightWeapon.MinimumSize = new Size(60, 60);
            knightWeapon.Name = "knightWeapon";
            knightWeapon.Size = new Size(60, 60);
            knightWeapon.TabIndex = 0;
            knightWeapon.Text = "Bron";
            knightWeapon.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // tabControl2
            // 
            tabControl2.Controls.Add(jokerPostac);
            tabControl2.Controls.Add(jokerStatystyki);
            tabControl2.Controls.Add(jokerEkwipunek);
            tabControl2.Location = new Point(928, 70);
            tabControl2.Name = "tabControl2";
            tabControl2.SelectedIndex = 0;
            tabControl2.Size = new Size(200, 336);
            tabControl2.TabIndex = 7;
            // 
            // jokerPostac
            // 
            jokerPostac.Controls.Add(pictureBox5);
            jokerPostac.Location = new Point(4, 24);
            jokerPostac.Name = "jokerPostac";
            jokerPostac.Padding = new Padding(3);
            jokerPostac.Size = new Size(192, 308);
            jokerPostac.TabIndex = 0;
            jokerPostac.Text = "Postac";
            jokerPostac.UseVisualStyleBackColor = true;
            // 
            // pictureBox5
            // 
            pictureBox5.Dock = DockStyle.Fill;
            pictureBox5.Location = new Point(3, 3);
            pictureBox5.Name = "pictureBox5";
            pictureBox5.Size = new Size(186, 302);
            pictureBox5.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox5.TabIndex = 0;
            pictureBox5.TabStop = false;
            // 
            // jokerStatystyki
            // 
            jokerStatystyki.Controls.Add(jokerDmg);
            jokerStatystyki.Controls.Add(jokerName);
            jokerStatystyki.Controls.Add(jokerInitiative);
            jokerStatystyki.Controls.Add(jokerLevel);
            jokerStatystyki.Controls.Add(jokerCrit);
            jokerStatystyki.Controls.Add(jokerExp);
            jokerStatystyki.Controls.Add(jokerResistance);
            jokerStatystyki.Controls.Add(jokerStrength);
            jokerStatystyki.Controls.Add(jokerHp);
            jokerStatystyki.Controls.Add(jokerDexterity);
            jokerStatystyki.Controls.Add(jokerIntelligence);
            jokerStatystyki.Location = new Point(4, 24);
            jokerStatystyki.Name = "jokerStatystyki";
            jokerStatystyki.Padding = new Padding(3);
            jokerStatystyki.Size = new Size(192, 308);
            jokerStatystyki.TabIndex = 1;
            jokerStatystyki.Text = "Statystyki";
            jokerStatystyki.UseVisualStyleBackColor = true;
            // 
            // jokerDmg
            // 
            jokerDmg.AutoSize = true;
            jokerDmg.Location = new Point(3, 250);
            jokerDmg.Name = "jokerDmg";
            jokerDmg.Size = new Size(103, 15);
            jokerDmg.TabIndex = 43;
            jokerDmg.Text = "Obrażenia Ataku:  ";
            // 
            // jokerName
            // 
            jokerName.AutoSize = true;
            jokerName.Location = new Point(3, 3);
            jokerName.Name = "jokerName";
            jokerName.Size = new Size(36, 15);
            jokerName.TabIndex = 33;
            jokerName.Text = "Imie: ";
            // 
            // jokerInitiative
            // 
            jokerInitiative.AutoSize = true;
            jokerInitiative.Location = new Point(3, 224);
            jokerInitiative.Name = "jokerInitiative";
            jokerInitiative.Size = new Size(69, 15);
            jokerInitiative.TabIndex = 42;
            jokerInitiative.Text = "Inicjatywa:  ";
            // 
            // jokerLevel
            // 
            jokerLevel.AutoSize = true;
            jokerLevel.Location = new Point(3, 27);
            jokerLevel.Name = "jokerLevel";
            jokerLevel.Size = new Size(40, 15);
            jokerLevel.TabIndex = 34;
            jokerLevel.Text = "Level: ";
            // 
            // jokerCrit
            // 
            jokerCrit.AutoSize = true;
            jokerCrit.Location = new Point(3, 200);
            jokerCrit.Name = "jokerCrit";
            jokerCrit.Size = new Size(97, 15);
            jokerCrit.TabIndex = 41;
            jokerCrit.Text = "Szansa na Kryta:  ";
            // 
            // jokerExp
            // 
            jokerExp.AutoSize = true;
            jokerExp.Location = new Point(3, 52);
            jokerExp.Name = "jokerExp";
            jokerExp.Size = new Size(73, 15);
            jokerExp.TabIndex = 35;
            jokerExp.Text = "Punkty EXP: ";
            // 
            // jokerResistance
            // 
            jokerResistance.AutoSize = true;
            jokerResistance.Location = new Point(3, 175);
            jokerResistance.Name = "jokerResistance";
            jokerResistance.Size = new Size(75, 15);
            jokerResistance.TabIndex = 40;
            jokerResistance.Text = "Odpornosc:  ";
            // 
            // jokerStrength
            // 
            jokerStrength.AutoSize = true;
            jokerStrength.Location = new Point(5, 77);
            jokerStrength.Name = "jokerStrength";
            jokerStrength.Size = new Size(31, 15);
            jokerStrength.TabIndex = 36;
            jokerStrength.Text = "Siła: ";
            // 
            // jokerHp
            // 
            jokerHp.AutoSize = true;
            jokerHp.Location = new Point(3, 151);
            jokerHp.Name = "jokerHp";
            jokerHp.Size = new Size(32, 15);
            jokerHp.TabIndex = 39;
            jokerHp.Text = "HP:  ";
            // 
            // jokerDexterity
            // 
            jokerDexterity.AutoSize = true;
            jokerDexterity.Location = new Point(3, 102);
            jokerDexterity.Name = "jokerDexterity";
            jokerDexterity.Size = new Size(66, 15);
            jokerDexterity.TabIndex = 37;
            jokerDexterity.Text = "Zrecznosc: ";
            // 
            // jokerIntelligence
            // 
            jokerIntelligence.AutoSize = true;
            jokerIntelligence.Location = new Point(3, 126);
            jokerIntelligence.Name = "jokerIntelligence";
            jokerIntelligence.Size = new Size(77, 15);
            jokerIntelligence.TabIndex = 38;
            jokerIntelligence.Text = "Inteligencja:  ";
            // 
            // jokerEkwipunek
            // 
            jokerEkwipunek.Controls.Add(jokerArmor);
            jokerEkwipunek.Controls.Add(jokerWeapon);
            jokerEkwipunek.Location = new Point(4, 24);
            jokerEkwipunek.Name = "jokerEkwipunek";
            jokerEkwipunek.Padding = new Padding(3);
            jokerEkwipunek.Size = new Size(192, 308);
            jokerEkwipunek.TabIndex = 2;
            jokerEkwipunek.Text = "Ekwipunek";
            jokerEkwipunek.UseVisualStyleBackColor = true;
            // 
            // jokerArmor
            // 
            jokerArmor.Location = new Point(110, 51);
            jokerArmor.MinimumSize = new Size(60, 60);
            jokerArmor.Name = "jokerArmor";
            jokerArmor.Size = new Size(60, 60);
            jokerArmor.TabIndex = 4;
            jokerArmor.Text = "Armor";
            jokerArmor.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // jokerWeapon
            // 
            jokerWeapon.AllowDrop = true;
            jokerWeapon.Location = new Point(19, 51);
            jokerWeapon.MinimumSize = new Size(60, 60);
            jokerWeapon.Name = "jokerWeapon";
            jokerWeapon.Size = new Size(60, 60);
            jokerWeapon.TabIndex = 3;
            jokerWeapon.Text = "Bron";
            jokerWeapon.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // Inventory
            // 
            Inventory.AllowDrop = true;
            Inventory.Location = new Point(67, 578);
            Inventory.Name = "Inventory";
            Inventory.Size = new Size(320, 203);
            Inventory.TabIndex = 8;
            // 
            // goldLabel
            // 
            goldLabel.AutoSize = true;
            goldLabel.BackColor = Color.Gold;
            goldLabel.BorderStyle = BorderStyle.FixedSingle;
            goldLabel.Font = new Font("Segoe UI", 19F, FontStyle.Regular, GraphicsUnit.Point);
            goldLabel.Location = new Point(1184, 94);
            goldLabel.Name = "goldLabel";
            goldLabel.Size = new Size(84, 38);
            goldLabel.TabIndex = 23;
            goldLabel.Text = "Złoto:";
            // 
            // toolTip1
            // 
            toolTip1.AutomaticDelay = 200;
            toolTip1.AutoPopDelay = 10000;
            toolTip1.InitialDelay = 200;
            toolTip1.ReshowDelay = 40;
            // 
            // Shop
            // 
            Shop.AllowDrop = true;
            Shop.Location = new Point(1039, 526);
            Shop.Name = "Shop";
            Shop.Size = new Size(320, 203);
            Shop.TabIndex = 24;
            // 
            // Roll
            // 
            Roll.Location = new Point(1162, 735);
            Roll.Name = "Roll";
            Roll.Size = new Size(91, 23);
            Roll.TabIndex = 25;
            Roll.Text = "Roll 25 Golda";
            Roll.UseVisualStyleBackColor = true;
            Roll.Click += Roll_Click;
            // 
            // PrzygotowanieUserControl
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(Roll);
            Controls.Add(Shop);
            Controls.Add(goldLabel);
            Controls.Add(Inventory);
            Controls.Add(tabControl2);
            Controls.Add(tabControl1);
            Controls.Add(tabControl5);
            Controls.Add(tabControl3);
            Controls.Add(wyruszButton);
            Controls.Add(pictureBox1);
            Name = "PrzygotowanieUserControl";
            Size = new Size(1424, 861);
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            tabControl3.ResumeLayout(false);
            clericPostac.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            clericStatystyki.ResumeLayout(false);
            clericStatystyki.PerformLayout();
            clericEkwipunek.ResumeLayout(false);
            tabControl5.ResumeLayout(false);
            roguePostac.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pictureBox4).EndInit();
            rogueStatystyki.ResumeLayout(false);
            rogueStatystyki.PerformLayout();
            rogueEkwipunek.ResumeLayout(false);
            tabControl1.ResumeLayout(false);
            knightPostac.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pictureBox3).EndInit();
            knightStatystyki.ResumeLayout(false);
            knightStatystyki.PerformLayout();
            knightEkwipunek.ResumeLayout(false);
            tabControl2.ResumeLayout(false);
            jokerPostac.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pictureBox5).EndInit();
            jokerStatystyki.ResumeLayout(false);
            jokerStatystyki.PerformLayout();
            jokerEkwipunek.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private PictureBox pictureBox1;
        private Button wyruszButton;
        private TabControl tabControl3;
        private TabPage clericPostac;
        private TabPage clericStatystyki;
        private TabPage clericEkwipunek;
        private TabControl tabControl5;
        private TabPage roguePostac;
        private TabPage rogueStatystyki;
        private TabPage rogueEkwipunek;
        private TabControl tabControl1;
        private TabPage knightPostac;
        private TabPage knightStatystyki;
        private TabPage knightEkwipunek;
        private TabControl tabControl2;
        private TabPage jokerPostac;
        private TabPage jokerStatystyki;
        private TabPage jokerEkwipunek;
        private Label knightName;
        private Label knightInitiative;
        private Label knightCrit;
        private Label knightResistance;
        private Label knightHp;
        private Label knightIntelligence;
        private Label knightDexterity;
        private Label knightStrength;
        private Label knightExp;
        private Label knightLevel;
        private Label knightDmg;
        private Label clericDmg;
        private Label clericName;
        private Label clericInitiative;
        private Label clericLevel;
        private Label clericCrit;
        private Label clericExp;
        private Label clericResistance;
        private Label clericStrength;
        private Label clericHp;
        private Label clericDexterity;
        private Label clericIntelligence;
        private Label rogueDmg;
        private Label rogueInitiative;
        private Label rogueCrit;
        private Label rogueResistance;
        private Label rogueHp;
        private Label rogueIntelligence;
        private Label rogueDexterity;
        private Label rogueStrength;
        private Label rogueExp;
        private Label rogueLevel;
        private Label rogueName;
        private Label jokerDmg;
        private Label jokerName;
        private Label jokerInitiative;
        private Label jokerLevel;
        private Label jokerCrit;
        private Label jokerExp;
        private Label jokerResistance;
        private Label jokerStrength;
        private Label jokerHp;
        private Label jokerDexterity;
        private Label jokerIntelligence;
        private PictureBox pictureBox2;
        private PictureBox pictureBox4;
        private PictureBox pictureBox3;
        private PictureBox pictureBox5;
        private FlowLayoutPanel Inventory;
        private Label knightWeapon;
        private Label knightArmor;
        private Label knightBlock;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private Label rogueDodge;
        private Label rogueArmor;
        private Label rogueWeapon;
        private Label clericArmor;
        private Label clericWeapon;
        private Label jokerArmor;
        private Label jokerWeapon;
        private Label goldLabel;
        private ToolTip toolTip1;
        private FlowLayoutPanel Shop;
        private Button Roll;
    }
}
