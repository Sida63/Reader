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
using System.IO;
using System.Text.RegularExpressions;

namespace Readerversion1._0
{
    public partial class MethodSettingEntity : Form
    {
        private Settingentity settingentity;
        private Method form;
        private MethodEntity methodtemp;
        private ArrayList methodlisttemp;
        private Form1 formtemp;
        private MethodNext methodnexttemp;
        public string newparamatername;
        public MethodSettingEntity()
        {
            InitializeComponent();
        }
        public MethodSettingEntity(Settingentity value)
        {
            InitializeComponent();
            settingentity = value;
        }
        public MethodSettingEntity(Method formvalue, Form1 mainformvalue, MethodNext methodnexttempvalue, ArrayList valuelist, MethodEntity methodvalue, int value)
        {
            InitializeComponent();
            if (Form1.language != "")
            {
                refreshlanguage(Form1.language);
            }
            methodtemp = methodvalue;
            methodnexttemp = methodnexttempvalue;
            settingentity = (Settingentity)methodvalue.getsettinglist()[value];
            methodlisttemp = valuelist;
            form = formvalue;
            formtemp = mainformvalue;
            clinevalue.SelectedIndex = 0;
            namevalue.Text = settingentity.getparamatername();
        }
        private void savebtn_Click(object sender, EventArgs e)
        {
            /*settingentity.setreadytime(int.Parse(readytimevalue.Text));
            settingentity.setshuttertimes(int.Parse(shuttertimevalue.Text));
            settingentity.setclinevalue(clinevalue.Text);
            /*bool flagtemp=true;
            for (int i = 0; i < methodlisttemp.Count; i++)
            {
                MethodEntity temp=(MethodEntity)methodlisttemp[i];
                if (temp.getmethodname() == methodtemp.getmethodname())
                {
                    flagtemp = false;
                    break;
                }
            }
            if(flagtemp==true)
                methodlisttemp.Add(methodtemp);*/
            /*Settingdetectsection temp = new Settingdetectsection(form,formtemp,methodlisttemp,methodtemp);
            temp.TopLevel = false;
            temp.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None; //设置窗体为非边框样式
            temp.Dock = System.Windows.Forms.DockStyle.Fill;
            panel1.Controls.Clear();
            panel1.Controls.Add(temp);
            temp.Show();*/
            
            //formtemp.OnLoad();
            //form.Dispose();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
           // namevalue.Text = settingentity.getparamatername();
        }

        private void deleteparamaterbtn_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < methodnexttemp.tabControl1.Controls.Count; i++)
            {
                TabPage tab = (TabPage)methodnexttemp.tabControl1.Controls[i];
                if (tab.Name == namevalue.Text.ToString())
                {
                    methodnexttemp.tabControl1.Controls.Remove(tab);
                    methodtemp.getsettinglist().Remove(settingentity);
                    methodnexttemp.Refresh();
                    break;
                }
            }
        }

        private void addparamaterbtn_Click(object sender, EventArgs e)
        {
            Settingentity newsettingentity = new Settingentity();
            newsettingentity.setparamatername(newparamatername);
            methodtemp.getsettinglist().Add(newsettingentity);
            TabPage tab = new TabPage();
            tab.Name = newparamatername;
            tab.Text = newparamatername;
            MethodSettingEntity newmethodsettingentity = new MethodSettingEntity(form, formtemp, methodnexttemp, methodlisttemp, methodtemp, methodtemp.getsettinglist().Count-1);
            newmethodsettingentity.TopLevel = false;     
            tab.Controls.Add(newmethodsettingentity.panel1);
            methodnexttemp.tabControl1.TabPages.Add(tab);
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

        private void rangesettingbtn_Click(object sender, EventArgs e)
        {
            TestlineSetting testlineform = new TestlineSetting(settingentity);
            testlineform.ShowDialog();
        }

        private void MethodSettingEntity_Load(object sender, EventArgs e)
        {
            namevalue.Text = settingentity.getparamatername();
            clinevalue.Text = settingentity.getlinevalue();
            if (clinevalue.Text.Equals(""))
            {
                clinevalue.SelectedIndex = 0;
            }
            for(int i=0;i<settingentity.getresultentitylist().Count;i++)
                if(((ResultEntity)settingentity.getresultentitylist()[i]).getresultname()=="Control line")
                {
                    setstartvalue.Text = ((ResultEntity)settingentity.getresultentitylist()[i]).getresultstartvalue().ToString();
                    setendvalue.Text = ((ResultEntity)settingentity.getresultentitylist()[i]).getresultendvalue().ToString();
                }
            shuttertimevalue.Text = settingentity.getshuttertimes().ToString();
            readytimevalue.Text = settingentity.getreadytime().ToString();
        }

        private void setstartvalue_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!((e.KeyChar >= '0' && e.KeyChar <= '9') || (int)e.KeyChar == (int)(char)Keys.Back))
            {
                e.Handled = true;
            }
        }

        private void setendvalue_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!((e.KeyChar >= '0' && e.KeyChar <= '9') || (int)e.KeyChar == (int)(char)Keys.Back))
            {
                e.Handled = true;
            }
        }

        private void shuttertimevalue_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!((e.KeyChar >= '0' && e.KeyChar <= '9') || (int)e.KeyChar == (int)(char)Keys.Back))
            {
                e.Handled = true;
            }
        }

        private void readytimevalue_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!((e.KeyChar >= '0' && e.KeyChar <= '9') || (int)e.KeyChar == (int)(char)Keys.Back))
            {
                e.Handled = true;
            }
        }
    }
}
