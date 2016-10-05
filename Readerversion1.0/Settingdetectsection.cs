using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AForge;
using AForge.Video;
using AForge.Video.DirectShow;
using AForge.Imaging;
using AForge.Imaging.Filters;
using System.Collections;
using System.IO;
using System.Text.RegularExpressions;
using MySql.Data.MySqlClient;

namespace Readerversion1._0
{
    public partial class Settingdetectsection : Form
    {
        private FilterInfoCollection videoDevices;
        private int flag = 1;
        private string tempname = "";
        Graphics g;
        Bitmap bitmap = null;
        public  Rectangle rectNew;
        public int pointStartX, pointStartY, pointEndX, pointEndY;
        private int copyStartX, copyStartY, copyEndX, copyEndY;
        private int copyrecwidth;
        private int copyrecheight;
        public ArrayList list1 = new ArrayList();
        private bool blnDraw = false;
        private Method form;
        private Form1 formtemp;
        public ArrayList chartstack = new ArrayList();
        private Bitmap bitmapSource = null;
        public MethodEntity methodtemp;
        private ArrayList methodlisttemp;
        private Databaseoperator databaseoperator=new Databaseoperator();
        public int brightness=0;
        public int contrast = 0;
        public float saturation = 0;
        private string devicename;
        private int resolution=0;
        public int neededboxes = 0;
        public int framewidth;
        public int frameheight;
        private PictureBox pictureBox1;
        private int tapindexi=0;
        public string paramatername;
        public int editflag;
        public string paramatertype;
        public Settingdetectsection()
        {
            InitializeComponent();
        }

        public Settingdetectsection(Method form, Form1 formtemp,ArrayList methodlist,MethodEntity methodentity,int flag)
        {
            // TODO: Complete member initialization
            InitializeComponent();
            if (Form1.language != "")
            {
                refreshlanguage(Form1.language);
            }
            this.form = form;
            this.formtemp = formtemp;
            methodtemp = methodentity;
            methodlisttemp=methodlist;
            editflag = flag;
        }
        private void Settingdetectsection_Load(object sender, EventArgs e)
        {
            try
            {
                videoDevices = new FilterInfoCollection(FilterCategory.VideoInputDevice);

                if (videoDevices.Count == 0)
                    throw new ApplicationException();
                int i = 0;
                foreach (FilterInfo device in videoDevices)
                {
                    if (device.Name == "USB2.0 Camera")
                    {
                        devicename = device.Name;
                        VideoCaptureDevice videoSource = new VideoCaptureDevice(videoDevices[i].MonikerString);
                        videoSource.VideoResolution = videoSource.VideoCapabilities[0];
                        framewidth = videoSource.VideoResolution.FrameSize.Width / 320;
                        frameheight = videoSource.VideoResolution.FrameSize.Height / 240;
                        videoSource.DesiredFrameSize = new Size(320, 240);
                        videoSource.DesiredFrameRate = 1;
                        videPlayer.VideoSource = videoSource;
                        videPlayer.Start();
                    }
                    i++;
                }
                neededboxes = methodtemp.getsettinglist().Count;
                settingdetectsectionneededvaluelabel.Text = neededboxes.ToString();
                for (int j = 0; j < methodtemp.getsettinglist().Count; j++)
                {
                    TabPage tab = new TabPage();
                    tab.Name = ((Settingentity)methodtemp.getsettinglist()[j]).getparamatername();
                    tab.Text = ((Settingentity)methodtemp.getsettinglist()[j]).getparamatername();
                    Settingimagedetection tempentity = new Settingimagedetection(this, ((Settingentity)methodtemp.getsettinglist()[j]).getparamatername(),framewidth,frameheight);
                    tempentity.TopLevel = false;      
                    tab.Controls.Add(tempentity);
                    this.tabControl1.TabPages.Add(tab);
                    tempentity.Show();
                    tabControl1.SelectedIndex = 0;
                    tabControl1_SelectedIndexChanged(null,null);
                }
            }
            catch (ApplicationException)
            {
                videoDevices = null;
            }
        }
        public void settingdetectsectionload(string tempdevicename,int indexi)
        {
            try
            {
               
                videoDevices = new FilterInfoCollection(FilterCategory.VideoInputDevice);

                if (videoDevices.Count == 0)
                    throw new ApplicationException();
                int i = 0;
                foreach (FilterInfo device in videoDevices)
                {
                    if (device.Name == tempdevicename)
                    {
                        devicename = device.Name;
                        VideoCaptureDevice videoSource = new VideoCaptureDevice(videoDevices[i].MonikerString);
                        videoSource.VideoResolution = videoSource.VideoCapabilities[indexi];
                        resolution = indexi;
                        framewidth = videoSource.VideoResolution.FrameSize.Width / 320;
                        frameheight = videoSource.VideoResolution.FrameSize.Height / 240;
                        videoSource.DesiredFrameSize = new Size(320, 240);
                        videoSource.DesiredFrameRate = 1;
                        videPlayer.VideoSource = videoSource;
                        videPlayer.Start();
                    }
                    i++;
                }
            }
            catch (ApplicationException)
            {
                videoDevices = null;
            }
        }
        public void settingdetectsectionload(string tempdevicename)
        {
            try
            {
                
                videoDevices = new FilterInfoCollection(FilterCategory.VideoInputDevice);

                if (videoDevices.Count == 0)
                    throw new ApplicationException();
                int i = 0;
                foreach (FilterInfo device in videoDevices)
                {
                    if (device.Name == tempdevicename)
                    {
                        devicename = device.Name;
                        VideoCaptureDevice videoSource = new VideoCaptureDevice(videoDevices[i].MonikerString);
                        videoSource.VideoResolution = videoSource.VideoCapabilities[resolution];
                        videoSource.DesiredFrameSize = new Size(320, 240);
                        videoSource.DesiredFrameRate = 1;
                        videPlayer.VideoSource = videoSource;
                        videPlayer.Start();
                    }
                    i++;
                }
                for (int j = 0; j < methodtemp.getsettinglist().Count; j++)
                {
                    TabPage tab = new TabPage();
                    tab.Name = ((Settingentity)methodtemp.getsettinglist()[j]).getparamatername();
                    tab.Text = ((Settingentity)methodtemp.getsettinglist()[j]).getparamatername();
                    Settingimagedetection tempentity = new Settingimagedetection(this, ((Settingentity)methodtemp.getsettinglist()[j]).getparamatername(), framewidth, frameheight);
                    tempentity.TopLevel = false;      
                    tab.Controls.Add(tempentity);
                    this.tabControl1.TabPages.Add(tab);
                    tempentity.Show();
                }
            }
            catch (ApplicationException)
            {
                videoDevices = null;
            }
        }
        private void video_NewFrame(object sender, NewFrameEventArgs eventArgs)
        {
            Bitmap bitmap = (Bitmap)eventArgs.Frame.Clone();
            if (flag == 0)
            {
                flag = 1;
                bitmap = new Bitmap(bitmap, new Size(320, 240));
                ContrastCorrection filter = new ContrastCorrection(contrast);
                BrightnessCorrection bfilter = new BrightnessCorrection(brightness);
                SaturationCorrection sfilter = new SaturationCorrection(saturation);
                bfilter.ApplyInPlace(bitmap);
                filter.ApplyInPlace(bitmap);
                sfilter.ApplyInPlace(bitmap);
                for (int j = 0; j < methodtemp.getsettinglist().Count; j++)
                {
                    ((PictureBox)tabControl1.Controls[j].Controls[0].Controls[0]).Image = (Bitmap)bitmap.Clone();
                }
                
            }
            
        }

