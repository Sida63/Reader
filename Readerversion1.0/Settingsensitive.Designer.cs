namespace Readerversion1._0
{
    partial class Settingsensitive
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
            this.Settingsensitivetestbtn = new System.Windows.Forms.Button();
            this.Settingsensitivefinishbtn = new System.Windows.Forms.Button();
            this.Sensitivevalue = new System.Windows.Forms.TextBox();
            this.Settingsensitiveinputsensitivelabel = new System.Windows.Forms.Label();
            this.tabgroup = new System.Windows.Forms.TabControl();
            this.SettingsensitiveIncreasevaluebtn = new System.Windows.Forms.Button();
            this.Settingsensitivedecreasebtn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // Settingsensitivetestbtn
            // 
            this.Settingsensitivetestbtn.Location = new System.Drawing.Point(517, 480);
            this.Settingsensitivetestbtn.Name = "Settingsensitivetestbtn";
            this.Settingsensitivetestbtn.Size = new System.Drawing.Size(75, 23);
            this.Settingsensitivetestbtn.TabIndex = 1;
            this.Settingsensitivetestbtn.Text = "Run";
            this.Settingsensitivetestbtn.UseVisualStyleBackColor = true;
            this.Settingsensitivetestbtn.Click += new System.EventHandler(this.Settingsensitivetestbtn_Click);
            // 
            // Settingsensitivefinishbtn
            // 
            this.Settingsensitivefinishbtn.Location = new System.Drawing.Point(324, 565);
            this.Settingsensitivefinishbtn.Name = "Settingsensitivefinishbtn";
            this.Settingsensitivefinishbtn.Size = new System.Drawing.Size(196, 23);
            this.Settingsensitivefinishbtn.TabIndex = 2;
            this.Settingsensitivefinishbtn.Text = "Confirm";
            this.Settingsensitivefinishbtn.UseVisualStyleBackColor = true;
            this.Settingsensitivefinishbtn.Click += new System.EventHandler(this.Settingsensitivefinishbtn_Click);
            // 
            // Sensitivevalue
            // 
            this.Sensitivevalue.Location = new System.Drawing.Point(356, 480);
            this.Sensitivevalue.Name = "Sensitivevalue";
            this.Sensitivevalue.Size = new System.Drawing.Size(123, 20);
            this.Sensitivevalue.TabIndex = 3;
            this.Sensitivevalue.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Sensitivevalue_KeyPress);
            // 
            // Settingsensitiveinputsensitivelabel
            // 
            this.Settingsensitiveinputsensitivelabel.AutoSize = true;
            this.Settingsensitiveinputsensitivelabel.Location = new System.Drawing.Point(265, 480);
            this.Settingsensitiveinputsensitivelabel.Name = "Settingsensitiveinputsensitivelabel";
            this.Settingsensitiveinputsensitivelabel.Size = new System.Drawing.Size(66, 13);
            this.Settingsensitiveinputsensitivelabel.TabIndex = 4;
            this.Settingsensitiveinputsensitivelabel.Text = "Signal Noise";
            // 
            // tabgroup
            // 
            this.tabgroup.Location = new System.Drawing.Point(47, 24);
            this.tabgroup.Name = "tabgroup";
            this.tabgroup.SelectedIndex = 0;
            this.tabgroup.Size = new System.Drawing.Size(757, 427);
            this.tabgroup.TabIndex = 5;
            // 
            // SettingsensitiveIncreasevaluebtn
            // 
            this.SettingsensitiveIncreasevaluebtn.Location = new System.Drawing.Point(623, 480);
            this.SettingsensitiveIncreasevaluebtn.Name = "SettingsensitiveIncreasevaluebtn";
            this.SettingsensitiveIncreasevaluebtn.Size = new System.Drawing.Size(75, 23);
            this.SettingsensitiveIncreasevaluebtn.TabIndex = 6;
            this.SettingsensitiveIncreasevaluebtn.Text = "Increase";
            this.SettingsensitiveIncreasevaluebtn.UseVisualStyleBackColor = true;
            this.SettingsensitiveIncreasevaluebtn.Click += new System.EventHandler(this.SettingsensitiveIncreasevaluebtn_Click);
            // 
            // Settingsensitivedecreasebtn
            // 
            this.Settingsensitivedecreasebtn.Location = new System.Drawing.Point(623, 522);
            this.Settingsensitivedecreasebtn.Name = "Settingsensitivedecreasebtn";
            this.Settingsensitivedecreasebtn.Size = new System.Drawing.Size(75, 23);
            this.Settingsensitivedecreasebtn.TabIndex = 7;
            this.Settingsensitivedecreasebtn.Text = "decrease";
            this.Settingsensitivedecreasebtn.UseVisualStyleBackColor = true;
            this.Settingsensitivedecreasebtn.Click += new System.EventHandler(this.Settingsensitivedecreasebtn_Click);
            // 
            // Settingsensitive
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(850, 600);
            this.Controls.Add(this.Settingsensitivedecreasebtn);
            this.Controls.Add(this.SettingsensitiveIncreasevaluebtn);
            this.Controls.Add(this.tabgroup);
            this.Controls.Add(this.Settingsensitiveinputsensitivelabel);
            this.Controls.Add(this.Sensitivevalue);
            this.Controls.Add(this.Settingsensitivefinishbtn);
            this.Controls.Add(this.Settingsensitivetestbtn);
            this.Name = "Settingsensitive";
            this.Text = "Settingsensitive";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button Settingsensitivetestbtn;
        private System.Windows.Forms.Button Settingsensitivefinishbtn;
        private System.Windows.Forms.TextBox Sensitivevalue;
        private System.Windows.Forms.Label Settingsensitiveinputsensitivelabel;
        private System.Windows.Forms.TabControl tabgroup;
        private System.Windows.Forms.Button SettingsensitiveIncreasevaluebtn;
        private System.Windows.Forms.Button Settingsensitivedecreasebtn;
    }
}