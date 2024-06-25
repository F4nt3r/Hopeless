namespace Hopeless
{
    partial class PreparationUserControl
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
            character3Picture = new PictureBox();
            clericStatystyki = new TabPage();
            character3Block = new Label();
            character3Dmg = new Label();
            character3Name = new Label();
            character3Initiative = new Label();
            character3Level = new Label();
            character3Crit = new Label();
            character3Exp = new Label();
            character3Resistance = new Label();
            character3Strength = new Label();
            character3Hp = new Label();
            character3Dexterity = new Label();
            character3Intelligence = new Label();
            clericEkwipunek = new TabPage();
            character3ClassName = new Label();
            character3Armor = new Label();
            character3Weapon = new Label();
            tabControl5 = new TabControl();
            roguePostac = new TabPage();
            character2Picture = new PictureBox();
            rogueStatystyki = new TabPage();
            character2Block = new Label();
            character2Dmg = new Label();
            character2Initiative = new Label();
            character2Crit = new Label();
            character2Resistance = new Label();
            character2Hp = new Label();
            character2Intelligence = new Label();
            character2Dexterity = new Label();
            character2Strength = new Label();
            character2Exp = new Label();
            character2Level = new Label();
            character2Name = new Label();
            rogueEkwipunek = new TabPage();
            character2ClassName = new Label();
            character2Armor = new Label();
            character2Weapon = new Label();
            tabControl1 = new TabControl();
            knightPostac = new TabPage();
            character1Picture = new PictureBox();
            knightStatystyki = new TabPage();
            character1Block = new Label();
            character1Dmg = new Label();
            character1Initiative = new Label();
            character1Crit = new Label();
            character1Resistance = new Label();
            character1Hp = new Label();
            character1Intelligence = new Label();
            character1Dexterity = new Label();
            character1Strength = new Label();
            character1Exp = new Label();
            character1Level = new Label();
            character1Name = new Label();
            knightEkwipunek = new TabPage();
            character1ClassName = new Label();
            character1Armor = new Label();
            character1Weapon = new Label();
            tabControl2 = new TabControl();
            jokerPostac = new TabPage();
            character4Picture = new PictureBox();
            jokerStatystyki = new TabPage();
            character4Block = new Label();
            character4Dmg = new Label();
            character4Name = new Label();
            character4Initiative = new Label();
            character4Level = new Label();
            character4Crit = new Label();
            character4Exp = new Label();
            character4Resistance = new Label();
            character4Strength = new Label();
            character4Hp = new Label();
            character4Dexterity = new Label();
            character4Intelligence = new Label();
            jokerEkwipunek = new TabPage();
            character4ClassName = new Label();
            character4Armor = new Label();
            character4Weapon = new Label();
            Inventory = new FlowLayoutPanel();
            backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            goldLabel = new Label();
            toolTip1 = new ToolTip(components);
            Shop = new FlowLayoutPanel();
            Roll = new Button();
            backButton = new Button();
            SortKnight = new Button();
            SortRogue = new Button();
            SortCleric = new Button();
            SortJoker = new Button();
            SortAll = new Button();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            tabControl3.SuspendLayout();
            clericPostac.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)character3Picture).BeginInit();
            clericStatystyki.SuspendLayout();
            clericEkwipunek.SuspendLayout();
            tabControl5.SuspendLayout();
            roguePostac.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)character2Picture).BeginInit();
            rogueStatystyki.SuspendLayout();
            rogueEkwipunek.SuspendLayout();
            tabControl1.SuspendLayout();
            knightPostac.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)character1Picture).BeginInit();
            knightStatystyki.SuspendLayout();
            knightEkwipunek.SuspendLayout();
            tabControl2.SuspendLayout();
            jokerPostac.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)character4Picture).BeginInit();
            jokerStatystyki.SuspendLayout();
            jokerEkwipunek.SuspendLayout();
            SuspendLayout();
            // 
            // pictureBox1
            // 
            pictureBox1.Dock = DockStyle.Fill;
            pictureBox1.Location = new Point(0, 0);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(1350, 705);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 0;
            pictureBox1.TabStop = false;
            // 
            // wyruszButton
            // 
            wyruszButton.Anchor = AnchorStyles.None;
            wyruszButton.Location = new Point(1197, 652);
            wyruszButton.Name = "wyruszButton";
            wyruszButton.Size = new Size(150, 50);
            wyruszButton.TabIndex = 0;
            wyruszButton.Text = "Missions";
            wyruszButton.UseVisualStyleBackColor = true;
            wyruszButton.Click += wyruszButton_Click;
            // 
            // tabControl3
            // 
            tabControl3.Anchor = AnchorStyles.None;
            tabControl3.Controls.Add(clericPostac);
            tabControl3.Controls.Add(clericStatystyki);
            tabControl3.Controls.Add(clericEkwipunek);
            tabControl3.Location = new Point(738, 43);
            tabControl3.Name = "tabControl3";
            tabControl3.SelectedIndex = 0;
            tabControl3.Size = new Size(200, 336);
            tabControl3.TabIndex = 3;
            // 
            // clericPostac
            // 
            clericPostac.BackColor = Color.Transparent;
            clericPostac.Controls.Add(character3Picture);
            clericPostac.Location = new Point(4, 24);
            clericPostac.Name = "clericPostac";
            clericPostac.Padding = new Padding(3);
            clericPostac.Size = new Size(192, 308);
            clericPostac.TabIndex = 0;
            clericPostac.Text = "Character";
            // 
            // character3Picture
            // 
            character3Picture.BackColor = Color.LightCyan;
            character3Picture.Dock = DockStyle.Fill;
            character3Picture.Location = new Point(3, 3);
            character3Picture.Name = "character3Picture";
            character3Picture.Size = new Size(186, 302);
            character3Picture.SizeMode = PictureBoxSizeMode.StretchImage;
            character3Picture.TabIndex = 0;
            character3Picture.TabStop = false;
            // 
            // clericStatystyki
            // 
            clericStatystyki.BackColor = Color.LightCyan;
            clericStatystyki.Controls.Add(character3Block);
            clericStatystyki.Controls.Add(character3Dmg);
            clericStatystyki.Controls.Add(character3Name);
            clericStatystyki.Controls.Add(character3Initiative);
            clericStatystyki.Controls.Add(character3Level);
            clericStatystyki.Controls.Add(character3Crit);
            clericStatystyki.Controls.Add(character3Exp);
            clericStatystyki.Controls.Add(character3Resistance);
            clericStatystyki.Controls.Add(character3Strength);
            clericStatystyki.Controls.Add(character3Hp);
            clericStatystyki.Controls.Add(character3Dexterity);
            clericStatystyki.Controls.Add(character3Intelligence);
            clericStatystyki.Location = new Point(4, 24);
            clericStatystyki.Name = "clericStatystyki";
            clericStatystyki.Padding = new Padding(3);
            clericStatystyki.Size = new Size(192, 308);
            clericStatystyki.TabIndex = 1;
            clericStatystyki.Text = "Statistics";
            // 
            // character3Block
            // 
            character3Block.AutoSize = true;
            character3Block.Location = new Point(8, 275);
            character3Block.Name = "character3Block";
            character3Block.Size = new Size(10, 15);
            character3Block.TabIndex = 33;
            character3Block.Text = " ";
            // 
            // character3Dmg
            // 
            character3Dmg.AutoSize = true;
            character3Dmg.Location = new Point(6, 250);
            character3Dmg.Name = "character3Dmg";
            character3Dmg.Size = new Size(103, 15);
            character3Dmg.TabIndex = 32;
            character3Dmg.Text = "Obrażenia Ataku:  ";
            // 
            // character3Name
            // 
            character3Name.AutoSize = true;
            character3Name.Location = new Point(6, 3);
            character3Name.Name = "character3Name";
            character3Name.Size = new Size(36, 15);
            character3Name.TabIndex = 22;
            character3Name.Text = "Imie: ";
            // 
            // character3Initiative
            // 
            character3Initiative.AutoSize = true;
            character3Initiative.Location = new Point(6, 224);
            character3Initiative.Name = "character3Initiative";
            character3Initiative.Size = new Size(69, 15);
            character3Initiative.TabIndex = 31;
            character3Initiative.Text = "Inicjatywa:  ";
            // 
            // character3Level
            // 
            character3Level.AutoSize = true;
            character3Level.Location = new Point(6, 27);
            character3Level.Name = "character3Level";
            character3Level.Size = new Size(40, 15);
            character3Level.TabIndex = 23;
            character3Level.Text = "Level: ";
            // 
            // character3Crit
            // 
            character3Crit.AutoSize = true;
            character3Crit.Location = new Point(6, 200);
            character3Crit.Name = "character3Crit";
            character3Crit.Size = new Size(97, 15);
            character3Crit.TabIndex = 30;
            character3Crit.Text = "Szansa na Kryta:  ";
            // 
            // character3Exp
            // 
            character3Exp.AutoSize = true;
            character3Exp.Location = new Point(6, 52);
            character3Exp.Name = "character3Exp";
            character3Exp.Size = new Size(73, 15);
            character3Exp.TabIndex = 24;
            character3Exp.Text = "Punkty EXP: ";
            // 
            // character3Resistance
            // 
            character3Resistance.AutoSize = true;
            character3Resistance.Location = new Point(6, 175);
            character3Resistance.Name = "character3Resistance";
            character3Resistance.Size = new Size(75, 15);
            character3Resistance.TabIndex = 29;
            character3Resistance.Text = "Odpornosc:  ";
            // 
            // character3Strength
            // 
            character3Strength.AutoSize = true;
            character3Strength.Location = new Point(8, 77);
            character3Strength.Name = "character3Strength";
            character3Strength.Size = new Size(31, 15);
            character3Strength.TabIndex = 25;
            character3Strength.Text = "Siła: ";
            // 
            // character3Hp
            // 
            character3Hp.AutoSize = true;
            character3Hp.Location = new Point(6, 151);
            character3Hp.Name = "character3Hp";
            character3Hp.Size = new Size(32, 15);
            character3Hp.TabIndex = 28;
            character3Hp.Text = "HP:  ";
            // 
            // character3Dexterity
            // 
            character3Dexterity.AutoSize = true;
            character3Dexterity.Location = new Point(6, 102);
            character3Dexterity.Name = "character3Dexterity";
            character3Dexterity.Size = new Size(66, 15);
            character3Dexterity.TabIndex = 26;
            character3Dexterity.Text = "Zrecznosc: ";
            // 
            // character3Intelligence
            // 
            character3Intelligence.AutoSize = true;
            character3Intelligence.Location = new Point(6, 126);
            character3Intelligence.Name = "character3Intelligence";
            character3Intelligence.Size = new Size(77, 15);
            character3Intelligence.TabIndex = 27;
            character3Intelligence.Text = "Inteligencja:  ";
            // 
            // clericEkwipunek
            // 
            clericEkwipunek.BackColor = Color.LightCyan;
            clericEkwipunek.Controls.Add(character3ClassName);
            clericEkwipunek.Controls.Add(character3Armor);
            clericEkwipunek.Controls.Add(character3Weapon);
            clericEkwipunek.Location = new Point(4, 24);
            clericEkwipunek.Name = "clericEkwipunek";
            clericEkwipunek.Padding = new Padding(3);
            clericEkwipunek.Size = new Size(192, 308);
            clericEkwipunek.TabIndex = 2;
            clericEkwipunek.Text = "Inventory";
            // 
            // character3ClassName
            // 
            character3ClassName.AutoSize = true;
            character3ClassName.Location = new Point(73, 3);
            character3ClassName.Name = "character3ClassName";
            character3ClassName.Size = new Size(10, 15);
            character3ClassName.TabIndex = 4;
            character3ClassName.Text = " ";
            // 
            // character3Armor
            // 
            character3Armor.BorderStyle = BorderStyle.FixedSingle;
            character3Armor.Location = new Point(115, 51);
            character3Armor.MinimumSize = new Size(60, 60);
            character3Armor.Name = "character3Armor";
            character3Armor.Size = new Size(60, 60);
            character3Armor.TabIndex = 3;
            character3Armor.Text = "Armor";
            character3Armor.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // character3Weapon
            // 
            character3Weapon.AllowDrop = true;
            character3Weapon.BorderStyle = BorderStyle.FixedSingle;
            character3Weapon.Location = new Point(24, 51);
            character3Weapon.MinimumSize = new Size(60, 60);
            character3Weapon.Name = "character3Weapon";
            character3Weapon.Size = new Size(60, 60);
            character3Weapon.TabIndex = 2;
            character3Weapon.Text = "Bron";
            character3Weapon.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // tabControl5
            // 
            tabControl5.Anchor = AnchorStyles.None;
            tabControl5.Controls.Add(roguePostac);
            tabControl5.Controls.Add(rogueStatystyki);
            tabControl5.Controls.Add(rogueEkwipunek);
            tabControl5.Location = new Point(394, 43);
            tabControl5.Name = "tabControl5";
            tabControl5.SelectedIndex = 0;
            tabControl5.Size = new Size(200, 336);
            tabControl5.TabIndex = 5;
            // 
            // roguePostac
            // 
            roguePostac.Controls.Add(character2Picture);
            roguePostac.Location = new Point(4, 24);
            roguePostac.Name = "roguePostac";
            roguePostac.Padding = new Padding(3);
            roguePostac.Size = new Size(192, 308);
            roguePostac.TabIndex = 0;
            roguePostac.Text = "Character";
            roguePostac.UseVisualStyleBackColor = true;
            // 
            // character2Picture
            // 
            character2Picture.BackColor = Color.DarkGray;
            character2Picture.Dock = DockStyle.Fill;
            character2Picture.Location = new Point(3, 3);
            character2Picture.Name = "character2Picture";
            character2Picture.Size = new Size(186, 302);
            character2Picture.SizeMode = PictureBoxSizeMode.StretchImage;
            character2Picture.TabIndex = 0;
            character2Picture.TabStop = false;
            // 
            // rogueStatystyki
            // 
            rogueStatystyki.BackColor = Color.DarkGray;
            rogueStatystyki.Controls.Add(character2Block);
            rogueStatystyki.Controls.Add(character2Dmg);
            rogueStatystyki.Controls.Add(character2Initiative);
            rogueStatystyki.Controls.Add(character2Crit);
            rogueStatystyki.Controls.Add(character2Resistance);
            rogueStatystyki.Controls.Add(character2Hp);
            rogueStatystyki.Controls.Add(character2Intelligence);
            rogueStatystyki.Controls.Add(character2Dexterity);
            rogueStatystyki.Controls.Add(character2Strength);
            rogueStatystyki.Controls.Add(character2Exp);
            rogueStatystyki.Controls.Add(character2Level);
            rogueStatystyki.Controls.Add(character2Name);
            rogueStatystyki.Location = new Point(4, 24);
            rogueStatystyki.Name = "rogueStatystyki";
            rogueStatystyki.Padding = new Padding(3);
            rogueStatystyki.Size = new Size(192, 308);
            rogueStatystyki.TabIndex = 1;
            rogueStatystyki.Text = "Statistics";
            // 
            // character2Block
            // 
            character2Block.AutoSize = true;
            character2Block.Location = new Point(6, 275);
            character2Block.Name = "character2Block";
            character2Block.Size = new Size(10, 15);
            character2Block.TabIndex = 22;
            character2Block.Text = " ";
            // 
            // character2Dmg
            // 
            character2Dmg.AutoSize = true;
            character2Dmg.Location = new Point(6, 250);
            character2Dmg.Name = "character2Dmg";
            character2Dmg.Size = new Size(103, 15);
            character2Dmg.TabIndex = 21;
            character2Dmg.Text = "Obrażenia Ataku:  ";
            // 
            // character2Initiative
            // 
            character2Initiative.AutoSize = true;
            character2Initiative.Location = new Point(6, 224);
            character2Initiative.Name = "character2Initiative";
            character2Initiative.Size = new Size(69, 15);
            character2Initiative.TabIndex = 20;
            character2Initiative.Text = "Inicjatywa:  ";
            // 
            // character2Crit
            // 
            character2Crit.AutoSize = true;
            character2Crit.Location = new Point(6, 200);
            character2Crit.Name = "character2Crit";
            character2Crit.Size = new Size(97, 15);
            character2Crit.TabIndex = 19;
            character2Crit.Text = "Szansa na Kryta:  ";
            // 
            // character2Resistance
            // 
            character2Resistance.AutoSize = true;
            character2Resistance.Location = new Point(6, 175);
            character2Resistance.Name = "character2Resistance";
            character2Resistance.Size = new Size(75, 15);
            character2Resistance.TabIndex = 18;
            character2Resistance.Text = "Odpornosc:  ";
            // 
            // character2Hp
            // 
            character2Hp.AutoSize = true;
            character2Hp.Location = new Point(6, 151);
            character2Hp.Name = "character2Hp";
            character2Hp.Size = new Size(32, 15);
            character2Hp.TabIndex = 17;
            character2Hp.Text = "HP:  ";
            // 
            // character2Intelligence
            // 
            character2Intelligence.AutoSize = true;
            character2Intelligence.Location = new Point(6, 126);
            character2Intelligence.Name = "character2Intelligence";
            character2Intelligence.Size = new Size(77, 15);
            character2Intelligence.TabIndex = 16;
            character2Intelligence.Text = "Inteligencja:  ";
            // 
            // character2Dexterity
            // 
            character2Dexterity.AutoSize = true;
            character2Dexterity.Location = new Point(6, 102);
            character2Dexterity.Name = "character2Dexterity";
            character2Dexterity.Size = new Size(66, 15);
            character2Dexterity.TabIndex = 15;
            character2Dexterity.Text = "Zrecznosc: ";
            // 
            // character2Strength
            // 
            character2Strength.AutoSize = true;
            character2Strength.Location = new Point(8, 77);
            character2Strength.Name = "character2Strength";
            character2Strength.Size = new Size(31, 15);
            character2Strength.TabIndex = 14;
            character2Strength.Text = "Siła: ";
            // 
            // character2Exp
            // 
            character2Exp.AutoSize = true;
            character2Exp.Location = new Point(6, 52);
            character2Exp.Name = "character2Exp";
            character2Exp.Size = new Size(73, 15);
            character2Exp.TabIndex = 13;
            character2Exp.Text = "Punkty EXP: ";
            // 
            // character2Level
            // 
            character2Level.AutoSize = true;
            character2Level.Location = new Point(6, 27);
            character2Level.Name = "character2Level";
            character2Level.Size = new Size(40, 15);
            character2Level.TabIndex = 12;
            character2Level.Text = "Level: ";
            // 
            // character2Name
            // 
            character2Name.AutoSize = true;
            character2Name.Location = new Point(6, 3);
            character2Name.Name = "character2Name";
            character2Name.Size = new Size(36, 15);
            character2Name.TabIndex = 11;
            character2Name.Text = "Imie: ";
            // 
            // rogueEkwipunek
            // 
            rogueEkwipunek.BackColor = Color.DarkGray;
            rogueEkwipunek.Controls.Add(character2ClassName);
            rogueEkwipunek.Controls.Add(character2Armor);
            rogueEkwipunek.Controls.Add(character2Weapon);
            rogueEkwipunek.Location = new Point(4, 24);
            rogueEkwipunek.Name = "rogueEkwipunek";
            rogueEkwipunek.Padding = new Padding(3);
            rogueEkwipunek.Size = new Size(192, 308);
            rogueEkwipunek.TabIndex = 2;
            rogueEkwipunek.Text = "Inventory";
            // 
            // character2ClassName
            // 
            character2ClassName.AutoSize = true;
            character2ClassName.Location = new Point(73, 3);
            character2ClassName.Name = "character2ClassName";
            character2ClassName.Size = new Size(10, 15);
            character2ClassName.TabIndex = 3;
            character2ClassName.Text = " ";
            // 
            // character2Armor
            // 
            character2Armor.BorderStyle = BorderStyle.FixedSingle;
            character2Armor.Location = new Point(112, 51);
            character2Armor.MinimumSize = new Size(60, 60);
            character2Armor.Name = "character2Armor";
            character2Armor.Size = new Size(60, 60);
            character2Armor.TabIndex = 2;
            character2Armor.Text = "Armor";
            character2Armor.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // character2Weapon
            // 
            character2Weapon.AllowDrop = true;
            character2Weapon.BorderStyle = BorderStyle.FixedSingle;
            character2Weapon.Location = new Point(16, 51);
            character2Weapon.MinimumSize = new Size(60, 60);
            character2Weapon.Name = "character2Weapon";
            character2Weapon.Size = new Size(60, 60);
            character2Weapon.TabIndex = 1;
            character2Weapon.Text = "Bron";
            character2Weapon.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // tabControl1
            // 
            tabControl1.Anchor = AnchorStyles.None;
            tabControl1.Controls.Add(knightPostac);
            tabControl1.Controls.Add(knightStatystyki);
            tabControl1.Controls.Add(knightEkwipunek);
            tabControl1.Location = new Point(64, 43);
            tabControl1.Name = "tabControl1";
            tabControl1.SelectedIndex = 0;
            tabControl1.Size = new Size(200, 336);
            tabControl1.TabIndex = 6;
            // 
            // knightPostac
            // 
            knightPostac.Controls.Add(character1Picture);
            knightPostac.Location = new Point(4, 24);
            knightPostac.Name = "knightPostac";
            knightPostac.Padding = new Padding(3);
            knightPostac.Size = new Size(192, 308);
            knightPostac.TabIndex = 0;
            knightPostac.Text = "Character";
            knightPostac.UseVisualStyleBackColor = true;
            // 
            // character1Picture
            // 
            character1Picture.BackColor = Color.RosyBrown;
            character1Picture.Dock = DockStyle.Fill;
            character1Picture.Location = new Point(3, 3);
            character1Picture.Name = "character1Picture";
            character1Picture.Size = new Size(186, 302);
            character1Picture.SizeMode = PictureBoxSizeMode.StretchImage;
            character1Picture.TabIndex = 0;
            character1Picture.TabStop = false;
            // 
            // knightStatystyki
            // 
            knightStatystyki.BackColor = Color.RosyBrown;
            knightStatystyki.Controls.Add(character1Block);
            knightStatystyki.Controls.Add(character1Dmg);
            knightStatystyki.Controls.Add(character1Initiative);
            knightStatystyki.Controls.Add(character1Crit);
            knightStatystyki.Controls.Add(character1Resistance);
            knightStatystyki.Controls.Add(character1Hp);
            knightStatystyki.Controls.Add(character1Intelligence);
            knightStatystyki.Controls.Add(character1Dexterity);
            knightStatystyki.Controls.Add(character1Strength);
            knightStatystyki.Controls.Add(character1Exp);
            knightStatystyki.Controls.Add(character1Level);
            knightStatystyki.Controls.Add(character1Name);
            knightStatystyki.Location = new Point(4, 24);
            knightStatystyki.Name = "knightStatystyki";
            knightStatystyki.Padding = new Padding(3);
            knightStatystyki.Size = new Size(192, 308);
            knightStatystyki.TabIndex = 1;
            knightStatystyki.Text = "Statistics";
            // 
            // character1Block
            // 
            character1Block.AutoSize = true;
            character1Block.Location = new Point(8, 282);
            character1Block.Name = "character1Block";
            character1Block.Size = new Size(10, 15);
            character1Block.TabIndex = 11;
            character1Block.Text = " ";
            // 
            // character1Dmg
            // 
            character1Dmg.AutoSize = true;
            character1Dmg.Location = new Point(6, 250);
            character1Dmg.Name = "character1Dmg";
            character1Dmg.Size = new Size(103, 15);
            character1Dmg.TabIndex = 10;
            character1Dmg.Text = "Obrażenia Ataku:  ";
            // 
            // character1Initiative
            // 
            character1Initiative.AutoSize = true;
            character1Initiative.Location = new Point(6, 224);
            character1Initiative.Name = "character1Initiative";
            character1Initiative.Size = new Size(69, 15);
            character1Initiative.TabIndex = 9;
            character1Initiative.Text = "Inicjatywa:  ";
            // 
            // character1Crit
            // 
            character1Crit.AutoSize = true;
            character1Crit.Location = new Point(6, 200);
            character1Crit.Name = "character1Crit";
            character1Crit.Size = new Size(97, 15);
            character1Crit.TabIndex = 8;
            character1Crit.Text = "Szansa na Kryta:  ";
            // 
            // character1Resistance
            // 
            character1Resistance.AutoSize = true;
            character1Resistance.Location = new Point(6, 175);
            character1Resistance.Name = "character1Resistance";
            character1Resistance.Size = new Size(75, 15);
            character1Resistance.TabIndex = 7;
            character1Resistance.Text = "Odpornosc:  ";
            // 
            // character1Hp
            // 
            character1Hp.AutoSize = true;
            character1Hp.Location = new Point(6, 151);
            character1Hp.Name = "character1Hp";
            character1Hp.Size = new Size(32, 15);
            character1Hp.TabIndex = 6;
            character1Hp.Text = "HP:  ";
            // 
            // character1Intelligence
            // 
            character1Intelligence.AutoSize = true;
            character1Intelligence.Location = new Point(6, 126);
            character1Intelligence.Name = "character1Intelligence";
            character1Intelligence.Size = new Size(77, 15);
            character1Intelligence.TabIndex = 5;
            character1Intelligence.Text = "Inteligencja:  ";
            // 
            // character1Dexterity
            // 
            character1Dexterity.AutoSize = true;
            character1Dexterity.Location = new Point(6, 102);
            character1Dexterity.Name = "character1Dexterity";
            character1Dexterity.Size = new Size(66, 15);
            character1Dexterity.TabIndex = 4;
            character1Dexterity.Text = "Zrecznosc: ";
            // 
            // character1Strength
            // 
            character1Strength.AutoSize = true;
            character1Strength.Location = new Point(8, 77);
            character1Strength.Name = "character1Strength";
            character1Strength.Size = new Size(31, 15);
            character1Strength.TabIndex = 3;
            character1Strength.Text = "Siła: ";
            // 
            // character1Exp
            // 
            character1Exp.AutoSize = true;
            character1Exp.Location = new Point(6, 52);
            character1Exp.Name = "character1Exp";
            character1Exp.Size = new Size(73, 15);
            character1Exp.TabIndex = 2;
            character1Exp.Text = "Punkty EXP: ";
            // 
            // character1Level
            // 
            character1Level.AutoSize = true;
            character1Level.Location = new Point(6, 27);
            character1Level.Name = "character1Level";
            character1Level.Size = new Size(40, 15);
            character1Level.TabIndex = 1;
            character1Level.Text = "Level: ";
            // 
            // character1Name
            // 
            character1Name.AutoSize = true;
            character1Name.Location = new Point(6, 3);
            character1Name.Name = "character1Name";
            character1Name.Size = new Size(36, 15);
            character1Name.TabIndex = 0;
            character1Name.Text = "Imie: ";
            // 
            // knightEkwipunek
            // 
            knightEkwipunek.BackColor = Color.RosyBrown;
            knightEkwipunek.Controls.Add(character1ClassName);
            knightEkwipunek.Controls.Add(character1Armor);
            knightEkwipunek.Controls.Add(character1Weapon);
            knightEkwipunek.Location = new Point(4, 24);
            knightEkwipunek.Name = "knightEkwipunek";
            knightEkwipunek.Padding = new Padding(3);
            knightEkwipunek.Size = new Size(192, 308);
            knightEkwipunek.TabIndex = 2;
            knightEkwipunek.Text = "Inventory";
            // 
            // character1ClassName
            // 
            character1ClassName.AutoSize = true;
            character1ClassName.Location = new Point(68, 3);
            character1ClassName.Name = "character1ClassName";
            character1ClassName.Size = new Size(10, 15);
            character1ClassName.TabIndex = 2;
            character1ClassName.Text = " ";
            // 
            // character1Armor
            // 
            character1Armor.BorderStyle = BorderStyle.FixedSingle;
            character1Armor.Location = new Point(115, 51);
            character1Armor.MinimumSize = new Size(60, 60);
            character1Armor.Name = "character1Armor";
            character1Armor.Size = new Size(60, 60);
            character1Armor.TabIndex = 1;
            character1Armor.Text = "Armor";
            character1Armor.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // character1Weapon
            // 
            character1Weapon.AllowDrop = true;
            character1Weapon.BorderStyle = BorderStyle.FixedSingle;
            character1Weapon.Location = new Point(6, 51);
            character1Weapon.MinimumSize = new Size(60, 60);
            character1Weapon.Name = "character1Weapon";
            character1Weapon.Size = new Size(60, 60);
            character1Weapon.TabIndex = 0;
            character1Weapon.Text = "Bron";
            character1Weapon.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // tabControl2
            // 
            tabControl2.Anchor = AnchorStyles.None;
            tabControl2.Controls.Add(jokerPostac);
            tabControl2.Controls.Add(jokerStatystyki);
            tabControl2.Controls.Add(jokerEkwipunek);
            tabControl2.Location = new Point(1043, 43);
            tabControl2.Name = "tabControl2";
            tabControl2.SelectedIndex = 0;
            tabControl2.Size = new Size(200, 336);
            tabControl2.TabIndex = 7;
            // 
            // jokerPostac
            // 
            jokerPostac.Controls.Add(character4Picture);
            jokerPostac.Location = new Point(4, 24);
            jokerPostac.Name = "jokerPostac";
            jokerPostac.Padding = new Padding(3);
            jokerPostac.Size = new Size(192, 308);
            jokerPostac.TabIndex = 0;
            jokerPostac.Text = "Character";
            jokerPostac.UseVisualStyleBackColor = true;
            // 
            // character4Picture
            // 
            character4Picture.BackColor = Color.Beige;
            character4Picture.Dock = DockStyle.Fill;
            character4Picture.Location = new Point(3, 3);
            character4Picture.Name = "character4Picture";
            character4Picture.Size = new Size(186, 302);
            character4Picture.SizeMode = PictureBoxSizeMode.StretchImage;
            character4Picture.TabIndex = 0;
            character4Picture.TabStop = false;
            // 
            // jokerStatystyki
            // 
            jokerStatystyki.BackColor = Color.Beige;
            jokerStatystyki.Controls.Add(character4Block);
            jokerStatystyki.Controls.Add(character4Dmg);
            jokerStatystyki.Controls.Add(character4Name);
            jokerStatystyki.Controls.Add(character4Initiative);
            jokerStatystyki.Controls.Add(character4Level);
            jokerStatystyki.Controls.Add(character4Crit);
            jokerStatystyki.Controls.Add(character4Exp);
            jokerStatystyki.Controls.Add(character4Resistance);
            jokerStatystyki.Controls.Add(character4Strength);
            jokerStatystyki.Controls.Add(character4Hp);
            jokerStatystyki.Controls.Add(character4Dexterity);
            jokerStatystyki.Controls.Add(character4Intelligence);
            jokerStatystyki.Location = new Point(4, 24);
            jokerStatystyki.Name = "jokerStatystyki";
            jokerStatystyki.Padding = new Padding(3);
            jokerStatystyki.Size = new Size(192, 308);
            jokerStatystyki.TabIndex = 1;
            jokerStatystyki.Text = "Statistics";
            // 
            // character4Block
            // 
            character4Block.AutoSize = true;
            character4Block.Location = new Point(6, 275);
            character4Block.Name = "character4Block";
            character4Block.Size = new Size(10, 15);
            character4Block.TabIndex = 44;
            character4Block.Text = " ";
            // 
            // character4Dmg
            // 
            character4Dmg.AutoSize = true;
            character4Dmg.Location = new Point(3, 250);
            character4Dmg.Name = "character4Dmg";
            character4Dmg.Size = new Size(103, 15);
            character4Dmg.TabIndex = 43;
            character4Dmg.Text = "Obrażenia Ataku:  ";
            // 
            // character4Name
            // 
            character4Name.AutoSize = true;
            character4Name.Location = new Point(3, 3);
            character4Name.Name = "character4Name";
            character4Name.Size = new Size(36, 15);
            character4Name.TabIndex = 33;
            character4Name.Text = "Imie: ";
            // 
            // character4Initiative
            // 
            character4Initiative.AutoSize = true;
            character4Initiative.Location = new Point(3, 224);
            character4Initiative.Name = "character4Initiative";
            character4Initiative.Size = new Size(69, 15);
            character4Initiative.TabIndex = 42;
            character4Initiative.Text = "Inicjatywa:  ";
            // 
            // character4Level
            // 
            character4Level.AutoSize = true;
            character4Level.Location = new Point(3, 27);
            character4Level.Name = "character4Level";
            character4Level.Size = new Size(40, 15);
            character4Level.TabIndex = 34;
            character4Level.Text = "Level: ";
            // 
            // character4Crit
            // 
            character4Crit.AutoSize = true;
            character4Crit.Location = new Point(3, 200);
            character4Crit.Name = "character4Crit";
            character4Crit.Size = new Size(97, 15);
            character4Crit.TabIndex = 41;
            character4Crit.Text = "Szansa na Kryta:  ";
            // 
            // character4Exp
            // 
            character4Exp.AutoSize = true;
            character4Exp.Location = new Point(3, 52);
            character4Exp.Name = "character4Exp";
            character4Exp.Size = new Size(73, 15);
            character4Exp.TabIndex = 35;
            character4Exp.Text = "Punkty EXP: ";
            // 
            // character4Resistance
            // 
            character4Resistance.AutoSize = true;
            character4Resistance.Location = new Point(3, 175);
            character4Resistance.Name = "character4Resistance";
            character4Resistance.Size = new Size(75, 15);
            character4Resistance.TabIndex = 40;
            character4Resistance.Text = "Odpornosc:  ";
            // 
            // character4Strength
            // 
            character4Strength.AutoSize = true;
            character4Strength.Location = new Point(5, 77);
            character4Strength.Name = "character4Strength";
            character4Strength.Size = new Size(31, 15);
            character4Strength.TabIndex = 36;
            character4Strength.Text = "Siła: ";
            // 
            // character4Hp
            // 
            character4Hp.AutoSize = true;
            character4Hp.Location = new Point(3, 151);
            character4Hp.Name = "character4Hp";
            character4Hp.Size = new Size(32, 15);
            character4Hp.TabIndex = 39;
            character4Hp.Text = "HP:  ";
            // 
            // character4Dexterity
            // 
            character4Dexterity.AutoSize = true;
            character4Dexterity.Location = new Point(3, 102);
            character4Dexterity.Name = "character4Dexterity";
            character4Dexterity.Size = new Size(66, 15);
            character4Dexterity.TabIndex = 37;
            character4Dexterity.Text = "Zrecznosc: ";
            // 
            // character4Intelligence
            // 
            character4Intelligence.AutoSize = true;
            character4Intelligence.Location = new Point(3, 126);
            character4Intelligence.Name = "character4Intelligence";
            character4Intelligence.Size = new Size(77, 15);
            character4Intelligence.TabIndex = 38;
            character4Intelligence.Text = "Inteligencja:  ";
            // 
            // jokerEkwipunek
            // 
            jokerEkwipunek.BackColor = Color.Beige;
            jokerEkwipunek.Controls.Add(character4ClassName);
            jokerEkwipunek.Controls.Add(character4Armor);
            jokerEkwipunek.Controls.Add(character4Weapon);
            jokerEkwipunek.Location = new Point(4, 24);
            jokerEkwipunek.Name = "jokerEkwipunek";
            jokerEkwipunek.Padding = new Padding(3);
            jokerEkwipunek.Size = new Size(192, 308);
            jokerEkwipunek.TabIndex = 2;
            jokerEkwipunek.Text = "Inventory";
            // 
            // character4ClassName
            // 
            character4ClassName.AutoSize = true;
            character4ClassName.Location = new Point(71, 3);
            character4ClassName.Name = "character4ClassName";
            character4ClassName.Size = new Size(10, 15);
            character4ClassName.TabIndex = 5;
            character4ClassName.Text = " ";
            // 
            // character4Armor
            // 
            character4Armor.BorderStyle = BorderStyle.FixedSingle;
            character4Armor.Location = new Point(110, 51);
            character4Armor.MinimumSize = new Size(60, 60);
            character4Armor.Name = "character4Armor";
            character4Armor.Size = new Size(60, 60);
            character4Armor.TabIndex = 4;
            character4Armor.Text = "Armor";
            character4Armor.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // character4Weapon
            // 
            character4Weapon.AllowDrop = true;
            character4Weapon.BorderStyle = BorderStyle.FixedSingle;
            character4Weapon.Location = new Point(19, 51);
            character4Weapon.MinimumSize = new Size(60, 60);
            character4Weapon.Name = "character4Weapon";
            character4Weapon.Size = new Size(60, 60);
            character4Weapon.TabIndex = 3;
            character4Weapon.Text = "Bron";
            character4Weapon.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // Inventory
            // 
            Inventory.AllowDrop = true;
            Inventory.Anchor = AnchorStyles.None;
            Inventory.BackColor = Color.Bisque;
            Inventory.Location = new Point(209, 459);
            Inventory.Name = "Inventory";
            Inventory.Size = new Size(335, 205);
            Inventory.TabIndex = 8;
            // 
            // goldLabel
            // 
            goldLabel.AutoSize = true;
            goldLabel.BackColor = Color.Gold;
            goldLabel.BorderStyle = BorderStyle.FixedSingle;
            goldLabel.Font = new Font("Segoe UI", 19F, FontStyle.Regular, GraphicsUnit.Point);
            goldLabel.Location = new Point(1139, 459);
            goldLabel.Name = "goldLabel";
            goldLabel.Size = new Size(77, 38);
            goldLabel.TabIndex = 23;
            goldLabel.Text = "Gold:";
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
            Shop.Anchor = AnchorStyles.None;
            Shop.BackColor = Color.PeachPuff;
            Shop.Location = new Point(786, 459);
            Shop.Name = "Shop";
            Shop.Size = new Size(320, 203);
            Shop.TabIndex = 24;
            // 
            // Roll
            // 
            Roll.Anchor = AnchorStyles.None;
            Roll.Location = new Point(899, 668);
            Roll.Name = "Roll";
            Roll.Size = new Size(91, 23);
            Roll.TabIndex = 25;
            Roll.Text = "Roll 25 Golda";
            Roll.UseVisualStyleBackColor = true;
            Roll.Click += Roll_Click;
            // 
            // backButton
            // 
            backButton.Anchor = AnchorStyles.None;
            backButton.Location = new Point(3, 652);
            backButton.Name = "backButton";
            backButton.Size = new Size(150, 50);
            backButton.TabIndex = 27;
            backButton.Text = "Back";
            backButton.UseVisualStyleBackColor = true;
            backButton.Click += returnButton_Click;
            // 
            // SortKnight
            // 
            SortKnight.Anchor = AnchorStyles.None;
            SortKnight.Location = new Point(270, 430);
            SortKnight.Name = "SortKnight";
            SortKnight.Size = new Size(63, 23);
            SortKnight.TabIndex = 28;
            SortKnight.Text = "Knight";
            SortKnight.UseVisualStyleBackColor = true;
            SortKnight.Click += SortKnight_Click;
            // 
            // SortRogue
            // 
            SortRogue.Anchor = AnchorStyles.None;
            SortRogue.Location = new Point(339, 430);
            SortRogue.Name = "SortRogue";
            SortRogue.Size = new Size(63, 23);
            SortRogue.TabIndex = 29;
            SortRogue.Text = "Rogue";
            SortRogue.UseVisualStyleBackColor = true;
            SortRogue.Click += SortRogue_Click;
            // 
            // SortCleric
            // 
            SortCleric.Anchor = AnchorStyles.None;
            SortCleric.Location = new Point(411, 430);
            SortCleric.Name = "SortCleric";
            SortCleric.Size = new Size(63, 23);
            SortCleric.TabIndex = 30;
            SortCleric.Text = "Cleric";
            SortCleric.UseVisualStyleBackColor = true;
            SortCleric.Click += SortCleric_Click;
            // 
            // SortJoker
            // 
            SortJoker.Anchor = AnchorStyles.None;
            SortJoker.Location = new Point(480, 430);
            SortJoker.Name = "SortJoker";
            SortJoker.Size = new Size(63, 23);
            SortJoker.TabIndex = 31;
            SortJoker.Text = "Joker";
            SortJoker.UseVisualStyleBackColor = true;
            SortJoker.Click += SortJoker_Click;
            // 
            // SortAll
            // 
            SortAll.Anchor = AnchorStyles.None;
            SortAll.Location = new Point(201, 430);
            SortAll.Name = "SortAll";
            SortAll.Size = new Size(63, 23);
            SortAll.TabIndex = 32;
            SortAll.Text = "All";
            SortAll.UseVisualStyleBackColor = true;
            SortAll.Click += SortAll_Click;
            // 
            // PreparationUserControl
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(backButton);
            Controls.Add(SortAll);
            Controls.Add(SortJoker);
            Controls.Add(SortCleric);
            Controls.Add(SortRogue);
            Controls.Add(SortKnight);
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
            Name = "PreparationUserControl";
            Size = new Size(1350, 705);
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            tabControl3.ResumeLayout(false);
            clericPostac.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)character3Picture).EndInit();
            clericStatystyki.ResumeLayout(false);
            clericStatystyki.PerformLayout();
            clericEkwipunek.ResumeLayout(false);
            clericEkwipunek.PerformLayout();
            tabControl5.ResumeLayout(false);
            roguePostac.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)character2Picture).EndInit();
            rogueStatystyki.ResumeLayout(false);
            rogueStatystyki.PerformLayout();
            rogueEkwipunek.ResumeLayout(false);
            rogueEkwipunek.PerformLayout();
            tabControl1.ResumeLayout(false);
            knightPostac.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)character1Picture).EndInit();
            knightStatystyki.ResumeLayout(false);
            knightStatystyki.PerformLayout();
            knightEkwipunek.ResumeLayout(false);
            knightEkwipunek.PerformLayout();
            tabControl2.ResumeLayout(false);
            jokerPostac.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)character4Picture).EndInit();
            jokerStatystyki.ResumeLayout(false);
            jokerStatystyki.PerformLayout();
            jokerEkwipunek.ResumeLayout(false);
            jokerEkwipunek.PerformLayout();
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
        private Label character1Name;
        private Label character1Initiative;
        private Label character1Crit;
        private Label character1Resistance;
        private Label character1Hp;
        private Label character1Intelligence;
        private Label character1Dexterity;
        private Label character1Strength;
        private Label character1Exp;
        private Label character1Level;
        private Label character1Dmg;
        private Label character3Dmg;
        private Label character3Name;
        private Label character3Initiative;
        private Label character3Level;
        private Label character3Crit;
        private Label character3Exp;
        private Label character3Resistance;
        private Label character3Strength;
        private Label character3Hp;
        private Label character3Dexterity;
        private Label character3Intelligence;
        private Label character2Dmg;
        private Label character2Initiative;
        private Label character2Crit;
        private Label character2Resistance;
        private Label character2Hp;
        private Label character2Intelligence;
        private Label character2Dexterity;
        private Label character2Strength;
        private Label character2Exp;
        private Label character2Level;
        private Label character2Name;
        private Label character4Dmg;
        private Label character4Name;
        private Label character4Initiative;
        private Label character4Level;
        private Label character4Crit;
        private Label character4Exp;
        private Label character4Resistance;
        private Label character4Strength;
        private Label character4Hp;
        private Label character4Dexterity;
        private Label character4Intelligence;
        private PictureBox character3Picture;
        private PictureBox character2Picture;
        private PictureBox character1Picture;
        private PictureBox character4Picture;
        private FlowLayoutPanel Inventory;
        private Label character1Weapon;
        private Label character1Armor;
        private Label character1Block;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private Label character2Block;
        private Label character2Armor;
        private Label character2Weapon;
        private Label character3Armor;
        private Label character3Weapon;
        private Label character4Armor;
        private Label character4Weapon;
        private Label goldLabel;
        private ToolTip toolTip1;
        private FlowLayoutPanel Shop;
        private Button Roll;
        private Button backButton;
        private Label character3ClassName;
        private Label character2ClassName;
        private Label character1ClassName;
        private Label character4ClassName;
        private Button SortKnight;
        private Button SortRogue;
        private Button SortCleric;
        private Button SortJoker;
        private Button SortAll;
        private Label character3Block;
        private Label character4Block;
    }
}
