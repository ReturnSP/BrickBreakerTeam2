using System;
using System.Drawing;
using System.Windows.Forms;

namespace BrickBreaker
{
    public class Ball
    {
        public int x, y, xSpeed, ySpeed, size;
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
            Rectangle blockRec = b.hitBox;
            Rectangle ballRec = new Rectangle(x, y, size, size);

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
                        y = b.hitBox.Y + b.hitBox.Height; 
                    }

                    ySpeed *= -1;
                }
            }

            return blockRec.IntersectsWith(ballRec);
        }

        public void PaddleCollision(Paddle p)
        {
            Rectangle ballRec = new Rectangle(x, y, size, size);
            Rectangle paddleRec = new Rectangle(p.x, p.y, p.width, p.height);

            if (ballRec.IntersectsWith(paddleRec))
            {
                ySpeed *= -1;
                y = p.y - size;
            }
        }

        public void WallCollision(UserControl UC)
        {
            // Collision with left wall
            if (x < 0)
            {
                x = 0;
                xSpeed *= -1;
            }
            // Collision with right wall
            if (x > (UC.Width - size))
            {
                x = UC.Width - size;
                xSpeed *= -1;
            }
            // Collision with top wall
            if (y < 0)
            {
                y = 0;
                ySpeed *= -1;
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
