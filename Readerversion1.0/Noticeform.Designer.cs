namespace Readerversion1._0
{
    partial class Noticeform
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
            this.Noticeformwaitlabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // Noticeformwaitlabel
            // 
            this.Noticeformwaitlabel.AutoSize = true;
            this.Noticeformwaitlabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Noticeformwaitlabel.Location = new System.Drawing.Point(115, 85);
            this.Noticeformwaitlabel.Name = "Noticeformwaitlabel";
            this.Noticeformwaitlabel.Size = new System.Drawing.Size(154, 25);
            this.Noticeformwaitlabel.TabIndex = 0;
            this.Noticeformwaitlabel.Text = "Please wait...";
            // 
            // Noticeform
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(400, 205);
            this.Controls.Add(this.Noticeformwaitlabel);
            this.Name = "Noticeform";
            this.Text = "Noticeform";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label Noticeformwaitlabel;



    }
}