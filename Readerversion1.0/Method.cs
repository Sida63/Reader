using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using System.Collections;
using System.IO;
using MySql.Data.MySqlClient;

namespace Readerversion1._0
{
    public partial class Method : Form
    {
        private MethodEntity methodtemp = new MethodEntity();
        private ArrayList methodlist;
        private Databaseoperator database = new Databaseoperator();
        private Form1 formtemp;
        private int editflag = 0;
        public Method()
        {
            InitializeComponent();
        }
        public Method(Form1 formvalue,ArrayList value)
        {
            InitializeComponent();
            if (Form1.language != "")
            {
                refreshlanguage(Form1.language);
            }
            methodlist = value;
            formtemp = formvalue;
        }
        public Method(Form1 formvalue, ArrayList value,MethodEntity tempmethodentity,int flag)
        {
            InitializeComponent();
            if (Form1.language != "")
            {
                refreshlanguage(Form1.language);
            }
            methodlist = value;
            formtemp = formvalue;
            methodtemp = tempmethodentity;
            editflag = flag;
        }
        private void nextbtn_Click(object sender, EventArgs e)
        {
            MySqlDataReader mysqlreader = database.select("Methodtable", "Methodname");
            while (mysqlreader.Read())
            {
                if (mysqlreader[0].ToString().Equals(methodnamevalue.Text)&& editflag==0)
                {
                    MessageBox.Show("method has been created");
                    return;
                }
            }
            ArrayList namelisttemp = new ArrayList();
            methodtemp.setmethodname(methodnamevalue.Text);
            methodtemp.setsensitive(5);
            string line = namevalue.Text;

            //Regex reg = new Regex("[A-Za-z0-9]+");
            string[] match = Regex.Split(line, ",| ,|, ");
            //MatchCollection match = reg.Matches(line);
            if (Paramaternumbertextbox.Text!=""&&match.Length == int.Parse(Paramaternumbertextbox.Text))
            {
                for (int i = 0; i < match.Length; i++)
                {
                    Settingentity settingentity = new Settingentity();
                    string value = match[i].ToString();
                    namelisttemp.Add(value);
                    settingentity.setparamatername(value);
                    if (methodtemp.getsettinglist().Count > 0)
                    {
                        for (int j = 0; j < methodtemp.getsettinglist().Count; j++)
                        {
                            if (((Settingentity)methodtemp.getsettinglist()[j]).getparamatername() == value)
                            {
                                break;
                            }
                            else if (j == methodtemp.getsettinglist().Count-1)
                            {
                                methodtemp.getsettinglist().Add(settingentity);
                            }
                        }
                    }
                    else
                    {
                        methodtemp.getsettinglist().Add(settingentity);
                    }
                }
                //namelist = namelisttemp;  
                MethodNext temp = new MethodNext(this, formtemp, methodlist, methodtemp,editflag);
                //MethodNext temp = new MethodNext();
                temp.TopLevel = false;
                temp.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None; 
                temp.Dock = System.Windows.Forms.DockStyle.Fill;
                panel1.Controls.Clear();
                panel1.Controls.Add(temp);
                for (int i = 0; i < namelisttemp.Count; i++)
                {
                    TabPage tab = new TabPage();
                    tab.Name = (string)namelisttemp[i];
                    tab.Text = (string)namelisttemp[i];

                    MethodSettingEntity form = new MethodSettingEntity(this, formtemp, temp, methodlist, methodtemp, i);
                    form.TopLevel = false;     
                    tab.Controls.Add(form.panel1);
                    temp.tabControl1.TabPages.Add(tab);
                    form.Show();
                }
                temp.Show();
            }
            else
            {
                MessageBox.Show("Please input correct number");
            }
        }

        private void methodnamelab_Click(object sender, EventArgs e)
        {

        }

        private void cancelbtn_Click(object sender, EventArgs e)
        {

        }

        private void namevalue_TextChanged(object sender, EventArgs e)
        {

        }

        private void methodnamevalue_TextChanged(object sender, EventArgs e)
        {

        }

        private void namelab_Click(object sender, EventArgs e)
        {

        }

