using HopelessLibary;
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
    public partial class WyprawaUserControl : UserControl
    {
        public List<Character> Characters { get; set; }
        public Expedition expedition { get; set; }

        public delegate void CustomDelegate(bool wynik, Expedition wyprawa);
        public event CustomDelegate eventFirst;

        public WyprawaUserControl()
        {
            InitializeComponent();
            pictureBox1.Image = Properties.Resources.Wyprawa;
            this.Load += WyprawaUserControl_Load;
        }
        private void WyprawaUserControl_Load(object sender, EventArgs e)
        {
            knightName.Text = Characters[0].Name;
            rogueName.Text = Characters[1].Name;
            clericName.Text = Characters[2].Name;
            jokerName.Text = Characters[3].Name;

            enemy1Name.Text = expedition.Monsters[0].Name;
            enemy2Name.Text = expedition.Monsters[1].Name;
            enemy3Name.Text = expedition.Monsters[2].Name;
            enemy4Name.Text = expedition.Monsters[3].Name;

        }
        public event EventHandler FinishButtonClicked;
        private void loseButton_Click(object sender, EventArgs e)
        {
            eventFirst?.Invoke(false, expedition);
            FinishButtonClicked?.Invoke(this, EventArgs.Empty);
        }
        private void winButton_Click(object sender, EventArgs e)
        {
            eventFirst?.Invoke(true, expedition);
            FinishButtonClicked?.Invoke(this, EventArgs.Empty);
        }

    }
}