/*  Created by: Team 2!
 *  Project: Brick Breaker
 *  Date: 
 */
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Media;
using System.Drawing.Drawing2D;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ToolTip;

namespace BrickBreaker
{
    public partial class GameScreen : UserControl
    {
        #region global values

        //player1 button control keys - DO NOT CHANGE
        Boolean leftArrowDown, rightArrowDown;

        // Game values
        int lives;
        int levelNumber = 0;

        // Paddle and Ball objects
        Paddle paddle = new Paddle(0, 0, 0, 0, 0, Color.White);
        Ball ball;

        // list of all blocks for current level
        List<Block> blocks = new List<Block>();

        // Brushes
        SolidBrush paddleBrush = new SolidBrush(Color.White);
        SolidBrush ballBrush = new SolidBrush(Color.White);

        GraphicsPath paddleCircle = new GraphicsPath();
        GraphicsPath ballCircle = new GraphicsPath();
        Region ballRegion = new Region();
        Region leftPaddleRegion = new Region();
        Region rightPaddleRegion = new Region();

        Region[] checkRegions = new Region[] { null, null, null, null };

        bool restartLevel = false;

        //cursor Pos

        public static int lastCursorX;


        // slow mode (testing)

        bool slow;

        //mouse move
        bool mouseMoving = false;

        //debuff list

        public static List<Debuff> debuffs = new List<Debuff>();

        // debuff collected

        public static bool debuffCollected = false;

        public static Debuff SDC;

        // debuff? which one

        public static bool dB1, dB2, dB3, dB4, dB5 = false;

        float mirroredBallX;

        int mirroredPaddleX;

        int duration1, duration2, duration3, duration4, duration5;

        //bouncing off side of paddle
        float slope;
        bool leftCircleCollision = false;
        bool rightCircleCollision = false;

        PointF prevPosition;

        List<Rectangle> debuff1 = new List<Rectangle>();
        #endregion

        public GameScreen()
        {
            InitializeComponent();
            OnStart();
        }


        public void OnStart()
        {
            Cursor.Hide();
            //set life counter
            lives = 4;

            //set all button presses to false.
            leftArrowDown = rightArrowDown = false;

            // setup starting paddle values and create paddle object
            paddle = new Paddle((this.Width / 2) - (paddle.width / 2), this.Height - paddle.height - 60, 80, 20, 8, Color.White);

            updateCurve();

            // setup starting ball values
            int ballX = this.Width / 2 - 10;
            int ballY = this.Height - paddle.height - 80;

            // Creates a new ball
            int speedMod = 2;
            float xSpeed = 15 * speedMod;
            float ySpeed = -3 * speedMod;
            int ballSize = 20;
            ball = new Ball(ballX, ballY, Convert.ToInt16(xSpeed), Convert.ToInt16(ySpeed), ballSize);

            updateBallStorage();

            // start the game engine loop


            if (debuffs.Count != 0)
            {
                debuffs.Clear();
            }
            dB1 = false;
            dB2 = false;
            dB3 = false;
            dB4 = false;
            dB5 = false;


            gameTimer.Enabled = true;

        }

        private void GameScreen_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            //player 1 button presses
            switch (e.KeyCode)
            {
                case Keys.Left:
                    leftArrowDown = true;
                    break;
                case Keys.Right:
                    rightArrowDown = true;
                    break;
                case Keys.K:
                    slow = true;
                    break;
                case Keys.Space:
                    if (!restartLevel)
                    {
                        restartLevel = true;
                    }
                    break;
                default:
                    break;
            }

        }


        private void GameScreen_KeyUp(object sender, KeyEventArgs e)
        {
            //player 1 button releases
            switch (e.KeyCode)
            {
                case Keys.Left:
                    leftArrowDown = false;
                    break;
                case Keys.Right:
                    rightArrowDown = false;
                    break;
                case Keys.Escape:
                    Application.Exit();
                    break;
                case Keys.K:
                    slow = false;
                    break;
                default:
                    break;
            }
        }

