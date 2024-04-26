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
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // pictureBox1
            // 
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(0, -3);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(1424, 861);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 0;
            pictureBox1.TabStop = false;
            // 
            // jokerName
            // 
            jokerName.AutoSize = true;
            jokerName.Location = new Point(52, 437);
            jokerName.Name = "jokerName";
            jokerName.Size = new Size(36, 15);
            jokerName.TabIndex = 12;
            jokerName.Text = "Imie: ";
            // 
            // clericName
            // 
            clericName.AutoSize = true;
            clericName.Location = new Point(173, 437);
            clericName.Name = "clericName";
            clericName.Size = new Size(36, 15);
            clericName.TabIndex = 13;
            clericName.Text = "Imie: ";
            // 
            // rogueName
            // 
            rogueName.AutoSize = true;
            rogueName.Location = new Point(291, 437);
            rogueName.Name = "rogueName";
            rogueName.Size = new Size(36, 15);
            rogueName.TabIndex = 14;
            rogueName.Text = "Imie: ";
            // 
            // knightName
            // 
            knightName.AutoSize = true;
            knightName.Location = new Point(434, 437);
            knightName.Name = "knightName";
            knightName.Size = new Size(36, 15);
            knightName.TabIndex = 15;
            knightName.Text = "Imie: ";
            // 
            // enemy1Name
            // 
            enemy1Name.AutoSize = true;
            enemy1Name.Location = new Point(858, 437);
            enemy1Name.Name = "enemy1Name";
            enemy1Name.Size = new Size(36, 15);
            enemy1Name.TabIndex = 16;
            enemy1Name.Text = "Imie: ";
            // 
            // enemy2Name
            // 
            enemy2Name.AutoSize = true;
            enemy2Name.Location = new Point(975, 437);
            enemy2Name.Name = "enemy2Name";
            enemy2Name.Size = new Size(36, 15);
            enemy2Name.TabIndex = 17;
            enemy2Name.Text = "Imie: ";
            // 
            // enemy3Name
            // 
            enemy3Name.AutoSize = true;
            enemy3Name.Location = new Point(1105, 437);
            enemy3Name.Name = "enemy3Name";
            enemy3Name.Size = new Size(36, 15);
            enemy3Name.TabIndex = 18;
            enemy3Name.Text = "Imie: ";
            // 
            // enemy4Name
            // 
            enemy4Name.AutoSize = true;
            enemy4Name.Location = new Point(1234, 437);
            enemy4Name.Name = "enemy4Name";
            enemy4Name.Size = new Size(36, 15);
            enemy4Name.TabIndex = 19;
            enemy4Name.Text = "Imie: ";
            // 
            // WyprawaUserControl
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
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
    }
}