        private void shutter_Click(object sender, EventArgs e)
        {
            chartstack.Clear();
            flag = 0;
            videPlayer.VideoSource.NewFrame += new NewFrameEventHandler(video_NewFrame);
            //formtemp.OnLoad();
            //form.Dispose();
        }

        

        private void save_Click(object sender, EventArgs e)
        {
            if (editflag == 1)
            {
                MySqlDataReader tempsqlreader = databaseoperator.select("methodtable", "Methodname", methodtemp.getmethodname());
                ArrayList deletelist = new ArrayList();
                while (tempsqlreader.Read())
                {
                    deletelist.Add((String)tempsqlreader.GetValue(3));
                }
                databaseoperator.connectdatabase();
                databaseoperator.opendatabase();
                databaseoperator.deletedata("methodtable", "Methodname", methodtemp.getmethodname());
                for (int i = 0; i < deletelist.Count; i++)
                {
                    databaseoperator.deletedata("settingentitytable", "Paramaterindex", (String)deletelist[i]);
                    databaseoperator.deletedata("resulttable", "Resultvalueindex", (String)deletelist[i]);
                    databaseoperator.deletedata("rectangletable", "Rectangleindex", (String)deletelist[i]);
                    databaseoperator.deletedata("setzonetable", "Setzoneindex", (String)deletelist[i]);

                }
                databaseoperator.closedatabase();
            }
            bool flagtemp = true;
            methodtemp.getcameraandsourcesetting().setcameraname(devicename);
            methodtemp.getcameraandsourcesetting().setresolution(resolution);
            methodtemp.getcameraandsourcesetting().setbrightnes(brightness);
            methodtemp.getcameraandsourcesetting().setcontrast(contrast);
            methodtemp.getcameraandsourcesetting().setsaturation(saturation);
            for (int k = 0; k < methodlisttemp.Count; k++)
            {
                MethodEntity temp = (MethodEntity)methodlisttemp[k];
                if (temp.getmethodname() == methodtemp.getmethodname())
                {
                    flagtemp = false;
                    break;
                }
            }
            if (flagtemp == true)
                methodlisttemp.Add(methodtemp);
            
            
            for (int databasei = 0; databasei < methodtemp.getsettinglist().Count; databasei++)
            {
                string paramaterindex = methodtemp.getmethodname().ToString() + ((Settingentity)methodtemp.getsettinglist()[databasei]).getparamatername().ToString();
                databaseoperator.insertdata("Methodtable", "Methodname,Paramaters,Paramaterindex,Brightness,Contrast,Saturation,Cameraname,Resolution, Sensitivevalue,Adjustvalue", "'" + methodtemp.getmethodname().ToString() + "'" + "," + "'" + ((Settingentity)methodtemp.getsettinglist()[databasei]).getparamatername().ToString() + "'" + "," + "'" + paramaterindex + "'" + "," + ((Cameraandsourcesetting)methodtemp.getcameraandsourcesetting()).getbrightness() + "," + ((Cameraandsourcesetting)methodtemp.getcameraandsourcesetting()).getcontrast() + "," + ((Cameraandsourcesetting)methodtemp.getcameraandsourcesetting()).getsaturation() + ","+"'"+((Cameraandsourcesetting)methodtemp.getcameraandsourcesetting()).getcameraname()+"'"+","+methodtemp.getcameraandsourcesetting().getresolution()+","+methodtemp.getsensitive()+","+methodtemp.getadjustvalue());
                string settingtablevalue="'"+((Settingentity)methodtemp.getsettinglist()[databasei]).getparamatername().ToString()+"'"+","+"'"+((Settingentity)methodtemp.getsettinglist()[databasei]).getlinevalue().ToString()+"'"+","+((Settingentity)methodtemp.getsettinglist()[databasei]).getshuttertimes().ToString()+
                    ","+((Settingentity)methodtemp.getsettinglist()[databasei]).getreadytime().ToString()+","+"'"+methodtemp.getmethodname().ToString()+"'"+","+"'"+paramaterindex.ToString()+"'"+","+"'"+paramaterindex.ToString()+"'"+","+"'"+paramaterindex.ToString()+"'";                                
                databaseoperator.insertdata("Settingentitytable", "Paramatername,Cline,Shuttertime,Readytime,Methodname,Resultvalueindex,Rectangleindex,Paramaterindex",
                    settingtablevalue);
                string rectangletablevalue = "'" + paramaterindex + "'" + "," + ((ImageSampleEntity)((Settingentity)methodtemp.getsettinglist()[databasei]).getImageSample()).getx().ToString() + "," + ((ImageSampleEntity)((Settingentity)methodtemp.getsettinglist()[databasei]).getImageSample()).gety().ToString() + "," + ((ImageSampleEntity)((Settingentity)methodtemp.getsettinglist()[databasei]).getImageSample()).getimagewidth().ToString() + "," + ((ImageSampleEntity)((Settingentity)methodtemp.getsettinglist()[databasei]).getImageSample()).getimageheight().ToString();
                databaseoperator.insertdata("Rectangletable", "Rectangleindex,X,Y,Width,Height", rectangletablevalue);
                for(int resulti=0;resulti<((Settingentity)methodtemp.getsettinglist()[databasei]).getresultentitylist().Count;resulti++)
                {
                    //string resultvalueindex = paramaterindex + ((ResultEntity)((Settingentity)methodtemp.getsettinglist()[databasei]).getresultentitylist()[resulti]).getresultname().ToString();
                    string resultvalueindex = paramaterindex;
                    string resulttablevalue = "'" + resultvalueindex + "'" + "," + "'" + ((ResultEntity)((Settingentity)methodtemp.getsettinglist()[databasei]).getresultentitylist()[resulti]).getresultname().ToString() + "'" + "," + "'" + ((ResultEntity)((Settingentity)methodtemp.getsettinglist()[databasei]).getresultentitylist()[resulti]).getresultstartvalue().ToString() + "'" + "," + "'" + ((ResultEntity)((Settingentity)methodtemp.getsettinglist()[databasei]).getresultentitylist()[resulti]).getresultendvalue().ToString() + "'" + "," + "'" + ((ResultEntity)((Settingentity)methodtemp.getsettinglist()[databasei]).getresultentitylist()[resulti]).getresultvalue()+"'";
                    databaseoperator.insertdata("Resulttable", "Resultvalueindex,Resultname,Resultstartvalue,Resultendvalue,Resultvalue", resulttablevalue);
                }
                for (int setzonei = 0; setzonei < ((ImageSampleEntity)((Settingentity)methodtemp.getsettinglist()[databasei]).getImageSample()).getcontrolzonelist().Count;setzonei++)
                {
                    string setzonetablevalue = "'" + ((Settingentity)methodtemp.getsettinglist()[databasei]).getparamatername() + "'" + "," + "'" + paramaterindex + "'" + "," + ((Setzoneentity)((ImageSampleEntity)((Settingentity)methodtemp.getsettinglist()[databasei]).getImageSample()).getcontrolzonelist()[setzonei]).getzonepositionx().ToString() + "," + ((Setzoneentity)((ImageSampleEntity)((Settingentity)methodtemp.getsettinglist()[databasei]).getImageSample()).getcontrolzonelist()[setzonei]).getzonepositiony().ToString() + "," + ((Setzoneentity)((ImageSampleEntity)((Settingentity)methodtemp.getsettinglist()[databasei]).getImageSample()).getcontrolzonelist()[setzonei]).getzonepositionwidth().ToString() + "," + ((Setzoneentity)((ImageSampleEntity)((Settingentity)methodtemp.getsettinglist()[databasei]).getImageSample()).getcontrolzonelist()[setzonei]).getzonepositionheight().ToString() + "," + "'" + ((Setzoneentity)((ImageSampleEntity)((Settingentity)methodtemp.getsettinglist()[databasei]).getImageSample()).getcontrolzonelist()[setzonei]).getzonecategory() + "'";
                    databaseoperator.insertdata("SetZonetable", "Paramater,Setzoneindex,ZonepositionX,ZonepositionY,ZonepositionWidth, ZonepositionHeight, Zonecategory", setzonetablevalue);
                }
                
            }
                formtemp.OnLoad();
            form.getclosingmethod();
            form.Dispose();
        }

