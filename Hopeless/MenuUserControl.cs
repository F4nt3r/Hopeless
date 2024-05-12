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
            if (UpdateCountinueButtonState())
            {

            }
        }

        public event EventHandler NewGameButtonClicked;

        public event EventHandler ContinueGreButtonClicked;

        private void newGameButton_Click(object sender, EventArgs e)
        {

            if (UpdateCountinueButtonState())
            {
                DialogResult result = MessageBox.Show("There is a save game. Do you want to overwrite it and continue?", "Override game", MessageBoxButtons.YesNo);
                if (result == DialogResult.Yes)
                {
                    NewGameButtonClicked?.Invoke(this, EventArgs.Empty);
                }
            }
            else
            {
                NewGameButtonClicked?.Invoke(this, EventArgs.Empty);
            }



        }

        private void countinueButton_Click(object sender, EventArgs e)
        {
            ContinueGreButtonClicked?.Invoke(this, EventArgs.Empty);
        }
        private bool UpdateCountinueButtonState()
        {

            string saveFilePath = "game_state.json";

            bool fileExists = File.Exists(saveFilePath);

            kontynuujGreButton.Enabled = fileExists;
            return fileExists;
        }


    }
}
