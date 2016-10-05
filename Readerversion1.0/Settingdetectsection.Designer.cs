namespace Readerversion1._0
{
    partial class Settingdetectsection
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
            this.shutter = new System.Windows.Forms.Button();
            this.videPlayer = new AForge.Controls.VideoSourcePlayer();
            this.save = new System.Windows.Forms.Button();
            this.setzonebtn = new System.Windows.Forms.Button();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.settingtoolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sourceSettingToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cameraToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sensitiveSettingToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.upbtn = new System.Windows.Forms.Button();
            this.leftbtn = new System.Windows.Forms.Button();
            this.downbtn = new System.Windows.Forms.Button();
            this.rightbtn = new System.Windows.Forms.Button();
            this.settingdetectsectoindeletebtn = new System.Windows.Forms.Button();
            this.setttingdetectsectiondeleteallbtn = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.settingdetectsectionneededlabel = new System.Windows.Forms.Label();
            this.settingdetectsectionneededvaluelabel = new System.Windows.Forms.Label();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.Settingdetectsectioncopybtn = new System.Windows.Forms.Button();
            this.menuStrip1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // shutter
            // 
            this.shutter.Location = new System.Drawing.Point(12, 67);
            this.shutter.Name = "shutter";
            this.shutter.Size = new System.Drawing.Size(97, 25);
            this.shutter.TabIndex = 19;
            this.shutter.Text = "Obtain Image";
            this.shutter.UseVisualStyleBackColor = true;
            this.shutter.Click += new System.EventHandler(this.shutter_Click);
            // 
            // videPlayer
            // 
            this.videPlayer.Location = new System.Drawing.Point(261, 89);
            this.videPlayer.Name = "videPlayer";
            this.videPlayer.Size = new System.Drawing.Size(320, 240);
            this.videPlayer.TabIndex = 17;
            this.videPlayer.Text = "videPlayer";
            this.videPlayer.VideoSource = null;
            // 
            // save
            // 
            this.save.Location = new System.Drawing.Point(415, 384);
            this.save.Name = "save";
            this.save.Size = new System.Drawing.Size(166, 41);
            this.save.TabIndex = 20;
            this.save.Text = "Save";
            this.save.UseVisualStyleBackColor = true;
            this.save.Click += new System.EventHandler(this.save_Click);
            // 
            // setzonebtn
            // 
            this.setzonebtn.Location = new System.Drawing.Point(134, 67);
            this.setzonebtn.Name = "setzonebtn";
            this.setzonebtn.Size = new System.Drawing.Size(101, 23);
            this.setzonebtn.TabIndex = 21;
            this.setzonebtn.Text = "Zone Setting";
            this.setzonebtn.UseVisualStyleBackColor = true;
            this.setzonebtn.Click += new System.EventHandler(this.setzonebtn_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.settingtoolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(626, 24);
            this.menuStrip1.TabIndex = 22;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // settingtoolStripMenuItem
            // 
            this.settingtoolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.sourceSettingToolStripMenuItem,
            this.cameraToolStripMenuItem,
            this.sensitiveSettingToolStripMenuItem});
            this.settingtoolStripMenuItem.Name = "settingtoolStripMenuItem";
            this.settingtoolStripMenuItem.Size = new System.Drawing.Size(56, 20);
            this.settingtoolStripMenuItem.Text = "Setting";
            // 
            // sourceSettingToolStripMenuItem
            // 
            this.sourceSettingToolStripMenuItem.Name = "sourceSettingToolStripMenuItem";
            this.sourceSettingToolStripMenuItem.Size = new System.Drawing.Size(154, 22);
            this.sourceSettingToolStripMenuItem.Text = "Camera Source";
            this.sourceSettingToolStripMenuItem.Click += new System.EventHandler(this.sourceSettingToolStripMenuItem_Click);
            // 
            // cameraToolStripMenuItem
            // 
            this.cameraToolStripMenuItem.Name = "cameraToolStripMenuItem";
            this.cameraToolStripMenuItem.Size = new System.Drawing.Size(154, 22);
            this.cameraToolStripMenuItem.Text = "Camera setting";
            this.cameraToolStripMenuItem.Click += new System.EventHandler(this.cameraToolStripMenuItem_Click);
            // 
            // sensitiveSettingToolStripMenuItem
            // 
            this.sensitiveSettingToolStripMenuItem.Name = "sensitiveSettingToolStripMenuItem";
            this.sensitiveSettingToolStripMenuItem.Size = new System.Drawing.Size(154, 22);
            this.sensitiveSettingToolStripMenuItem.Text = "Signal Noise";
            this.sensitiveSettingToolStripMenuItem.Click += new System.EventHandler(this.sensitiveSettingToolStripMenuItem_Click);
            // 
            // upbtn
            // 
            this.upbtn.Location = new System.Drawing.Point(67, 12);
            this.upbtn.Name = "upbtn";
            this.upbtn.Size = new System.Drawing.Size(50, 23);
            this.upbtn.TabIndex = 23;
            this.upbtn.Text = "up";
            this.upbtn.UseVisualStyleBackColor = true;
            this.upbtn.Click += new System.EventHandler(this.upbtn_Click);
            // 
            // leftbtn
            // 
            this.leftbtn.Location = new System.Drawing.Point(6, 65);
            this.leftbtn.Name = "leftbtn";
            this.leftbtn.Size = new System.Drawing.Size(45, 23);
            this.leftbtn.TabIndex = 24;
            this.leftbtn.Text = "left";
            this.leftbtn.UseVisualStyleBackColor = true;
            this.leftbtn.Click += new System.EventHandler(this.leftbtn_Click);
            // 
            // downbtn
            // 
            this.downbtn.Location = new System.Drawing.Point(67, 113);
            this.downbtn.Name = "downbtn";
            this.downbtn.Size = new System.Drawing.Size(50, 23);
            this.downbtn.TabIndex = 25;
            this.downbtn.Text = "down";
            this.downbtn.UseVisualStyleBackColor = true;
            this.downbtn.Click += new System.EventHandler(this.downbtn_Click);
            // 
            // rightbtn
            // 
            this.rightbtn.Location = new System.Drawing.Point(133, 65);
            this.rightbtn.Name = "rightbtn";
            this.rightbtn.Size = new System.Drawing.Size(45, 23);
            this.rightbtn.TabIndex = 26;
            this.rightbtn.Text = "right";
            this.rightbtn.UseVisualStyleBackColor = true;
            this.rightbtn.Click += new System.EventHandler(this.rightbtn_Click);
            // 
            // settingdetectsectoindeletebtn
            // 
            this.settingdetectsectoindeletebtn.Location = new System.Drawing.Point(12, 127);
            this.settingdetectsectoindeletebtn.Name = "settingdetectsectoindeletebtn";
            this.settingdetectsectoindeletebtn.Size = new System.Drawing.Size(97, 23);
            this.settingdetectsectoindeletebtn.TabIndex = 27;
            this.settingdetectsectoindeletebtn.Text = "Remove Recent";
            this.settingdetectsectoindeletebtn.UseVisualStyleBackColor = true;
            this.settingdetectsectoindeletebtn.Click += new System.EventHandler(this.settingdetectsectoindeletebtn_Click);
            // 
            // setttingdetectsectiondeleteallbtn
            // 
            this.setttingdetectsectiondeleteallbtn.Location = new System.Drawing.Point(134, 127);
            this.setttingdetectsectiondeleteallbtn.Name = "setttingdetectsectiondeleteallbtn";
            this.setttingdetectsectiondeleteallbtn.Size = new System.Drawing.Size(101, 23);
            this.setttingdetectsectiondeleteallbtn.TabIndex = 28;
            this.setttingdetectsectiondeleteallbtn.Text = "Clear All";
            this.setttingdetectsectiondeleteallbtn.UseVisualStyleBackColor = true;
            this.setttingdetectsectiondeleteallbtn.Click += new System.EventHandler(this.setttingdetectsectiondeleteallbtn_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.Settingdetectsectioncopybtn);
            this.panel1.Controls.Add(this.downbtn);
            this.panel1.Controls.Add(this.upbtn);
            this.panel1.Controls.Add(this.leftbtn);
            this.panel1.Controls.Add(this.rightbtn);
            this.panel1.Location = new System.Drawing.Point(28, 202);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(192, 150);
            this.panel1.TabIndex = 29;
            // 
            // settingdetectsectionneededlabel
            // 
            this.settingdetectsectionneededlabel.AutoSize = true;
            this.settingdetectsectionneededlabel.Location = new System.Drawing.Point(375, 46);
            this.settingdetectsectionneededlabel.Name = "settingdetectsectionneededlabel";
            this.settingdetectsectionneededlabel.Size = new System.Drawing.Size(94, 13);
            this.settingdetectsectionneededlabel.TabIndex = 30;
            this.settingdetectsectionneededlabel.Text = "Numbers of Zones";
            // 
            // settingdetectsectionneededvaluelabel
            // 
            this.settingdetectsectionneededvaluelabel.AutoSize = true;
            this.settingdetectsectionneededvaluelabel.ForeColor = System.Drawing.Color.Red;
            this.settingdetectsectionneededvaluelabel.Location = new System.Drawing.Point(478, 46);
            this.settingdetectsectionneededvaluelabel.Name = "settingdetectsectionneededvaluelabel";
            this.settingdetectsectionneededvaluelabel.Size = new System.Drawing.Size(13, 13);
            this.settingdetectsectionneededvaluelabel.TabIndex = 31;
            this.settingdetectsectionneededvaluelabel.Text = "0";
            // 
            // tabControl1
            // 
            this.tabControl1.Location = new System.Drawing.Point(254, 74);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(360, 280);
            this.tabControl1.TabIndex = 32;
            this.tabControl1.SelectedIndexChanged += new System.EventHandler(this.tabControl1_SelectedIndexChanged);
            // 
            // Settingdetectsectioncopybtn
            // 
            this.Settingdetectsectioncopybtn.Location = new System.Drawing.Point(67, 64);
            this.Settingdetectsectioncopybtn.Name = "Settingdetectsectioncopybtn";
            this.Settingdetectsectioncopybtn.Size = new System.Drawing.Size(50, 23);
            this.Settingdetectsectioncopybtn.TabIndex = 27;
            this.Settingdetectsectioncopybtn.Text = "copy";
            this.Settingdetectsectioncopybtn.UseVisualStyleBackColor = true;
            this.Settingdetectsectioncopybtn.Click += new System.EventHandler(this.Settingdetectsectioncopybtn_Click);
            // 
            // Settingdetectsection
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(626, 439);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.settingdetectsectionneededvaluelabel);
            this.Controls.Add(this.settingdetectsectionneededlabel);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.setttingdetectsectiondeleteallbtn);
            this.Controls.Add(this.settingdetectsectoindeletebtn);
            this.Controls.Add(this.setzonebtn);
            this.Controls.Add(this.save);
            this.Controls.Add(this.shutter);
            this.Controls.Add(this.videPlayer);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Settingdetectsection";
            this.Text = "Settingdetectsection";
            this.Load += new System.EventHandler(this.Settingdetectsection_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button shutter;
        private AForge.Controls.VideoSourcePlayer videPlayer;
        private System.Windows.Forms.Button save;
        private System.Windows.Forms.Button setzonebtn;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem settingtoolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem sourceSettingToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem cameraToolStripMenuItem;
        private System.Windows.Forms.Button upbtn;
        private System.Windows.Forms.Button leftbtn;
        private System.Windows.Forms.Button downbtn;
        private System.Windows.Forms.Button rightbtn;
        private System.Windows.Forms.Button settingdetectsectoindeletebtn;
        private System.Windows.Forms.Button setttingdetectsectiondeleteallbtn;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label settingdetectsectionneededlabel;
        private System.Windows.Forms.ToolStripMenuItem sensitiveSettingToolStripMenuItem;
        private System.Windows.Forms.TabControl tabControl1;
        public System.Windows.Forms.Label settingdetectsectionneededvaluelabel;
        private System.Windows.Forms.Button Settingdetectsectioncopybtn;


    }
}