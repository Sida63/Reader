/*
 * this class will be instantiated when the program invoke the Settingdetectsection class
 */
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

namespace Readerversion1._0
{
    public partial class Settingimagedetection : Form
    {
        public int pointStartX, pointStartY, pointEndX, pointEndY;
        private bool blnDraw = false;
        public Rectangle rectNew;
        public ArrayList chartstack = new ArrayList();
        public Bitmap bitmapSource = null;
        public Bitmap bitmap = null;
        public Graphics g;
        public int framewidth;
        public int frameheight;
        public string name;
        Settingdetectsection tempform;
        public Settingimagedetection(Settingdetectsection form,string namevalue,int fwidth,int fheight)
        {
            InitializeComponent();
            tempform = form;
            name = namevalue;
            framewidth = fwidth;
            frameheight = fheight;
            this.FormBorderStyle = FormBorderStyle.None;
            this.ShowInTaskbar = false; 
        }

        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
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
                else
                    bitmapSource = (Bitmap)chartstack[chartstack.Count - 1];
                pointStartX = e.X;
                pointStartY = e.Y;
                pointEndX = e.X;
                pointEndY = e.Y;
                blnDraw = true;
            }
        }

        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            if (blnDraw == true)
            {
                int iWidth = e.X - pointStartX;
                int iHeight = e.Y - pointStartY;
                if (e.Button == MouseButtons.Left)
                {
                    bitmap = new Bitmap(bitmapSource);
                    Pen pen = new Pen(Color.White);
                    Graphics gh = Graphics.FromImage(bitmap);
                    rectNew = new Rectangle(pointStartX, pointStartY, iWidth, iHeight);
                    gh.DrawRectangle(pen, rectNew);
                    pictureBox1.Image = bitmap;
                }
            }
        }

        private void pictureBox1_MouseUp(object sender, MouseEventArgs e)
        {
            if (rectNew.Width - 1 > 0 && rectNew.Height - 1 > 0 && bitmapSource != null)
            {
                pointEndX = e.X;
                pointEndY = e.Y;
                bitmapSource = bitmap;
                ImageSampleEntity imagesample = new ImageSampleEntity();
                Bitmap newbitmap = new Bitmap(rectNew.Width - 1, rectNew.Height - 1);
                Bitmap chartstacktemp = new Bitmap(pictureBox1.Width, pictureBox1.Height);
                pictureBox1.DrawToBitmap(chartstacktemp, new Rectangle(0, 0, pictureBox1.Width, pictureBox1.Height));
                chartstack.Add(chartstacktemp);
                g = Graphics.FromImage(newbitmap);
                g.DrawImage(bitmap, pictureBox1.Left - rectNew.Location.X - pictureBox1.Left - 1, pictureBox1.Top - rectNew.Location.Y - pictureBox1.Top - 1);
                g.Dispose();
                newbitmap.Save(Environment.CurrentDirectory + "\\image\\" + DateTime.Now.ToString("yyyyMMddhhmmss") + ".jpg");
                tempform.chartstack = chartstack;
                tempform.rectNew = rectNew;
                tempform.pointStartX = pointStartX;
                tempform.pointStartY = pointStartY;
                tempform.pointEndX = pointEndX;
                tempform.pointEndY = pointEndY;
                tempform.frameheight = frameheight;
                tempform.framewidth = framewidth;
                Settingimageentity tempentity = new Settingimageentity();
                tempentity.setimage(newbitmap);
                tempentity.setparamatername(name);
                tempform.paramatername = name;
                tempform.list1.Add(tempentity);
                for (int k = 0; k < tempform.methodtemp.getsettinglist().Count; k++)
                {
                    if (((Settingentity)tempform.methodtemp.getsettinglist()[k]).getparamatername() == name)
                    {
                        Settingentity settingentity = ((Settingentity)tempform.methodtemp.getsettinglist()[k]);
                        settingentity.getImageSample().setimagesample(rectNew.X * framewidth, rectNew.Y * frameheight, rectNew.Width * framewidth, rectNew.Height * frameheight);
                        tempform.paramatertype = ((Settingentity)tempform.methodtemp.getsettinglist()[k]).getlinevalue();
                        tempentity.setparamatertype(((Settingentity)tempform.methodtemp.getsettinglist()[k]).getlinevalue());
                    }
                }
                    tempform.neededboxes--;
                tempform.settingdetectsectionneededvaluelabel.Text = tempform.neededboxes.ToString();
            }
        }

       
    }
}
