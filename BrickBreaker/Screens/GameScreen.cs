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
        int levelNumber = 1;
        Score score;
        List<string> comboAdds = new List<string>();
        int scoreAngle = 0;
        int scoreDirection = 1;
        int scoreSize = 50;

        // Paddle and Ball objects
        Paddle paddle = new Paddle(0, 0, 0, 0, 0, Color.White);
        Ball ball;
        float paddleWidth = 80;

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

        Region mirroredLeftPaddleRegion = new Region();
        Region mirroredRightPaddleRegion = new Region();
        GraphicsPath mirroredPaddleCircle = new GraphicsPath();

        Region[] checkRegions = new Region[] { null, null, null, null };

        bool isCaught = true;

        //cursor Pos

        public static int lastCursorX;


        //slow mode (testing)

        bool slow;

        int TopXPos = 0;
        int turnCount = 0;

        bool moveRight = false;
        bool moveLeft = false;

        bool trackPos = true;


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
        int vineLocatoin = 130;
        int grow;

        //bouncing off side of paddle
        float slope;
        bool leftCircleCollision = false;
        bool rightCircleCollision = false;

        //RANOM
        Random rand = new Random();

        //whiteboy
        PictureBox whiteBoy = new PictureBox();

        List<PictureBox> debuff1 = new List<PictureBox>();

        // list of balls

        List<Ball> freakyBalls = new List<Ball>();

        int drawBall;

        bool drawTheBall;

        Color debuffColor;

        //Evil Skull Man

        PictureBox evilSkullMan = new PictureBox();

        int catchDistance = 100;

       public static bool pU1, pU2, pU3, pU4, pU5;

        //powerup durations 

        int pDuration1, pDuration2, pDuration3, pDuration4, pDuration5;
        List<Rectangle> debuff1 = new List<Rectangle>();

        //Grady
        System.Windows.Media.MediaPlayer[] music =
        {
            new System.Windows.Media.MediaPlayer(),
            new System.Windows.Media.MediaPlayer(),
            new System.Windows.Media.MediaPlayer(),
            new System.Windows.Media.MediaPlayer(),
            new System.Windows.Media.MediaPlayer(),
            new System.Windows.Media.MediaPlayer(),
            new System.Windows.Media.MediaPlayer(),
            new System.Windows.Media.MediaPlayer(),
            new System.Windows.Media.MediaPlayer(),
            new System.Windows.Media.MediaPlayer(),
            new System.Windows.Media.MediaPlayer()
        };
        List<System.Windows.Media.MediaPlayer> sounds = new List<System.Windows.Media.MediaPlayer>();
        #endregion

        public GameScreen()
        {
            InitializeComponent();
            blocks = Block.LevelChanger(levelNumber, new Size(Screen.PrimaryScreen.Bounds.Width, Screen.PrimaryScreen.Bounds.Height));
            OnStart();

            music[0].Open(new Uri(Application.StartupPath + "\\Resources\\Idlemusic1.wav"));
            music[1].Open(new Uri(Application.StartupPath + "\\Resources\\Idlemusic2.wav"));
            music[2].Open(new Uri(Application.StartupPath + "\\Resources\\Idlemusic3.wav"));
            music[3].Open(new Uri(Application.StartupPath + "\\Resources\\Idlemusic4.wav"));
            music[4].Open(new Uri(Application.StartupPath + "\\Resources\\Idlemusic5.wav"));
            music[5].Open(new Uri(Application.StartupPath + "\\Resources\\Idlemusic6.wav"));
            music[6].Open(new Uri(Application.StartupPath + "\\Resources\\Idlemusic7.wav"));
            music[7].Open(new Uri(Application.StartupPath + "\\Resources\\Idlemusic8.wav"));
            music[8].Open(new Uri(Application.StartupPath + "\\Resources\\Idlemusic9.wav"));
            music[9].Open(new Uri(Application.StartupPath + "\\Resources\\Idlemusic10.wav"));
            music[10].Open(new Uri(Application.StartupPath + "\\Resources\\Idlemusic11.wav"));

            music[0].MediaEnded += new EventHandler(music0);
            music[1].MediaEnded += new EventHandler(music1);
            music[2].MediaEnded += new EventHandler(music2);
            music[3].MediaEnded += new EventHandler(music3);
            music[4].MediaEnded += new EventHandler(music4);
            music[5].MediaEnded += new EventHandler(music5);
            music[6].MediaEnded += new EventHandler(music6);
            music[7].MediaEnded += new EventHandler(music7);
            music[8].MediaEnded += new EventHandler(music8);
            music[9].MediaEnded += new EventHandler(music9);
            music[10].MediaEnded += new EventHandler(music10);
        }

        private void music0(object sender, EventArgs e)
        {
            music[0].Stop();


            music[0].Play();
        }
        private void music1(object sender, EventArgs e)
        {
            music[1].Stop();


            music[1].Play();
        }
        private void music2(object sender, EventArgs e)
        {
            music[2].Stop();


            music[2].Play();
        }
        private void music3(object sender, EventArgs e)
        {
            music[3].Stop();


            music[3].Play();
        }
        private void music4(object sender, EventArgs e)
        {
            music[4].Stop();


            music[4].Play();
        }
        private void music5(object sender, EventArgs e)
        {
            music[5].Stop();


            music[5].Play();
        }
        private void music6(object sender, EventArgs e)
        {
            music[6].Stop();


            music[6].Play();
        }
        private void music7(object sender, EventArgs e)
        {
            music[7].Stop();


            music[7].Play();
        }
        private void music8(object sender, EventArgs e)
        {
            music[8].Stop();


            music[8].Play();
        }
        private void music9(object sender, EventArgs e)
        {
            music[9].Stop();


            music[9].Play();
        }
        private void music10(object sender, EventArgs e)
        {
            music[10].Stop();


            music[10].Play();
        }
        void PlayMusic()
        {
            //Hi Mr. T! Private Contractor Grady Here!
            TurnMusicOff();
            int indexer = levelNumber % 10;
            music[indexer].Play();
        }

        void TurnMusicOff()
        {
            for (int i = 0; i < music.Length; i++)
            {
                music[i].Stop();
            }
        }

        public void PlaySound(String startUp)
        {

            var sound = new System.Windows.Media.MediaPlayer();

            sound.Open(new Uri(Application.StartupPath + startUp));

            sounds.Add(sound);

            sounds[sounds.Count - 1].Play();

        }

        public void OnStart()
        {
            //pU2 = true;
            //pU1 = true;
            //pU3 = true;
            pU4 = true;
            Cursor.Hide();
            //set life counter
            lives = 4;
            score = new Score(0, 1);

            //set all button presses to false.
            leftArrowDown = rightArrowDown = false;

            // setup starting paddle values and create paddle object
            paddle = new Paddle((this.Width / 2) - ((int)paddle.width / 2), this.Height - paddle.height - 60, paddleWidth, 20, 30, Color.White);

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

            PlayMusic();
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
                case Keys.C:
                    catchMove();
                    break;
                case Keys.Space:
                    if (isCaught)
                    {
                        throwMove();
                        isCaught = false;
                    }
                    break;
                //testing
                case Keys.P:
                    gameTimer.Enabled = false;
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
                //testing
                case Keys.P:
                    gameTimer.Enabled = true;
                    break;
                default:
                    break;
            }
        }

        //  RectangleF prevPosition;

        private void gameTimer_Tick(object sender, EventArgs e)
        {
            if (blocks.Count() == 0)
            {
                levelNumber++;
                blocks =  Block.LevelChanger(levelNumber, this.Size);
                TurnMusicOff();
                PlayMusic();
                sounds.Clear();
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
                Cursor.Position = this.PointToScreen(new Point(paddle.x + ((int)paddle.width / 2), paddle.y + (paddle.height / 2)));
            }
            else
            {
                paddle.x = mouse.X - ((int)paddle.width / 2);
                updateCurve();

                if (mouse.X < paddle.width / 2 + 20)
                {
                    Cursor.Position = this.PointToScreen(new Point(0 + (int)paddle.width / 2 + 20, paddle.y + paddle.height / 2));
                }

                if (mouse.X > this.Width - paddle.width / 2 - 20)
                {
                    Cursor.Position = this.PointToScreen(new Point(this.Width - (int)paddle.width / 2 - 20, paddle.y + paddle.height / 2));
                }
            }

            if (isCaught)
            {
                ball.x = paddle.x + (paddle.width / 2) - (ball.size / 2);
                ball.y = paddle.y - 25;

            }
            else //game running loop
            {
                brickTime = 0;

                // Move ball
                foreach (Ball b in freakyBalls)
                {
                    b.Move();
                }

                ball.Move();


                // Check for collision with top and side walls
                String check = ball.WallCollision(this);
                if (check != "")
                {
                    PlaySound(check);
                }
                
                foreach (Ball b in freakyBalls)
                {
                    b.WallCollision(this);
                }

                ball.WallCollision(this);

                // Check for ball hitting bottom of screen

                if (ball.BottomCollision(this))
                {
                    ball.ySpeed *= -1;
                    lives--;
                    restartLevel = false;
                    PlaySound("\\Resources\\Minecraft Damage (Oof) - Sound Effect (HD).wav");
                    // SoundPlayer lifesubtracted = new SoundPlayer(Properties.Resources.lifesubtracted);
                    score.RemoveCombo();
                    scoreSize = 50;

                    ball.ySpeed *= -1;
                    lives--;
                    isCaught = true;
                    trackPos = true;
                    //lifesubtracted.Play();

                    freakyBalls.Clear();

                    // Moves the ball back to origin
                    ball.x = ((paddle.x - (ball.size / 2)) + (paddle.width / 2));
                    ball.y = (this.Height - paddle.height) - 85;

                    if (lives == 0)
                    {
                        gameTimer.Enabled = false;
                        OnEnd();
                    }


                }

                for (int i = freakyBalls.Count; i > 0; i--)
                {
                    if (freakyBalls[i - 1].y > this.Height)
                    {
                        freakyBalls.RemoveAt(i - 1);
                        lives--;

                        if (lives == 0)
                        {
                            gameTimer.Enabled = false;
                            OnEnd();
                        }
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
                    float momentumPercent = 1 + (slope / 100) - (paddle.speed / 2);
                    float yMultiplier = 1 - momentumPercent;
                    ball.ySpeed += -1 * yMultiplier;
                    ball.xSpeed += -1 * momentumPercent;
                }

                //speed capping code
                const float MAXSPEED = 15;
                const float MINSPEED = 5;

                if (Math.Abs(ball.xSpeed) < MINSPEED && Math.Abs(ball.ySpeed) < MINSPEED) //makes really slow balls less slow
                {
                    while (Math.Abs(ball.xSpeed) < MINSPEED || Math.Abs(ball.ySpeed) < MINSPEED)
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
                 check = ball.PaddleCollision(paddle);
                if (check != "")
                {
                    PlaySound(check);
                }
             
                foreach (Ball b in freakyBalls)
                {
                    b.PaddleCollision(paddle);
                }

                ball.PaddleCollision(paddle);

                // SoundPlayer brickbroken = new SoundPlayer(Properties.Resources.brickbroken);
                // Check if ball has collided with any blocks
                foreach (Block b in blocks)
                {
                    if (brickTime == 0)
                    {
                        if (ball.BlockCollision(b))
                        {
                            PlaySound("\\Resources\\Brick impact debris  _ Sound Effect.wav");
                            comboAdds.Add(100 * score.comboCounter + "");
                            score.AddToScore(100);
                            scoreSize += 1;
                            b.hp--;
                            if (b.hp == 0)
                            {
                                blocks.Remove(b);

                                if(pU3)
                                {
                                    blocks.RemoveAll(Block => b.hitBox.Y == Block.hitBox.Y);
                                }
                                
                                int chance = 40;

                                if (rand.Next(1, 100) <= chance)
                                {
                                    int check = rand.Next(1, 100);
                                    int o = 0;

                                    if (check > 10 && check < 20)
                                    {
                                        o = 1;
                                        debuffColor = Color.Green;
                                    }
                                    else if (check > 20 && check < 50)
                                    {
                                        o = 2;
                                        debuffColor = Color.Pink;
                                    }
                                    else if (check == 50)
                                    {
                                        o = 3;
                                        debuffColor = Color.Black;
                                    }
                                    else if (check > 51 && check < 62)
                                    {
                                        o = 4;
                                        debuffColor = Color.White;
                                    }
                                    else
                                    {
                                        o = 5;
                                        debuffColor = Color.Silver;
                                    }

                                    Debuff newDebuff = new Debuff(o, b.hitBox.X + b.hitBox.Width / 2, b.hitBox.Y + b.hitBox.Width, debuffColor);

                                    debuffs.Add(newDebuff);
                                }
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
                        //comment

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
                gameTimer.Interval = 10;
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
            float widthScale = (float)Screen.PrimaryScreen.Bounds.Width / 1448;
            float heightScale = (float)Screen.PrimaryScreen.Bounds.Height / 700;
            float initalSize = 100 * widthScale;
            if (dB1)
            {
                duration1++;
                if (duration1 < 12)
                {
                    PictureBox vines = new PictureBox();
                    vines.Parent = this;
                    vines.Location = new Point(vineLocatoin, 0);
                    vines.SizeMode = PictureBoxSizeMode.StretchImage;
                    vines.Image = Properties.Resources.IvyVine;
                    //vines.BackColor = Color.Transparent;
                    vines.BringToFront();
                    debuff1.Add(vines);
                    vineLocatoin += (int)initalSize;
                }
                else if (duration1 < 100)
                {
                    foreach (PictureBox p in debuff1)
                    {
                        p.Size = new Size((int)initalSize, grow);
                    }
                    grow += 10;
                }
                else if (duration1 < 200)
                {
                    grow -= 10;
                    foreach (PictureBox p in debuff1)
                    {
                        p.Size = new Size((int)initalSize, grow);
                    }
                }
                else
                {
                    duration1 = 0;
                    dB1 = false;
                    debuff1.Clear();
                    vineLocatoin = 130;
                }


            }

            if (dB2)
            {
                duration2++;
                if (duration2 < 2)
                {
                    for (int i = 0; i < 2; i++)
                    {
                        Ball newBall = new Ball(ball.x, ball.y, rand.Next(-18, 18), rand.Next(-18, 18), ball.size);
                        freakyBalls.Add(newBall);
                    }

                }

                if (duration2 > 200)
                {
                    freakyBalls.Clear();
                    dB2 = false;
                    duration2 = 0;
                }

                if (duration2 % 5 == 0 && drawBall == 1)
                {
                    drawTheBall = false;
                    drawBall = 0;
                }
                else if (duration2 % 5 == 0 && drawBall == 0)
                {
                    drawTheBall = true;
                    drawBall = 1;
                }


            }

            if (dB3)
            {
                //send to game over screen in future
                duration3++;

                if (duration3 > 60 && duration3 < 100)
                {
                    evilSkullMan.Parent = this;
                    evilSkullMan.Location = new Point((this.Width - evilSkullMan.Width) / 2, (this.Height - evilSkullMan.Height) / 2);
                    evilSkullMan.SizeMode = PictureBoxSizeMode.StretchImage;
                    evilSkullMan.Image = Properties.Resources.evilFace;
                    evilSkullMan.Size = new Size((int)(700 * widthScale), (int)(700 * heightScale));
                    evilSkullMan.BringToFront();
                }
                else if (duration3 > 100)
                {
                    duration3 = 0;
                    dB3 = false;
                    Application.Exit();
                }

            }

            if (dB4)
            {
                duration4++;
                if (duration4 < 3)
                {

                    whiteBoy.Parent = this;
                    whiteBoy.Location = new Point((this.Width - whiteBoy.Width) / 2, (this.Height - whiteBoy.Height) / 2);
                    whiteBoy.SizeMode = PictureBoxSizeMode.StretchImage;
                    whiteBoy.Image = Properties.Resources.WhiteBoy;
                    whiteBoy.BringToFront();
                    //play sound
                }
                else if (duration4 < 40 && duration4 > 20)
                {
                    whiteBoy.Visible = true;
                    whiteBoy.Size = new Size((int)(100 * widthScale), (int)(100 * heightScale));
                    whiteBoy.Location = new Point((this.Width - whiteBoy.Width) / 2, (this.Height - whiteBoy.Height) / 2);
                    //play sound
                }
                else if (duration4 < 200 && duration4 > 180)
                {
                    whiteBoy.Visible = true;
                    whiteBoy.Size = new Size((int)(200 * widthScale), (int)(200 * heightScale));
                    whiteBoy.Location = new Point((this.Width - whiteBoy.Width) / 2, (this.Height - whiteBoy.Height) / 2);
                    //play sound
                }
                else if (duration4 < 400 && duration4 > 380)
                {
                    whiteBoy.Visible = true;
                    whiteBoy.Size = new Size((int)(700 * widthScale), (int)(700 * heightScale));
                    whiteBoy.Location = new Point((this.Width - whiteBoy.Width) / 2, (this.Height - whiteBoy.Height) / 2);
                    //play sound
                }
                else
                {
                    whiteBoy.Visible = false;
                }

                if (duration4 > 400)
                {
                    dB4 = false;
                    duration4 = 0;
                }


            }

            if (dB5)
            {
                duration5++;
                if (duration5 < 1000)
                {
                    //mirror ball
                    mirroredBallX = this.Width - ball.x - ball.size;
                    //mirror paddle
                    mirroredPaddleX = this.Width - paddle.x - (int)paddle.width;

                    #region regions
                    mirroredPaddleCircle.Reset();
                    mirroredLeftPaddleRegion.Dispose();
                    mirroredPaddleCircle.AddEllipse(mirroredPaddleX - 20, paddle.y, 40, 40);
                    mirroredLeftPaddleRegion = new Region(mirroredPaddleCircle);
                    mirroredLeftPaddleRegion.Exclude(new Rectangle(mirroredPaddleX - 20, paddle.y + 20, 40, 20));
                    mirroredLeftPaddleRegion.Exclude(new Rectangle(mirroredPaddleX, paddle.y, 20, 20));

                    mirroredPaddleCircle.Reset();
                    mirroredRightPaddleRegion.Dispose();
                    mirroredPaddleCircle.AddEllipse(mirroredPaddleX + paddle.width - 20, paddle.y, 40, 40);
                    mirroredRightPaddleRegion = new Region(mirroredPaddleCircle);
                    mirroredRightPaddleRegion.Exclude(new Rectangle(mirroredPaddleX + (int)paddle.width - 20, paddle.y + 20, 40, 20));
                    mirroredRightPaddleRegion.Exclude(new Rectangle(mirroredPaddleX + (int)paddle.width - 20, paddle.y, 20, 20));
                    #endregion
                }
                else
                {
                    dB5 = false;
                    duration5 = 0;
                }

            }


            #endregion

            #region Power Up Area

            if(pU1)
            {
                pDuration1++;
                if (pDuration1 < 2)
                {
                    paddle.width = paddleWidth * 3;
                }
                else if (pDuration1 < 500)
                {
                    paddle.width -= (float)160/500;
                }
                else
                {
                    paddle.width = paddleWidth;
                    pU1 = false;
                    pDuration1 = 0;
                }
            }
            
            if(pU2)
            {
                pDuration2++;
                if(pDuration2 > 250)
                {
                    pU2 = false;
                    pDuration2 = 0;
                }
            }

            if (pU3)
            {
                pDuration3++;
                if (pDuration3 > 250)
                {
                    pU3 = false;
                    pDuration3 = 0;
                }
            }

            if (pU4)
            {
                pDuration4++;
                if (pDuration4 < 250)
                {
                    ball.size = 30;
                }
                else
                {
                    ball.size = 20;
                    pU4 = false;
                    pDuration4= 0;
                }
            }



            #endregion



            brickTime--;

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
            rightPaddleRegion.Exclude(new Rectangle(paddle.x + (int)paddle.width - 20, paddle.y + 20, 40, 20));
            rightPaddleRegion.Exclude(new Rectangle(paddle.x + (int)paddle.width - 20, paddle.y, 20, 20));
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
            TurnMusicOff();
            // Goes to the game over screen
            Form form = this.FindForm();
            MenuScreen ps = new MenuScreen();

            ps.Location = new Point((form.Width - ps.Width) / 2, (form.Height - ps.Height) / 2);

            Cursor.Show();
            form.Controls.Add(ps);
            form.Controls.Remove(this);
        }

        private void GameScreen_MouseDown(object sender, MouseEventArgs e)
        {
            mouseMoving = true;
        }

        public void catchMove()
        {
            int yComponent = (int)Math.Abs(paddle.y - ball.y);
            int xComponent = (int)Math.Abs(paddle.x - ball.x);

            int magnitude = (int)Math.Abs(Math.Sqrt(Math.Pow(yComponent, 2) + Math.Pow(xComponent, 2)));

            if (magnitude < catchDistance || isCaught)
            {
                ball.x = paddle.x + (paddle.width / 2) - (ball.size / 2);
                ball.y = paddle.y - 25;
                ball.xSpeed = paddle.x;
                ball.ySpeed = paddle.y;
                isCaught = true;
                trackPos = true;
            }
        }
        public void throwMove()
        {
                float yComponent = (float)Math.Abs(Math.Abs(0) - Math.Abs(ball.y));
                float xComponent = (float)Math.Abs(Math.Abs(TopXPos) - Math.Abs(ball.x));

                float magnitude = (float)Math.Abs(Math.Sqrt(Math.Pow(yComponent, 2) + Math.Pow(xComponent, 2)));
                float scale = (yComponent + xComponent);
                float scaleX = (xComponent / magnitude) / scale;
                float scaleY = (yComponent / magnitude) / scale;
                if (TopXPos < ball.x)
                {
                    ball.xSpeed = (magnitude * scaleX + 9) * -1;
                    ball.ySpeed = (magnitude * scaleY + 9) * -1;
                }
                else
                {
                    ball.xSpeed = (magnitude * scaleX + 9);
                    ball.ySpeed = (magnitude * scaleY + 9) * -1;
                }

                trackPos = false;
            isCaught = false;
        }
        public void GameScreen_Paint(object sender, PaintEventArgs e)
        {
            UIPaint.PaintTransRectangle(e.Graphics, Color.White, new Rectangle(0, 0, 128, this.Height), 50);
            UIPaint.PaintTransRectangle(e.Graphics, Color.White, new Rectangle(this.Width - 128, 0, 128, this.Height), 50);

            UIPaint.PaintText(e.Graphics, "Level 0", 24, new Point(this.Width - 120, 90), Color.Goldenrod);
            Image heartImage = Properties.Resources.heart1;
            Point lifePos = new Point(this.Width - heartImage.Width - 25, 25);
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
            Font myFont = new Font("Chiller", scoreSize, FontStyle.Bold);
            SizeF textSize = e.Graphics.MeasureString(score.score + "", myFont);
            foreach (string i in comboAdds)
            {

            }
            if (scoreDirection == 1)
            {
                scoreAngle++;
            }
            else
            {
                scoreAngle--;
            }
            if (scoreAngle > 10)
            {
                scoreDirection *= -1;
            }
            if (scoreAngle < -10)
            {
                scoreDirection *= -1;
            }


            // Draws paddle
            paddleBrush.Color = paddle.colour;
            e.Graphics.FillRectangle(paddleBrush, paddle.x, paddle.y, paddle.width, paddle.height);

            e.Graphics.FillRegion(Brushes.White, leftPaddleRegion);
            e.Graphics.FillRegion(Brushes.White, rightPaddleRegion);

            Block.PaintBlocks(e.Graphics, blocks);

            foreach (Debuff d in debuffs)
            {
                if (d.y < this.Bottom)
                {
                    Pen whitePen = new Pen(Color.White, 3);
                    e.Graphics.DrawRectangle(whitePen, d.x, d.y, 10, 10);
                    Brush brush = new SolidBrush(d.color);
                    e.Graphics.FillRectangle(brush, d.x, d.y, 10, 10);
                }
            }

            // Draws ball

            if (drawTheBall)
            {
                foreach (Ball b in freakyBalls)
                {
                    e.Graphics.FillEllipse(ballBrush, b.x, b.y, b.size, b.size);
                }
            }


            e.Graphics.FillEllipse(ballBrush, ball.x, ball.y, ball.size, ball.size);

            if (dB5)
            {
                e.Graphics.FillEllipse(ballBrush, mirroredBallX, ball.y, ball.size, ball.size);

                //fix paddle shape

                e.Graphics.FillRectangle(paddleBrush, mirroredPaddleX, paddle.y, paddle.width, paddle.height);
                e.Graphics.FillRegion(paddleBrush, mirroredLeftPaddleRegion);
                e.Graphics.FillRegion(paddleBrush, mirroredRightPaddleRegion);
            }

            UIPaint.PaintTextRotate(e.Graphics, score.score + "", scoreSize, new Point(this.Width / 2, this.Height / 2 - 360), Color.Red, scoreAngle, new Point((int)textSize.Width / 2, (int)textSize.Height / 2));

            //Tracking position of ball when caught
            if (trackPos)
            {
                if (turnCount % 2 == 0)
                {
                    moveRight = true;
                }
                if (moveRight == true)
                {
                    TopXPos += 40;
                    if (TopXPos > this.Width)
                    {
                        turnCount += 1;
                        moveRight = false;
                    }
                }
                else
                {
                    TopXPos -= 40;
                    if (TopXPos < 0)
                    {
                        turnCount += 1;
                        moveRight = true;
                    }

                }

                e.Graphics.DrawLine(Pens.Red, ball.x + (ball.size / 2), ball.y + (ball.size / 2), TopXPos, 0);
            }

            // test
            e.Graphics.DrawRectangle(Pens.White, ball.x, ball.y, ball.size, ball.size);
            //foreach (Block block in blocks)
            //{
            //    e.Graphics.DrawRectangle(Pens.RoyalBlue, block.hitBox);
            //}

            //e.Graphics.DrawRectangle(Pens.Red, Convert.ToInt16(ball.x), Convert.ToInt16(ball.y) + 5, 1, Convert.ToInt16(ball.size) - 10);
            //e.Graphics.DrawRectangle(Pens.Red, Convert.ToInt16(ball.x) + Convert.ToInt16(ball.size), Convert.ToInt16(ball.y) + 5, 1, Convert.ToInt16(ball.size) - 10);
            //e.Graphics.DrawRectangle(Pens.Red, Convert.ToInt16(ball.x) + 5, Convert.ToInt16(ball.y), Convert.ToInt16(ball.size) - 10, 1);
            //e.Graphics.DrawRectangle(Pens.Red, Convert.ToInt16(ball.x) + 5, Convert.ToInt16(ball.y) + Convert.ToInt16(ball.size), Convert.ToInt16(ball.size) - 10, 1);

            ////Rectangle bRl = new Rectangle(Convert.ToInt16(ball.x), Convert.ToInt16(ball.y) + 10, 1, Convert.ToInt16(ball.size) - 10);
            ////Rectangle bRr = new Rectangle(Convert.ToInt16(ball.x) + Convert.ToInt16(ball.size), Convert.ToInt16(ball.y) + 10, 1, Convert.ToInt16(ball.size) - 10);
            ////Rectangle bRt = new Rectangle(Convert.ToInt16(ball.x) + 10, Convert.ToInt16(ball.y), Convert.ToInt16(ball.size) - 10, 1);
            ////Rectangle bRb = new Rectangle(Convert.ToInt16(ball.x) + 10, Convert.ToInt16(ball.y) + Convert.ToInt16(ball.size), Convert.ToInt16(ball.size) - 10, 1);
        }
    }
}
