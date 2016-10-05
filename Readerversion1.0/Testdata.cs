using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Readerversion1._0
{
    class Testdata
    {
        private string name;
        private int clinevalue;
        private int tlinevalue;
        private int background;
        private string result;
        private string ifvalid;
        public void setname(string value)
        {
            name = value;
        }
        public void setclinevalue(int valuenumber)
        {
            clinevalue = valuenumber;
        }
        public void settlinevalue(int valuenumber)
        {
            tlinevalue = valuenumber;
        }
        public void setbackground(int backgrojndvalue)
        {
            background = backgrojndvalue;
        }
        public void setresult(string resultvalue)
        {
            result = resultvalue;
        }
        public void setifvalid(string value)
        {
            ifvalid = value;
        }
        public string getname()
        {
            return name;
        }
        public int getclinevalue()
        {
            return clinevalue;
        }
        public int gettlinevalue()
        {
            return tlinevalue;
        }
        public int getbackground()
        {
            return background;
        }
        public string getresult()
        {
            return result;
        }
        public string getifvalid()
        {
            return ifvalid;
        }
    }
}