        private void setzonebtn_Click(object sender, EventArgs e)
        {
            Setcontrolzone frm = new Setcontrolzone(list1, methodtemp,framewidth,frameheight);
            frm.ShowDialog();
        }

        private void sourceSettingToolStripMenuItem_Click(object sender, EventArgs e)
        {
            videPlayer.SignalToStop();
            videPlayer.WaitForStop();
            Sourcechoose sourcechooseform = new Sourcechoose(this);
            sourcechooseform.ShowDialog();
        }

        private void cameraToolStripMenuItem_Click(object sender, EventArgs e)
        {
            videPlayer.SignalToStop();
            videPlayer.WaitForStop();
            Camerasetting camerasettingform = new Camerasetting(this,devicename,resolution);
            camerasettingform.ShowDialog();
        }

        private void upbtn_Click(object sender, EventArgs e)
        {
            if (chartstack.Count > 1)
            {
                pointStartY = pointStartY - 1;
                if (pointStartY >= 0)
                {
                    pointEndY = pointEndY - 1;
                    for (int k = 0; k < list1.Count; k++)
                    {
                        Settingimageentity tempsettingimageeneity = (Settingimageentity)list1[k];
                        if (tempsettingimageeneity.getparamatername() == paramatername)
                        {
                            list1.RemoveAt(k);
                        }
                    }
                        chartstack.RemoveAt(chartstack.Count - 1);
                    pictureBox1.Image = (Bitmap)chartstack[chartstack.Count - 1];
                    int iWidth = pointEndX - pointStartX;
                    int iHeight = pointEndY - pointStartY;
                    if (chartstack.Count == 0)
                    {
                        bitmapSource = (Bitmap)pictureBox1.Image;
                    }
                    else
                        bitmapSource = (Bitmap)chartstack[chartstack.Count - 1];
                    if (bitmapSource != null)
                    {
                        //copy the original picture which is stored in bitmapsource and eliminate the old rectangle
                        bitmap = new Bitmap(bitmapSource);
                        Pen pen = new Pen(Color.White);
                        Graphics gh = Graphics.FromImage(bitmap);
                        rectNew = new Rectangle(pointStartX, pointStartY, iWidth, iHeight);
                        //draw rectangle
                        gh.DrawRectangle(pen, rectNew);
                        // show it on the screen
                        //this.CreateGraphics().DrawImage(bitmap, pictureBox1.Left, pictureBox1.Top, 500, 500);
                        pictureBox1.Image = bitmap;
                        bitmapSource = bitmap;
                        // Graphics.FromImage(bitmap);
                        //          g.DrawImage(bitmap,rectNew);
                        Bitmap newbitmap = new Bitmap(rectNew.Width - 1, rectNew.Height - 1);
                        Bitmap chartstacktemp = new Bitmap(pictureBox1.Width, pictureBox1.Height);
                        pictureBox1.DrawToBitmap(chartstacktemp, new Rectangle(0, 0, pictureBox1.Width, pictureBox1.Height));
                        chartstack.Add(chartstacktemp);
                        g = Graphics.FromImage(newbitmap);
                        //g.DrawImage(bitmap, rectNew.Top, rectNew.Left);
                        g.DrawImage(bitmap, pictureBox1.Left - rectNew.Location.X - pictureBox1.Left - 1, pictureBox1.Top - rectNew.Location.Y - pictureBox1.Top - 1);
                        g.Dispose();
                        //newbitmap.Save("D:\\" + DateTime.Now.ToString("yyyyMMddhhmmss") + ".jpg");
                        Settingimageentity tempentity = new Settingimageentity();
                        tempentity.setparamatername(paramatername);
                        tempentity.setimage(newbitmap);
                        tempentity.setparamatertype(paramatertype);
                        list1.Add(tempentity);
                        ((Settingimagedetection)tabControl1.TabPages[tapindexi].Controls[0]).pointStartX = pointStartX;
                        ((Settingimagedetection)tabControl1.TabPages[tapindexi].Controls[0]).pointStartY = pointStartY;
                        ((Settingimagedetection)tabControl1.TabPages[tapindexi].Controls[0]).pointEndX = pointEndX;
                        ((Settingimagedetection)tabControl1.TabPages[tapindexi].Controls[0]).pointEndY = pointEndY;
                        for (int k = 0; k < methodtemp.getsettinglist().Count; k++)
                        {
                            Settingentity settingentity = (Settingentity)methodtemp.getsettinglist()[k];
                            if (settingentity.getparamatername() == paramatername)
                            {
                                settingentity.getImageSample().setimagesample(rectNew.X * framewidth, rectNew.Y * frameheight, rectNew.Width * framewidth, rectNew.Height * frameheight);
                                break;
                            }
                        }

                        blnDraw = false;
                    }
                }
                else
                {
                    pointStartY = pointStartY + 1;
                }
            }
        }

