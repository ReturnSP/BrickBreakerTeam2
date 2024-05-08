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

            // Discarded code to keep for later
            //SoundPlayer player = new SoundPlayer(filePaths[choices]);
            //player.Play();
            //var idle = new WindowsMediaPlayer();
            //idle.URL = @"C:\Users\Attihasl487\Source\Repos\BrickBreakerTeam2\BrickBreaker\Resources\"+idleselected+"";

        }
    }
}