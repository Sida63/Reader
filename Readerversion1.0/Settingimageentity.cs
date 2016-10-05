using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Readerversion1._0
{
    class Settingimageentity
    {
        private string paramatername;
        private Bitmap image;
        private string paramatertype;
        public void setparamatername(string name)
        {
            paramatername = name;
        }
        public void setimage(Bitmap tempimage)
        {
            image = tempimage;
        }
        public string getparamatername()
        {
            return paramatername;
        }
        public Bitmap getimage()
        {
            return image;
        }
        public void setparamatertype(string type)
        {
            paramatertype = type;
        }
        public string getparamatertype()
        {
            return paramatertype;
        }
    }
}