        private void downbtn_Click(object sender, EventArgs e)
        {
            if (chartstack.Count > 1)
            {
                for (int k = 0; k < list1.Count; k++)
                {
                    Settingimageentity tempsettingimageeneity = (Settingimageentity)list1[k];
                    if (tempsettingimageeneity.getparamatername() == paramatername)
                    {
                        list1.RemoveAt(k);
                    }
                }
                chartstack.RemoveAt(chartstack.Count - 1);
                pictureBox1.Image = (Bitmap)chartstack[chartstack.Count - 1];
                pointStartY = pointStartY + 1;
                pointEndY = pointEndY + 1;
                int iWidth = pointEndX - pointStartX;
                int iHeight = pointEndY - pointStartY;
                if (chartstack.Count == 0)
                {
                    bitmapSource = (Bitmap)pictureBox1.Image;
                }
                else
                    bitmapSource = (Bitmap)chartstack[chartstack.Count - 1];
                if (bitmapSource != null)
                {
                    bitmap = new Bitmap(bitmapSource);
                    Pen pen = new Pen(Color.White);
                    Graphics gh = Graphics.FromImage(bitmap);
                    rectNew = new Rectangle(pointStartX, pointStartY, iWidth, iHeight);
                    gh.DrawRectangle(pen, rectNew);
                    //this.CreateGraphics().DrawImage(bitmap, pictureBox1.Left, pictureBox1.Top, 500, 500);
                    pictureBox1.Image = bitmap;
                    bitmapSource = bitmap;
                    // Graphics.FromImage(bitmap);
                    //          g.DrawImage(bitmap,rectNew);
                    Bitmap newbitmap = new Bitmap(rectNew.Width - 1, rectNew.Height - 1);
                    Bitmap chartstacktemp = new Bitmap(pictureBox1.Width, pictureBox1.Height);
                    pictureBox1.DrawToBitmap(chartstacktemp, new Rectangle(0, 0, pictureBox1.Width, pictureBox1.Height));
                    chartstack.Add(chartstacktemp);
                    g = Graphics.FromImage(newbitmap);
                    //g.DrawImage(bitmap, rectNew.Top, rectNew.Left);
                    g.DrawImage(bitmap, pictureBox1.Left - rectNew.Location.X - pictureBox1.Left - 1, pictureBox1.Top - rectNew.Location.Y - pictureBox1.Top - 1);
                    g.Dispose();
                    //newbitmap.Save("C:\\Users\\zsd\\Desktop\\" + DateTime.Now.ToString("yyyyMMddhhmmss") + ".jpg");
                    Settingimageentity tempentity = new Settingimageentity();
                    tempentity.setparamatername(paramatername);
                    tempentity.setimage(newbitmap);
                    tempentity.setparamatertype(paramatertype);
                    list1.Add(tempentity);
                    ((Settingimagedetection)tabControl1.TabPages[tapindexi].Controls[0]).pointStartX = pointStartX;
                    ((Settingimagedetection)tabControl1.TabPages[tapindexi].Controls[0]).pointStartY = pointStartY;
                    ((Settingimagedetection)tabControl1.TabPages[tapindexi].Controls[0]).pointEndX = pointEndX;
                    ((Settingimagedetection)tabControl1.TabPages[tapindexi].Controls[0]).pointEndY = pointEndY;
                    for (int k = 0; k < methodtemp.getsettinglist().Count; k++)
                    {
                        Settingentity settingentity = (Settingentity)methodtemp.getsettinglist()[k];
                        if (settingentity.getparamatername() == paramatername)
                        {
                            settingentity.getImageSample().setimagesample(rectNew.X * framewidth, rectNew.Y * frameheight, rectNew.Width * framewidth, rectNew.Height * frameheight);
                            break;
                        }
                    }
                    blnDraw = false;
                }

            }
        }

