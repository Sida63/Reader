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
using System.IO;
using System.Text.RegularExpressions;

namespace Readerversion1._0
{
    public partial class Controlzoneentity : Form
    {
        private int mousestartX, mousestartY, mouseendX, mouseendY;
        private ArrayList chartstack = new ArrayList();
        private int recstartX, recstartY, recendX, recendY;
        private bool moveflag = false;
        private Bitmap image;
        private int times=1;
        Rectangle rectNew;
        private Bitmap orginalimage;
        private Settingentity settingentity;
        private int framewidth;
        private int frameheight;
        private int mark=0;
        public Controlzoneentity()
        {
            InitializeComponent();
        }
        public Controlzoneentity(Bitmap imagevalue,Settingentity tempvalue,int tempframewidth,int tempframeheight)//set different areas for the control line and the test line
        {
            InitializeComponent();
            if (Form1.language != "")
            {
                refreshlanguage(Form1.language);
            }
            image = imagevalue;
            orginalimage = (Bitmap)imagevalue.Clone();
            image = new Bitmap(image, new Size(pictureBox1.Height, pictureBox1.Width));
            image.RotateFlip(RotateFlipType.Rotate270FlipNone);
            pictureBox1.Image = image;
            chartstack.Add(image);
            comboBox1.SelectedIndex = 4;
            controlradiobtn.Checked = true;
            settingentity = tempvalue;
            settingentity.getImageSample().getcontrolzonelist().Clear();
            framewidth = tempframewidth;
            frameheight = tempframeheight;

        }

        private void Controlzoneentity_Load(object sender, EventArgs e)
        {
            loaddata();
        }
        private void loaddata()//load the data
        {
            Pen pen = new Pen(Color.Red);
            Bitmap tempimage = new Bitmap((Bitmap)chartstack[chartstack.Count - 1]);
            recstartX = 0;
            recstartY = 0;
            recendX = pictureBox1.Width * int.Parse(comboBox1.Text.ToString()) / 10;
            recendY = pictureBox1.Height;
            int width = recendX - recstartX - 1;
            int height = recendY - recstartY - 1;
            if (times % 3 == 1)
            {
                 pen= new Pen(Color.Red);
            }
            else if (times % 3 == 2)
            {
                 pen = new Pen(Color.Blue);
            }
            else if (times % 3 == 0)
            {
                 pen = new Pen(Color.Green);
            }
            Graphics gh = Graphics.FromImage(tempimage);
            rectNew = new Rectangle(recstartX, recstartY, width, height);
            gh.DrawRectangle(pen, rectNew);
            pictureBox1.Image = tempimage;

        }

        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.X > recstartX && e.X < recendX && e.Y < recendY && e.Y > recstartY)
            {
                moveflag = true;
                mousestartX = e.X;
                mousestartY = e.Y;
            }
        }

        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            if (moveflag == true)
            {
                int mousexdistance = e.X - mousestartX;//get the result of mouse moving distance
                mousestartX = e.X;
                Bitmap tempimage = new Bitmap((Bitmap)chartstack[chartstack.Count - 1]);
                recstartX = recstartX + mousexdistance;
                recendX = recendX + mousexdistance;
                if (recendX <= pictureBox1.Width && recstartX >= 0)
                {
                    int width = recendX - recstartX - 1;
                    int height = recendY - recstartY - 1;
                    Pen pen = new Pen(Color.Red);
                    if (times % 3 == 1)
                    {
                        pen = new Pen(Color.Red);
                    }
                    else if (times % 3 == 2)
                    {
                        pen = new Pen(Color.Blue);
                    }
                    else if (times % 3 == 0)
                    {
                        pen = new Pen(Color.Green);
                    }
                    Graphics gh = Graphics.FromImage(tempimage);
                    rectNew = new Rectangle(recstartX, recstartY, width, height);
                    gh.DrawRectangle(pen, rectNew);
                    pictureBox1.Image = tempimage;
                }
                if (recstartX < 0)
                {
                    recstartX = 0;
                    recendX = (int)(pictureBox1.Width * (int.Parse(comboBox1.Text.ToString()) / 10.0));
                }
                if (recendX > pictureBox1.Width)
                {
                    recendX = pictureBox1.Width;
                    recstartX = (int)(recendX - 1 - (pictureBox1.Width * int.Parse(comboBox1.Text.ToString()) / 10.0));
                }

            }
        }

        private void pictureBox1_MouseUp(object sender, MouseEventArgs e)
        {
            if (moveflag == true)
            {
                moveflag = false;
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            loaddata();
        }

        private void contorlzoneentityfinsihbtn_Click(object sender, EventArgs e)
        {
            string tempcatgory;
            if(controlradiobtn.Checked&&mark==0)
            {
                tempcatgory="control";
                testtradiobtn.Checked = true;
                mark = 1;
            }
            else
            {
                tempcatgory="test";
            }
            Setzoneentity setzonetemp = new Setzoneentity((recstartY * orginalimage.Width / pictureBox1.Height)*framewidth, (recstartX * orginalimage.Height / pictureBox1.Width)*frameheight, ((recendY - recstartY - 1) * orginalimage.Width / pictureBox1.Height)*framewidth, ((recendX - recstartX - 1) * orginalimage.Height / pictureBox1.Width)*frameheight, tempcatgory);
            settingentity.getImageSample().getcontrolzonelist().Add(setzonetemp);
            times++;
            Bitmap nextbitmap = (Bitmap)pictureBox1.Image;
            chartstack.Add(nextbitmap);
            loaddata();
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

        private void controlradiobtn_CheckedChanged(object sender, EventArgs e)
        {
            if (mark == 1)
            {
                testtradiobtn.Checked = true;
            }
        }

    }
}
