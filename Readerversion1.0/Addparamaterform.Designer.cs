namespace Readerversion1._0
{
    partial class Addparamaterform
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
            this.addnewparamaterbtn = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // addnewparamaterbtn
            // 
            this.addnewparamaterbtn.Location = new System.Drawing.Point(81, 139);
            this.addnewparamaterbtn.Name = "addnewparamaterbtn";
            this.addnewparamaterbtn.Size = new System.Drawing.Size(147, 23);
            this.addnewparamaterbtn.TabIndex = 0;
            this.addnewparamaterbtn.Text = "add new paramater";
            this.addnewparamaterbtn.UseVisualStyleBackColor = true;
            this.addnewparamaterbtn.Click += new System.EventHandler(this.addnewparamaterbtn_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(11, 74);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(113, 12);
            this.label1.TabIndex = 1;
            this.label1.Text = "Please input name:";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(147, 71);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(153, 21);
            this.textBox1.TabIndex = 2;
            // 
            // Addparamaterform
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(332, 214);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.addnewparamaterbtn);
            this.Name = "Addparamaterform";
            this.Text = "Addparamaterform";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button addnewparamaterbtn;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox1;
    }
}