using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BrickBreaker
{
    public partial class InstructionsScreen : UserControl
    {
        public InstructionsScreen()
        {
            InitializeComponent();
        }

        private void label14_Click(object sender, EventArgs e)
        {

        }

        private void BackButton_Click(object sender, EventArgs e)
        {
            if (realShopScreen.duringGame)
            {
                Form1.ChangeScreen(this, new realShopScreen());
            }
            else
            {
                Form1.ChangeScreen(this, new MenuScreen());
            }
        }

        private void controls_Click(object sender, EventArgs e)
        {

        }
    }
}