        private void gameTimer_Tick(object sender, EventArgs e)
        {
            if (blocks.Count() == 0)
            {
                levelNumber++;
                blocks =  Block.LevelChanger(levelNumber, this.Size);
            }
            Point mouse = this.PointToClient(Cursor.Position);

            int brickTime = 0;
            // Arrow key movements
            if (leftArrowDown && paddle.x > 20)
            {
                paddle.Move("left");
                updateCurve();
                mouseMoving = false;
            }
            if (rightArrowDown && paddle.x < (this.Width - paddle.width - 20))
            {
                paddle.Move("right");
                updateCurve();
                mouseMoving = false;
            }

            //mouse movement
            if (!mouseMoving)
            {
                Cursor.Position = this.PointToScreen(new Point(paddle.x + (paddle.width / 2), paddle.y + (paddle.height / 2)));
            }
            else
            {
                paddle.x = mouse.X - (paddle.width / 2);
                updateCurve();

                if (mouse.X < paddle.width / 2 + 20)
                {
                    Cursor.Position = this.PointToScreen(new Point(0 + paddle.width / 2 + 20, paddle.y + paddle.height / 2));
                }

                if (mouse.X > this.Width - paddle.width / 2 - 20)
                {
                    Cursor.Position = this.PointToScreen(new Point(this.Width - paddle.width / 2 - 20, paddle.y + paddle.height / 2));
                }
            }

            if (!restartLevel)
            {
                ball.x = paddle.x + (paddle.width / 2) - (ball.size / 2);
                ball.y = paddle.y - 25;
            }
            else //game running loop
            {
                brickTime = 0;

                // Move ball
                ball.Move();

                // Check for collision with top and side walls
                ball.WallCollision(this);

                // Check for ball hitting bottom of screen
                if (ball.BottomCollision(this))
                {
                    SoundPlayer lifesubtracted = new SoundPlayer(Properties.Resources.lifesubtracted);
                    ball.ySpeed *= -1;
                    lives--;
                    restartLevel = false;
                    lifesubtracted.Play();

                    // Moves the ball back to origin
                    ball.x = ((paddle.x - (ball.size / 2)) + (paddle.width / 2));
                    ball.y = (this.Height - paddle.height) - 85;

                    if (lives == 0)
                    {
                        gameTimer.Enabled = false;
                        OnEnd();
                    }
                }

                updateBallStorage();
                slope = derivitive();

                
                //slope momentum bounces
                if (leftCircleCollision)
                {
                    float momentumPercent = 1 - (slope / 100) - (paddle.speed / 2);
                    float yMultiplier = 1 - momentumPercent;
                    ball.ySpeed -= -1 * yMultiplier;
                    ball.xSpeed -= -1 * momentumPercent;
                }
                if (rightCircleCollision)
                {
                    float momentumPercent = 1 - (slope / 100) - (paddle.speed / 2);
                    float yMultiplier = 1 - momentumPercent;
                    ball.ySpeed += -1 * yMultiplier;
                    ball.xSpeed += -1 * momentumPercent;
                }
                //attempt at using angle between vectors to calculate new vector
                /*
                //calculates angle between ball vector and derivative using dot product of vectors
                if (leftCircleCollision || rightCircleCollision)
                {
                    PointF newDirection = new PointF();
                    double taco = Math.Acos((ball.xSpeed + (ball.ySpeed * slope)) / (Math.Sqrt(Math.Pow(ball.xSpeed, 2) + Math.Pow(ball.ySpeed, 2)) * Math.Sqrt(Math.Pow(slope, 2) + 1)));
                    double theta = Math.Atan2(ball.ySpeed - slope, ball.xSpeed - 1);

                    if (theta > 90)
                    {
                        theta = 180 - theta;
                    }
                    theta *= Math.PI / 180;
                    float colX = ball.x + ball.size - paddle.x;
                    float colY = (float)Math.Sqrt(400 - Math.Pow(colX, 2));

                    if (leftCircleCollision) //left collision
                    {
                        if (ball.xSpeed > 0 && ball.ySpeed > 0)
                        {
                            if (theta < Math.PI / 2)
                                newDirection = Block.RotatePoint(prevPosition, new PointF(colX, colY), 2 * theta); //rotate cc
                            else
                                newDirection = Block.RotatePoint(prevPosition, new PointF(colX, colY), 360 - (2 * theta)); //rotate ccw
                        }
                        else if (ball.xSpeed < 0 && ball.ySpeed > 0)
                        {
                            if (theta < Math.PI / 2)
                                newDirection = Block.RotatePoint(prevPosition, new PointF(colX, colY), 360 - (2 * theta)); //rotate cc
                            else
                                newDirection = Block.RotatePoint(prevPosition, new PointF(colX, colY), 2 * theta); //rotate ccw
                        }
                    }
                    else //rotate clocklwise
                    {
                        if (ball.xSpeed < 0 && ball.ySpeed > 0)
                        {
                            if (theta < Math.PI / 2)
                                newDirection = Block.RotatePoint(prevPosition, new PointF(colX, colY), 2 * theta); //rotate cc
                            else
                                newDirection = Block.RotatePoint(prevPosition, new PointF(colX, colY), 360 - (2 * theta)); //rotate ccw
                        }
                        else if (ball.xSpeed > 0 && ball.ySpeed > 0)
                        {
                            if (theta < Math.PI / 2)
                                newDirection = Block.RotatePoint(prevPosition, new PointF(colX, colY), 360 - (2 * theta)); //rotate cc
                            else
                                newDirection = Block.RotatePoint(prevPosition, new PointF(colX, colY), 2 * theta); //rotate ccw
                        }
                    }
                    ball.xSpeed = -(newDirection.X - colX);
                    ball.ySpeed = -(newDirection.Y - colY);
                }
                */

                //speed capping code
                const float MAXSPEED = 18;
                const float MINSPEED = 5;

                if (Math.Abs(ball.xSpeed) < MINSPEED && Math.Abs(ball.ySpeed) < MINSPEED) //makes really slow balls less slow
                {
                    while (Math.Abs(ball.xSpeed) < MINSPEED|| Math.Abs(ball.ySpeed) < MINSPEED)
                    {
                        ball.xSpeed *= (float)1.25;
                        ball.ySpeed *= (float)1.25;
                    }
                }

                while (Math.Abs(ball.xSpeed) > MAXSPEED || Math.Abs(ball.ySpeed) > MAXSPEED) //makes really fast balls less fast
                {
                    if (Math.Abs(ball.xSpeed) > MAXSPEED)
                    {
                        float diff = MAXSPEED / ball.xSpeed;
                        ball.xSpeed *= Math.Abs(diff);
                        ball.ySpeed *= Math.Abs(diff);
                    }
                    if (Math.Abs(ball.ySpeed) > MAXSPEED)
                    {
                        float diff = MAXSPEED / ball.ySpeed;
                        ball.xSpeed *= Math.Abs(diff);
                        ball.ySpeed *= Math.Abs(diff);
                    }
                }

                if (Math.Abs(ball.ySpeed) < MINSPEED)
                {
                    float diff = MINSPEED / ball.ySpeed;
                    ball.ySpeed *= Math.Abs(diff);
                }
                

                // Check for collision of ball with paddle, (incl. paddle movement)
                ball.PaddleCollision(paddle);
                SoundPlayer brickbroken = new SoundPlayer(Properties.Resources.brickbroken);

                // Check if ball has collided with any blocks
                foreach (Block b in blocks)
                {
                    if (brickTime == 0)
                    {
                        if (ball.BlockCollision(b))
                        {
                            b.hp--;
                            if (b.hp == 0)
                            {
                                blocks.Remove(b);
                            }
                            else
                            {
                                b.currentTexture++;
                                b.texture = b.textures[b.currentTexture];
                            }
                            brickTime = 20;
                            if (blocks.Count == 0)
                            {
                                gameTimer.Enabled = false;
                                OnEnd();
                            }

                            break;
                        }
                    }
                }
            }


            #region Debuff Area
            foreach (Debuff d in debuffs)
            {
                d.PaddleCollision(paddle, d);
            }
            if (debuffCollected)
            {
                debuffs.Remove(SDC);
                debuffCollected = false;
            }


            if (slow)
            {
                gameTimer.Interval = 200;
            }
            else
            {
                gameTimer.Interval = 1;
            }

            brickTime--;

            if (debuffs.Count != 0)
            {
                foreach (Debuff d in debuffs)
                {
                    d.Spawn();
                }
                for (int i = 0; i < debuffs.Count; i++)
                {
                    if (debuffs[i].y > this.Bottom)
                    {
                        debuffs.RemoveAt(i);
                    }
                }
            }

            //debuffs

            if (dB1)
            {
                duration1++;
                if (duration1 < 300)
                {
                    Random rand = new Random();
                    Rectangle newRec = new Rectangle(rand.Next(1, this.Width - 20), rand.Next(1, this.Height - 20), 40, 40);
                    debuff1.Add(newRec);
                }
                else if (duration1 < 600)
                {
                    try
                    {
                        debuff1.RemoveAt(debuff1.Count - 1);
                    }
                    catch
                    {
                        debuff1.Clear();
                    }

                }
                else
                {
                    duration1 = 0;
                    dB1 = false;
                }


            }

            if (dB2)
            {

            }

            if (dB3)
            {
                //send to game over screen in future
                dB3 = false;
                Application.Exit();
            }

            if (dB4)
            {

            }

            if (dB5)
            {
                duration5++;
                if (duration5 < 1000)
                {
                    //mirror ball
                    mirroredBallX = this.Width - ball.x - ball.size;
                    //mirror paddle
                    mirroredPaddleX = this.Width - paddle.x - paddle.width;
                }
                else
                {
                    dB5 = false;
                    duration5 = 0;
                }

            }


            #endregion

            brickTime--;
            prevPosition = new PointF(ball.x, ball.y);
            Refresh();
        }

