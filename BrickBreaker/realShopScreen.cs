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
                SSPU1 = true;
                Score.score -= 10000;
                shopScoreLabel.Text = Score.score.ToString();
            }
        }

        private void PU2Button_Click(object sender, EventArgs e)
        {
            if(Score.score > 15000)
            {
                SSPU2 = true;
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
                SSPU3 = true;
                Score.score -= 20000;
                shopScoreLabel.Text = Score.score.ToString();
            }

        }

        private void PU4Button_Click(object sender, EventArgs e)
        {
            if (Score.score > 7000)
            {
                SSPU4 = true;
                Score.score -= 7000;
                shopScoreLabel.Text = Score.score.ToString();
            }
        }

        private void PU5Button_Click(object sender, EventArgs e)
        {
            //one time purchase
            if(Score.score > 40000)
            {
                SSPU5 = true;
                Score.score -= 40000;
                shopScoreLabel.Text = Score.score.ToString();
            }

        }

        private void PU6Button_Click(object sender, EventArgs e)
        {
            if(Score.score > 35000)
            {
                SSPU6 = true;
                Score.score -= 35000;
                shopScoreLabel.Text = Score.score.ToString();
            }

        }

        private void PU7Button_Click(object sender, EventArgs e)
        {
            if(Score.score > 150000)
            {
                SSPU7 = true;
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
