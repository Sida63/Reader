namespace Readerversion1._0
{
    partial class TestlineSetting
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
            this.TestingSettingsavebtn = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.TestlineSettingdeletebtn = new System.Windows.Forms.Button();
            this.TestlineRecordslabel = new System.Windows.Forms.Label();
            this.TestlineSettingRecordsvalue = new System.Windows.Forms.TextBox();
            this.TestlineSettingaddbtn = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // TestingSettingsavebtn
            // 
            this.TestingSettingsavebtn.Location = new System.Drawing.Point(420, 265);
            this.TestingSettingsavebtn.Name = "TestingSettingsavebtn";
            this.TestingSettingsavebtn.Size = new System.Drawing.Size(75, 23);
            this.TestingSettingsavebtn.TabIndex = 57;
            this.TestingSettingsavebtn.Text = "Save";
            this.TestingSettingsavebtn.UseVisualStyleBackColor = true;
            this.TestingSettingsavebtn.Click += new System.EventHandler(this.TestingSettingsavebtn_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(36, 80);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(312, 262);
            this.dataGridView1.TabIndex = 59;
            this.dataGridView1.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.dataGridView1_DataError);
            // 
            // TestlineSettingdeletebtn
            // 
            this.TestlineSettingdeletebtn.Location = new System.Drawing.Point(420, 319);
            this.TestlineSettingdeletebtn.Name = "TestlineSettingdeletebtn";
            this.TestlineSettingdeletebtn.Size = new System.Drawing.Size(75, 23);
            this.TestlineSettingdeletebtn.TabIndex = 60;
            this.TestlineSettingdeletebtn.Text = "Delete";
            this.TestlineSettingdeletebtn.UseVisualStyleBackColor = true;
            this.TestlineSettingdeletebtn.Click += new System.EventHandler(this.TestlineSettingdeletebtn_Click);
            // 
            // TestlineRecordslabel
            // 
            this.TestlineRecordslabel.AutoSize = true;
            this.TestlineRecordslabel.Location = new System.Drawing.Point(366, 135);
            this.TestlineRecordslabel.Name = "TestlineRecordslabel";
            this.TestlineRecordslabel.Size = new System.Drawing.Size(47, 13);
            this.TestlineRecordslabel.TabIndex = 61;
            this.TestlineRecordslabel.Text = "Records";
            // 
            // TestlineSettingRecordsvalue
            // 
            this.TestlineSettingRecordsvalue.Location = new System.Drawing.Point(420, 135);
            this.TestlineSettingRecordsvalue.Name = "TestlineSettingRecordsvalue";
            this.TestlineSettingRecordsvalue.Size = new System.Drawing.Size(100, 20);
            this.TestlineSettingRecordsvalue.TabIndex = 62;
            this.TestlineSettingRecordsvalue.Text = "1";
            this.TestlineSettingRecordsvalue.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TestlineSettingRecordsvalue_KeyPress);
            // 
            // TestlineSettingaddbtn
            // 
            this.TestlineSettingaddbtn.Location = new System.Drawing.Point(420, 182);
            this.TestlineSettingaddbtn.Name = "TestlineSettingaddbtn";
            this.TestlineSettingaddbtn.Size = new System.Drawing.Size(75, 23);
            this.TestlineSettingaddbtn.TabIndex = 63;
            this.TestlineSettingaddbtn.Text = "Add";
            this.TestlineSettingaddbtn.UseVisualStyleBackColor = true;
            this.TestlineSettingaddbtn.Click += new System.EventHandler(this.TestlineSettingaddbtn_Click);
            // 
            // TestlineSetting
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(559, 437);
            this.Controls.Add(this.TestlineSettingaddbtn);
            this.Controls.Add(this.TestlineSettingRecordsvalue);
            this.Controls.Add(this.TestlineRecordslabel);
            this.Controls.Add(this.TestlineSettingdeletebtn);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.TestingSettingsavebtn);
            this.Name = "TestlineSetting";
            this.Text = "TestlineSetting";
            this.Load += new System.EventHandler(this.TestlineSetting_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button TestingSettingsavebtn;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button TestlineSettingdeletebtn;
        private System.Windows.Forms.Label TestlineRecordslabel;
        private System.Windows.Forms.TextBox TestlineSettingRecordsvalue;
        private System.Windows.Forms.Button TestlineSettingaddbtn;
    }
}