        private float derivitive()
        {
            //bounce curve modelled in desmos, which can be found here: "https://www.desmos.com/calculator/emiewzq0xk"
            using (Graphics e = this.CreateGraphics())
            {
                if (ball.x < paddle.x + (paddle.width / 2)) //checks for left collision
                {
                    checkRegions[0] = ballRegion;
                    checkRegions[1] = leftPaddleRegion;
                    checkRegions[0].Intersect(checkRegions[1]);

                    if (!checkRegions[0].IsEmpty(e))
                    {
                        float x = ball.x + ball.size - paddle.x;
                        leftCircleCollision = true;

                        slope = (float)(-x / Math.Sqrt(400 - Math.Pow(x, 2)));
                        return slope;
                    }
                }
                else //checks for right collision
                {
                    checkRegions[0] = ballRegion;
                    checkRegions[1] = rightPaddleRegion;
                    checkRegions[0].Intersect(checkRegions[1]);

                    if (!checkRegions[0].IsEmpty(e))
                    {
                        float x = ball.x - (paddle.x + paddle.width);
                        rightCircleCollision = true;

                        slope = (float)(-x / Math.Sqrt(400 - Math.Pow(x, 2)));
                        return slope;
                    }
                }
                leftCircleCollision = false;
                rightCircleCollision = false;
                return 1;
            }
        }
        private void updateCurve()
        {
            paddleCircle.Reset();
            leftPaddleRegion.Dispose();
            paddleCircle.AddEllipse(paddle.x - 20, paddle.y, 40, 40);
            leftPaddleRegion = new Region(paddleCircle);
            leftPaddleRegion.Exclude(new Rectangle(paddle.x - 20, paddle.y + 20, 40, 20));
            leftPaddleRegion.Exclude(new Rectangle(paddle.x, paddle.y, 20, 20));

            paddleCircle.Reset();
            rightPaddleRegion.Dispose();
            paddleCircle.AddEllipse(paddle.x + paddle.width - 20, paddle.y, 40, 40);
            rightPaddleRegion = new Region(paddleCircle);
            rightPaddleRegion.Exclude(new Rectangle(paddle.x + paddle.width - 20, paddle.y + 20, 40, 20));
            rightPaddleRegion.Exclude(new Rectangle(paddle.x + paddle.width - 20, paddle.y, 20, 20));
        }

