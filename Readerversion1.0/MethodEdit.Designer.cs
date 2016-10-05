namespace Readerversion1._0
{
    partial class MethodEdit
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
            this.Methodeditmethodnamelable = new System.Windows.Forms.Label();
            this.methodeditmethodnametextbox = new System.Windows.Forms.TextBox();
            this.methodeditparamatercombox = new System.Windows.Forms.ComboBox();
            this.Methodeditparamaters = new System.Windows.Forms.Label();
            this.methodeditsavebtn = new System.Windows.Forms.Button();
            this.methodeditaddbtn = new System.Windows.Forms.Button();
            this.methodeditdelete = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // Methodeditmethodnamelable
            // 
            this.Methodeditmethodnamelable.AutoSize = true;
            this.Methodeditmethodnamelable.Location = new System.Drawing.Point(362, 197);
            this.Methodeditmethodnamelable.Name = "Methodeditmethodnamelable";
            this.Methodeditmethodnamelable.Size = new System.Drawing.Size(69, 13);
            this.Methodeditmethodnamelable.TabIndex = 0;
            this.Methodeditmethodnamelable.Text = "Methodname";
            // 
            // methodeditmethodnametextbox
            // 
            this.methodeditmethodnametextbox.Location = new System.Drawing.Point(437, 197);
            this.methodeditmethodnametextbox.Name = "methodeditmethodnametextbox";
            this.methodeditmethodnametextbox.Size = new System.Drawing.Size(100, 20);
            this.methodeditmethodnametextbox.TabIndex = 1;
            // 
            // methodeditparamatercombox
            // 
            this.methodeditparamatercombox.FormattingEnabled = true;
            this.methodeditparamatercombox.Location = new System.Drawing.Point(437, 248);
            this.methodeditparamatercombox.Name = "methodeditparamatercombox";
            this.methodeditparamatercombox.Size = new System.Drawing.Size(121, 21);
            this.methodeditparamatercombox.TabIndex = 2;
            // 
            // Methodeditparamaters
            // 
            this.Methodeditparamaters.AutoSize = true;
            this.Methodeditparamaters.Location = new System.Drawing.Point(365, 248);
            this.Methodeditparamaters.Name = "Methodeditparamaters";
            this.Methodeditparamaters.Size = new System.Drawing.Size(59, 13);
            this.Methodeditparamaters.TabIndex = 3;
            this.Methodeditparamaters.Text = "paramaters";
            // 
            // methodeditsavebtn
            // 
            this.methodeditsavebtn.Location = new System.Drawing.Point(323, 541);
            this.methodeditsavebtn.Name = "methodeditsavebtn";
            this.methodeditsavebtn.Size = new System.Drawing.Size(314, 23);
            this.methodeditsavebtn.TabIndex = 4;
            this.methodeditsavebtn.Text = "Save";
            this.methodeditsavebtn.UseVisualStyleBackColor = true;
            // 
            // methodeditaddbtn
            // 
            this.methodeditaddbtn.Location = new System.Drawing.Point(368, 316);
            this.methodeditaddbtn.Name = "methodeditaddbtn";
            this.methodeditaddbtn.Size = new System.Drawing.Size(75, 23);
            this.methodeditaddbtn.TabIndex = 5;
            this.methodeditaddbtn.Text = "Add";
            this.methodeditaddbtn.UseVisualStyleBackColor = true;
            this.methodeditaddbtn.Click += new System.EventHandler(this.methodeditaddbtn_Click);
            // 
            // methodeditdelete
            // 
            this.methodeditdelete.Location = new System.Drawing.Point(483, 316);
            this.methodeditdelete.Name = "methodeditdelete";
            this.methodeditdelete.Size = new System.Drawing.Size(75, 23);
            this.methodeditdelete.TabIndex = 6;
            this.methodeditdelete.Text = "delete";
            this.methodeditdelete.UseVisualStyleBackColor = true;
            // 
            // MethodEdit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1041, 631);
            this.Controls.Add(this.methodeditdelete);
            this.Controls.Add(this.methodeditaddbtn);
            this.Controls.Add(this.methodeditsavebtn);
            this.Controls.Add(this.Methodeditparamaters);
            this.Controls.Add(this.methodeditparamatercombox);
            this.Controls.Add(this.methodeditmethodnametextbox);
            this.Controls.Add(this.Methodeditmethodnamelable);
            this.Name = "MethodEdit";
            this.Text = "MethodEdit";
            this.Load += new System.EventHandler(this.MethodEdit_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label Methodeditmethodnamelable;
        private System.Windows.Forms.TextBox methodeditmethodnametextbox;
        private System.Windows.Forms.ComboBox methodeditparamatercombox;
        private System.Windows.Forms.Label Methodeditparamaters;
        private System.Windows.Forms.Button methodeditsavebtn;
        private System.Windows.Forms.Button methodeditaddbtn;
        private System.Windows.Forms.Button methodeditdelete;
    }
}