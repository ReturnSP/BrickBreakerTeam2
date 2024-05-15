using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BrickBreaker
{
    internal class Score
    {
        public double score { get; set; }
        public double comboCounter { get; set; }

        public Score(int initialScore, double initialCombo)
        {
            score = initialScore;
            comboCounter = initialCombo;
        }

        public void AddToScore(int scoreNumb)
        {
            score += scoreNumb * comboCounter;
            AddToCombo(0.1);
        }

        public void AddToCombo(double comboAdd)
        {
            comboCounter += comboAdd;
        }

        public void RemoveCombo()
        {
            comboCounter = 1;
        }
    }
}
