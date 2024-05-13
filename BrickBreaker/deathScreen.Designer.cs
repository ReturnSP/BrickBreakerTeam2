namespace BrickBreaker
{
    partial class deathScreen
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.diedBackLabel = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // diedBackLabel
            // 
            this.diedBackLabel.BackColor = System.Drawing.Color.Transparent;
            this.diedBackLabel.Font = new System.Drawing.Font("Chiller", 80.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.diedBackLabel.ForeColor = System.Drawing.Color.DarkRed;
            this.diedBackLabel.Location = new System.Drawing.Point(12, 322);
            this.diedBackLabel.Name = "diedBackLabel";
            this.diedBackLabel.Size = new System.Drawing.Size(1369, 201);
            this.diedBackLabel.TabIndex = 1;
            this.diedBackLabel.Text = "YOU DIED";
            this.diedBackLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.Black;
            this.button1.Font = new System.Drawing.Font("Chiller", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.button1.Location = new System.Drawing.Point(554, 694);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(263, 43);
            this.button1.TabIndex = 2;
            this.button1.Text = "Give Up";
            this.button1.UseVisualStyleBackColor = false;
            // 
            // deathScreen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(19F, 37F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::BrickBreaker.Properties.Resources.scareAssBackground;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1370, 749);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.diedBackLabel);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.Color.Black;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(10, 9, 10, 9);
            this.Name = "deathScreen";
            this.Text = "scareScreen";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label diedBackLabel;
        private System.Windows.Forms.Button button1;
    }
}