        public void updateBallStorage()
        {
            ballCircle.Reset();
            ballRegion.Dispose();

            ballCircle.AddRectangle(new RectangleF(ball.x, ball.y, ball.size, ball.size));
            ballRegion = new Region(ballCircle);
        }

        public void OnEnd()
        {
            // Goes to the game over screen
            Form form = this.FindForm();
            MenuScreen ps = new MenuScreen();

            ps.Location = new Point((form.Width - ps.Width) / 2, (form.Height - ps.Height) / 2);

            form.Controls.Add(ps);
            form.Controls.Remove(this);

        }

        private void GameScreen_MouseDown(object sender, MouseEventArgs e)
        {
            mouseMoving = true;
        }

        public void GameScreen_Paint(object sender, PaintEventArgs e)
        {
            UIPaint.PaintTransRectangle(e.Graphics, Color.White, new Rectangle(0, 0, 128, this.Height), 50);
            UIPaint.PaintTransRectangle(e.Graphics, Color.White, new Rectangle(this.Width - 128, 0, 128, this.Height), 50);

            UIPaint.PaintText(e.Graphics, "Level 1", 24, new Point(this.Width - 120,  90), Color.Goldenrod);
            Image heartImage = Properties.Resources.heart1;
            Point lifePos = new Point(this.Width - heartImage.Width -25, 25);
            switch (lives)
            {
                
                case 1:
                    e.Graphics.DrawImage(Properties.Resources.heart1, lifePos);
                    break;
                case 2:
                    e.Graphics.DrawImage(Properties.Resources.heart2, lifePos);
                    break;
                case 3:
                    e.Graphics.DrawImage(Properties.Resources.heart3, lifePos);
                    break;
                case 4:
                    e.Graphics.DrawImage(Properties.Resources.heart4, lifePos);
                    break;
                case 5:
                    e.Graphics.DrawImage(Properties.Resources.heart5, lifePos);
                    break;
                case 6:
                    e.Graphics.DrawImage(Properties.Resources.heart6, lifePos);
                    break;
                default:
                    e.Graphics.DrawImage(Properties.Resources.heart6, lifePos);
                    break;
            }
            UIPaint.PaintText(e.Graphics, lives + "", 24, new Point(this.Width - 55, 50), Color.Red);


            // Draws paddle
            paddleBrush.Color = paddle.colour;
            e.Graphics.FillRectangle(paddleBrush, paddle.x, paddle.y, paddle.width, paddle.height);

            e.Graphics.FillRegion(Brushes.Red, leftPaddleRegion);
            e.Graphics.FillRegion(Brushes.Red, rightPaddleRegion);

            Block.PaintBlocks(e.Graphics, blocks);

            foreach (Debuff d in debuffs)
            {
                if (d.y < this.Bottom)
                {
                    e.Graphics.DrawRectangle(Pens.White, d.x, d.y, 10, 10);
                }
            }

            // Draws ball
            e.Graphics.FillEllipse(ballBrush, ball.x, ball.y, ball.size, ball.size);

            if (dB5)
            {
                e.Graphics.FillEllipse(ballBrush, mirroredBallX, ball.y, ball.size, ball.size);

                //fix paddle shape

                e.Graphics.FillRectangle(paddleBrush, mirroredPaddleX, paddle.y, paddle.width, paddle.height);

                e.Graphics.FillRegion(paddleBrush, leftPaddleRegion);
                e.Graphics.FillRegion(paddleBrush, rightPaddleRegion);
            }

            if (dB1)
            {
                foreach (Rectangle r in debuff1)
                {
                    e.Graphics.FillEllipse(Brushes.White, r.X, r.Y, r.Width, r.Height);
                }

            }


            // e.Graphics.FillEllipse(ballBrush, ball.x, ball.y, ball.size, ball.size);
            e.Graphics.FillRegion(Brushes.LightBlue, ballRegion);
            // test
            e.Graphics.DrawRectangle(Pens.White, ball.x, ball.y, ball.size, ball.size);
        }
    }
}
