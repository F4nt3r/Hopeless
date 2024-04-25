using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Hopeless
{
    public partial class MenuUserControl : UserControl
    {
        public MenuUserControl()
        {
            InitializeComponent();

            pictureBox1.Image = Properties.Resources.hope;
            UpdateKontynuujGreButtonState();
        }

        public event EventHandler NowaGraButtonClicked;

        public event EventHandler KontynuujGreButtonClicked;

        private void nowaGraButton_Click(object sender, EventArgs e)
        {
            NowaGraButtonClicked?.Invoke(this, EventArgs.Empty);
        }

        private void kontynuujGreButton_Click(object sender, EventArgs e)
        {
            KontynuujGreButtonClicked?.Invoke(this, EventArgs.Empty);
        }
        private void UpdateKontynuujGreButtonState()
        {
      
            string saveFilePath = "game_state.json";

            bool fileExists = File.Exists(saveFilePath);

            kontynuujGreButton.Enabled = fileExists;
        }
    }
}
