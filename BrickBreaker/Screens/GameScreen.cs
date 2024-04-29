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

        int lastCursorX, lastCursorY;

        #endregion

        public GameScreen()
        {
            InitializeComponent();
            OnStart();
        }


        public void OnStart()
        {
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
            int xSpeed = 6;
            int ySpeed = 6;
            int ballSize = 20;
            ball = new Ball(ballX, ballY, xSpeed, ySpeed, ballSize);

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
                default:
                    break;
            }
        }

        private void gameTimer_Tick(object sender, EventArgs e)
        {
            // Move the paddle
            if (leftArrowDown && lowerPaddle.x > 0)
            {
                paddle.Move("left");
                lowerPaddle.Move("left");
                updateCurve();
            }
            if (rightArrowDown && paddle.x < (this.Width - lowerPaddle.width))
            {
                paddle.Move("right");
                lowerPaddle.Move("right");
                updateCurve();
            }

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
                if (ball.BlockCollision(b))
                {
                    blocks.Remove(b);

                    if (blocks.Count == 0)
                    {
                        gameTimer.Enabled = false;
                        OnEnd();
                    }

                    break;
                }
            }

            //cursorPos -- I made this! yippee

            lastCursorX = Cursor.Position.X;
            lastCursorY = Cursor.Position.Y;

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

            // Draws ball
            e.Graphics.FillRectangle(ballBrush, ball.x, ball.y, ball.size, ball.size);
        }
    }
}
