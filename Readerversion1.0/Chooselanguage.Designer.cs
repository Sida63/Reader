namespace Readerversion1._0
{
    partial class Chooselanguage
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
            this.languageselectbox = new System.Windows.Forms.ComboBox();
            this.selectlanguagelabel = new System.Windows.Forms.Label();
            this.Languagefinishbtn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // languageselectbox
            // 
            this.languageselectbox.FormattingEnabled = true;
            this.languageselectbox.Location = new System.Drawing.Point(130, 53);
            this.languageselectbox.Name = "languageselectbox";
            this.languageselectbox.Size = new System.Drawing.Size(121, 21);
            this.languageselectbox.TabIndex = 0;
            // 
            // selectlanguagelabel
            // 
            this.selectlanguagelabel.AutoSize = true;
            this.selectlanguagelabel.Location = new System.Drawing.Point(22, 56);
            this.selectlanguagelabel.Name = "selectlanguagelabel";
            this.selectlanguagelabel.Size = new System.Drawing.Size(91, 13);
            this.selectlanguagelabel.TabIndex = 1;
            this.selectlanguagelabel.Text = "Setting Language";
            // 
            // Languagefinishbtn
            // 
            this.Languagefinishbtn.Location = new System.Drawing.Point(101, 163);
            this.Languagefinishbtn.Name = "Languagefinishbtn";
            this.Languagefinishbtn.Size = new System.Drawing.Size(75, 23);
            this.Languagefinishbtn.TabIndex = 2;
            this.Languagefinishbtn.Text = "Finish";
            this.Languagefinishbtn.UseVisualStyleBackColor = true;
            this.Languagefinishbtn.Click += new System.EventHandler(this.Languagefinishbtn_Click);
            // 
            // Chooselanguage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Controls.Add(this.Languagefinishbtn);
            this.Controls.Add(this.selectlanguagelabel);
            this.Controls.Add(this.languageselectbox);
            this.Name = "Chooselanguage";
            this.Text = "Chooselanguage";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Chooselanguage_FormClosing);
            this.Load += new System.EventHandler(this.Chooselanguage_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox languageselectbox;
        private System.Windows.Forms.Label selectlanguagelabel;
        private System.Windows.Forms.Button Languagefinishbtn;

    }
}