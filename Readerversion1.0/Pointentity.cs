using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Readerversion1._0
{
    class Pointentity
    {
        private int color;
        private string name = "";
        public void setcolor(int value)
        {
            color = value;
        }
        public void setname(string value)
        {
            name = value;
        }
        public int getcolor()
        {
            return color;
        }
        public string getname()
        {
            return name;
        }
    }
}