        private void leftbtn_Click(object sender, EventArgs e)
        {
            if (chartstack.Count > 1)
            {
                for (int k = 0; k < list1.Count; k++)
                {
                    Settingimageentity tempsettingimageeneity = (Settingimageentity)list1[k];
                    if (tempsettingimageeneity.getparamatername() == paramatername)
                    {
                        list1.RemoveAt(k);
                    }
                }
                chartstack.RemoveAt(chartstack.Count - 1);
                pictureBox1.Image = (Bitmap)chartstack[chartstack.Count - 1];
                pointStartX = pointStartX - 1;
                pointEndX = pointEndX - 1;
                int iWidth = pointEndX - pointStartX;
                int iHeight = pointEndY - pointStartY;
                if (chartstack.Count == 0)
                {
                    bitmapSource = (Bitmap)pictureBox1.Image;
                }
                else
                    bitmapSource = (Bitmap)chartstack[chartstack.Count - 1];
                if (bitmapSource != null)
                {
                    bitmap = new Bitmap(bitmapSource);
                    Pen pen = new Pen(Color.White);
                    Graphics gh = Graphics.FromImage(bitmap);
                    rectNew = new Rectangle(pointStartX, pointStartY, iWidth, iHeight);
                    gh.DrawRectangle(pen, rectNew);
                    //this.CreateGraphics().DrawImage(bitmap, pictureBox1.Left, pictureBox1.Top, 500, 500);
                    pictureBox1.Image = bitmap;
                    bitmapSource = bitmap;
                    // Graphics.FromImage(bitmap);
                    //          g.DrawImage(bitmap,rectNew);
                    Bitmap newbitmap = new Bitmap(rectNew.Width - 1, rectNew.Height - 1);
                    Bitmap chartstacktemp = new Bitmap(pictureBox1.Width, pictureBox1.Height);
                    pictureBox1.DrawToBitmap(chartstacktemp, new Rectangle(0, 0, pictureBox1.Width, pictureBox1.Height));
                    chartstack.Add(chartstacktemp);
                    g = Graphics.FromImage(newbitmap);
                    //g.DrawImage(bitmap, rectNew.Top, rectNew.Left);
                    g.DrawImage(bitmap, pictureBox1.Left - rectNew.Location.X - pictureBox1.Left - 1, pictureBox1.Top - rectNew.Location.Y - pictureBox1.Top - 1);
                    g.Dispose();
                    //newbitmap.Save("C:\\Users\\zsd\\Desktop\\" + DateTime.Now.ToString("yyyyMMddhhmmss") + ".jpg");
                    Settingimageentity tempentity = new Settingimageentity();
                    tempentity.setparamatername(paramatername);
                    tempentity.setimage(newbitmap);
                    tempentity.setparamatertype(paramatertype);
                    list1.Add(tempentity);
                    ((Settingimagedetection)tabControl1.TabPages[tapindexi].Controls[0]).pointStartX = pointStartX;
                    ((Settingimagedetection)tabControl1.TabPages[tapindexi].Controls[0]).pointStartY = pointStartY;
                    ((Settingimagedetection)tabControl1.TabPages[tapindexi].Controls[0]).pointEndX = pointEndX;
                    ((Settingimagedetection)tabControl1.TabPages[tapindexi].Controls[0]).pointEndY = pointEndY;
                    for (int k = 0; k < methodtemp.getsettinglist().Count; k++)
                    {
                        Settingentity settingentity = (Settingentity)methodtemp.getsettinglist()[k];
                        if (settingentity.getparamatername() == paramatername)
                        {
                            settingentity.getImageSample().setimagesample(rectNew.X * framewidth, rectNew.Y * frameheight, rectNew.Width * framewidth, rectNew.Height * frameheight);
                            break;
                        }
                    }
                    blnDraw = false;
                }

            }
        }

