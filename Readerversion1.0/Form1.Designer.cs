namespace Readerversion1._0
{
    partial class Form1
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.loadImageToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.createQRcodeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.analyseQRcodeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.settingToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.methodToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addMethodToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteMethodToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editMethodToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.languageToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.chooseLanguageToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.methodbox = new System.Windows.Forms.ComboBox();
            this.button1 = new System.Windows.Forms.Button();
            this.measurementbtn = new System.Windows.Forms.Button();
            this.videPlayer = new AForge.Controls.VideoSourcePlayer();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.patientfilelab = new System.Windows.Forms.Label();
            this.patientfiletxtbox = new System.Windows.Forms.TextBox();
            this.lastnamelab = new System.Windows.Forms.Label();
            this.lastnametxtbox = new System.Windows.Forms.TextBox();
            this.middlenamelab = new System.Windows.Forms.Label();
            this.middlenametxtbox = new System.Windows.Forms.TextBox();
            this.diagnosislab = new System.Windows.Forms.Label();
            this.diagnosistxtbox = new System.Windows.Forms.TextBox();
            this.assaydatelab = new System.Windows.Forms.Label();
            this.assaydatevalue = new System.Windows.Forms.DateTimePicker();
            this.dataofbirthdaylab = new System.Windows.Forms.Label();
            this.lotlab = new System.Windows.Forms.Label();
            this.idlab = new System.Windows.Forms.Label();
            this.sentbylab = new System.Windows.Forms.Label();
            this.idtxtbox = new System.Windows.Forms.TextBox();
            this.lottxtbox = new System.Windows.Forms.TextBox();
            this.femaleradiobtn = new System.Windows.Forms.RadioButton();
            this.maleradiobtn = new System.Windows.Forms.RadioButton();
            this.genderlab = new System.Windows.Forms.Label();
            this.firstnamelab = new System.Windows.Forms.Label();
            this.Firstnametxtbox = new System.Windows.Forms.TextBox();
            this.Operatorlab = new System.Windows.Forms.Label();
            this.operatortxtbox = new System.Windows.Forms.TextBox();
            this.Form1listView = new System.Windows.Forms.ListView();
            this.Testnametextbox = new System.Windows.Forms.TextBox();
            this.Testnamelabel = new System.Windows.Forms.Label();
            this.Testcodelabel = new System.Windows.Forms.Label();
            this.testcodetextbox = new System.Windows.Forms.TextBox();
            this.birthayvalue = new System.Windows.Forms.DateTimePicker();
            this.sentbytextbox = new System.Windows.Forms.TextBox();
            this.Form1picturebox = new System.Windows.Forms.PictureBox();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Form1picturebox)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.settingToolStripMenuItem,
            this.languageToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1192, 24);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.loadImageToolStripMenuItem,
            this.createQRcodeToolStripMenuItem,
            this.analyseQRcodeToolStripMenuItem,
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // loadImageToolStripMenuItem
            // 
            this.loadImageToolStripMenuItem.Name = "loadImageToolStripMenuItem";
            this.loadImageToolStripMenuItem.Size = new System.Drawing.Size(153, 22);
            this.loadImageToolStripMenuItem.Text = "Load Image";
            this.loadImageToolStripMenuItem.Click += new System.EventHandler(this.loadImageToolStripMenuItem_Click);
            // 
            // createQRcodeToolStripMenuItem
            // 
            this.createQRcodeToolStripMenuItem.Name = "createQRcodeToolStripMenuItem";
            this.createQRcodeToolStripMenuItem.Size = new System.Drawing.Size(153, 22);
            this.createQRcodeToolStripMenuItem.Text = "Create QRcode";
            this.createQRcodeToolStripMenuItem.Visible = false;
            this.createQRcodeToolStripMenuItem.Click += new System.EventHandler(this.createQRcodeToolStripMenuItem_Click);
            // 
            // analyseQRcodeToolStripMenuItem
            // 
            this.analyseQRcodeToolStripMenuItem.Name = "analyseQRcodeToolStripMenuItem";
            this.analyseQRcodeToolStripMenuItem.Size = new System.Drawing.Size(153, 22);
            this.analyseQRcodeToolStripMenuItem.Text = "Read QRcode";
            this.analyseQRcodeToolStripMenuItem.Visible = false;
            this.analyseQRcodeToolStripMenuItem.Click += new System.EventHandler(this.analyseQRcodeToolStripMenuItem_Click);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(153, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // settingToolStripMenuItem
            // 
            this.settingToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.methodToolStripMenuItem});
            this.settingToolStripMenuItem.Name = "settingToolStripMenuItem";
            this.settingToolStripMenuItem.Size = new System.Drawing.Size(56, 20);
            this.settingToolStripMenuItem.Text = "Setting";
            // 
            // methodToolStripMenuItem
            // 
            this.methodToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addMethodToolStripMenuItem,
            this.deleteMethodToolStripMenuItem,
            this.editMethodToolStripMenuItem});
            this.methodToolStripMenuItem.Name = "methodToolStripMenuItem";
            this.methodToolStripMenuItem.Size = new System.Drawing.Size(116, 22);
            this.methodToolStripMenuItem.Text = "Method";
            // 
            // addMethodToolStripMenuItem
            // 
            this.addMethodToolStripMenuItem.Name = "addMethodToolStripMenuItem";
            this.addMethodToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.addMethodToolStripMenuItem.Text = "Add Method";
            this.addMethodToolStripMenuItem.Click += new System.EventHandler(this.addMethodToolStripMenuItem_Click);
            // 
            // deleteMethodToolStripMenuItem
            // 
            this.deleteMethodToolStripMenuItem.Name = "deleteMethodToolStripMenuItem";
            this.deleteMethodToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.deleteMethodToolStripMenuItem.Text = "Delete Method";
            this.deleteMethodToolStripMenuItem.Click += new System.EventHandler(this.deleteMethodToolStripMenuItem_Click);
            // 
            // editMethodToolStripMenuItem
            // 
            this.editMethodToolStripMenuItem.Name = "editMethodToolStripMenuItem";
            this.editMethodToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.editMethodToolStripMenuItem.Text = "Edit Method";
            this.editMethodToolStripMenuItem.Click += new System.EventHandler(this.editMethodToolStripMenuItem_Click);
            // 
            // languageToolStripMenuItem
            // 
            this.languageToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.chooseLanguageToolStripMenuItem});
            this.languageToolStripMenuItem.Name = "languageToolStripMenuItem";
            this.languageToolStripMenuItem.Size = new System.Drawing.Size(71, 20);
            this.languageToolStripMenuItem.Text = "Language";
            // 
            // chooseLanguageToolStripMenuItem
            // 
            this.chooseLanguageToolStripMenuItem.Name = "chooseLanguageToolStripMenuItem";
            this.chooseLanguageToolStripMenuItem.Size = new System.Drawing.Size(166, 22);
            this.chooseLanguageToolStripMenuItem.Text = "Choose language";
            this.chooseLanguageToolStripMenuItem.Click += new System.EventHandler(this.chooseLanguageToolStripMenuItem_Click);
            // 
            // methodbox
            // 
            this.methodbox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.methodbox.Font = new System.Drawing.Font("宋体", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.methodbox.FormattingEnabled = true;
            this.methodbox.ItemHeight = 29;
            this.methodbox.Location = new System.Drawing.Point(0, 30);
            this.methodbox.Name = "methodbox";
            this.methodbox.Size = new System.Drawing.Size(1192, 37);
            this.methodbox.TabIndex = 2;
            this.methodbox.SelectedIndexChanged += new System.EventHandler(this.methodbox_SelectedIndexChanged);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(38, 704);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 25);
            this.button1.TabIndex = 3;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Visible = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // measurementbtn
            // 
            this.measurementbtn.Location = new System.Drawing.Point(260, 705);
            this.measurementbtn.Name = "measurementbtn";
            this.measurementbtn.Size = new System.Drawing.Size(260, 25);
            this.measurementbtn.TabIndex = 4;
            this.measurementbtn.Text = "Scan";
            this.measurementbtn.UseVisualStyleBackColor = true;
            this.measurementbtn.Click += new System.EventHandler(this.measurementbtn_Click);
            // 
            // videPlayer
            // 
            this.videPlayer.Location = new System.Drawing.Point(180, 375);
            this.videPlayer.Name = "videPlayer";
            this.videPlayer.Size = new System.Drawing.Size(200, 155);
            this.videPlayer.TabIndex = 18;
            this.videPlayer.Text = "videPlayer";
            this.videPlayer.VideoSource = null;
            this.videPlayer.NewFrame += new AForge.Controls.VideoSourcePlayer.NewFrameHandler(this.videPlayer_NewFrame);
            // 
            // tabControl1
            // 
            this.tabControl1.Location = new System.Drawing.Point(12, 288);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(757, 387);
            this.tabControl1.TabIndex = 19;
            // 
            // patientfilelab
            // 
            this.patientfilelab.AutoSize = true;
            this.patientfilelab.Location = new System.Drawing.Point(807, 83);
            this.patientfilelab.Name = "patientfilelab";
            this.patientfilelab.Size = new System.Drawing.Size(76, 13);
            this.patientfilelab.TabIndex = 20;
            this.patientfilelab.Text = "Patient file No.";
            // 
            // patientfiletxtbox
            // 
            this.patientfiletxtbox.Location = new System.Drawing.Point(808, 100);
            this.patientfiletxtbox.Name = "patientfiletxtbox";
            this.patientfiletxtbox.Size = new System.Drawing.Size(100, 20);
            this.patientfiletxtbox.TabIndex = 21;
            this.patientfiletxtbox.Text = "0";
            // 
            // lastnamelab
            // 
            this.lastnamelab.AutoSize = true;
            this.lastnamelab.Location = new System.Drawing.Point(807, 137);
            this.lastnamelab.Name = "lastnamelab";
            this.lastnamelab.Size = new System.Drawing.Size(56, 13);
            this.lastnamelab.TabIndex = 22;
            this.lastnamelab.Text = "Last name";
            // 
            // lastnametxtbox
            // 
            this.lastnametxtbox.Location = new System.Drawing.Point(808, 153);
            this.lastnametxtbox.Name = "lastnametxtbox";
            this.lastnametxtbox.Size = new System.Drawing.Size(100, 20);
            this.lastnametxtbox.TabIndex = 23;
            this.lastnametxtbox.Text = "xxx";
            // 
            // middlenamelab
            // 
            this.middlenamelab.AutoSize = true;
            this.middlenamelab.Location = new System.Drawing.Point(808, 190);
            this.middlenamelab.Name = "middlenamelab";
            this.middlenamelab.Size = new System.Drawing.Size(67, 13);
            this.middlenamelab.TabIndex = 24;
            this.middlenamelab.Text = "Middle name";
            // 
            // middlenametxtbox
            // 
            this.middlenametxtbox.Location = new System.Drawing.Point(809, 206);
            this.middlenametxtbox.Name = "middlenametxtbox";
            this.middlenametxtbox.Size = new System.Drawing.Size(100, 20);
            this.middlenametxtbox.TabIndex = 25;
            this.middlenametxtbox.Text = "xxx";
            // 
            // diagnosislab
            // 
            this.diagnosislab.AutoSize = true;
            this.diagnosislab.Location = new System.Drawing.Point(808, 295);
            this.diagnosislab.Name = "diagnosislab";
            this.diagnosislab.Size = new System.Drawing.Size(53, 13);
            this.diagnosislab.TabIndex = 26;
            this.diagnosislab.Text = "Diagnosis";
            // 
            // diagnosistxtbox
            // 
            this.diagnosistxtbox.Location = new System.Drawing.Point(810, 311);
            this.diagnosistxtbox.Name = "diagnosistxtbox";
            this.diagnosistxtbox.Size = new System.Drawing.Size(100, 20);
            this.diagnosistxtbox.TabIndex = 27;
            this.diagnosistxtbox.Text = "xxx";
            // 
            // assaydatelab
            // 
            this.assaydatelab.AutoSize = true;
            this.assaydatelab.Location = new System.Drawing.Point(808, 345);
            this.assaydatelab.Name = "assaydatelab";
            this.assaydatelab.Size = new System.Drawing.Size(59, 13);
            this.assaydatelab.TabIndex = 28;
            this.assaydatelab.Text = "Assay date";
            // 
            // assaydatevalue
            // 
            this.assaydatevalue.CalendarFont = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.assaydatevalue.Checked = false;
            this.assaydatevalue.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.assaydatevalue.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.assaydatevalue.Location = new System.Drawing.Point(810, 361);
            this.assaydatevalue.Name = "assaydatevalue";
            this.assaydatevalue.Size = new System.Drawing.Size(129, 21);
            this.assaydatevalue.TabIndex = 29;
            // 
            // dataofbirthdaylab
            // 
            this.dataofbirthdaylab.AutoSize = true;
            this.dataofbirthdaylab.Location = new System.Drawing.Point(994, 83);
            this.dataofbirthdaylab.Name = "dataofbirthdaylab";
            this.dataofbirthdaylab.Size = new System.Drawing.Size(65, 13);
            this.dataofbirthdaylab.TabIndex = 30;
            this.dataofbirthdaylab.Text = "Date of birth";
            // 
            // lotlab
            // 
            this.lotlab.AutoSize = true;
            this.lotlab.Location = new System.Drawing.Point(994, 137);
            this.lotlab.Name = "lotlab";
            this.lotlab.Size = new System.Drawing.Size(28, 13);
            this.lotlab.TabIndex = 32;
            this.lotlab.Text = "LOT";
            // 
            // idlab
            // 
            this.idlab.AutoSize = true;
            this.idlab.Location = new System.Drawing.Point(994, 190);
            this.idlab.Name = "idlab";
            this.idlab.Size = new System.Drawing.Size(68, 13);
            this.idlab.TabIndex = 33;
            this.idlab.Text = "Specimen ID";
            // 
            // sentbylab
            // 
            this.sentbylab.AutoSize = true;
            this.sentbylab.Location = new System.Drawing.Point(994, 242);
            this.sentbylab.Name = "sentbylab";
            this.sentbylab.Size = new System.Drawing.Size(85, 13);
            this.sentbylab.TabIndex = 34;
            this.sentbylab.Text = "Referring Doctor";
            // 
            // idtxtbox
            // 
            this.idtxtbox.Location = new System.Drawing.Point(996, 206);
            this.idtxtbox.Name = "idtxtbox";
            this.idtxtbox.Size = new System.Drawing.Size(100, 20);
            this.idtxtbox.TabIndex = 36;
            this.idtxtbox.Text = "0";
            // 
            // lottxtbox
            // 
            this.lottxtbox.Location = new System.Drawing.Point(996, 153);
            this.lottxtbox.Name = "lottxtbox";
            this.lottxtbox.Size = new System.Drawing.Size(100, 20);
            this.lottxtbox.TabIndex = 37;
            this.lottxtbox.Text = "0";
            // 
            // femaleradiobtn
            // 
            this.femaleradiobtn.AutoSize = true;
            this.femaleradiobtn.Location = new System.Drawing.Point(1049, 308);
            this.femaleradiobtn.Name = "femaleradiobtn";
            this.femaleradiobtn.Size = new System.Drawing.Size(56, 17);
            this.femaleradiobtn.TabIndex = 38;
            this.femaleradiobtn.TabStop = true;
            this.femaleradiobtn.Text = "female";
            this.femaleradiobtn.UseVisualStyleBackColor = true;
            // 
            // maleradiobtn
            // 
            this.maleradiobtn.AutoSize = true;
            this.maleradiobtn.Location = new System.Drawing.Point(996, 308);
            this.maleradiobtn.Name = "maleradiobtn";
            this.maleradiobtn.Size = new System.Drawing.Size(47, 17);
            this.maleradiobtn.TabIndex = 39;
            this.maleradiobtn.TabStop = true;
            this.maleradiobtn.Text = "male";
            this.maleradiobtn.UseVisualStyleBackColor = true;
            // 
            // genderlab
            // 
            this.genderlab.AutoSize = true;
            this.genderlab.Location = new System.Drawing.Point(994, 290);
            this.genderlab.Name = "genderlab";
            this.genderlab.Size = new System.Drawing.Size(42, 13);
            this.genderlab.TabIndex = 40;
            this.genderlab.Text = "Gender";
            // 
            // firstnamelab
            // 
            this.firstnamelab.AutoSize = true;
            this.firstnamelab.Location = new System.Drawing.Point(808, 242);
            this.firstnamelab.Name = "firstnamelab";
            this.firstnamelab.Size = new System.Drawing.Size(55, 13);
            this.firstnamelab.TabIndex = 41;
            this.firstnamelab.Text = "First name";
            // 
            // Firstnametxtbox
            // 
            this.Firstnametxtbox.Location = new System.Drawing.Point(810, 258);
            this.Firstnametxtbox.Name = "Firstnametxtbox";
            this.Firstnametxtbox.Size = new System.Drawing.Size(100, 20);
            this.Firstnametxtbox.TabIndex = 42;
            this.Firstnametxtbox.Text = "xxx";
            // 
            // Operatorlab
            // 
            this.Operatorlab.AutoSize = true;
            this.Operatorlab.Location = new System.Drawing.Point(994, 345);
            this.Operatorlab.Name = "Operatorlab";
            this.Operatorlab.Size = new System.Drawing.Size(48, 13);
            this.Operatorlab.TabIndex = 43;
            this.Operatorlab.Text = "Operator";
            // 
            // operatortxtbox
            // 
            this.operatortxtbox.Location = new System.Drawing.Point(996, 361);
            this.operatortxtbox.Name = "operatortxtbox";
            this.operatortxtbox.Size = new System.Drawing.Size(100, 20);
            this.operatortxtbox.TabIndex = 44;
            this.operatortxtbox.Text = "xxx";
            // 
            // Form1listView
            // 
            this.Form1listView.Location = new System.Drawing.Point(808, 461);
            this.Form1listView.Name = "Form1listView";
            this.Form1listView.Size = new System.Drawing.Size(306, 214);
            this.Form1listView.TabIndex = 45;
            this.Form1listView.UseCompatibleStateImageBehavior = false;
            // 
            // Testnametextbox
            // 
            this.Testnametextbox.Location = new System.Drawing.Point(811, 418);
            this.Testnametextbox.Name = "Testnametextbox";
            this.Testnametextbox.Size = new System.Drawing.Size(100, 20);
            this.Testnametextbox.TabIndex = 46;
            this.Testnametextbox.Text = "xxx";
            // 
            // Testnamelabel
            // 
            this.Testnamelabel.AutoSize = true;
            this.Testnamelabel.Location = new System.Drawing.Point(808, 402);
            this.Testnamelabel.Name = "Testnamelabel";
            this.Testnamelabel.Size = new System.Drawing.Size(59, 13);
            this.Testnamelabel.TabIndex = 47;
            this.Testnamelabel.Text = "Test Name";
            // 
            // Testcodelabel
            // 
            this.Testcodelabel.AutoSize = true;
            this.Testcodelabel.Location = new System.Drawing.Point(993, 402);
            this.Testcodelabel.Name = "Testcodelabel";
            this.Testcodelabel.Size = new System.Drawing.Size(56, 13);
            this.Testcodelabel.TabIndex = 49;
            this.Testcodelabel.Text = "Test Code";
            // 
            // testcodetextbox
            // 
            this.testcodetextbox.Location = new System.Drawing.Point(996, 418);
            this.testcodetextbox.Name = "testcodetextbox";
            this.testcodetextbox.Size = new System.Drawing.Size(100, 20);
            this.testcodetextbox.TabIndex = 48;
            this.testcodetextbox.Text = "000";
            // 
            // birthayvalue
            // 
            this.birthayvalue.CalendarFont = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.birthayvalue.Checked = false;
            this.birthayvalue.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.birthayvalue.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.birthayvalue.Location = new System.Drawing.Point(996, 97);
            this.birthayvalue.Name = "birthayvalue";
            this.birthayvalue.Size = new System.Drawing.Size(129, 21);
            this.birthayvalue.TabIndex = 50;
            // 
            // sentbytextbox
            // 
            this.sentbytextbox.Location = new System.Drawing.Point(997, 258);
            this.sentbytextbox.Name = "sentbytextbox";
            this.sentbytextbox.Size = new System.Drawing.Size(100, 20);
            this.sentbytextbox.TabIndex = 51;
            this.sentbytextbox.Text = "xxx";
            // 
            // Form1picturebox
            // 
            this.Form1picturebox.Location = new System.Drawing.Point(12, 83);
            this.Form1picturebox.Name = "Form1picturebox";
            this.Form1picturebox.Size = new System.Drawing.Size(757, 195);
            this.Form1picturebox.TabIndex = 52;
            this.Form1picturebox.TabStop = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1192, 742);
            this.Controls.Add(this.Form1picturebox);
            this.Controls.Add(this.sentbytextbox);
            this.Controls.Add(this.birthayvalue);
            this.Controls.Add(this.Testcodelabel);
            this.Controls.Add(this.testcodetextbox);
            this.Controls.Add(this.Testnamelabel);
            this.Controls.Add(this.Testnametextbox);
            this.Controls.Add(this.Form1listView);
            this.Controls.Add(this.operatortxtbox);
            this.Controls.Add(this.Operatorlab);
            this.Controls.Add(this.Firstnametxtbox);
            this.Controls.Add(this.firstnamelab);
            this.Controls.Add(this.genderlab);
            this.Controls.Add(this.maleradiobtn);
            this.Controls.Add(this.femaleradiobtn);
            this.Controls.Add(this.lottxtbox);
            this.Controls.Add(this.idtxtbox);
            this.Controls.Add(this.sentbylab);
            this.Controls.Add(this.idlab);
            this.Controls.Add(this.lotlab);
            this.Controls.Add(this.dataofbirthdaylab);
            this.Controls.Add(this.assaydatevalue);
            this.Controls.Add(this.assaydatelab);
            this.Controls.Add(this.diagnosistxtbox);
            this.Controls.Add(this.diagnosislab);
            this.Controls.Add(this.middlenametxtbox);
            this.Controls.Add(this.middlenamelab);
            this.Controls.Add(this.lastnametxtbox);
            this.Controls.Add(this.lastnamelab);
            this.Controls.Add(this.patientfiletxtbox);
            this.Controls.Add(this.patientfilelab);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.videPlayer);
            this.Controls.Add(this.measurementbtn);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.methodbox);
            this.Controls.Add(this.menuStrip1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Form1picturebox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem settingToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem methodToolStripMenuItem;
        private System.Windows.Forms.ComboBox methodbox;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button measurementbtn;
        private AForge.Controls.VideoSourcePlayer videPlayer;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.Label patientfilelab;
        private System.Windows.Forms.TextBox patientfiletxtbox;
        private System.Windows.Forms.Label lastnamelab;
        private System.Windows.Forms.TextBox lastnametxtbox;
        private System.Windows.Forms.Label middlenamelab;
        private System.Windows.Forms.TextBox middlenametxtbox;
        private System.Windows.Forms.Label diagnosislab;
        private System.Windows.Forms.TextBox diagnosistxtbox;
        private System.Windows.Forms.Label assaydatelab;
        private System.Windows.Forms.DateTimePicker assaydatevalue;
        private System.Windows.Forms.Label dataofbirthdaylab;
        private System.Windows.Forms.Label lotlab;
        private System.Windows.Forms.Label idlab;
        private System.Windows.Forms.Label sentbylab;
        private System.Windows.Forms.TextBox idtxtbox;
        private System.Windows.Forms.TextBox lottxtbox;
        private System.Windows.Forms.RadioButton femaleradiobtn;
        private System.Windows.Forms.RadioButton maleradiobtn;
        private System.Windows.Forms.Label genderlab;
        private System.Windows.Forms.Label firstnamelab;
        private System.Windows.Forms.TextBox Firstnametxtbox;
        private System.Windows.Forms.Label Operatorlab;
        private System.Windows.Forms.TextBox operatortxtbox;
        private System.Windows.Forms.ListView Form1listView;
        private System.Windows.Forms.TextBox Testnametextbox;
        private System.Windows.Forms.Label Testnamelabel;
        private System.Windows.Forms.Label Testcodelabel;
        private System.Windows.Forms.TextBox testcodetextbox;
        private System.Windows.Forms.DateTimePicker birthayvalue;
        private System.Windows.Forms.TextBox sentbytextbox;
        private System.Windows.Forms.ToolStripMenuItem loadImageToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem createQRcodeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem analyseQRcodeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem addMethodToolStripMenuItem;
        private System.Windows.Forms.PictureBox Form1picturebox;
        private System.Windows.Forms.ToolStripMenuItem languageToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem chooseLanguageToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem deleteMethodToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem editMethodToolStripMenuItem;
    }
}

