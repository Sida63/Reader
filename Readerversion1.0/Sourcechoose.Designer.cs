namespace Readerversion1._0
{
    partial class Sourcechoose
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
            this.Videoinputlabel = new System.Windows.Forms.Label();
            this.Videochoosecombobox = new System.Windows.Forms.ComboBox();
            this.resolutionlabel = new System.Windows.Forms.Label();
            this.resolutioncomboBox = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // Videoinputlabel
            // 
            this.Videoinputlabel.AutoSize = true;
            this.Videoinputlabel.Location = new System.Drawing.Point(92, 85);
            this.Videoinputlabel.Name = "Videoinputlabel";
            this.Videoinputlabel.Size = new System.Drawing.Size(80, 13);
            this.Videoinputlabel.TabIndex = 0;
            this.Videoinputlabel.Text = "Camera Source";
            // 
            // Videochoosecombobox
            // 
            this.Videochoosecombobox.FormattingEnabled = true;
            this.Videochoosecombobox.Location = new System.Drawing.Point(201, 85);
            this.Videochoosecombobox.Name = "Videochoosecombobox";
            this.Videochoosecombobox.Size = new System.Drawing.Size(121, 21);
            this.Videochoosecombobox.TabIndex = 1;
            this.Videochoosecombobox.SelectedIndexChanged += new System.EventHandler(this.Videochoosecombobox_SelectedIndexChanged);
            // 
            // resolutionlabel
            // 
            this.resolutionlabel.AutoSize = true;
            this.resolutionlabel.Location = new System.Drawing.Point(115, 145);
            this.resolutionlabel.Name = "resolutionlabel";
            this.resolutionlabel.Size = new System.Drawing.Size(57, 13);
            this.resolutionlabel.TabIndex = 2;
            this.resolutionlabel.Text = "Resolution";
            // 
            // resolutioncomboBox
            // 
            this.resolutioncomboBox.FormattingEnabled = true;
            this.resolutioncomboBox.Location = new System.Drawing.Point(201, 145);
            this.resolutioncomboBox.Name = "resolutioncomboBox";
            this.resolutioncomboBox.Size = new System.Drawing.Size(121, 21);
            this.resolutioncomboBox.TabIndex = 3;
            // 
            // Sourcechoose
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(445, 355);
            this.Controls.Add(this.resolutioncomboBox);
            this.Controls.Add(this.resolutionlabel);
            this.Controls.Add(this.Videochoosecombobox);
            this.Controls.Add(this.Videoinputlabel);
            this.Name = "Sourcechoose";
            this.Text = "Sourcechoose";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Sourcechoose_FormClosing);
            this.Load += new System.EventHandler(this.Sourcechoose_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label Videoinputlabel;
        private System.Windows.Forms.ComboBox Videochoosecombobox;
        private System.Windows.Forms.Label resolutionlabel;
        private System.Windows.Forms.ComboBox resolutioncomboBox;
    }
}