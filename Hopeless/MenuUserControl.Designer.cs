namespace Hopeless
{
    partial class MenuUserControl
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MenuUserControl));
            pictureBox1 = new PictureBox();
            kontynuujGreButton = new Button();
            nowaGraButton = new Button();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // pictureBox1
            // 
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(0, 0);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(1424, 861);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 0;
            pictureBox1.TabStop = false;
            // 
            // kontynuujGreButton
            // 
            kontynuujGreButton.Enabled = false;
            kontynuujGreButton.Location = new Point(638, 735);
            kontynuujGreButton.Name = "kontynuujGreButton";
            kontynuujGreButton.Size = new Size(150, 50);
            kontynuujGreButton.TabIndex = 1;
            kontynuujGreButton.Text = "Kontynuuj Gre";
            kontynuujGreButton.UseVisualStyleBackColor = true;
            // 
            // nowaGraButton
            // 
            nowaGraButton.Location = new Point(638, 657);
            nowaGraButton.Name = "nowaGraButton";
            nowaGraButton.Size = new Size(150, 50);
            nowaGraButton.TabIndex = 2;
            nowaGraButton.Text = "Nowa Gra";
            nowaGraButton.UseVisualStyleBackColor = true;
            nowaGraButton.Click += nowaGraButton_Click;
            // 
            // MenuUserControl
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(nowaGraButton);
            Controls.Add(kontynuujGreButton);
            Controls.Add(pictureBox1);
            Name = "MenuUserControl";
            Size = new Size(1424, 861);
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private PictureBox pictureBox1;
        private Button kontynuujGreButton;
        private Button nowaGraButton;
    }
}
