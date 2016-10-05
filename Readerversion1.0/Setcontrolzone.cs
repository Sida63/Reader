using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Collections;

namespace Readerversion1._0
{
    public partial class Setcontrolzone : Form
    {
        private int framewidth;
        private int frameheight;
        public Setcontrolzone()
        {
            InitializeComponent();
            
        }
        public Setcontrolzone(ArrayList list, MethodEntity methodtemp, int framewightvalue, int frameheightvalue)
        {
            InitializeComponent();
            framewidth = framewightvalue;
            frameheight = frameheightvalue;

            for (int i = 0; i < list.Count; i++)
            {
                if (((Settingimageentity)list[i]).getparamatertype() != "Color")
                {
                    Bitmap tempbitmap = ((Settingimageentity)list[0]).getimage();//default value
                    TabPage tab = new TabPage();
                    tab.Name = ((Settingentity)methodtemp.getsettinglist()[i]).getparamatername();
                    tab.Text = tab.Name;
                    for (int k = 0; k < list.Count; k++)
                    {
                        if (((Settingentity)methodtemp.getsettinglist()[i]).getparamatername() == ((Settingimageentity)list[i]).getparamatername())
                        {
                            tempbitmap = ((Settingimageentity)list[i]).getimage();
                        }
                    }
                    Controlzoneentity form = new Controlzoneentity(tempbitmap, (Settingentity)methodtemp.getsettinglist()[i], framewidth, frameheight);
                    form.TopLevel = false;     
                    tab.Controls.Add(form.panel1);
                    tabControl1.TabPages.Add(tab);
                    form.Show();
                    tabControl1.Show();
                }
            }
        }
        private void setzonefinishbtn_Click(object sender, EventArgs e)
        {

        }
    }
}