        private void rightbtn_Click(object sender, EventArgs e)
        {
            if (chartstack.Count > 1)
            {
                for (int k = 0; k < list1.Count; k++)
                {
                    Settingimageentity tempsettingimageeneity = (Settingimageentity)list1[k];
                    if (tempsettingimageeneity.getparamatername() == paramatername)
                    {
                        list1.RemoveAt(k);
                    }
                }
                chartstack.RemoveAt(chartstack.Count - 1);
                pictureBox1.Image = (Bitmap)chartstack[chartstack.Count - 1];
                pointStartX = pointStartX + 1;
                pointEndX = pointEndX + 1;
                int iWidth = pointEndX - pointStartX;
                int iHeight = pointEndY - pointStartY;
                if (chartstack.Count == 0)
                {
                    bitmapSource = (Bitmap)pictureBox1.Image;
                }
                else
                    bitmapSource = (Bitmap)chartstack[chartstack.Count - 1];
                if (bitmapSource != null)
                {
                    bitmap = new Bitmap(bitmapSource);
                    Pen pen = new Pen(Color.White);
                    Graphics gh = Graphics.FromImage(bitmap);
                    rectNew = new Rectangle(pointStartX, pointStartY, iWidth, iHeight);
                    gh.DrawRectangle(pen, rectNew);
                    //this.CreateGraphics().DrawImage(bitmap, pictureBox1.Left, pictureBox1.Top, 500, 500);
                    pictureBox1.Image = bitmap;
                    bitmapSource = bitmap;
                    // Graphics.FromImage(bitmap);
                    //          g.DrawImage(bitmap,rectNew);
                    Bitmap newbitmap = new Bitmap(rectNew.Width - 1, rectNew.Height - 1);
                    Bitmap chartstacktemp = new Bitmap(pictureBox1.Width, pictureBox1.Height);
                    pictureBox1.DrawToBitmap(chartstacktemp, new Rectangle(0, 0, pictureBox1.Width, pictureBox1.Height));
                    chartstack.Add(chartstacktemp);
                    g = Graphics.FromImage(newbitmap);
                    //g.DrawImage(bitmap, rectNew.Top, rectNew.Left);
                    g.DrawImage(bitmap, pictureBox1.Left - rectNew.Location.X - pictureBox1.Left - 1, pictureBox1.Top - rectNew.Location.Y - pictureBox1.Top - 1);
                    g.Dispose();
                    //newbitmap.Save("C:\\Users\\zsd\\Desktop\\" + DateTime.Now.ToString("yyyyMMddhhmmss") + ".jpg");
                    Settingimageentity tempentity = new Settingimageentity();
                    tempentity.setparamatername(paramatername);
                    tempentity.setimage(newbitmap);
                    tempentity.setparamatertype(paramatertype);
                    list1.Add(tempentity);
                    ((Settingimagedetection)tabControl1.TabPages[tapindexi].Controls[0]).pointStartX = pointStartX;
                    ((Settingimagedetection)tabControl1.TabPages[tapindexi].Controls[0]).pointStartY = pointStartY;
                    ((Settingimagedetection)tabControl1.TabPages[tapindexi].Controls[0]).pointEndX = pointEndX;
                    ((Settingimagedetection)tabControl1.TabPages[tapindexi].Controls[0]).pointEndY = pointEndY;
                    for (int k = 0; k < methodtemp.getsettinglist().Count; k++)
                    {
                        Settingentity settingentity = (Settingentity)methodtemp.getsettinglist()[k];
                        if (settingentity.getparamatername() == paramatername)
                        {
                            settingentity.getImageSample().setimagesample(rectNew.X * framewidth, rectNew.Y * frameheight, rectNew.Width * framewidth, rectNew.Height * frameheight);
                            break;
                        }
                    }
                    blnDraw = false;
                }

            }
        }

        private void setttingdetectsectiondeleteallbtn_Click(object sender, EventArgs e)
        {
            list1.Clear();
            for (int i = 0; i < tabControl1.TabCount; i++)
            {
                tabControl1.SelectedIndex = i;
                tabControl1_SelectedIndexChanged(null,null);
                Bitmap temp = new Bitmap(pictureBox1.Width, pictureBox1.Height);
                if (chartstack.Count > 0)
                {
                    temp = (Bitmap)chartstack[0];
                    chartstack.Clear();
                    pictureBox1.Image = temp;                 
                }
                neededboxes = methodtemp.getsettinglist().Count;
                settingdetectsectionneededvaluelabel.Text = neededboxes.ToString();
            }
            
        }

