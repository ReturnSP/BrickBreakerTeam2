namespace BrickBreaker
{
    partial class GameOverScreen
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
            this.tipLabel = new System.Windows.Forms.Label();
            this.pauseLabel = new System.Windows.Forms.Label();
            this.giveUpButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // tipLabel
            // 
            this.tipLabel.BackColor = System.Drawing.Color.Transparent;
            this.tipLabel.Font = new System.Drawing.Font("Chiller", 26.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tipLabel.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.tipLabel.Location = new System.Drawing.Point(693, 432);
            this.tipLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.tipLabel.Name = "tipLabel";
            this.tipLabel.Size = new System.Drawing.Size(708, 202);
            this.tipLabel.TabIndex = 3;
            this.tipLabel.Text = "Tip:\r\nYou Lost so you should win next time";
            this.tipLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pauseLabel
            // 
            this.pauseLabel.BackColor = System.Drawing.Color.Transparent;
            this.pauseLabel.Font = new System.Drawing.Font("Chiller", 72F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pauseLabel.ForeColor = System.Drawing.Color.Gold;
            this.pauseLabel.Location = new System.Drawing.Point(826, 240);
            this.pauseLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.pauseLabel.Name = "pauseLabel";
            this.pauseLabel.Size = new System.Drawing.Size(463, 202);
            this.pauseLabel.TabIndex = 2;
            this.pauseLabel.Text = "GIVE UP";
            this.pauseLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // giveUpButton
            // 
            this.giveUpButton.BackColor = System.Drawing.Color.Gold;
            this.giveUpButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.giveUpButton.Font = new System.Drawing.Font("Chiller", 26F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.giveUpButton.Location = new System.Drawing.Point(969, 711);
            this.giveUpButton.Name = "giveUpButton";
            this.giveUpButton.Size = new System.Drawing.Size(166, 87);
            this.giveUpButton.TabIndex = 4;
            this.giveUpButton.Text = "Give Up";
            this.giveUpButton.UseVisualStyleBackColor = false;
            this.giveUpButton.Click += new System.EventHandler(this.giveUpButton_Click);
            // 
            // GameOverScreen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.BackgroundImage = global::BrickBreaker.Properties.Resources.pauseScreen;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.Controls.Add(this.giveUpButton);
            this.Controls.Add(this.tipLabel);
            this.Controls.Add(this.pauseLabel);
            this.DoubleBuffered = true;
            this.Name = "GameOverScreen";
            this.Size = new System.Drawing.Size(2049, 1152);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label tipLabel;
        private System.Windows.Forms.Label pauseLabel;
        private System.Windows.Forms.Button giveUpButton;
    }
}
