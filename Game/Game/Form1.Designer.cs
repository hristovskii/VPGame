namespace Game
{
    partial class Form1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripProgressBarTimeLeft = new System.Windows.Forms.ToolStripProgressBar();
            this.toolStripStatusLblLifes = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLblScore = new System.Windows.Forms.ToolStripStatusLabel();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // statusStrip1
            // 
            this.statusStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1,
            this.toolStripProgressBarTimeLeft,
            this.toolStripStatusLblLifes,
            this.toolStripStatusLblScore});
            this.statusStrip1.Location = new System.Drawing.Point(0, 825);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(1682, 28);
            this.statusStrip1.TabIndex = 0;
            this.statusStrip1.Text = "statusStrip1";
            this.statusStrip1.Paint += new System.Windows.Forms.PaintEventHandler(this.statusStrip1_Paint);
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(0, 23);
            // 
            // toolStripProgressBarTimeLeft
            // 
            this.toolStripProgressBarTimeLeft.Maximum = 600;
            this.toolStripProgressBarTimeLeft.Name = "toolStripProgressBarTimeLeft";
            this.toolStripProgressBarTimeLeft.Size = new System.Drawing.Size(1350, 22);
            this.toolStripProgressBarTimeLeft.Value = 600;
            // 
            // toolStripStatusLblLifes
            // 
            this.toolStripStatusLblLifes.Font = new System.Drawing.Font("Gigi", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolStripStatusLblLifes.ForeColor = System.Drawing.Color.DeepPink;
            this.toolStripStatusLblLifes.Image = global::Game.Properties.Resources.heart;
            this.toolStripStatusLblLifes.Name = "toolStripStatusLblLifes";
            this.toolStripStatusLblLifes.Size = new System.Drawing.Size(34, 23);
            this.toolStripStatusLblLifes.Text = ":";
            // 
            // toolStripStatusLblScore
            // 
            this.toolStripStatusLblScore.Font = new System.Drawing.Font("Gigi", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolStripStatusLblScore.ForeColor = System.Drawing.Color.DeepPink;
            this.toolStripStatusLblScore.Image = global::Game.Properties.Resources.flowerSmall;
            this.toolStripStatusLblScore.Name = "toolStripStatusLblScore";
            this.toolStripStatusLblScore.Size = new System.Drawing.Size(34, 23);
            this.toolStripStatusLblScore.Text = ":";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1682, 853);
            this.Controls.Add(this.statusStrip1);
            this.DoubleBuffered = true;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.Text = "Game";
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.Form1_Paint);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyDown);
            this.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.Form1_PreviewKeyDown);
            this.Resize += new System.EventHandler(this.Form1_Resize);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.ToolStripProgressBar toolStripProgressBarTimeLeft;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLblLifes;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLblScore;
    }
}

