using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WMPLib;

namespace BrickBreaker
{
    internal class Sound
    {
        static void Main(string[] args)
        {

            // When you enter a new level
            // Trigger.function

            // Idle music, ambient, mostly Fallout tracks

            // Source root for sounds
            var soundsRoot = Properties.Resources.;
            // Create new random
            var rand = new Random();
            // List of files from directory
            string[] soundFiles = Directory.GetFiles(@"C:\Users\Attihasl487\Source\Repos\BrickBreakerTeam2\BrickBreaker\Resources\Sound", "*.wav");
            // Create playsound variable, plays a random sound from established directory
            var playSound = soundFiles[rand.Next(0, soundFiles.Length)];
            // Play sound
            System.Media.SoundPlayer idle = new System.Media.SoundPlayer(playSound);

            // Create windows media players for active sound
            // Can hypothetically play 3 sounds at the same time, unless I should add more?
            //var active = new WindowsMediaPlayer();
            //active.URL = @"C:\Users\Attihasl487\Source\Repos\BrickBreakerTeam2\BrickBreaker\Resources\";
            //var active2 = new WindowsMediaPlayer();
            //active.URL = @"C:\Users\Attihasl487\Source\Repos\BrickBreakerTeam2\BrickBreaker\Resources\";
            //var active3 = new WindowsMediaPlayer();
            //active.URL = @"C:\Users\Attihasl487\Source\Repos\BrickBreakerTeam2\BrickBreaker\Resources\";
            //var constant = new WindowsMediaPlayer();
            //active.URL = @"C:\Users\Attihasl487\Source\Repos\BrickBreakerTeam2\BrickBreaker\Resources\";
            //Console.ReadLine();

            // Location of file
            int butthole;
            //List of files from directory
            // Source root for sounds
            var buttholesurfers = @"C:\Users\Attihasl487\Source\Repos\BrickBreakerTeam2\BrickBreaker\Resources\Sound"+butthole+"";
            // list of files, by WAV
            string[] activeFiles = Directory.GetFiles(@"C:\Users\Attihasl487\Source\Repos\BrickBreakerTeam2\BrickBreaker\Resources\", "*.wav");
            // Something to change the given file to

            var activePlay = soundFiles[butthole];
            System.Media.SoundPlayer activebutthole = new System.Media.SoundPlayer(activePlay); 

            // Create active sound directory
            string[] activesound = Directory.GetFiles(@"C:\Users\Attihasl487\Source\Repos\BrickBreakerTeam2\BrickBreaker\Resources\Sound", "*.wav");



            // While playing

            // If brick is struck, play brickstrike noise
            if ()
            {
            System.Media.SoundPlayer brickstrike = new System.Media.SoundPlayer();
            brickstrike.Play();
            }
            // if brick is broken, play brickbroken noise
            System.Media.SoundPlayer brickbroke = new System.Media.SoundPlayer();
            brickbroke.Play();
            // if paddle is hit, play paddlehit noise
            System.Media.SoundPlayer paddlehit = new System.Media.SoundPlayer();
            brickbroke.Play();
            // if wall is struck, play wallstrike noise
            System.Media.SoundPlayer wallstrike = new System.Media.SoundPlayer();
            brickbroke.Play();
            // If life is subtracted
            System.Media.SoundPlayer lifesub = new System.Media.SoundPlayer();
            brickbroke.Play();
            // If HP < 2
            System.Media.SoundPlayer smallerthan2 = new System.Media.SoundPlayer();
            brickbroke.Play();

            //If button clicked

            // If cont button is clicked
            System.Media.SoundPlayer contbutt = new System.Media.SoundPlayer();
            brickbroke.Play();
            // If startbutton is clicked
            System.Media.SoundPlayer startbutt = new System.Media.SoundPlayer();
            brickbroke.Play();
            // If purchasebutton is clicked
            System.Media.SoundPlayer buybutt = new System.Media.SoundPlayer();
            brickbroke.Play();
            // If exit program button is clicked
            System.Media.SoundPlayer leavebutt = new System.Media.SoundPlayer();
            brickbroke.Play();

            // While within location

            // While shop is entered
            System.Media.SoundPlayer shop = new System.Media.SoundPlayer();
            brickbroke.Play();

            // While deathscreen is entered
            System.Media.SoundPlayer deathscreen = new System.Media.SoundPlayer();
            brickbroke.Play();

            // While menu screen is entered 
            System.Media.SoundPlayer menuscreen = new System.Media.SoundPlayer();
            brickbroke.Play();


            // Powerups collected

            // If evilassskullmf
            System.Media.SoundPlayer kil = new System.Media.SoundPlayer();
            brickbroke.Play();

            // If whiteboy
            System.Media.SoundPlayer crakka = new System.Media.SoundPlayer();
            brickbroke.Play();

            // if hindupeace
            System.Media.SoundPlayer heil = new System.Media.SoundPlayer();
            brickbroke.Play();

            // If freaky
            System.Media.SoundPlayer tongue = new System.Media.SoundPlayer();
            brickbroke.Play();

            // If blessingofwar
            System.Media.SoundPlayer pantera = new System.Media.SoundPlayer();
            brickbroke.Play();

            // Moving on

            // If complete level
            var completelvl = new WindowsMediaPlayer();

            // If beat game
            var beaten = new WindowsMediaPlayer();

            // Discarded code to keep for later
            //SoundPlayer player = new SoundPlayer(filePaths[choices]);
            //player.Play();
            //var idle = new WindowsMediaPlayer();
            //idle.URL = @"C:\Users\Attihasl487\Source\Repos\BrickBreakerTeam2\BrickBreaker\Resources\"+idleselected+"";

        }
    }
}