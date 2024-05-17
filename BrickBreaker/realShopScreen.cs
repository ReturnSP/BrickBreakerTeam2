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
    public partial class realShopScreen : UserControl
    {
        public static bool SSPU1, SSPU2, SSPU3, SSPU4, SSPU5, SSPU6, SSPU7;
        double buyingPower;

        public realShopScreen()
        {
            InitializeComponent();
            GameScreen.x1 = 0;
            GameScreen.x2 = 0;
            GameScreen.x3 = 0;
            GameScreen.x4 = 0;
            GameScreen.x5 = 0;
            GameScreen.x6 = 0;
            GameScreen.x7 = 0;

            SSPU1 = false;
            SSPU2 = false;
            SSPU3 = false;
            SSPU4 = false;
            SSPU5 = false;
            SSPU6 = false;
            SSPU7 = false;

            GameScreen.dB1 = false;
            GameScreen.dB2 = false;
            GameScreen.dB3 = false;
            GameScreen.dB4 = false;
            GameScreen.dB5 = false;

            Cursor.Show();
            buyingPower = Score.score;
            shopScoreLabel.Text = buyingPower.ToString();

        }

        private void PU1Button_Click(object sender, EventArgs e)
        {
            if(buyingPower > 1000)
            {
                SSPU1 = true;
            }
        }

        private void PU2Button_Click(object sender, EventArgs e)
        {
            if(buyingPower > 2000)
            {
                SSPU2 = true;
            }

        }

        private void PU3Button_Click(object sender, EventArgs e)
        {
            if(buyingPower > 3000)
            {
                SSPU3 = true;
            }

        }

        private void PU4Button_Click(object sender, EventArgs e)
        {
            if (buyingPower > 4000)
            {
                SSPU4 = true;
            }
        }

        private void PU5Button_Click(object sender, EventArgs e)
        {
            if(buyingPower > 5000)
            {
                SSPU5 = true;
            }

        }

        private void PU6Button_Click(object sender, EventArgs e)
        {
            if(buyingPower > 6000)
            {
                SSPU6 = true;
            }

        }

        private void PU7Button_Click(object sender, EventArgs e)
        {
            if(buyingPower > 7000)
            {
                SSPU7 = true;
            }

        }

        private void continueButton_Click(object sender, EventArgs e)
        {
            GameScreen.levelNumber++;
            Form1.ChangeScreen(this,new GameScreen());
        }
    }
}
