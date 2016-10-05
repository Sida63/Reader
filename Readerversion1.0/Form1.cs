using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Collections;
using MySql.Data.MySqlClient;
using AForge;
using AForge.Video;
using AForge.Video.DirectShow;
using AForge.Imaging;
using AForge.Imaging.Filters;
using System.Timers;
using System.Windows.Forms.DataVisualization.Charting;
using com.google.zxing;
using com.google.zxing.common;
using System.Text.RegularExpressions;
using System.Globalization;
using System.IO;
using System.Threading;

namespace Readerversion1._0
{
    public partial class Form1 : Form
    {
        public static string language="";
        public static Form form;
        public static ImageProcessing imageprocess;
        public static Noticeform noticeform;
        public static Thread t1;
        private ArrayList methodlist = new ArrayList();
        private MethodEntity methodentity;
        private Databaseoperator database = new Databaseoperator();
        private FilterInfoCollection videoDevices;
        private Bitmap bitmapentity;
        private Bitmap bitmapentitytemp;
        private Bitmap pictureboxbitmap;
        private ArrayList chartlist = new ArrayList();
        private string content = "";
        private Pointentity setclassentity;
        private System.Collections.ArrayList colorlist;
        private System.Timers.Timer aTimer;
        private ArrayList bitmaplistqueue = new ArrayList();
        private ArrayList combinedimagelist = new ArrayList();
        private System.Collections.ArrayList namelist = new ArrayList();
        private Bitmap combinedimage;
        private int outflag = 1;
        private int controlnoticeform = 0;
        private ArrayList testdatalist=new ArrayList();
        private int closecameraflag = 0;
        private string imagepath;
        Graphics g;
        private ArrayList sampleimmagelist = new ArrayList();
        private Databaseoperator databaseoperator = new Databaseoperator();
        private int flag = 1;
        private VideoCaptureDevice videoSource;
        public Form1()
        {
            InitializeComponent();
            Databaseoperator mysqltest = new Databaseoperator();
            if (mysqltest.testconnectdatabase() == true)
            {
                loaddata();
                //dateTimePicker1.CustomFormat = "yyyy-MM-dd";
                //dateTimePicker1.Format = DateTimePickerFormat.Custom;
                //dateTimePicker1.ShowUpDown = true;
                maleradiobtn.Checked = true;
            }
            else
            {
                database.createcatabase();
                database.createtestdatabase();
                database.createtable();
                database.createtestinfotable();       
            }
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Dispose();
            Application.Exit();
        }

        private void methodToolStripMenuItem_Click(object sender, EventArgs e)
        {
            form = new Method(this, methodlist);
            form.ShowDialog();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            if (methodlist.Count != 0)
            {
                for (int i = 0; i < methodlist.Count; i++)
                {
                    MethodEntity methodentitytemp = (MethodEntity)methodlist[i];
                    methodbox.Items.Add(methodentitytemp.getmethodname());
                }
                methodbox.SelectedIndex = 0;
            }
        }

        internal void OnLoad()
        {
           if (methodlist.Count != 0)
            {
                for (int i = 0; i < methodlist.Count; i++)
                {
                    MethodEntity methodentitytemp = (MethodEntity)methodlist[i];
                    if (methodbox.Items.Contains(methodentitytemp.getmethodname()) == false)
                        methodbox.Items.Add(methodentitytemp.getmethodname());
                }
                methodbox.SelectedIndex = 0;
            }
            
            
        }
        internal void refreshlanguage(string name)
        {
            language = name;
            StreamReader sr = new StreamReader(System.Environment.CurrentDirectory + "\\"+name+".txt", Encoding.Default);
            String line;
            while ((line = sr.ReadLine()) != null)
            {
                Regex reg = new Regex("[A-Za-z0-9]*:");
                MatchCollection match = reg.Matches(line);
                if (match.Count != 0)
                {
                    reg = new Regex("[A-Za-z0-9]+");
                    match = reg.Matches(match[0].ToString());
                    string result = sr.ReadLine();
                    for (int i = 0; i < this.Controls.Count; i++)
                    {
                        if (this.Controls[i].Name == match[0].ToString())
                        {
                            this.Controls[i].Text = result;
                            break;
                        }
                        else if (this.Controls[i].Name == "menuStrip1")
                        {
                            for(int k=0;k<((MenuStrip)this.Controls[i]).Items.Count;k++)
                            {
                                if (((MenuStrip)this.Controls[i]).Items[k].Name == match[0].ToString())
                                {
                                    ((MenuStrip)this.Controls[i]).Items[k].Text = result;
                                }
                                else
                                {
                                    if (((ToolStripMenuItem)((MenuStrip)this.Controls[i]).Items[k]).DropDownItems.Count != 0)
                                    {
                                        for (int m = 0; m < ((ToolStripMenuItem)((MenuStrip)this.Controls[i]).Items[k]).DropDownItems.Count; m++)
                                        {
                                            if (((ToolStripMenuItem)((MenuStrip)this.Controls[i]).Items[k]).DropDownItems[m].Name == match[0].ToString())
                                            {
                                                ((ToolStripMenuItem)((MenuStrip)this.Controls[i]).Items[k]).DropDownItems[m].Text = result;

                                            }
                                            else
                                            {
                                                if (((ToolStripMenuItem)((ToolStripMenuItem)((MenuStrip)this.Controls[i]).Items[k]).DropDownItems[m]).DropDownItems.Count != 0)
                                                {
                                                    for (int n = 0; n < ((ToolStripMenuItem)((ToolStripMenuItem)((MenuStrip)this.Controls[i]).Items[k]).DropDownItems[m]).DropDownItems.Count; n++)
                                                    {
                                                        if (((ToolStripMenuItem)((ToolStripMenuItem)((MenuStrip)this.Controls[i]).Items[k]).DropDownItems[m]).DropDownItems[n].Name == match[0].ToString())
                                                        {
                                                            ((ToolStripMenuItem)((ToolStripMenuItem)((MenuStrip)this.Controls[i]).Items[k]).DropDownItems[m]).DropDownItems[n].Text = result;
                                                        }
                                                    }
                                                }
                                            }
                                        }
                                    }
                                }
                                
                            }
                            
                        }
                    }
                }
            }
            
        }

