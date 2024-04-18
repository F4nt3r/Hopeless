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
        public WyprawaUserControl()
        {
            InitializeComponent();
            pictureBox1.Image = Properties.Resources.Wyprawa;
        }

    }
}