        private void settingdetectsectoindeletebtn_Click(object sender, EventArgs e)
        {
            if (chartstack.Count > 1)
            {
                for(int i=0;i<list1.Count;i++)
                {
                    if (((Settingimageentity)list1[i]).getparamatername() == paramatername)
                    {
                        list1.RemoveAt(list1.Count - 1);
                    }
                }
                chartstack.RemoveAt(chartstack.Count - 1);
                pictureBox1.Image = (Bitmap)chartstack[chartstack.Count - 1];
                neededboxes++;
                settingdetectsectionneededvaluelabel.Text = neededboxes.ToString();
            }
        }

        private void sensitiveSettingToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Settingsensitive settingsensitiveform = new Settingsensitive(list1, methodtemp);
            settingsensitiveform.ShowDialog();
        }

        internal void refreshlanguage(string name)
        {
            StreamReader sr = new StreamReader(System.Environment.CurrentDirectory + "\\" + name + ".txt", Encoding.Default);
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
                        else if (this.Controls[i].Name =="panel1")
                        {
                            for (int a = 0; a < this.panel1.Controls.Count; a++)
                            {
                                if (this.panel1.Controls[a].Name == match[0].ToString())
                                {
                                    this.panel1.Controls[a].Text = result;
                                    break;
                                }
                            }
                        }
                        else if (this.Controls[i].Name == "menuStrip1")
                        {
                            for (int k = 0; k < ((MenuStrip)this.Controls[i]).Items.Count; k++)
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

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tabControl1.SelectedTab.Controls[0].Controls[0].Name == "pictureBox1")
            {
                copyStartX = pointStartX;
                copyStartY = pointStartY;
                copyEndX = pointEndX;
                copyEndY = pointEndY;
                copyrecwidth = rectNew.Width;
                copyrecheight = rectNew.Height;
                paramatername = tabControl1.SelectedTab.Name;
                pictureBox1 = (PictureBox)tabControl1.SelectedTab.Controls[0].Controls[0];
                rectNew = ((Settingimagedetection)tabControl1.SelectedTab.Controls[0]).rectNew;
                chartstack = ((Settingimagedetection)tabControl1.SelectedTab.Controls[0]).chartstack;
                pointStartX = ((Settingimagedetection)tabControl1.SelectedTab.Controls[0]).pointStartX;
                pointStartY = ((Settingimagedetection)tabControl1.SelectedTab.Controls[0]).pointStartY;
                pointEndX = ((Settingimagedetection)tabControl1.SelectedTab.Controls[0]).pointEndX;
                pointEndY = ((Settingimagedetection)tabControl1.SelectedTab.Controls[0]).pointEndY;
                tapindexi = tabControl1.SelectedIndex;
            }
        }

