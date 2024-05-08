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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(GameScreen));
            this.gameTimer = new System.Windows.Forms.Timer(this.components);
            this.LBarLabel = new System.Windows.Forms.Label();
            this.RBarLabel = new System.Windows.Forms.Label();
            this.scoreGSLabel = new System.Windows.Forms.Label();
            this.powerUpLabel = new System.Windows.Forms.Label();
            this.power1Label = new System.Windows.Forms.Label();
            this.power2Label = new System.Windows.Forms.Label();
            this.power3Label = new System.Windows.Forms.Label();
            this.power4Label = new System.Windows.Forms.Label();
            this.power5Label = new System.Windows.Forms.Label();
            this.currentLevelLabel = new System.Windows.Forms.Label();
            this.comboLabel = new System.Windows.Forms.Label();
            this.heartAmountLabel = new System.Windows.Forms.Label();
            this.heartLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // gameTimer
            // 
            this.gameTimer.Enabled = true;
            this.gameTimer.Interval = 1;
            this.gameTimer.Tick += new System.EventHandler(this.gameTimer_Tick);
            // 
            // LBarLabel
            // 
            this.LBarLabel.Location = new System.Drawing.Point(0, 0);
            this.LBarLabel.Name = "LBarLabel";
            this.LBarLabel.Size = new System.Drawing.Size(102, 768);
            this.LBarLabel.TabIndex = 0;
            // 
            // RBarLabel
            // 
            this.RBarLabel.Location = new System.Drawing.Point(1264, 0);
            this.RBarLabel.Name = "RBarLabel";
            this.RBarLabel.Size = new System.Drawing.Size(102, 768);
            this.RBarLabel.TabIndex = 1;
            // 
            // scoreGSLabel
            // 
            this.scoreGSLabel.BackColor = System.Drawing.Color.Transparent;
            this.scoreGSLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 72F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.scoreGSLabel.Location = new System.Drawing.Point(280, 442);
            this.scoreGSLabel.Name = "scoreGSLabel";
            this.scoreGSLabel.Size = new System.Drawing.Size(787, 156);
            this.scoreGSLabel.TabIndex = 2;
            this.scoreGSLabel.Text = "10000";
            this.scoreGSLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // powerUpLabel
            // 
            this.powerUpLabel.BackColor = System.Drawing.Color.Transparent;
            this.powerUpLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.powerUpLabel.Location = new System.Drawing.Point(294, 728);
            this.powerUpLabel.Name = "powerUpLabel";
            this.powerUpLabel.Size = new System.Drawing.Size(787, 26);
            this.powerUpLabel.TabIndex = 2;
            this.powerUpLabel.Text = "power here";
            this.powerUpLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // power1Label
            // 
            this.power1Label.BackColor = System.Drawing.Color.Silver;
            this.power1Label.Location = new System.Drawing.Point(3, 91);
            this.power1Label.Name = "power1Label";
            this.power1Label.Size = new System.Drawing.Size(82, 77);
            this.power1Label.TabIndex = 6;
            // 
            // power2Label
            // 
            this.power2Label.BackColor = System.Drawing.Color.Silver;
            this.power2Label.Location = new System.Drawing.Point(3, 211);
            this.power2Label.Name = "power2Label";
            this.power2Label.Size = new System.Drawing.Size(82, 77);
            this.power2Label.TabIndex = 6;
            // 
            // power3Label
            // 
            this.power3Label.BackColor = System.Drawing.Color.Silver;
            this.power3Label.Location = new System.Drawing.Point(3, 325);
            this.power3Label.Name = "power3Label";
            this.power3Label.Size = new System.Drawing.Size(82, 77);
            this.power3Label.TabIndex = 6;
            // 
            // power4Label
            // 
            this.power4Label.BackColor = System.Drawing.Color.Silver;
            this.power4Label.Location = new System.Drawing.Point(3, 442);
            this.power4Label.Name = "power4Label";
            this.power4Label.Size = new System.Drawing.Size(82, 77);
            this.power4Label.TabIndex = 6;
            // 
            // power5Label
            // 
            this.power5Label.BackColor = System.Drawing.Color.Silver;
            this.power5Label.Location = new System.Drawing.Point(3, 562);
            this.power5Label.Name = "power5Label";
            this.power5Label.Size = new System.Drawing.Size(82, 77);
            this.power5Label.TabIndex = 6;
            // 
            // currentLevelLabel
            // 
            this.currentLevelLabel.BackColor = System.Drawing.Color.Silver;
            this.currentLevelLabel.Location = new System.Drawing.Point(1281, 722);
            this.currentLevelLabel.Name = "currentLevelLabel";
            this.currentLevelLabel.Size = new System.Drawing.Size(82, 32);
            this.currentLevelLabel.TabIndex = 7;
            // 
            // comboLabel
            // 
            this.comboLabel.BackColor = System.Drawing.Color.Silver;
            this.comboLabel.Location = new System.Drawing.Point(1281, 161);
            this.comboLabel.Name = "comboLabel";
            this.comboLabel.Size = new System.Drawing.Size(82, 37);
            this.comboLabel.TabIndex = 7;
            // 
            // heartAmountLabel
            // 
            this.heartAmountLabel.BackColor = System.Drawing.Color.Silver;
            this.heartAmountLabel.Location = new System.Drawing.Point(1281, 103);
            this.heartAmountLabel.Name = "heartAmountLabel";
            this.heartAmountLabel.Size = new System.Drawing.Size(82, 21);
            this.heartAmountLabel.TabIndex = 7;
            // 
            // heartLabel
            // 
            this.heartLabel.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.heartLabel.Image = ((System.Drawing.Image)(resources.GetObject("heartLabel.Image")));
            this.heartLabel.Location = new System.Drawing.Point(1281, 12);
            this.heartLabel.Name = "heartLabel";
            this.heartLabel.Size = new System.Drawing.Size(82, 68);
            this.heartLabel.TabIndex = 8;
            // 
            // GameScreen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.Controls.Add(this.heartLabel);
            this.Controls.Add(this.heartAmountLabel);
            this.Controls.Add(this.comboLabel);
            this.Controls.Add(this.currentLevelLabel);
            this.Controls.Add(this.power5Label);
            this.Controls.Add(this.power4Label);
            this.Controls.Add(this.power3Label);
            this.Controls.Add(this.power2Label);
            this.Controls.Add(this.power1Label);
            this.Controls.Add(this.powerUpLabel);
            this.Controls.Add(this.scoreGSLabel);
            this.Controls.Add(this.LBarLabel);
            this.Controls.Add(this.RBarLabel);
            this.DoubleBuffered = true;
            this.Name = "GameScreen";
            this.Size = new System.Drawing.Size(1366, 768);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.GameScreen_Paint);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.GameScreen_KeyUp);
            this.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.GameScreen_PreviewKeyDown);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Timer gameTimer;
        private System.Windows.Forms.Label LBarLabel;
        private System.Windows.Forms.Label RBarLabel;
        private System.Windows.Forms.Label scoreGSLabel;
        private System.Windows.Forms.Label powerUpLabel;
        private System.Windows.Forms.Label power1Label;
        private System.Windows.Forms.Label power2Label;
        private System.Windows.Forms.Label power3Label;
        private System.Windows.Forms.Label power4Label;
        private System.Windows.Forms.Label power5Label;
        private System.Windows.Forms.Label currentLevelLabel;
        private System.Windows.Forms.Label comboLabel;
        private System.Windows.Forms.Label heartAmountLabel;
        private System.Windows.Forms.Label heartLabel;
    }
}
