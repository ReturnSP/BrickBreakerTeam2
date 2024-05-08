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
    public partial class ShopScreen : Form
    {
        public ShopScreen()
        {
            InitializeComponent();

            highPShelfLabel.BackColor = Color.FromArgb(160, 100, 100, 100);
            lowPShelfLabel.BackColor = Color.FromArgb(160, 100, 100, 100);
            sideBarLabel.BackColor = Color.FromArgb(160, 100, 100, 100);
          

        }
    }
}