        private void Method_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                for (int i = 0; i < this.Controls[0].Controls[0].Controls[0].Controls[0].Controls.Count; i++)
                {
                    if (this.Controls[0].Controls[0].Controls[0].Controls[0].Controls[i].Name == "videPlayer")
                    {
                        AForge.Controls.VideoSourcePlayer tempvideo = (AForge.Controls.VideoSourcePlayer)this.Controls[0].Controls[0].Controls[0].Controls[0].Controls[i];
                        tempvideo.SignalToStop();
                        tempvideo.WaitForStop();
                    }
                }
            }
            catch (Exception)
            {

            }
        }

        public void getclosingmethod()
        {
            Method_FormClosing(null, null);
        }

        internal void refreshlanguage(string name)
        {
            StreamReader sr = new StreamReader(System.Environment.CurrentDirectory + "\\" + name + ".txt", Encoding.Default);
            String line;
            while ((line = sr.ReadLine()) != null)
            {
                Regex reg = new Regex("[A-Za-z0-9]*:");
                MatchCollection match = reg.Matches(line);
                if (match.Count != 0)
                {
                    reg = new Regex("[A-Za-z0-9]+");
                    match = reg.Matches(match[0].ToString());
                    string result = sr.ReadLine();
                    for (int i = 0; i < this.panel1.Controls.Count; i++)
                    {
                        if (this.panel1.Controls[i].Name == match[0].ToString())
                        {
                            this.panel1.Controls[i].Text = result;
                            break;
                        }
                        else if (this.panel1.Controls[i].Name == "menuStrip1")
                        {
                            for (int k = 0; k < ((MenuStrip)this.panel1.Controls[i]).Items.Count; k++)
                            {
                                if (((MenuStrip)this.panel1.Controls[i]).Items[k].Name == match[0].ToString())
                                {
                                    ((MenuStrip)this.panel1.Controls[i]).Items[k].Text = result;
                                }
                                else
                                {
                                    if (((ToolStripMenuItem)((MenuStrip)this.panel1.Controls[i]).Items[k]).DropDownItems.Count != 0)
                                    {
                                        for (int m = 0; m < ((ToolStripMenuItem)((MenuStrip)this.panel1.Controls[i]).Items[k]).DropDownItems.Count; m++)
                                        {
                                            if (((ToolStripMenuItem)((MenuStrip)this.panel1.Controls[i]).Items[k]).DropDownItems[m].Name == match[0].ToString())
                                            {
                                                ((ToolStripMenuItem)((MenuStrip)this.panel1.Controls[i]).Items[k]).DropDownItems[m].Text = result;

                                            }
                                            else
                                            {
                                                if (((ToolStripMenuItem)((ToolStripMenuItem)((MenuStrip)this.panel1.Controls[i]).Items[k]).DropDownItems[m]).DropDownItems.Count != 0)
                                                {
                                                    for (int n = 0; n < ((ToolStripMenuItem)((ToolStripMenuItem)((MenuStrip)this.panel1.Controls[i]).Items[k]).DropDownItems[m]).DropDownItems.Count; n++)
                                                    {
                                                        if (((ToolStripMenuItem)((ToolStripMenuItem)((MenuStrip)this.panel1.Controls[i]).Items[k]).DropDownItems[m]).DropDownItems[n].Name == match[0].ToString())
                                                        {
                                                            ((ToolStripMenuItem)((ToolStripMenuItem)((MenuStrip)this.panel1.Controls[i]).Items[k]).DropDownItems[m]).DropDownItems[n].Text = result;
                                                        }
                                                    }
                                                }
                                            }
                                        }
                                    }
                                }

                            }

                        }
                    }
                }
            }

        }

        private void Paramaternumbertextbox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!((e.KeyChar >= '0' && e.KeyChar <= '9') || (int)e.KeyChar == (int)(char)Keys.Back))
            {
                e.Handled = true;
            }
        }

        private void Method_Load(object sender, EventArgs e)
        {
            if (methodtemp.getsettinglist().Count > 0)
            {
                methodnamevalue.Text = methodtemp.getmethodname();
                Paramaternumbertextbox.Text = methodtemp.getsettinglist().Count.ToString();
                String temp = "";
                for (int i = 0; i < methodtemp.getsettinglist().Count; i++)
                {
                    temp = temp + ((Settingentity)methodtemp.getsettinglist()[i]).getparamatername();
                    if (i != methodtemp.getsettinglist().Count - 1)
                    {
                        temp = temp + ",";
                    }
                }
                namevalue.Text = temp;
            }
        }
    }
}
