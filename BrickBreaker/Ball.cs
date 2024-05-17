using System;
using System.Drawing;
using System.Media;
using System.Windows.Forms;

namespace BrickBreaker
{
    public class Ball
    {
        public float x, y, xSpeed, ySpeed, size;
        public Color colour;

        public static Random rand = new Random();

        public Ball(float _x, float _y, float _xSpeed, float _ySpeed, float _ballSize)
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
                int[] colEdgesMove;
                int[] colEdgesBrick;
                int distX;
                int distY;
                double timeX;
                double timeY;
                if (GameScreen.pU2 == false)
                {
                    if (xSpeed > 0)
                    {
                        if (ySpeed > 0)
                        {
                            colEdgesMove = new int[] { (int)ballRec.Right, (int)ballRec.Bottom };
                            colEdgesBrick = new int[] { (int)blockRec.Left, (int)blockRec.Top };
                            distX = Math.Abs(colEdgesBrick[0] - colEdgesMove[0]);
                            distY = Math.Abs(colEdgesBrick[1] - colEdgesMove[1]);
                            timeX = Math.Abs((double)distX / xSpeed);
                            timeY = Math.Abs((double)distY / ySpeed);
                            if (timeX > timeY)
                                ySpeed *= -1;
                            else if (timeY > timeX)
                                xSpeed *= -1;
                            else
                                Console.WriteLine("Collided at a corner");
                        }
                        else
                        {
                            colEdgesMove = new int[] { (int)ballRec.Right, (int)ballRec.Top };
                            colEdgesBrick = new int[] { (int)blockRec.Left, (int)blockRec.Bottom };
                            distX = Math.Abs(colEdgesBrick[0] - colEdgesMove[0]);
                            distY = Math.Abs(colEdgesBrick[1] - colEdgesMove[1]);
                            timeX = Math.Abs((double)distX / xSpeed);
                            timeY = Math.Abs((double)distY / ySpeed);
                            if (timeX > timeY)
                                ySpeed *= -1;
                            else if (timeY > timeX)
                                xSpeed *= -1;
                            else
                                Console.WriteLine("Collided at a corner");
                        }
                    }
                    else
                    {
                        if (ySpeed > 0)
                        {
                            colEdgesMove = new int[] { (int)ballRec.Left, (int)ballRec.Bottom };
                            colEdgesBrick = new int[] { (int)blockRec.Right, (int)blockRec.Top };
                            distX = Math.Abs(colEdgesBrick[0] - colEdgesMove[0]);
                            distY = Math.Abs(colEdgesBrick[1] - colEdgesMove[1]);
                            timeX = Math.Abs((double)distX / xSpeed);
                            timeY = Math.Abs((double)distY / ySpeed);
                            if (timeX > timeY)
                                ySpeed *= -1;
                            else if (timeY > timeX)
                                xSpeed *= -1;
                            else
                                Console.WriteLine("Collided at a corner");
                        }
                        else
                        {
                            colEdgesMove = new int[] { (int)ballRec.Left, (int)ballRec.Top };
                            colEdgesBrick = new int[] { (int)blockRec.Right, (int)blockRec.Bottom };
                            distX = Math.Abs(colEdgesBrick[0] - colEdgesMove[0]);
                            distY = Math.Abs(colEdgesBrick[1] - colEdgesMove[1]);
                            timeX = Math.Abs((double)distX / xSpeed);
                            timeY = Math.Abs((double)distY / ySpeed);
                            if (timeX > timeY)
                                ySpeed *= -1;
                            else if (timeY > timeX)
                                xSpeed *= -1;
                            else
                                Console.WriteLine("Collided at a corner");
                        }
                    }
                }
            }
            return blockRec.IntersectsWith(ballRec);
        }

        public String PaddleCollision(Paddle p)
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
                return ("\\Resources\\Paddlesound.wav");
            }
            return ("");
        }

        public String WallCollision(UserControl UC)
        {
            // Collision with left wall
            if (x < 0+130)
            {
                x = 0+130;
                xSpeed *= -1;
                return ("\\Resources\\Wallhitsound.wav");

            }
            // Collision with right wall
            if (x > (UC.Width - size - 130))
            {
                x = UC.Width - size - 130;
                xSpeed *= -1;
                return ("\\Resources\\Wallhitsound.wav");

            }
            // Collision with top wall
            if (y < 0)
            {
                y = 0;
                ySpeed *= -1;
                return ("\\Resources\\Wallhitsound.wav");

            }
            return ("");
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
