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
using System.IO;
using System.Text.RegularExpressions;
namespace Readerversion1._0
{
    public partial class Sourcechoose : Form
    {
        private Settingdetectsection tempform;
        private FilterInfoCollection videoDevices;
        public Sourcechoose()
        {
            InitializeComponent();
        }
        public Sourcechoose(Settingdetectsection form)
        {
            InitializeComponent();
            tempform = form;
            if (Form1.language != "")
            {
                refreshlanguage(Form1.language);
            }
        }
        private void Sourcechoose_FormClosing(object sender, FormClosingEventArgs e)
        {
            tempform.settingdetectsectionload(Videochoosecombobox.Text.ToString(), resolutioncomboBox.SelectedIndex);
        }

        private void Sourcechoose_Load(object sender, EventArgs e)
        {
            try
            {
                videoDevices = new FilterInfoCollection(FilterCategory.VideoInputDevice);

                if (videoDevices.Count == 0)
                    throw new ApplicationException();

                foreach (FilterInfo device in videoDevices)//show all of camera devices in the laptop
                {
                    Videochoosecombobox.Items.Add(device.Name);
                }

                Videochoosecombobox.SelectedIndex = 0;
            }
            catch (ApplicationException)
            {
                Videochoosecombobox.Items.Add("No local capture devices");
                videoDevices = null;
            }
        }

        private void Videochoosecombobox_SelectedIndexChanged(object sender, EventArgs e)
        {
            VideoCaptureDevice videoSource = new VideoCaptureDevice(videoDevices[Videochoosecombobox.SelectedIndex].MonikerString);
            resolutioncomboBox.Items.Clear();
            for (int i = 0; i < videoSource.VideoCapabilities.Length; i++)
            {
                resolutioncomboBox.Items.Add(videoSource.VideoCapabilities[i].FrameSize.ToString());
            }
            resolutioncomboBox.SelectedIndex = 0;
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
                        }
                    }
                }
            }

        }
    }
}
