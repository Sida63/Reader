using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Drawing.Imaging;

namespace Readerversion1._0
{
    public class ImageProcessing
    {
        private static bool countflag = false;
        public static Bitmap imagecombine(Bitmap image1, Bitmap image2)
        {
            for (int i = 0; i < image1.Width; i++)
            {
                for (int j = 0; j < image1.Height; j++)
                {
                    Color colorimg1 = image1.GetPixel(i, j);
                    Color colorimg2 = image2.GetPixel(i, j);
                    //calculate the gray value
                    Color newColor = Color.FromArgb((int)((colorimg1.R + colorimg2.R) / 2), (int)((colorimg1.G + colorimg2.G) / 2), (int)((colorimg1.B + colorimg2.B) / 2));
                    image1.SetPixel(i, j, newColor);
                }
            }
            return image1;
        }
        public static Bitmap ToGray(Bitmap bmp)
        {
            for (int i = 0; i < bmp.Width; i++)
            {
                for (int j = 0; j < bmp.Height; j++)
                { 
                    Color color = bmp.GetPixel(i, j); 
                    int gray = (int)(color.R * 0.3 + color.G * 0.59 + color.B * 0.11);
                    Color newColor = Color.FromArgb(gray, gray, gray);
                    bmp.SetPixel(i, j, newColor);
                }
            }
            return bmp;
        }
        public static int Rcogniseaveragevalue(Bitmap bmp)// not be used
        {
            int average = 0;
            int count = 0;
            for (int i = 0; i < bmp.Width; i++)
            {
                for (int j = 0; j < bmp.Height; j++)
                {
                    Color color = bmp.GetPixel(i, j);
                    average += color.B;
                }
            }
            average = (int)average / (bmp.Width * bmp.Height);
            int i1 = bmp.Width / 2;
            int temp = 255;
            bool tempcount = false;
            for (int j = 0; j < bmp.Height; j++)
            {
                Color color = bmp.GetPixel(i1, j);
                if (color.B - average < 0)
                {
                    tempcount = true;
                }
                else
                {
                    tempcount = false;
                }
                if (countflag ^ tempcount == true)
                {
                    count++;
                    countflag = tempcount;
                }
            }

            //average = (int)average / (bmp.Width * bmp.Height); //255,
            return count / 2;
        }
        public static Bitmap ConvertTo1Bpp1(Bitmap bmp)
        {
            bmp = ToGray(bmp);
            int average = 0;
            for (int i = 0; i < bmp.Width; i++)
            {
                for (int j = 0; j < bmp.Height; j++)
                {
                    Color color = bmp.GetPixel(i, j);
                    average += color.B;
                }
            }
            average = (int)average / (bmp.Width * bmp.Height);
            for (int i = 0; i < bmp.Width; i++)
            {
                for (int j = 0; j < bmp.Height; j++)
                {
                    Color color = bmp.GetPixel(i, j);
                    int value = 255 - color.B;
                    /*if (color.B > average)
                    {
                        Color newColor = Color.FromArgb(255, 255, 255);
                        bmp.SetPixel(i, j, newColor);
                    }
                    else if (color.B <= average)
                    {
                        Color newColor = Color.FromArgb(0, 0, 0);
                        bmp.SetPixel(i, j, newColor);
                    }*/
                    Color newColor = value > average ? Color.FromArgb(0, 0, 0) : Color.FromArgb(255, 255, 255);
                    bmp.SetPixel(i, j, newColor);
                }
            }
            return bmp;
        }
        public static Bitmap ConvertTo1Bpp2(Bitmap bmp)
        {
            bmp = ToGray(bmp);
            int average = 0;
            for (int i = 0; i < bmp.Width; i++)
            {
                for (int j = 0; j < bmp.Height; j++)
                {
                    Color color = bmp.GetPixel(i, j);
                    average += color.B;
                }
            }
            average = (int)average / (bmp.Width * bmp.Height);
            for (int i = 0; i < bmp.Width; i++)
            {
                for (int j = 0; j < bmp.Height; j++)
                { 
                    Color color = bmp.GetPixel(i, j);
                    int value = 255 - color.B;
                    /*if (color.B > average)
                    {
                        Color newColor = Color.FromArgb(255, 255, 255);
                        bmp.SetPixel(i, j, newColor);
                    }
                    else if (color.B <= average)
                    {
                        Color newColor = Color.FromArgb(0, 0, 0);
                        bmp.SetPixel(i, j, newColor);
                    }*/
                    Color newColor = value > 50 ? Color.FromArgb(0, 0, 0) : Color.FromArgb(255, 255, 255);
                    bmp.SetPixel(i, j, newColor);
                }
            }
            return bmp;
        }
    }
}
