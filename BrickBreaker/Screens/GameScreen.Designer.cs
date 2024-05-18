namespace BrickBreaker
{
    partial class GameScreen
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.gameTimer = new System.Windows.Forms.Timer(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.powerUp1Timer = new System.Windows.Forms.Label();
            this.powerUp3Timer = new System.Windows.Forms.Label();
            this.powerUp2Timer = new System.Windows.Forms.Label();
            this.powerUp5Timer = new System.Windows.Forms.Label();
            this.powerUp6Timer = new System.Windows.Forms.Label();
            this.powerUp4Timer = new System.Windows.Forms.Label();
            this.powerUp7Timer = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // gameTimer
            // 
            this.gameTimer.Enabled = true;
            this.gameTimer.Interval = 10;
            this.gameTimer.Tick += new System.EventHandler(this.gameTimer_Tick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(44, 16);
            this.label1.TabIndex = 7;
            this.label1.Text = "label1";
            // 
            // powerUp1Timer
            // 
            this.powerUp1Timer.BackColor = System.Drawing.Color.Lime;
            this.powerUp1Timer.ForeColor = System.Drawing.Color.Lime;
            this.powerUp1Timer.Location = new System.Drawing.Point(1591, 569);
            this.powerUp1Timer.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.powerUp1Timer.Name = "powerUp1Timer";
            this.powerUp1Timer.Size = new System.Drawing.Size(166, 21);
            this.powerUp1Timer.TabIndex = 8;
            this.powerUp1Timer.Text = "       ";
            // 
            // powerUp3Timer
            // 
            this.powerUp3Timer.BackColor = System.Drawing.Color.Lime;
            this.powerUp3Timer.ForeColor = System.Drawing.Color.Lime;
            this.powerUp3Timer.Location = new System.Drawing.Point(1591, 690);
            this.powerUp3Timer.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.powerUp3Timer.Name = "powerUp3Timer";
            this.powerUp3Timer.Size = new System.Drawing.Size(166, 21);
            this.powerUp3Timer.TabIndex = 9;
            this.powerUp3Timer.Text = "       ";
            // 
            // powerUp2Timer
            // 
            this.powerUp2Timer.BackColor = System.Drawing.Color.Lime;
            this.powerUp2Timer.ForeColor = System.Drawing.Color.Lime;
            this.powerUp2Timer.Location = new System.Drawing.Point(1591, 627);
            this.powerUp2Timer.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.powerUp2Timer.Name = "powerUp2Timer";
            this.powerUp2Timer.Size = new System.Drawing.Size(166, 21);
            this.powerUp2Timer.TabIndex = 10;
            this.powerUp2Timer.Text = "       ";
            // 
            // powerUp5Timer
            // 
            this.powerUp5Timer.BackColor = System.Drawing.Color.Lime;
            this.powerUp5Timer.ForeColor = System.Drawing.Color.Lime;
            this.powerUp5Timer.Location = new System.Drawing.Point(1591, 810);
            this.powerUp5Timer.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.powerUp5Timer.Name = "powerUp5Timer";
            this.powerUp5Timer.Size = new System.Drawing.Size(166, 21);
            this.powerUp5Timer.TabIndex = 13;
            this.powerUp5Timer.Text = "       ";
            // 
            // powerUp6Timer
            // 
            this.powerUp6Timer.BackColor = System.Drawing.Color.Lime;
            this.powerUp6Timer.ForeColor = System.Drawing.Color.Lime;
            this.powerUp6Timer.Location = new System.Drawing.Point(1591, 874);
            this.powerUp6Timer.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.powerUp6Timer.Name = "powerUp6Timer";
            this.powerUp6Timer.Size = new System.Drawing.Size(166, 21);
            this.powerUp6Timer.TabIndex = 12;
            this.powerUp6Timer.Text = "       ";
            // 
            // powerUp4Timer
            // 
            this.powerUp4Timer.BackColor = System.Drawing.Color.Lime;
            this.powerUp4Timer.ForeColor = System.Drawing.Color.Lime;
            this.powerUp4Timer.Location = new System.Drawing.Point(1591, 753);
            this.powerUp4Timer.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.powerUp4Timer.Name = "powerUp4Timer";
            this.powerUp4Timer.Size = new System.Drawing.Size(166, 21);
            this.powerUp4Timer.TabIndex = 11;
            this.powerUp4Timer.Text = "       ";
            // 
            // powerUp7Timer
            // 
            this.powerUp7Timer.BackColor = System.Drawing.Color.Lime;
            this.powerUp7Timer.ForeColor = System.Drawing.Color.Lime;
            this.powerUp7Timer.Location = new System.Drawing.Point(1591, 939);
            this.powerUp7Timer.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.powerUp7Timer.Name = "powerUp7Timer";
            this.powerUp7Timer.Size = new System.Drawing.Size(166, 21);
            this.powerUp7Timer.TabIndex = 14;
            this.powerUp7Timer.Text = "       ";
            // 
            // GameScreen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(120F, 120F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.Controls.Add(this.powerUp7Timer);
            this.Controls.Add(this.powerUp5Timer);
            this.Controls.Add(this.powerUp6Timer);
            this.Controls.Add(this.powerUp4Timer);
            this.Controls.Add(this.powerUp2Timer);
            this.Controls.Add(this.powerUp3Timer);
            this.Controls.Add(this.powerUp1Timer);
            this.Controls.Add(this.label1);
            this.DoubleBuffered = true;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "GameScreen";
            this.Size = new System.Drawing.Size(1708, 960);
            this.Load += new System.EventHandler(this.GameScreen_Load);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.GameScreen_Paint);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.GameScreen_KeyUp);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.GameScreen_MouseDown);
            this.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.GameScreen_PreviewKeyDown);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Timer gameTimer;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label powerUp1Timer;
        private System.Windows.Forms.Label powerUp3Timer;
        private System.Windows.Forms.Label powerUp2Timer;
        private System.Windows.Forms.Label powerUp5Timer;
        private System.Windows.Forms.Label powerUp6Timer;
        private System.Windows.Forms.Label powerUp4Timer;
        private System.Windows.Forms.Label powerUp7Timer;
    }
}
