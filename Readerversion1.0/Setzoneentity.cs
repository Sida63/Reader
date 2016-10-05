using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Readerversion1._0
{
    class Setzoneentity
    {
        private int zonepositionx;
        private int zonepositiony;
        private int zonepositionwidth;
        private int zonepositionheight;
        private string zonecategory;
        public Setzoneentity(int xvalue,int yvalue,int width,int height,string category)
        {
            zonepositionx = xvalue;
            zonepositiony = yvalue;
            zonepositionwidth=width;
            zonepositionheight = height;
            zonecategory = category;
        }
        public void setzonepositionx(int x)
        {
            zonepositionx = x;
        }
        public void setzonepositiony(int y)
        {
            zonepositiony = y;
        }
        public void setpositionwidth(int width)
        {
            zonepositionwidth = width;
        }
        public void setpositionheight(int height)
        {
            zonepositionheight = height;
        }
        public int getzonepositionx()
        {
            return zonepositionx;
        }
        public int getzonepositiony()
        {
            return zonepositiony;
        }
        public int getzonepositionwidth()
        {
            return zonepositionwidth;
        }
        public int getzonepositionheight()
        {
            return zonepositionheight;
        }
        public string getzonecategory()
        {
            return zonecategory;
        }
    }
}
