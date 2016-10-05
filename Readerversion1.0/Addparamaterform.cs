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
    public partial class Addparamaterform : Form
    {
        private MethodSettingEntity temp;
        public Addparamaterform()
        {
            InitializeComponent();
        }
        public Addparamaterform(MethodSettingEntity methodsettingentity)
        {
            InitializeComponent();
            temp = methodsettingentity;
        }

        private void addnewparamaterbtn_Click(object sender, EventArgs e)
        {
            temp.newparamatername = textBox1.Text.ToString();
            this.Close();
        }
    }
}
