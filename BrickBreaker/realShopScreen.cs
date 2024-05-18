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
        public static int SSPU1 = 0, SSPU2 = 0, SSPU3 = 0, SSPU4 = 0, SSPU6 = 0, SSPU7 = 0;
        public static bool SSPU5 = false;
        public static bool duringGame = false;

        public realShopScreen()
        {
            InitializeComponent();
            p6Amount.BackColor = Color.FromArgb(80, 255, 255, 255);
            lowPShelfLabel.BackColor = Color.FromArgb(80, 255, 255, 255);
            shopScoreLabel.BackColor = Color.FromArgb(80, 255, 255, 255);
            livesBackground.BackColor = Color.FromArgb(80, 255, 255, 255);
            levelLabel.BackColor = Color.FromArgb(80, 255, 255, 255);
            levelLabel.Text = $"Level: {GameScreen.levelNumber}";
            livesCount.Parent = livesBackground;
            livesCount.Location = new Point(0, 22);
            livesCount.Text = $"{GameScreen.lives}";

            GameScreen.dB1 = false;
            GameScreen.dB2 = false;
            GameScreen.dB3 = false;
            GameScreen.dB4 = false;
            GameScreen.dB5 = false;

            p1Amount.Text = $"x{SSPU1}";
            p2Amount.Text = $"x{SSPU2}";
            p3Amount.Text = $"x{SSPU3}";
            p4Amount.Text = $"x{SSPU4}";
            p6Amounr.Text = $"x{SSPU6}";
            p7Amount.Text = $"x{SSPU7}";

            if (SSPU5) {
                p5Active.Text = "Active";
            }
            else
            {
                p5Active.Text = "Inactive";
            }

            resetCursor();
            shopScoreLabel.Text = Score.score.ToString();
        }

        private void resetCursor()
        {
            Cursor.Show();
            Cursor.Position = this.PointToScreen(new Point(this.Width / 2, this.Height / 2));

            if (SSPU5)
            {
                PU5Button.BackColor = Color.DarkGray;
            }
        }

        private void PU1Button_Click(object sender, EventArgs e)
        {
            if(Score.score > 2000)
            {
                SSPU1++;
                Score.score -= 2000;
                shopScoreLabel.Text = Score.score.ToString();
                p1Amount.Text = $"x{SSPU1}";
            }
        }

        private void PU2Button_Click(object sender, EventArgs e)
        {
            if(Score.score > 10000)
            {
                SSPU2++;
                Score.score -= 10000;
                shopScoreLabel.Text = Score.score.ToString();
                p2Amount.Text = $"x{SSPU2}";
            }

        }

        private void button8_Click(object sender, EventArgs e)
        {
            if (Score.score > 5000)
            {
                GameScreen.lives += 1;
                Score.score -= 5000;
                shopScoreLabel.Text = Score.score.ToString();
                livesCount.Text = $"{GameScreen.lives}";
            }
        }

        private void instructionsButton_Click(object sender, EventArgs e)
        {
            duringGame = true;
            Form1.ChangeScreen(this, new InstructionsScreen());
        }

        private void PU3Button_Click(object sender, EventArgs e)
        {
            if(Score.score > 15000)
            {
                SSPU3++;
                Score.score -= 15000;
                shopScoreLabel.Text = Score.score.ToString();
                p3Amount.Text = $"x{SSPU3}";
            }

        }

        private void PU4Button_Click(object sender, EventArgs e)
        {
            if (Score.score > 1000)
            {
                SSPU4++;
                Score.score -= 1000;
                shopScoreLabel.Text = Score.score.ToString();
                p4Amount.Text = $"x{SSPU4}";
            }
        }

        private void PU5Button_Click(object sender, EventArgs e)
        {
            //one time purchase
            if(Score.score > 40000)
            {
                p5Active.Text = "Active";
                PU5Button.BackColor = Color.DarkGray;
                SSPU5 = true;
                Score.score -= 40000;
                shopScoreLabel.Text = Score.score.ToString();
            }

        }

        private void PU6Button_Click(object sender, EventArgs e)
        {
            if(Score.score > 30000)
            {
                SSPU6++;
                Score.score -= 30000;
                shopScoreLabel.Text = Score.score.ToString();
                p6Amounr.Text = $"x{SSPU6}";
            }

        }

        private void PU7Button_Click(object sender, EventArgs e)
        {
            if(Score.score > 150000)
            {
                SSPU7++;
                Score.score -= 150000;
                shopScoreLabel.Text = Score.score.ToString();
                p7Amount.Text = $"x{SSPU7}";
            }

        }

        private void continueButton_Click(object sender, EventArgs e)
        {
            Form1.ChangeScreen(this, new GameScreen());
        }
    }
}
