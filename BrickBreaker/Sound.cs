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
            var soundsRoot = @"C:\Users\Attihasl487\Source\Repos\BrickBreakerTeam2\BrickBreaker\Resources\Sound";
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

            //Either create a priority list, ensuring that the sound that occurs first is played on active, then active2, then active3...
            //Or assign sounds likely to have conflict different active players... Which is easier.

            // While playing

            // If brick is struck, play brickstrike noise
         
            // if brick is broken, play brickbroken noise

            if ()
            {
                // Set int butthole to file location
                butthole = $"C:\Users\Attihasl487\Source\Repos\BrickBreakerTeam2\BrickBreaker\Resources\Sound\Bricksmash1\"";
                // Call/reference back to buttholesurfers, should replace int 'butthole' with the given soundfile location, much like with the weather app

            }

            // if paddle is hit, play paddlehit noise
      
            // if wall is struck, play wallstrike noise
         
            // If life is subtracted
        
            // While HP < 2

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