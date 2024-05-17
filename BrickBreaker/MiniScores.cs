using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Timers;
using System.Diagnostics;
using System.Drawing;

namespace BrickBreaker
{
    class MiniScores
    {
        public Stopwatch time = new Stopwatch();
        public Point drawPoint { get; set; }
        public string text { get; set; }
        public int transparency { get; set; }

        public MiniScores(string _text, Point _drawPoint, int _transparency)
        {
            drawPoint = _drawPoint;
            text = _text;
            transparency = _transparency;
            time.Start();
        }


    }
}
