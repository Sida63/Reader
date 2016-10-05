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
    public partial class MethodNext : Form
    {
        private MethodEntity methodtemp;
        private ArrayList methodlisttemp;
        private Method method;
        private Form1 formtemp;
        private ArrayList methodlist;
        private int editflag;
        public MethodNext()
        {
            InitializeComponent();
        }
        public MethodNext(ArrayList valuelist,MethodEntity value)
        {
            InitializeComponent();
            if (Form1.language != "")
            {
                refreshlanguage(Form1.language);
            }
            methodtemp = value;
            methodlisttemp = valuelist;
        }

        public MethodNext(Method method, Form1 formtemp, ArrayList methodlist, MethodEntity methodtemp,int flag)
        {
            // TODO: Complete member initialization
            InitializeComponent();
            if (Form1.language != "")
            {
                refreshlanguage(Form1.language);
            }
            this.method = method;
            this.formtemp = formtemp;
            this.methodlisttemp = methodlist;
            this.methodtemp = methodtemp;
            this.editflag = flag;
        }

        private void savebtn_Click(object sender, EventArgs e)
        {
            
            for (int i = 0; i < tabControl1.TabPages.Count; i++)
            {
                ResultEntity temp = new ResultEntity();
                for (int j = 0; j < tabControl1.TabPages[i].Controls[0].Controls.Count; j++)
                {
                    if (tabControl1.TabPages[i].Controls[0].Controls[j].Name == "readytimevalue")
                    {
                        Settingentity settingentitytemp = (Settingentity)methodtemp.getsettinglist()[i];
                        settingentitytemp.setreadytime(int.Parse(tabControl1.TabPages[i].Controls[0].Controls[j].Text));

                    }
                    else if (tabControl1.TabPages[i].Controls[0].Controls[j].Name == "namevalue")
                    {
                        Settingentity settingentitytemp = (Settingentity)methodtemp.getsettinglist()[i];
                        settingentitytemp.setparamatername(tabControl1.TabPages[i].Controls[0].Controls[j].Text.ToString());
                    }
                    else if (tabControl1.TabPages[i].Controls[0].Controls[j].Name == "shuttertimevalue")
                    {
                        Settingentity settingentitytemp = (Settingentity)methodtemp.getsettinglist()[i];
                        settingentitytemp.setshuttertimes(int.Parse(tabControl1.TabPages[i].Controls[0].Controls[j].Text));
                    }
                    else if (tabControl1.TabPages[i].Controls[0].Controls[j].Name == "clinevalue")
                    {
                        Settingentity settingentitytemp = (Settingentity)methodtemp.getsettinglist()[i];
                        settingentitytemp.setclinevalue(tabControl1.TabPages[i].Controls[0].Controls[j].Text.ToString());
                    }
                    else if (tabControl1.TabPages[i].Controls[0].Controls[j].Name == "setstartvalue")
                    {
                        temp.setresultname("Control line");
                        temp.setresultstartvalue(int.Parse(tabControl1.TabPages[i].Controls[0].Controls[j].Text));

                    }
                    else if (tabControl1.TabPages[i].Controls[0].Controls[j].Name == "setendvalue")
                    {
                        temp.setresultname("Control line");
                        temp.setresultendvalue(int.Parse(tabControl1.TabPages[i].Controls[0].Controls[j].Text));

                    }
                }
                Settingentity settingentitytempforresult = (Settingentity)methodtemp.getsettinglist()[i];
                for (int k = 0; k < settingentitytempforresult.getresultentitylist().Count; k++)
                {
                    if (((ResultEntity)settingentitytempforresult.getresultentitylist()[k]).getresultname() == "Control line")
                    {
                        settingentitytempforresult.getresultentitylist().RemoveAt(k);
                    }
                }
                    settingentitytempforresult.getresultentitylist().Add(temp);

            }

            Settingdetectsection settemp = new Settingdetectsection(method, formtemp, methodlisttemp, methodtemp,editflag);
            settemp.TopLevel = false;
            settemp.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            settemp.Dock = System.Windows.Forms.DockStyle.Fill;
            panel1.Controls.Clear();
            panel1.Controls.Add(settemp);
            settemp.Show();
            //formtemp.OnLoad();
            //method.Dispose();
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
    }
}
