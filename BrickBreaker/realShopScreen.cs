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
        public static int SSPU1 = 0, SSPU2 = 0, SSPU3 = 0, SSPU4 = 0, SSPU5 = 0, SSPU6 = 0, SSPU7 = 0;

        public realShopScreen()
        {
            InitializeComponent();

            GameScreen.dB1 = false;
            GameScreen.dB2 = false;
            GameScreen.dB3 = false;
            GameScreen.dB4 = false;
            GameScreen.dB5 = false;

            resetCursor();
            shopScoreLabel.Text = Score.score.ToString();
        }

        private void resetCursor()
        {
            Cursor.Show();
            Cursor.Position = this.PointToScreen(new Point(this.Width / 2, this.Height / 2));
        }

        private void PU1Button_Click(object sender, EventArgs e)
        {
            if(Score.score > 10000)
            {
                SSPU1++;
                Score.score -= 10000;
                shopScoreLabel.Text = Score.score.ToString();
            }
        }

        private void PU2Button_Click(object sender, EventArgs e)
        {
            if(Score.score > 15000)
            {
                SSPU2++;
                Score.score -= 15000;
                shopScoreLabel.Text = Score.score.ToString();
            }

        }

        private void button8_Click(object sender, EventArgs e)
        {
            if (Score.score > 5000)
            {
                GameScreen.lives += 1;
                Score.score -= 5000;
                shopScoreLabel.Text = Score.score.ToString();
            }
        }

        private void PU3Button_Click(object sender, EventArgs e)
        {
            if(Score.score > 20000)
            {
                SSPU3++;
                Score.score -= 20000;
                shopScoreLabel.Text = Score.score.ToString();
            }

        }

        private void PU4Button_Click(object sender, EventArgs e)
        {
            if (Score.score > 7000)
            {
                SSPU4++;
                Score.score -= 7000;
                shopScoreLabel.Text = Score.score.ToString();
            }
        }

        private void PU5Button_Click(object sender, EventArgs e)
        {
            //one time purchase
            if(Score.score > 40000)
            {
                SSPU5++;
                Score.score -= 40000;
                shopScoreLabel.Text = Score.score.ToString();
            }

        }

        private void PU6Button_Click(object sender, EventArgs e)
        {
            if(Score.score > 35000)
            {
                SSPU6++;
                Score.score -= 35000;
                shopScoreLabel.Text = Score.score.ToString();
            }

        }

        private void PU7Button_Click(object sender, EventArgs e)
        {
            if(Score.score > 150000)
            {
                SSPU7++;
                Score.score -= 100000;
                shopScoreLabel.Text = Score.score.ToString();
            }

        }

        private void continueButton_Click(object sender, EventArgs e)
        {
            GameScreen.levelNumber++;
            Form1.ChangeScreen(this,new GameScreen());
        }
    }
}
