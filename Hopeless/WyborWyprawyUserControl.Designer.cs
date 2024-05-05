namespace Hopeless
{
    partial class WyborWyprawyUserControl
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
            DescriptionBox = new TextBox();
            hardExpeditions = new FlowLayoutPanel();
            mediumExpeditions = new FlowLayoutPanel();
            easyExpeditions = new FlowLayoutPanel();
            bossExpeditions = new FlowLayoutPanel();
            powrotButton = new Button();
            pictureBox1 = new PictureBox();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // DescriptionBox
            // 
            DescriptionBox.Enabled = false;
            DescriptionBox.Location = new Point(1072, 155);
            DescriptionBox.MaximumSize = new Size(300, 500);
            DescriptionBox.Multiline = true;
            DescriptionBox.Name = "DescriptionBox";
            DescriptionBox.ScrollBars = ScrollBars.Vertical;
            DescriptionBox.Size = new Size(300, 500);
            DescriptionBox.TabIndex = 10;
            DescriptionBox.TextAlign = HorizontalAlignment.Center;
            // 
            // hardExpeditions
            // 
            hardExpeditions.AllowDrop = true;
            hardExpeditions.Location = new Point(31, 407);
            hardExpeditions.Name = "hardExpeditions";
            hardExpeditions.Size = new Size(920, 160);
            hardExpeditions.TabIndex = 12;
            // 
            // mediumExpeditions
            // 
            mediumExpeditions.AllowDrop = true;
            mediumExpeditions.Location = new Point(31, 217);
            mediumExpeditions.Name = "mediumExpeditions";
            mediumExpeditions.Size = new Size(920, 160);
            mediumExpeditions.TabIndex = 13;
            // 
            // easyExpeditions
            // 
            easyExpeditions.AllowDrop = true;
            easyExpeditions.Location = new Point(31, 28);
            easyExpeditions.Name = "easyExpeditions";
            easyExpeditions.Size = new Size(920, 160);
            easyExpeditions.TabIndex = 13;
            // 
            // bossExpeditions
            // 
            bossExpeditions.AllowDrop = true;
            bossExpeditions.Location = new Point(202, 610);
            bossExpeditions.Name = "bossExpeditions";
            bossExpeditions.Size = new Size(610, 160);
            bossExpeditions.TabIndex = 13;
            // 
            // powrotButton
            // 
            powrotButton.Location = new Point(13, 800);
            powrotButton.Name = "powrotButton";
            powrotButton.Size = new Size(150, 50);
            powrotButton.TabIndex = 14;
            powrotButton.Text = "Powrót";
            powrotButton.UseVisualStyleBackColor = true;
            powrotButton.Click += powrotButton_Click;
            // 
            // pictureBox1
            // 
            pictureBox1.Dock = DockStyle.Fill;
            pictureBox1.Location = new Point(0, 0);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(1424, 861);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 15;
            pictureBox1.TabStop = false;
            // 
            // WyborWyprawyUserControl
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(powrotButton);
            Controls.Add(bossExpeditions);
            Controls.Add(easyExpeditions);
            Controls.Add(mediumExpeditions);
            Controls.Add(hardExpeditions);
            Controls.Add(DescriptionBox);
            Controls.Add(pictureBox1);
            Name = "WyborWyprawyUserControl";
            Size = new Size(1424, 861);
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox DescriptionBox;
        private FlowLayoutPanel hardExpeditions;
        private FlowLayoutPanel mediumExpeditions;
        private FlowLayoutPanel easyExpeditions;
        private FlowLayoutPanel bossExpeditions;
        private Button powrotButton;
        private PictureBox pictureBox1;
    }
}
