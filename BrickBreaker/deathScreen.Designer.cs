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
            this.SuspendLayout();
            // 
            // diedBackLabel
            // 
            this.diedBackLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 72F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.diedBackLabel.Location = new System.Drawing.Point(9, 294);
            this.diedBackLabel.Name = "diedBackLabel";
            this.diedBackLabel.Size = new System.Drawing.Size(1369, 201);
            this.diedBackLabel.TabIndex = 1;
            this.diedBackLabel.Text = "YOU DIED";
            this.diedBackLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // scare
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(19F, 37F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::BrickBreaker.Properties.Resources.scareAssBackground;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1386, 788);
            this.Controls.Add(this.diedBackLabel);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.Color.Black;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(10, 9, 10, 9);
            this.Name = "scare";
            this.Text = "scareScreen";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label diedBackLabel;
    }
}