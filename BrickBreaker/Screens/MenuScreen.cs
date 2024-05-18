using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BrickBreaker
{
    public partial class MenuScreen : System.Windows.Forms.UserControl
    {
        System.Windows.Media.MediaPlayer menuMusic = new System.Windows.Media.MediaPlayer();
        public MenuScreen()
        {
            Cursor.Show();
            InitializeComponent();
            menuMusic.Open(new Uri(Application.StartupPath + "\\Resources\\Wasteland 2 Soundtrack - Desert Nomads.wav"));
            menuMusic.MediaEnded += new EventHandler(menuMusicEnded);
            menuMusic.Play();
            Cursor.Show();
        }

        private void menuMusicEnded(object sender, EventArgs e)
        {
            menuMusic.Stop();
            menuMusic.Play();
            Cursor.Show();
        }

        private void exitButton_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void playButton_Click(object sender, EventArgs e)
        {
            Cursor.Hide();
            Score.score = 25000;
            // Goes to the game screen
            Form1.ChangeScreen(this, new realShopScreen());
            menuMusic.Stop();
        }

  

        private void MenuScreen_Load(object sender, EventArgs e)
        {
            Cursor.Show();
        }

        private void instructionsButton_Click(object sender, EventArgs e)
        {
            realShopScreen.duringGame = false;
            Form1.ChangeScreen(this, new InstructionsScreen());
        }
    }
}