        private void Settingdetectsectioncopybtn_Click(object sender, EventArgs e)
        {
            if (pictureBox1.Image != null)
            {
                if (chartstack.Count == 0)
                {
                    bitmapSource = (Bitmap)pictureBox1.Image;
                    Bitmap chartstacktemp = new Bitmap(pictureBox1.Width, pictureBox1.Height);
                    pictureBox1.DrawToBitmap(chartstacktemp, new Rectangle(0, 0, pictureBox1.Width, pictureBox1.Height));
                    chartstack.Add(chartstacktemp);
                }
            }
            if (chartstack.Count > 1)
            {
                for (int k = 0; k < list1.Count; k++)
                {
                    Settingimageentity tempsettingimageeneity = (Settingimageentity)list1[k];
                    if (tempsettingimageeneity.getparamatername() == paramatername)
                    {
                        list1.RemoveAt(k);
                    }
                }
                chartstack.RemoveAt(chartstack.Count - 1);
                pictureBox1.Image = (Bitmap)chartstack[chartstack.Count - 1];
                pointStartX = copyStartX;
                pointEndX = copyEndX;
                pointEndY = copyEndY;
                pointStartY = copyStartY;

                int iWidth = copyEndX - copyStartX;
                int iHeight = copyEndY - copyStartY;
                if (chartstack.Count == 0)
                {
                    bitmapSource = (Bitmap)pictureBox1.Image;
                }
                else
                    bitmapSource = (Bitmap)chartstack[chartstack.Count - 1];
                if (bitmapSource != null)
                {
                    bitmap = new Bitmap(bitmapSource);
                    Pen pen = new Pen(Color.White);
                    Graphics gh = Graphics.FromImage(bitmap);
                    rectNew = new Rectangle(pointStartX, pointStartY, iWidth, iHeight);
                    gh.DrawRectangle(pen, rectNew);
                    //this.CreateGraphics().DrawImage(bitmap, pictureBox1.Left, pictureBox1.Top, 500, 500);
                    pictureBox1.Image = bitmap;
                    bitmapSource = bitmap;
                    // Graphics.FromImage(bitmap);
                    //          g.DrawImage(bitmap,rectNew);
                    Bitmap newbitmap = new Bitmap(rectNew.Width - 1, rectNew.Height - 1);
                    Bitmap chartstacktemp = new Bitmap(pictureBox1.Width, pictureBox1.Height);
                    pictureBox1.DrawToBitmap(chartstacktemp, new Rectangle(0, 0, pictureBox1.Width, pictureBox1.Height));
                    chartstack.Add(chartstacktemp);
                    g = Graphics.FromImage(newbitmap);
                    //g.DrawImage(bitmap, rectNew.Top, rectNew.Left);
                    g.DrawImage(bitmap, pictureBox1.Left - rectNew.Location.X - pictureBox1.Left - 1, pictureBox1.Top - rectNew.Location.Y - pictureBox1.Top - 1);
                    g.Dispose();
                    //newbitmap.Save("C:\\Users\\zsd\\Desktop\\" + DateTime.Now.ToString("yyyyMMddhhmmss") + ".jpg");
                    Settingimageentity tempentity = new Settingimageentity();
                    tempentity.setparamatername(paramatername);
                    tempentity.setimage(newbitmap);
                    tempentity.setparamatertype(paramatertype);
                    list1.Add(tempentity);
                    ((Settingimagedetection)tabControl1.TabPages[tapindexi].Controls[0]).pointStartX = pointStartX;
                    ((Settingimagedetection)tabControl1.TabPages[tapindexi].Controls[0]).pointStartY = pointStartY;
                    ((Settingimagedetection)tabControl1.TabPages[tapindexi].Controls[0]).pointEndX = pointEndX;
                    ((Settingimagedetection)tabControl1.TabPages[tapindexi].Controls[0]).pointEndY = pointEndY;
                    for (int k = 0; k < methodtemp.getsettinglist().Count; k++)
                    {
                        Settingentity settingentity = (Settingentity)methodtemp.getsettinglist()[k];
                        if (settingentity.getparamatername() == paramatername)
                        {
                            settingentity.getImageSample().setimagesample(rectNew.X * framewidth, rectNew.Y * frameheight, rectNew.Width * framewidth, rectNew.Height * frameheight);
                            break;
                        }
                    }
                    blnDraw = false;
                    neededboxes--;
                    settingdetectsectionneededvaluelabel.Text = neededboxes.ToString();
                }

            }
            else
            {
                pictureBox1.Image = (Bitmap)chartstack[chartstack.Count - 1];
                pointStartX = copyStartX;
                pointEndX = copyEndX;
                pointEndY = copyEndY;
                pointStartY = copyStartY;

                int iWidth = copyEndX - copyStartX;
                int iHeight = copyEndY - copyStartY;
                if (chartstack.Count == 0)
                {
                    bitmapSource = (Bitmap)pictureBox1.Image;
                }
                else
                    bitmapSource = (Bitmap)chartstack[chartstack.Count - 1];
                if (bitmapSource != null)
                {
                    bitmap = new Bitmap(bitmapSource);
                    Pen pen = new Pen(Color.White);
                    Graphics gh = Graphics.FromImage(bitmap);
                    rectNew = new Rectangle(pointStartX, pointStartY, iWidth, iHeight);
                    gh.DrawRectangle(pen, rectNew);
                    //this.CreateGraphics().DrawImage(bitmap, pictureBox1.Left, pictureBox1.Top, 500, 500);
                    pictureBox1.Image = bitmap;
                    bitmapSource = bitmap;
                    // Graphics.FromImage(bitmap);
                    //          g.DrawImage(bitmap,rectNew);
                    Bitmap newbitmap = new Bitmap(rectNew.Width - 1, rectNew.Height - 1);
                    Bitmap chartstacktemp = new Bitmap(pictureBox1.Width, pictureBox1.Height);
                    pictureBox1.DrawToBitmap(chartstacktemp, new Rectangle(0, 0, pictureBox1.Width, pictureBox1.Height));
                    chartstack.Add(chartstacktemp);
                    g = Graphics.FromImage(newbitmap);
                    //g.DrawImage(bitmap, rectNew.Top, rectNew.Left);
                    g.DrawImage(bitmap, pictureBox1.Left - rectNew.Location.X - pictureBox1.Left - 1, pictureBox1.Top - rectNew.Location.Y - pictureBox1.Top - 1);
                    g.Dispose();
                    //newbitmap.Save("C:\\Users\\zsd\\Desktop\\" + DateTime.Now.ToString("yyyyMMddhhmmss") + ".jpg");
                    Settingimageentity tempentity = new Settingimageentity();
                    tempentity.setparamatername(tabControl1.TabPages[tapindexi].Name.ToString());
                    tempentity.setimage(newbitmap);
                    tempentity.setparamatertype(paramatertype);
                    list1.Add(tempentity);
                    ((Settingimagedetection)tabControl1.TabPages[tapindexi].Controls[0]).pointStartX = pointStartX;
                    ((Settingimagedetection)tabControl1.TabPages[tapindexi].Controls[0]).pointStartY = pointStartY;
                    ((Settingimagedetection)tabControl1.TabPages[tapindexi].Controls[0]).pointEndX = pointEndX;
                    ((Settingimagedetection)tabControl1.TabPages[tapindexi].Controls[0]).pointEndY = pointEndY;
                    for (int k = 0; k < methodtemp.getsettinglist().Count; k++)
                    {
                        Settingentity settingentity = (Settingentity)methodtemp.getsettinglist()[k];
                        if (settingentity.getparamatername() == paramatername)
                        {
                            settingentity.getImageSample().setimagesample(rectNew.X * framewidth, rectNew.Y * frameheight, rectNew.Width * framewidth, rectNew.Height * frameheight);
                            break;
                        }
                    }
                    blnDraw = false;
                    neededboxes--;
                    settingdetectsectionneededvaluelabel.Text = neededboxes.ToString();
                }
            }
        }
    }
}
