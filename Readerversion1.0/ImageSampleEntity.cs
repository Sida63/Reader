using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace Readerversion1._0
{
    public class ImageSampleEntity
    {
        private int imagepositionx;
        private int imagepositiony;
        private int imagewidth;
        private int imageheight;
        private ArrayList controlzonelist=new ArrayList();
        public void setimagesample(int x,int y,int width,int height)
        {
            imagepositionx = x;
            imagepositiony = y;
            imagewidth = width;
            imageheight = height;
        }
        public void setimagepositionx(int x)
        {
            imagepositionx = x;
        }
        public void setimagepositiony(int y)
        {
            imagepositiony = y;
        }
        public void setimagewidth(int width)
        {
            imagewidth = width;
        }
        public void setimageheight(int height)
        {
            imageheight = height;
        }
        public int getx()
        {
            return imagepositionx;
        }
        public int gety()
        {
            return imagepositiony;
        }
        public int getimagewidth()
        {
            return imagewidth;
        }
        public int getimageheight()
        {
            return imageheight;
        }
        public ArrayList getcontrolzonelist()
        {
            return controlzonelist;
        }
    }

}
