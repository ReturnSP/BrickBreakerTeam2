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
        public Color color;
        int speedUp;


        public Debuff(int _debuff, int _x, int _y, Color _color)
        {
            debuff = _debuff;
            x = _x;
            y = _y;
            color = _color;
        }

        public void Spawn()
        {
            speedUp = speedUp + 2;
            
            double temp = 0.155 * ( 2 ^ speedUp);

            y += Convert.ToInt16(temp);
        }

        public void PaddleCollision(Paddle p, Debuff d)
        {
            Rectangle DebuffRec = new Rectangle(d.x, d.y, 10, 10);
            Rectangle paddleRec = new Rectangle(p.x - 20, p.y, (int)p.width + 40, p.height);

            if (DebuffRec.IntersectsWith(paddleRec))
            {
                GameScreen.debuffCollected = true;
                GameScreen.SDC = d;


                if (d.debuff == 1)
                {
                    GameScreen.dB1 = true;
                }
                if (d.debuff == 2)
                {
                    GameScreen.dB2 = true;
                }
                if (d.debuff == 3)
                {
                    GameScreen.dB3 = true;
                }
                if (d.debuff == 4)
                {
                    GameScreen.dB4 = true;
                }
                if (d.debuff == 5)
                {
                    GameScreen.dB5 = true;
                }
            }
        }
    }
}