        private void button1_Click(object sender, EventArgs e)
        {

          
                if (closecameraflag == 0 && controlnoticeform == 0)
                {
                    //noticeform.Show();
                    
                    noticeform.Controls[0].UseWaitCursor=true;
                    
                    noticeform.Show();
                    noticeform.Refresh();
                }
                
                while (true)
                {
                    noticeform.Controls[0].Text = "Please Wait...";
                if (closecameraflag == 1)
                {
                    noticeform.Close();
                    controlnoticeform = 0;
                    break;
                }
            }
        }
        private void loaddata()
        {
            MySqlDataReader mysqlreader = database.selectall("Methodtable");
            while (mysqlreader.Read())
            {
                for (int methodi = 1; methodi < mysqlreader.FieldCount; methodi++)
                {
                    if (methodi == 1)
                    {
                        MethodEntity methodentitytemp = new MethodEntity();
                        methodentitytemp.setmethodname(mysqlreader[methodi].ToString());
                        bool mark = false;
                        for (int methodj = 0; methodj < methodlist.Count; methodj++)
                        {
                            if (((MethodEntity)methodlist[methodj]).getmethodname() == methodentitytemp.getmethodname())
                                mark = true;
                        }
                        if (mark == false)
                        {
                            MySqlDataReader mysqlreadermethod = database.select("Methodtable", "Methodname", mysqlreader[methodi].ToString());
                            while (mysqlreadermethod.Read())
                            {
                                for (int settingj = 0; settingj < mysqlreadermethod.FieldCount; settingj++)
                                {
                                    if (settingj == 2)//name
                                    {
                                        Settingentity temp = new Settingentity();
                                        MySqlDataReader mysqldatatemp = database.select("Settingentitytable", "Paramaterindex", mysqlreader[methodi].ToString() + mysqlreadermethod[settingj].ToString());
                                        temp.setparamatername(mysqlreadermethod[settingj].ToString());
                                        while (mysqldatatemp.Read())
                                        {
                                            for (int settingentityi = 0; settingentityi < mysqldatatemp.FieldCount; settingentityi++)
                                            {
                                                if (settingentityi == 2)
                                                    temp.setclinevalue(mysqldatatemp[settingentityi].ToString());
                                                else if (settingentityi == 3)
                                                    temp.setshuttertimes(int.Parse(mysqldatatemp[settingentityi].ToString()));
                                                else if (settingentityi == 4)
                                                {
                                                    temp.setreadytime(int.Parse(mysqldatatemp[settingentityi].ToString()));
                                                    MySqlDataReader mysqlresult = database.select("Resulttable", "Resultvalueindex", mysqlreader[methodi].ToString() + mysqlreadermethod[settingj].ToString());
                                                    while (mysqlresult.Read())
                                                    {
                                                        ResultEntity resulttemp = new ResultEntity();
                                                        for (int resulti = 0; resulti < mysqlresult.FieldCount; resulti++)
                                                        {

                                                            if (resulti == 2)
                                                                resulttemp.setresultname(mysqlresult[resulti].ToString());
                                                            if (resulti == 3)
                                                                resulttemp.setresultstartvalue(int.Parse(mysqlresult[resulti].ToString()));
                                                            if(resulti == 4)
                                                                resulttemp.setresultendvalue(int.Parse(mysqlresult[resulti].ToString()));
                                                            if (resulti == 5)
                                                                resulttemp.setresultvalue(mysqlresult[resulti].ToString());
                                                        }
                                                        temp.getresultentitylist().Add(resulttemp);
                                                    }
                                                    MySqlDataReader mysqlrect = database.select("Rectangletable", "rectangleindex", mysqlreader[methodi].ToString() + mysqlreadermethod[settingj].ToString());
                                                    while (mysqlrect.Read())
                                                    {
                                                        int x = 0, y = 0, width = 0, height = 0;
                                                        for (int recti = 0; recti < mysqlrect.FieldCount; recti++)
                                                        {

                                                            if (recti == 2)
                                                                x = int.Parse(mysqlrect[recti].ToString());
                                                            else if (recti == 3)
                                                                y = int.Parse(mysqlrect[recti].ToString());
                                                            else if (recti == 4)
                                                                width = int.Parse(mysqlrect[recti].ToString());
                                                            else if (recti == 5)
                                                                height = int.Parse(mysqlrect[recti].ToString());
                                                        }
                                                        ((ImageSampleEntity)temp.getImageSample()).setimagesample(x, y, width, height);
                                                    }
                                                    MySqlDataReader mysqlsetzone = database.select("Setzonetable", "Setzoneindex", mysqlreader[methodi].ToString() + mysqlreadermethod[settingj].ToString());
                                                    while (mysqlsetzone.Read())
                                                    {
                                                        Setzoneentity tempsetzoneentity=new Setzoneentity(int.Parse(mysqlsetzone[3].ToString()),int.Parse(mysqlsetzone[4].ToString()),int.Parse(mysqlsetzone[5].ToString()),int.Parse(mysqlsetzone[6].ToString()),mysqlsetzone[7].ToString());
                                                        temp.getImageSample().getcontrolzonelist().Add(tempsetzoneentity);
                                                    }
                                                }


                                            }

                                        }
                                        methodentitytemp.getsettinglist().Add(temp);
                                    }

                                }
                            }

                            methodlist.Add(methodentitytemp);

                        }
                    }
                    else
                    {
                        MethodEntity methodentitytemp = (MethodEntity)methodlist[methodlist.Count - 1];
                        if (methodi == 4)
                        {
                            methodentitytemp.getcameraandsourcesetting().setbrightnes(int.Parse(mysqlreader[methodi].ToString()));
                        }
                        if (methodi == 5)
                        {
                            methodentitytemp.getcameraandsourcesetting().setcontrast(int.Parse(mysqlreader[methodi].ToString()));
                        }
                        if (methodi == 6)
                        {
                            methodentitytemp.getcameraandsourcesetting().setsaturation(float.Parse(mysqlreader[methodi].ToString()));
                        }
                        if (methodi == 7)
                        {
                            methodentitytemp.getcameraandsourcesetting().setcameraname(mysqlreader[methodi].ToString());
                        }
                        if (methodi == 8)
                        {
                            methodentitytemp.getcameraandsourcesetting().setresolution(int.Parse(mysqlreader[methodi].ToString()));
                        }
                        if (methodi == 9)
                        {
                            methodentitytemp.setsensitive(int.Parse(mysqlreader[methodi].ToString()));
                        }
                        if (methodi == 10)
                        {
                            methodentitytemp.setadjustvalue(int.Parse(mysqlreader[methodi].ToString()));
                        }
                    }
                }
            }
            mysqlreader.Close();
            
        }
        private void loaddata(string methodname)
        {
            MySqlDataReader mysqlreader = database.select("Methodtable", "Methodname");
            while (mysqlreader.Read())
            {
                for (int methodi = 0; methodi < mysqlreader.FieldCount; methodi++)
                {
                    if (methodi == 0)
                    {
                        MethodEntity methodentitytemp = new MethodEntity();
                        methodentitytemp.setmethodname(mysqlreader[methodi].ToString());
                        bool mark = false;
                        for (int methodj = 0; methodj < methodlist.Count; methodj++)
                        {
                            if (((MethodEntity)methodlist[methodj]).getmethodname() == methodentitytemp.getmethodname())
                                mark = true;
                        }
                        if (mark == false)
                        {
                            MySqlDataReader mysqlreadermethod = database.select("Methodtable", "Methodname", mysqlreader[methodi].ToString());
                            while (mysqlreadermethod.Read())
                            {
                                for (int settingj = 0; settingj < mysqlreadermethod.FieldCount; settingj++)
                                {
                                    if (settingj == 2)
                                    {
                                        Settingentity temp = new Settingentity();
                                        MySqlDataReader mysqldatatemp = database.select("Settingentitytable", "Paramaterindex", mysqlreader[methodi].ToString() + mysqlreadermethod[settingj].ToString());
                                        temp.setparamatername(mysqlreadermethod[settingj].ToString());
                                        while (mysqldatatemp.Read())
                                        {
                                            for (int settingentityi = 0; settingentityi < mysqldatatemp.FieldCount; settingentityi++)
                                            {
                                                if (settingentityi == 2)
                                                    temp.setclinevalue(mysqldatatemp[settingentityi].ToString());
                                                else if (settingentityi == 3)
                                                    temp.setshuttertimes(int.Parse(mysqldatatemp[settingentityi].ToString()));
                                                else if (settingentityi == 4)
                                                {
                                                    temp.setreadytime(int.Parse(mysqldatatemp[settingentityi].ToString()));
                                                    MySqlDataReader mysqlresult = database.select("Resulttable", "Resultvalueindex", mysqlreader[methodi].ToString() + mysqlreadermethod[settingj].ToString());
                                                    while (mysqlresult.Read())
                                                    {
                                                        ResultEntity resulttemp = new ResultEntity();
                                                        for (int resulti = 0; resulti < mysqlresult.FieldCount; resulti++)
                                                        {

                                                            if (resulti == 2)
                                                                resulttemp.setresultname(mysqlresult[resulti].ToString());
                                                            if (resulti == 3)
                                                                resulttemp.setresultstartvalue(int.Parse(mysqlresult[resulti].ToString()));
                                                            if (resulti == 4)
                                                                resulttemp.setresultendvalue(int.Parse(mysqlresult[resulti].ToString()));
                                                        }
                                                        temp.getresultentitylist().Add(resulttemp);
                                                    }
                                                    MySqlDataReader mysqlrect = database.select("Rectangletable", "rectangleindex", mysqlreader[methodi].ToString() + mysqlreadermethod[settingj].ToString());
                                                    while (mysqlrect.Read())
                                                    {
                                                        int x = 0, y = 0, width = 0, height = 0;
                                                        for (int recti = 0; recti < mysqlrect.FieldCount; recti++)
                                                        {

                                                            if (recti == 2)
                                                                x = int.Parse(mysqlrect[recti].ToString());
                                                            else if (recti == 3)
                                                                y = int.Parse(mysqlrect[recti].ToString());
                                                            else if (recti == 4)
                                                                width = int.Parse(mysqlrect[recti].ToString());
                                                            else if (recti == 5)
                                                                height = int.Parse(mysqlrect[recti].ToString());
                                                        }
                                                        ((ImageSampleEntity)temp.getImageSample()).setimagesample(x, y, width, height);
                                                    }
                                                }


                                            }

                                        }
                                        methodentitytemp.getsettinglist().Add(temp);
                                    }

                                }
                            }
                            methodlist.Add(methodentitytemp);

                        }
                    }
                }
            }
            mysqlreader.Close();
        }
        public void TestMethod()
        {
            noticeform.ShowDialog();
        }
        private void measurementbtn_Click(object sender, EventArgs e)
        {
            //t1 = new Thread(new ThreadStart(TestMethod));
            //t1.Start();
            //t1.Priority = ThreadPriority.Highest;
            //TestMethod();
            testdatalist.Clear();
            methodbox_SelectedIndexChanged(null,null);
            if (combinedimagelist.Count == 0)
            {
                tabControl1.TabPages.Clear();
                string methodname = methodbox.SelectedItem.ToString();
                for (int i = 0; i < methodlist.Count; i++)
                {
                    if (((MethodEntity)methodlist[i]).getmethodname() == methodname)
                    {
                        methodentity = (MethodEntity)methodlist[i];
                    }
                }
                if (!initializecamera())
                {
                    return;
                }
                while (videPlayer.VideoSource.IsRunning == false)
                {

                };
                aTimer = new System.Timers.Timer();
                aTimer.Elapsed += new ElapsedEventHandler(OnTimedEvent);// openning the camera needs some time and using a timer to wait for it.
                // Set the Interval
                aTimer.Interval = 3000;
                aTimer.Enabled = true;            
                while (true)
                {
                    if (closecameraflag == 0 && controlnoticeform == 0)
                    {
                        noticeform = new Noticeform();//provide a notice for user when dealing with the data
                        noticeform.Show();
                        noticeform.Refresh();
                        controlnoticeform = 1;
                    }
                    if (closecameraflag == 1)
                    {
                        noticeform.Close();
                        controlnoticeform = 0;
                        break;
                    }
                }
                closecaamera();
                scanpicture(sampleimmagelist);//scan pictures and prepare the data for the next step
                darwpicture();
                
                for (int i = 0; i < sampleimmagelist.Count; i++)
                {
                    int count = 0;
                    Bitmap tempsampleimage = (Bitmap)((Settingimageentity)sampleimmagelist[i]).getimage().Clone();
                    if (((Settingentity)methodentity.getsettinglist()[i]).getlinevalue() == "Color")
                    {
                        ContrastCorrection filter = new ContrastCorrection(-methodentity.getcameraandsourcesetting().getcontrast());
                        BrightnessCorrection bfilter = new BrightnessCorrection(-methodentity.getcameraandsourcesetting().getbrightness());
                        SaturationCorrection sfilter = new SaturationCorrection(-methodentity.getcameraandsourcesetting().getsaturation());
                        bfilter.ApplyInPlace(tempsampleimage);
                        filter.ApplyInPlace(tempsampleimage);
                        sfilter.ApplyInPlace(tempsampleimage);
                        tempsampleimage.Save(Environment.CurrentDirectory + "\\image\\" + "tempsampleimage" + ".jpg");
                        ((Testdata)testdatalist[i]).setresult("Color");
                        ((Testdata)testdatalist[i]).setifvalid("uvalid");
                        int bluenumber = 0;
                        int rednumber = 0;
                        int greennumber = 0;
                        for (int dcolori = 0; dcolori < tempsampleimage.Height; dcolori++)
                        {
                            for (int dcolorj = 0; dcolorj < tempsampleimage.Width; dcolorj++)
                            {
                                Color colorcurrent = tempsampleimage.GetPixel(dcolorj, dcolori);
                                bluenumber = bluenumber + colorcurrent.B;
                                rednumber = rednumber + colorcurrent.R;
                                greennumber = greennumber + colorcurrent.G;
                            }
                        }
                        Color finalcolor = Color.FromArgb(rednumber / (tempsampleimage.Height * tempsampleimage.Width), bluenumber / (tempsampleimage.Height * tempsampleimage.Width), greennumber / (tempsampleimage.Height * tempsampleimage.Width));
                        float hue = finalcolor.GetHue();
                        float saturation = finalcolor.GetSaturation();
                        float lightness = finalcolor.GetBrightness();
                        for (int colori = 0; colori < ((Settingentity)methodentity.getsettinglist()[i]).getresultentitylist().Count; colori++)
                        {
                            if (((ResultEntity)((Settingentity)methodentity.getsettinglist()[i]).getresultentitylist()[colori]).getresultname() == "Test line")
                            {
                                if (hue >= ((ResultEntity)((Settingentity)methodentity.getsettinglist()[i]).getresultentitylist()[colori]).getresultstartvalue() && hue <= ((ResultEntity)((Settingentity)methodentity.getsettinglist()[i]).getresultentitylist()[colori]).getresultendvalue())
                                {
                                    ((Testdata)testdatalist[i]).setresult(((ResultEntity)((Settingentity)methodentity.getsettinglist()[i]).getresultentitylist()[colori]).getresultvalue());
                                    break;
                                }
                            }
                        }
                            
                                //txtMsg.Text = txtMsg.Text + "\r\n" + "hue:" + hue.ToString() + " saturation:" + saturation.ToString() + " lightness:" + lightness.ToString() + " data:" + finalcolor.ToArgb();
                                
                    }
                    else
                    {
                        for (int j = 0; j < ((Settingentity)methodentity.getsettinglist()[i]).getImageSample().getcontrolzonelist().Count; j++)
                        {
                            System.Drawing.Point temppoint = new System.Drawing.Point(((Setzoneentity)((Settingentity)methodentity.getsettinglist()[i]).getImageSample().getcontrolzonelist()[j]).getzonepositionx(), ((Setzoneentity)((Settingentity)methodentity.getsettinglist()[i]).getImageSample().getcontrolzonelist()[j]).getzonepositiony());
                            Size tempsize = new System.Drawing.Size(((Setzoneentity)((Settingentity)methodentity.getsettinglist()[i]).getImageSample().getcontrolzonelist()[j]).getzonepositionwidth(), ((Setzoneentity)((Settingentity)methodentity.getsettinglist()[i]).getImageSample().getcontrolzonelist()[j]).getzonepositionheight());
                            Rectangle rectNew = new Rectangle(temppoint, tempsize);
                            Bitmap newbitmap = new Bitmap(rectNew.Width, rectNew.Height);
                            g = Graphics.FromImage(newbitmap);
                            //g.DrawImage(bitmap, rectNew.Top, rectNew.Left);
                            g.DrawImage(tempsampleimage, -rectNew.Location.X - 1, -rectNew.Y - 1);
                            g.Dispose();
                            newbitmap.Save(Environment.CurrentDirectory + "\\image\\" + "sample" + j + ".jpg");
                            if (((Settingentity)methodentity.getsettinglist()[i]).getlinevalue() == "Competitive")
                            {
                                if (((Setzoneentity)((Settingentity)methodentity.getsettinglist()[i]).getImageSample().getcontrolzonelist()[j]).getzonecategory() == "control")
                                {
                                    for (int resulti = 0; resulti < ((Settingentity)methodentity.getsettinglist()[i]).getresultentitylist().Count; resulti++)
                                    {
                                        if (((ResultEntity)((Settingentity)methodentity.getsettinglist()[i]).getresultentitylist()[resulti]).getresultname() == "Control line")
                                        {
                                            if (((Testdata)testdatalist[i]).getclinevalue() >= ((ResultEntity)((Settingentity)methodentity.getsettinglist()[i]).getresultentitylist()[resulti]).getresultstartvalue() && ((Testdata)testdatalist[i]).getclinevalue() <= ((ResultEntity)((Settingentity)methodentity.getsettinglist()[i]).getresultentitylist()[resulti]).getresultendvalue())
                                            {
                                                //count = count + Averagevalue(newbitmap, methodentity.getsensitive().ToString());
                                                ((Testdata)testdatalist[i]).setifvalid("valid");
                                                resulti = ((Settingentity)methodentity.getsettinglist()[i]).getresultentitylist().Count;
                                            }
                                            else
                                            {
                                                ((Testdata)testdatalist[i]).setifvalid("unvalid");
                                                resulti = ((Settingentity)methodentity.getsettinglist()[i]).getresultentitylist().Count;
                                            }
                                        }
                                    }
                                }
                                else if (((Setzoneentity)((Settingentity)methodentity.getsettinglist()[i]).getImageSample().getcontrolzonelist()[j]).getzonecategory() == "test")
                                {
                                    for (int resulti = 0; resulti < ((Settingentity)methodentity.getsettinglist()[i]).getresultentitylist().Count; resulti++)
                                    {
                                        if (((ResultEntity)((Settingentity)methodentity.getsettinglist()[i]).getresultentitylist()[resulti]).getresultname() == "Test line")
                                        {
                                            if (((Testdata)testdatalist[i]).gettlinevalue() >= ((ResultEntity)((Settingentity)methodentity.getsettinglist()[i]).getresultentitylist()[resulti]).getresultstartvalue() && ((Testdata)testdatalist[i]).gettlinevalue() <= ((ResultEntity)((Settingentity)methodentity.getsettinglist()[i]).getresultentitylist()[resulti]).getresultendvalue())
                                            {
                                                count = Averagevalue(newbitmap, methodentity.getsensitive().ToString());
                                               // if (count == 1)
                                               // {
                                                    ((Testdata)testdatalist[i]).setresult(((ResultEntity)((Settingentity)methodentity.getsettinglist()[i]).getresultentitylist()[resulti]).getresultvalue());
                                                    
                                               // }
                                              //  else
                                               // {
                                              //      ((Testdata)testdatalist[i]).setresult("out of range");
                                               // }
                                                resulti = ((Settingentity)methodentity.getsettinglist()[i]).getresultentitylist().Count;
                                                break;
                                            }
                                            else
                                            {
                                                ((Testdata)testdatalist[i]).setresult("out of range");
                                            }
                                        }
                                    }
                                }
                            }
                            if (((Settingentity)methodentity.getsettinglist()[i]).getlinevalue() == "Sandwich")
                            {
                                if (((Setzoneentity)((Settingentity)methodentity.getsettinglist()[i]).getImageSample().getcontrolzonelist()[j]).getzonecategory() == "control")
                                {
                                    for (int resulti = 0; resulti < ((Settingentity)methodentity.getsettinglist()[i]).getresultentitylist().Count; resulti++)
                                    {
                                        if (((ResultEntity)((Settingentity)methodentity.getsettinglist()[i]).getresultentitylist()[resulti]).getresultname() == "Control line")
                                        {
                                            if (((Testdata)testdatalist[i]).getclinevalue() >= ((ResultEntity)((Settingentity)methodentity.getsettinglist()[i]).getresultentitylist()[resulti]).getresultstartvalue() && ((Testdata)testdatalist[i]).getclinevalue() <= ((ResultEntity)((Settingentity)methodentity.getsettinglist()[i]).getresultentitylist()[resulti]).getresultendvalue())
                                            {
                                                //count = count + Averagevalue(newbitmap, methodentity.getsensitive().ToString());
                                                ((Testdata)testdatalist[i]).setifvalid("valid");
                                                resulti = ((Settingentity)methodentity.getsettinglist()[i]).getresultentitylist().Count;
                                            }
                                            else
                                            {
                                                ((Testdata)testdatalist[i]).setifvalid("unvalid");
                                                resulti = ((Settingentity)methodentity.getsettinglist()[i]).getresultentitylist().Count;
                                            }
                                        }
                                    }
                                }
                                else if (((Setzoneentity)((Settingentity)methodentity.getsettinglist()[i]).getImageSample().getcontrolzonelist()[j]).getzonecategory() == "test")
                                {
                                    for (int resulti = 0; resulti < ((Settingentity)methodentity.getsettinglist()[i]).getresultentitylist().Count; resulti++)
                                    {
                                        if (((ResultEntity)((Settingentity)methodentity.getsettinglist()[i]).getresultentitylist()[resulti]).getresultname() == "Test line")
                                        {
                                            if (((Testdata)testdatalist[i]).gettlinevalue() >= ((ResultEntity)((Settingentity)methodentity.getsettinglist()[i]).getresultentitylist()[resulti]).getresultstartvalue() && ((Testdata)testdatalist[i]).gettlinevalue() <= ((ResultEntity)((Settingentity)methodentity.getsettinglist()[i]).getresultentitylist()[resulti]).getresultendvalue())
                                            {
                                               // count = Averagevalue(newbitmap, methodentity.getsensitive().ToString());
                                               // if (count == 1)
                                               // {
                                                    ((Testdata)testdatalist[i]).setresult(((ResultEntity)((Settingentity)methodentity.getsettinglist()[i]).getresultentitylist()[resulti]).getresultvalue());
                                                    
                                              //  }
                                               // else
                                              //  {
                                               //     ((Testdata)testdatalist[i]).setresult("out of range");
                                               // }
                                                resulti = ((Settingentity)methodentity.getsettinglist()[i]).getresultentitylist().Count;
                                                break;
                                            }
                                            else
                                            {
                                                ((Testdata)testdatalist[i]).setresult("out of range");
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
                pictureboxbitmap.Save(Environment.CurrentDirectory + "\\image\\" + "testimage" + DateTime.Now.ToString("yyyyMMddhhmmss") + ".jpg");
                pictureboxbitmap = new Bitmap(pictureboxbitmap, Form1picturebox.Width, Form1picturebox.Height);
                Form1picturebox.Image = pictureboxbitmap;
                displaytestdata();
                storedata();
                closecameraflag = 0;
                namelist.Clear();
                bitmaplistqueue.Clear();
                sampleimmagelist.Clear();
                colorlist = null;
                combinedimagelist.Clear();
                //successful
                /*string paramaters = "Patientfile,Firstname,Middlename,Lastname,Diagnosis,Assaydate,Dateofbirth,Lot,TestID,Sentby,Gender,Operator";
                string paramatervalues = "'" + patientfiletxtbox.Text.ToString() + "'" + "," + "'" + Firstnametxtbox.Text.ToString() + "'" + "," + "'" + middlenametxtbox.Text.ToString() + "'" + "," + "'" + lastnametxtbox.Text.ToString() + "'" + "," + "'" + diagnosistxtbox.Text.ToString() + "'" + "," + "'" + assaydatevalue.Text.ToString() + "'" + "," + "'" + dateofbirthdaytxtbox.Text.ToString() + "'" + "," + lottxtbox.Text.ToString() + "," + idtxtbox.Text.ToString() + "," + "'" + sentbycombobox.Text.ToString() + "'" + ",";
                if (maleradiobtn.Checked == true)
                {
                    paramatervalues = paramatervalues + "'" + "male" + "'" + "," + "'" + operatortxtbox.Text.ToString() + "'";
                }
                else
                {
                    paramatervalues = paramatervalues + "'" + "female" + "'" + "," + "'" + operatortxtbox.Text.ToString() + "'";
                }
                 * */
            }
            else
            {
                tabControl1.TabPages.Clear();
                string methodname = methodbox.SelectedItem.ToString();
                for (int i = 0; i < methodlist.Count; i++)
                {
                    if (((MethodEntity)methodlist[i]).getmethodname() == methodname)
                    {
                        methodentity = (MethodEntity)methodlist[i];
                    }
                }
                noticeform = new Noticeform();
                noticeform.Show();
                noticeform.Refresh();
                pictureboxbitmap = (Bitmap)((Bitmap)combinedimagelist[0]).Clone();
                pictureboxbitmap.Save(Environment.CurrentDirectory + "\\image\\" + "testimage" + DateTime.Now.ToString("yyyyMMddhhmmss") + ".jpg");
                pictureboxbitmap = new Bitmap(pictureboxbitmap, Form1picturebox.Width, Form1picturebox.Height);
                Form1picturebox.Image = pictureboxbitmap;
                scanpicture(sampleimmagelist);
                darwpicture();

                for (int i = 0; i < methodentity.getsettinglist().Count; i++)
                {
                    int count = 0;
                    Bitmap tempsampleimage = (Bitmap)((Settingimageentity)sampleimmagelist[i]).getimage().Clone();
                    if (((Settingentity)methodentity.getsettinglist()[i]).getlinevalue() == "Color")
                    {
                        ((Testdata)testdatalist[i]).setresult("Color");
                        ((Testdata)testdatalist[i]).setifvalid("uvalid");
                    }
                    else
                    {
                        for (int j = 0; j < ((Settingentity)methodentity.getsettinglist()[i]).getImageSample().getcontrolzonelist().Count; j++)
                        {
                            System.Drawing.Point temppoint = new System.Drawing.Point(((Setzoneentity)((Settingentity)methodentity.getsettinglist()[i]).getImageSample().getcontrolzonelist()[j]).getzonepositionx(), ((Setzoneentity)((Settingentity)methodentity.getsettinglist()[i]).getImageSample().getcontrolzonelist()[j]).getzonepositiony());
                            Size tempsize = new System.Drawing.Size(((Setzoneentity)((Settingentity)methodentity.getsettinglist()[i]).getImageSample().getcontrolzonelist()[j]).getzonepositionwidth(), ((Setzoneentity)((Settingentity)methodentity.getsettinglist()[i]).getImageSample().getcontrolzonelist()[j]).getzonepositionheight());
                            Rectangle rectNew = new Rectangle(temppoint, tempsize);
                            Bitmap newbitmap = new Bitmap(rectNew.Width, rectNew.Height);
                            g = Graphics.FromImage(newbitmap);
                            //g.DrawImage(bitmap, rectNew.Top, rectNew.Left);
                            g.DrawImage(tempsampleimage, -rectNew.Location.X - 1, -rectNew.Y - 1);
                            g.Dispose();
                            newbitmap.Save(Environment.CurrentDirectory + "\\image\\" + "sample" + j + ".jpg");
                            if (((Settingentity)methodentity.getsettinglist()[i]).getlinevalue() == "Competitive")
                            {
                                if (((Setzoneentity)((Settingentity)methodentity.getsettinglist()[i]).getImageSample().getcontrolzonelist()[j]).getzonecategory() == "control")
                                {
                                    for (int resulti = 0; resulti < ((Settingentity)methodentity.getsettinglist()[i]).getresultentitylist().Count; resulti++)
                                    {
                                        if (((ResultEntity)((Settingentity)methodentity.getsettinglist()[i]).getresultentitylist()[resulti]).getresultname() == "Control line")
                                        {
                                            if (((Testdata)testdatalist[i]).getclinevalue() > ((ResultEntity)((Settingentity)methodentity.getsettinglist()[i]).getresultentitylist()[resulti]).getresultstartvalue() && ((Testdata)testdatalist[i]).getclinevalue() < ((ResultEntity)((Settingentity)methodentity.getsettinglist()[i]).getresultentitylist()[resulti]).getresultendvalue())
                                            {
                                                //count = count + Averagevalue(newbitmap, methodentity.getsensitive().ToString());
                                                ((Testdata)testdatalist[i]).setifvalid("valid");
                                                resulti = ((Settingentity)methodentity.getsettinglist()[i]).getresultentitylist().Count;
                                            }
                                            else
                                            {
                                                ((Testdata)testdatalist[i]).setifvalid("unvalid");
                                                resulti = ((Settingentity)methodentity.getsettinglist()[i]).getresultentitylist().Count;
                                            }
                                        }
                                    }
                                }
                                else if (((Setzoneentity)((Settingentity)methodentity.getsettinglist()[i]).getImageSample().getcontrolzonelist()[j]).getzonecategory() == "test")
                                {
                                    for (int resulti = 0; resulti < ((Settingentity)methodentity.getsettinglist()[i]).getresultentitylist().Count; resulti++)
                                    {
                                        if (((ResultEntity)((Settingentity)methodentity.getsettinglist()[i]).getresultentitylist()[resulti]).getresultname() == "Test line")
                                        {
                                            if (((Testdata)testdatalist[i]).gettlinevalue() > ((ResultEntity)((Settingentity)methodentity.getsettinglist()[i]).getresultentitylist()[resulti]).getresultstartvalue() && ((Testdata)testdatalist[i]).gettlinevalue() < ((ResultEntity)((Settingentity)methodentity.getsettinglist()[i]).getresultentitylist()[resulti]).getresultendvalue())
                                            {
                                               // count = Averagevalue(newbitmap, methodentity.getsensitive().ToString());
                                               // if (count == 1)
                                               // {
                                                    ((Testdata)testdatalist[i]).setresult(((ResultEntity)((Settingentity)methodentity.getsettinglist()[i]).getresultentitylist()[resulti]).getresultvalue());
                                              //  }
                                              //  else
                                              //  {
                                                //    ((Testdata)testdatalist[i]).setresult("out of range");
                                               // }
                                                resulti = ((Settingentity)methodentity.getsettinglist()[i]).getresultentitylist().Count;
                                                break;
                                            }
                                            else
                                            {
                                                ((Testdata)testdatalist[i]).setresult("out of range");
                                            }
                                        }
                                    }
                                }
                            }
                            if (((Settingentity)methodentity.getsettinglist()[i]).getlinevalue() == "Sandwich")
                            {
                                if (((Setzoneentity)((Settingentity)methodentity.getsettinglist()[i]).getImageSample().getcontrolzonelist()[j]).getzonecategory() == "control")
                                {
                                    for (int resulti = 0; resulti < ((Settingentity)methodentity.getsettinglist()[i]).getresultentitylist().Count; resulti++)
                                    {
                                        if (((ResultEntity)((Settingentity)methodentity.getsettinglist()[i]).getresultentitylist()[resulti]).getresultname() == "Control line")
                                        {
                                            if (((Testdata)testdatalist[i]).getclinevalue() > ((ResultEntity)((Settingentity)methodentity.getsettinglist()[i]).getresultentitylist()[resulti]).getresultstartvalue() && ((Testdata)testdatalist[i]).getclinevalue() < ((ResultEntity)((Settingentity)methodentity.getsettinglist()[i]).getresultentitylist()[resulti]).getresultendvalue())
                                            {
                                                //count = count + Averagevalue(newbitmap, methodentity.getsensitive().ToString());
                                                ((Testdata)testdatalist[i]).setifvalid("valid");
                                                resulti = ((Settingentity)methodentity.getsettinglist()[i]).getresultentitylist().Count;
                                            }
                                            else
                                            {
                                                ((Testdata)testdatalist[i]).setifvalid("unvalid");
                                                resulti = ((Settingentity)methodentity.getsettinglist()[i]).getresultentitylist().Count;
                                            }
                                        }
                                    }
                                }
                                else if (((Setzoneentity)((Settingentity)methodentity.getsettinglist()[i]).getImageSample().getcontrolzonelist()[j]).getzonecategory() == "test")
                                {
                                    for (int resulti = 0; resulti < ((Settingentity)methodentity.getsettinglist()[i]).getresultentitylist().Count; resulti++)
                                    {
                                        if (((ResultEntity)((Settingentity)methodentity.getsettinglist()[i]).getresultentitylist()[resulti]).getresultname() == "Test line")
                                        {
                                            if (((Testdata)testdatalist[i]).gettlinevalue() > ((ResultEntity)((Settingentity)methodentity.getsettinglist()[i]).getresultentitylist()[resulti]).getresultstartvalue() && ((Testdata)testdatalist[i]).gettlinevalue() < ((ResultEntity)((Settingentity)methodentity.getsettinglist()[i]).getresultentitylist()[resulti]).getresultendvalue())
                                            {
                                                count = Averagevalue(newbitmap, methodentity.getsensitive().ToString());
                                                //if (count == 1)
                                               // {
                                                    ((Testdata)testdatalist[i]).setresult(((ResultEntity)((Settingentity)methodentity.getsettinglist()[i]).getresultentitylist()[resulti]).getresultvalue());
                                               // }
                                               // else
                                               // {
                                                 //   ((Testdata)testdatalist[i]).setresult("out of range");
                                               // }
                                                resulti = ((Settingentity)methodentity.getsettinglist()[i]).getresultentitylist().Count;
                                                break;
                                            }
                                            else
                                            {
                                                ((Testdata)testdatalist[i]).setresult("out of range");
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
                noticeform.Close();
                displaytestdata();
                storedata();
                closecameraflag = 0;
                namelist.Clear();
                bitmaplistqueue.Clear();
                sampleimmagelist.Clear();
                colorlist = null;
                combinedimagelist.Clear();
                //successful
                /*string paramaters = "Patientfile,Firstname,Middlename,Lastname,Diagnosis,Assaydate,Dateofbirth,Lot,TestID,Sentby,Gender,Operator";
                string paramatervalues = "'" + patientfiletxtbox.Text.ToString() + "'" + "," + "'" + Firstnametxtbox.Text.ToString() + "'" + "," + "'" + middlenametxtbox.Text.ToString() + "'" + "," + "'" + lastnametxtbox.Text.ToString() + "'" + "," + "'" + diagnosistxtbox.Text.ToString() + "'" + "," + "'" + assaydatevalue.Text.ToString() + "'" + "," + "'" + dateofbirthdaytxtbox.Text.ToString() + "'" + "," + lottxtbox.Text.ToString() + "," + idtxtbox.Text.ToString() + "," + "'" + sentbycombobox.Text.ToString() + "'" + ",";
                if (maleradiobtn.Checked == true)
                {
                    paramatervalues = paramatervalues + "'" + "male" + "'" + "," + "'" + operatortxtbox.Text.ToString() + "'";
                }
                else
                {
                    paramatervalues = paramatervalues + "'" + "female" + "'" + "," + "'" + operatortxtbox.Text.ToString() + "'";
                }
                 * */
            }
        }
        public Boolean initializecamera()// load camera
        {
            int mark = 0;
            try
            {
                // detect all of devices in the cpmputer
                videoDevices = new FilterInfoCollection(FilterCategory.VideoInputDevice);
                MySqlDataReader mysqlreader = database.select("Methodtable", "Methodname",methodbox.Text);
                mysqlreader.Read();
                if (videoDevices.Count == 0)
                    throw new ApplicationException();
                int i = 0;
                foreach (FilterInfo device in videoDevices)
                {
                    if (device.Name.Equals(mysqlreader[7].ToString()))
                    {
                        videoSource = new VideoCaptureDevice(videoDevices[i].MonikerString);
                        videoSource.VideoResolution = videoSource.VideoCapabilities[methodentity.getcameraandsourcesetting().getresolution()];
                        videoSource.DesiredFrameSize = new Size(320, 240);
                        videoSource.DesiredFrameRate = 1;
                        videPlayer.VideoSource = videoSource;
                        videPlayer.Start();
                        mark = 1;
                    }
                    i++;
                }
                if (mark == 0)
                {
                    throw new ApplicationException();
                }
                return true;
            }
            catch (ApplicationException)
            {
                videoDevices = null;
                MessageBox.Show("camera problems");
                return false;
            }
        }
        public void closecaamera()
        {
            videPlayer.SignalToStop();
            videPlayer.WaitForStop();
        }
        public void shutter()
        {
            flag = 0;
            bitmapentity = (Bitmap)bitmapentitytemp.Clone();
            bitmapentity = new Bitmap(bitmapentity, new Size(videoSource.VideoResolution.FrameSize.Width, videoSource.VideoResolution.FrameSize.Height));
            pictureboxbitmap = (Bitmap)bitmapentity.Clone();
            ContrastCorrection filter = new ContrastCorrection(methodentity.getcameraandsourcesetting().getcontrast());
            BrightnessCorrection bfilter = new BrightnessCorrection(methodentity.getcameraandsourcesetting().getbrightness());
            SaturationCorrection sfilter = new SaturationCorrection(methodentity.getcameraandsourcesetting().getsaturation());
            bfilter.ApplyInPlace(bitmapentity);
            filter.ApplyInPlace(bitmapentity);
            sfilter.ApplyInPlace(bitmapentity);
            
            //videPlayer.VideoSource.NewFrame += new NewFrameEventHandler(video_NewFrame);
        }
        private void video_NewFrame(object sender, NewFrameEventArgs eventArgs)
        {
            Bitmap bitmap = (Bitmap)eventArgs.Frame.Clone();
            if (flag == 0)
            {
                flag = 1;
                bitmap = new Bitmap(bitmap, new Size(320, 240));
                bitmapentity = bitmap;

            }

        }
        private void OnTimedEvent(object source, ElapsedEventArgs e)//take pictures through camera and do some primiary processing
        {
            aTimer.Enabled = false;
            for (int i = 0; i < methodentity.getsettinglist().Count; i++)
            {
                ArrayList bitmaplist = new ArrayList();
                for (int j = 0; j < ((Settingentity)methodentity.getsettinglist()[i]).getshuttertimes(); j++)
                {
                    Bitmap tempbitmap;
                    shutter();
                    tempbitmap = (Bitmap)bitmapentity.Clone();
                    bitmaplist.Add(tempbitmap);
                    //bitmapentity.Save("C:\\Users\\zsd\\Desktop\\" + DateTime.Now.ToString("yyyyMMddhhmmss") + ".jpg");
                }
                bitmaplistqueue.Add(bitmaplist);
            }
            for (int m = 0; m < bitmaplistqueue.Count; m++)
            {
                ArrayList bitmaplist = (ArrayList)bitmaplistqueue[m];
                for (int k = 0; k < bitmaplist.Count; k++)
                {
                        Bitmap tempbitmap = ((Bitmap)((Bitmap)bitmaplist[k]).Clone());
                        //ImageProcessing.ToGray(tempbitmap);
                        //ImageProcessing.imagecombine(tempbitmap, tempbitmap);
                        //combinedimage = tempbitmap;
                        System.Drawing.Point temppoint = new System.Drawing.Point(((Settingentity)methodentity.getsettinglist()[m]).getImageSample().getx(), ((Settingentity)methodentity.getsettinglist()[m]).getImageSample().gety());
                        Size tempsize = new System.Drawing.Size(((Settingentity)methodentity.getsettinglist()[m]).getImageSample().getimagewidth(), ((Settingentity)methodentity.getsettinglist()[m]).getImageSample().getimageheight());
                        Rectangle rectNew = new Rectangle(temppoint, tempsize);
                        imagepath = "testimage" + DateTime.Now.ToString("yyyyMMddhhmmss") + ".jpg";
                        //((Bitmap)combinedimagelist[m]).Save("D:\\" + imagepath);
                        Bitmap newbitmap = new Bitmap(rectNew.Width - 1, rectNew.Height - 1);
                        g = Graphics.FromImage(newbitmap);
                        //g.DrawImage(bitmap, rectNew.Top, rectNew.Left);
                        g.DrawImage(tempbitmap, -rectNew.Location.X - 1, -rectNew.Y - 1);
                        g.Dispose();
                        newbitmap.Save(Environment.CurrentDirectory +"\\image\\"+ "combinesample" + m + ".jpg");
                        if (k == 0)
                            combinedimage = newbitmap;
                        else
                        {
                            ImageProcessing.imagecombine(combinedimage, newbitmap);
                        }                    
                }
                //combinedimage.Save("C:\\Users\\zsd\\Desktop\\" + DateTime.Now.ToString("yyyyMMddhhmmss") + ".jpg");
                combinedimagelist.Add(combinedimage);
            }
            for (int i = 0; i < combinedimagelist.Count; i++)
            {
                imagepath = "testcombinedimage" + DateTime.Now.ToString("yyyyMMddhhmmss") + ".jpg";
                ((Bitmap)combinedimagelist[i]).Save(Environment.CurrentDirectory + "\\image\\" + imagepath);
                Settingimageentity tempimageentity = new Settingimageentity();
                tempimageentity.setparamatertype(((Settingentity)methodentity.getsettinglist()[i]).getlinevalue());
                tempimageentity.setimage((Bitmap)combinedimagelist[i]);
                sampleimmagelist.Add(tempimageentity);
            }
            //closecaamera();
            /*chartform chartpage = new chartform();
            chartpage.TopLevel = false;
            chartpage.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None; //设置窗体为非边框样式
            chartpage.Dock = System.Windows.Forms.DockStyle.Fill;
            panel1.Controls.Clear();
            panel1.Controls.Add(chartpage.panel1);
            chartpage.Show();*/
            outflag = 0;
            closecameraflag = 1;
            aTimer.Close();

        }

        private void videPlayer_NewFrame(object sender, ref Bitmap image)
        {
            bitmapentitytemp = image;
        }

        private void methodbox_SelectedIndexChanged(object sender, EventArgs e)
        {
            string methodname = methodbox.SelectedItem.ToString();
            Form1listView.Clear();
            for (int i = 0; i < methodlist.Count; i++)
            {
                if (((MethodEntity)methodlist[i]).getmethodname() == methodname)
                {
                    methodentity = (MethodEntity)methodlist[i];
                }
            }
            Form1listView.GridLines = true;
            Form1listView.View = View.Details;
            Form1listView.Scrollable = true;
            Form1listView.Columns.Add("Analyte",Form1listView.Width/3);
            Form1listView.Columns.Add("Result", Form1listView.Width / 3);
            //Form1listView.Columns.Add("TestValue", Form1listView.Width / 3);
           // Form1listView.Columns.Add("Background", Form1listView.Width / 3);
            for (int i = 0; i < methodentity.getsettinglist().Count; i++)
            {
                Form1listView.Items.Add(((Settingentity)methodentity.getsettinglist()[i]).getparamatername().ToString(), ((Settingentity)methodentity.getsettinglist()[i]).getparamatername().ToString(), 0);
                //Form1listView.Items[Form1listView].SubItems.Add();// add testresult later(database need to be finished firstly)

            }

        }
        public void displaytestdata()// dispaly data on the table
        {
            Form1listView.Clear();
            Form1listView.GridLines = true;
            Form1listView.View = View.Details;
            Form1listView.Scrollable = true;
            Form1listView.Columns.Add("Name", Form1listView.Width / 3);
            Form1listView.Columns.Add("Result", Form1listView.Width / 3);
            Form1listView.Columns.Add("Valid/Invalid", Form1listView.Width / 3);
            //Form1listView.Columns.Add("Value", Form1listView.Width / 3);
            //Form1listView.Columns.Add("Background", Form1listView.Width / 3);
            for (int i = 0; i < testdatalist.Count; i++)
            {
                Form1listView.Items.Add(((Testdata)testdatalist[i]).getname(), ((Testdata)testdatalist[i]).getname(),i);
                Form1listView.Items[((Testdata)testdatalist[i]).getname()].SubItems.Add(((Testdata)testdatalist[i]).getresult());
                Form1listView.Items[((Testdata)testdatalist[i]).getname()].SubItems.Add(((Testdata)testdatalist[i]).getifvalid().ToString());
                //Form1listView.Items[((Testdata)testdatalist[i]).getname()].SubItems.Add(((Testdata)testdatalist[i]).getbackground().ToString());
            }
        }
        public void storedata() //save data in the database
        {
            string temptestindex = Testnametextbox.Text.ToString() + DateTime.Now.ToString("yyyyMMddhhmmss");
            string temptestinfotablevalue = "'" + patientfiletxtbox.Text.ToString() + "'" + "," + "'" + lastnametxtbox.Text.ToString() + "'" + "," + "'" + middlenametxtbox.Text.ToString() + "'" + "," + "'" + Firstnametxtbox.Text.ToString() + "'" + "," + "'" + diagnosistxtbox.Text.ToString() + "'" +","+ "'" + assaydatevalue.Value.Date.ToString("yyyy-MM-dd") + "'" + "," + "'" + birthayvalue.Value.Date.ToString("yyyy-MM-dd") + "'" + "," + lottxtbox.Text.ToString() + "," + idtxtbox.Text.ToString() + "," + "'" + sentbytextbox.Text.ToString() + "'" + ",";
            if (maleradiobtn.Checked == true)
            {
                temptestinfotablevalue = temptestinfotablevalue + "'" + "male" + "'" + "," +"'" +operatortxtbox.Text.ToString()+"'"+","+ "'"+temptestindex+"'"+","+"'"+Testnametextbox.Text.ToString()+"'"+","+"'"+testcodetextbox.Text.ToString()+"'"+","+"'"+imagepath+"'";
            }
            else
            {
                temptestinfotablevalue = temptestinfotablevalue + "'" + "female" + "'" + "," + "'" + operatortxtbox.Text.ToString() + "'" + "," + "'" + temptestindex + "'" + "," + "'" + Testnametextbox.Text.ToString() + "'" + "," + "'" + testcodetextbox.Text.ToString() + "'" + "," + "'" + imagepath + "'";
            }
            databaseoperator.inserttestdata("Testresultinfotable", "Patientfile,Firstname,Middlename,Lastname,Diagnosis,Assaydate,Dateofbirth,Lot,TestID,Sentby,Gender,Operator,Testresultindex,Testname,Testcode,Imagepath", temptestinfotablevalue);
            for(int i=0;i<testdatalist.Count;i++)
            {
                string temptestresulttable = "'" + temptestindex + "'" + "," + "'" + ((Testdata)testdatalist[i]).getname() + "'" + "," + "'" + ((Testdata)testdatalist[i]).getresult() + "'" + "," + ((Testdata)testdatalist[i]).getclinevalue() + "," + ((Testdata)testdatalist[i]).gettlinevalue() + "," + ((Testdata)testdatalist[i]).getbackground() + "," + "'" + ((Testdata)testdatalist[i]).getifvalid()+ "'" + "," + "'" + DateTime.Now.ToString("yyyy-MM-dd") + "'";
                databaseoperator.inserttestdata("Testresulttable", "Testindex,Name,Result,Clinevalue,Tlinevalue,Background,Valid,Date", temptestresulttable);
            }
        }
        public void scanpicture(ArrayList list1)
        {
            chartlist.Clear();
            content = "";
            for (int k = 0; k < list1.Count; k++)
            {
                if (((Settingimageentity)list1[k]).getparamatertype() != "Color")
                {
                    Bitmap bitmap = (Bitmap)((Settingimageentity)list1[k]).getimage().Clone();
                    colorlist = new ArrayList();
                    bitmap = ToGray(bitmap);
                    int i = bitmap.Width / 2;
                    int temp = 255;
                    bool tempcount = false;
                    int average = 0;
                    ArrayList downsurge = new ArrayList();
                    for (int j = 0; j < bitmap.Height; j++)
                    {
                        Color colorcurrent = bitmap.GetPixel(i, j);
                        content = content + colorcurrent.B.ToString() + " ";
                        if (j < bitmap.Height - 2)
                        {
                            Color colorafter = bitmap.GetPixel(i, j + 2);
                            if (tempcount == false)//detectdowntrend
                            {
                                if (colorcurrent.B - colorafter.B >= methodentity.getsensitive())
                                {
                                    tempcount = true;
                                }
                                else
                                {
                                    average = average + colorcurrent.B;
                                }
                            }
                            else if (tempcount == true)//detectuptrend
                            {
                                if (colorcurrent.B - colorafter.B <= -methodentity.getsensitive())
                                {
                                    tempcount = false;//up
                                    downsurge.Add(j);
                                }
                                else
                                {
                                    downsurge.Add(j);
                                }
                            }
                        }
                        else
                        {
                            average = average + colorcurrent.B;
                        }

                    }
                    average = average / (bitmap.Height - downsurge.Count);
                    Color colorlast = bitmap.GetPixel(i, bitmap.Height - 1);
                    Color colorfirst = bitmap.GetPixel(i, 0);
                    int difference = Math.Abs(colorlast.B - colorfirst.B);
                    average = average + difference;
                    if (((Color)bitmap.GetPixel(i, (int)downsurge[0])).B > average)
                        average = ((Color)bitmap.GetPixel(i, (int)downsurge[0])).B;
                    if (((Color)bitmap.GetPixel(i, (int)downsurge[downsurge.Count - 1])).B > average)
                        average = ((Color)bitmap.GetPixel(i, (int)downsurge[downsurge.Count - 1])).B;
                    if (average > 255)
                        average = 255;
                    for (int j = 0, k1 = 0; j < bitmap.Height; j++)
                    {
                        if (j == (int)downsurge[k1])
                        {
                            if (k1 < downsurge.Count - 1)
                                k1++;
                            setclassentity = new Pointentity();
                            Color color = bitmap.GetPixel(i, j);
                            setclassentity.setcolor(color.B);
                            colorlist.Add(setclassentity);
                        }
                        else
                        {
                            setclassentity = new Pointentity();
                            Color color = Color.FromArgb(average, average, average);
                            setclassentity.setcolor(color.B);
                            colorlist.Add(setclassentity);
                        }
                        
                    }
                    chartlist.Add(colorlist);
                }
                else
                {
                    Bitmap bitmap = (Bitmap)((Settingimageentity)list1[k]).getimage().Clone();
                    chartlist.Add(bitmap);
                }
            }
        }
        public static Bitmap ToGray(Bitmap bmp)// change picture to gray scale
        {
            for (int i = 0; i < bmp.Width; i++)
            {
                for (int j = 0; j < bmp.Height; j++)
                {
                    //get the RGB value of every pixel  
                    Color color = bmp.GetPixel(i, j);
                    //calculate the gray value  
                    int gray = (int)(color.R * 0.3 + color.G * 0.59 + color.B * 0.11);
                    Color newColor = Color.FromArgb(gray, gray, gray);
                    bmp.SetPixel(i, j, newColor);
                }
            }
            return bmp;
        }
        public int Averagevalue(Bitmap bmp,string sensitive)//recognise how many lines in the picture
        {
            Bitmap bitmap = (Bitmap)bmp.Clone();
            bitmap = ToGray(bitmap);
            int i = bitmap.Width / 2;
            int temp = 255;
            int count = 0;
            bool tempcount = false;
            int average = 0;
            ArrayList downsurge = new ArrayList();
            for (int j = 0; j < bitmap.Height; j++)
            {
                Color colorcurrent = bitmap.GetPixel(i, j);
                if (j < bitmap.Height - 2)
                {
                    Color colorafter = bitmap.GetPixel(i, j + 2);
                    if (tempcount == false)//detectdowntrend
                    {
                        if (colorcurrent.B - colorafter.B >= int.Parse(sensitive))
                        {
                            tempcount = true;
                            count++;
                        }
                        else
                        {
                            average = average + colorcurrent.B;
                        }
                    }
                    else if (tempcount == true)//detectuptrend
                    {
                        if (colorcurrent.B - colorafter.B <= -(int.Parse(sensitive)))
                        {
                            tempcount = false;//up
                        }
                        else
                        {
                            downsurge.Add(j);
                        }
                    }
                }
                else
                {
                    average = average + colorcurrent.B;
                }

            }
            return count;
        }
        public void darwpicture()
        {
            Pointentity temp = new Pointentity();
            //this.colorlist = colorlist;
            for (int i = 0; i < methodentity.getsettinglist().Count; i++)
            {
                namelist.Add(((Settingentity)methodentity.getsettinglist()[i]).getparamatername());
            }
            //set tabs
            for (int i = 0; i < namelist.Count; i++)
            {
                if (((Settingentity)methodentity.getsettinglist()[i]).getlinevalue() != "Color")
                {
                    DateTime currenttime = DateTime.Now;
                    int colorvaluetop = 255;
                    int colorvaluebottom = 255;
                    ArrayList templist = new ArrayList();
                    int averagevalue = 0;
                    if (i < chartlist.Count)
                    {
                        TabPage tabPage = new TabPage();
                        tabPage.Text = "page" + i.ToString();
                        tabPage.ClientSize = new Size(749, 368);
                        tabPage.BackColor = Color.White;
                        Chart chart2 = new Chart();
                        chart2.Series.Clear();
                        chart2.ChartAreas.Add("ChartArea2");
                        chart2.Location = new System.Drawing.Point(24, 17);
                        chart2.ClientSize = new Size(672, 300);
                        chart2.Margin = new Padding(3, 3, 3, 3);
                        chart2.ChartAreas["ChartArea2"].AxisX.Interval = 1;
                        chart2.ChartAreas["ChartArea2"].AxisY.Maximum = 300;
                        Series series = new Series("Spline");
                        chart2.Legends.Add(new Legend("Spline1"));

                        series.LegendText = namelist[i].ToString();
                        //series.Tag = "asda";
                        series.ChartType = SeriesChartType.Spline;
                        series.BorderWidth = 3;
                        colorlist = (System.Collections.ArrayList)chartlist[i];
                        for (int k = 0; k < colorlist.Count; k++)
                        {
                            ((Pointentity)colorlist[k]).setcolor(((Pointentity)colorlist[k]).getcolor() + methodentity.getadjustvalue());
                        }
                        for (int k = 0; k < colorlist.Count; k++)
                        {
                            temp = (Pointentity)colorlist[k];
                            series.Points.AddY(temp.getcolor());
                            if (temp.getcolor() < colorvaluetop && k < colorlist.Count / 2)
                            {
                                colorvaluetop = temp.getcolor();

                            }
                            else if (temp.getcolor() < colorvaluebottom && k > colorlist.Count / 2)
                            {
                                colorvaluebottom = temp.getcolor();
                            }

                        }
                        chart2.Series.Add(series);
                        tabPage.Controls.Add(chart2);
                        chart2.Show();
                        tabPage.Name = namelist[i].ToString();
                        tabPage.Text = namelist[i].ToString();
                        tabControl1.TabPages.Add(tabPage);
                        temp = (Pointentity)colorlist[0];
                        averagevalue = temp.getcolor();
                        colorvaluetop = averagevalue - colorvaluetop;
                        colorvaluebottom = averagevalue - colorvaluebottom;
                        Testdata temptesdata = new Testdata();
                        temptesdata.setname(namelist[i].ToString());
                        temptesdata.setbackground(averagevalue);
                        temptesdata.setclinevalue(colorvaluetop);
                        temptesdata.settlinevalue(colorvaluebottom);
                        testdatalist.Add(temptesdata);
                        TextAnnotation text = new TextAnnotation();
                        text.Text = "C:";
                        text.X = 85;
                        text.Y = 20;
                        chart2.Annotations.Add(text);
                        text = new TextAnnotation();
                        text.Text = colorvaluetop.ToString();
                        text.X = 90;
                        text.Y = 20;
                        chart2.Annotations.Add(text);
                        text = new TextAnnotation();
                        text.Text = "T:";
                        text.X = 85;
                        text.Y = 27;
                        chart2.Annotations.Add(text);
                        text = new TextAnnotation();
                        text.Text = colorvaluebottom.ToString();
                        text.X = 90;
                        text.Y = 27;
                        chart2.Annotations.Add(text);
                        text = new TextAnnotation();
                        text.Text = "Loading:";
                        text.X = 85;
                        text.Y = 34;
                        chart2.Annotations.Add(text);
                        text = new TextAnnotation();
                        System.DateTime timetemp = new DateTime();
                        TimeSpan ts = currenttime - timetemp;
                        text.Text = "0." + ts.Milliseconds.ToString() + "/s";
                        text.X = 92;
                        text.Y = 34;
                        chart2.Annotations.Add(text);
                    }
                }
                else
                {
                    Testdata temptesdata = new Testdata();
                    temptesdata.setname(namelist[i].ToString());
                    temptesdata.setbackground(0);
                    temptesdata.setclinevalue(0);
                    temptesdata.settlinevalue(0);
                    testdatalist.Add(temptesdata);
                }
            }
        }

        private void loadImageToolStripMenuItem_Click(object sender, EventArgs e)// load one image form files
        {
            namelist.Clear();
            bitmaplistqueue.Clear();
            sampleimmagelist.Clear();
            colorlist = null;
            combinedimagelist.Clear();
            OpenFileDialog fileDialog = new OpenFileDialog();
            fileDialog.Multiselect = true;
            fileDialog.Title = "Please select files";
            fileDialog.Filter = "All files(*.*)|*.*";
            if (fileDialog.ShowDialog() == DialogResult.OK)
            {
                string opFilePath = fileDialog.FileName;
                Bitmap img = (Bitmap)Bitmap.FromFile(opFilePath);
                combinedimagelist.Add(img);
                for (int i = 0; i < methodentity.getsettinglist().Count; i++)
                {
                    System.Drawing.Point temppoint = new System.Drawing.Point(((Settingentity)methodentity.getsettinglist()[i]).getImageSample().getx(), ((Settingentity)methodentity.getsettinglist()[i]).getImageSample().gety());
                    Size tempsize = new System.Drawing.Size(((Settingentity)methodentity.getsettinglist()[i]).getImageSample().getimagewidth(), ((Settingentity)methodentity.getsettinglist()[i]).getImageSample().getimageheight());
                    Rectangle rectNew = new Rectangle(temppoint, tempsize);
                    Bitmap newbitmap = new Bitmap(rectNew.Width - 1, rectNew.Height - 1);
                    g = Graphics.FromImage(newbitmap);
                    //g.DrawImage(bitmap, rectNew.Top, rectNew.Left);
                    g.DrawImage((Bitmap)combinedimagelist[0], -rectNew.Location.X - 1, -rectNew.Y - 1);
                    g.Dispose();
                    newbitmap.Save(Environment.CurrentDirectory + "\\image\\" + "sample1" + i + ".jpg");
                    Settingimageentity tempimageentity = new Settingimageentity();
                    tempimageentity.setparamatertype(((Settingentity)methodentity.getsettinglist()[i]).getlinevalue());
                    tempimageentity.setimage(newbitmap);
                    sampleimmagelist.Add(tempimageentity);
                }
            }
        }

        private void createQRcodeToolStripMenuItem_Click(object sender, EventArgs e)//create qr code
        {
            string tempvalue = patientfiletxtbox.Text.ToString() + "," + lastnametxtbox.Text.ToString() + "," + middlenametxtbox.Text.ToString() + "," + Firstnametxtbox.Text.ToString() + "," + diagnosistxtbox.Text.ToString() + "," + assaydatevalue.Value.ToString("yyyy-MM-dd") + "," + Testnametextbox.Text.ToString() + "," + birthayvalue.Value.ToString("yyyy-MM-dd")+","+lottxtbox.Text.ToString()+","+idtxtbox.Text.ToString()+","+sentbytextbox.Text.ToString()+",";
            if (maleradiobtn.Checked == true)
            {
                tempvalue = tempvalue + "male" + "," + operatortxtbox.Text.ToString() + "," + testcodetextbox.Text.ToString();
            }
            else
            {
                tempvalue = tempvalue + "female" + "," + operatortxtbox.Text.ToString() + "," + testcodetextbox.Text.ToString();
            }
            try
            {
                MultiFormatWriter mutiWriter = new com.google.zxing.MultiFormatWriter();
                ByteMatrix bm = mutiWriter.encode(tempvalue, com.google.zxing.BarcodeFormat.QR_CODE, 150, 150);
                Bitmap img = bm.ToBitmap();
                string filename = System.Environment.CurrentDirectory + "\\QR" + DateTime.Now.Ticks.ToString() + ".jpg";
                img.Save(filename, System.Drawing.Imaging.ImageFormat.Jpeg);
                MessageBox.Show(filename);
                //ByteMatrix bm = mutiWriter.encode(txtMsg.Text, com.google.zxing.BarcodeFormat.EAN_13, 363, 150);
            }
            catch (Exception ee)
            { MessageBox.Show(ee.Message); }
        }

        private void analyseQRcodeToolStripMenuItem_Click(object sender, EventArgs e)//analyse qr code
        {
            Bitmap img;
            OpenFileDialog fileDialog = new OpenFileDialog();
            fileDialog.Multiselect = true;
            fileDialog.Title = "Please select files";
            fileDialog.Filter = "All files(*.*)|*.*";
            if (fileDialog.ShowDialog() == DialogResult.OK)
            {
                string opFilePath = fileDialog.FileName;
                img = (Bitmap)Bitmap.FromFile(opFilePath);
                MultiFormatReader mutiReader = new com.google.zxing.MultiFormatReader();
                LuminanceSource ls = new RGBLuminanceSource(img, img.Width, img.Height);
                BinaryBitmap bb = new BinaryBitmap(new com.google.zxing.common.HybridBinarizer(ls));
                string values = mutiReader.decode(bb).Text;
                Regex reg = new Regex("[A-Za-z0-9]+");

                MatchCollection match = reg.Matches(values);
                for (int i = 0; i < match.Count; i++)
                {
                    string value = match[i].ToString();
                    if (i == 1)
                    {
                        patientfiletxtbox.Text = value;
                    }
                    else if (i == 2)
                    {
                        Firstnametxtbox.Text = value;
                    }
                    else if (i == 3)
                    {
                        middlenametxtbox.Text = value;
                    }
                    else if (i == 4)
                    {
                        lastnametxtbox.Text = value;
                    }
                    else if (i == 5)
                    {
                        diagnosistxtbox.Text = value;
                    }
                    else if(i==6)
                    {
                        DateTime temp = DateTime.ParseExact(value, "yyyyMMdd", new CultureInfo("en-US"));
                        assaydatevalue.Value = temp;
                    }
                    else if (i == 7)
                    {
                        Testnametextbox.Text = value;
                    }
                    else if (i == 8)
                    {
                        DateTime temp = DateTime.ParseExact(value, "yyyyMMdd", new CultureInfo("en-US"));
                        birthayvalue.Value = temp;
                    }
                    else if (i == 9)
                    {
                        lottxtbox.Text = value;
                    }
                    else if (i == 10)
                    {
                        idtxtbox.Text = value;
                    }
                    else if (i == 11)
                    {
                        sentbytextbox.Text = value;
                    }
                    else if (i == 12)
                    {
                        if (value.Equals("male"))
                        {
                            maleradiobtn.Checked = true;
                        }
                        else
                        {
                            femaleradiobtn.Checked = false;
                        }
                    }
                    else if (i == 13)
                    {
                        operatortxtbox.Text = value;
                    }
                    else if (i == 14)
                    {
                        testcodetextbox.Text = value;
                    }
                }
            }
        }

        private void addMethodToolStripMenuItem_Click(object sender, EventArgs e)
        {
            form = new Method(this, methodlist);
            form.ShowDialog();
        }

        private void chooseLanguageToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Chooselanguage chooselanguageform = new Chooselanguage(this);
            chooselanguageform.ShowDialog();
        }

        private void deleteMethodToolStripMenuItem_Click(object sender, EventArgs e)//delete method
        {
            if (methodbox.Items.Count != 0)
            {
                if (MessageBox.Show("confirm delete？", "this delete can not be recovered", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    MySqlDataReader tempsqlreader = databaseoperator.select("methodtable", "Methodname", methodbox.Text);
                    ArrayList deletelist = new ArrayList();
                    while (tempsqlreader.Read())
                    {
                        deletelist.Add((String)tempsqlreader.GetValue(3));
                    }
                    databaseoperator.connectdatabase();
                    databaseoperator.opendatabase();
                    databaseoperator.deletedata("methodtable", "Methodname", methodbox.Text);
                    for (int i = 0; i < deletelist.Count; i++)
                    {
                        databaseoperator.deletedata("settingentitytable", "Paramaterindex", (String)deletelist[i]);
                        databaseoperator.deletedata("resulttable", "Resultvalueindex", (String)deletelist[i]);
                        databaseoperator.deletedata("rectangletable", "Rectangleindex", (String)deletelist[i]);
                        databaseoperator.deletedata("setzonetable", "Setzoneindex", (String)deletelist[i]);

                    }
                    databaseoperator.closedatabase();
                    for (int i = 0; i < methodlist.Count; i++)
                    {
                        if (((MethodEntity)methodlist[i]).getmethodname() == methodbox.Text)
                        {
                            methodlist.RemoveAt(i);
                        }
                    }
                    methodbox.Items.Clear();
                    Form1_Load(null, null);
                }
            }
            else
            {
                MessageBox.Show("don't have methods");
            }
        }

        private void editMethodToolStripMenuItem_Click(object sender, EventArgs e)//edit method
        {
            if (methodbox.Items.Count != 0)
            {
                int editflag = 1;
                for (int i = 0; i < methodlist.Count; i++)
                {
                    if (((MethodEntity)methodlist[i]).getmethodname() == methodbox.Text)
                    {
                        methodentity = ((MethodEntity)methodlist[i]);
                    }
                }
                form = new Method(this, methodlist, methodentity, editflag);
                form.ShowDialog();
            }
            else
            {
                MessageBox.Show("don't have methods");
            }
        }
        private void detectcolor(string paramater1,string paramater2,string paramater3,int value,Bitmap tempsampleimage,int i)//the new method, hasn't been tested
        {
            int bluenumber = 0;
            int rednumber = 0;
            int greennumber = 0;
            for (int dcolori = 0; dcolori < tempsampleimage.Height; dcolori++)
                {
                    for (int dcolorj = 0; dcolorj < tempsampleimage.Width; dcolorj++)
                        {
                            Color colorcurrent = tempsampleimage.GetPixel(dcolorj, dcolori);
                            bluenumber = bluenumber + colorcurrent.B;
                            rednumber = rednumber + colorcurrent.R;
                            greennumber = greennumber + colorcurrent.G;
                         }
                 }
            Color finalcolor = Color.FromArgb(rednumber / (tempsampleimage.Height * tempsampleimage.Width), bluenumber / (tempsampleimage.Height * tempsampleimage.Width), greennumber / (tempsampleimage.Height * tempsampleimage.Width));
            float hue = finalcolor.GetHue();
            float saturation = finalcolor.GetSaturation();
            float lightness = finalcolor.GetBrightness();
            if (paramater1 == "R")
            {
                if (finalcolor.R > value)
                {
                    subdetectcolor(paramater2,finalcolor,hue,saturation,lightness,i);
                }
                else
                {
                    subdetectcolor(paramater3, finalcolor, hue, saturation, lightness,i);
                }
            }
            else if (paramater1 == "G")
            {
                if (finalcolor.G > value)
                {
                    subdetectcolor(paramater2, finalcolor, hue, saturation, lightness,i);
                }
                else
                {
                    subdetectcolor(paramater3, finalcolor, hue, saturation, lightness,i);
                }
            }
            else if (paramater1 == "B")
            {
                if (finalcolor.B > value)
                {
                    subdetectcolor(paramater2, finalcolor, hue, saturation, lightness,i);
                }
                else
                {
                    subdetectcolor(paramater3, finalcolor, hue, saturation, lightness,i);
                }
            }
            else if (paramater1 == "saturation")
            {
                if (saturation > value)
                {
                    subdetectcolor(paramater2, finalcolor, hue, saturation, lightness,i);
                }
                else
                {
                    subdetectcolor(paramater3, finalcolor, hue, saturation, lightness,i);
                }
            }
            else if (paramater1 == "hue")
            {
                if (hue > value)
                {
                    subdetectcolor(paramater2, finalcolor, hue, saturation, lightness,i);
                }
                else
                {
                    subdetectcolor(paramater3, finalcolor, hue, saturation, lightness,i);
                }
            }
            else if (paramater1 == "lightness")
            {
                if (lightness > value)
                {
                    subdetectcolor(paramater2, finalcolor, hue, saturation, lightness,i);
                }
                else
                {
                    subdetectcolor(paramater3, finalcolor, hue, saturation, lightness,i);
                }
            }
        }
        private void subdetectcolor(string paramater,Color finalcolor,float hue,float saturation,float lightness,int i)
        {
            if (paramater == "R")
            {
                for (int colori = 0; colori < ((Settingentity)methodentity.getsettinglist()[i]).getresultentitylist().Count; colori++)
                {
                    if (((ResultEntity)((Settingentity)methodentity.getsettinglist()[i]).getresultentitylist()[colori]).getresultname() == "Test line")
                    {
                        if (finalcolor.R >= ((ResultEntity)((Settingentity)methodentity.getsettinglist()[i]).getresultentitylist()[colori]).getresultstartvalue() && hue <= ((ResultEntity)((Settingentity)methodentity.getsettinglist()[i]).getresultentitylist()[colori]).getresultendvalue())
                        {
                            ((Testdata)testdatalist[i]).setresult(((ResultEntity)((Settingentity)methodentity.getsettinglist()[i]).getresultentitylist()[colori]).getresultvalue());
                            break;
                        }
                    }
                }
            }
            else if (paramater == "G")
            {
                for (int colori = 0; colori < ((Settingentity)methodentity.getsettinglist()[i]).getresultentitylist().Count; colori++)
                {
                    if (((ResultEntity)((Settingentity)methodentity.getsettinglist()[i]).getresultentitylist()[colori]).getresultname() == "Test line")
                    {
                        if (finalcolor.G >= ((ResultEntity)((Settingentity)methodentity.getsettinglist()[i]).getresultentitylist()[colori]).getresultstartvalue() && hue <= ((ResultEntity)((Settingentity)methodentity.getsettinglist()[i]).getresultentitylist()[colori]).getresultendvalue())
                        {
                            ((Testdata)testdatalist[i]).setresult(((ResultEntity)((Settingentity)methodentity.getsettinglist()[i]).getresultentitylist()[colori]).getresultvalue());
                            break;
                        }
                    }
                }
            }
            if (paramater == "B")
            {
                for (int colori = 0; colori < ((Settingentity)methodentity.getsettinglist()[i]).getresultentitylist().Count; colori++)
                {
                    if (((ResultEntity)((Settingentity)methodentity.getsettinglist()[i]).getresultentitylist()[colori]).getresultname() == "Test line")
                    {
                        if (finalcolor.B >= ((ResultEntity)((Settingentity)methodentity.getsettinglist()[i]).getresultentitylist()[colori]).getresultstartvalue() && hue <= ((ResultEntity)((Settingentity)methodentity.getsettinglist()[i]).getresultentitylist()[colori]).getresultendvalue())
                        {
                            ((Testdata)testdatalist[i]).setresult(((ResultEntity)((Settingentity)methodentity.getsettinglist()[i]).getresultentitylist()[colori]).getresultvalue());
                            break;
                        }
                    }
                }
            }
            if (paramater == "saturation")
            {
                for (int colori = 0; colori < ((Settingentity)methodentity.getsettinglist()[i]).getresultentitylist().Count; colori++)
                {
                    if (((ResultEntity)((Settingentity)methodentity.getsettinglist()[i]).getresultentitylist()[colori]).getresultname() == "Test line")
                    {
                        if (saturation >= ((ResultEntity)((Settingentity)methodentity.getsettinglist()[i]).getresultentitylist()[colori]).getresultstartvalue() && hue <= ((ResultEntity)((Settingentity)methodentity.getsettinglist()[i]).getresultentitylist()[colori]).getresultendvalue())
                        {
                            ((Testdata)testdatalist[i]).setresult(((ResultEntity)((Settingentity)methodentity.getsettinglist()[i]).getresultentitylist()[colori]).getresultvalue());
                            break;
                        }
                    }
                }
            }
            if (paramater == "hue")
            {
                for (int colori = 0; colori < ((Settingentity)methodentity.getsettinglist()[i]).getresultentitylist().Count; colori++)
                {
                    if (((ResultEntity)((Settingentity)methodentity.getsettinglist()[i]).getresultentitylist()[colori]).getresultname() == "Test line")
                    {
                        if (hue >= ((ResultEntity)((Settingentity)methodentity.getsettinglist()[i]).getresultentitylist()[colori]).getresultstartvalue() && hue <= ((ResultEntity)((Settingentity)methodentity.getsettinglist()[i]).getresultentitylist()[colori]).getresultendvalue())
                        {
                            ((Testdata)testdatalist[i]).setresult(((ResultEntity)((Settingentity)methodentity.getsettinglist()[i]).getresultentitylist()[colori]).getresultvalue());
                            break;
                        }
                    }
                }
            }
            if (paramater == "lightness")
            {
                for (int colori = 0; colori < ((Settingentity)methodentity.getsettinglist()[i]).getresultentitylist().Count; colori++)
                {
                    if (((ResultEntity)((Settingentity)methodentity.getsettinglist()[i]).getresultentitylist()[colori]).getresultname() == "Test line")
                    {
                        if (lightness >= ((ResultEntity)((Settingentity)methodentity.getsettinglist()[i]).getresultentitylist()[colori]).getresultstartvalue() && hue <= ((ResultEntity)((Settingentity)methodentity.getsettinglist()[i]).getresultentitylist()[colori]).getresultendvalue())
                        {
                            ((Testdata)testdatalist[i]).setresult(((ResultEntity)((Settingentity)methodentity.getsettinglist()[i]).getresultentitylist()[colori]).getresultvalue());
                            break;
                        }
                    }
                }
            }
        }
    }

}
