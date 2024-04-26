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
    public partial class WyborWyprawyUserControl : UserControl
    {
        public List<Expediton> Expeditions { get; set; }
        public List<Monster> Monsters { get; set; }
        public Expediton SelectedExpedition { get; set; }
 
        public WyborWyprawyUserControl()
        {
            InitializeComponent();
            pictureBox1.Image = Properties.Resources.Prep;
            this.Load += WyborWyprawyUserControl_Load;

          
        }
        private void WyborWyprawyUserControl_Load(object sender, EventArgs e)
        {
            InitializeExpeditions();
            InitializeMouseEvents();
        }
        private void InitializeExpeditions()
        {
            foreach (Expediton expediton in Expeditions)
            {
                Label label = new Label();
                if (expediton.Type == DifficultyType.Easy)
                {

                    label.Text = expediton.Name;
                    label.AutoSize = false;
                    label.Height = 50;
                    label.TextAlign = ContentAlignment.MiddleCenter;
                    label.BorderStyle = BorderStyle.FixedSingle;


                    label.AccessibleDescription = expediton.Name + Environment.NewLine + expediton.Description + Environment.NewLine + "Złoto za wyprawe: " + expediton.Gold.ToString() +
                    Environment.NewLine + "EXP za wyprawe: " + expediton.ExperienceGains.ToString() + Environment.NewLine + Environment.NewLine +
                    "Możliwy Drop Broni:" + Environment.NewLine +
                    string.Join("," + Environment.NewLine, expediton.WeaponRewards.Select(Name => Name.ToString())) + Environment.NewLine + Environment.NewLine +
                    "Możliwy Drop Zbroii:" + Environment.NewLine +
                    string.Join("," + Environment.NewLine, expediton.ArmorRewards.Select(Name => Name.ToString())) + Environment.NewLine + Environment.NewLine +
                     "Potwory:" + Environment.NewLine +
                    string.Join("," + Environment.NewLine, expediton.Monsters.Select(Name => Name.ToString()));
                   
                    
                    
                    
                    easyExpeditions.Controls.Add(label);

                }



                else if (expediton.Type == DifficultyType.Medium)
                {

                }
                else if (expediton.Type == DifficultyType.Hard)
                {

                }
                else
                {

                }
            }
        }
        private void InitializeMouseEvents()
        {
            foreach (Control control in easyExpeditions.Controls)
            {
                control.MouseHover += ExpeditionMouseHover;
                control.MouseClick += ExpeditionMouseClick;
            }
        }
        private void ExpeditionMouseHover(object sender, EventArgs e)
        {
            Label label = sender as Label;
            string itemDescription = label.AccessibleDescription;
            DescriptionBox.Text = itemDescription;
        }
        public event EventHandler ExpeditionMouseClicked;
        private void ExpeditionMouseClick(object sender, EventArgs e)
        {
            Label label = sender as Label;
            foreach (Expediton expedition in Expeditions)
            {
                if (expedition.Name == label.Text)
                {
                    SelectedExpedition = expedition;
                }
            }
           

            ExpeditionMouseClicked?.Invoke(this, EventArgs.Empty);
        }
        public event EventHandler powrotButtonClicked;     
        private void powrotButton_Click(object sender, EventArgs e)
        {
            powrotButtonClicked?.Invoke(this, EventArgs.Empty);
        }

        public void AfterWin(bool wynik)
        {
            
        }
        public void AfterLose(bool wynik)
        {

        }
    }
}
