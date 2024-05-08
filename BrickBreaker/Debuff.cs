using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace BrickBreaker
{
    public class Debuff
    {
        public int debuff;
        public int x, y;

        public Debuff(int _debuff, int _x, int _y)
        {
            debuff = _debuff;
            x = _x;
            y = _y;

        }

        public void Spawn()
        {
            y += 6;     
        }

        public void PaddleCollision(Paddle p, Debuff d)
        {
            Rectangle DebuffRec = new Rectangle(d.x, d.y, 10, 10);
            Rectangle paddleRec = new Rectangle(p.x, p.y, p.width, p.height);

            if (DebuffRec.IntersectsWith(paddleRec))
            {
                GameScreen.debuffCollected = true;
                GameScreen.SDC = d;


                if (d.debuff == 1)
                {
                    GameScreen.dB1 = true;
                }
                if(d.debuff == 2)
                {
                    GameScreen.dB2 = true;
                }
                if(d.debuff == 3)
                {
                    GameScreen.dB3 = true;
                }
                if(d.debuff == 4)
                {
                    GameScreen.dB4 = true;
                }
                if(d.debuff == 5)
                {
                    GameScreen.dB5 = true;
                }
            }
        }
    }
}
