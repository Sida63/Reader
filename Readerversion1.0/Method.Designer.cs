namespace Readerversion1._0
{
    partial class Method
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
            this.Paramaternumbertextbox = new System.Windows.Forms.TextBox();
            this.Paramaternumberlabel = new System.Windows.Forms.Label();
            this.methodnamevalue = new System.Windows.Forms.TextBox();
            this.methodnamelab = new System.Windows.Forms.Label();
            this.cancelbtn = new System.Windows.Forms.Button();
            this.nextbtn = new System.Windows.Forms.Button();
            this.namevalue = new System.Windows.Forms.TextBox();
            this.namelab = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.Paramaternumbertextbox);
            this.panel1.Controls.Add(this.Paramaternumberlabel);
            this.panel1.Controls.Add(this.methodnamevalue);
            this.panel1.Controls.Add(this.methodnamelab);
            this.panel1.Controls.Add(this.cancelbtn);
            this.panel1.Controls.Add(this.nextbtn);
            this.panel1.Controls.Add(this.namevalue);
            this.panel1.Controls.Add(this.namelab);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(648, 495);
            this.panel1.TabIndex = 0;
            // 
            // Paramaternumbertextbox
            // 
            this.Paramaternumbertextbox.Location = new System.Drawing.Point(310, 231);
            this.Paramaternumbertextbox.Name = "Paramaternumbertextbox";
            this.Paramaternumbertextbox.Size = new System.Drawing.Size(184, 20);
            this.Paramaternumbertextbox.TabIndex = 13;
            this.Paramaternumbertextbox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Paramaternumbertextbox_KeyPress);
            // 
            // Paramaternumberlabel
            // 
            this.Paramaternumberlabel.AutoSize = true;
            this.Paramaternumberlabel.Location = new System.Drawing.Point(160, 231);
            this.Paramaternumberlabel.Name = "Paramaternumberlabel";
            this.Paramaternumberlabel.Size = new System.Drawing.Size(112, 13);
            this.Paramaternumberlabel.TabIndex = 12;
            this.Paramaternumberlabel.Text = "Number of Paramaters";
            // 
            // methodnamevalue
            // 
            this.methodnamevalue.Location = new System.Drawing.Point(310, 164);
            this.methodnamevalue.Name = "methodnamevalue";
            this.methodnamevalue.Size = new System.Drawing.Size(184, 20);
            this.methodnamevalue.TabIndex = 11;
            this.methodnamevalue.Text = "name";
            this.methodnamevalue.TextChanged += new System.EventHandler(this.methodnamevalue_TextChanged);
            // 
            // methodnamelab
            // 
            this.methodnamelab.AutoSize = true;
            this.methodnamelab.Location = new System.Drawing.Point(160, 167);
            this.methodnamelab.Name = "methodnamelab";
            this.methodnamelab.Size = new System.Drawing.Size(74, 13);
            this.methodnamelab.TabIndex = 10;
            this.methodnamelab.Text = "Method Name";
            this.methodnamelab.Click += new System.EventHandler(this.methodnamelab_Click);
            // 
            // cancelbtn
            // 
            this.cancelbtn.Location = new System.Drawing.Point(202, 432);
            this.cancelbtn.Name = "cancelbtn";
            this.cancelbtn.Size = new System.Drawing.Size(75, 25);
            this.cancelbtn.TabIndex = 9;
            this.cancelbtn.Text = "cancel";
            this.cancelbtn.UseVisualStyleBackColor = true;
            this.cancelbtn.Click += new System.EventHandler(this.cancelbtn_Click);
            // 
            // nextbtn
            // 
            this.nextbtn.Location = new System.Drawing.Point(367, 432);
            this.nextbtn.Name = "nextbtn";
            this.nextbtn.Size = new System.Drawing.Size(75, 25);
            this.nextbtn.TabIndex = 8;
            this.nextbtn.Text = "Next";
            this.nextbtn.UseVisualStyleBackColor = true;
            this.nextbtn.Click += new System.EventHandler(this.nextbtn_Click);
            // 
            // namevalue
            // 
            this.namevalue.Location = new System.Drawing.Point(310, 289);
            this.namevalue.Multiline = true;
            this.namevalue.Name = "namevalue";
            this.namevalue.Size = new System.Drawing.Size(184, 68);
            this.namevalue.TabIndex = 7;
            this.namevalue.TextChanged += new System.EventHandler(this.namevalue_TextChanged);
            // 
            // namelab
            // 
            this.namelab.AutoSize = true;
            this.namelab.Location = new System.Drawing.Point(160, 292);
            this.namelab.Name = "namelab";
            this.namelab.Size = new System.Drawing.Size(96, 13);
            this.namelab.TabIndex = 6;
            this.namelab.Text = "Paramaters Names";
            this.namelab.Click += new System.EventHandler(this.namelab_Click);
            // 
            // Method
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(648, 495);
            this.Controls.Add(this.panel1);
            this.Name = "Method";
            this.Text = "Method";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Method_FormClosing);
            this.Load += new System.EventHandler(this.Method_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button cancelbtn;
        private System.Windows.Forms.Button nextbtn;
        private System.Windows.Forms.TextBox namevalue;
        private System.Windows.Forms.Label namelab;
        private System.Windows.Forms.TextBox methodnamevalue;
        private System.Windows.Forms.Label methodnamelab;
        private System.Windows.Forms.TextBox Paramaternumbertextbox;
        private System.Windows.Forms.Label Paramaternumberlabel;

    }
}