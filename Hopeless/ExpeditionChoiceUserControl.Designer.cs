namespace Hopeless
{
    partial class ExpeditionChoiceUserControl
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
            returnButton = new Button();
            pictureBox1 = new PictureBox();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // DescriptionBox
            // 
            DescriptionBox.Enabled = false;
            DescriptionBox.Location = new Point(1030, 88);
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
            hardExpeditions.Anchor = AnchorStyles.None;
            hardExpeditions.BackColor = Color.Red;
            hardExpeditions.Location = new Point(23, 341);
            hardExpeditions.Name = "hardExpeditions";
            hardExpeditions.Size = new Size(920, 140);
            hardExpeditions.TabIndex = 12;
            // 
            // mediumExpeditions
            // 
            mediumExpeditions.AllowDrop = true;
            mediumExpeditions.Anchor = AnchorStyles.None;
            mediumExpeditions.BackColor = Color.Orange;
            mediumExpeditions.Location = new Point(23, 179);
            mediumExpeditions.Name = "mediumExpeditions";
            mediumExpeditions.Size = new Size(920, 140);
            mediumExpeditions.TabIndex = 13;
            // 
            // easyExpeditions
            // 
            easyExpeditions.AllowDrop = true;
            easyExpeditions.Anchor = AnchorStyles.None;
            easyExpeditions.BackColor = Color.Green;
            easyExpeditions.Location = new Point(23, 19);
            easyExpeditions.Name = "easyExpeditions";
            easyExpeditions.Size = new Size(920, 140);
            easyExpeditions.TabIndex = 13;
            // 
            // bossExpeditions
            // 
            bossExpeditions.AllowDrop = true;
            bossExpeditions.Anchor = AnchorStyles.None;
            bossExpeditions.BackColor = Color.Black;
            bossExpeditions.Location = new Point(323, 506);
            bossExpeditions.Name = "bossExpeditions";
            bossExpeditions.Size = new Size(620, 140);
            bossExpeditions.TabIndex = 13;
            // 
            // returnButton
            // 
            returnButton.Anchor = AnchorStyles.None;
            returnButton.Location = new Point(-5, 635);
            returnButton.Name = "returnButton";
            returnButton.Size = new Size(208, 67);
            returnButton.TabIndex = 14;
            returnButton.Text = "Return";
            returnButton.UseVisualStyleBackColor = true;
            returnButton.Click += returnButton_Click;
            // 
            // pictureBox1
            // 
            pictureBox1.Dock = DockStyle.Fill;
            pictureBox1.Location = new Point(0, 0);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(1350, 705);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 15;
            pictureBox1.TabStop = false;
            // 
            // ExpeditionChoiceUserControl
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(returnButton);
            Controls.Add(bossExpeditions);
            Controls.Add(easyExpeditions);
            Controls.Add(mediumExpeditions);
            Controls.Add(hardExpeditions);
            Controls.Add(DescriptionBox);
            Controls.Add(pictureBox1);
            Name = "ExpeditionChoiceUserControl";
            Size = new Size(1350, 705);
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
        private Button returnButton;
        private PictureBox pictureBox1;
    }
}
