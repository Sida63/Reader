using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace Readerversion1._0
{
    public class Settingentity
    {
        private string paramatername;
        private ArrayList resultentitylist = new ArrayList();
        private int shuttertimes=1;
        private int readytime=0;
        private string clinevalue;
        private ImageSampleEntity imagesampleentity = new ImageSampleEntity();
        public void setclinevalue(string value)
        {
            clinevalue = value;
        }
        public ImageSampleEntity getImageSample()
        {
            return imagesampleentity;
        }
        public string getlinevalue()
        {
            return clinevalue;
        }
        public void setparamatername(string value)
        {
            paramatername = value;
        }
        public void setshuttertimes(int values)
        {
            shuttertimes = values;
        }
        public void setreadytime(int value)
        {
            readytime = value;
        }
        public string getparamatername()
        {
            return paramatername;
        }
        public int getshuttertimes()
        {
            return shuttertimes;
        }
        public int getreadytime()
        {
            return readytime;
        }
        public ArrayList getresultentitylist()
        {
            return resultentitylist;
        }
    }
}
