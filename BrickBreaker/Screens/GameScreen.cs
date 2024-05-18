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
    public partial class GameScreen : System.Windows.Forms.UserControl
    {
        #region global values

        //activate cheats
        bool cheatmode = false;

        //player1 button control keys - DO NOT CHANGE
        Boolean leftArrowDown, rightArrowDown;

        // Game values
        public static int lives = 6;
        public static int levelNumber = 1;
        Score score;
        List<MiniScores> comboAdds = new List<MiniScores>();
        int scoreAngle = 0;
        int scoreDirection = 1;
        int scoreSize = 50;
        int ballSize;

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

        public static int duration1, duration2, duration3, duration4, duration5;
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

        List<PictureBox> pictureDebuff = new List<PictureBox>();

        // list of balls

        List<Ball> freakyBalls = new List<Ball>();

        int drawBall;

        bool drawTheBall;

        Color debuffColor;

        //Evil Skull Man

        PictureBox evilSkullMan = new PictureBox();

        int catchDistance = 100;

        public static bool pU1, pU2, pU3, pU4, pU5, pU6, pU7;

        //powerup durations 

        public static int pDuration1, pDuration2, pDuration3, pDuration4, pDuration5, pDuration6, pDuration7;

        //bottom rectangle

        Rectangle bottomRec;
        RectangleF ballRec;
        RectangleF freakyball;

        //shrink;

        int shrink;

        //ball X speed / y Speed

        float xSpeed, ySpeed;

        //newSize

        const float NEWSIZE = 5;

        //timeriemriem
        double timerDuration1 = 500;
        double timerDuration2 = 250;
        double timerDuration3 = 250;
        double timerDuration4 = 250;
        double timerDuration5 = 500;
        double timerDuration6 = 1500;
        double timerDuration7 = 250;



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

        //sound (minor)
        SoundPlayer evilFace = new SoundPlayer(Properties.Resources.Aztec_Death_Whistle);
        SoundPlayer whiteBoySound = new SoundPlayer(Properties.Resources.WhiteBoy1);
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

        private void GameScreen_Load(object sender, EventArgs e)
        {
            Cursor.Hide();
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
            //Hi Mr. T! Private Contractor Grady Here! (he is DJ music man - Logan)
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
            //set life counter
            score = new Score(Score.score, 1);

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
            xSpeed = 15 * speedMod;
            ySpeed = -3 * speedMod;
            ballSize = 20;
            ball = new Ball(ballX, ballY, Convert.ToInt16(xSpeed), Convert.ToInt16(ySpeed), ballSize);
            updateBallStorage();

            //clears debuffs
            if (debuffs.Count != 0)
            {
                debuffs.Clear();
            }

            #region debuffs / powerups
            //resets each powerup and debuff
            dB1 = false;
            dB2 = false;
            dB3 = false;
            dB4 = false;
            dB5 = false;

            duration1 = 0;
            duration2 = 0;
            duration3 = 0;
            duration4 = 0;
            duration5 = 0;

            pU1 = false;
            pU2 = false;
            pU3 = false;
            pU4 = false;
            pU5 = false;
            pU6 = false;
            pU7 = false;

            pDuration1 = (int)timerDuration1;
            pDuration2 = (int)timerDuration2;
            pDuration3 = (int)timerDuration3;
            pDuration4 = (int)timerDuration4;
            pDuration5 = (int)timerDuration5;
            pDuration6 = (int)timerDuration6;
            pDuration7 = (int)timerDuration7;
            #endregion

            //start music and level
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
                    if (cheatmode)
                    {
                        slow = true;
                    }
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
                case Keys.G:
                    if (cheatmode)
                    {
                        pU7 = true;
                    }
                    break;
                case Keys.D1:
                    if (realShopScreen.SSPU1 > 0 && !pU1)
                    {
                        pU1 = true;
                        realShopScreen.SSPU1--;
                    }
                    break;
                case Keys.D2:
                    if (realShopScreen.SSPU2 > 0 && !pU2)
                    {
                        pU2 = true;
                        realShopScreen.SSPU2--;
                    }
                    break;
                case Keys.D3:
                    if (realShopScreen.SSPU3 > 0 && !pU3)
                    {
                        pU3 = true;
                        realShopScreen.SSPU3--;
                    }
                    break;
                case Keys.D4:
                    if (realShopScreen.SSPU4 > 0 && !pU4)
                    {
                        pU4 = true;
                        realShopScreen.SSPU4--;
                    }
                    break;
                case Keys.D6:
                    if (realShopScreen.SSPU6 > 0 && !pU6)
                    {
                        pU6 = true;
                        realShopScreen.SSPU6--;
                    }
                    break;
                case Keys.D7:
                    if (realShopScreen.SSPU7 > 0 && !pU7)
                    {
                        pU7 = true;
                        realShopScreen.SSPU7--;
                    }
                    break;
                case Keys.J:
                    if (cheatmode)
                    {
                        gameTimer.Stop();
                        levelNumber++;
                        if (levelNumber == 13)
                        {
                            resetGame();
                            Form1.ChangeScreen(this, new WinScreen());
                        }
                        else
                        {
                            Form1.ChangeScreen(this, new realShopScreen());
                        }
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
                //testing
                case Keys.P:
                    gameTimer.Enabled = true;
                    break;
                default:
                    break;
            }
        }

        private void gameTimer_Tick(object sender, EventArgs e)
        {
            if (realShopScreen.SSPU5)
            {
                pU5 = true;
                powerUp5Timer.BackColor = Color.Lime;
            }
            Point mouse = this.PointToClient(Cursor.Position);

            int brickTime = 0;
            // Arrow key movements
            if (leftArrowDown && paddle.x > 40 + 128)
            {
                paddle.Move("left");
                updateCurve();
                mouseMoving = false;
            }
            if (rightArrowDown && paddle.x < (this.Width - paddle.width - 128 - 40))
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

                if (mouse.X < paddle.width / 2 + 128 + 20)
                {
                    Cursor.Position = this.PointToScreen(new Point(0 + (int)paddle.width / 2 + 128 + 20, paddle.y + paddle.height / 2));
                }

                if (mouse.X > this.Width - paddle.width / 2 - 128)
                {
                    Cursor.Position = this.PointToScreen(new Point(this.Width - (int)paddle.width / 2 - 128 - 20, paddle.y + paddle.height / 2));
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
                    lives--;
                    PlaySound("\\Resources\\Minecraft Damage (Oof) - Sound Effect (HD).wav");
                    // SoundPlayer lifesubtracted = new SoundPlayer(Properties.Resources.lifesubtracted);
                    score.RemoveCombo();
                    scoreSize = 50;

                    isCaught = true;
                    trackPos = true;
                    //lifesubtracted.Play();

                    freakyBalls.Clear();

                    // Moves the ball back to origin
                    ball.x = ((paddle.x - (ball.size / 2)) + (paddle.width / 2));
                    ball.y = (this.Height - paddle.height) - 85;

                    if (lives == 0)
                    {
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
                const float MAXSPEED = 18;
                const float MINSPEED = 8;

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

                // Check if ball has collided with any blocks
                foreach (Block b in blocks)
                {
                    if (brickTime == 0)
                    {
                        if (ball.BlockCollision(b))
                        {
                            comboAdds.Add(new MiniScores(100 * score.comboCounter + "", new Point((int)paddle.x + rand.Next(-50, 50), (int)paddle.y - 50 + rand.Next(-50, 50)), 255));
                            score.AddToScore(100);
                            scoreSize += 1;

                            b.hp--;
                            if (b.hp == 0)
                            {
                                score.AddToScore(100);
                                blocks.Remove(b);

                                if (pU3)
                                {
                                    for (int i = 0; i < blocks.Count; i++)
                                    {
                                        if (b.hitBox.Y == blocks[i].hitBox.Y) {
                                            blocks.RemoveAt(i);
                                            score.AddToScore(100);
                                            score.AddToCombo(0.25);
                                        }
                                    }
                                    blocks.RemoveAll(Block => b.hitBox.Y == Block.hitBox.Y);
                                }

                                int chance = 101;

                                if (rand.Next(1, 100) <= chance)
                                {
                                    int cCheck = rand.Next(1, 100);
                                    int o = 0;

                                    if (cCheck > 10 && cCheck < 20)
                                    {
                                        o = 1;
                                        debuffColor = Color.Green;
                                    }
                                    else if (cCheck > 20 && cCheck < 50)
                                    {
                                        o = 2;
                                        debuffColor = Color.Pink;
                                    }
                                    else if (cCheck == 50)
                                    {
                                        o = 3;
                                        debuffColor = Color.Black;
                                    }
                                    else if (cCheck > 51 && cCheck < 62)
                                    {
                                        o = 4;
                                        debuffColor = Color.White;
                                    }
                                    else
                                    {
                                        o = 5;
                                        debuffColor = Color.Silver;
                                    }

                                    if (!pU7)
                                    {
                                        Debuff newDebuff = new Debuff(o, b.hitBox.X + b.hitBox.Width / 2, b.hitBox.Y + b.hitBox.Width, debuffColor);

                                        debuffs.Add(newDebuff);
                                    }

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
                    pictureDebuff.Add(vines);
                    vineLocatoin += (int)initalSize;
                }
                else if (duration1 < 100)
                {
                    foreach (PictureBox p in pictureDebuff)
                    {
                        p.Size = new Size((int)initalSize, grow);
                    }
                    grow += 10;
                }
                else if (duration1 < 200)
                {
                    grow -= 10;
                    foreach (PictureBox p in pictureDebuff)
                    {
                        p.Size = new Size((int)initalSize, grow);
                    }
                }
                else
                {
                    duration1 = 0;
                    dB1 = false;
                    pictureDebuff.Clear();
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

                if (duration3 > 60 && duration3 < 80)
                {
                    evilFace.Play();
                    Refresh();
                }
                else if (duration3 > 80 && duration3 < 130)
                {

                    evilSkullMan.Parent = this;
                    evilSkullMan.Location = new Point((this.Width - evilSkullMan.Width) / 2, (this.Height - evilSkullMan.Height) / 2);
                    evilSkullMan.SizeMode = PictureBoxSizeMode.StretchImage;
                    evilSkullMan.Image = Properties.Resources.evilFace;
                    evilSkullMan.Size = new Size((int)(700 * widthScale), (int)(700 * heightScale));
                    evilSkullMan.BringToFront();
                }
                else if (duration3 > 150)
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
                    whiteBoySound.Play();
                    whiteBoy.Parent = this;
                    whiteBoy.Location = new Point((this.Width - whiteBoy.Width) / 2, (this.Height - whiteBoy.Height) / 2);
                    whiteBoy.SizeMode = PictureBoxSizeMode.StretchImage;
                    whiteBoy.Image = Properties.Resources.WhiteBoy;
                    whiteBoy.BringToFront();
                    //play sound

                }
                else if (duration4 < 40 && duration4 > 20)
                {
                    whiteBoySound.Play();
                    whiteBoy.Visible = true;
                    whiteBoy.Size = new Size((int)(100 * widthScale), (int)(100 * heightScale));
                    whiteBoy.Location = new Point((this.Width - whiteBoy.Width) / 2, (this.Height - whiteBoy.Height) / 2);
                    //play sound

                }
                else if (duration4 < 200 && duration4 > 180)
                {
                    whiteBoySound.Play();
                    whiteBoy.Visible = true;
                    whiteBoy.Size = new Size((int)(200 * widthScale), (int)(200 * heightScale));
                    whiteBoy.Location = new Point((this.Width - whiteBoy.Width) / 2, (this.Height - whiteBoy.Height) / 2);
                    //play sound

                }
                else if (duration4 < 400 && duration4 > 380)
                {
                    whiteBoySound.Play();
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

            if (pU1)
            {
                pDuration1--;
                if (pDuration1 > 498)
                {
                    paddle.width = paddleWidth * 5;
                }
                else if (pDuration1 > 0)
                {
                    paddle.width -= (float)320 / 500;
                }
                else
                {
                    paddle.width = paddleWidth;
                    pU1 = false;
                    pDuration1 = 500;
                }
            }

            if (pU2)
            {
                pDuration2--;
                if (pDuration2 < 0)
                {
                    pU2 = false;
                    pDuration2 = 250;
                }
            }

            if (pU3)
            {
                pDuration3--;
                if (pDuration3 < 0)
                {
                    pU3 = false;
                    pDuration3 = 250;
                }
            }

            if (pU4)
            {
                pDuration4--;
                if (pDuration4 > 0)
                {
                    ball.size = 30;
                }
                else
                {
                    ball.size = 20;
                    pU4 = false;
                    pDuration4 = 250;
                }
            }

            if (pU6)
            {
                pDuration6--;
                bottomRec = new Rectangle(0, this.Height - 20, this.Width, 20);
                ballRec = new RectangleF(ball.x, ball.y, ball.size, ball.size);
                if (pDuration6 > 800)
                {
                    ball.xSpeed *= 2;
                    ball.ySpeed *= 2;
                    if (ballRec.IntersectsWith(bottomRec))
                    {
                        ball.y = bottomRec.Y - ball.size;
                        ball.ySpeed *= -1;
                    }
                    foreach (Ball b in freakyBalls)
                    {
                        freakyball = new RectangleF(b.x, b.y, b.size, b.size);
                        if (freakyball.IntersectsWith(bottomRec))
                        {
                            b.y = bottomRec.Y - b.size;
                            b.ySpeed *= -1;
                        }
                    }
                }
                else if (pDuration6 < 0)
                {
                    shrink++;
                    bottomRec.Size = new Size(this.Width - 2 * (shrink), 20);
                    bottomRec.Location = new Point(0 + shrink, this.Height - 20);
                    ball.xSpeed -= 1;
                    ball.ySpeed -= 1;
                    if (ballRec.IntersectsWith(bottomRec))
                    {
                        ball.y = bottomRec.Y - ball.size;
                        ball.ySpeed *= -1;
                    }
                    foreach (Ball b in freakyBalls)
                    {
                        freakyball = new RectangleF(b.x, b.y, b.size, b.size);
                        if (freakyball.IntersectsWith(bottomRec))
                        {
                            b.y = bottomRec.Y - b.size;
                            b.ySpeed *= -1;
                        }
                    }
                }
                else
                {
                    pDuration6 = 1500;
                    pU6 = false;
                    shrink = 0;
                    ball.xSpeed = xSpeed;
                    ball.ySpeed = ySpeed;
                }
            }
            if (pU7)
            {
                //ball.xSpeed = 0;
                //ball.ySpeed = 0;
                pDuration7--;
                if (pDuration7 > 0)
                {
                    int middleOfScreenX = this.Width / 2;
                    int middleOfScreenY = this.Height / 2;

                    double diffX = middleOfScreenX - ball.x;
                    double diffY = middleOfScreenY - ball.y;
                    const int SPEEDCAP = 4;
                    if (Math.Abs(diffY) >= Math.Abs(diffX)) //multiply down y
                    {
                        double scaler = Math.Abs(SPEEDCAP / diffY);
                        diffX *= scaler;
                        diffY *= scaler;
                    }
                    else
                    {
                        double scaler = Math.Abs(SPEEDCAP / diffX);
                        diffX *= scaler;
                        diffY *= scaler;
                    }
                    ball.xSpeed = (float)diffX;
                    ball.ySpeed = (float)diffY;

                    if (pDuration7 < 150)
                    {
                        ball.size += NEWSIZE;
                        ball.x = (this.Width / 2) - (ball.size / 2);
                        ball.y = (this.Height / 2) - (ball.size / 2);

                        foreach (Block b in blocks)
                        {
                            diffX = middleOfScreenX - b.hitBox.X;
                            diffY = middleOfScreenY - b.hitBox.Y;
                            const int SPEEDCAPBLOCK = 2;
                            if (Math.Abs(diffY) >= Math.Abs(diffX)) //multiply down y
                            {
                                double scaler = Math.Abs(SPEEDCAP / diffY);
                                diffX *= scaler;
                                diffY *= scaler;
                            }
                            else
                            {
                                double scaler = Math.Abs(SPEEDCAP / diffX);
                                diffX *= scaler;
                                diffY *= scaler;
                            }
                            if (b.hitBox.IntersectsWith(new Rectangle((int)ball.x, (int)ball.y, (int)ball.size, (int)ball.size)))
                            {
                                blocks.Remove(b);
                                break;
                            }
                            b.hitBox = new Rectangle(b.hitBox.X + (int)diffX, b.hitBox.Y + (int)diffY, b.hitBox.Width, b.hitBox.Height);
                            ball.ySpeed = (float)diffY;
                        }
                    }
                }
                else
                {
                    pDuration7 = 250;
                    pU7 = false;
                    ball.size = ballSize;
                    ball.xSpeed = xSpeed;
                    ball.xSpeed = ySpeed;
                    mouseMoving = false;
                    paddle.x = (this.Width / 2) - (int)(paddle.width / 2) - 20;
                    updateCurve();
                    isCaught = true;
                    trackPos = true;
                    blocks.Clear();
                    Refresh();
                }

            }

            #endregion

            #region PowerUp Timers

            const int TIMERWIDTH = 100;

            int t1percent = (int)((float)(pDuration1 / timerDuration1) * TIMERWIDTH);
            int t2percent = (int)((float)(pDuration2 / timerDuration2) * TIMERWIDTH);
            int t3percent = (int)((float)(pDuration3 / timerDuration3) * TIMERWIDTH);
            int t4percent = (int)((float)(pDuration4 / timerDuration4) * TIMERWIDTH);
            int t5percent = (int)((float)(pDuration5 / timerDuration5) * TIMERWIDTH);
            int t6percent = (int)((float)(pDuration6 / timerDuration6) * TIMERWIDTH);
            int t7percent = (int)((float)(pDuration7 / timerDuration7) * TIMERWIDTH);

            powerUp1Timer.Size = new Size(t1percent, 10);
            powerUp2Timer.Size = new Size(t2percent, 10);
            powerUp3Timer.Size = new Size(t3percent, 10);
            powerUp4Timer.Size = new Size(t4percent, 10);
            powerUp5Timer.Size = new Size(t5percent, 10);
            powerUp6Timer.Size = new Size(t6percent, 10);
            powerUp7Timer.Size = new Size(t7percent, 10);


            #endregion

            brickTime--;

            if (blocks.Count() == 0)
            {
                levelNumber++;
                if (levelNumber == 13)
                {
                    resetGame();
                    Form1.ChangeScreen(this, new WinScreen());
                }
                else
                {
                    Form1.ChangeScreen(this, new realShopScreen());
                }
                TurnMusicOff();
                PlayMusic();
                sounds.Clear();
                blocks = Block.LevelChanger(levelNumber, this.Size);
                gameTimer.Stop();
            }

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
            resetGame();
            Form1.ChangeScreen(this, new GameOverScreen());
        }

        private void GameScreen_MouseDown(object sender, MouseEventArgs e)
        {
            mouseMoving = true;
        }

        public void catchMove()
        {
            if (pU5)
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
                ball.xSpeed = (magnitude * scaleX + 12) * -1;
                ball.ySpeed = (magnitude * scaleY + 12) * -1;
            }
            else
            {
                ball.xSpeed = (magnitude * scaleX + 12);
                ball.ySpeed = (magnitude * scaleY + 12) * -1;
            }

            trackPos = false;
            isCaught = false;
        }

        void resetGame()
        {
            gameTimer.Stop();
            levelNumber = 1;
            realShopScreen.SSPU1 = 0;
            realShopScreen.SSPU2 = 0;
            realShopScreen.SSPU3 = 0;
            realShopScreen.SSPU4 = 0;
            realShopScreen.SSPU5 = false;
            realShopScreen.SSPU6 = 0;
            realShopScreen.SSPU7 = 0;
            Score.score = 25000;
            lives = 6;
            blocks = new List<Block>();
            dB1 = false;
            dB2 = false;
            dB3 = false;
            dB4 = false;
            dB5 = false;
            realShopScreen.duringGame = false;
        }

        public void GameScreen_Paint(object sender, PaintEventArgs e)
        {
            UIPaint.PaintTransRectangle(e.Graphics, Color.White, new Rectangle(0, 0, 128, this.Height), 50);
            UIPaint.PaintTransRectangle(e.Graphics, Color.White, new Rectangle(this.Width - 128, 0, 128, this.Height), 50);

            UIPaint.PaintText(e.Graphics, $"Level {levelNumber}", 24, new Point(this.Width - 120, 90), Color.Goldenrod);

            //creates the graphics for powerups
            UIPaint.PaintText(e.Graphics, "Magnum", 14, new Point(4, 550), Color.Goldenrod);
            UIPaint.PaintText(e.Graphics, $"x{realShopScreen.SSPU1}", 24, new Point(this.Width - 86, 523), Color.Goldenrod);

            UIPaint.PaintText(e.Graphics, "Piercing Strike", 14, new Point(4, 610), Color.Goldenrod);
            UIPaint.PaintText(e.Graphics, $"x{realShopScreen.SSPU2}", 24, new Point(this.Width - 86, 585), Color.Goldenrod);

            UIPaint.PaintText(e.Graphics, "Construction", 14, new Point(4, 670), Color.Goldenrod);
            UIPaint.PaintText(e.Graphics, $"x{realShopScreen.SSPU3}", 24, new Point(this.Width - 86, 647), Color.Goldenrod);

            UIPaint.PaintText(e.Graphics, "Growth Elixer", 14, new Point(4, 730), Color.Goldenrod);
            UIPaint.PaintText(e.Graphics, $"x{realShopScreen.SSPU4}", 24, new Point(this.Width - 86, 711), Color.Goldenrod);

            UIPaint.PaintText(e.Graphics, "Control Strike", 14, new Point(4, 790), Color.Goldenrod);
            if (realShopScreen.SSPU5)
                UIPaint.PaintText(e.Graphics, $"Active", 20, new Point(this.Width - 94, 775), Color.Goldenrod);
            else
                UIPaint.PaintText(e.Graphics, $"Inactive", 20, new Point(this.Width - 101, 775), Color.Goldenrod);

            UIPaint.PaintText(e.Graphics, "War God", 14, new Point(4, 850), Color.Goldenrod);
            UIPaint.PaintText(e.Graphics, $"x{realShopScreen.SSPU6}", 24, new Point(this.Width - 86, 835), Color.Goldenrod);

            UIPaint.PaintText(e.Graphics, "Final Gift", 14, new Point(4, 910), Color.Goldenrod);
            UIPaint.PaintText(e.Graphics, $"x{realShopScreen.SSPU7}", 24, new Point(this.Width - 86, 896), Color.Goldenrod);

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
            SizeF textSize = e.Graphics.MeasureString(Score.score + "", myFont);
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

            if (pU6)
            {
                e.Graphics.FillRectangle(Brushes.White, bottomRec);
            }

            UIPaint.PaintTextRotate(e.Graphics, score.comboCounter + "x " + Score.score + "", scoreSize, new Point(this.Width / 2, this.Height / 2 - 360), Color.Red, scoreAngle, new Point((int)textSize.Width, (int)textSize.Height));


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

                try
                {
                    e.Graphics.DrawLine(Pens.Red, ball.x + (ball.size / 2), ball.y + (ball.size / 2), TopXPos, 0);
                }
                catch {}
            }

            // test
            // e.Graphics.DrawRectangle(Pens.White, ball.x, ball.y, ball.size, ball.size);
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
            ///

            for (int i = 0; i < comboAdds.Count(); i++)
            {
                if (comboAdds.Count() != 0)
                {
                    UIPaint.PaintTextTrans(e.Graphics, comboAdds[i].text, 30, comboAdds[i].drawPoint, Color.Red, comboAdds[i].transparency);
                    comboAdds[i].transparency -= 7;
                    if (comboAdds[i].transparency <= 0)
                    {
                        comboAdds.Remove(comboAdds[i]);
                    }
                }
            }
        }
    }
}
