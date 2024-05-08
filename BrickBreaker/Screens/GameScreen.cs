﻿/*  Created by: Team 2!
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

namespace BrickBreaker
{
    public partial class GameScreen : UserControl
    {
        #region global values

        //player1 button control keys - DO NOT CHANGE
        Boolean leftArrowDown, rightArrowDown;

        // Game values
        int lives;

        // Paddle and Ball objects
        Paddle paddle = new Paddle(0, 0, 0, 0, 0, Color.White);
        Paddle lowerPaddle;
        Ball ball;

        // list of all blocks for current level
        List<Block> blocks = new List<Block>();

        // Brushes
        SolidBrush paddleBrush = new SolidBrush(Color.White);
        SolidBrush ballBrush = new SolidBrush(Color.White);
        SolidBrush blockBrush = new SolidBrush(Color.Red);

        GraphicsPath paddleCircle = new GraphicsPath();
        Region leftPaddleRegion = new Region();
        Region rightPaddleRegion = new Region();

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

        int mirroredBallX;

        int mirroredPaddleX;

        int mirroredLowerPaddleX;

        int duration;
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
            lives = 3;

            //set all button presses to false.
            leftArrowDown = rightArrowDown = false;

            // setup starting paddle values and create paddle object
            paddle = new Paddle((this.Width / 2) - (paddle.width / 2), this.Height - paddle.height - 60, 80, 10, 8, Color.White);
            lowerPaddle = new Paddle(paddle.x - 10, paddle.y + 10, paddle.width + 20, paddle.height, paddle.speed, Color.White);

            updateCurve();

            // setup starting ball values
            int ballX = this.Width / 2 - 10;
            int ballY = this.Height - paddle.height - 80;

            // Creates a new ball
            float xSpeed = 5;
            float ySpeed = 1;
            int ballSize = 20;
            ball = new Ball(ballX, ballY, Convert.ToInt16(xSpeed), Convert.ToInt16(ySpeed), ballSize);

            #region Creates blocks for generic level. Need to replace with code that loads levels.

            //TODO - replace all the code in this region eventually with code that loads levels from xml files

            blocks.Clear();
            int x = 10;

            while (blocks.Count < 12)
            {
                x += 57;
                Block b1 = new Block(x, 10, 1, Color.White);
                blocks.Add(b1);
            }

            #endregion

            // start the game engine loop
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
            Point mouse = this.PointToClient(Cursor.Position);

            int brickTime = 0;
            // Move the paddle
            if (leftArrowDown && lowerPaddle.x > 1)
            {
                paddle.Move("left");
                lowerPaddle.Move("left");
                updateCurve();
                mouseMoving = false;
            }
            if (rightArrowDown && paddle.x < (this.Width - lowerPaddle.width + 9))
            {
                paddle.Move("right");
                lowerPaddle.Move("right");
                updateCurve();
                mouseMoving = false;
            }


            if (!mouseMoving)
            {
                Cursor.Position = this.PointToScreen(new Point(paddle.x + (paddle.width / 2), paddle.y + (paddle.height / 2)));
            }
            else
            {
                paddle.x = mouse.X - (paddle.width / 2);
                lowerPaddle.x = paddle.x - 10;
                updateCurve();

                if (mouse.X < 0 + lowerPaddle.width / 2)
                {
                    Cursor.Position = this.PointToScreen(new Point(0 + lowerPaddle.width / 2, paddle.y + paddle.height / 2));
                }

                if (mouse.X > this.Width - lowerPaddle.width / 2)
                {
                    Cursor.Position = this.PointToScreen(new Point(this.Width - lowerPaddle.width / 2, paddle.y + paddle.height / 2));
                }
            }


            //funny mode
            //Random random = new Random();

            //if (random.Next(1, 1000000) == 10)
            //{
            //    ball.xSpeed = 30;
            //    ball.ySpeed = 0;
            //}



            // Move ball
            ball.Move();

            // Check for collision with top and side walls
            ball.WallCollision(this);

            // Check for ball hitting bottom of screen
            if (ball.BottomCollision(this))
            {
                lives--;

                // Moves the ball back to origin
                ball.x = ((paddle.x - (ball.size / 2)) + (paddle.width / 2));
                ball.y = (this.Height - paddle.height) - 85;

                if (lives == 0)
                {
                    gameTimer.Enabled = false;
                    OnEnd();
                }
            }

            // Check for collision of ball with paddle, (incl. paddle movement)
            ball.PaddleCollision(paddle);

            // Check if ball has collided with any blocks
            foreach (Block b in blocks)
            {
                if (brickTime == 0)
                {
                    if (ball.BlockCollision(b))

                    {
                        blocks.Remove(b);

                        brickTime = 3;

                        if (blocks.Count == 0)
                        {
                            gameTimer.Enabled = false;
                            OnEnd();
                        }

                        break;
                    }
                }
            }

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
                    if(debuffs[i].y > this.Bottom)
                    {
                        debuffs.RemoveAt(i);
                    }
                }
            }

            //debuffs

            if (dB1)
            {

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
                duration++;
                if (duration < 3000)
                {
                    //mirror ball
                    mirroredBallX = this.Width - ball.x - ball.size;
                    //mirror paddle
                    mirroredPaddleX = this.Width - paddle.x - paddle.width;

                    mirroredLowerPaddleX = mirroredPaddleX - 10;
                }
                else
                {
                    dB5 = false;
                    duration = 0;
                }
                
            }
                


            //redraw the screen
            Refresh();
        }

        private void updateCurve()
        {
            paddleCircle.Reset();
            leftPaddleRegion.Dispose();
            paddleCircle.AddEllipse(lowerPaddle.x, paddle.y, 20, 20);
            leftPaddleRegion = new Region(paddleCircle);
            leftPaddleRegion.Exclude(new Rectangle(lowerPaddle.x, lowerPaddle.y, 20, 10));
            leftPaddleRegion.Exclude(new Rectangle(paddle.x, paddle.y, 10, 10));

            paddleCircle.Reset();
            rightPaddleRegion.Dispose();
            paddleCircle.AddEllipse(paddle.x + paddle.width - 10, paddle.y, 20, 20);
            rightPaddleRegion = new Region(paddleCircle);
            rightPaddleRegion.Exclude(new Rectangle(paddle.x + paddle.width - 10, paddle.y + 10, 20, 10));
            rightPaddleRegion.Exclude(new Rectangle(paddle.x + paddle.width - 10, paddle.y, 10, 10));
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
            // Draws paddle
            paddleBrush.Color = paddle.colour;
            e.Graphics.FillRectangle(paddleBrush, paddle.x, paddle.y, paddle.width, paddle.height);
            e.Graphics.FillRectangle(paddleBrush, lowerPaddle.x, lowerPaddle.y, lowerPaddle.width, lowerPaddle.height);

            e.Graphics.FillRegion(paddleBrush, leftPaddleRegion);
            e.Graphics.FillRegion(paddleBrush, rightPaddleRegion);

            // Draws blocks
            foreach (Block b in blocks)
            {
                e.Graphics.FillRectangle(blockBrush, b.x, b.y, b.width, b.height);
            }

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
                e.Graphics.FillRectangle(paddleBrush, mirroredLowerPaddleX, lowerPaddle.y, lowerPaddle.width, lowerPaddle.height);

                e.Graphics.FillRegion(paddleBrush, leftPaddleRegion);
                e.Graphics.FillRegion(paddleBrush, rightPaddleRegion);
            }
            



            // test
            e.Graphics.DrawRectangle(Pens.White, ball.x, ball.y, ball.size, ball.size);
        }
    }
}
