namespace Readerversion1._0
{
    partial class Controlzoneentity
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.testtradiobtn = new System.Windows.Forms.RadioButton();
            this.controlradiobtn = new System.Windows.Forms.RadioButton();
            this.Controlzoneentitysizelable = new System.Windows.Forms.Label();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.contorlzoneentityfinsihbtn = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.testtradiobtn);
            this.panel1.Controls.Add(this.controlradiobtn);
            this.panel1.Controls.Add(this.Controlzoneentitysizelable);
            this.panel1.Controls.Add(this.comboBox1);
            this.panel1.Controls.Add(this.contorlzoneentityfinsihbtn);
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(563, 346);
            this.panel1.TabIndex = 12;
            // 
            // testtradiobtn
            // 
            this.testtradiobtn.AutoSize = true;
            this.testtradiobtn.Location = new System.Drawing.Point(430, 265);
            this.testtradiobtn.Name = "testtradiobtn";
            this.testtradiobtn.Size = new System.Drawing.Size(42, 17);
            this.testtradiobtn.TabIndex = 17;
            this.testtradiobtn.TabStop = true;
            this.testtradiobtn.Text = "test";
            this.testtradiobtn.UseVisualStyleBackColor = true;
            // 
            // controlradiobtn
            // 
            this.controlradiobtn.AutoSize = true;
            this.controlradiobtn.Location = new System.Drawing.Point(430, 240);
            this.controlradiobtn.Name = "controlradiobtn";
            this.controlradiobtn.Size = new System.Drawing.Size(57, 17);
            this.controlradiobtn.TabIndex = 16;
            this.controlradiobtn.TabStop = true;
            this.controlradiobtn.Text = "control";
            this.controlradiobtn.UseVisualStyleBackColor = true;
            this.controlradiobtn.CheckedChanged += new System.EventHandler(this.controlradiobtn_CheckedChanged);
            // 
            // Controlzoneentitysizelable
            // 
            this.Controlzoneentitysizelable.AutoSize = true;
            this.Controlzoneentitysizelable.Location = new System.Drawing.Point(395, 201);
            this.Controlzoneentitysizelable.Name = "Controlzoneentitysizelable";
            this.Controlzoneentitysizelable.Size = new System.Drawing.Size(25, 13);
            this.Controlzoneentitysizelable.TabIndex = 15;
            this.Controlzoneentitysizelable.Text = "size";
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7",
            "8",
            "9",
            "10"});
            this.comboBox1.Location = new System.Drawing.Point(430, 201);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(121, 21);
            this.comboBox1.TabIndex = 14;
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // contorlzoneentityfinsihbtn
            // 
            this.contorlzoneentityfinsihbtn.Location = new System.Drawing.Point(231, 278);
            this.contorlzoneentityfinsihbtn.Name = "contorlzoneentityfinsihbtn";
            this.contorlzoneentityfinsihbtn.Size = new System.Drawing.Size(75, 25);
            this.contorlzoneentityfinsihbtn.TabIndex = 13;
            this.contorlzoneentityfinsihbtn.Text = "finish";
            this.contorlzoneentityfinsihbtn.UseVisualStyleBackColor = true;
            this.contorlzoneentityfinsihbtn.Click += new System.EventHandler(this.contorlzoneentityfinsihbtn_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(2, 44);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(558, 108);
            this.pictureBox1.TabIndex = 12;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseDown);
            this.pictureBox1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseMove);
            this.pictureBox1.MouseUp += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseUp);
            // 
            // Controlzoneentity
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(563, 346);
            this.Controls.Add(this.panel1);
            this.Name = "Controlzoneentity";
            this.Text = "Controlzoneentity";
            this.Load += new System.EventHandler(this.Controlzoneentity_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.RadioButton testtradiobtn;
        private System.Windows.Forms.RadioButton controlradiobtn;
        private System.Windows.Forms.Label Controlzoneentitysizelable;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Button contorlzoneentityfinsihbtn;
        private System.Windows.Forms.PictureBox pictureBox1;
        public System.Windows.Forms.Panel panel1;

    }
}