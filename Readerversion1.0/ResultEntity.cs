using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Readerversion1._0
{
    public class ResultEntity
    {
        private int resultstartvalue;
        private int resultendvalue;
        private string resultname;
        private string resultvalue;
        public void setresultstartvalue(int value)
        {
            resultstartvalue = value;
        }
        public int getresultstartvalue()
        {
            return resultstartvalue;
        }
        public void setresultendvalue(int value)
        {
            resultendvalue = value;
        }
        public int getresultendvalue()
        {
            return resultendvalue;
        }
        public void setresultname(string value)
        {
            resultname = value;
        }
        public string getresultname()
        {
            return resultname;
        }
        public string getresultvalue()
        {
            return resultvalue;
        }
        public void setresultvalue(string value)
        {
            resultvalue = value;
        }
    }
}
