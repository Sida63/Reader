using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
namespace Readerversion1._0
{
    public class MethodEntity
    {
        private string methodname;
        private int sensitive;
        private int adjustvalue;
        private Cameraandsourcesetting cameraandsourcesetting=new Cameraandsourcesetting();
        private ArrayList settinglist=new ArrayList();
        public void setmethodname(string value)
        {
            methodname = value;
        }
        public string getmethodname()
        {
            return methodname;
        }
        public ArrayList getsettinglist()
        {
            return settinglist;
        }
        public Cameraandsourcesetting getcameraandsourcesetting()
        {
            return cameraandsourcesetting;
        }
        public void setsensitive(int value)
        {
            sensitive = value;
        }
        public int getsensitive()
        {
            return sensitive;
        }
        public void setadjustvalue(int value)
        {
            adjustvalue = value;
        }
        public int getadjustvalue()
        {
            return adjustvalue;
        }
    }
}
