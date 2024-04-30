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
            RectangleF blockRec = new RectangleF(b.x, b.y, b.width, b.height);
            RectangleF ballRec = new RectangleF(x, y, size, size);

            if (ballRec.IntersectsWith(blockRec))
            {
                ySpeed *= -1;
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
            }
        }

        public void WallCollision(UserControl UC)
        {
            // Collision with left wall
            if (x <= 0)
            {
                xSpeed *= -1;
            }
            // Collision with right wall
            if (x >= (UC.Width - size))
            {
                xSpeed *= -1;
            }
            // Collision with top wall
            if (y <= 2)
            {
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
