namespace Readerversion1._0
{
    partial class Camerasetting
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
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label7 = new System.Windows.Forms.Label();
            this.saturationlabel = new System.Windows.Forms.Label();
            this.saturationtrackBar = new System.Windows.Forms.TrackBar();
            this.contrastlabel = new System.Windows.Forms.Label();
            this.brightnesslabel = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.contrasttrackBar = new System.Windows.Forms.TrackBar();
            this.brightnesstrackBar = new System.Windows.Forms.TrackBar();
            this.videPlayer = new AForge.Controls.VideoSourcePlayer();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.saturationtrackBar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.contrasttrackBar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.brightnesstrackBar)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(22, 81);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(320, 240);
            this.pictureBox1.TabIndex = 19;
            this.pictureBox1.TabStop = false;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(715, 182);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(13, 13);
            this.label7.TabIndex = 44;
            this.label7.Text = "0";
            // 
            // saturationlabel
            // 
            this.saturationlabel.AutoSize = true;
            this.saturationlabel.Location = new System.Drawing.Point(359, 182);
            this.saturationlabel.Name = "saturationlabel";
            this.saturationlabel.Size = new System.Drawing.Size(53, 13);
            this.saturationlabel.TabIndex = 43;
            this.saturationlabel.Text = "saturation";
            // 
            // saturationtrackBar
            // 
            this.saturationtrackBar.Location = new System.Drawing.Point(418, 182);
            this.saturationtrackBar.Maximum = 50;
            this.saturationtrackBar.Minimum = -50;
            this.saturationtrackBar.Name = "saturationtrackBar";
            this.saturationtrackBar.Size = new System.Drawing.Size(291, 45);
            this.saturationtrackBar.TabIndex = 42;
            this.saturationtrackBar.TickStyle = System.Windows.Forms.TickStyle.None;
            this.saturationtrackBar.ValueChanged += new System.EventHandler(this.saturationtrackBar_ValueChanged);
            // 
            // contrastlabel
            // 
            this.contrastlabel.AutoSize = true;
            this.contrastlabel.Location = new System.Drawing.Point(359, 137);
            this.contrastlabel.Name = "contrastlabel";
            this.contrastlabel.Size = new System.Drawing.Size(45, 13);
            this.contrastlabel.TabIndex = 41;
            this.contrastlabel.Text = "contrast";
            // 
            // brightnesslabel
            // 
            this.brightnesslabel.AutoSize = true;
            this.brightnesslabel.Location = new System.Drawing.Point(359, 85);
            this.brightnesslabel.Name = "brightnesslabel";
            this.brightnesslabel.Size = new System.Drawing.Size(55, 13);
            this.brightnesslabel.TabIndex = 40;
            this.brightnesslabel.Text = "brightness";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(716, 141);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(13, 13);
            this.label2.TabIndex = 39;
            this.label2.Text = "0";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(716, 90);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(13, 13);
            this.label1.TabIndex = 38;
            this.label1.Text = "0";
            // 
            // contrasttrackBar
            // 
            this.contrasttrackBar.Location = new System.Drawing.Point(418, 137);
            this.contrasttrackBar.Maximum = 500;
            this.contrasttrackBar.Minimum = -500;
            this.contrasttrackBar.Name = "contrasttrackBar";
            this.contrasttrackBar.Size = new System.Drawing.Size(291, 45);
            this.contrasttrackBar.TabIndex = 37;
            this.contrasttrackBar.TickStyle = System.Windows.Forms.TickStyle.None;
            this.contrasttrackBar.ValueChanged += new System.EventHandler(this.contrasttrackBar_ValueChanged);
            // 
            // brightnesstrackBar
            // 
            this.brightnesstrackBar.Location = new System.Drawing.Point(418, 81);
            this.brightnesstrackBar.Maximum = 500;
            this.brightnesstrackBar.Minimum = -500;
            this.brightnesstrackBar.Name = "brightnesstrackBar";
            this.brightnesstrackBar.Size = new System.Drawing.Size(291, 45);
            this.brightnesstrackBar.TabIndex = 36;
            this.brightnesstrackBar.TickStyle = System.Windows.Forms.TickStyle.None;
            this.brightnesstrackBar.ValueChanged += new System.EventHandler(this.brightnesstrackBar_ValueChanged);
            // 
            // videPlayer
            // 
            this.videPlayer.Location = new System.Drawing.Point(22, 81);
            this.videPlayer.Name = "videPlayer";
            this.videPlayer.Size = new System.Drawing.Size(320, 240);
            this.videPlayer.TabIndex = 45;
            this.videPlayer.Text = "videPlayer";
            this.videPlayer.VideoSource = null;
            this.videPlayer.Visible = false;
            // 
            // Camerasetting
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(768, 473);
            this.Controls.Add(this.videPlayer);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.saturationlabel);
            this.Controls.Add(this.saturationtrackBar);
            this.Controls.Add(this.contrastlabel);
            this.Controls.Add(this.brightnesslabel);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.contrasttrackBar);
            this.Controls.Add(this.brightnesstrackBar);
            this.Controls.Add(this.pictureBox1);
            this.Name = "Camerasetting";
            this.Text = "Camerasetting";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Camerasetting_FormClosing);
            this.Load += new System.EventHandler(this.Camerasetting_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.saturationtrackBar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.contrasttrackBar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.brightnesstrackBar)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label saturationlabel;
        private System.Windows.Forms.TrackBar saturationtrackBar;
        private System.Windows.Forms.Label contrastlabel;
        private System.Windows.Forms.Label brightnesslabel;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TrackBar contrasttrackBar;
        private System.Windows.Forms.TrackBar brightnesstrackBar;
        private AForge.Controls.VideoSourcePlayer videPlayer;
    }
}