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

            // Source root for sounds
            var soundsRoot = @"C:\Users\Attihasl487\Source\Repos\BrickBreakerTeam2\BrickBreaker\Resources\Sound";
            // Create new random
            var rand = new Random();
            // List of files from directory
            string[] soundFiles = Directory.GetFiles(@"C:\Users\Attihasl487\Source\Repos\BrickBreakerTeam2\BrickBreaker\Resources\Sound", "*.wav");
            // Create playsound variable, plays a random sound from established directory
            var playSound = soundFiles[rand.Next(0, soundFiles.Length)];
            // Play sound
            System.Media.SoundPlayer idle = new System.Media.SoundPlayer(playSound);
         
            // Create windows media player (2) for active sound
            var active = new WindowsMediaPlayer();
            active.URL = @"C:\Users\Attihasl487\Source\Repos\BrickBreakerTeam2\BrickBreaker\Resources\";
            Console.ReadLine();

            // While playing

            // If brick is struck, play brickstrike noise
            // if brick is broken, play brickbroken noise
            // if paddle is hit, play paddlehit noise
            // if wall is struck, play wallstrike noise
            // If life is subtracted
            // If HP < 2

            //If button clicked

            // If cont button is clicked
            // If startbutton is clicked
            // If purchasebutton is clicked
            // If exit program button is clicked

            // While within location

            // While shop is entered
            // While deathscreen is entered
            // While menu screen is entered 

            // Powerups collected

            // If evilassskullmf
            // If whiteboy
            // if hindupeace
            // If freaky
            // If blessingofwar

            // Moving on

            // If complete level
            // If beat game


            // Discarded code to keep for later
            //SoundPlayer player = new SoundPlayer(filePaths[choices]);
            //player.Play();
            //var idle = new WindowsMediaPlayer();
            //idle.URL = @"C:\Users\Attihasl487\Source\Repos\BrickBreakerTeam2\BrickBreaker\Resources\"+idleselected+"";

        }
    }
}