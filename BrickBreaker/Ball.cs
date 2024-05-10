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
                int[] colEdgesMove;
                int[] colEdgesBrick;
                int distX;
                int distY;
                double timeX;
                double timeY;
                if (xSpeed > 0)
                {
                    if (ySpeed > 0)
                    {
                        colEdgesMove = new int[] { (int)ballRec.Right, (int)ballRec.Bottom};
                        colEdgesBrick = new int[] { (int)blockRec.Left, (int)blockRec.Top};
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
                        colEdgesMove = new int[] { (int)ballRec.Right, (int)ballRec.Top};
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





            //if (ballRec.IntersectsWith(blockRec))
            //{
            //    if ((x < b.hitBox.X - size + 8 || x > b.hitBox.X + b.hitBox.Width - 8) && (y > b.hitBox.Y - size || y < b.hitBox.Y + b.hitBox.Width - 8))
            //    {
            //        if (xSpeed > 0)
            //        {
            //            x = b.hitBox.X - size;
            //        }
            //        else
            //        {
            //            x = b.hitBox.X + b.hitBox.Width;
            //        }
            //        xSpeed *= -1;
            //    }
            //    else if (x > b.hitBox.X - size - 8 || x < b.hitBox.X + b.hitBox.Width - 8)
            //    {
            //        if (ySpeed > 0)
            //        {
            //            y = b.hitBox.Y - size;
            //        }
            //        else
            //        {
            //            y = blockRec.Y + blockRec.Height;
            //        }
            //        ySpeed *= -1;
            //    }
            //    int chance = 101;
            //    if (rand.Next(1, 100)  <= chance)
            //    {
            //        int check = rand.Next(1, 100);
            //        int o = 0;
            //
            //        if (check > 10 && check < 20)
            //        {
            //            o = 1;
            //        }
            //        else if (check > 20 && check < 50)
            //        {
            //            o = 2;
            //        }
            //        else if (check == 50)
            //        {
            //            o = 3;
            //        }
            //        else if (check > 51 && check < 62)
            //        {
            //            o = 4;
            //        }
            //        else 
            //        {
            //            o = 5;
            //        }
            //
            //        Debuff newDebuff = new Debuff(o, (int)blockRec.X + (int)blockRec.Width / 2, (int)blockRec.Y + (int)blockRec.Width);
            //
            //        GameScreen.debuffs.Add(newDebuff);
            //    }
            //}
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
