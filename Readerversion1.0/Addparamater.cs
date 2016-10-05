using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Readerversion1._0
{
    public partial class Addparamater : Form
    {
        private Settingentity settingentity;
        public Addparamater(Settingentity tempvalue)
        {
            InitializeComponent();
            settingentity = tempvalue;
        }

        private void Addparamaterrangesettingbtn_Click(object sender, EventArgs e)
        {
            TestlineSetting temptestlinesetting = new TestlineSetting(settingentity);
            temptestlinesetting.ShowDialog();
        }

        private void Addparamaternextbtn_Click(object sender, EventArgs e)
        {
            settingentity.setparamatername(Addparamaternamevalue.Text);
            settingentity.setclinevalue(Addparamaterclinevalue.Text);
            ResultEntity tempresultentity=new ResultEntity();
            tempresultentity.setresultname("Control line");
            tempresultentity.setresultstartvalue(int.Parse(Addparamatersetstartvalue.Text));
            tempresultentity.setresultendvalue(int.Parse(Addparamatersetendvalue.Text));
            settingentity.getresultentitylist().Add(tempresultentity);
            settingentity.setshuttertimes(int.Parse(Addparamatershuttertimevalue.Text));
            settingentity.setreadytime(int.Parse(Addparamaterreadytimevalue.Text));
        }
    }
}
