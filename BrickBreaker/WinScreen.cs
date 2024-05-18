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
    public partial class WinScreen : UserControl
    {
        int initialFormWidth;
        int initialFormHeight;
        int initialFontSize ;
        public WinScreen()
        {
            InitializeComponent();
            this.Size = Screen.PrimaryScreen.Bounds.Size;
            initialFormWidth = this.Width;
            initialFormHeight = this.Height;
            initialFontSize = (int)label1.Font.Size;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form1.ChangeScreen(this, new MenuScreen());
        }

        private void Form1_Resize(object sender, EventArgs e)
        {
            ResizeLabelFont();
        }

        private void ResizeLabelFont()
        {
            // Calculate the scaling factor
            float widthRatio = this.Width / initialFormWidth;
            float heightRatio = this.Height / initialFormHeight;
            float scale = Math.Min(widthRatio, heightRatio);

            // Calculate the new font size
            float newFontSize = initialFontSize * scale;

            // Set the new font size
            label1.Font = new Font(label1.Font.FontFamily, newFontSize, label1.Font.Style);
        }

    }
}
