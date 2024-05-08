using System;
using System.Drawing;
using System.Windows.Forms;

namespace BrickBreaker
{
    public class Ball
    {
        public float x, y, xSpeed, ySpeed, size;
        public Color colour;

        public static Random rand = new Random();

        public Ball(int _x, int _y, int _xSpeed, int _ySpeed, int _ballSize)
        {
            x = _x;
            y = _y;
            xSpeed = _xSpeed;
            ySpeed = _ySpeed;
            size = _ballSize;

        }

        public void Move()
        {
            x = x + xSpeed;
            y = y + ySpeed;
        }

        public bool BlockCollision(Block b)
        {
            RectangleF blockRec = b.hitBox;
            RectangleF ballRec = new RectangleF(x, y, size, size);

            if (ballRec.IntersectsWith(blockRec))
            {
                if ((x < b.hitBox.X - size + 8 || x > b.hitBox.X + b.hitBox.Width - 8) && (y > b.hitBox.Y - size || y < b.hitBox.Y + b.hitBox.Width - 8))
                {
                    if (xSpeed > 0)
                    {
                        x = b.hitBox.X - size;
                    }
                    else
                    {
                        x = b.hitBox.X + b.hitBox.Width;
                    }
                    xSpeed *= -1;
                }
                else if (x > b.hitBox.X - size - 8 || x < b.hitBox.X + b.hitBox.Width - 8)
                {
                    if (ySpeed > 0)
                    {
                        y = b.hitBox.Y - size;
                    }
                    else
                    {
                        y = b.y + b.height;
                    }
                    ySpeed *= -1;
                }
                int chance = 101;
                if (rand.Next(1, 100)  <= chance)
                {
                    int check = rand.Next(1, 100);
                    int o = 0;

                    if (check > 10 && check < 20)
                    {
                        o = 1;
                    }
                    else if (check > 20 && check < 50)
                    {
                        o = 2;
                    }
                    else if (check == 50)
                    {
                        o = 3;
                    }
                    else if (check > 51 && check < 62)
                    {
                        o = 4;
                    }
                    else 
                    {
                        o = 5;
                    }

                    Debuff newDebuff = new Debuff(o, b.x + b.width / 2, b.y + b.width);

                    GameScreen.debuffs.Add(newDebuff);
                }
            }
            return blockRec.IntersectsWith(ballRec);
        }

        public void PaddleCollision(Paddle p)
        {
            RectangleF ballRec = new RectangleF(x, y, size, size);
            RectangleF paddleRec = new RectangleF(p.x, p.y, p.width, p.height);

            if (ballRec.IntersectsWith(paddleRec))
            {
                ySpeed *= -1;
                y = p.y - size;
                ySpeed -= (float)0.05;
                if (xSpeed > 0)
                {
                    xSpeed += (float)0.05;
                }
                else
                {
                    xSpeed -= (float)0.05;
                }
            }
        }

        public bool BottomCollision(UserControl UC)
        {
            Boolean didCollide = false;

            if (y >= UC.Height)
            {
                didCollide = true;
            }

            return didCollide;
        }

    }
}
