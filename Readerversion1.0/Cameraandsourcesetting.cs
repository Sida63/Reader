using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Readerversion1._0
{
    public class Cameraandsourcesetting
    {
        private int brightness;
        private int contrast;
        private float saturation;
        private string cameraname;
        private int resolution;
        public void setresolution(int value)
        {
            resolution = value;
        }
        public int getresolution()
        {
            return resolution;
        }
        public void setbrightnes(int value)
        {
            brightness = value;
        }
        public void setcontrast(int value)
        {
            contrast = value;
        }
        public void setsaturation(float value)
        {
            saturation = value;
        }
        public void setcameraname(string value)
        {
            cameraname = value;
        }
        public int getbrightness()
        {
            return brightness;
        }
        public int getcontrast()
        {
            return contrast;
        }
        public float getsaturation()
        {
            return saturation;
        }
        public string getcameraname()
        {
            return cameraname;
        }
    }
}
