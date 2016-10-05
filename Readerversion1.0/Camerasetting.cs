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

namespace Readerversion1._0
{
    public partial class Camerasetting : Form
    {
        private FilterInfoCollection videoDevices;
        private string devicename;
        private int flag = 1;
        private Settingdetectsection tempform;
        private int indexi = 0;
        public Camerasetting()
        {
            InitializeComponent();
        }
        public Camerasetting(Settingdetectsection form,string tempdevicename,int valuei)
        {
            InitializeComponent();
            devicename = tempdevicename;
            tempform = form;
            indexi = valuei;
            if (Form1.language != "")
            {
                refreshlanguage(Form1.language);
            }
        }
        private void brightnesstrackBar_ValueChanged(object sender, EventArgs e)//set brightness
        {
            tempform.brightness = brightnesstrackBar.Value / 1;
            label1.Text = tempform.brightness.ToString();
            flag = 0;
            videPlayer.VideoSource.NewFrame += new NewFrameEventHandler(video_NewFrame);
        }

        private void Camerasetting_Load(object sender, EventArgs e)//connect with camera
        {
            try
            {
                // detect all of devices in the computer
                videoDevices = new FilterInfoCollection(FilterCategory.VideoInputDevice);

                if (videoDevices.Count == 0)
                    throw new ApplicationException();
                int i = 0;
                foreach (FilterInfo device in videoDevices)
                {
                    if (device.Name == devicename)
                    {
                        VideoCaptureDevice videoSource = new VideoCaptureDevice(videoDevices[i].MonikerString);
                        videoSource.VideoResolution = videoSource.VideoCapabilities[indexi];
                        videoSource.DesiredFrameSize = new Size(320, 240);
                        videoSource.DesiredFrameRate = 1;
                        videPlayer.VideoSource = videoSource;
                        videPlayer.Start();
                    }
                    i++;
                }
                flag = 0;
                videPlayer.VideoSource.NewFrame += new NewFrameEventHandler(video_NewFrame);
            }
            catch (ApplicationException)
            {
                videoDevices = null;
            }
        }

        private void video_NewFrame(object sender, NewFrameEventArgs eventArgs)//get picture from camera
        {
            Bitmap bitmap = (Bitmap)eventArgs.Frame.Clone();
            if (flag == 0)
            {
                //bitmap.Save(img);
                flag = 1;
                bitmap = new Bitmap(bitmap, new Size(320, 240));
                ContrastCorrection filter = new ContrastCorrection(tempform.contrast);
                BrightnessCorrection bfilter = new BrightnessCorrection(tempform.brightness);
                SaturationCorrection sfilter = new SaturationCorrection(tempform.saturation);
                bfilter.ApplyInPlace(bitmap);
                filter.ApplyInPlace(bitmap);
                sfilter.ApplyInPlace(bitmap);
                pictureBox1.Image = bitmap;
            }

        }

        private void contrasttrackBar_ValueChanged(object sender, EventArgs e)//set contrast
        {
            tempform.contrast = contrasttrackBar.Value / 1;
            label2.Text = tempform.contrast.ToString();
            flag = 0;
            videPlayer.VideoSource.NewFrame += new NewFrameEventHandler(video_NewFrame);
        }

        private void saturationtrackBar_ValueChanged(object sender, EventArgs e)//set saturation
        {
            tempform.saturation = saturationtrackBar.Value * 0.1f;
            label7.Text = tempform.saturation.ToString();
            flag = 0;
            videPlayer.VideoSource.NewFrame += new NewFrameEventHandler(video_NewFrame);
        }

        private void Camerasetting_FormClosing(object sender, FormClosingEventArgs e)
        {
            videPlayer.SignalToStop();
            videPlayer.WaitForStop();
            tempform.settingdetectsectionload(devicename,indexi);
        }
        internal void refreshlanguage(string name)//set language
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
                        }
                    }
                }
            }

        }
    }
}
