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
    public partial class MethodEdit : Form
    {
        private MethodEntity methodentity;
        public MethodEdit(MethodEntity tempmethodentity)
        {
            InitializeComponent();
            methodentity = tempmethodentity;
        }

        private void MethodEdit_Load(object sender, EventArgs e)
        {
            methodeditmethodnametextbox.Text = methodentity.getmethodname();
            for (int i = 0; i < methodentity.getsettinglist().Count; i++)
            {
                methodeditparamatercombox.Items.Add(((Settingentity)methodentity.getsettinglist()[i]).getparamatername());
            }

        }

        private void methodeditaddbtn_Click(object sender, EventArgs e)
        {
            Settingentity tempsettingentity = new Settingentity();
            Addparamater tempform = new Addparamater(tempsettingentity);

        }
    }
}
