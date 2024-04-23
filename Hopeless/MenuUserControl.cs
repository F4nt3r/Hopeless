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
        }

        public event EventHandler NowaGraButtonClicked;

       

        private void nowaGraButton_Click(object sender, EventArgs e)
        {
            NowaGraButtonClicked?.Invoke(this, EventArgs.Empty);
        }
        
    }
}
